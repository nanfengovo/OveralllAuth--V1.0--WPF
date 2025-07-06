using Prism.Regions;
using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace OveralllAuth__V1._0__WPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool IsMenuExpanded = true; // 导航栏初始状态为展开
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            var widthAnimation = new DoubleAnimation
            {
                From = menuBoard.Width,
                To = IsMenuExpanded ? 0 : 250,
                Duration = TimeSpan.FromMilliseconds(1000), // 增加动画持续时间
                EasingFunction = new SineEase { EasingMode = EasingMode.EaseOut } // 使用 SineEase 使动画更平滑
            };

            Storyboard.SetTarget(widthAnimation, menuBoard);
            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(FrameworkElement.WidthProperty));

            var storyboard = new Storyboard();
            storyboard.Children.Add(widthAnimation);
            storyboard.Begin();

            IsMenuExpanded = !IsMenuExpanded; // 切换状态
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
