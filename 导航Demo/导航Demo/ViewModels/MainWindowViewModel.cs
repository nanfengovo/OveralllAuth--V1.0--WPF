using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows.Input;

namespace 导航Demo.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private readonly IRegionManager _regionManager;

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            GoView1Cmm = new DelegateCommand(GoView1);
            HomeCmm = new DelegateCommand(GoHome);
        }

        public ICommand GoView1Cmm {  get; set; }

        public void GoView1()
        {
            _regionManager.Regions["MainViewRegion"].RequestNavigate("View1");
        }

        public ICommand HomeCmm { get; private set; }  // 实现ICommand接口

        public void GoHome()
        {
            _regionManager.Regions["MainViewRegion"].RequestNavigate("HomeUC");
        }
    }
}
