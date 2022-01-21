using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CSFramework.Common.Helper;

namespace CSFramework.Controls
{
    public  class FacePlayer : Control
    {

        private Bitmap _currentFrame;
        private Bitmap _convertedFrame;


        private Rectangle? _faceRect;

        private string _lastMsg;
        private VideoStatus _videoStatus;

        public Point MsgLocation { get; set; } = new Point(30,50);
        public Pen FaceBorderPen { get; set;} = Pens.CornflowerBlue;

        private readonly object _videoSync = new object();

        public  FacePlayer()
        {
            SuspendLayout();
            ResumeLayout(false);
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
        }


        public void VideoErrorHandle(string errMsg)
        {
            _videoStatus = VideoStatus.Error;
            _lastMsg = errMsg;
        }

        public void CheckForCrossThreadAccess()
        {
            if (!IsHandleCreated)
            {
                CreateControl();

                if (!IsHandleCreated) CreateHandle();
            }
            if (InvokeRequired)
                throw new InvalidOperationException("Cross thread access to the control is not allowed.");
        }


        public void VideoFindHandle(string reason)
        {
            _videoStatus = VideoStatus.Finish;
            _lastMsg = reason;

            if (_currentFrame != null)
            {
                _currentFrame.Dispose();
                _currentFrame = null;
            }

            if (_convertedFrame != null)
            {
                _convertedFrame.Dispose();
                _convertedFrame = null;
            }
        }

        public Tuple<Rectangle?, Bitmap> GetFaceInfo()
        {
            lock (_videoSync)
            {
                return new Tuple<Rectangle?, Bitmap>(_faceRect,(Bitmap)_currentFrame.Clone());
            }
        }

        public void DrawFrame(Bitmap bitmap, Rectangle? faceRect)
        {
            var curBitmap = (Bitmap)bitmap.Clone();

            lock (_videoSync)
            {
                if (_currentFrame != null)
                {
                    _currentFrame.Dispose();
                    _currentFrame = null;
                }

                if (_convertedFrame != null)
                {
                    _convertedFrame.Dispose();
                    _convertedFrame = null;
                }

                _videoStatus = VideoStatus.Play;
                _currentFrame = curBitmap;
                _faceRect = faceRect;
            }

            Invalidate();
           
        }


        private void DrawTackFace(Graphics g)
        {
            switch (_videoStatus)
            {
                case VideoStatus.Connect:
                    g.DrawString("connect...", Font, new SolidBrush(ForeColor), MsgLocation);
                    break;
                case VideoStatus.Error:
                case VideoStatus.Finish:
                    g.DrawString(_lastMsg, Font, new SolidBrush(ForeColor), MsgLocation);
                    break;
                case VideoStatus.GetImage:
                case VideoStatus.Play:
                    if(_currentFrame == null) break;
                    g.DrawImage(_currentFrame, ClientRectangle.X + 3, ClientRectangle.Y +4, ClientRectangle.Width - 6, ClientRectangle.Height - 9);
                    if(_faceRect == null) break;
                    var faceRect =  SizeHelper.GetZoomRectangle(Size,_currentFrame.Size,_faceRect.Value) ;
                    g.DrawRectangle(FaceBorderPen, faceRect);
                    break;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            lock (_videoSync)
            {
                DrawTackFace(e.Graphics);
                base.OnPaint(e);
            }
        }


    }

    public enum VideoStatus
    {
        Connect,
        Error,
        Play,
        GetImage,
        Finish
    }

}
