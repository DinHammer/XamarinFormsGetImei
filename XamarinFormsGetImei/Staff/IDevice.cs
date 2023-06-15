using System;
using System.Collections.Generic;
using System.Text;
using XamarinFormsGetImei.Models;

namespace XamarinFormsGetImei.Staff
{
    public interface IDevice
    {
        //RequestResult<string> GetImei();

        //RequestResult<string> GetAndroidId();

        RequestResult<MdlAndroidIdentificator> GetAndroidId();
        
    }
}
