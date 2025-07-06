using System.Windows;
using OveralllAuth_V1.Views;
using Prism.Ioc;
using 导航Demo.ViewModels;
using 导航Demo.Views;

namespace 导航Demo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<View1,View1ViewModel>();
            containerRegistry.RegisterForNavigation<HomeUC, HomeUCViewModel>();
            containerRegistry.RegisterForNavigation<View2,View2ViewModel>();
        }
    }
}
