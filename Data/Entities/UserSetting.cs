using System;
using System.Collections.Generic;

namespace Biztalk.Monitor.Data.Entities
{
    public partial class UserSetting
    {
        public string UserName { get; set; }
        public string SettingName { get; set; }
        public string SettingValue { get; set; }
    }
}
