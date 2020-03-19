using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace PharmaceuticalWarehouseManagementSystem.Utility
{
    public static class Ipfinder
    {
        public static string GetIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
                else
                {
                    return "127.0.0.1".ToString();
                }
            }
            return "Local Ip Address Not Found!";
        }

        public static string IpAddress { get { return GetIpAddress(); } }
    }
}
