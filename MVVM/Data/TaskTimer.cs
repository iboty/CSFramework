using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading;


namespace CSFramework.MVVM.Data
{
    public class TaskTimer
    {
        private Timer _timer;
        private bool _enable;

        public TaskTimer(int firstIntervalLen, int intervalLen, int errorIntervalLen = Timeout.Infinite)
        {
            FirstIntervalLen = firstIntervalLen;
            IntervalLen = intervalLen;
            ErrorIntervalLen = errorIntervalLen;
        }

        /// <summary>
        /// 首次运行时间间隔
        /// </summary>
        public int FirstIntervalLen { get; set; }

        /// <summary>
        /// 运行时间间隔
        /// </summary>
        public int IntervalLen { get; set; }

        /// <summary>
        /// 订阅异常时，时间间隔
        /// </summary>
        public int ErrorIntervalLen { get; set; }
        /// <summary>
        /// 定时器使能
        /// </summary>

        public bool Enable
        {
            get => _enable;
            set => SetEnable(value);
        }

        private void SetEnable(bool value)
        {
            if (_enable == value) return;

            if (value)
            {
                var intervalLen = IsSyncRun ? Timeout.Infinite : IntervalLen;
                _timer = new Timer(t => OnEventTriggered(), null, FirstIntervalLen, intervalLen);
            }
            else
            {
                _timer?.Dispose();
                _timer = null;
            }

            _enable = value;
        }

        public void Stop()
        {
            Enable = false;
        }

        public void Start()
        {
            Enable = true;
        }

        /// <summary>
        /// 是否同步启动，开启该设置，下次定时的自动开始计时的时间为本次任务结束的时间，默认 true
        /// </summary>
        public bool IsSyncRun { get; set; } = true;
        /// <summary>
        /// 触发事件
        /// </summary>
        public event EventHandler Triggered;

        /// <summary>
        /// 定时间自动重置，默认 true
        /// </summary>
        public bool AutoReset { get; set; } = true;

        private bool _isErrorMode;

        /// <summary>
        /// 设置任务运行模式，不同的模式下定时的时间取决于设置，用于MVVM下可以自动设置
        /// </summary>
        /// <param name="isError"></param>
        public void SetErrorTaskMode(bool isError)
        {
            if(_isErrorMode == isError || ErrorIntervalLen == Timeout.Infinite) return;

            _isErrorMode = isError;

            if(!AutoReset || IsSyncRun) return;

            var interval = _isErrorMode ? ErrorIntervalLen : IntervalLen;
            _timer?.Change(interval, interval);
        }

        private void OnEventTriggered()
        {
            Triggered?.Invoke(this, new EventArgs());

            if (!AutoReset)
            {
                Stop();
            }
            else if (IsSyncRun)
            {
                var interval = _isErrorMode ? ErrorIntervalLen : IntervalLen;
                _timer.Change(interval, Timeout.Infinite);
            }
        }
    }

}

