using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfPaymentApp.ViewModel.SharedClass.Model;

namespace WpfPaymentApp.ViewModel.SharedClass
{
    internal class MenuItem : ModelBase
    {
        private Int32 _width;
        private Int32 _height;
        private string _menuGroup;
        private string _menuName;
        private string _menuText;
        private string _menuTooltip;
        private string _menuPathIcon;
        private string _menuPathContent;
        private ICommand _menuCommand;

        public string MenuName { get => _menuName; set { _menuName = value; this.OnPropertyChanged(); } }
        public string MenuText { get => _menuText; set { _menuText = value; this.OnPropertyChanged(); } }
        public string MenuTooltip { get => _menuTooltip; set { _menuTooltip = value; this.OnPropertyChanged(); } }
        public string MenuPathIcon { get => _menuPathIcon; set { _menuPathIcon = value; this.OnPropertyChanged(); } }
        public string MenuPathContent { get => _menuPathContent; set { _menuPathContent = value; this.OnPropertyChanged(); } }
        public ICommand MenuCommand { get => _menuCommand; set { _menuCommand = value; this.OnPropertyChanged(); } }
        public string MenuGroup { get => _menuGroup; set { _menuGroup = value; OnPropertyChanged(); } }

        public int Width { get => _width; set { _width = value; OnPropertyChanged(); } }
        public int Height { get => _height; set { _height = value; OnPropertyChanged(); } }
    }
}
