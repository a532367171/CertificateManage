using OpenCvHelp.Components;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpenCvHelp
{
    public partial class Form1 : Form
    {
        确认表扫描件纠正类 handle;
        public Form1()
        {
            InitializeComponent();
            handle = new 确认表扫描件纠正类();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //using (Mat Image原图 = Cv2.ImRead(openFileDialog1.FileName))

            using (Mat Image原图 = Cv2.ImRead(@"D:\new1\input2.tif"))
            using (Mat Image原图角度纠正后 = handle.The_Angle_correct(Image原图))
            using (Mat Image表格 = handle.To_extract_form(Image原图角度纠正后))
            {
                OpenCvSharp.Point[][] contours查找表格轮廓 = handle.Find_the_outline(Image表格);
                Rect[] rect = new Rect[contours查找表格轮廓.Length];
                OpenCvSharp.Point[][] contours_poly = new OpenCvSharp.Point[contours查找表格轮廓.Length][];
                Point2f center;
                for (int i = 0; i < contours查找表格轮廓.Length; i++)
                {
                    //获取区域的面积，如果小于某个值就忽略，代表是杂线不是表格
                    double area = Cv2.ContourArea(contours查找表格轮廓[i]);
                    if (area < 1000)
                        continue;
                    if (area > 4000000)
                        continue;
                    //拟近的多边形  ApproxPolyDP
                    contours_poly[i] = Cv2.ApproxPolyDP(contours查找表格轮廓[i], 3, true);
                    //矩形 最小正矩形    包围  BoundingRect
                    rect[i] = Cv2.BoundingRect(contours_poly[i]);

                    //矩形 最小斜矩形    包围  MinAreaRect
                    RotatedRect 斜矩形 = Cv2.MinAreaRect(contours查找表格轮廓[i]);

                    Rect rect2 = new Rect(rect[i].X + 2, rect[i].Y + 2, rect[i].Width - 4, rect[i].Height - 4);
                    Cv2.Rectangle(Image原图, rect2, Scalar.Red);
                    Image原图.PutText(">>" +i.ToString()+ "____"+area.ToString(), handle.getCenterPoint(rect2), HersheyFonts.HersheySimplex, 0.5, Scalar.Blue);

                }

                //using (new Window("Image原图", WindowMode.AutoSize, Image原图))
                ////using (new Window("Image原图角度纠正后", WindowMode.AutoSize, Image原图角度纠正后))
                ////using (new Window("Image表格", WindowMode.AutoSize, Image表格)) 
                //{
                //    Image原图.SaveImage(@"D:\new1\画框框.tif");
                //    Window.WaitKey(0);
                //}
                Image原图.SaveImage(@"D:\new1\画框框.tif");

            }
        }
    }
}