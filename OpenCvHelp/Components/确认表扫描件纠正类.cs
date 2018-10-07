using OpenCvHelp.Interfaces;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OpenCvHelp.Components
{
    public class 确认表扫描件纠正类 : IOpencvFunc
    {
        public void handle1(string absoluteFilePath)
        {
            using (Mat Image原图 = Cv2.ImRead(absoluteFilePath))
            using (Mat Image旋转后原图 = The_Angle_correct(Image原图))
            {
                Image旋转后原图.SaveImage(absoluteFilePath);
                string getExtension = Path.GetExtension(absoluteFilePath);
                string newFileName = absoluteFilePath.Replace(getExtension, ".tif");
                Image旋转后原图.SaveImage(newFileName);

            }
         
        }
        /// <summary>
        /// 角度纠正
        /// </summary>
        /// <param name="Image原图"></param>
        /// <returns></returns>
        public Mat The_Angle_correct(Mat Image原图)
        {
            Mat Image旋转纠正后原图 = new Mat();
            using (Mat Image灰度 = new Mat())
            using (Mat Image自适应阈值化 = new Mat())
            //using (Mat Image旋转纠正后原图 = new Mat())
            {
                Cv2.CvtColor(Image原图, Image灰度, ColorConversionCodes.BGR2GRAY);
                Cv2.AdaptiveThreshold(~Image灰度, Image自适应阈值化, 255, AdaptiveThresholdTypes.MeanC, ThresholdTypes.Binary, 15, -2);
                //查找轮廓
                OpenCvSharp.Point[][] contours查找的轮廓 = Find_the_outline(Image自适应阈值化);

                for (int i = 0; i < contours查找的轮廓.Length; i++)
                {
                    RotatedRect rotaterect倾斜 = Cv2.MinAreaRect(contours查找的轮廓[i]);
                    if (rotaterect倾斜.Size.Height * rotaterect倾斜.Size.Width > 1000000)
                    {
                        Rect rect轮廓 = Cv2.BoundingRect(contours查找的轮廓[i]);
                        float angle;
                        Image旋转纠正后原图.SetTo(255);
                        Point2f center = rotaterect倾斜.Center;  //中心点
                        if (rotaterect倾斜.Size.Height > rotaterect倾斜.Size.Width)
                        {
                            angle = rotaterect倾斜.Angle;

                        }
                        else
                        {
                            angle = 90.0f + rotaterect倾斜.Angle;

                            //Point2f center =(Point2f)90.0- rotaterect倾斜.Center;
                        }
                        using (Mat M2 = Cv2.GetRotationMatrix2D(center, angle, 1))
                        {
                            //Cv2.WarpAffine(Image直接阈值化, Image旋转后灰度图, M2, Image直接阈值化.Size(), InterpolationFlags.Linear, 0, new Scalar(0));//仿射变换
                            Cv2.WarpAffine(Image原图, Image旋转纠正后原图, M2, Image自适应阈值化.Size(), InterpolationFlags.Linear, 0, new Scalar(0));
                            //仿射变换
                            //Image原图.Rectangle(rect轮廓, Scalar.Red);
                            //Image旋转后原图.Rectangle(rect轮廓, Scalar.Gray);
                            //var window旋转后灰度图 = new Window("旋转后灰度图");
                            //window旋转后灰度图.Image = Image旋转后灰度图;
                            //var window旋转后原图 = new Window("旋转后原图");
                            //window旋转后原图.Image = Image旋转后原图;
                        }

                    }
                }
                
                return Image旋转纠正后原图;
                // Bottom-Right


                //using (new Window("Image原图", WindowMode.AutoSize, Image原图))
                //using (new Window("Image灰度", WindowMode.AutoSize, Image灰度))
                //using (new Window("Image自适应阈值化", WindowMode.AutoSize, Image自适应阈值化))
                //using (new Window("Image旋转后原图", WindowMode.AutoSize, Image旋转后原图))
                //{
                //    Window.WaitKey(0);
                //}
            }
        }

        /// <summary>
        /// 提前图片里的表格
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public Mat To_extract_form(Mat mat)
        {
            using (Mat horizontal横线图 = mat.Clone())
            using (Mat vertical竖线图 = mat.Clone())
            //为了获取横向的表格线，设置腐蚀和膨胀的操作区域为一个比较大的横向直条
            //横核,函数
            using (Mat horizontalStructure = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(horizontal横线图.Cols / 20, 1)))
            //竖核,函数
            using (Mat verticalStructure = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(1, vertical竖线图.Rows / 30)))
            {
                //横腐蚀
                Cv2.Erode(~horizontal横线图, horizontal横线图, horizontalStructure, new OpenCvSharp.Point(-1, -1));

                //横膨胀
                Cv2.Dilate(horizontal横线图, horizontal横线图, horizontalStructure, new OpenCvSharp.Point(-1, -1));

                //竖腐蚀
                Cv2.Erode(~vertical竖线图, vertical竖线图, verticalStructure, new OpenCvSharp.Point(-1, -1));

                //竖膨胀
                Cv2.Dilate(vertical竖线图, vertical竖线图, verticalStructure, new OpenCvSharp.Point(-1, -1));


                Mat Image纯表格 = horizontal横线图 + vertical竖线图;
                Cv2.CvtColor(~Image纯表格, Image纯表格, ColorConversionCodes.BGR2GRAY);

                //var window先腐蚀再膨胀纵向 = new Window("先腐蚀再膨胀纵向");
                //window先腐蚀再膨胀纵向.Image = vertical竖线图;

                //using (new Window("horizontal横线图", WindowMode.AutoSize, horizontal横线图))
                //using (new Window("vertical竖线图", WindowMode.AutoSize, vertical竖线图))
                //using (new Window("Image纯表格", WindowMode.AutoSize, Image纯表格))
                //{
                //    Window.WaitKey(0);

                //    //Image阈值化.SaveImage(@"D:\new1\langyp.fontyp.exp0.tif");
                //}
                //var window横纵向 = new Window("横纵向");
                //window横纵向.Image = Image纯表格;
                //Image纯表格.SaveImage(@"D:\new1\纯表格.tif");
                //Cv2.ImWrite("横纵向.jpg", Image纯表格);
                return Image纯表格;
            }

        }

        /// <summary>
        /// 查找轮廓
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public OpenCvSharp.Point[][] Find_the_outline(Mat mat)
        {
            OpenCvSharp.Point[][] contours查找纠正轮廓 = null;
            HierarchyIndex[] hierarcy查找纠正轮廓 = null;
            Cv2.FindContours(mat, out contours查找纠正轮廓, out hierarcy查找纠正轮廓, RetrievalModes.List, ContourApproximationModes.ApproxNone);
            return contours查找纠正轮廓;
        }

        /// <summary>
        /// 中值滤波器
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public Mat Filtering_processing(Mat Image原图)
        {
            using (Mat Image灰度 = new Mat())
            using (Mat 中值滤波器 = new Mat())
            using (Mat Image阈值化 = new Mat())
            {
                Cv2.CvtColor(Image原图, Image灰度, ColorConversionCodes.BGR2GRAY);
                Cv2.MedianBlur(Image灰度, 中值滤波器, 3);
                Cv2.Threshold(中值滤波器, Image阈值化, 220, 255, ThresholdTypes.Binary);
                //Cv2.Laplacian
                using (new Window("Image原图", WindowMode.AutoSize, Image原图))
                using (new Window("Image灰度", WindowMode.AutoSize, Image灰度))
                using (new Window("Image中值滤波器", WindowMode.AutoSize, 中值滤波器))
                using (new Window("Image阈值化", WindowMode.AutoSize, Image阈值化))
                {
                    Window.WaitKey(0);
                    //Image阈值化.SaveImage(@"D:\new1\langyp.fontyp.exp0.tif");
                }
                return Image阈值化;
            }
        }

        /// <summary>
        /// 高斯滤波
        /// </summary>
        /// <param name="Image原图"></param>
        /// <returns></returns>
        public Mat Filtering_processing1(Mat Image原图)
        {
            using (Mat Image灰度 = new Mat())
            using (Mat 高斯滤波 = new Mat())
            using (Mat Image阈值化 = new Mat())
            {
                Cv2.CvtColor(Image原图, Image灰度, ColorConversionCodes.BGR2GRAY);
                Cv2.GaussianBlur(Image灰度, 高斯滤波, new OpenCvSharp.Size(3, 3), 0, 0); ;
                Cv2.Threshold(高斯滤波, Image阈值化, 220, 255, ThresholdTypes.Binary);
                //Cv2.Laplacian
                using (new Window("Image原图", WindowMode.AutoSize, Image原图))
                using (new Window("Image灰度", WindowMode.AutoSize, Image灰度))
                using (new Window("Image高斯滤波", WindowMode.AutoSize, 高斯滤波))
                using (new Window("Image阈值化", WindowMode.AutoSize, Image阈值化))

                {
                    Window.WaitKey(0);

                    //Image阈值化.SaveImage(@"D:\new1\langyp.fontyp.exp0.tif");
                }
                return Image阈值化;
            }

        }

        public Point getCenterPoint(Rect rect)
        {
            Point cpt;
            cpt.X = rect.X + (int)(rect.Width / 2.0);
            cpt.Y = rect.Y + (int)(rect.Height / 2.0);
            return cpt;
        } 


    }
}
