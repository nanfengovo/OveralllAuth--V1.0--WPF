using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OveralllAuth_V1.Domain.DomainModel
{
    public class MenuItemModel : BindableBase // Prism的BindableBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }

        private string _describe;
        public string Describe
        {
            get => _describe;
            set => SetProperty(ref _describe, value);
        }

        private bool _isEnable;
        public bool IsEnable
        {
            get => _isEnable;
            set => SetProperty(ref _isEnable, value);
        }

        // 当前选中状态
        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }
    }
}
