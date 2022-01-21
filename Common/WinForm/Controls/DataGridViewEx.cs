using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CSFramework.Common.WinForm.Controls
{
    public class DataGridViewEx : DataGridView
    {
        private readonly DataGridViewCellStyle _dataGridViewCellStyle1 = new DataGridViewCellStyle();
        private readonly DataGridViewCellStyle _dataGridViewCellStyle2 = new DataGridViewCellStyle();

        public DataGridViewEx()
        {
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToResizeColumns = false;
            AllowUserToResizeRows = false;
            BackgroundColor = Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(21)))), ((int)(((byte)(67)))));
            BorderStyle = BorderStyle.None;
            CellBorderStyle = DataGridViewCellBorderStyle.None;
            ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            _dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _dataGridViewCellStyle1.BackColor = Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            _dataGridViewCellStyle1.Font = new Font("微软雅黑", 16F);
            _dataGridViewCellStyle1.ForeColor = Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(144)))), ((int)(((byte)(214)))));
            _dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            _dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            _dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            ColumnHeadersDefaultCellStyle = _dataGridViewCellStyle1;
            ColumnHeadersHeight = 65;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            _dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _dataGridViewCellStyle2.BackColor = Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(83)))));
            _dataGridViewCellStyle2.Font = new Font("微软雅黑", 16F);
            _dataGridViewCellStyle2.ForeColor = Color.White;
            _dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(83)))));
            _dataGridViewCellStyle2.SelectionForeColor = Color.White;
            _dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            DefaultCellStyle = _dataGridViewCellStyle2;
            EnableHeadersVisualStyles = false;
            GridColor = Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(21)))), ((int)(((byte)(65)))));
            MultiSelect = false;
            ReadOnly = true;
            RowHeadersVisible = false;
            RowTemplate.DividerHeight = 5;
            RowTemplate.Height = 50;
            ScrollBars = ScrollBars.None;
            Size = new Size(950, 565);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawLine(e.Graphics);
        }

        private void DrawLine(Graphics g)
        {
            if (Rows.Count == 0) return;

            var yOffset = ColumnHeadersHeight;

            using (var pen = new Pen(Color.FromArgb(1, 21, 67), 5))
            {
                g.DrawLine(pen, 0, 2, Width, 2);
                g.DrawLine(pen, 0, ColumnHeadersHeight - 3, Width, ColumnHeadersHeight - 3);
                for (var index = 1; index < Rows.Count + 1; index++)
                {
                    yOffset = yOffset + RowTemplate.Height;
                    g.DrawLine(pen, 0, yOffset - 3, Width, yOffset - 3);
                }
            }
        }

        [Browsable(false)]
        [DefaultValue(typeof(DataGridViewColumnHeadersHeightSizeMode), nameof(DataGridViewColumnHeadersHeightSizeMode.DisableResizing))]
        public new DataGridViewColumnHeadersHeightSizeMode ColumnHeadersHeightSizeMode
        {
            get => base.ColumnHeadersHeightSizeMode;
            set => base.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        }

        [Browsable(false)]
        public new DataGridViewCellStyle DefaultCellStyle
        {
            get => base.DefaultCellStyle;
            set => base.DefaultCellStyle = _dataGridViewCellStyle2;
        }

        [Browsable(false)]
        public new DataGridViewCellStyle ColumnHeadersDefaultCellStyle
        {
            get => base.ColumnHeadersDefaultCellStyle;
            set => base.ColumnHeadersDefaultCellStyle = _dataGridViewCellStyle1;
        }
    }
}
