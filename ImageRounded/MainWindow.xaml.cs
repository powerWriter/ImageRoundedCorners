using Microsoft.Win32;
using System;
using System.Windows;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Media;

namespace ImageRounded
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool changeTag = false;//是否已执行转换操作 true-已执行，false-未执行
        public Bitmap doBitmap ;
        public MainWindow()
        {

        }

        private void SelectImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "图片文件(*.jpg,*.png)|*.jpg;*.png;*.jpeg";//规定指定的格式
            dialog.Multiselect = false;//是否可以多选
            if (dialog.ShowDialog() == true)
            {
                //string now1 = DateTime.Now.ToString("yyyyMMddHHmmssf");
                foreach (String fileName in dialog.FileNames)
                {
                    using (Bitmap bitImage = new Bitmap(fileName))
                    {
                        FilePath.Text = fileName;
                        doBitmap = bitImage;
                        BitmapImage bitmapImage = BitmapToBitmapImageFromBitmap(bitImage);
                        ImagePreview.Source = bitmapImage;
                    }
                }
            }
        }

        private void OutPutPath_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog folder = new System.Windows.Forms.FolderBrowserDialog();
            if (folder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                OutPutPath.Text = folder.SelectedPath;
            }
        }

        private void OperationBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RoundCornerSize.Text.Trim() == "")
            {
                MessageBox.Show("请输入圆角大小");
                return;
            }
            if (null == ImagePreview.Source)
            {
                MessageBox.Show("请先导入图像");
                return;
            }

            Image tempImg = ImageSourceToBitmap(ImagePreview.Source);
            tempImg = CommenUtils.CreateRoundedCorner(tempImg, RoundCornerSize.Text,CommenUtils.RoundRectanglePosition.TopLeft);
            tempImg = CommenUtils.CreateRoundedCorner(tempImg, RoundCornerSize.Text,CommenUtils.RoundRectanglePosition.TopRight);
            tempImg = CommenUtils.CreateRoundedCorner(tempImg, RoundCornerSize.Text,CommenUtils.RoundRectanglePosition.BottomLeft);
            tempImg = CommenUtils.CreateRoundedCorner(tempImg, RoundCornerSize.Text,CommenUtils.RoundRectanglePosition.BottomRight);

            ImagePreview.Source = BitmapToBitmapImageFromBitmap((Bitmap)tempImg);
        }

        private void OutPutBtn_Click(object sender, RoutedEventArgs e)
        {
            if(OutPutPath.Text.Trim() == "")
            {
                MessageBox.Show("请输入输出路径");
                return;
            }
            if (OutPutName.Text.Trim() == "")
            {
                MessageBox.Show("请输入输出文件名");
                return;
            }

            Image tempImg = ImageSourceToBitmap(ImagePreview.Source);

            if (comboBox.SelectedIndex == 0)
                tempImg.Save(OutPutPath.Text + "\\" + OutPutName.Text + ".png", ImageFormat.Png);
            else if (comboBox.SelectedIndex == 1)
            {
                Bitmap bitmapImage = CommenUtils.doOperation((Bitmap)tempImg, int.Parse(RoundCornerSize.Text));
                bitmapImage.Save(OutPutPath.Text + "\\" + OutPutName.Text + ".png", ImageFormat.Png);
            }
             
            MessageBox.Show("导出成功！","提示信息");
        }

        public static BitmapImage BitmapToBitmapImageFromBitmap(Bitmap bitmap)
        {
            #region
            BitmapImage bitmapImage = new BitmapImage();
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = new MemoryStream(ms.ToArray());
                bitmapImage.EndInit();
            }
            return bitmapImage;
            #endregion
        }

        /// <summary>
        /// ImageSource to Bitmap
        /// </summary>
        /// <param name="imageSource"></param>
        /// <returns></returns>
        public static System.Drawing.Bitmap ImageSourceToBitmap(ImageSource imageSource)
        {
            BitmapSource m = (BitmapSource)imageSource;

            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(m.PixelWidth, m.PixelHeight, System.Drawing.Imaging.PixelFormat.Format32bppPArgb); // 坑点：选Format32bppRgb将不带透明度

            System.Drawing.Imaging.BitmapData data = bmp.LockBits(
            new System.Drawing.Rectangle(System.Drawing.Point.Empty, bmp.Size), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

            m.CopyPixels(Int32Rect.Empty, data.Scan0, data.Height * data.Stride, data.Stride);
            bmp.UnlockBits(data);

            return bmp;
        }

    }
}
