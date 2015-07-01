using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace DeleInvoke
{
    public partial class Form1 : Form
    {
        private readonly int Max_Item_count = 1000;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Thread(((ThreadStart)(delegate()
                {
                    for (int i = 0; i < Max_Item_count; i++)
                    {
                        listView1.Invoke((MethodInvoker)delegate()
                        {
                            listView1.Items.Add(new ListViewItem(new string[] { i.ToString(), string.Format("This is No.{0} item", i.ToString()) }));
                        });
                    }

                }))).Start();
        }
    }
}
