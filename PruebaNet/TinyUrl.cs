//namespace PruebaNet


using System;

using System.Collections.Generic;

using System.Security.Cryptography;

using System.Text;

using System.Text.RegularExpressions;

namespace PruebaNet
{




    public class TinyUrl
    {


        private Dictionary<string, string> urlMap;

        public TinyUrl()
        {
            urlMap = new Dictionary<string, string>();
        }

        public string Encode(string longUrl)
        {
            if (!IsValidUrl(longUrl))
            {
                throw new ArgumentException("La URL es inválida");
            }

            if (longUrl.Length < 1 || longUrl.Length > 250)
            {
                throw new ArgumentException("Longitud de la URL erronea (1-255)");
            }


            using (SHA1Managed sha1 = new SHA1Managed())

            {

                byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(longUrl));

                StringBuilder shortUrl = new StringBuilder("http://tinyurl.com/");

                for (int i = 0; i < 5; i++)

                {

                    shortUrl.Append(hash[i].ToString("x2"));

                }

                urlMap[shortUrl.ToString()] = longUrl;

                return shortUrl.ToString();

            }

        }


        public string Decode(string longUrl)
        {
            if (urlMap.ContainsKey(longUrl))

            {

                return urlMap[longUrl];

            }

            else

            {

                throw new ArgumentException("URL acortada no encontrada en el objeto TinyUrl.");

            }
        }

        private bool IsValidUrl(string url)
        {
            Regex regex = new Regex(@"^(?:http|ftp)s?://(?:(?:[A-Z0-9](?:[A-Z0-9-]{0,61}[A-Z0-9])?\.)+(?:[A-Z]{2,6}\.?|[A-Z0-9-]{2,}\.?)|localhost|\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})(?::\d+)?(?:/?|[/?]\S+)$", RegexOptions.IgnoreCase);

            return regex.IsMatch(url);
        }
    }
}