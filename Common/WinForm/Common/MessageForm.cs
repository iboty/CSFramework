using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using CCWin;
using CSFramework.Common.Data;
using CSFramework.Properties;

namespace CSFramework.Common.WinForm.Common
{
    public partial class MessageForm : Form
    {
        public MessageForm()
        {
            InitializeComponent();
        }

        public MessageForm(MessageCode msgCode, string theme, string message, int timeoutSec)
        {
            InitializeComponent();
            SetData(msgCode, theme, message, timeoutSec);
        }

        private static volatile MessageForm _messageBox;

        private int _timeoutSec;

        private void SetData(MessageCode msgCode, string theme, string message, int timeout)
        {
            lblTile.Text = GetTheme(msgCode, theme);
            panelImg.BackgroundImage = GetImage(msgCode);
            lblMsg.Text = message;
            SetButton(msgCode, timeout);
        }
      

        private void SetButton(MessageCode msgCode, int timeoutSec)
        {
            switch (msgCode)
            {
                case MessageCode.RequestOkCancel:
                    btnCancel.Visible = true;
                    btnOk.DialogResult = DialogResult.OK;
                    btnOk.Text = "确认";
                    btnCancel.DialogResult = DialogResult.Cancel;
                    btnCancel.Text = "取消";
                    break;
                case MessageCode.RequestYesNo:
                    btnCancel.Visible = true;
                    btnOk.DialogResult = DialogResult.Yes;
                    btnOk.Text = "是";
                    btnCancel.DialogResult = DialogResult.No;
                    btnCancel.Text = "否";
                    break;
                default:
                    btnCancel.Visible = false;
                    btnOk.Left = (Width - btnOk.Width) / 2;
                    _timeoutSec = timeoutSec;
                    if(_timeoutSec <= 0) break;
                    time.Start();
                    break;
            }
        }

        private Image GetImage(MessageCode msgCode)
        {
            if (msgCode == MessageCode.RequestOkCancel || msgCode == MessageCode.RequestYesNo) return Resources.msg_ask;
            if (msgCode == MessageCode.Fault) return Resources.msg_error;
            if (msgCode == MessageCode.Warn) return Resources.msg_warn;
            return Resources.msg_Info;
        }

        private string GetTheme(MessageCode msgCode, string theme)
        {
            if (!string.IsNullOrEmpty(theme)) return theme;

            if (msgCode == MessageCode.Info) return "消息通知";
            if (msgCode == MessageCode.Warn) return "告警提示";
            if (msgCode == MessageCode.Fault) return "错误提示";
            if (msgCode == MessageCode.Success) return "成功提示";
            if (msgCode == MessageCode.RequestOkCancel || msgCode == MessageCode.RequestYesNo) return "操作询问";
            return "提示信息";
        }


        public static DialogResult Show(MessageCode msgCode, string message, string theme = null,  int timeout = 6)
        {
            if (_messageBox != null) return DialogResult.None;

            _messageBox = new MessageForm(msgCode, theme, message, timeout);
            var result = _messageBox.ShowDialog();
            _messageBox = null;
            return result;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (--_timeoutSec <= 0) DialogResult = DialogResult.OK;
            btnOk.Text = $"确认({_timeoutSec}s)";
        }
    }

}
