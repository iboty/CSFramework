using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CSFramework.Common.Data;
using CSFramework.Common.Helper;
using CSFramework.MVVM.Data;
using CSFramework.MVVM.Models;
using CSFramework.MVVM.Roles;

namespace CSFramework.Common.Tool
{
    public partial class DebugForm : Form
    {
        public DebugForm()
        {
            InitializeComponent();
            Load += (o, e) => { Init(); };
        }

        private readonly MsgLevel _preLevel = Notifier.MsgLevel;    //全局的MsgLevel  界面退出时需要还原为这个值
        public ModelList<DebugInfo> DebugInfoList = new ModelList<DebugInfo>();

        public List<MessageCode> MessageCodeList = new List<MessageCode>
        {
            MessageCode.Fault, MessageCode.Info, MessageCode.Invalid, MessageCode.RequestOkCancel,
            MessageCode.RequestYesNo, MessageCode.Success, MessageCode.Warn
        };
        private static bool _isShow;  //界面是否正在显示
        private bool _isRun = true;   //监控是否正在运行
        private bool _isSuspend;      //dgv是否隐藏
        private static readonly string IniFilePath = AppDomain.CurrentDomain.BaseDirectory + "config.ini";

        private void Init()
        {
            try
            {
                DebugInfoList.InitSynchronizationContext();
                dgv.AutoGenerateColumns = false;
                dgv.DataSource = DebugInfoList;

                MsgLevel value = 0;
                value |= MsgLevel.Normal;
                value |= MsgLevel.Debug;
                Notifier.MsgLevel = value;

                Notifier.NotifyMsg += OnNotifyMessage;

                cbxAutoRun.Checked =
                    Convert.ToBoolean(IniFileHelper.IniReadValue("DebugForm", "AutoRun", "", IniFilePath));

                Shown += (o, e) => { _isShow = true; };
                Closed += (o, e) =>
                {
                    _isShow = false;
                    Notifier.NotifyMsg -= OnNotifyMessage;
                    Notifier.MsgLevel = _preLevel;
                };

                btnStartOrPause.Click += (o, e) =>
                {
                    if (!_isRun)
                    {
                        Notifier.NotifyMsg -= OnNotifyMessage;
                        Notifier.NotifyMsg += OnNotifyMessage;
                        btnStartOrPause.Text = @"暂停";
                        btnStartOrPause.BorderColor = Color.Lime;
                        btnStartOrPause.BaseColor = Color.Lime;
                        btnStartOrPause.DownBaseColor = Color.FromArgb(128, 255, 128);
                        btnStartOrPause.MouseBaseColor = Color.FromArgb(192, 255, 192);
                        _isRun = true;
                    }
                    else
                    {
                        Notifier.NotifyMsg -= OnNotifyMessage;
                        btnStartOrPause.Text = @"开始";
                        btnStartOrPause.BorderColor = Color.DarkGray;
                        btnStartOrPause.BaseColor = Color.DarkGray;
                        btnStartOrPause.DownBaseColor = Color.Silver;
                        btnStartOrPause.MouseBaseColor = Color.FromArgb(224, 224, 224);
                        _isRun = false;
                    }
                };

                btnExport.Click += (o, e) => { Export(); };

                btnClear.Click += (o, e) => { DebugInfoList.Clear(); };

                btnSuspend.Click += (o, e) =>
                {
                    if (!_isSuspend)
                    {
                        Height = 150;
                        btnSuspend.Text = @"还原";
                        _isSuspend = true;
                    }
                    else
                    {
                        Height = 753;
                        btnSuspend.Text = @"隐藏";
                        _isSuspend = false;
                    }
                };

                cbxLevelNormal.CheckedChanged += (o, e) =>
                {
                    value = 0;
                    if (cbxLevelNormal.Checked) value |= MsgLevel.Normal;
                    if (cbxLevelDebug.Checked) value |= MsgLevel.Debug;
                    if (cbxLevelTrace.Checked) value |= MsgLevel.Trace;
                    Notifier.MsgLevel = value;
                };

                cbxLevelDebug.CheckedChanged += (o, e) =>
                {
                    value = 0;
                    if (cbxLevelNormal.Checked) value |= MsgLevel.Normal;
                    if (cbxLevelDebug.Checked) value |= MsgLevel.Debug;
                    if (cbxLevelTrace.Checked) value |= MsgLevel.Trace;
                    Notifier.MsgLevel = value;
                };

                cbxLevelTrace.CheckedChanged += (o, e) =>
                {
                    value = 0;
                    if (cbxLevelNormal.Checked) value |= MsgLevel.Normal;
                    if (cbxLevelDebug.Checked) value |= MsgLevel.Debug;
                    if (cbxLevelTrace.Checked) value |= MsgLevel.Trace;
                    Notifier.MsgLevel = value;

                    if (dgv.Columns["堆栈信息"] != null)
                    {
                        dgv.Columns["堆栈信息"].Visible = cbxLevelTrace.Checked;
                    }
                };

                cbxTypeNormal.CheckedChanged += (o, e) =>
                {
                    if (cbxTypeNormal.Checked) MessageCodeList.Add(MessageCode.Info);
                    else MessageCodeList.Remove(MessageCode.Info);
                };

                cbxTypeWarn.CheckedChanged += (o, e) =>
                {
                    if (cbxTypeWarn.Checked) MessageCodeList.Add(MessageCode.Warn);
                    else MessageCodeList.Remove(MessageCode.Warn);
                };

                cbxTypeFault.CheckedChanged += (o, e) =>
                {
                    if (cbxTypeFault.Checked) MessageCodeList.Add(MessageCode.Fault);
                    else MessageCodeList.Remove(MessageCode.Fault);
                };

                cbxTypeOther.CheckedChanged += (o, e) =>
                {
                    if (cbxTypeOther.Checked)
                    {
                        MessageCodeList.Add(MessageCode.Invalid);
                        MessageCodeList.Add(MessageCode.Success);
                        MessageCodeList.Add(MessageCode.RequestOkCancel);
                        MessageCodeList.Add(MessageCode.RequestYesNo);
                    }
                    else
                    {
                        MessageCodeList.Remove(MessageCode.Invalid);
                        MessageCodeList.Remove(MessageCode.Success);
                        MessageCodeList.Remove(MessageCode.RequestOkCancel);
                        MessageCodeList.Remove(MessageCode.RequestYesNo);
                    }
                };

                cbxAutoRun.CheckedChanged += (o, e) =>
                {
                    IniFileHelper.IniWriteValue("DebugForm", "AutoRun", cbxAutoRun.Checked ? "true" : "false",
                        IniFilePath);
                };

                dgv.CellDoubleClick += (o, e) =>
                {
                    if (dgv.Columns[e.ColumnIndex].Name == "任务名称")
                    {
                        txtTaskName.Text = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    }
                };
            }
            catch
            {
                // ignored
            }
        }

