using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Reflection;

namespace GetIPv4Address
{
    public partial class MainForm : Form
    {

        #region 属性字段

        private MainToolWindow mainToolWin = new MainToolWindow();
        private BaseForm frmProduct = new BaseForm();
        private BaseForm frmCustomer = new BaseForm();
        private BaseForm frmOrder = new BaseForm();
        private BaseForm frmStock = new BaseForm();
        private BaseForm frmComingCall = new BaseForm();
        private BaseForm frmDeliving = new BaseForm();
        private BaseForm frmHistory = new BaseForm();

        #endregion

        public MainForm()
        {
            InitializeComponent();

            SplashScreen.Splasher.Status = "正在展示相关的内容";
            System.Threading.Thread.Sleep(100);

            mainToolWin.Show(this.dockPanel, DockState.DockLeft);

            //frmComingCall.Show(this.dockPanel);
            //frmDeliving.Show(this.dockPanel);
            //frmHistory.Show(this.dockPanel);
            //frmStock.Show(this.dockPanel);
            //frmProduct.Show(this.dockPanel);
            //frmCustomer.Show(this.dockPanel);
            //frmOrder.Show(this.dockPanel);

            SplashScreen.Splasher.Status = "初始化完毕";
            System.Threading.Thread.Sleep(50);

            SplashScreen.Splasher.Close();
        }

        //private void menu_Window_CloseAll_Click(object sender, EventArgs e)
        //{
        //    CloseAllDocuments();
        //}

        //private void menu_Window_CloseOther_Click(object sender, EventArgs e)
        //{
        //    if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
        //    {
        //        Form activeMdi = ActiveMdiChild;
        //        foreach (Form form in MdiChildren)
        //        {
        //            if (form != activeMdi)
        //            {
        //                form.Close();
        //            }
        //        }
        //    }
        //    else
        //    {
        //        foreach (IDockContent document in dockPanel.DocumentsToArray())
        //        {
        //            if (!document.DockHandler.IsActivated)
        //            {
        //                document.DockHandler.Close();
        //            }
        //        }
        //    }
        //}

        //private DockContent FindDocument(string text)
        //{
        //    if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
        //    {
        //        foreach (Form form in MdiChildren)
        //        {
        //            if (form.Text == text)
        //            {
        //                return form as DockContent;
        //            }
        //        }

        //        return null;
        //    }
        //    else
        //    {
        //        foreach (DockContent content in dockPanel.Documents)
        //        {
        //            if (content.DockHandler.TabText == text)
        //            {
        //                return content;
        //            }
        //        }

        //        return null;
        //    }
        //}

        //public DockContent ShowContent(string caption, Type formType)
        //{
        //    DockContent frm = FindDocument(caption);
        //    if (frm == null)
        //    {
        //        frm = ChildWinManagement.LoadMdiForm(Portal.gc.MainDialog, formType) as DockContent;
        //    }

        //    frm.Show(this.dockPanel);
        //    frm.BringToFront();
        //    return frm;
        //}

        //public void CloseAllDocuments()
        //{
        //    if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
        //    {
        //        foreach (Form form in MdiChildren)
        //        {
        //            form.Close();
        //        }
        //    }
        //    else
        //    {
        //        IDockContent[] documents = dockPanel.DocumentsToArray();
        //        foreach (IDockContent content in documents)
        //        {
        //            content.DockHandler.Close();
        //        }
        //    }
        //} 

        #region 自定义方法

        public void ShowContent(string frmName, Type frmType)
        {
            //BaseForm bf = (BaseForm)(Activator.CreateInstance(frmType));
            BaseForm bf = new BaseForm();
            bf.MdiParent = this;
            bf.WindowState = FormWindowState.Maximized;
            bf.Show(this.dockPanel);
            bf.Activate();
            //bf.Show(this.dockPanel);
        }

        #endregion
    }
}
