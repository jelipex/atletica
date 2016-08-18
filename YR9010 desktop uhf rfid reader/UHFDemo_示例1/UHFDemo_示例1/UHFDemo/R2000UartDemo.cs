using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;

namespace UHFDemo
{
    public partial class R2000UartDemo : Form
    {
        private Reader.ReaderMethod reader;
        private ReaderSetting m_curSetting = new ReaderSetting();
        private InventoryBuffer m_curInventoryBuffer = new InventoryBuffer();
        private OperateTagBuffer m_curOperateTagBuffer = new OperateTagBuffer();
        private OperateTagISO18000Buffer m_curOperateTagISO18000Buffer = new OperateTagISO18000Buffer();

        //使用List来存放实时标签信息
        private List<RealTimeTagData> RealTimeTagDataList = new List<RealTimeTagData>();

        //盘存操作前，需要先设置工作天线，用于标识当前是否在执行盘存操作
        private bool m_bInventory = false;
        //标识是否统计命令执行时间，当前仅盘存命令需要统计时间
        private bool m_bReckonTime = false;
        //实时盘存锁定操作
        private bool m_bLockTab = false;
        //ISO18000标签连续盘存标识
        private bool m_bContinue = false;
        //是否显示串口监控数据
        private bool m_bDisplayLog = false;
        //记录ISO18000标签循环写入次数
        private int m_nLoopTimes = 0;
        //记录ISO18000标签写入字符数
        private int m_nBytes = 0;
        //记录ISO18000标签已经循环写入次数
        private int m_nLoopedTimes = 0;
        //实时盘存次数
        private int m_nTotal = 0;
        //列表更新频率
        private int m_nRealRate = 20;
        //记录快速轮询天线参数
        private byte[] m_btAryData=new byte[10];
        //记录快速轮询总次数
        private int m_nSwitchTotal = 0;
        private int m_nSwitchTime = 0;

        public R2000UartDemo()
        {
            InitializeComponent();
        }

        private void R2000UartDemo_Load(object sender, EventArgs e)
        {
            //初始化访问读写器实例
            reader = new Reader.ReaderMethod();

            //回调函数
            reader.AnalyCallback = AnalyData;
            reader.ReceiveCallback = ReceiveData;
            reader.SendCallback = SendData;

            //设置界面元素有效性
            gbRS232.Enabled = false;
            gbTcpIp.Enabled = false;
            SetFormEnable(false);
           

            //初始化连接读写器默认配置
            cmbComPort.SelectedIndex = 0;
            cmbBaudrate.SelectedIndex = 1;
            ipIpServer.IpAddressStr = "192.168.0.178";
            txtTcpPort.Text = "4001";
     
           
            
        }

        private void ReceiveData(byte[] btAryReceiveData)
        {
            if (m_bDisplayLog)
            {
                string strLog = CCommondMethod.ByteArrayToString(btAryReceiveData, 0, btAryReceiveData.Length);

               
            }            
        }

        private void SendData(byte[] btArySendData)
        {
            if (m_bDisplayLog)
            {
                string strLog = CCommondMethod.ByteArrayToString(btArySendData, 0, btArySendData.Length);

               
            }            
        }

        private void AnalyData(Reader.MessageTran msgTran)
        {
            if (msgTran.PacketType != 0xA0)
            {
                return;
            }
            switch(msgTran.Cmd)
            {
                case 0x81:
                    ProcessReadTag(msgTran);
                    break;
                case 0x89:
                    ProcessInventoryReal(msgTran);
                    break;
                default:
                    break;
            }
        }

        

        private void SetFormEnable(bool bIsEnable)
        {
                      

            btnResetReader.Enabled = bIsEnable;
          
        }

