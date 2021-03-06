﻿using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System;
using System.Windows.Input;


namespace FlightSimulator.ViewModels.Windows
{
    public class SettingsWindowViewModel : BaseNotify
    {
        private ISettingsModel model;

        public SettingsWindowViewModel(ISettingsModel model)
        {
            this.model = model;
        }

        public string FlightServerIP
        {
            get { return model.FlightServerIP; }
            set
            {
                model.FlightServerIP = value;
                NotifyPropertyChanged("FlightServerIP");
            }
        }

        public int FlightCommandPort
        {
            get { return model.FlightCommandPort; }
            set
            {
                model.FlightCommandPort = value;
                NotifyPropertyChanged("FlightCommandPort");
            }
        }

        public int FlightInfoPort
        {
            get { return model.FlightInfoPort; }
            set
            {
                model.FlightInfoPort = value;
                NotifyPropertyChanged("FlightInfoPort");
            }
        }


        public void SaveSettings()
        {
           
            model.SaveSettings();
        }

        public void ReloadSettings()
        {
            model.ReloadSettings();
        }


        public Action CloseAction { get; set; }
       

        #region Commands
        #region ClickCommand
        private ICommand _OkCommand;
        public ICommand OkCommand
        {
            get
            {
                return _OkCommand ?? (_OkCommand = new CommandHandler(() => OnOk()));
            }
        }
        private void OnOk()
        {

            SaveSettings();
            
            
        }
        #endregion

        #region CancelCommand
        private ICommand _CancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                return _CancelCommand ?? (_CancelCommand = new CommandHandler(() => OnCancel()));
            }
        }
        private void OnCancel()
        {
            ReloadSettings();
        }
        #endregion
        #endregion
    }
}

