using OpenCvHelp.Components;
using PdfComponent.Lib.Components;
using PdfComponent.Lib.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace 证书管理
{
    public partial class Form1 : Form
    {
        #region 定义全局变量，并实例化公共类对象
        public static string strFullName = "";    //记录选择的文件名及路径
        public static ArrayList list = new ArrayList();    //打开的文件（全文件）
        public static ArrayList list_out = new ArrayList();    //装换的照片路径（文件夹）

        public static string txt_OutputDir = System.IO.Directory.GetCurrentDirectory() + "\\temp";
        private readonly List<IPdfComponentFunc> _pdfComponents = new List<IPdfComponentFunc>();//PDF类

        #endregion
        public Form1()
        {
            InitializeComponent();
            //InitComponentList();
        }
        private void InitComponentList()
        {
            var implementedComponents = typeof(IPdfComponentFunc).Assembly.GetTypes()
                .Where(p => typeof(IPdfComponentFunc).IsAssignableFrom(p) && !p.IsInterface);

            foreach (var aComponent in implementedComponents)
            {
                var componentInstance = (IPdfComponentFunc)Activator.CreateInstance(aComponent);
                _pdfComponents.Add(componentInstance);
                cmb_Component.DisplayMember = "ComponentName";
                cmb_Component.Items.Add(new { ComponentName = componentInstance.ComponentName, ComponentIns = componentInstance });
            }
            cmb_Component.SelectedIndex = 0;
        }

        private IPdfComponentFunc GetSelectedComponent()
        {
            dynamic selectedItem = cmb_Component.SelectedItem;
            return (IPdfComponentFunc)selectedItem.ComponentIns;
        }

        private void CommonWorkFlow(Action<string, string> childDeal, string fileExtensionFilter = ".pdf")
        {
            if (!CheckSelect())
                return;

            foreach (string aPdfFile in list)
            {
                var pdfOutputDir = Path.Combine(txt_OutputDir, Path.GetFileNameWithoutExtension(aPdfFile));
                list_out.Add(pdfOutputDir);
                if (!string.IsNullOrEmpty(fileExtensionFilter) &&
                    !fileExtensionFilter.Split(',').Any(p => p.Equals(Path.GetExtension(aPdfFile), StringComparison.OrdinalIgnoreCase)))
                    continue;

                if (!Directory.Exists(pdfOutputDir))
                    Directory.CreateDirectory(pdfOutputDir);

                childDeal(aPdfFile, pdfOutputDir);
                //Thread thread = new Thread(new ThreadStart(() =>{
                //    childDeal(aPdfFile, pdfOutputDir);
                //}));
                //thread.Start();

            }

        }

        private bool CheckSelect()
        {
            //if (cmb_Component.SelectedIndex == -1)
            //{
            //    MessageBox.Show("Please Select Pdf Component");
            //    return false;
            //}
            if (list.Count == 0)
            {
                MessageBox.Show("Please Select Input File Directory");
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.backgroundWorker1.RunWorkerAsync(); // 运行 backgroundWorker 组件
            ProcessForm form = new ProcessForm(this.backgroundWorker1);// 显示进度条窗体
            form.ShowDialog(this);
            form.Close();
        }

        private void ToolS_File_Click(object sender, EventArgs e)
        {
            dlg.Multiselect = true;
            dlg.Filter = "PDF文件|*.pdf";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                foreach (string s in dlg.FileNames)
                {
                    list.Add(s);
                    //MessageBox.Show(s);
                }
            }


        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
            }
            else
            {
            }
        }
        //你可以在这个方法内，实现你的调用，方法等。
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            var selectCompoent = new AsposePdfComponent(worker);
            CommonWorkFlow((aPdfFile, outputDir) =>
            {
                //var selectCompoent = GetSelectedComponent();
                selectCompoent.ToJpeg(aPdfFile, outputDir);
            });
            if (worker.CancellationPending)  // 如果用户取消则跳出处理数据代码 
            {
                e.Cancel = true;
            }

            //for (int i = 0; i < 100; i++)
            //{
            //    Thread.Sleep(100);
            //    worker.ReportProgress(i);
            //    
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //var houghLinesComponent1 =new HoughLinesComponent();
            var 确认表扫描件纠正类1 = new 确认表扫描件纠正类();
            foreach (string aPdfFile in list_out)
            {
                var pdfFiles = Directory.GetFiles(aPdfFile);
                foreach (var aPdfFile1 in pdfFiles)
                {
                    //var pdfOutputDir = Path.Combine(txt_OutputDir.Text, );

                    确认表扫描件纠正类1.handle1(aPdfFile1);
                 
                }
                //for (int i = 0; i < pdfFiles.Length; i++)
                //{
                //    var pdfOutputDir = Path.Combine(txt_OutputDir.Text, );

                //}

            }



           
        }
    }
}
