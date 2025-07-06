using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace OveralllAuth_V1.ViewModels
{
    public class LoginUCViewModel : BindableBase, IDialogAware
    {
        public event Action<IDialogResult> RequestClose;

        public string Title { get; set; } = "权限管理";

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            // Handle dialog closed logic here
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            // Handle dialog opened logic here
        }

        public void CloseDialog(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }

        #region 账号
        private string _Account;

        public string Account
        {
            get { return _Account; }
            set 
            {
                _Account = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region 密码
        private string _pwd;

        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd
        {
            get { return _pwd; }
            set
            {
                _pwd = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public LoginUCViewModel()
        {
            //登录命令
            LoginCmm = new DelegateCommand(Login);
        }

        #region 登录
        public DelegateCommand LoginCmm { get; set; }

        private void Login()
        {
            if(string.IsNullOrEmpty(Account) || string.IsNullOrEmpty(Pwd) )
            {
                MessageBox.Show("用户名和密码不能为空！");
            }
            else
            {
                MessageBox.Show("登录成功！！");
                RequestClose.Invoke(new DialogResult(ButtonResult.OK));
                Account = "";
                Pwd = "";
            }
        }
        #endregion
    }
}
