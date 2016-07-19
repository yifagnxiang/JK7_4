using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Drawing;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_public
{
    public static class Tool
    {
        /// <summary>取当前主机地址
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetHostUrl()
        {
            string url = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port + "/";
            return url;
        }

        /// <summary>返回发送短信的状态说明
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetMobileMsmStatus(string str)
        {
            string s = "";
            switch (str)
            {
                case "-1":
                    s = "没有该用户账户";
                    break;
                case "-2":
                    s = "密钥不正确（不是用户密码）";
                    break;
                case "-3":
                    s = "短信数量不足";
                    break;
                case "-11":
                    s = "该用户被禁用";
                    break;
                case "-14":
                    s = "短信内容出现非法字符";
                    break;
                case "-4":
                    s = "手机号格式不正确";
                    break;
                case "-41":
                    s = "手机号码为空";
                    break;
                case "-42":
                    s = "短信内容为空";
                    break;
                default:
                    s = "成功发送" + str + "条短信";
                    break;
            }
            return s;
        }

        /// <summary>发送手机短信
        /// 
        /// </summary>
        /// <param name="mobile">手机号码,多个手机号以,号相隔</param>
        /// <param name="body">短信内容</param>
        public static bool SendMobileMsm(string mobile, string body)
        {
            string url = "http://utf8.sms.webchinese.cn/?Uid=lovemeok120&Key=8135d548c59583602ef9&smsMob=" + mobile + "&smsText=" + body;
            string targeturl = url.Trim();
            try
            {
                bool result = false;
                HttpWebRequest hr = (HttpWebRequest)WebRequest.Create(targeturl);
                hr.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
                hr.Method = "GET";
                hr.Timeout = 30 * 60 * 1000;
                WebResponse hs = hr.GetResponse();
                Stream sr = hs.GetResponseStream();
                StreamReader ser = new StreamReader(sr, Encoding.Default);
                string content = ser.ReadToEnd();
                if (content.Substring(0, 1) == "0")
                {
                    result = true;
                }
                else
                {
                    if (content.Substring(0, 1) == "2") //余额不足
                    {
                        //"手机短信余额不足";
                    }
                    else
                    {
                        //短信发送失败的其他原因，请参看官方API
                    }
                    result = false;
                }

                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 发送手机短信(北京盛世云商网络技术)
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="pwd">用户密码</param>
        /// <param name="mobile">手机号码,多个手机号以,号相隔</param>
        /// <param name="body">短信内容</param>
        /// <returns></returns>
        public static bool SendeNsms(string username,string pwd,string mobile, string body)
        {
            long epoch = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;//时间戳
            string md5pwd = Md5(username + pwd + epoch);//加密后的字符串
            string url = "http://sms.ensms.com:8080/sendsms/?username="+username+"&pwd="+md5pwd+"&msg="+body+"&mobiles="+mobile+"&dt="+epoch+"&code=";
            string targeturl = url.Trim();
            try
            {
                bool result = false;
                HttpWebRequest hr = (HttpWebRequest)WebRequest.Create(targeturl);
                hr.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
                hr.Method = "GET";
                hr.Timeout = 30 * 60 * 1000;
                WebResponse hs = hr.GetResponse();
                Stream sr = hs.GetResponseStream();
                StreamReader ser = new StreamReader(sr, Encoding.Default);
                string content = ser.ReadToEnd();
                if (content.Substring(0, 1) == "0")
                {
                    result = true;
                }
                else
                {
                    if (content.Substring(0, 1) == "2") //余额不足
                    {
                        //"手机短信余额不足";
                    }
                    else
                    {
                        //短信发送失败的其他原因，请参看官方API
                    }
                    result = false;
                }

                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>发送邮件
        /// 
        /// </summary>
        /// <param name="Subject">主题</param>
        /// <param name="body">正文</param>
        public static void MailMessage(string Subject, string body)
        {
            MailMessage mailObj = new MailMessage();
            mailObj.From = new MailAddress("hengyangxieyue@sina.com"); //发送人邮箱地址
            mailObj.To.Add("zyg853771@sina.com");   //收件人邮箱地址
            mailObj.Subject = Subject;    //主题
            mailObj.Body = body;    //正文
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.sina.com";         //smtp服务器名称
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new NetworkCredential("发送人邮箱登录名", "发送人邮箱密码");  //发送人的登录名和密码
            smtp.Send(mailObj);
        }




        /// <summary>  实现数据的四舍五入法　　
        /// 
        /// </summary>    
        /// <param name="v">要进行处理的数据</param>   
        /// <param name="x">保留的小数位数</param>   
        /// <returns>四舍五入后的结果</returns>
        public static double Round(double v, int x)
        {
            bool isNegative = false;
            //如果是负数        
            if (v < 0)
            {
                isNegative = true;
                v = -v;
            }
            int value = 1;
            for (int i = 1; i <= x; i++)
            {
                value = value * 10;
            }
            double Int = Math.Round(v * value + 0.5, 0);
            v = Int / value;
            if (isNegative)
            {
                v = -v;
            }
            return v;
        }

        /// <summary>写Cookie
        /// 
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="content">内容</param>
        /// <param name="day">失效小时数</param>
        public static void SetCookie(string key, string content, int hours)
        {
            HttpCookie cookie = HttpContext.Current.Response.Cookies[key];
            if (cookie != null)
            {
                cookie.Value = content;
                cookie.Expires = DateTime.Now.AddHours(hours);
            }
            else
            {
                HttpCookie nCookie = new HttpCookie(key, content) { Expires = DateTime.Now.AddHours(hours) };
                HttpContext.Current.Response.Cookies.Add(nCookie);
            }

        }

        /// <summary>清除Cookie
        /// 
        /// </summary>
        /// <param name="key">键</param>
        public static void ClearCookie(string key)
        {
            HttpCookie cookie = HttpContext.Current.Response.Cookies[key];
            if (cookie != null)
            {
                HttpCookie nCookie = new HttpCookie(key) { Expires = DateTime.Now.AddDays(-1) };
                HttpContext.Current.Response.Cookies.Add(nCookie);
            }
        }

        /// <summary>获取客户端的IP，可以取到代理后的IP
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetClientIp()
        {
            string result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(result))
            {
                //可能有代理  
                if (result.IndexOf(".", System.StringComparison.Ordinal) == -1)
                    result = null;
                else
                {
                    if (result.IndexOf(",", System.StringComparison.Ordinal) != -1)
                    {
                        //有“,”，估计多个代理。取第一个不是内网的IP。  
                        result = result.Replace("  ", "").Replace("'", "");
                        string[] temparyip = result.Split(",;".ToCharArray());
                        foreach (string t in temparyip)
                        {
                            if (IsIpAddress(t)
                                && t.Substring(0, 3) != "10."
                                && t.Substring(0, 7) != "192.168"
                                && t.Substring(0, 7) != "172.16.")
                            {
                                return t;        //找到不是内网的地址  
                            }
                        }
                    }
                    else if (IsIpAddress(result))  //代理即是IP格式  
                        return result;
                    else
                        result = null;        //代理中的内容  非IP，取IP  
                }
            }
            if (string.IsNullOrEmpty(result))
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            if (string.IsNullOrEmpty(result))
                result = HttpContext.Current.Request.UserHostAddress;
            return result;
        }

        ///  <summary>判断是否是IP地址格式  0.0.0.0
        ///  
        ///  </summary>
        ///  <param  name="str">待判断的IP地址</param>
        ///  <returns>true  or  false</returns>
        public static bool IsIpAddress(string str)
        {
            if (string.IsNullOrEmpty(str) || str.Length < 7 || str.Length > 15) return false;

            const string regformat = @"^d{1,3}[.]d{1,3}[.]d{1,3}[.]d{1,3}$";

            Regex regex = new Regex(regformat, RegexOptions.IgnoreCase);
            return regex.IsMatch(str);
        }

        /// <summary>加密
        /// 
        /// </summary>
        /// <param name="str">待加密字符串</param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        public static string Encode(string str, string key)
        {
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            provider.Key = Encoding.ASCII.GetBytes(key.Substring(0, 8));
            provider.IV = Encoding.ASCII.GetBytes(key.Substring(0, 8));
            byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(str);
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(), CryptoStreamMode.Write);
            stream2.Write(bytes, 0, bytes.Length);
            stream2.FlushFinalBlock();
            StringBuilder builder = new StringBuilder();
            foreach (byte num in stream.ToArray())
            {
                builder.AppendFormat("{0:X2}", num);
            }
            stream.Close();
            return builder.ToString();
        }
        /// <summary>解密
        /// 
        /// </summary>
        /// <param name="str">待解密字符串</param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        public static string Decode(string str, string key)
        {
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            provider.Key = Encoding.ASCII.GetBytes(key.Substring(0, 8));
            provider.IV = Encoding.ASCII.GetBytes(key.Substring(0, 8));
            byte[] buffer = new byte[str.Length / 2];
            for (int i = 0; i < (str.Length / 2); i++)
            {
                int num2 = Convert.ToInt32(str.Substring(i * 2, 2), 0x10);
                buffer[i] = (byte)num2;
            }
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(), CryptoStreamMode.Write);
            stream2.Write(buffer, 0, buffer.Length);
            stream2.FlushFinalBlock();
            stream.Close();
            return Encoding.GetEncoding("GB2312").GetString(stream.ToArray());
        }

        ///<summary>MD5加密字符串
        /// 
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <returns></returns>
        public static string Md5(string str)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5"); ;
        }

        /// <summary>过滤SQL和HTML敏感字符
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetSafeSqlandHtml(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;
            str = Regex.Replace(str, @"<applet[^>]*?>.*?</applet>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<body[^>]*?>.*?</body>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<embed[^>]*?>.*?</embed>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<frame[^>]*?>.*?</frame>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<frameset[^>]*?>.*?</frameset>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<html[^>]*?>.*?</html>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<iframe[^>]*?>.*?</iframe>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<style[^>]*?>.*?</style>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<layer[^>]*?>.*?</layer>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<link[^>]*?>.*?</link>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<ilayer[^>]*?>.*?</ilayer>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<meta[^>]*?>.*?</meta>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<object[^>]*?>.*?</object>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"-->", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<!--.*", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "eXeC", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "VaRcHaR", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "dEcLaRe", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @";", string.Empty);
            str = Regex.Replace(str, @"'", string.Empty);
            str = Regex.Replace(str, @"&", string.Empty);
            str = Regex.Replace(str, @"%20", string.Empty);
            str = Regex.Replace(str, @"--", string.Empty);
            //str = Regex.Replace(str, @"==", string.Empty);
            str = Regex.Replace(str, @"<", string.Empty);
            str = Regex.Replace(str, @">", string.Empty);

            return str;
        }

        /// <summary>过滤SQL和HTML敏感字符
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetSafeSql(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;
            str = Regex.Replace(str, "eXeC", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "VaRcHaR", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "dEcLaRe", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @";", string.Empty);
            str = Regex.Replace(str, @"'", string.Empty);
            str = Regex.Replace(str, @"&", string.Empty);
            str = Regex.Replace(str, @"%20", string.Empty);
            str = Regex.Replace(str, @"--", string.Empty);
            //str = Regex.Replace(str, @"==", string.Empty);
            str = Regex.Replace(str, @"<", string.Empty);
            str = Regex.Replace(str, @">", string.Empty);

            return str;
        }

        /// <summary>清除HTML标签
        /// 
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        public static string StripHTML(string strHtml)
        {
            string[] aryReg ={ 
                      @"<script[^>]*?>.*?</script>", 
                      @"<(\/\s*)?!?((\w+:)?\w+)(\w+(\s*=?\s*(([""'])(\\[""'tbnr]|[^\7])*?\7|\w+)|.{0})|\s)*?(\/\s*)?>", 
                      @"([\r\n])[\s]+", 
                      @"&(quot|#34);", 
                      @"&(amp|#38);", 
                      @"&(lt|#60);", 
                      @"&(gt|#62);",    
                      @"&(nbsp|#160);",    
                      @"&(iexcl|#161);", 
                      @"&(cent|#162);", 
                      @"&(pound|#163);", 
                      @"&(copy|#169);", 
                      @"&#(\d+);", 
                      @"-->", 
                      @"<!--.*\n" 
                    };

            string[] aryRep =   { 
                        "", 
                        "", 
                        "", 
                        "\"", 
                        "&", 
                        "<", 
                        ">", 
                        "   ", 
                        "\xa1",//chr(161), 
                        "\xa2",//chr(162), 
                        "\xa3",//chr(163), 
                        "\xa9",//chr(169), 
                        "", 
                        "\r\n", 
                        "" 
                      };

            string newReg = aryReg[0];
            string strOutput = strHtml;
            for (int i = 0; i < aryReg.Length; i++)
            {
                Regex regex = new Regex(aryReg[i], RegexOptions.IgnoreCase);
                strOutput = regex.Replace(strOutput, aryRep[i]);
            }
            strOutput.Replace("<", "");
            strOutput.Replace(">", "");
            strOutput.Replace("\r\n", "");
            return strOutput;
        }

        /// <summary>获得当前页面客户端的IP
        /// 
        /// </summary>
        /// <returns>当前页面客户端的IP</returns>
        public static string GetIP()
        {
            string result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            if (string.IsNullOrEmpty(result))
                result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(result))
                result = HttpContext.Current.Request.UserHostAddress;

            if (string.IsNullOrEmpty(result) || !IsIP(result))
                return "127.0.0.1";

            return result;
        }

        /// <summary>是否为ip
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        /// <summary>从字符串的指定位置截取指定长度的子字符串
        /// 
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <param name="startIndex">子字符串的起始位置</param>
        /// <param name="length">子字符串的长度</param>
        /// <param name="pathStr">截取后接字符串</param>
        /// <returns>子字符串</returns>
        public static string CutString(string str, int startIndex, int length, string pathStr)
        {
            if (startIndex >= 0)
            {
                if (length < 0)
                {
                    length = length * -1;
                    if (startIndex - length < 0)
                    {
                        length = startIndex;
                        startIndex = 0;
                    }
                    else
                        startIndex = startIndex - length;
                }

                if (startIndex > str.Length)
                    return "";
            }
            else
            {
                if (length < 0)
                    return "";
                else
                {
                    if (length + startIndex > 0)
                    {
                        length = length + startIndex;
                        startIndex = 0;
                    }
                    else
                        return "";
                }
            }
            if (str.Length - startIndex < length)
                length = str.Length - startIndex;
            if (!string.IsNullOrEmpty(pathStr) && length<str.Length)
            {
                return str.Substring(startIndex, length) + pathStr;
            }
            return str.Substring(startIndex, length);
        }
    }

}
