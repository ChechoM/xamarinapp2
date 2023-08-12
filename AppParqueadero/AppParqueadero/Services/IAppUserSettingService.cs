using System;
using System.Collections.Generic;
using System.Text;

namespace AppParqueadero.Services
{
    public interface IAppUserSettingService
    {
        string UserName { get; set; }
        string UserToken { get; set; }
        void Clear();

    }

}
