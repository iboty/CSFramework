using System.Windows.Forms;

namespace CSFramework.Common.Tool
{
    partial class DebugForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxLevelNormal = new CCWin.SkinControl.SkinCheckBox();
            this.cbxLevelDebug = new CCWin.SkinControl.SkinCheckBox();
            this.cbxLevelTrace = new CCWin.SkinControl.SkinCheckBox();
            this.cbxTypeFault = new CCWin.SkinControl.SkinCheckBox();
            this.cbxTypeWarn = new CCWin.SkinControl.SkinCheckBox();
            this.cbxTypeNormal = new CCWin.SkinControl.SkinCheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxTypeOther = new CCWin.SkinControl.SkinCheckBox();
            this.txtTaskName = new CCWin.SkinControl.SkinWaterTextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnStartOrPause = new CCWin.SkinControl.SkinButton();
            this.btnExport = new CCWin.SkinControl.SkinButton();
            this.btnClear = new CCWin.SkinControl.SkinButton();
            this.btnSuspend = new CCWin.SkinControl.SkinButton();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxAutoRun = new CCWin.SkinControl.SkinCheckBox();
            this.时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.任务名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.任务状态 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.消息类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.消息信息 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.堆栈信息 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.消息等级 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(47, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "任务名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(374, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 10;
            this.label2.Text = "消息等级：";
            // 
            // cbxLevelNormal
            // 
            this.cbxLevelNormal.AutoSize = true;
            this.cbxLevelNormal.BackColor = System.Drawing.Color.Transparent;
            this.cbxLevelNormal.Checked = true;
            this.cbxLevelNormal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxLevelNormal.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.cbxLevelNormal.DefaultCheckButtonWidth = 15;
            this.cbxLevelNormal.DownBack = null;
            this.cbxLevelNormal.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxLevelNormal.LightEffect = false;
            this.cbxLevelNormal.Location = new System.Drawing.Point(459, 19);
            this.cbxLevelNormal.MouseBack = null;
            this.cbxLevelNormal.Name = "cbxLevelNormal";
            this.cbxLevelNormal.NormlBack = null;
            this.cbxLevelNormal.SelectedDownBack = null;
            this.cbxLevelNormal.SelectedMouseBack = null;
            this.cbxLevelNormal.SelectedNormlBack = null;
            this.cbxLevelNormal.Size = new System.Drawing.Size(61, 25);
            this.cbxLevelNormal.TabIndex = 11;
            this.cbxLevelNormal.Text = "正常";
            this.cbxLevelNormal.UseVisualStyleBackColor = false;
            // 
            // cbxLevelDebug
            // 
            this.cbxLevelDebug.AutoSize = true;
            this.cbxLevelDebug.BackColor = System.Drawing.Color.Transparent;
            this.cbxLevelDebug.Checked = true;
            this.cbxLevelDebug.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxLevelDebug.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.cbxLevelDebug.DefaultCheckButtonWidth = 15;
            this.cbxLevelDebug.DownBack = null;
            this.cbxLevelDebug.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxLevelDebug.LightEffect = false;
            this.cbxLevelDebug.Location = new System.Drawing.Point(526, 19);
            this.cbxLevelDebug.MouseBack = null;
            this.cbxLevelDebug.Name = "cbxLevelDebug";
            this.cbxLevelDebug.NormlBack = null;
            this.cbxLevelDebug.SelectedDownBack = null;
            this.cbxLevelDebug.SelectedMouseBack = null;
            this.cbxLevelDebug.SelectedNormlBack = null;
            this.cbxLevelDebug.Size = new System.Drawing.Size(61, 25);
            this.cbxLevelDebug.TabIndex = 12;
            this.cbxLevelDebug.Text = "调试";
            this.cbxLevelDebug.UseVisualStyleBackColor = false;
            // 
            // cbxLevelTrace
            // 
            this.cbxLevelTrace.AutoSize = true;
            this.cbxLevelTrace.BackColor = System.Drawing.Color.Transparent;
            this.cbxLevelTrace.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.cbxLevelTrace.DefaultCheckButtonWidth = 15;
            this.cbxLevelTrace.DownBack = null;
            this.cbxLevelTrace.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxLevelTrace.LightEffect = false;
            this.cbxLevelTrace.Location = new System.Drawing.Point(593, 19);
            this.cbxLevelTrace.MouseBack = null;
            this.cbxLevelTrace.Name = "cbxLevelTrace";
            this.cbxLevelTrace.NormlBack = null;
            this.cbxLevelTrace.SelectedDownBack = null;
            this.cbxLevelTrace.SelectedMouseBack = null;
            this.cbxLevelTrace.SelectedNormlBack = null;
            this.cbxLevelTrace.Size = new System.Drawing.Size(61, 25);
            this.cbxLevelTrace.TabIndex = 13;
            this.cbxLevelTrace.Text = "追踪";
            this.cbxLevelTrace.UseVisualStyleBackColor = false;
            // 
            // cbxTypeFault
            // 
            this.cbxTypeFault.AutoSize = true;
            this.cbxTypeFault.BackColor = System.Drawing.Color.Transparent;
            this.cbxTypeFault.Checked = true;
            this.cbxTypeFault.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxTypeFault.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.cbxTypeFault.DefaultCheckButtonWidth = 15;
            this.cbxTypeFault.DownBack = null;
            this.cbxTypeFault.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxTypeFault.LightEffect = false;
            this.cbxTypeFault.Location = new System.Drawing.Point(266, 71);
            this.cbxTypeFault.MouseBack = null;
            this.cbxTypeFault.Name = "cbxTypeFault";
            this.cbxTypeFault.NormlBack = null;
            this.cbxTypeFault.SelectedDownBack = null;
            this.cbxTypeFault.SelectedMouseBack = null;
            this.cbxTypeFault.SelectedNormlBack = null;
            this.cbxTypeFault.Size = new System.Drawing.Size(61, 25);
            this.cbxTypeFault.TabIndex = 17;
            this.cbxTypeFault.Text = "错误";
            this.cbxTypeFault.UseVisualStyleBackColor = false;
            // 
            // cbxTypeWarn
            // 
            this.cbxTypeWarn.AutoSize = true;
            this.cbxTypeWarn.BackColor = System.Drawing.Color.Transparent;
            this.cbxTypeWarn.Checked = true;
            this.cbxTypeWarn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxTypeWarn.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.cbxTypeWarn.DefaultCheckButtonWidth = 15;
            this.cbxTypeWarn.DownBack = null;
            this.cbxTypeWarn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxTypeWarn.LightEffect = false;
            this.cbxTypeWarn.Location = new System.Drawing.Point(199, 71);
            this.cbxTypeWarn.MouseBack = null;
            this.cbxTypeWarn.Name = "cbxTypeWarn";
            this.cbxTypeWarn.NormlBack = null;
            this.cbxTypeWarn.SelectedDownBack = null;
            this.cbxTypeWarn.SelectedMouseBack = null;
            this.cbxTypeWarn.SelectedNormlBack = null;
            this.cbxTypeWarn.Size = new System.Drawing.Size(61, 25);
            this.cbxTypeWarn.TabIndex = 16;
            this.cbxTypeWarn.Text = "告警";
            this.cbxTypeWarn.UseVisualStyleBackColor = false;
            // 
            // cbxTypeNormal
            // 
            this.cbxTypeNormal.AutoSize = true;
            this.cbxTypeNormal.BackColor = System.Drawing.Color.Transparent;
            this.cbxTypeNormal.Checked = true;
            this.cbxTypeNormal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxTypeNormal.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.cbxTypeNormal.DefaultCheckButtonWidth = 15;
            this.cbxTypeNormal.DownBack = null;
            this.cbxTypeNormal.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxTypeNormal.LightEffect = false;
            this.cbxTypeNormal.Location = new System.Drawing.Point(132, 71);
            this.cbxTypeNormal.MouseBack = null;
            this.cbxTypeNormal.Name = "cbxTypeNormal";
            this.cbxTypeNormal.NormlBack = null;
            this.cbxTypeNormal.SelectedDownBack = null;
            this.cbxTypeNormal.SelectedMouseBack = null;
            this.cbxTypeNormal.SelectedNormlBack = null;
            this.cbxTypeNormal.Size = new System.Drawing.Size(61, 25);
            this.cbxTypeNormal.TabIndex = 15;
            this.cbxTypeNormal.Text = "正常";
            this.cbxTypeNormal.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(47, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 21);
            this.label3.TabIndex = 14;
            this.label3.Text = "消息类型：";
            // 
            // cbxTypeOther
            // 
            this.cbxTypeOther.AutoSize = true;
            this.cbxTypeOther.BackColor = System.Drawing.Color.Transparent;
            this.cbxTypeOther.Checked = true;
            this.cbxTypeOther.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxTypeOther.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.cbxTypeOther.DefaultCheckButtonWidth = 15;
            this.cbxTypeOther.DownBack = null;
            this.cbxTypeOther.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxTypeOther.LightEffect = false;
            this.cbxTypeOther.Location = new System.Drawing.Point(333, 71);
            this.cbxTypeOther.MouseBack = null;
            this.cbxTypeOther.Name = "cbxTypeOther";
            this.cbxTypeOther.NormlBack = null;
            this.cbxTypeOther.SelectedDownBack = null;
            this.cbxTypeOther.SelectedMouseBack = null;
            this.cbxTypeOther.SelectedNormlBack = null;
            this.cbxTypeOther.Size = new System.Drawing.Size(61, 25);
            this.cbxTypeOther.TabIndex = 18;
            this.cbxTypeOther.Text = "其他";
            this.cbxTypeOther.UseVisualStyleBackColor = false;
            // 
            // txtTaskName
            // 
            this.txtTaskName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTaskName.Location = new System.Drawing.Point(132, 17);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Size = new System.Drawing.Size(207, 29);
            this.txtTaskName.TabIndex = 20;
            this.txtTaskName.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtTaskName.WaterText = "";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.时间,
            this.任务名称,
            this.任务状态,
            this.消息类型,
            this.消息信息,
            this.堆栈信息,
            this.消息等级});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgv.Location = new System.Drawing.Point(13, 119);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(805, 583);
            this.dgv.TabIndex = 19;
            // 
            // btnStartOrPause
            // 
            this.btnStartOrPause.BackColor = System.Drawing.Color.Transparent;
            this.btnStartOrPause.BaseColor = System.Drawing.Color.Lime;
            this.btnStartOrPause.BorderColor = System.Drawing.Color.Lime;
            this.btnStartOrPause.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnStartOrPause.DownBack = null;
            this.btnStartOrPause.DownBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnStartOrPause.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartOrPause.Location = new System.Drawing.Point(424, 68);
            this.btnStartOrPause.MouseBack = null;
            this.btnStartOrPause.MouseBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnStartOrPause.Name = "btnStartOrPause";
            this.btnStartOrPause.NormlBack = null;
            this.btnStartOrPause.Size = new System.Drawing.Size(75, 34);
            this.btnStartOrPause.TabIndex = 21;
            this.btnStartOrPause.Text = "暂停";
            this.btnStartOrPause.UseVisualStyleBackColor = false;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnExport.DownBack = null;
            this.btnExport.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExport.Location = new System.Drawing.Point(519, 68);
            this.btnExport.MouseBack = null;
            this.btnExport.Name = "btnExport";
            this.btnExport.NormlBack = null;
            this.btnExport.Size = new System.Drawing.Size(75, 34);
            this.btnExport.TabIndex = 22;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnClear.DownBack = null;
            this.btnClear.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClear.Location = new System.Drawing.Point(614, 68);
            this.btnClear.MouseBack = null;
            this.btnClear.Name = "btnClear";
            this.btnClear.NormlBack = null;
            this.btnClear.Size = new System.Drawing.Size(75, 34);
            this.btnClear.TabIndex = 23;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // btnSuspend
            // 
            this.btnSuspend.BackColor = System.Drawing.Color.Transparent;
            this.btnSuspend.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnSuspend.DownBack = null;
            this.btnSuspend.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSuspend.Location = new System.Drawing.Point(710, 68);
            this.btnSuspend.MouseBack = null;
            this.btnSuspend.Name = "btnSuspend";
            this.btnSuspend.NormlBack = null;
            this.btnSuspend.Size = new System.Drawing.Size(75, 34);
            this.btnSuspend.TabIndex = 24;
            this.btnSuspend.Text = "隐藏";
            this.btnSuspend.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(681, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 21);
            this.label4.TabIndex = 25;
            this.label4.Text = "开机启动：";
            // 
            // cbxAutoRun
            // 
            this.cbxAutoRun.AutoSize = true;
            this.cbxAutoRun.BackColor = System.Drawing.Color.Transparent;
            this.cbxAutoRun.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.cbxAutoRun.DefaultCheckButtonWidth = 15;
            this.cbxAutoRun.DownBack = null;
            this.cbxAutoRun.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxAutoRun.LightEffect = false;
            this.cbxAutoRun.Location = new System.Drawing.Point(766, 19);
            this.cbxAutoRun.MouseBack = null;
            this.cbxAutoRun.Name = "cbxAutoRun";
            this.cbxAutoRun.NormlBack = null;
            this.cbxAutoRun.SelectedDownBack = null;
            this.cbxAutoRun.SelectedMouseBack = null;
            this.cbxAutoRun.SelectedNormlBack = null;
            this.cbxAutoRun.Size = new System.Drawing.Size(34, 25);
            this.cbxAutoRun.TabIndex = 26;
            this.cbxAutoRun.Text = " ";
            this.cbxAutoRun.UseVisualStyleBackColor = false;
            // 
            // 时间
            // 
            this.时间.DataPropertyName = "NotifyTime";
            this.时间.HeaderText = "时间";
            this.时间.Name = "时间";
            this.时间.ReadOnly = true;
            this.时间.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.时间.Width = 90;
            // 
            // 任务名称
            // 
            this.任务名称.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.任务名称.DataPropertyName = "TaskName";
            this.任务名称.HeaderText = "任务名称";
            this.任务名称.Name = "任务名称";
            this.任务名称.ReadOnly = true;
            this.任务名称.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.任务名称.Width = 58;
            // 
            // 任务状态
            // 
            this.任务状态.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.任务状态.DataPropertyName = "RunStatus";
            this.任务状态.HeaderText = "任务状态";
            this.任务状态.Name = "任务状态";
            this.任务状态.ReadOnly = true;
            this.任务状态.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.任务状态.Width = 58;
            // 
            // 消息类型
            // 
            this.消息类型.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.消息类型.DataPropertyName = "MessageCode";
            this.消息类型.HeaderText = "消息类型";
            this.消息类型.Name = "消息类型";
            this.消息类型.ReadOnly = true;
            this.消息类型.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.消息类型.Width = 58;
            // 
            // 消息信息
            // 
            this.消息信息.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.消息信息.DataPropertyName = "Message";
            this.消息信息.HeaderText = "消息信息";
            this.消息信息.Name = "消息信息";
            this.消息信息.ReadOnly = true;
            this.消息信息.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 堆栈信息
            // 
            this.堆栈信息.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.堆栈信息.DataPropertyName = "Track";
            this.堆栈信息.HeaderText = "堆栈信息";
            this.堆栈信息.Name = "堆栈信息";
            this.堆栈信息.ReadOnly = true;
            this.堆栈信息.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.堆栈信息.Visible = false;
            // 
            // 消息等级
            // 
            this.消息等级.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.消息等级.DataPropertyName = "MessageLevel";
            this.消息等级.HeaderText = "消息等级";
            this.消息等级.Name = "消息等级";
            this.消息等级.ReadOnly = true;
            this.消息等级.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.消息等级.Width = 58;
            // 
            // DebugForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(829, 714);
            this.Controls.Add(this.cbxAutoRun);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSuspend);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnStartOrPause);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.txtTaskName);
            this.Controls.Add(this.cbxTypeOther);
            this.Controls.Add(this.cbxTypeFault);
            this.Controls.Add(this.cbxTypeWarn);
            this.Controls.Add(this.cbxTypeNormal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxLevelTrace);
            this.Controls.Add(this.cbxLevelDebug);
            this.Controls.Add(this.cbxLevelNormal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DebugForm";
            this.Text = "信息监控终端";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private CCWin.SkinControl.SkinCheckBox cbxLevelNormal;
        private CCWin.SkinControl.SkinCheckBox cbxLevelDebug;
        private CCWin.SkinControl.SkinCheckBox cbxLevelTrace;
        private CCWin.SkinControl.SkinCheckBox cbxTypeFault;
        private CCWin.SkinControl.SkinCheckBox cbxTypeWarn;
        private CCWin.SkinControl.SkinCheckBox cbxTypeNormal;
        private System.Windows.Forms.Label label3;
        private CCWin.SkinControl.SkinCheckBox cbxTypeOther;
        private CCWin.SkinControl.SkinWaterTextBox txtTaskName;
        private  DataGridView dgv;
        private CCWin.SkinControl.SkinButton btnStartOrPause;
        private CCWin.SkinControl.SkinButton btnExport;
        private CCWin.SkinControl.SkinButton btnClear;
        private CCWin.SkinControl.SkinButton btnSuspend;
        private Label label4;
        private CCWin.SkinControl.SkinCheckBox cbxAutoRun;
        private DataGridViewTextBoxColumn 时间;
        private DataGridViewTextBoxColumn 任务名称;
        private DataGridViewTextBoxColumn 任务状态;
        private DataGridViewTextBoxColumn 消息类型;
        private DataGridViewTextBoxColumn 消息信息;
        private DataGridViewTextBoxColumn 堆栈信息;
        private DataGridViewTextBoxColumn 消息等级;
    }
}