        private void OnNotifyMessage(TaskInfo taskInfo, NotifyInfo notifyInfo)
        {
            try
            {
                if (!taskInfo.TaskName.Contains(txtTaskName.Text.Trim())) return;
                if (!MessageCodeList.Contains(notifyInfo.MessageCode)) return;

                var info = new DebugInfo()
                {
                    TaskName = taskInfo.TaskName,
                    NotifyTime = notifyInfo.MessageTime.ToString("MM-dd HH:mm:ss"),
                    Message = notifyInfo.Message,
                    Track = notifyInfo.Track,
                    MessageLevel = (MsgLevelDisplay)notifyInfo.MsgLevel,
                    MessageCode = (MessageCodeDisplay)notifyInfo.MessageCode,
                    RunStatus = (RunStatusDisplay)taskInfo.RunInfo.Status
                };

                DebugInfoList.Add(info);
            }
            catch
            {
                // ignored
            }
        }

        private void Export()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (var info in DebugInfoList)
                {
                    sb.Append($"时间：{info.NotifyTime}\t任务名称：{info.TaskName}\t任务状态：{info.RunStatus.ToString()}\t" +
                              $"消息类型：{info.MessageCode.ToString()}\t消息信息：{info.Message}\t" +
                              $"堆栈信息：{info.Track}\t消息等级：{info.MessageLevel.ToString()}\n\n");
                }

                var fileDir =
                    $"{AppDomain.CurrentDomain.BaseDirectory}\\logs";
                if (!Directory.Exists(fileDir)) Directory.CreateDirectory(fileDir);
                FileStream file = new FileStream($"{fileDir}\\{DateTime.Now:yyyy-MM-dd}.log", FileMode.Append);
                StreamWriter sw = new StreamWriter(file, Encoding.GetEncoding("GB2312"));
                sw.Write(sb.ToString());
                sw.Close();
                sw.Dispose();
                file.Close();
                file.Dispose();
                MessageBox.Show(@"导出成功");
            }
            catch
            {
                MessageBox.Show(@"导出失败");
            }

        }

        public static void AutoRun()
        {
            string str = IniFileHelper.IniReadValue("DebugForm", "AutoRun", "", IniFilePath);
            if (str == "true")
            {
                ShowForm();
            }
        }

        public static void ShowForm()
        {
            if (_isShow) return;

            var waitThread = new Thread(() =>
            {
                var form = new DebugForm();
                Application.Run(form);
            });
            waitThread.Start();
        }
    }
}
