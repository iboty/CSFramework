using System;

namespace CSFramework.Common.Data
{
    public class ComEventArgs : EventArgs
    {
        public ComEventArgs(object data)
        {
            Data = data;
        }
        public object Data { get; }
    }
}
