using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SyncSocketDemo
{
    public class Channel_Server
    {
        // Thread signal. 
        public static ManualResetEvent allDone = new ManualResetEvent(false);
        static Channel_Server instance = null;
        private bool isConnected;
        private byte[] buf;
        float x, y;
        Socket socket, listener;

        public static Channel_Server Instance()
        {
            if (instance == null)
            {
                instance = new Channel_Server();
            }
            return instance;
        }

        private Channel_Server()
        {

            buf = new byte[1024];
            isConnected = false;
            x = 0;
            y = 0;
        }

        public bool startServer(string strIP, int portNum)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//初始化socket
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//初始化socket
            IPAddress[] ipAddr = Dns.GetHostAddresses(strIP);
            IPAddress ip = ipAddr[0];
            IPEndPoint hostEP = new IPEndPoint(ip, portNum);
            try
            {
                listener.Bind(hostEP);
                listener.Listen(100);
                // Set the event to nonsignaled state. 
                allDone.Reset();
                listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
                // Wait until a connection is made before continuing. 
                allDone.WaitOne();

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }

        public void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue. 
            allDone.Set();
            // Get the socket that handles the client request. 
            listener = (Socket)ar.AsyncState;
            socket = listener.EndAccept(ar);
            //读取客户端内容
            Thread t = new Thread(new ThreadStart(threadrecv));
            t.Start();
            socket.BeginReceive(buf, 0, 1024, 0, new AsyncCallback(ReadCallback), null);
            isConnected = true;
        }

        private void threadrecv()
        {
            socket.BeginReceive(buf, 0, 1024, 0, new AsyncCallback(ReadCallback), socket);
        }

        public void ReadCallback(IAsyncResult ar)
        {
            int byteread = socket.EndReceive(ar);
            x = BitConverter.ToSingle(buf, 12);
            y = BitConverter.ToSingle(buf, 16);
            socket.BeginReceive(buf, 0, 1024, 0, new AsyncCallback(ReadCallback), socket);
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object. 
                Socket handler = (Socket)ar.AsyncState;
                // Complete sending the data to the remote device. 
                int bytesSent = handler.EndSend(ar);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public bool getPoint(ref float x, ref float y)
        {
            x = this.x;
            y = this.y;
            return true;
        }

        public bool close()
        {
            try
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                listener.Close();
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
            byte[] buffer = new byte[50];
            bf.CopyTo(buffer, 0);
            bx.CopyTo(buffer, 4);
            by.CopyTo(buffer, 8);
            bf.CopyTo(buffer, 12);
            bf.CopyTo(buffer, 16);
            socket.BeginSend(buffer, 0, 20, 0, new AsyncCallback(SendCallback), socket);
            return true;
        }

    }
}