        private void btnConnectRs232_Click(object sender, EventArgs e)
        {
            //处理串口连接读写器
            string strException = string.Empty;
            string strComPort = cmbComPort.Text;
            int nBaudrate=Convert.ToInt32(cmbBaudrate.Text);

            int nRet = reader.OpenCom(strComPort, nBaudrate, out strException);
            if (nRet != 0)
            {
                string strLog = "连接读写器失败，失败原因： " + strException;

                WriteLog(lrtxtLog, strLog, 1);
                return;
            }
            else
            {
                string strLog = "连接读写器 " + strComPort + "@" + nBaudrate.ToString();
                WriteLog(lrtxtLog, strLog, 0);
               
            }
            
            //处理界面元素是否有效
            SetFormEnable(true);

            
            btnConnectRs232.Enabled = false;
            btnDisconnectRs232.Enabled = true;

            //设置按钮字体颜色
            btnConnectRs232.ForeColor = Color.Black;
            btnDisconnectRs232.ForeColor = Color.Indigo;
           
        }

        private void btnDisconnectRs232_Click(object sender, EventArgs e)
        {
            //处理串口断开连接读写器
            reader.CloseCom();

            //处理界面元素是否有效
            SetFormEnable(false);
            btnConnectRs232.Enabled = true;
            btnDisconnectRs232.Enabled = false;

            //设置按钮字体颜色
            btnConnectRs232.ForeColor = Color.Indigo;
            btnDisconnectRs232.ForeColor = Color.Black;
           
        }

        private void btnConnectTcp_Click(object sender, EventArgs e)
        {
            try
            {
                //处理Tcp连接读写器
                string strException = string.Empty;
                IPAddress ipAddress = IPAddress.Parse(ipIpServer.IpAddressStr);
                int nPort = Convert.ToInt32(txtTcpPort.Text);

                int nRet = reader.ConnectServer(ipAddress,nPort,out strException);
                if (nRet != 0)
                {
                    string strLog = "连接读写器失败，失败原因： " + strException;

                    WriteLog(lrtxtLog, strLog, 1);
                    return;
                }
                else
                {
                    string strLog = "连接读写器 " + ipIpServer.IpAddressStr + "@" + nPort.ToString();
                    WriteLog(lrtxtLog, strLog, 0);
                   
                }

                //处理界面元素是否有效
                SetFormEnable(true);
                btnConnectTcp.Enabled = false;
                btnDisconnectTcp.Enabled = true;

                //设置按钮字体颜色
                btnConnectTcp.ForeColor = Color.Black;
                btnDisconnectTcp.ForeColor = Color.Indigo;
              
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnDisconnectTcp_Click(object sender, EventArgs e)
        {
            //处理断开Tcp连接读写器
            reader.SignOut();

            //处理界面元素是否有效
            SetFormEnable(false);
            btnConnectTcp.Enabled = true;
            btnDisconnectTcp.Enabled = false;

            //设置按钮字体颜色
            btnConnectTcp.ForeColor = Color.Indigo;
            btnDisconnectTcp.ForeColor = Color.Black;
           
        }
        private void rdbTcpIp_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTcpIp.Checked)
            {
                gbTcpIp.Enabled = true;
                btnDisconnectTcp.Enabled = false;

                //设置按钮字体颜色
                btnConnectTcp.ForeColor = Color.Indigo;


                gbRS232.Enabled = false;
            }
        }

        private void rdbRS232_Click(object sender, EventArgs e)
        {
            if (rdbRS232.Checked)
            {
                gbRS232.Enabled = true;
                btnDisconnectRs232.Enabled = false;

                //设置按钮字体颜色
                btnConnectRs232.ForeColor = Color.Indigo;

                gbTcpIp.Enabled = false;
            }
        }

