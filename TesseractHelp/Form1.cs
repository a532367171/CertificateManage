using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tesseract;

namespace TesseractHelp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //PictureBox控件显示图片
                    pictureBox1.Load(openFileDialog1.FileName);
                    //获取用户选择文件的后缀名 
                    string extension = Path.GetExtension(openFileDialog1.FileName);
                    //声明允许的后缀名 
                    string[] str = new string[] { ".jpg", ".png" };
                    if (!str.Contains(extension))
                    {
                        MessageBox.Show("仅能上传jpg,png格式的图片！");
                    }
                    else
                    {
                        //识别图片文字
                        var img = new Bitmap(openFileDialog1.FileName);
                        //var ocr = new TesseractEngine("./tessdata", "eng", EngineMode.TesseractAndCube);
                        var ocr = new TesseractEngine("./tessdata", "chi_sim", EngineMode.TesseractAndCube);

                        var page = ocr.Process(img);
                        label1.Text = page.GetText();
                    }
                }

            }
        }
    }
}
