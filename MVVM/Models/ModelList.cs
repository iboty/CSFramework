using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Forms;


namespace CSFramework.MVVM.Models
{
    public class ModelList<T> : BindingList<T>  where T : ModelBase, new()
    {
        private int _position = -1;
        private T _current;

        public event EventHandler PostionChanged;

        public event EventHandler CurrentChanged;

        /// <summary>
        /// 界面同步上下文
        /// </summary>
        public SynchronizationContext SynchronizationContext { get; private set; }

        public void InitSynchronizationContext()
        {
            SynchronizationContext = SynchronizationContext.Current;
        }

        /// <summary>
        /// 使用此方法执行一切操作上下文相关的操作
        /// </summary>
        private void Invoke(Action action, object state = null)
        {
            if (SynchronizationContext == null) action();
            else SynchronizationContext.Send(t => action(), state);
        }

        public new void Add(T item)
        {
            Invoke(() =>
            {
                item.SynchronizationContext = SynchronizationContext;
                base.Add(item);
            });
        }

        public new void Remove(T item)
        {
            Invoke(() => base.Remove(item));
        }

        public new void Clear()
        {
            Invoke(()=>
            {
                base.Clear();

                Position = -1;
                PostionChanged?.Invoke(this, EventArgs.Empty);
                CurrentChanged?.Invoke(this, EventArgs.Empty);
            });
        }

        public int Position
        {
            get => _position;
            set => SetPosition(value);
        }

        private void SetPosition(int position)
        {
            if (position == _position) return;

            _position = position;

            _current = _position == -1? null : this[position];

            Invoke(()=> PostionChanged?.Invoke(this, EventArgs.Empty));
        }


        public T Current
        {
            get => _current;
            set => SetCurrent(value);
        }

        private void SetCurrent(T current)
        {
            if (current == _current) return;

            _position = current == null ? -1 : IndexOf(current);

            _current = current;

            Invoke(() => CurrentChanged?.Invoke(this, EventArgs.Empty));
        }


        /// <summary>
        /// 从实体列表中更新模型的数据列表
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="entityList"></param>
        public void UpdateFromEntityList<T1>(List<T1> entityList)
        {
             Clear();
             entityList?.ForEach(t =>Add(ModelBase.NewModelFromEntity<T>(t)));
        }

        public List<T1> ToEntityList<T1>() where T1 : new()
        {
            return this.Select(t => t.ToEntity<T1>()).ToList();
        }
    }
}
