using System;
using System.Windows;

using OveralllAuth__V1._0__WPF.Views;
using OveralllAuth_V1.ViewModels;
using OveralllAuth_V1.Views;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Services.Dialogs;
using 导航Demo.ViewModels;
using 导航Demo.Views;

namespace OveralllAuth__V1._0__WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App:PrismApplication
    {
        /// <summary>
        /// 设置启动页
        /// </summary>
        /// <returns></returns>
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        /// <summary>
        /// 注入需要的服务
        /// </summary>
        /// <param name="containerRegistry"></param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //登录
            containerRegistry.RegisterDialog<LoginUC, LoginUCViewModel>();
            containerRegistry.RegisterForNavigation<MainWindow>();
            //containerRegistry.RegisterForNavigation<HomeUC>("HomeUC"); // 关键注册
            containerRegistry.RegisterForNavigation<View1, View1ViewModel>();
            // 需要添加这行：
            containerRegistry.RegisterForNavigation<HomeUC, HomeUCViewModel>();
        }


        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            //var dialog = Container.Resolve<IDialogService>();
            //dialog.ShowDialog("LoginUC", callback =>
            //{
            //    if (callback.Result != ButtonResult.OK)
            //    {
            //        Application.Current.Shutdown(); // 登录取消则退出
            //    }
            //    else
            //    {
            //        // 登录成功，创建主窗口
            //        var mainWindow = Container.Resolve<MainWindow>();
            //        Application.Current.MainWindow = mainWindow;
            //        mainWindow.Show();
            //    }
            //});

            var mainWindow = Container.Resolve<MainWindow>();
            Application.Current.MainWindow = mainWindow;
            mainWindow.Show();
        }
    }
}
