using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Runtime.Serialization;
using System.Text;

namespace CSFramework.MVVM.Data
{
    public class TaskException : Exception
    {
        public TaskException(ErrorLevel errorLevel, string msg = null) : base(msg)
        {
            ErrorLevel = errorLevel;
        }

        public ErrorLevel ErrorLevel { get; private set; }
    }
  
}
