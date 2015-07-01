namespace GetIPv4Address
{
    partial class MainToolWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainToolWindow));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "保存.ico");
            this.imageList.Images.SetKeyName(1, "报产.ico");
            this.imageList.Images.SetKeyName(2, "编辑 .ico");
            this.imageList.Images.SetKeyName(3, "病历 .ico");
            this.imageList.Images.SetKeyName(4, "病人.ico");
            this.imageList.Images.SetKeyName(5, "查看.ico");
            this.imageList.Images.SetKeyName(6, "查找.ico");
            this.imageList.Images.SetKeyName(7, "出院.ico");
            this.imageList.Images.SetKeyName(8, "出院结算.ico");
            this.imageList.Images.SetKeyName(9, "催款.ico");
            this.imageList.Images.SetKeyName(10, "打开.ico");
            this.imageList.Images.SetKeyName(11, "打印.ico");
            this.imageList.Images.SetKeyName(12, "导出.ico");
            this.imageList.Images.SetKeyName(13, "导入.ico");
            this.imageList.Images.SetKeyName(14, "第一个.ico");
            this.imageList.Images.SetKeyName(15, "发送.ico");
            this.imageList.Images.SetKeyName(16, "发药.ico");
            this.imageList.Images.SetKeyName(17, "反馈 .ico");
            this.imageList.Images.SetKeyName(18, "分诊台.ico");
            this.imageList.Images.SetKeyName(19, "供应商.ico");
            this.imageList.Images.SetKeyName(20, "关系.ico");
            this.imageList.Images.SetKeyName(21, "合并 .ico");
            this.imageList.Images.SetKeyName(22, "后退.ico");
            this.imageList.Images.SetKeyName(23, "基础 .ico");
            this.imageList.Images.SetKeyName(24, "加号.ico");
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 428);
            this.panel1.TabIndex = 0;
            // 
            // MainToolWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 432);
            this.Controls.Add(this.panel1);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HideOnClose = true;
            this.Name = "MainToolWindow";
            this.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeftAutoHide;
            this.TabText = "工具";
            this.Text = "工具窗口";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Panel panel1;
    }
}