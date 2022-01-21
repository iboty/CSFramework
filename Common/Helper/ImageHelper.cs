using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFramework.Common.Helper
{
    public static  class ImageHelper
    {

        private static readonly Font Font = new Font("微软雅黑", 15f, FontStyle.Bold);
        private static readonly Brush Brush = new SolidBrush(Color.AntiqueWhite);

        public static void AddNowTime(Bitmap sourceImage)
        {
            var g = Graphics.FromImage(sourceImage);
            g.SmoothingMode = SmoothingMode.AntiAlias; //使绘图质量最高，即消除锯齿
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            g.DrawString($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}", Font, Brush, 30, 30);
            g.Dispose();
        }

        public static Image GetImageFromPath(ref Image image, string path)
        {
            try
            {
                if (image != null) return image;

                if (string.IsNullOrEmpty(path) || !File.Exists(path)) return null;
                return Image.FromFile(path);
            }
            catch
            {
                return null;
            }
        }

        public static byte[] ImageToBytes(Bitmap bitmap)
        {
            if (bitmap == null) return null;

            using (var ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                var buffer = ms.GetBuffer();
                return buffer;
            }
        }

        public static Bitmap GetImageFromGraphicsPath(GraphicsPath graphicsPath, Pen pen)
        {
            if (graphicsPath == null || graphicsPath.PointCount == 0) return null;
            var w = (int)graphicsPath.PathPoints.Max(t => t.X) + 1;
            var h = (int)graphicsPath.PathPoints.Max(t => t.Y) + 1;

            var bitmap = new Bitmap(w,h);
            using (var g = Graphics.FromImage(bitmap))
            {
               g.SmoothingMode = SmoothingMode.AntiAlias;
                g.DrawPath(pen, graphicsPath);
                g.Dispose();
            }
            return bitmap;
        }
    }
}
