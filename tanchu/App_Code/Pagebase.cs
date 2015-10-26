using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Security;
using System.Collections;
using System.Web;
using System.Text.RegularExpressions;
using System.IO;


    public class Pagebase : System.Web.UI.Page
    {
        public Pagebase()
        { }

        /// <summary>
        /// 接收参数
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string Get(string name)
        {
            string text1 = HttpContext.Current.Request.QueryString[name];
            return ((text1 == null) ? string.Empty : text1.Trim());
        }
        /// <summary>
        /// 接受POST参数
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string Post(string name)
        {
            string text1 = HttpContext.Current.Request.Form[name];
            return ((text1 == null) ? string.Empty : text1.Trim());
        }
        /// <summary>
        /// 截取指定长度的字符串
        /// </summary>
        /// <param name="val"></param>
        /// <param name="intLong"></param>
        /// <returns></returns>
        public static string Left(string s, int need, bool encode)
        {
            char ch1;
            if ((s == null) || (s == ""))
            {
                return string.Empty;
            }
            int num1 = s.Length;
            if (num1 < (need / 2))
            {
                return (encode ? TextEncode(s) : s);
            }
            int num4 = 0;
            int num2 = 0;
            while (num2 < num1)
            {
                ch1 = s[num2];
                num4 += IsUnicode(ch1.ToString()) ? 2 : 1;
                if (num4 >= need)
                {
                    break;
                }
                num2++;
            }
            string text1 = s.Substring(0, num2);
            if (num1 > num2)
            {
                int num3 = 0;
                while (num3 < 5)
                {
                    ch1 = s[num2 - num3];
                    num4 -= IsUnicode(ch1.ToString()) ? 2 : 1;
                    if (num4 <= need)
                    {
                        break;
                    }
                    num3++;
                }
                text1 = s.Substring(0, num2 - num3) + "...";
            }
            return (encode ? TextEncode(text1) : text1);
        }
        /// <summary>
        /// 全角转换为半角
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string charconverter(string source)
        {
            int len= source.Length;
            StringBuilder result = new StringBuilder(len, len);
            for (int i = 0; i < len; i++)
            {
                if (source[i] >= 65281 && source[i] <= 65373)
                {
                    result.Append((char)(source[i] - 65248));
                }
                else if (source[i] == 12288)
                {
                    result.Append("");
                }
                else
                {
                    result.Append(source[i]);
                }
            }
            return result.ToString();
        }
        /// <summary>
        /// 危险字符过滤
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string TextEncode(string s)
        {
            StringBuilder builder1 = new StringBuilder(s);
            builder1.Replace("&", "&amp;");
            builder1.Replace("<", "&lt;");
            builder1.Replace(">", "&gt;");
            builder1.Replace("\"", "&quot;");
            builder1.Replace("'", "&#39;");
            return ShitEncode(builder1.ToString());
        }
        /// <summary>
        /// 过滤脏字
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ShitEncode(string s)
        {
            string text1 = "";
            if ((text1 == null) || (text1 == ""))
            {
                text1 = "\u5988\u7684|\u4f60\u5988|\u4ed6\u5988|\u5988b|\u5988\u6bd4|fuck|shit|\u6211\u65e5|\u6cd5\u8f6e|\u6211\u64cd";
            }
            else
            {
                text1 = Regex.Replace(text1, @"\|{2,}", "|");
                text1 = Regex.Replace(text1, @"(^\|)|(\|$)", string.Empty);
            }
            return Regex.Replace(s, text1, "**", RegexOptions.IgnoreCase);
        }
        /// <summary>
        /// MD5算法
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string CutMD5(string str)
        {
            str = FormsAuthentication.HashPasswordForStoringInConfigFile(str, "md5");
            str = str.Substring(2, 17);
            str = str.ToLower();
            return str;
        }
        /// <summary>
        /// 分成数组
        /// </summary>
        /// <param name="str"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public string[] SplitString(string str, string separator)
        {
            string tmp = str;
            Hashtable ht = new Hashtable();
            int i = 0;
            int pos = tmp.IndexOf(separator);
            while (pos != -1)
            {
                ht.Add(i, tmp.Substring(0, pos));
                tmp = tmp.Substring(pos + separator.Length);
                pos = tmp.IndexOf(separator);
                i++;
            }
            ht.Add(i, tmp);
            string[] array = new string[ht.Count];
            for (int j = 0; j < ht.Count; j++)
                array[j] = ht[j].ToString();
            return array;
        }

        /// <summary>
        /// 去除HTML标记,简单防SQL注入
        /// </summary>
        /// <param name="Htmlstring"></param>
        /// <returns></returns>
        public static string NoHTML(string Htmlstring)
        {
            //删除脚本
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring.Replace("'", "");
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

            return ShitEncode(Htmlstring);
        }
        /// <summary>
        /// 解码危险字符 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string HtmlDecode(string s)
        {
            StringBuilder builder1 = new StringBuilder(s);
            builder1.Replace("&amp;", "&");
            builder1.Replace("&lt;", "<");
            builder1.Replace("&gt;", ">");
            builder1.Replace("&quot;", "\"");
            builder1.Replace("&#39;", "'");
            builder1.Replace("&nbsp; &nbsp; ", "\t");
            builder1.Replace("<p></p>", "\r\n\r\n");
            builder1.Replace("<br />", "\r\n");
            return builder1.ToString();
        }


        /// <summary>
        /// 过滤危险字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string HtmlEncode(string s)
        {
            StringBuilder builder1 = new StringBuilder(s);
            builder1.Replace("&", "&amp;");
            builder1.Replace("<", "&lt;");
            builder1.Replace(">", "&gt;");
            builder1.Replace("\"", "&quot;");
            builder1.Replace("'", "&#39;");
            builder1.Replace("\t", "&nbsp; &nbsp; ");
            builder1.Replace("\r", "");
            builder1.Replace("\n\n", "<p></p>");
            builder1.Replace("\n", "<br />");
            return ShitEncode(builder1.ToString());
        }
        /// <summary>
        /// 转换EMAIL
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string EmailEncode(string s)
        {
            string text1 = TextEncode(s).Replace("@", "&#64;").Replace(".", "&#46;");
            return string.Concat(new string[] { "<a href='mailto:", text1, "'>", text1, "</a>" });
        }
        /// <summary>
        ///  上次URL
        /// </summary>
        public static string Referrer
        {
            get
            {
                Uri uri1 = HttpContext.Current.Request.UrlReferrer;
                if (uri1 == null)
                {
                    return string.Empty;
                }
                return Convert.ToString(uri1);
            }
        }
        /// <summary>
        /// 域名
        /// </summary>
        public static string ServerDomain
        {
            get
            {
                string text1 = HttpContext.Current.Request.Url.Host.ToLower();
                string[] textArray1 = text1.Split(new char[] { '.' });
                if ((textArray1.Length < 3) || IsIp(text1))
                {
                    return text1;
                }
                string text2 = text1.Remove(0, text1.IndexOf(".") + 1);
                if ((text2.StartsWith("com.") || text2.StartsWith("net.")) || (text2.StartsWith("org.") || text2.StartsWith("gov.")))
                {
                    return text1;
                }
                return text2;
            }
        }

        /// <summary>
        /// 当前路径
        /// </summary>
        public static string CurrentPath
        {
            get
            {
                string text1 = HttpContext.Current.Request.Path;
                text1 = text1.Substring(0, text1.LastIndexOf("/"));
                if (text1 == "/")
                {
                    return string.Empty;
                }
                return text1;
            }
        }

        /// <summary>
        /// 客户IP
        /// </summary>
        public static string UserIp
        {
            get
            {
                string text1 = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if ((text1 == null) || (text1 == string.Empty))
                {
                    text1 = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }
                if (!IsIp(text1))
                {
                    return "Unknown";
                }
                return text1;
            }
        }


        /// <summary>
        /// IP转换成数值
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static long Ip2Int(string ip)
        {
            if (!IsIp(ip))
            {
                return (long)(-1);
            }
            string[] textArray1 = ip.Split(new char[] { '.' });
            long num1 = long.Parse(textArray1[0]) * 0x1000000;
            num1 += int.Parse(textArray1[1]) * 0x10000;
            num1 += int.Parse(textArray1[2]) * 0x100;
            return (num1 + int.Parse(textArray1[3]));
        }


        /// <summary>
        /// 客户浏览器
        /// </summary>
        public static string UserBrowser
        {
            get
            {
                string text1 = HttpContext.Current.Request.UserAgent;
                if (text1 != null)
                {
                    text1 = text1.ToLower();
                    if (text1.IndexOf("firefox") != -1)
                    {
                        return "Firefox";
                    }
                    if (text1.IndexOf("firebird") != -1)
                    {
                        return "Firebird";
                    }
                    if (text1.IndexOf("myie") != -1)
                    {
                        return "MyIE";
                    }
                    if (text1.IndexOf("opera") != -1)
                    {
                        return "Opera";
                    }
                    if (text1.IndexOf("netscape") != -1)
                    {
                        return "Netscape";
                    }
                    string[] textArray1 = text1.Split(new char[] { ';' });
                    if (textArray1[1].Trim() == "u")
                    {
                        return "Mozilla";
                    }
                    if (textArray1[1].IndexOf("msie") != -1)
                    {
                        return textArray1[1].Replace("msie", "IE").Trim();
                    }
                }
                return "Unknown";
            }
        }



        public static bool IsIp(string s)
        {
            string text1 = @"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$";
            return Regex.IsMatch(s, text1);
        }

        public static bool IsSafety(string s)
        {
            string text1 = s.Replace("%20", " ");
            text1 = Regex.Replace(text1, @"\s", " ");
            string text2 = "select |insert |delete from |count\\(|drop table|update |truncate |asc\\(|mid\\(|char\\(|xp_cmdshell|exec master|net localgroup administrators|:|net user|\"|\\'| or ";
            return !Regex.IsMatch(text1, text2, RegexOptions.IgnoreCase);
        }

        public static bool IsUnicode(string s)
        {
            string text1 = @"^[\u4E00-\u9FA5\uE815-\uFA29]+$";
            return Regex.IsMatch(s, text1);
        }

        public virtual bool IsUrl(string s)
        {
            string text1 = @"^(http|https|ftp|rtsp|mms):(\/\/|\\\\)[A-Za-z0-9%\-_@]+\.[A-Za-z0-9%\-_@]+[A-Za-z0-9\.\/=\?%\-&_~`@:\+!;]*$";
            return Regex.IsMatch(s, text1, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 检测是否是绝对路径
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public virtual bool IsRelativePath(string s)
        {
            if ((s == null) || (s == string.Empty))
            {
                return false;
            }
            if (s.StartsWith("/") || s.StartsWith("?"))
            {
                return false;
            }
            if (Regex.IsMatch(s, @"^\s*[a-zA-Z]{1,10}:.*$"))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 检测是否是物理路径
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public virtual bool IsPhysicalPath(string s)
        {
            string text1 = @"^\s*[a-zA-Z]:.*$";
            return Regex.IsMatch(s, text1);
        }
        /// <summary>
        /// 检测是否是数字
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public virtual bool IsNumeric(string s)
        {
            string text1 = @"^\-?[0-9]+$";
            return Regex.IsMatch(s, text1);
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="aa"></param>
        /// <returns></returns>
        public static string jiemi(string aa)
        {
            string str = "";
            int c;
            string code;
            for (int i = 0; i < aa.Length; i = i + 6)
            {
                try
                {
                    code = aa.Substring(i, 6);
                    c = int.Parse(code);
                    str = str + System.Convert.ToChar(c).ToString();
                }
                catch
                {
                    str = str + "?";
                }
            }
            return str;
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="aa"></param>
        /// <returns></returns>
        public static string jiami(string aa)
        {
            string str = "";
            char[] chr = aa.ToCharArray();
            for (int i = 0; i < chr.Length; i++)
            {
                str = str + Convert.ToInt32(chr[i]).ToString("000000");
            }
            return str;
        }
    }
