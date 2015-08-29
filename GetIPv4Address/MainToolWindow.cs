using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UtilityLibrary.WinControls;

namespace GetIPv4Address
{
    public partial class MainToolWindow : WeifenLuo.WinFormsUI.Docking.DockContent
    {

        private OutlookBar outlookBar1 = null;

        public MainToolWindow()
        {
            InitializeComponent();
            InitializeOutlookbar();
        }

        private void InitializeOutlookbar()
        {
            outlookBar1 = new OutlookBar();

            #region 销售管理
            OutlookBarBand outlookShortcutsBand = new OutlookBarBand("销售管理");
            outlookShortcutsBand.SmallImageList = this.imageList;
            outlookShortcutsBand.LargeImageList = this.imageList;
            outlookShortcutsBand.Items.Add(new OutlookBarItem(outlookBar1, "订单管理", 0));
            outlookShortcutsBand.Items.Add(new OutlookBarItem(outlookBar1, "客户管理", 1));
            outlookShortcutsBand.Items.Add(new OutlookBarItem(outlookBar1, "水票管理", 2));
            outlookShortcutsBand.Items.Add(new OutlookBarItem(outlookBar1, "套餐管理", 3));
            outlookShortcutsBand.Items.Add(new OutlookBarItem(outlookBar1, "今日盘点", 5));
            outlookShortcutsBand.Items.Add(new OutlookBarItem(outlookBar1, "来电记录", 6));
            outlookShortcutsBand.Items.Add(new OutlookBarItem(outlookBar1, "送货记录", 7));
            outlookShortcutsBand.Background = SystemColors.AppWorkspace;
            outlookShortcutsBand.TextColor = Color.White;
            outlookBar1.Bands.Add(outlookShortcutsBand);

            #endregion

            #region 产品库存管理
            OutlookBarBand mystorageBand = new OutlookBarBand("产品库存管理");
            mystorageBand.SmallImageList = this.imageList;
            mystorageBand.LargeImageList = this.imageList;
            mystorageBand.Items.Add(new OutlookBarItem(outlookBar1, "产品管理", 2));
            mystorageBand.Items.Add(new OutlookBarItem(outlookBar1, "库存管理", 3));
            mystorageBand.Background = SystemColors.AppWorkspace;
            mystorageBand.TextColor = Color.White;
            outlookBar1.Bands.Add(mystorageBand);
            #endregion

            outlookBar1.Dock = DockStyle.Fill;
            outlookBar1.CurrentBand = 1;
            outlookBar1.ItemClicked += new OutlookBarItemClickedHandler(OnOutlookBarItemClicked);
            outlookBar1.ItemDropped += new OutlookBarItemDroppedHandler(OnOutlookBarItemDropped);

            //outlookBar1.FlatArrowButtons = true;
            this.panel1.Controls.AddRange(new Control[] { outlookBar1 });
        }

        private void OnOutlookBarItemClicked(OutlookBarBand band, OutlookBarItem item)
        {
            switch (item.Text)
            {
                #region 销售管理

                case "订单管理":
                    Portal.gc.MainDialog.ShowContent("订单管理", typeof(BaseForm));
                    break;
                case "客户管理":
                    Portal.gc.MainDialog.ShowContent("客户管理", typeof(BaseForm));
                    break;
                case "水票管理":
                    Portal.gc.MainDialog.ShowContent("水票管理", typeof(BaseForm));
                    break;
                case "套餐管理":
                    BaseForm dlg = new BaseForm();
                    dlg.ShowDialog();
                    break;
                case "来电记录":
                    Portal.gc.MainDialog.ShowContent("来电记录", typeof(BaseForm));
                    break;
                case "送货记录":
                    Portal.gc.MainDialog.ShowContent("送货记录", typeof(BaseForm));
                    break;

                #endregion

                #region 产品库存管理
                case "产品管理":
                    Portal.gc.MainDialog.ShowContent("产品管理", typeof(BaseForm));
                    break;
                case "库存管理":
                    Portal.gc.MainDialog.ShowContent("库存管理", typeof(BaseForm));
                    break;
                #endregion

                default:
                    break;
            }
        }

        private void OnOutlookBarItemDropped(OutlookBarBand band, OutlookBarItem item)
        {
            //            string message = "Item : " + item.Text + " was dropped";
            //            MessageBox.Show(message);            
        }
    }
}
