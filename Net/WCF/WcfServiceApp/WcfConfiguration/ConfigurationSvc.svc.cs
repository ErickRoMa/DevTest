using ServiceConfigurationContract;
using System.Collections.Generic;

namespace WcfConfiguration
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ConfigurationSvc : IConfigurationSvc
    {
        public IList<MenuOption> MenuOptions()
        {
            IList<MenuOption> menuOptions = new List<MenuOption>
            {
                new MenuOption
                {
                    Height=24,
                    Width=24,
                    MenuGroup = "Cobranza",
                    MenuName = "Payment",
                    MenuText = "Pagos",
                    MenuPathIcon = "../Utils/Icon/calendar.ico",
                    MenuPathContent = "WpfPaymentApp.View.Payment.PaymentUsr",
                    MenuTooltip = "Pagos"
                }
            };

            return menuOptions;
        }
    }
}
