using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Management;
using System.Management.Instrumentation;



/// <summary>
/// 授权文件校验
/// </summary>
public class LicenseChecker
{

    /// <summary>
    /// 校验授权文件
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public bool Check(string filePath, out string message)
    {
        bool result = false;
        message = string.Empty;

        string content = System.IO.File.ReadAllText(filePath);
        string[] items = content.Split(new string[] { "+++++=====+++++" }, StringSplitOptions.RemoveEmptyEntries);

        if (items.Length != 3)
        {
            message = "授权文件格式无法识别";
            return false;
        }

        string json = items[0];
        string sign = items[1];
        string publicKeyXml = items[2];

        var isVerify = Verify(json, sign, publicKeyXml);

        if (isVerify == false)
        {
            message = "授权文件格式校验未通过";
            return false;
        }

        AuthorizeFile af = AuthorizeFile.FromJson(json);

        if (!af.IsEver)
        {
            if (DateTime.Now > af.EndDate || DateTime.Now < af.BeginDate)
            {
                message = "应用授权失败，限制使用时间" + af.BeginDate + "至" + af.EndDate + "，当前授权类型为：" + af.AuthorizeType;

                return false;
            }
        }
        
        if (af.Check() == false)
        {
            message = "应用授权失败，当前授权类型为：" + af.AuthorizeType;

            return false;
        }
        else
        {
            result = true;
        }
        return result;
    }

    bool Verify(byte[] data, byte[] Signature, string PublicKey)
    {
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        //导入公钥，准备验证签名
        rsa.FromXmlString(PublicKey);
        //返回数据验证结果
        return rsa.VerifyData(data, "MD5", Signature);
    }

    public bool Verify(String Text, string SignatureBase64, string PublicKey)
    {
        var data = System.Text.Encoding.UTF8.GetBytes(Text);
        byte[] Signature = Convert.FromBase64String(SignatureBase64);

        return Verify(data, Signature, PublicKey);

    }


}

/// <summary>
/// 授权文件数据格式
/// </summary>
class AuthorizeFile
{

    public string Version { get; set; }
    public bool IsEver { get; set; }
    public DateTime BeginDate { get; set; }

    public DateTime EndDate { get; set; }

    public string AuthorizeType { get; set; }

    public string AuthorizeContent { get; set; }


    public DateTime SignDate { get; set; }

    public bool Check()
    {
        string[] splits = new string[] { ",", "\r\n" };
        string[] items = this.AuthorizeContent.Split(splits, StringSplitOptions.RemoveEmptyEntries);

        if (this.AuthorizeType.Equals("CPU序列号"))
        {   
            string cpuInfo = "";//cpu序列号
            ManagementClass cimobject = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = cimobject.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                cpuInfo = mo.Properties["ProcessorId"].Value.ToString();

                foreach (string item in items)
                {
                    if (cpuInfo.ToLower().Contains(item.ToLower()))
                    {
                        return true;
                    }
                }
            }
        }
        else if (this.AuthorizeType.Equals("硬盘序列号"))
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
            String strHardDiskID = null;//存储磁盘序列号
            foreach (ManagementObject mo in searcher.Get())
            {
                strHardDiskID = mo["SerialNumber"].ToString().Trim();//记录获得的磁盘序列号
                foreach (string item in items)
                {
                    if (strHardDiskID.ToLower().Contains(item.ToLower()))
                    {
                        return true;
                    }
                }
            }
        }
        else if (this.AuthorizeType.Equals("网卡Mac地址"))
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc2 = mc.GetInstances();
            foreach (ManagementObject mo in moc2)
            {
                if ((bool)mo["IPEnabled"] == true)
                {
                    string mac = mo["MacAddress"].ToString();

                    foreach (string item in items)
                    {
                        if (mac.ToLower().Contains(item.ToLower()))
                        {
                            return true;
                        }
                    }
                }
            }
        }

        return false;
    }

    public string ToJson()
    {
        this.SignDate = DateTime.Now;

        return Newtonsoft.Json.JsonConvert.SerializeObject(this);
    }

    public static AuthorizeFile FromJson(string json)
    {
        return Newtonsoft.Json.JsonConvert.DeserializeObject<AuthorizeFile>(json);
    }


}
