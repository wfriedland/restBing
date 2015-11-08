using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restBing.Controllers
{
    public class yahooQuote
    {
        string ticker;
        string[] requestStr =
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
            // use linq to test for valid ticker symbol

        }
    }
}