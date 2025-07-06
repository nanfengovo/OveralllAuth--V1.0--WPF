using Prism.Mvvm;
using System.ComponentModel;
using System.Windows.Threading;
using System;
using Prism.Commands;
using Prism.Regions;
using System.Windows.Input;
using 导航Demo.Views;

namespace OveralllAuth_V1.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";

        private readonly IRegionManager _regionManager;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }


        private string _currentDate;
        private string _currentTime;
        private string _iconData;

        // 当前日期
        public string CurrentDate
        {
            get { return _currentDate; }
            set
            {
                _currentDate = value;
                OnPropertyChanged(nameof(CurrentDate));
            }
        }

        // 当前时间
        public string CurrentTime
        {
            get { return _currentTime; }
            set
            {
                _currentTime = value;
                OnPropertyChanged(nameof(CurrentTime));
            }
        }

        // 当前图标数据 ("sun" 或 "moon")
        public string IconData
        {
            get { return _iconData; }
            set
            {
                _iconData = value;
                OnPropertyChanged(nameof(IconData));
            }
        }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            //初始化时更新一次日期和时间
            CurrentDate = DateTime.Now.ToString("MM月dd日  dddd", new System.Globalization.CultureInfo("zh-CN"));
            CurrentTime = DateTime.Now.ToString("HH:mm");

            // 初始化图标数据
            UpdateIconData();

            // 设置定时器每秒更新一次时间
            //var timer = new DispatcherTimer();
            //timer.Interval = TimeSpan.FromSeconds(1);
            //timer.Tick += (sender, args) =>
            //{
            //    // 更新时间
            //    CurrentTime = DateTime.Now.ToString("HH:mm");
            //    CurrentDate = DateTime.Now.ToString("MM月dd日  dddd", new System.Globalization.CultureInfo("zh-CN"));

            //    // 更新图标
            //    UpdateIconData();
            //};
            //timer.Start();
            _regionManager = regionManager;
            GoView1Cmm = new DelegateCommand(GoView1);
            HomeCmm = new DelegateCommand(GoHome);
        }

        // 根据时间更新图标数据
        private void UpdateIconData()
        {
            // 获取当前小时
            var hour = DateTime.Now.Hour;

            // 白天时间段：6:00 - 18:00，晚上为 moon 图标
            IconData = hour >= 6 && hour < 18 ? "sun" : "moon";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        #region 导航切换
        public ICommand GoView1Cmm { get; set; }

        public void GoView1()
        {
            _regionManager.Regions["MainViewRegion"].RequestNavigate("View1");
        }

        //public DelegateCommand HomeCmm { get; set; }

        // 修改后
        public ICommand HomeCmm { get; private set; }  // 实现ICommand接口

        public void GoHome()
        {
            _regionManager.Regions["MainViewRegion"].RequestNavigate("HomeUC");
        }



        #endregion
    }
}
