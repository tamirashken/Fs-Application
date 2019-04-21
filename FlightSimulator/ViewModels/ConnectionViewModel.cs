using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Views;
using FlightSimulator.Model;
using System.Windows.Input;
using FlightSimulator.ViewModels.Windows;
using FlightSimulator.Views.Windows;

namespace FlightSimulator.ViewModels
{
    class ConnectionViewModel
    {
        private FlightManagerModel flightManagerModel;
        public ConnectionViewModel(FlightManagerModel fmd)
        {
            this.flightManagerModel = fmd;
        }

        public Action OpenAction { get; set; }

        #region Commands
        #region SettingsCommand
        private ICommand _SettingsCommand;
        public ICommand SettingsCommand
        {
            get
            {
                return _SettingsCommand ?? (_SettingsCommand = new CommandHandler(() => OnSettings()));
            }
        }
        private void OnSettings()
        {
            Settings settingWin = new Settings();
            settingWin.ShowDialog();  
        }
        #endregion

        #region ConnectCommand
        private ICommand _ConnectCommand;
        public ICommand ConnectCommand
        {
            get
            {
                return _ConnectCommand ?? (_ConnectCommand = new CommandHandler(() => OnConnect()));
            }
        }
        private void OnConnect()
        {
            string ip = ApplicationSettingsModel.Instance.FlightServerIP;
            int portOfCommand = ApplicationSettingsModel.Instance.FlightCommandPort;
            int portOfStart = ApplicationSettingsModel.Instance.FlightInfoPort;
            this.flightManagerModel.start(ip, portOfStart);
            this.flightManagerModel.connect(ip, portOfCommand);
        }
        #endregion
        #endregion
    }
}
