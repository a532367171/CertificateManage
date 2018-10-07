using OpenCvHelp.Interfaces;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCvHelp.Components
{
    public class HoughLinesComponent : IOpencvFunc
    {
        public void handle1(string absoluteFilePath)
        {
            //throw new NotImplementedException();
            SampleCpp(absoluteFilePath);
        }
        private void SampleCpp(string absoluteFilePath)
        {
            // (1) Load the image 载入照片
            using (Mat imgGray = new Mat(absoluteFilePath, ImreadModes.GrayScale))
            using (Mat imgStd = new Mat(absoluteFilePath, ImreadModes.Color))
            using (Mat imgProb = imgStd.Clone())
            {
                // （2）Preprocess 预处理  图像中的边缘发现用精明的算法?
                Cv2.Canny(imgGray, imgGray, 50, 200, 3, false);

                // (3) Run Standard Hough Transform  运行标准霍夫变换
                LineSegmentPolar[] segStd = Cv2.HoughLines(imgGray, 1, Math.PI / 180, 50, 0, 0);
                int limit = Math.Min(segStd.Length, 10);
                for (int i = 0; i < limit; i++)
                {
                    // Draws result lines 绘制结果 直线
                    float rho = segStd[i].Rho;
                    float theta = segStd[i].Theta;
                    double a = Math.Cos(theta);
                    double b = Math.Sin(theta);
                    double x0 = a * rho;
                    double y0 = b * rho;
                    Point pt1 = new Point { X = (int)Math.Round(x0 + 1000 * (-b)), Y = (int)Math.Round(y0 + 1000 * (a)) };
                    Point pt2 = new Point { X = (int)Math.Round(x0 - 1000 * (-b)), Y = (int)Math.Round(y0 - 1000 * (a)) };
                    imgStd.Line(pt1, pt2, Scalar.Red, 3, LineTypes.AntiAlias, 0);
                }

                // (4) Run Probabilistic Hough Transform 运行概率霍夫变换
                LineSegmentPoint[] segProb = Cv2.HoughLinesP(imgGray, 1, Math.PI / 180, 50, 50, 10);
                foreach (LineSegmentPoint s in segProb)
                {
                    imgProb.Line(s.P1, s.P2, Scalar.Red, 3, LineTypes.AntiAlias, 0);
                }

                // (5) Show results 显示结果
                using (new Window("Hough_line_standard", WindowMode.AutoSize, imgStd))
                using (new Window("imgGray", WindowMode.AutoSize, imgGray))
                using (new Window("imgProb", WindowMode.AutoSize, imgProb))
                using (new Window("Hough_line_probabilistic", WindowMode.AutoSize, imgProb))
                {
                    Window.WaitKey(0);
                }
            }
        }

    }
}
