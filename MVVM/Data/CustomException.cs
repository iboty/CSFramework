using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Runtime.Serialization;
using System.Text;

namespace CSFramework.MVVM.Data
{
    public class CustomException : Exception
    {
        public CustomException(Enum errorCode, string msg = null, object data = null) : base(msg)
        {
            ErrorCode = errorCode;
            MessageData = data;
        }

        /// <summary>
        /// 消息主题
        /// </summary>
        public string MessageTheme { get; private set;}

        public Enum ErrorCode { get; private set; }
        
        public object MessageData { get; private set; }

    }
  
}
