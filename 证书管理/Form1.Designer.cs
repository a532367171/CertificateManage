namespace 证书管理
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dlg = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Tool_AddFile = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_File = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_Dir = new System.Windows.Forms.ToolStripMenuItem();
            this.Tool_DeleteFile = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_SelectFile = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolSt_RepeatFile = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_ALLFile = new System.Windows.Forms.ToolStripMenuItem();
            this.Tool_List = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_NewList = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_ADDList = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_OpenList = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_SaveList = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_DeleteList = new System.Windows.Forms.ToolStripMenuItem();
            this.Tool_Mode = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_Mode01 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_Mode02 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_Mode03 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_Mode04 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_Mode05 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_Component = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dlg
            // 
            this.dlg.FileName = "dlg";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(398, 405);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Gainsboro;
            this.menuStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuStrip1.BackgroundImage")));
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Tool_AddFile,
            this.Tool_DeleteFile,
            this.Tool_List,
            this.Tool_Mode});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(656, 25);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Tool_AddFile
            // 
            this.Tool_AddFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolS_File,
            this.ToolS_Dir});
            this.Tool_AddFile.Name = "Tool_AddFile";
            this.Tool_AddFile.Size = new System.Drawing.Size(44, 21);
            this.Tool_AddFile.Text = "添加";
            // 
            // ToolS_File
            // 
            this.ToolS_File.Name = "ToolS_File";
            this.ToolS_File.Size = new System.Drawing.Size(112, 22);
            this.ToolS_File.Text = "文件";
            this.ToolS_File.Click += new System.EventHandler(this.ToolS_File_Click);
            // 
            // ToolS_Dir
            // 
            this.ToolS_Dir.Name = "ToolS_Dir";
            this.ToolS_Dir.Size = new System.Drawing.Size(112, 22);
            this.ToolS_Dir.Text = "文件夹";
            // 
            // Tool_DeleteFile
            // 
            this.Tool_DeleteFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolS_SelectFile,
            this.ToolSt_RepeatFile,
            this.ToolS_ALLFile});
            this.Tool_DeleteFile.Name = "Tool_DeleteFile";
            this.Tool_DeleteFile.Size = new System.Drawing.Size(44, 21);
            this.Tool_DeleteFile.Text = "删除";
            // 
            // ToolS_SelectFile
            // 
            this.ToolS_SelectFile.Name = "ToolS_SelectFile";
            this.ToolS_SelectFile.Size = new System.Drawing.Size(136, 22);
            this.ToolS_SelectFile.Tag = "0";
            this.ToolS_SelectFile.Text = "选中的文件";
            // 
            // ToolSt_RepeatFile
            // 
            this.ToolSt_RepeatFile.Name = "ToolSt_RepeatFile";
            this.ToolSt_RepeatFile.Size = new System.Drawing.Size(136, 22);
            this.ToolSt_RepeatFile.Tag = "1";
            this.ToolSt_RepeatFile.Text = "重复的文件";
            // 
            // ToolS_ALLFile
            // 
            this.ToolS_ALLFile.Name = "ToolS_ALLFile";
            this.ToolS_ALLFile.Size = new System.Drawing.Size(136, 22);
            this.ToolS_ALLFile.Tag = "2";
            this.ToolS_ALLFile.Text = "全部删除";
            // 
            // Tool_List
            // 
            this.Tool_List.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolS_NewList,
            this.ToolS_ADDList,
            this.ToolS_OpenList,
            this.ToolS_SaveList,
            this.ToolS_DeleteList});
            this.Tool_List.Name = "Tool_List";
            this.Tool_List.Size = new System.Drawing.Size(44, 21);
            this.Tool_List.Text = "列表";
            // 
            // ToolS_NewList
            // 
            this.ToolS_NewList.Name = "ToolS_NewList";
            this.ToolS_NewList.Size = new System.Drawing.Size(124, 22);
            this.ToolS_NewList.Tag = "1";
            this.ToolS_NewList.Text = "新建列表";
            // 
            // ToolS_ADDList
            // 
            this.ToolS_ADDList.Name = "ToolS_ADDList";
            this.ToolS_ADDList.Size = new System.Drawing.Size(124, 22);
            this.ToolS_ADDList.Tag = "2";
            this.ToolS_ADDList.Text = "添加列表";
            // 
            // ToolS_OpenList
            // 
            this.ToolS_OpenList.Name = "ToolS_OpenList";
            this.ToolS_OpenList.Size = new System.Drawing.Size(124, 22);
            this.ToolS_OpenList.Tag = "3";
            this.ToolS_OpenList.Text = "打开列表";
            // 
            // ToolS_SaveList
            // 
            this.ToolS_SaveList.Name = "ToolS_SaveList";
            this.ToolS_SaveList.Size = new System.Drawing.Size(124, 22);
            this.ToolS_SaveList.Tag = "4";
            this.ToolS_SaveList.Text = "保存列表";
            // 
            // ToolS_DeleteList
            // 
            this.ToolS_DeleteList.Name = "ToolS_DeleteList";
            this.ToolS_DeleteList.Size = new System.Drawing.Size(124, 22);
            this.ToolS_DeleteList.Tag = "5";
            this.ToolS_DeleteList.Text = "删除列表";
            // 
            // Tool_Mode
            // 
            this.Tool_Mode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolS_Mode01,
            this.ToolS_Mode02,
            this.ToolS_Mode03,
            this.ToolS_Mode04,
            this.ToolS_Mode05});
            this.Tool_Mode.Name = "Tool_Mode";
            this.Tool_Mode.Size = new System.Drawing.Size(44, 21);
            this.Tool_Mode.Text = "模式";
            // 
            // ToolS_Mode01
            // 
            this.ToolS_Mode01.Name = "ToolS_Mode01";
            this.ToolS_Mode01.Size = new System.Drawing.Size(124, 22);
            this.ToolS_Mode01.Tag = "1";
            this.ToolS_Mode01.Text = "单曲播放";
            // 
            // ToolS_Mode02
            // 
            this.ToolS_Mode02.Name = "ToolS_Mode02";
            this.ToolS_Mode02.Size = new System.Drawing.Size(124, 22);
            this.ToolS_Mode02.Tag = "2";
            this.ToolS_Mode02.Text = "单曲循环";
            // 
            // ToolS_Mode03
            // 
            this.ToolS_Mode03.Name = "ToolS_Mode03";
            this.ToolS_Mode03.Size = new System.Drawing.Size(124, 22);
            this.ToolS_Mode03.Tag = "3";
            this.ToolS_Mode03.Text = "顺序播放";
            // 
            // ToolS_Mode04
            // 
            this.ToolS_Mode04.Name = "ToolS_Mode04";
            this.ToolS_Mode04.Size = new System.Drawing.Size(124, 22);
            this.ToolS_Mode04.Tag = "4";
            this.ToolS_Mode04.Text = "循环播放";
            // 
            // ToolS_Mode05
            // 
            this.ToolS_Mode05.Name = "ToolS_Mode05";
            this.ToolS_Mode05.Size = new System.Drawing.Size(124, 22);
            this.ToolS_Mode05.Tag = "5";
            this.ToolS_Mode05.Text = "随机播放";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(338, 425);
            this.panel1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(343, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "UseComponent";
            // 
            // cmb_Component
            // 
            this.cmb_Component.FormattingEnabled = true;
            this.cmb_Component.Location = new System.Drawing.Point(426, 28);
            this.cmb_Component.Name = "cmb_Component";
            this.cmb_Component.Size = new System.Drawing.Size(99, 20);
            this.cmb_Component.TabIndex = 7;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(521, 408);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 19);
            this.button2.TabIndex = 9;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_Component);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog dlg;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Tool_AddFile;
        private System.Windows.Forms.ToolStripMenuItem ToolS_File;
        private System.Windows.Forms.ToolStripMenuItem ToolS_Dir;
        private System.Windows.Forms.ToolStripMenuItem Tool_DeleteFile;
        private System.Windows.Forms.ToolStripMenuItem ToolS_SelectFile;
        private System.Windows.Forms.ToolStripMenuItem ToolSt_RepeatFile;
        private System.Windows.Forms.ToolStripMenuItem ToolS_ALLFile;
        private System.Windows.Forms.ToolStripMenuItem Tool_List;
        private System.Windows.Forms.ToolStripMenuItem ToolS_NewList;
        private System.Windows.Forms.ToolStripMenuItem ToolS_ADDList;
        private System.Windows.Forms.ToolStripMenuItem ToolS_OpenList;
        private System.Windows.Forms.ToolStripMenuItem ToolS_SaveList;
        private System.Windows.Forms.ToolStripMenuItem ToolS_DeleteList;
        private System.Windows.Forms.ToolStripMenuItem Tool_Mode;
        private System.Windows.Forms.ToolStripMenuItem ToolS_Mode01;
        private System.Windows.Forms.ToolStripMenuItem ToolS_Mode02;
        private System.Windows.Forms.ToolStripMenuItem ToolS_Mode03;
        private System.Windows.Forms.ToolStripMenuItem ToolS_Mode04;
        private System.Windows.Forms.ToolStripMenuItem ToolS_Mode05;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_Component;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button2;
    }
}

