using System.Configuration;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Xamless.Resources.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Global Variables / Properties

        private WindowState _windowState;
        public WindowState WindowState
        {
            get { return this._windowState; }
            set { Set(ref _windowState, value); }
        }

        public bool IsMaximized
        {
            get { return WindowState == WindowState.Maximized; }
        }

        private string _windowTitle;
        public string WindowTitle
        {
            get { return this._windowTitle; }
            set { Set(ref _windowTitle, value); }
        }

        private string _currentUrl;
        public string CurrentUrl
        {
            get { return this._currentUrl; }
            set { Set(ref _currentUrl, value); }
        }

        private RelayCommand<MainWindow> _titlebarDragCommand;
        public RelayCommand<MainWindow> TitlebarDragCommand
        {
            get
            {
                return _titlebarDragCommand ?? (_titlebarDragCommand = new RelayCommand<MainWindow>(window =>
                {
                    window.DragMove();
                }));
            }
        }

        private RelayCommand _titlebarDoubleClickCommand;
        public RelayCommand TitlebarDoubleClickCommand
        {
            get
            {
                return _titlebarDoubleClickCommand ?? (_titlebarDoubleClickCommand = new RelayCommand(() =>
                {
                    WindowState = IsMaximized ? WindowState.Normal : WindowState.Maximized;
                    RaisePropertyChanged(() => IsMaximized);
                }));
            }
        }

        private RelayCommand<MainWindow> _closeClickCommand;
        public RelayCommand<MainWindow> CloseClickCommand
        {
            get
            {
                return _closeClickCommand ?? (_closeClickCommand = new RelayCommand<MainWindow>(window =>
                {
                    window.Close();
                }));
            }
        }

        private RelayCommand _minimizeClickCommand;
        public RelayCommand MinimizeClickCommand
        {
            get
            {
                return _minimizeClickCommand ?? (_minimizeClickCommand = new RelayCommand(() =>
                {
                    WindowState = WindowState.Minimized;
                    RaisePropertyChanged(() => IsMaximized);
                }));
            }
        }

        private RelayCommand _maximizeClickCommand;
        public RelayCommand MaximizeClickCommand
        {
            get
            {
                return _maximizeClickCommand ?? (_maximizeClickCommand = new RelayCommand(() =>
                {
                    WindowState = WindowState.Maximized;
                    RaisePropertyChanged(() => IsMaximized);
                }));
            }
        }

        private RelayCommand _windowClickCommand;
        public RelayCommand WindowClickCommand
        {
            get
            {
                return _windowClickCommand ?? (_windowClickCommand = new RelayCommand(() =>
                {
                    WindowState = WindowState.Normal;
                    RaisePropertyChanged(() => IsMaximized);
                }));
            }
        }

        #endregion

        #region Constructor

        public MainViewModel()
        {
            //Load the settings from the config file.
            CurrentUrl = ConfigurationManager.AppSettings[Enums.AppSettingKeys.BrowserStartUrl.ToString()];
            WindowTitle = ConfigurationManager.AppSettings[Enums.AppSettingKeys.WindowTitle.ToString()];
        }

        #endregion
    }
}