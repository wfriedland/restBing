using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Text;

namespace restBing.Controllers
{
    public class stock
    {
        public string symb { get; }
        public string name { get; set; }
        public double price { get; set;}
        public stock(string ticker)
        {
            symb = ticker;
        }
    }
    public class EodStockList
    {
        List<stock> portfolio;
        StringBuilder rawData;
        protected const int MAX_BUF = 1000;
        public EodStockList()
        {
            portfolio = new List<stock>();
            rawData = new StringBuilder(MAX_BUF);
            portfolio.Add(new stock("XOM"));
            portfolio.Add(new stock("JNPR"));
            portfolio.Add(new stock("EXPE"));
            portfolio.Add(new stock("FB"));
            portfolio.Add(new stock("TGT"));
        }
        public string sendGet()
        {
            string pkt = "http://finance.yahoo.com/d/quotes.csv?s=XOM+jnpr+expe+fb+tgt&f=snd1l1yr";
            Byte[] buf = new Byte[MAX_BUF];

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(pkt);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream resStream = response.GetResponseStream();
            int bytesRead = resStream.Read(buf, 0, MAX_BUF);
            buf = Encoding.Convert(Encoding.GetEncoding("iso-8859-1"), Encoding.UTF8, buf);
            rawData.Append(Encoding.UTF8.GetString(buf, 0, bytesRead));
            return rawData.ToString() ;
        }
        public List<string> formatBlock()
        {
            List<string> fmtBlock = new List<string>();
            rawData.Replace('\n', ',');
            rawData.Replace('"', ' ');

            string[] blocks = rawData.ToString().Split(',');
            for (int i = 0; i < blocks.Length; i++)
            {
                if (blocks[i].ToUpper().Trim().Contains("XOM"))
                {
                    string str = blocks[i].ToUpper() + ":  " + blocks[i + 3];
                    fmtBlock.Add(str);
                }
                else if (blocks[i].ToUpper().Trim().Contains("FB"))
                {
                    string str1 = blocks[i].ToUpper() + ":  " + blocks[i + 3];
                    fmtBlock.Add(str1);
                }
                else if (blocks[i].ToUpper().Trim().Contains("EXPE"))
                {
                    string str2 = blocks[i].ToUpper() + ":  " + blocks[i + 3];
                    fmtBlock.Add(str2);
                }
                else if (blocks[i].ToUpper().Trim().Contains("JNPR"))
                {
                    string str3 = blocks[i].ToUpper() + ":  " + blocks[i + 3];
                    fmtBlock.Add(str3);
                }
            }
            return fmtBlock;
        }
    }
}