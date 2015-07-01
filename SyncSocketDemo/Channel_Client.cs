using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace SyncSocketDemo
{
    public class Channel_Client
    {
        static Channel_Client instance = null;
        private bool isConnected;
        private byte[] buf;
        private NetworkStream ns;
        Socket socket;

        public static Channel_Client Instance()
        {
            if (instance == null)
            {
                instance = new Channel_Client();
            }
            return instance;
        }

        private Channel_Client()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//初始化socket
            buf = new byte[1024];
            isConnected = false;
        }

        public bool connect(string strIP, int portNum, int readTimeOut)
        {

            IPAddress[] ipAddr = Dns.GetHostAddresses(strIP);
            IPAddress ip = ipAddr[0];
            IPEndPoint hostEP = new IPEndPoint(ip, portNum);
            isConnected = true;
            try
            {

                Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//初始化socket
                s.Bind(hostEP);
                s.Listen(0);
                socket = s.Accept();
                //尝试连接 客户端时
                //socket=socket.Connect(hostEP);
            }
            catch (Exception se)
            {
                //MessageBox.Show("连接错误" + se.Message, "提示信息", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
                Console.WriteLine("连接错误" + se.Message);
                isConnected = false;
                return false;
            }
            ns = new NetworkStream(socket);
            if (readTimeOut < 0)
                readTimeOut = 0;
            ns.ReadTimeout = readTimeOut;
            return isConnected;
        }

        public bool getPoint(ref float x, ref float y)
        {
            if (isConnected == false)
            {
                return false;
            }
            try
            {
                if (ns.DataAvailable)
                {
                    while (ns.DataAvailable)
                    {
                        ns.Read(buf, 0, 20);
                    }
                }
                else
                {
                    ns.Read(buf, 0, 20);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            x = BitConverter.ToSingle(buf, 12);
            y = BitConverter.ToSingle(buf, 16);
            return true;
        }

        public bool close()
        {
            try
            {
                if (ns != null)
                {
                    ns.Close();
                }
                if (socket != null)
                {
                    socket.Close();
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }

        public bool sendPoint(float x, float y)
        {
            if (isConnected == false)
            {
                return false;
            }
            float flag = 0;
            byte[] bf = BitConverter.GetBytes(flag);
            byte[] bx = BitConverter.GetBytes(x);
            byte[] by = BitConverter.GetBytes(y);
            bf.CopyTo(buf, 0);
            bx.CopyTo(buf, 4);
            by.CopyTo(buf, 8);
            bf.CopyTo(buf, 12);
            bf.CopyTo(buf, 16);
            try
            {
                ns.Write(buf, 0, 20);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            ns.Flush();
            return true;
        }
    }
}
