using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;
using System.Windows.Input;


namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
        private FlightManagerModel flightManagerModel;

        public FlightBoardViewModel(FlightManagerModel fmd)
        {
            this.flightManagerModel = fmd;
        }


        public double Lon
        {
            get;
        }

        public double Lat
        {
            get;
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
            OpenAction();

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
           //OpenAction();
        }
        #endregion
        #endregion
    }
}
