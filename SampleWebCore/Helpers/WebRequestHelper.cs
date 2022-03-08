using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;

namespace SampleWebCore.Helpers
{
    public class WebRequestHelper
    {

        public static string Post(string url, string data, string accept = "")
        {
            string result = string.Empty;

            var webRequest = WebRequest.Create(url) as HttpWebRequest;
            if (webRequest != null)
            {
                //var payload = new System.Net.Http.StringContent(data, Encoding.UTF8, "application/json");
                webRequest.Method = WebRequestMethods.Http.Post;
                webRequest.ContentType = "application/json";
                if (!string.IsNullOrEmpty(accept))
                {
                    webRequest.Accept = "application/json";
                }
                //POST the data.
                using (StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                {
                    requestWriter.Write(data);
                }
                using (HttpWebResponse httpWebResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    using (Stream stream = httpWebResponse.GetResponseStream())
                    {
                        using (StreamReader streamReader = new StreamReader(stream))
                        {
                            result = streamReader.ReadToEnd();
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// This method is used to get html content as response
        /// </summary>
        /// <param name="url">Url to get data from</param>
        /// <param name="requestTimeout">Timeout in milliseconds</param>
        /// <returns>Response as string</returns>
        public static string Get(string url, int requestTimeout = 60000, string accept = "")
        {
            string result = string.Empty;

            var webRequest = WebRequest.Create(url) as HttpWebRequest;
            if (webRequest != null)
            {
                webRequest.Method = WebRequestMethods.Http.Get;
                webRequest.Timeout = webRequest.ReadWriteTimeout = requestTimeout;
                webRequest.KeepAlive = false;
                webRequest.ContentType = "application/x-www-form-urlencoded";
                if (!string.IsNullOrEmpty(accept))
                {
                    webRequest.Accept = "application/json";
                }
                using (HttpWebResponse httpWebResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    using (Stream stream = httpWebResponse.GetResponseStream())
                    {
                        using (StreamReader streamReader = new StreamReader(stream))
                        {
                            result = streamReader.ReadToEnd();
                        }
                    }
                }
            }

            return result;
        }

        public static string Post(string url, string data, Dictionary<string, string> customeHeaders, string accept = "")
        {
            string result = string.Empty;
            //sleep thread for one sec to avoid concurrent smtp calls
            Thread.Sleep(TimeSpan.FromSeconds(1));
            var webRequest = WebRequest.Create(url) as HttpWebRequest;
            if (webRequest != null)
            {
                //var payload = new System.Net.Http.StringContent(data, Encoding.UTF8, "application/json");
                webRequest.Method = WebRequestMethods.Http.Post;
                webRequest.ContentType = "application/json";
                if (customeHeaders?.Count > 0)
                {
                    foreach(var header in customeHeaders)
                    {
                        webRequest.Headers.Add(header.Key, header.Value);
                    }
                }
                if (!string.IsNullOrEmpty(accept))
                {
                    webRequest.Accept = "application/json";
                }
                //POST the data.
                using (StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                {
                    requestWriter.Write(data);
                }
                using (HttpWebResponse httpWebResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    using (Stream stream = httpWebResponse.GetResponseStream())
                    {
                        using (StreamReader streamReader = new StreamReader(stream))
                        {
                            result = streamReader.ReadToEnd();
                        }
                    }
                }
            }

            return result;
        }

        public static string Get(string url, Dictionary<string, string> customeHeaders, string accept = "")
        {
            string result = string.Empty;

            var webRequest = WebRequest.Create(url) as HttpWebRequest;
            if (webRequest != null)
            {
                webRequest.Method = WebRequestMethods.Http.Get;
                webRequest.Timeout = webRequest.ReadWriteTimeout = 60000;
                webRequest.KeepAlive = false;
                webRequest.ContentType = "application/x-www-form-urlencoded";
                if (customeHeaders?.Count > 0)
                {
                    foreach (var header in customeHeaders)
                    {
                        webRequest.Headers.Add(header.Key, header.Value);
                    }
                }
                if (!string.IsNullOrEmpty(accept))
                {
                    webRequest.Accept = "application/json";
                }
                using (HttpWebResponse httpWebResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    using (Stream stream = httpWebResponse.GetResponseStream())
                    {
                        using (StreamReader streamReader = new StreamReader(stream))
                        {
                            result = streamReader.ReadToEnd();
                        }
                    }
                }
            }

            return result;
        }

    }
}
