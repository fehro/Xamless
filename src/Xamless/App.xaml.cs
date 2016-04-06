using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Owin.Hosting;
using Xamless.Infrastructure;

namespace Xamless
{
    public partial class App : Application
    {
        #region Global Variables / Properties

        private string _selfHostingListenPort;

        #endregion

        #region Constructor

        public App()
        {
            //Load the settings from the config file.
            _selfHostingListenPort = ConfigurationManager.AppSettings[Enums.AppSettingKeys.SelfHostingListenPort.ToString()];
        }

        #endregion

        #region Overridden Methods

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //Configure the Owin middleware.
            ConfigureOwinMiddleware();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Configure the Owin middleware if it is enabled.
        /// </summary>
        private void ConfigureOwinMiddleware()
        {
            //If no self hosting listen port has been configured then just return.
            if (string.IsNullOrEmpty(_selfHostingListenPort)) return;

            try
            {
                //Enable the static files configuration.
                var selfHostingListenPort = Convert.ToInt32(_selfHostingListenPort);
                WebApp.Start<OwinStaticFilesConfig>($"http://localhost:{selfHostingListenPort}/");
            }
            catch (Exception ex)
            {
                //Exception.
            }

        }

        #endregion
    }
}
