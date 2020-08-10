using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServiceConfigurationContract
{
    [DataContract]
    public class MenuOption
    {
        private Int32 _width;
        private Int32 _height;
        private string _menuGroup;
        private string _menuName;
        private string _menuText;
        private string _menuTooltip;
        private string _menuPathIcon;
        private string _menuPathContent;

        [DataMember] public string MenuName { get => _menuName; set => _menuName = value; }
        [DataMember] public string MenuText { get => _menuText; set => _menuText = value; }
        [DataMember] public string MenuTooltip { get => _menuTooltip; set => _menuTooltip = value; }
        [DataMember] public string MenuPathIcon { get => _menuPathIcon; set => _menuPathIcon = value; }
        [DataMember] public string MenuPathContent { get => _menuPathContent; set => _menuPathContent = value; }
        [DataMember] public string MenuGroup { get => _menuGroup; set => _menuGroup = value; }
        [DataMember] public int Width { get => _width; set => _width = value; }
        [DataMember] public int Height { get => _height; set => _height = value; }
    }
}
