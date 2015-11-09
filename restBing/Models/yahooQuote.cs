using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.IO;
using System.Text;

namespace restBing.Controllers
{
    public class yahooQuote
    {
        protected int urlIdx = 33;
        public string ticker;
        protected string[] getStr =
        {
            "http://finance.yahoo.com/d/quotes.csv?s=fb&f=price",
            "http://finance.yahoo.com/d/quotes.csv?s=sds&f=price",
            "http://finance.yahoo.com/d/quotes.csv?s=expe&f=price",
            "http://finance.yahoo.com/d/quotes.csv?s=tgt&f=price",
            "http://finance.yahoo.com/d/quotes.csv?s=xom&f=price"
        };
        string[] supportedTickers = { "fb", "sds", "expe", "tgt", "xom" };
        public yahooQuote(string tickr)
        {
            // replace this code with  linq to test for valid ticker symbol
            for (int i = 0; i < supportedTickers.Length; i++)
            {
                if (tickr == supportedTickers[i])
                {
                    urlIdx = i;
                    ticker = tickr;
                    break;
                }
            }
            if (urlIdx == 33)
            {
                urlIdx = 0;
                ticker = supportedTickers[urlIdx];
            }

        }

        public string sendGet()
        {
            string url = getStr[urlIdx];
            byte[] buf = new byte[200];

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream resStream = response.GetResponseStream();
            int len = resStream.Read(buf, 0, 200);
            return parsePrice(buf, len);
        }

        protected string parsePrice(byte[] buf, int len)
        {
            StringBuilder price = new StringBuilder("");
            for (int i = 0; i < len; i++)
            {
                if (buf[i] == ',') break;
                price.Append((char)buf[i]);
            }
            return price.ToString();            
        }
    }
}