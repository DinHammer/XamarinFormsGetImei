using System;
using System.Collections.Generic;
using System.Text;
using XamarinFormsGetImei.Constants;

namespace XamarinFormsGetImei.Models
{
    public class MdlAndroidIdentificator
    {
        public MdlAndroidIdentificator(TypeAndroidId typeAndroidId, string id) 
        {
            TypeAndroidId = typeAndroidId;
            Id = id;
        }
        public TypeAndroidId TypeAndroidId { get; private set; }
        public string Id { get; private set; }
    }
}
