namespace CSFramework.ORM.Data
{
    public class DbNotifyEventArgs
    {
        public DbNotifyEventArgs(object source)
        {
            SourceObj = source;
        }

        public object SourceObj { get; private set;}
    }
}
