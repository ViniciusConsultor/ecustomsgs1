using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace ApplicationUtils.Utils
{
	/// <summary>
	/// Summary description for NetHelper.
	/// </summary>
	public class NetHelper
	{
		public static string GetIpAddress()
		{
			IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
			return hostEntry.HostName;
		}

		public static IPAddress GetIpAddressFromTheSameNetworkAs(IPAddress address)
		{
			NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
			if (IPAddress.IsLoopback(address)) return address;
			foreach (NetworkInterface networkInterface in interfaces)
			{
				foreach (UnicastIPAddressInformation ipAddress in networkInterface.GetIPProperties().UnicastAddresses)
				{
					if (ipAddress.Address.AddressFamily != address.AddressFamily)
					{
						continue;
					}
					if (ipAddress.IPv4Mask == null)
					{
						continue;
					}
					if (ApplyMask(ipAddress.Address, ipAddress.IPv4Mask).Equals(ApplyMask(address, ipAddress.IPv4Mask)))
					{
						return ipAddress.Address;
					}
				}
			}
		  return null;
		}

		public static IPAddress ApplyMask(IPAddress ipAddress,IPAddress mask)
		{
			byte[] addressBytes = ipAddress.GetAddressBytes();
			byte[] maskBytes = mask.GetAddressBytes();
			List<byte> resultBytes = new List<byte>();

			for (int i = 0; i < addressBytes.Length; i++)
			{
				byte addressByte = addressBytes[i];
				byte maskAddressByte = maskBytes[i];

				resultBytes.Add((byte) (addressByte & maskAddressByte));
			}

			return new IPAddress(resultBytes.ToArray());
		}
	}
}