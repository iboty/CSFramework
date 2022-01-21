using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFramework.Common.Helper
{
    public static class SizeHelper
    {
        public static Rectangle GetZoomRectangle(int sourceWidth, int sourceHeight, int sourceLeft, int sourceTop, float widthZoom, int leftOffset, float heightZoom, int topOffset)
        {
            var width =  (int)(sourceWidth * widthZoom);
            var height = (int)(sourceHeight * heightZoom);

            var left = sourceLeft - (width - sourceWidth) / 2 + leftOffset;
            var top = sourceTop - (height - sourceHeight) / 2 + topOffset;

            return new Rectangle(left,top, width, height);
        }

        public static Rectangle GetZoomRectangle(Size  dstSize, Size sourceSize,  Rectangle sourceRect)
        {

            var widthZoom = dstSize.Width * 1f / sourceSize.Width;
            var heightZoom = dstSize.Height * 1f / sourceSize.Height;

            var width = (int)(sourceRect.Width * widthZoom);
            var height = (int)(sourceRect.Height * heightZoom);

             width += width%4;
             height += height%4;

            var left = (int)(sourceRect.Left * widthZoom);
            var top =  (int)(sourceRect.Top * heightZoom);

            return new Rectangle(left, top, width, height);
        }
    }
}
