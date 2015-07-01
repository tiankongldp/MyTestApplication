using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DllInvoke
{
    public partial class Form1 : Form
    {
        public delegate int InitDll();
        public delegate int INIT(string pErrMsg);
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInvoke_Click(object sender, EventArgs e)
        {
            try
            {
                DllInvoke dll = new DllInvoke("dblib.dll");
                InitDll compile = (InitDll)dll.Invoke("InitDLL", typeof(InitDll));
                compile(); //这里就是调用我的DLL里定义的Compile函数
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DllInvoke dll = new DllInvoke(@"229900\SiInterface.dll");
                INIT compile = (INIT)dll.Invoke("INIT", typeof(INIT));
                string perrmsg = "".PadLeft(1024, ' ');
                int res = compile(perrmsg); //这里就是调用我的DLL里定义的Compile函数
                res = DllInvoke.INIT(perrmsg);
                if (res == 0 )
                {
                    MessageBox.Show("成功");
                }
                else
                {
                    MessageBox.Show(res.ToString() + " :" + perrmsg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
