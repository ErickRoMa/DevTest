﻿using ServiceConfigurationContract;
using System.Collections.Generic;
using System.ServiceModel;

namespace WcfConfiguration
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IConfigurationSvc
    {

        [OperationContract]
        IList<MenuOption> MenuOptions();        
    }    
}
