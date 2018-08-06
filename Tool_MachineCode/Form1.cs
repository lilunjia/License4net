using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Management.Instrumentation;

namespace Tool_MachineCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string AuthorizeType = cbxAuthorizeType.Text;
            if (string.IsNullOrWhiteSpace(cbxAuthorizeType.Text))
                return;
            
            txtContent.Text = string.Empty;

            if (AuthorizeType.Equals("CPU序列号"))
            {
                string cpuInfo = "";//cpu序列号
                ManagementClass cimobject = new ManagementClass("Win32_Processor");
                ManagementObjectCollection moc = cimobject.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
                    txtContent.Text += cpuInfo;
                    txtContent.Text += "\r\n";
                }
            }
            else if (AuthorizeType.Equals("硬盘序列号"))
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
                String strHardDiskID = null;//存储磁盘序列号
                foreach (ManagementObject mo in searcher.Get())
                {
                    strHardDiskID = mo["SerialNumber"].ToString().Trim();//记录获得的磁盘序列号
                    txtContent.Text += strHardDiskID;
                    txtContent.Text += "\r\n";
                }
            }
            else if (AuthorizeType.Equals("网卡Mac地址"))
            {
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc2 = mc.GetInstances();
                foreach (ManagementObject mo in moc2)
                {
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        txtContent.Text += mo["MacAddress"].ToString();
                        txtContent.Text += "\r\n";
                    }
                }
            }

        }
    }
}