        private delegate void WriteLogUnSafe(CustomControl.LogRichTextBox logRichTxt, string strLog, int nType);
        private void WriteLog(CustomControl.LogRichTextBox logRichTxt, string strLog, int nType)
        {
            if (this.InvokeRequired)
            {
                WriteLogUnSafe InvokeWriteLog = new WriteLogUnSafe(WriteLog);
                this.Invoke(InvokeWriteLog, new object[] { logRichTxt, strLog, nType });
            }
            else
            {
                if (nType == 0)
                {
                    logRichTxt.AppendTextEx(strLog, Color.Indigo);
                }
                else
                {
                    logRichTxt.AppendTextEx(strLog, Color.Red);
                }



                logRichTxt.Select(logRichTxt.TextLength, 0);
                logRichTxt.ScrollToCaret();
            }
        }

        private void rdbRS232_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbRS232.Checked)
            {
                gbRS232.Enabled = true;
                btnDisconnectRs232.Enabled = false;

                //设置按钮字体颜色
                btnConnectRs232.ForeColor = Color.Indigo;

                gbTcpIp.Enabled = false;
            }
        }

        private void lrtxtLog_DoubleClick_1(object sender, EventArgs e)
        {
            lrtxtLog.Text = "";
        }

        private void btnResetReader_Click(object sender, EventArgs e)
        {
            int nRet = reader.Reset(m_curSetting.btReadId);
            if (nRet != 0)
            {
                string strLog = "复位读写器失败";
              
            }
            else
            {
                string strLog = "复位读写器";
               
            }
        }

        private string GetFreqString(byte btFreq)
        {
            string strFreq = string.Empty;

            if (m_curSetting.btRegion == 4)
            {
                float nExtraFrequency = btFreq * m_curSetting.btUserDefineFrequencyInterval * 10;
                float nstartFrequency = ((float)m_curSetting.nUserDefineStartFrequency) / 1000;
                float nStart = nstartFrequency + nExtraFrequency / 1000;
                string strTemp = nStart.ToString("0.000");
                return strTemp;
            }
            else
            {
                if (btFreq < 0x07)
                {
                    float nStart = 865.00f + Convert.ToInt32(btFreq) * 0.5f;

                    string strTemp = nStart.ToString("0.00");

                    return strTemp;
                }
                else
                {
                    float nStart = 902.00f + (Convert.ToInt32(btFreq) - 7) * 0.5f;

                    string strTemp = nStart.ToString("0.00");

                    return strTemp;
                }
            }
        }

        private void ProcessReadTag(Reader.MessageTran msgTran)
        {
            string strCmd = "读标签";
            string strErrorCode = string.Empty;
            if (msgTran.AryData.Length == 1)
            {
                strErrorCode = CCommondMethod.FormatErrorCode(msgTran.AryData[0]);
                string strLog = strCmd + "失败，失败原因： " + strErrorCode;
                m_curSetting.btRealInventoryFlag = 100; //读写器返回错误信息

                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                RealTimeTagData tagData = new RealTimeTagData();
                int nLen = msgTran.AryData.Length;
                int nDataLen = Convert.ToInt32(msgTran.AryData[nLen - 3]);
                int nEpcLen = Convert.ToInt32(msgTran.AryData[2]) - nDataLen - 4;

                string strPC = CCommondMethod.ByteArrayToString(msgTran.AryData, 3, 2);
                string strEPC = CCommondMethod.ByteArrayToString(msgTran.AryData, 5, nEpcLen);
                string strCRC = CCommondMethod.ByteArrayToString(msgTran.AryData, 5 + nEpcLen, 2);
                string strData = CCommondMethod.ByteArrayToString(msgTran.AryData, 7 + nEpcLen, nDataLen);

                byte byTemp = msgTran.AryData[nLen - 2];
                byte byAntId = (byte)((byTemp & 0x03) + 1);


                tagData.strEpc = strEPC;
                tagData.strPc = strPC;
                tagData.strTid = strData;
                tagData.btAntId = byAntId;

                RealTimeTagDataList.Add(tagData);

                int nReaddataCount = msgTran.AryData[0] * 255 + msgTran.AryData[1]; //数据总数量
                if (RealTimeTagDataList.Count == nReaddataCount)  //收到所有的数据
                {
                    m_curSetting.btRealInventoryFlag = 1; //读写器返回错误信息
                }
            }
        }
        private void ProcessInventoryReal(Reader.MessageTran msgTran)
        {
            string strCmd = "";
            strCmd = "实时盘存";
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1) //收到错误信息数据包
            {
                strErrorCode = CCommondMethod.FormatErrorCode(msgTran.AryData[0]);
                string strLog = strCmd + "失败，失败原因： " + strErrorCode;
                m_curSetting.btRealInventoryFlag = 100; //读写器返回盘存错误
                WriteLog(lrtxtLog, strLog, 1);

              
            }
            else if (msgTran.AryData.Length == 7) //收到命令结束数据包
            {
                m_curInventoryBuffer.nReadRate = Convert.ToInt32(msgTran.AryData[1]) * 256 + Convert.ToInt32(msgTran.AryData[2]);
                m_curInventoryBuffer.nDataCount = Convert.ToInt32(msgTran.AryData[3]) * 256 * 256 * 256 + Convert.ToInt32(msgTran.AryData[4]) * 256 * 256 + Convert.ToInt32(msgTran.AryData[5]) * 256 + Convert.ToInt32(msgTran.AryData[6]);
                m_curSetting.btRealInventoryFlag = 1; //成功收到盘存命令结束数据包
                WriteLog(lrtxtLog, strCmd, 0);
            }
            else //收到实时标签数据信息
            {
                m_nTotal++;
                int nLength = msgTran.AryData.Length;
                int nEpcLength = nLength - 4;
                RealTimeTagData tagData = new RealTimeTagData();

                string strEPC = CCommondMethod.ByteArrayToString(msgTran.AryData, 3, nEpcLength);
                string strPC = CCommondMethod.ByteArrayToString(msgTran.AryData, 1, 2);
                string strRSSI = (msgTran.AryData[nLength - 1] - 129).ToString() + " dBm";
                byte btTemp = msgTran.AryData[0];
                byte btAntId = (byte)((btTemp & 0x03) + 1);
                byte btFreq = (byte)(btTemp >> 2);
                string strFreq = GetFreqString(btFreq) + " MHz";
            

                tagData.strEpc = strEPC;
                tagData.strPc = strPC;
                tagData.strRssi = strRSSI;
                tagData.strCarrierFrequency = strFreq;
                tagData.btAntId = btAntId;
                
                RealTimeTagDataList.Add(tagData);
        
           }
            
        }

        


        //实时盘存标签函数
        //-----------输入参数-------------- 
        //btReaderId:读写器地址，0xff为公共地址 
        //btRepeat：每命令重复盘存次数，0xff为快速模式。
        //btTimeOut：超时控制，单位是秒，如果在此时间内读写器未响应或命令未执行完毕则返回超时 
        //---------------------------------
        //-----------输出参数--------------
        // 0：成功盘存但未盘存到标签
        // 1：成功盘存并盘存到标签
        // -1：盘存过程出现错误
        // -2：盘存超时
        //---------------------------------
        //注意：在此函数及其调用的函数中不要更新界面，因为界面线程正在等待此函数返回。
        private int realTimeInventory(byte btReaderId, byte btRepeat, byte btTimeOut)
        {
            DateTime startTime;
            TimeSpan timeOutControl;

            //这里使用等待数据的方法，数据全部接收完毕后再进行处理
            m_curSetting.btRealInventoryFlag = 0;
            RealTimeTagDataList.Clear();  //清空标签信息表
            reader.InventoryReal(255, 1); // 先发送实时盘存命令，用0xFF公共地址，每条命令重复盘存一次

            startTime = DateTime.Now;

            while (m_curSetting.btRealInventoryFlag == 0) //等待读写器返回数据完成，若超时，返回超时标志
            {
                timeOutControl = DateTime.Now - startTime;
                if (timeOutControl.TotalMilliseconds > btTimeOut * 1000)//超时返回 
                {
                    return -2;
                }
            }

            if (m_curSetting.btRealInventoryFlag == 1) //命令执行成功
            {
                if (RealTimeTagDataList.Count > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            if (m_curSetting.btRealInventoryFlag == 100) //命令执行失败
            {
                return -1;
            }
            return 0;
        }

        //读标签TID函数
        //-----------输入参数-------------- 
        //btReaderId:读写器地址，0xff为公共地址 
        //btTidLength：TID长度，单位字节（byte)
        //btTimeOut：超时控制，单位是秒，如果在此时间内读写器未响应或命令未执行完毕则返回超时 
        //---------------------------------
        //-----------输出参数--------------
        // 1：成功读到标签TID
        // -1：盘存过程出现错误
        // -2：盘存超时
        //---------------------------------
        //注意：在此函数及其调用的函数中不要更新界面，因为界面线程正在等待此函数返回。
        private int readTid(byte btReaderId, byte btTidLength, byte btTimeOut)
        {
            DateTime startTime;
            TimeSpan timeOutControl;
            byte btDataLengthWord = 0;

            btDataLengthWord = (byte)(btTidLength / 2); //1 word = 2 bytes

            //这里使用等待数据的方法，数据全部接收完毕后再进行处理
            m_curSetting.btRealInventoryFlag = 0;
            RealTimeTagDataList.Clear();  //清空标签信息表
            reader.ReadTag(255,2,0,btDataLengthWord); // 先发送实时盘存命令，用0xFF公共地址，每条命令重复盘存一次

            startTime = DateTime.Now;

            while (m_curSetting.btRealInventoryFlag == 0) //等待读写器返回数据完成，若超时，返回超时标志
            {
                timeOutControl = DateTime.Now - startTime;
                if (timeOutControl.TotalMilliseconds > btTimeOut * 1000)//超时返回 
                {
                    return -2;
                }
            }

            if (m_curSetting.btRealInventoryFlag == 1) //命令执行成功
            {
                return 1;
               
            }
            if (m_curSetting.btRealInventoryFlag == 100) //命令执行失败
            {
                return -1;
            }
            return 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int nReturnValue = 0;
            string tagInfo = "";
            listBox1.Items.Clear();


            nReturnValue = realTimeInventory(255, 255, 5);  //公用读写器地址，快速盘存模式，超时控制5秒

            if (nReturnValue == 1)
            {
                for (int i = 0; i < RealTimeTagDataList.Count; i++)
                {
                    tagInfo = "天线" + RealTimeTagDataList[i].btAntId.ToString() + "    " + RealTimeTagDataList[i].strEpc + "    " + RealTimeTagDataList[i].strCarrierFrequency + "    " + RealTimeTagDataList[i].strRssi;
                    listBox1.Items.Add(tagInfo);
               
                }
            }
            else if (nReturnValue == 0)
            {
                MessageBox.Show("成功执行命令但没有盘存到标签");
            }
            else if (nReturnValue == -1)
            {
                MessageBox.Show("盘存出现错误");
            }
            else if (nReturnValue == -2)
            {
                MessageBox.Show("盘存超时");
            }
            else
            {
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int nReturnValue = 0;
            string tagInfo = "";
            listBox1.Items.Clear();
            nReturnValue = readTid(255, 8, 5);
            if (nReturnValue == 1)
            {
                for (int i = 0; i < RealTimeTagDataList.Count; i++)
                {
                    tagInfo = "天线" + RealTimeTagDataList[i].btAntId.ToString() + "    " + RealTimeTagDataList[i].strEpc + "    "  + RealTimeTagDataList[i].strTid;
                    listBox1.Items.Add(tagInfo);

                }
            }
            else if (nReturnValue == -1)
            {
                MessageBox.Show("未读到TID或其它错误");
            }
            else if (nReturnValue == -2)
            {
                MessageBox.Show("读标签超时");
            }
            else
            {
                return;
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

      
    
   
    }
}
