using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gma.QrCodeNet;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.Drawing;
using System.Drawing.Imaging;

namespace Wfs.Core
{
    /// <summary>
    /// 二维码类库
    /// </summary>
    public static class QrCodeHelper
    {
        /// <summary>
        /// 生成并保存二维码图片
        /// </summary>
        /// <param name="text">文字信息</param>
        /// <param name="filename">图片保存地址</param>
        public static void Generate(string text, string filename)
        {
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.M);
            QrCode qrCode = qrEncoder.Encode(text);
            //保存成png文件
            GraphicsRenderer render = new GraphicsRenderer(new FixedModuleSize(5, QuietZoneModules.Two), Brushes.Black, Brushes.White);
            using (FileStream stream = new FileStream(filename, FileMode.Create))
            {
                render.WriteToStream(qrCode.Matrix, ImageFormat.Png, stream);
            }
        }

        /// <summary>
        /// 生成带Logo的二维码流
        /// </summary>
        /// <param name="text">二维码内容</param>
        /// <param name="iconPath">Logo</param>
        /// <param name="moduleSize"></param>
        /// <returns></returns>
        public static byte[] GenerateQrCode(string text,string iconPath="",int moduleSize = 9)
        {
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.M);
            QrCode qrCode = qrEncoder.Encode(text);
            //保存成png文件
            GraphicsRenderer render = new GraphicsRenderer(new FixedModuleSize(moduleSize, QuietZoneModules.Two), Brushes.Black, Brushes.White);
            DrawingSize dSize = render.SizeCalculator.GetSize(qrCode.Matrix.Width);
            Bitmap bmp=new Bitmap(dSize.CodeWidth,dSize.CodeWidth);
            Graphics g=Graphics.FromImage(bmp);
            render.Draw(g,qrCode.Matrix);

            if (!string.IsNullOrEmpty(iconPath))
            {
                Image img=Image.FromFile(iconPath);
                Point point=new Point((bmp.Width-img.Width)/2,(bmp.Height-img.Height)/2);
                g.DrawImage(img,point.X,point.Y,img.Width,img.Height);
            }

            MemoryStream stream=new MemoryStream();
            bmp.Save(stream,ImageFormat.Jpeg);

            return stream.GetBuffer();
        }
    }
}
