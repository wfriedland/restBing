using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace restBing.Controllers
{
    public class pingObj
    {
        Ping pingSender;
        PingOptions options;
        public PingReply reply;
        public pingObj()
        {
            pingSender = new Ping();
            options = new PingOptions();
            // Use the default Ttl value which is 128,
            // but change the fragmentation behavior.
            options.DontFragment = true;

        }
        public bool send(string ipAddrOrHost)
        {
            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "abcdefghijklmnopqrstuvwxyz";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;
            if (ipAddrOrHost == null || ipAddrOrHost == "") ipAddrOrHost = "10.0.0.4";
             reply = pingSender.Send(ipAddrOrHost, timeout, buffer, options);
            if (reply.Status == IPStatus.Success)
            {
                Console.WriteLine("Address: {0}", reply.Address.ToString());
                Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
                Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);
                return true;
            }
            else
            {
                return false;
            }

        }
        protected string getIPaddr(string url)
        {
            IPHostEntry returnIP = System.Net.Dns.GetHostEntry(url);
            return returnIP.AddressList.ToString();
        }
    }
}