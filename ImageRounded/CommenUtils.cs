using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ImageRounded
{
    class CommenUtils
    {
        /// <summary>
        /// 圆角生成（但是只能是一个角）
        /// </summary>
        /// <param name="image">源图片 Image</param>
        /// <param name="roundCorner">圆角位置</param>
        /// <returns>处理好的Image</returns>
        public static System.Drawing.Image CreateRoundedCorner(System.Drawing.Image image, string radius, RoundRectanglePosition roundCorner)
        {
            Graphics g = Graphics.FromImage(image);
            //保证图片质量
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;
            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);
            //构建圆角外部路径
            GraphicsPath rectPath = CreateRoundRectanglePath(rect, int.Parse(radius), roundCorner);
            PointF[] p = rectPath.PathPoints;
            //PathData pathData = rectPath.PathData;
            //圆角背景用白色填充
            Brush b = new SolidBrush(Color.White);
            g.DrawPath(new Pen(b), rectPath);
            g.FillPath(b, rectPath);
            g.Dispose();
            return image;
        }

        /// <summary>
        /// 在圆角边缘的判断需要改进，相切部分做一下虚化处理
        /// </summary>
        /// <param name="bit"></param>
        /// <param name="RoundCornerSize"></param>
        /// <returns></returns>
        public static Bitmap doOperation(Bitmap bit,int RoundCornerSize)
        {

            int w1 = bit.Width;
            int h1 = bit.Height;


            //左上角
            for (int y = 0; y < RoundCornerSize; y++)
            {
                for (int x = 0; x < RoundCornerSize; x++)
                {
                    double aX = RoundCornerSize - x;
                    double bY = RoundCornerSize - y;
                    double c = Math.Sqrt(Math.Pow(aX,2) + Math.Pow(bY,2));
                    if (c > RoundCornerSize)//圆标准方程
                    {
                        //将圆以外的点设为透明
                        bit.SetPixel(x, y, System.Drawing.Color.FromArgb(0, 255, 255, 255));
                    }
                    if ((2 > (c - RoundCornerSize) && (c - RoundCornerSize) > 0) || c == RoundCornerSize)//圆标准方程
                    {
                        //将圆以外的点设为透明
                        bit.SetPixel(x, y, System.Drawing.Color.FromArgb(10, 128, 128, 128));
                    }
                }
            }
            // 右上角
            for (int x = w1 - RoundCornerSize; x < w1; x++)
            {
                for (int y = 0; y < RoundCornerSize; y++)
                {
                    double aX = x - (w1 - RoundCornerSize);
                    double bY = RoundCornerSize - y;
                    double c = Math.Sqrt(Math.Pow(aX, 2) + Math.Pow(bY, 2));
                    if (c > RoundCornerSize)//圆标准方程
                    {
                        //将圆以外的点设为透明
                        bit.SetPixel(x, y, System.Drawing.Color.FromArgb(0, 255, 255, 255));
                    }
                    if ((2 > (c - RoundCornerSize) && (c - RoundCornerSize) > 0 ) || c == RoundCornerSize)//圆标准方程
                    {
                        //将圆以外的点设为透明
                        bit.SetPixel(x, y, System.Drawing.Color.FromArgb(12, 128, 128, 128));
                    }
                }
            }
            //左下角
            for (int x = 0; x < RoundCornerSize; x++)
            {
                for (int y = h1 - RoundCornerSize; y < h1; y++)
                {
                    double aX = RoundCornerSize - x;
                    double bY = y - (h1 - RoundCornerSize);
                    double c = Math.Sqrt(Math.Pow(aX, 2) + Math.Pow(bY, 2));
                    if (c > RoundCornerSize)//圆标准方程
                    {
                        //将圆以外的点设为透明
                        bit.SetPixel(x, y, System.Drawing.Color.FromArgb(0, 255, 255, 255));
                    }
                    if ((2 > (c - RoundCornerSize) && (c - RoundCornerSize) > 0) || c == RoundCornerSize)//圆标准方程
                    {
                        //将圆以外的点设为透明
                        bit.SetPixel(x, y, System.Drawing.Color.FromArgb(12, 128, 128, 128));
                    }
                }
            }
            //右下角
            for (int x = w1 - RoundCornerSize; x < w1; x++)
            {
                for (int y = h1 - RoundCornerSize; y < h1; y++)
                {
                    double aX = x - (w1 - RoundCornerSize);
                    double bY = y - (h1 - RoundCornerSize);
                    double c = Math.Sqrt(Math.Pow(aX, 2) + Math.Pow(bY, 2));
                    if (c > RoundCornerSize)//圆标准方程
                    {
                        //将圆以外的点设为透明
                        bit.SetPixel(x, y, System.Drawing.Color.FromArgb(0, 255, 255, 255));
                    }
                    if ((2 > (c - RoundCornerSize) && (c - RoundCornerSize) > 0) || c == RoundCornerSize)//圆标准方程
                    {
                        //将圆以外的点设为透明
                        bit.SetPixel(x, y, System.Drawing.Color.FromArgb(12, 128, 128, 128));
                    }
                }

            }
            return bit;
        }


        /// <summary>
        /// 目标图片的圆角位置
        /// </summary>
        public enum RoundRectanglePosition
        {
            /// <summary>
            /// 左上角
            /// </summary>
            TopLeft,
            /// <summary>
            /// 右上角
            /// </summary>
            TopRight,
            /// <summary>
            /// 左下角
            /// </summary>
            BottomLeft,
            /// <summary>
            /// 右下角
            /// </summary>
            BottomRight
        }
        /// <summary>
        /// 构建GraphicsPath路径
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="radius"></param>
        /// <param name="rrPosition">图片圆角位置</param>
        /// <returns>返回GraphicPath</returns>
        private static GraphicsPath CreateRoundRectanglePath(Rectangle rect, int radius, RoundRectanglePosition rrPosition)
        {
            GraphicsPath rectPath = new GraphicsPath();
            switch (rrPosition)
            {
                case RoundRectanglePosition.TopLeft:
                    {
                        rectPath.AddArc(rect.Left, rect.Top, radius * 2, radius * 2, 180, 90);
                        rectPath.AddLine(rect.Left, rect.Top, rect.Left, rect.Top + radius);
                        break;
                    }
                case RoundRectanglePosition.TopRight:
                    {
                        rectPath.AddArc(rect.Right - radius * 2, rect.Top, radius * 2, radius * 2, 270, 90);
                        rectPath.AddLine(rect.Right, rect.Top, rect.Right - radius, rect.Top);
                        break;
                    }
                case RoundRectanglePosition.BottomLeft:
                    {
                        rectPath.AddArc(rect.Left, rect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
                        rectPath.AddLine(rect.Left, rect.Bottom - radius, rect.Left, rect.Bottom);
                        break;
                    }
                case RoundRectanglePosition.BottomRight:
                    {
                        rectPath.AddArc(rect.Right - radius * 2, rect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
                        rectPath.AddLine(rect.Right - radius, rect.Bottom, rect.Right, rect.Bottom);
                        break;
                    }
            }
            return rectPath;
        }

    }
}
