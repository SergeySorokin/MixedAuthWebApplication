using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Reflection;
using System.Web.Configuration;
using System.Security.Principal;

namespace Mvolo.Modules
{
    public class FormsAuthModule : IHttpModule
    {
        public const string EnableFormsAuthServerVariableName = "FormsAuth_Enable";

        private System.Web.Security.FormsAuthenticationModule _module;
        private bool _enabled;
        private MethodInfo _onEnter;
        private MethodInfo _onLeave;
        private FormsAuthConfigurationSection _config;
        #region IHttpModule Members

        public void Dispose()
        {
            _module.Dispose();
            _module = null;
            GC.SuppressFinalize(this);
        }

        public void Init(HttpApplication app)
        {
            // Create the real FormsAuthenticationModule to which we will delegate
            _module = new System.Web.Security.FormsAuthenticationModule();

            // This may throw an exception when trying to register the module
            // event handlers.  This exception is expected and doesnt affect
            // the operation. However, catching this exception here is
            // a poor practice because it may hide other exceptions.
            try
            {
                using (HttpApplication dummy = new HttpApplication())
                {
                    _module.Init(dummy);
                }
            }
            catch (Exception e)
            {
            }

            // Get the methods on it (private) using private reflection
            // NOTE: this requires full trust
            Type t = _module.GetType();
            _onEnter = t.GetMethod(
                "OnEnter", 
                BindingFlags.NonPublic | BindingFlags.Instance, 
                null, 
                new Type[] { typeof(Object), typeof(EventArgs) }, 
                null
                );
            _onLeave = t.GetMethod(
                "OnLeave", 
                BindingFlags.NonPublic | BindingFlags.Instance, 
                null, 
                new Type[] { typeof(Object), typeof(EventArgs) }, 
                null
                );
            if (_onEnter == null
                    || _onLeave == null)
            {
                throw new Exception("Unable to get all required FormsAuthenticationModule entrypoints using reflection.");
            }

            // Register for the required notifications
            app.AuthenticateRequest += new EventHandler(OnAuthenticateRequest);
            app.PostAuthenticateRequest += new EventHandler(OnPostAuthenticateRequest);
            app.EndRequest += new EventHandler(OnEndRequest);
        }

        #endregion

        public bool IsFormsAuthEnabled(HttpContext context)
        {
            bool enabled = true;
            string enabledSV = context.Request.ServerVariables[EnableFormsAuthServerVariableName];
            if (!String.IsNullOrEmpty(enabledSV))
            {
                if (enabledSV.Equals("true", StringComparison.InvariantCultureIgnoreCase))
                {
                    enabled = true;
                }
                else
                {
                    enabled = false;
                }
            }

            return enabled;
        }

        public static void EnableFormsAuth(HttpContext context, bool enable)
        {
            if (enable)
            {
                context.Request.ServerVariables[EnableFormsAuthServerVariableName] = "true";
            }
            else
            {
                context.Request.ServerVariables[EnableFormsAuthServerVariableName] = "false";
            }
        }

        public void OnPostAuthenticateRequest(Object source, EventArgs e)
        {
            HttpApplication app = (HttpApplication)source;
            HttpContext context = app.Context;

            // If Forms Authentication is not enabled, 
            // bring over the IIS user (unless disabled in configuration, or 
            // someone already set the user)
            if (!_enabled 
                    && context.User == null
                    && _config != null 
                    && _config.UseIISUser )
            {
                WindowsIdentity iisIdentity = context.Request.LogonUserIdentity;
                if (iisIdentity != null)
                {
                    if (iisIdentity.IsAnonymous)
                    {
                        context.User = new WindowsPrincipal(WindowsIdentity.GetAnonymous());
                    }
                    else
                    {
                        context.User = new WindowsPrincipal(iisIdentity);
                    }
                }
            }
        }

        public void OnAuthenticateRequest(Object source, EventArgs e)
        {
            HttpApplication app = (HttpApplication)source;
            HttpContext context = app.Context;

            _enabled = false;

            // Check whether we are enabled in configuration
            _config = WebConfigurationManager.GetSection(
                        FormsAuthConfigurationSection.ConfigurationSectionName,
                        context.Request.Path
                      ) as FormsAuthConfigurationSection;
            if (_config == null || !_config.Enabled)
            {
                return;
            }

            // Check whether we are enabled at runtime
            if (!IsFormsAuthEnabled(context))
            {
                return;
            }

            _enabled = true;

            // Invoke the underlying module
            _onEnter.Invoke(_module, new Object[] {source, e});
        }

        public void OnEndRequest(Object source, EventArgs e)
        {
            if (!_enabled)
            {
                return;
            }

            // Invoke the underlying module
            _onLeave.Invoke(_module, new Object[] { source, e });
        }
    }
}
