using System;
using System.Management;
using CSFramework.MVVM.Data;

namespace CSFramework.Common.Helper
{
    internal static class ComConvert
    {
        internal static RunResult ExceptionToRunResult(Exception e)
        {
            return e == null ? RunResult.Success : RunResult.Fault;
        }
       
    }
}