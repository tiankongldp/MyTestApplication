using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
namespace GetIPv4Address
{
    public partial class MyTestForm : Form
    {
        private int count = 0;

        public MyTestForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            
            try
            {
                for (int i = 0; i <= ipHostInfo.AddressList.Length - 1; i++)
                {
                    string str2 = "";
                    IPAddress ipAddress = ipHostInfo.AddressList[i];
                    if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
                    {
                        byte[] addressbytes = ipAddress.GetAddressBytes();
                        for (int j = 0; j < addressbytes.Length; j++)
                        {
                            str2 = str2 + addressbytes[j].ToString() + ".";
                        }
                        MessageBox.Show(str2.Trim('.'));
                    }
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + 
                    Environment.StackTrace + Environment.NewLine + 
                    ex.StackTrace);
            }

            //MessageBox.Show(GetLocalIP());
        }

        public static string GetLocalIP()
        {
            try
            {
                string HostName = Dns.GetHostName(); //得到主机名
                IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
                for (int i = 0; i < IpEntry.AddressList.Length; i++)
                {
                    //从IP地址列表中筛选出IPv4类型的IP地址
                    //AddressFamily.InterNetwork表示此IP为IPv4,
                    //AddressFamily.InterNetworkV6表示此地址为IPv6类型
                    if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        return IpEntry.AddressList[i].ToString();
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取本机IP出错:" + ex.Message);
                return "";
            }
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            count++;
        }

        private void btnShowCount_Click(object sender, EventArgs e)
        {
            MessageBox.Show(count.ToString());
        }
    }
}
