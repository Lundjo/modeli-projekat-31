using MVVM3.Commands;
using MVVM3.Helpers;
using MVVM3.Model;
using MVVMLight.Messaging;
using System.Windows.Media;
using System;
using System.IO;

namespace MVVM3.ViewModel
{
    public class HomeViewModel : BindableBase
    {
        private string applicationTitle;

        public MyICommand ImportXml { get; set; }
        public MyICommand ResetAll { get; set; }

        public HomeViewModel()
        {
            ApplicationTitle = "GDA Client";

            ImportXml = new MyICommand(ImportXmlData);
            ResetAll = new MyICommand(ClearData);
        }

        private void ImportXmlData()
        {
            new ImportApplyRemoveDataCommands().ImportData();
        }

        private void ClearData()
        {
            try
            {
                string solutionDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.FullName;
                string dataPath = Path.Combine(solutionDirectory, "NetworkModelData.data");

                if (File.Exists(dataPath))
                {
                    File.Delete(dataPath);
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        public string ApplicationTitle
        {
            get { return applicationTitle; }
            set
            {
                applicationTitle = value;
                OnPropertyChanged("ApplicationTitle");
            }
        }
    }
}
