namespace CSFramework.Common.Data
{
    /// <summary>
    /// 工厂类型
    /// </summary>
    public enum FactoryType
    {
        MEF,
        WCF,
    }

    public enum LayerType
    {
        Bll,
        Dal,
        Common
    }

    public enum MessageCode
    {
        Normal,
        Success,
        Fault,
        Warn,
        Invalid,
        RequestOkCancel,
        RequestYesNo,
        Append
    }

    public enum PrinterStatus
    {
        其他 = 1,
        未知 ,
        空闲,
        打印,
        预热,
        正在预热,
        已停止打印,
        脱机
    }

    public enum ExtendedDetectedErrorState
    {
        未知 = 0,
        其他 = 1,
        无错误 = 2,
        纸张不足 = 3,
        缺纸 = 4,
        墨粉不足 = 5,
        无墨粉 = 6,
        机盖未关 = 7,
        塞纸 = 8,
        需要维修 = 9,
        出纸盒已满 = 10,
        纸张问题 = 11,
        无法打印页 = 12,
        需要用户干预 = 13,
        内存不足 = 14,
        服务器未知 = 15
    }


    public enum ExtendedPrinterStatus
    {

        其他 = 1,
        未知 = 2,
        闲置 = 3,
        打印 = 4,
        正在预热 = 5,
        已停止打印 = 6,
        离线 = 7,
        已暂停 = 8,
        错误 = 9,
        忙碌 = 10,
        不可用 = 11,
        等待 = 12,
        过程中 = 13,
        初始化 = 14,
        省电 = 15,
        正在等待删除 = 16,
        IO处于活动状态 = 17,
        手动送纸 = 18
    }
}
