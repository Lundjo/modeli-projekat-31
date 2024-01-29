using FTN.Common;
using MVVM3.Helpers;
using MVVM3.Model;
using MVVMLight.Messaging;
using System.Windows;

namespace MVVM3.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {
        public MyICommand<Window> CloseWindowCommand { get; private set; }
        public MyICommand<string> NavCommand { get; private set; }

        /// View Models
        public HomeViewModel homeViewModel;
        public GetValuesViewModel getValuesViewModel;
        public GetExtentValuesViewModel getExtentViewModel;
        public GetRelatedValuesViewModel getRelatedValuesViewModel;
        private BindableBase currentViewModel;

        public static ModelResourcesDesc modelResourcesDesc = new ModelResourcesDesc();

        public MainWindowViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);

            /// View Models
            getValuesViewModel = new GetValuesViewModel();
            homeViewModel = new HomeViewModel();
            getExtentViewModel = new GetExtentValuesViewModel();
            getRelatedValuesViewModel = new GetRelatedValuesViewModel();
            CurrentViewModel = homeViewModel;

            CloseWindowCommand = new MyICommand<Window>(CloseWindow);
        }

        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                SetProperty(ref currentViewModel, value);
            }
        }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "home":
                    Messenger.Default.Send(new StatusMessage("Welcome to GDA Client - All services are operating normally.", "SteelBlue"));
                    CurrentViewModel = homeViewModel;
                    break;
                case "get":
                    CurrentViewModel = getValuesViewModel;
                    break;
                case "extent":
                    CurrentViewModel = getExtentViewModel;
                    break;
                case "related":
                    CurrentViewModel = getRelatedValuesViewModel;
                    break;
            }
        }

        private void CloseWindow(Window MainWindow)
        {
            MainWindow.Close();
        }
    }
}
