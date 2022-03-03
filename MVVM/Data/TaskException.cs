using System;

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
