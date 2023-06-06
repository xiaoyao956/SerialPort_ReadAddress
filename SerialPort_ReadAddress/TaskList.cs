using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialPort_ReadAddress
{
    public class TaskList
    {
        private static string _PortName;
        public string PortName { get { return _PortName; } set { _PortName = value; } }

        private string _BaudRate;
        public string BaudRate { get { return _BaudRate; } set { _BaudRate = value; } }

        private string _Parity;
        public string Parity { get { return _Parity; } set { _Parity = value; } }

        private string _DataBits;
        public string DataBits { get { return _DataBits; } set { _DataBits = value; } }

        private string _StopBits;
        public string StopBits { get { return _StopBits; } set { _StopBits = value; } }

        private string _text;
        public string text { get { return _text; } set { _text = value; } }
        //private SerialPort _sp;
        //public SerialPort sp { get { return _sp; } set { _sp = value; } }
    }

    public class TaskListClass
    {
        public static List<TaskList> taskList { get; set; }
    }

    public class Parameter
    {
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _PortName;
        public string PortName { get { return _PortName; } set { _PortName = value; } }

        private string _BaudRate;
        public string BaudRate { get { return _BaudRate; } set { _BaudRate = value; } }

        private string _Parity;
        public string Parity { get { return _Parity; } set { _Parity = value; } }

        private string _DataBits;
        public string DataBits { get { return _DataBits; } set { _DataBits = value; } }

        private string _StopBits;
        public string StopBits { get { return _StopBits; } set { _StopBits = value; } }

        private string _WirtPost;
        public string WirtPost { get { return _WirtPost; } set { _WirtPost = value; } }

        private string _ReadPost;
        public string ReadPost { get { return _ReadPost; } set { _ReadPost = value; } }
    }

    public class ParameterList
    {
        public static List<Parameter> Parameters { get; set; }
    }
}
