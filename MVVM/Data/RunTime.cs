using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFramework.MVVM.Data
{
    public class RunTimeSpan
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime Start { get; internal set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? End { get; internal set; }
        /// <summary>
        /// 运行时间间隔
        /// </summary>
        public TimeSpan Value => (End ?? DateTime.Now) - Start;
    }
}
