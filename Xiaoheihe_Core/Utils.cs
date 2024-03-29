﻿using System.Security.Cryptography;
using System.Text;
using Xiaoheihe_Core.Data;
using static Xiaoheihe_Core.StaticValue;

namespace Xiaoheihe_Core
{
    public static class Utils
    {
        /// <summary>
        /// 组装默认参数
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static Dictionary<string, string> DefaultParams(Account account)
        {
            return DefaultParams(account, DefaultHBVersion);
        }

        /// <summary>
        /// 组装默认参数
        /// </summary>
        /// <param name="account"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public static Dictionary<string, string> DefaultParams(Account account, string version)
        {
            if (string.IsNullOrEmpty(account.Imei)) { account.Imei = RandomImei(); }
            if (string.IsNullOrEmpty(version)) { version = DefaultHBVersion; }

            Dictionary<string, string> paramDict = new(40)
            {
                { "userid", "" },
                { "link_id", "" },
                { "type", "" },
                { "h_src", "" },
                { "shared_type", "" },
                { "index", "" },
                { "offset", "" },
                { "page", "" },
                { "limit", "" },
                { "filters", "" },
                { "only_cy", "" },
                { "list_type", "" },
                { "older", "" },
                { "newer", "" },
                { "tag", "" },
                { "rec_mark", "" },
                { "news_list_type", "" },
                { "is_first", "" },
                { "news_list_group", "" },
                { "appid", "" },
                { "platf", "" },
                { "sort_filter", "" },
                { "owner_only", "" },
                { "hide_cy", "" },
                { "return_json", "" },
                { "time_", "" },
                { "heybox_id", account.HeyboxID },
                { "imei", account.Imei },
                { "divice_info", account.DeviceInfo },
                { "os_type", account.OSType },
                { "x_os_type", account.OSType },
                { "x_client_type", "mobile" },
                { "os_version", account.OSVersion },
                { "version", version },
                { "x_app", "heybox" },
                { "_time", "" },
                { "nonce", "" },
                { "hkey", "" },
                { "channal", account.Channal }
            };

            return paramDict;
        }

        /// <summary>
        /// 设置默认请求头
        /// </summary>
        /// <param name="client"></param>
        /// <param name="pkey"></param>
        /// <returns></returns>
        public static void SetDefaultHttpHeaders(HttpClient client)
        {
            Dictionary<string, string> headers = new(6)
            {
                { "Host", "api.xiaoheihe.cn" },
                { "Referer", "http://api.maxjia.com/" },
                { "User-Agent", "Mozilla/5.0 AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.118 Safari/537.36 ApiMaxJia/1.0" },
                { "Accept-Encoding", "gzip, deflate" },
                { "Connection", "close" },

            };

            foreach (KeyValuePair<string, string> header in headers)
            {
                client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }

        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private static string RandomString(int length)
        {
            string template = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random rand = new();
            StringBuilder imei = new();
            for (int i = 0; i < length; i++)
            {
                imei.Append(template.AsSpan(rand.Next(0, template.Length - 1), 1));
            }
            return imei.ToString();
        }

        /// <summary>
        /// 生成随机IMEI
        /// </summary>
        /// <returns></returns>
        public static string RandomImei()
        {
            string randImei = RandomString(16).ToLowerInvariant();

            return randImei;
        }

        /// <summary>
        /// 生成随机Nonce
        /// </summary>
        /// <returns></returns>
        public static string RandomNonce()
        {
            return RandomString(32);
        }

        /// <summary>
        /// 生成随机DES密钥
        /// </summary>
        /// <returns></returns>
        public static string RandomDesKey()
        {
            return RandomString(8);
        }

        public static string DEs()
        {
            DES DESalg = DES.Create();

            DESalg.CreateEncryptor();
            return "";
        }

        /// <summary>
        /// Base64编码
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Base64Encode(string text)
        {
            byte[] inArray = Encoding.UTF8.GetBytes(text);
            string b64String = Convert.ToBase64String(inArray);
            return b64String;
        }
    }
}
