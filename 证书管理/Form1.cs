using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 证书管理
{
    public partial class Form1 : Form
    {
        #region 定义全局变量，并实例化公共类对象
        public static string strFullName = "";    //记录选择的文件名及路径
        public static ArrayList list = new ArrayList();    //记录选择的项
        #endregion
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
    }
}
