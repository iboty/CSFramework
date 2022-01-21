using System;
using System.Collections.Generic;

namespace CSFramework.Common.Helper
{
    /// <summary>
    /// 输入密码缓存，用于记录同一个用户密码输入错误次数
    /// </summary>
    public static class InputPwdCache
    {
        private static readonly Dictionary<string, PwdCheckRecord> InputCache = new Dictionary<string, PwdCheckRecord>();

        /// <summary>
        /// 检查错误次数
        /// </summary>
        /// <param name="userCode">用户编码</param>
        /// <param name="maxCount">错误最大次数</param>
        /// <param name="maxSec">连续记录最大秒数</param>
        /// <param name="isMax">是否超过最大的错误次数</param>
        /// <param name="restSec">下次允许输入剩下的时间</param>
        public static void CheckErrorCount(string userCode, int maxCount, int maxSec, out bool isMax, out int restSec)
        {
            isMax = false;
            restSec = 0;

            if (InputCache.ContainsKey(userCode))
            {
                var inputInfo = InputCache[userCode];
                var inputSpan = DateTime.Now - inputInfo.InputTime;

                if (inputSpan.TotalSeconds > maxCount)
                {
                    inputInfo.InputCount = 1;
                    inputInfo.InputTime = DateTime.Now;
                }
                else
                {
                    inputInfo.InputCount++;
                }

                if (inputInfo.InputCount >= maxCount)
                {
                    restSec = (int)Math.Ceiling(maxCount - inputSpan.TotalSeconds);
                    isMax = true;
                }
            }
            else
            {
                var rdInfo = new PwdCheckRecord()
                {
                    InputCount = 1,
                    InputTime = DateTime.Now
                };
                InputCache.Add(userCode, rdInfo);
            }
        }


        public static void ClearCache(string userCode)
        {
            if (InputCache.ContainsKey(userCode)) InputCache.Remove(userCode);
        }
    }

    public class PwdCheckRecord
    {
        public int InputCount { get; set; }

        public DateTime InputTime { get; set; }
    }
}
