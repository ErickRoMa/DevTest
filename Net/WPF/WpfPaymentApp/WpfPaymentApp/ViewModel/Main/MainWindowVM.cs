using System;
using System.Collections.Generic;
using System.Linq;
using WcfConfiguration;
using WpfPaymentApp.Utils.SharedClass.Message;
using WpfPaymentApp.ViewModel.BaseClass;
using WpfPaymentApp.ViewModel.SharedClass;
using WpfPaymentApp.ViewModel.SharedClass.Helpers;

namespace WpfPaymentApp.ViewModel.Main
{
    internal class MainWindowVM : ViewModelBase
    {
        public MainWindowVM(IMessenger messenger) : base(messenger)
        {
            LoadMenuItems();
        }

        private IList<MenuItem> _menuItems = default;

        private object _selectedView = default;

        public IList<MenuItem> MenuItems { get => _menuItems; set { _menuItems = value; this.OnPropertyChanged(); } }

        public object SelectedView { get => _selectedView; set { _selectedView = value; OnPropertyChanged(); } }

        protected void LoadMenuItems()
        {
            using (ServerProxy<IConfigurationSvc> proxy = new ServerProxy<IConfigurationSvc>())
            {
                MenuItems = proxy.Service.MenuOptions().Select(r =>
                {
                    MenuItem menuItem = r.ContractToEntity<MenuItem>();
                    menuItem.Height = menuItem.Height == 0 ? 24 : menuItem.Height;
                    menuItem.Width = menuItem.Width == 0 ? 24 : menuItem.Width;
                    menuItem.MenuCommand = new RelayCommand((object param) => { OnSelectedMenuItem(param); });
                    return menuItem;
                }
                ).ToList();
            }
        }

        private void OnSelectedMenuItem(object sender)
        {
            if (!(sender is MenuItem))
                return;

            MenuItem item = sender as MenuItem;

            SelectedView = ViewContainer.GetContainerView.AddNewViewIntance(item.MenuPathContent, this.GetType().Assembly);
        }
    }
}