using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFramework.MVVM.Attributes
{
    public  class ConfigLinkAttr : Attribute
    {
        public string KeyPropertyName { get; set; }

        public string ValuePropertyName { get; set; }

        public string DescPropertyName { get; set; }
    }
}
