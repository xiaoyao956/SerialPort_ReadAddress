using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace HexAll
{
    public class Hex
    {
        static SerialPort sp;
        static List<SerialPort> ports = new List<SerialPort>();
        private static readonly object thisLock = new object();

        public static byte[] Port_Byte(byte[] byteBuffer, string PortName, string BaudRate, string Parity, string DataBits, string StopBits)
        {
                if (PortName == String.Empty || BaudRate == string.Empty || DataBits == string.Empty)
                {
                    MessageBox.Show("参数不能为空");
                    return null;
                }

                if (sp == null || sp.PortName != PortName)
                {
                    sp = new SerialPort
                    {
                        PortName = PortName,
                        BaudRate = int.Parse(BaudRate),
                        DataBits = int.Parse(DataBits)
                    };
                }
                if (Parity == "None")
                {
                    sp.Parity = System.IO.Ports.Parity.None;
                }
                else if (Parity == "Odd")
                {
                    sp.Parity = System.IO.Ports.Parity.Odd;
                }
                else if (Parity == "Even")
                {
                    sp.Parity = System.IO.Ports.Parity.Even;
                }
                else if (Parity == "Mark")
                {
                    sp.Parity = System.IO.Ports.Parity.Mark;
                }
                else if (Parity == "Space")
                {
                    sp.Parity = System.IO.Ports.Parity.Space;
                }
                else
                {
                    MessageBox.Show("奇偶协议错误");
                    return null;
                }

                if (StopBits == "One")
                {
                    sp.StopBits = System.IO.Ports.StopBits.One;
                }
                else if (StopBits == "OnePointFive")
                {
                    sp.StopBits = System.IO.Ports.StopBits.OnePointFive;
                }
                else if (StopBits == "Two")
                {
                    sp.StopBits = System.IO.Ports.StopBits.Two;
                }
                else
                {
                    MessageBox.Show("停止位错误");
                    return null;
                }

                if (sp.IsOpen)
                {
                    sp.Close();
                    Thread.Sleep(100);
                }

                //打开新的串行端口连接
                sp.Open();
                //丢弃来自串行驱动程序的接受缓冲区的数据
                sp.DiscardInBuffer();
                //丢弃来自串行驱动程序的传输缓冲区的数据
                sp.DiscardOutBuffer();

                sp.Write(byteBuffer, 0, byteBuffer.Length);

                string t = string.Empty;
                Byte[] receivedData = new Byte[0];

                while (receivedData.Length == 0)
                {
                    receivedData = new Byte[sp.BytesToRead];        //创建接收字节数组
                    sp.Read(receivedData, 0, receivedData.Length);         //读取数据
                }
                sp.DiscardInBuffer();
                sp.Close();
                return receivedData;

        }

        /// <summary>
        /// 串口通信(字符串)
        /// </summary>
        /// <param name="stringBuffer">发送内容</param>
        /// <param name="PortName">通信端口</param>
        /// <param name="BaudRate">波特率</param>
        /// <param name="Parity">校验位</param>
        /// <param name="DataBits">数据位长度</param>
        /// <param name="StopBits">停止位</param>
        /// <returns></returns>
        public static string Port_String(string stringBuffer, string PortName, string BaudRate, string Parity, string DataBits, string StopBits)
        {
            if (PortName == String.Empty || BaudRate == String.Empty || DataBits == String.Empty)
            {
                MessageBox.Show("参数不能为空");
                return null;
            }
            if (sp != null && sp.PortName != PortName)
            {
                if (sp.IsOpen)
                {
                    sp.Close();
                }
                ports.Add(sp);
                foreach (SerialPort port in ports)
                {
                    if (port.PortName == PortName)
                    {
                        sp = port;
                        continue;
                    }
                    else
                    {
                        sp = null;
                    }
                }
            }
            if (sp == null)
            {
                sp = new SerialPort
                {
                    PortName = PortName,
                    BaudRate = int.Parse(BaudRate),
                    DataBits = int.Parse(DataBits),
                    ReadTimeout = 15000
                };

                if (Parity == "None")
                {
                    sp.Parity = System.IO.Ports.Parity.None;
                }
                else if (Parity == "Odd")
                {
                    sp.Parity = System.IO.Ports.Parity.Odd;
                }
                else if (Parity == "Even")
                {
                    sp.Parity = System.IO.Ports.Parity.Even;
                }
                else if (Parity == "Mark")
                {
                    sp.Parity = System.IO.Ports.Parity.Mark;
                }
                else if (Parity == "Space")
                {
                    sp.Parity = System.IO.Ports.Parity.Space;
                }
                else
                {
                    MessageBox.Show("奇偶协议错误");
                    return null;
                }

                if (StopBits == "One")
                {
                    sp.StopBits = System.IO.Ports.StopBits.One;
                }
                else if (StopBits == "OnePointFive")
                {
                    sp.StopBits = System.IO.Ports.StopBits.OnePointFive;
                }
                else if (StopBits == "Two")
                {
                    sp.StopBits = System.IO.Ports.StopBits.Two;
                }
                else
                {
                    MessageBox.Show("停止位错误");
                    return null;
                }
            }
            //return await Task.Run(() =>
            //{
            try
            {
                if (!sp.IsOpen)
                {
                    //打开新的串行端口连接
                    sp.Open();
                }

                //丢弃来自串行驱动程序的接受缓冲区的数据
                sp.DiscardInBuffer();
                //丢弃来自串行驱动程序的传输缓冲区的数据
                sp.DiscardOutBuffer();

                byte[] byteBuffer = Hex.StringToHex(stringBuffer);

                sp.Write(byteBuffer, 0, byteBuffer.Length);

                string t = string.Empty;
                Byte[] receivedData = new Byte[0];

                int count = 0;
                int SleepTime = 50;

                while (sp.BytesToRead == 0)
                {
                    Thread.Sleep(SleepTime);
                    count++;
                    if (count * SleepTime > sp.ReadTimeout)
                    {
                        sp.DiscardInBuffer();
                        sp.Close();
                        return sp.PortName + " 超时未接收数据";
                    }
                }
                receivedData = new Byte[sp.BytesToRead];        //创建接收字节数组
                sp.Read(receivedData, 0, receivedData.Length);         //读取数据
                sp.DiscardInBuffer();
                sp.Close();
                return Hex.HexToString(receivedData);
            }
            catch (InvalidOperationException)
            {
                return sp.PortName + "线程已被关闭";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            //});

        }

        public static byte[] StringToHex(string strSend)
        {
            try
            {
                string sendBuf = strSend;
                string sendnoNull = sendBuf.Trim();
                string sendNOComma = sendnoNull.Replace(',', ' ');    //去掉英文逗号
                string sendNOComma1 = sendNOComma.Replace('，', ' '); //去掉中文逗号
                string strSendNoComma2 = sendNOComma1.Replace("0x", "");   //去掉0x
                strSendNoComma2.Replace("0X", "");   //去掉0X
                string[] strArray = strSendNoComma2.Split(' ');
                //richTextBox1.Text += strSendNoComma2 + "\r\t";

                int byteBufferLength = strArray.Length;
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i] == "")
                    {
                        byteBufferLength--;
                    }
                }
                // int temp = 0;
                byte[] byteBuffer = new byte[byteBufferLength];
                int ii = 0;
                for (int i = 0; i < strArray.Length; i++)        //对获取的字符做相加运算
                {

                    Byte[] bytesOfStr = Encoding.Default.GetBytes(strArray[i]);

                    int decNum = 0;
                    if (strArray[i] == "")
                    {
                        //ii--;     //加上此句是错误的，下面的continue以延缓了一个ii，不与i同步
                        continue;
                    }
                    else
                    {
                        decNum = Convert.ToInt32(strArray[i], 16); //atrArray[i] == 12时，temp == 18 
                    }

                    try    //防止输错，使其只能输入一个字节的字符
                    {
                        byteBuffer[ii] = Convert.ToByte(decNum);
                        //richTextBox1.Text += byteBuffer[ii] + "\r\t";
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("字节越界，请逐个字节输入！", "Error");
                        //tmSend.Enabled = false;
                        return null;
                    }

                    ii++;
                }

                return byteBuffer;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error1");
                return null;
            }
        }

        public static string HexToString(byte[] receivedData)
        {
            string strRcv = null;
            //int decNum = 0;//存储十进制
            for (int i = 0; i < receivedData.Length; i++)
            {

                strRcv += receivedData[i].ToString("X2");  //16进制显示
                if (i < receivedData.Length - 1)
                {
                    strRcv += " ";
                }
            }
            return strRcv;
        }

    }
}
