namespace CSFramework.MVVM.Data
{
    public class MsgInfo
    {
        public MsgInfo(RegInfo regInfo, NotifyInfo notifyInfo)
        {
            RegInfo = regInfo;
            NotifyInfo = notifyInfo;
        }

        public RegInfo RegInfo { get;  }
        public NotifyInfo NotifyInfo { get;  }

    }
}
