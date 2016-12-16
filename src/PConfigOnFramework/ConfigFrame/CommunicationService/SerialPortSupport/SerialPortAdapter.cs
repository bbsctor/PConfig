using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace ConfigFrame.CommunicationService.SerialPortSupport
{
    public class SerialPortAdapter
    {
        private byte[] head;
        public byte[] Head
        {
            get { return head; }
            set { head = value; }
        }

        private byte[] tail;
        public byte[] Tail
        {
            get { return tail; }
            set { tail = value; }
        }

        static SerialPort _serialPort;

        public SerialPortAdapter()
        {
            _serialPort = new SerialPort();
            _serialPort.ReadBufferSize = 4096;
        }

        public void setFrameFormart(byte[] head, byte[] tail)
        {
            this.head = head;
            this.tail = tail;
        }

        public byte[] sendAndReceive(byte[] sendData)
        {
            lock (this)
            {
                byte[] temp = null;
                lock (_serialPort)
                {
                    try
                    {
                        _serialPort.Write(sendData, 0, sendData.Length);

                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                    Console.WriteLine("send: " + BitConverter.ToString(sendData));

                    if (head == null || tail == null)
                    {
                        temp = readRaw();
                    }
                    else
                    {
                        do
                        {
                             temp = readFrame();
                        }
                        while(temp[7] == 0x04);
                    }
                    Console.WriteLine("recv: " + BitConverter.ToString(temp));
                }

                return temp;
            }
            
        }

        public void writeOnly(byte[] data)
        {
            lock (this)
            {
                lock (_serialPort)
                {
                    try
                    {
                        _serialPort.Write(data, 0, data.Length);

                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                    Console.WriteLine("send: " + BitConverter.ToString(data));
                    Console.WriteLine("in write only mode!");
                }
            }
        }

        private byte[] readRaw()
        {
            byte[] buff = new byte[1024];
            int count = 0;
            try
            {
                count = _serialPort.Read(buff, 0, buff.Length);
            }
            catch (TimeoutException e)
            {
                //if (_serialPort.IsOpen == true)
                //{
                //    _serialPort.Close();
                //}
                throw;
            }
            byte[] result = null;
            if (count > 0)
            {
                result = new byte[count];
                System.Array.Copy(buff, result, count);
            }
            return result;
        }

        private byte[] readFrame()
        {
            int iTemp = -1;
            List<byte> dataRecv = new List<byte>();
            Queue<byte> temp = new Queue<byte>();
            bool waitingTail = false;
            bool stop = false;

            while (stop == false)
            {
                try
                {
                    iTemp = _serialPort.ReadByte();
                    temp.Enqueue((byte)iTemp);
                    if (containArray(temp.ToArray(), head.ToArray()) == true)
                    {
                        dataRecv.AddRange(head);
                        temp.Clear();
                        waitingTail = true;
                    }
                    else if (waitingTail == true && containArray(temp.ToArray(), tail.ToArray()) == true)
                    {
                        dataRecv.AddRange(temp.ToArray());
                        stop = true;
                    }
                }
                catch (TimeoutException e)
                {
                    //if (_serialPort.IsOpen == true)
                    //{
                    //    _serialPort.Close();
                    //}
                    throw;
                }
            }
            return dataRecv.ToArray();
        }

        private bool containArray(byte[] a, byte[] b)
        {
            if (a != null && b != null && a.Length >= b.Length)
            {
                byte[] temp = new byte[b.Length];
                System.Array.Copy(a, a.Length - b.Length, temp, 0, temp.Length);
                for (int i = 0; i < temp.Length; i++)
                {
                    if (temp[i] != b[i])
                    {
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }

        public void openSerial()
        {
            if (_serialPort.IsOpen == true)
            {
                lock (_serialPort)
                {
                    _serialPort.Close();
                }
            }
            try
            {
                lock (_serialPort)
                {
                    _serialPort.Open(); 
                }
              
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void closeSerial()
        {
            try
            {
                _serialPort.Close();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void SetPortBaudRate(int p)
        {
            _serialPort.BaudRate = p;
        }
        public void SetPortName(string port)
        {
            _serialPort.PortName = port;
        }

        public void SetReadTimeOut(int mseconds)
        {
            _serialPort.ReadTimeout = mseconds;
        }

        public void SetWriteTimeOut(int mseconds)
        {
            _serialPort.WriteTimeout = mseconds;
        }

        public void SetTimeOut(int mseconds)
        {
            _serialPort.ReadTimeout = mseconds;
            _serialPort.WriteTimeout = mseconds;
        }
    }
}
