using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ApplicationUtils.Utils
{
	public class CurrencyHelper
	{
		public static string FormatAsCurrency(double money)
		{
			System.Globalization.CultureInfo vi = new System.Globalization.CultureInfo("vi-VN");

			return money.ToString("C", vi);
		}

		public static string FormatAsCurrency(string strMoney)
		{
			System.Globalization.CultureInfo vi = new System.Globalization.CultureInfo("vi-VN");
			double newMoney = 0.0;
			if (strMoney.Trim() != "")
				try
				{
					newMoney = double.Parse(strMoney, vi);
				}
				catch (Exception exception)
				{ throw exception; }
			return newMoney.ToString("C", vi);
		}

		public static string FormatAsNumeric(string strNumeric)
		{
			System.Globalization.CultureInfo vi = new System.Globalization.CultureInfo("vi-VN");
			double newNumber = 0.0;
			if (strNumeric.Trim() != "")
				try
				{
						//if(strNumeric.Contains(".")) vi = new CultureInfo("en-US");
					if (strNumeric.Contains(".")) strNumeric = strNumeric.Replace('.', ',');
					newNumber = double.Parse(strNumeric, vi);	
				}
				catch (Exception exception)
				{
					throw exception;
				}
			return newNumber.ToString("N0", vi);
		}

		public static string FormatAsDecimal(string strNumeric, int numberOfDecimal)
		{
			System.Globalization.CultureInfo vi = new System.Globalization.CultureInfo("vi-VN");
			double newNumber = 0.0;
			if (strNumeric.Trim() != "")
				try
				{
					//if(strNumeric.Contains(".")) vi = new CultureInfo("en-US");
					if (strNumeric.Contains(".")) strNumeric = strNumeric.Replace('.', ',');
					newNumber = double.Parse(strNumeric, vi);
				}
				catch (Exception exception)
				{ throw exception; }
			return newNumber.ToString("N" + numberOfDecimal.ToString(), vi);
		}

		public static string FormatAsDecimal(string strNumeric)
		{
			System.Globalization.CultureInfo vi = new System.Globalization.CultureInfo("vi-VN");
			double newNumber = 0.0;
			if (strNumeric.Trim() != "")
				try
				{
					//if(strNumeric.Contains(".")) vi = new CultureInfo("en-US");
					if (strNumeric.Contains(".")) strNumeric = strNumeric.Replace('.', ',');
					newNumber = double.Parse(strNumeric, vi);
				}
				catch (Exception exception)
				{ throw exception; }
			return newNumber.ToString("D", vi);
		}

		public static double Parse(string strMoney)
		{
			System.Globalization.CultureInfo vi = new System.Globalization.CultureInfo("vi-VN");
			double newMoney = 0.0;
			if (strMoney.Trim() != "")
				try
				{
					if (strMoney.Contains(".")) strMoney = strMoney.Replace('.', ',');
					newMoney = double.Parse(strMoney, vi);
				}
				catch
				{
					newMoney = 0.0;
				}
			return newMoney;
		}

		public static decimal ParseToDecimal(string strMoney, int numberOfDecimal)
		{
			System.Globalization.CultureInfo vi = new System.Globalization.CultureInfo("vi-VN");
			string ret = FormatAsDecimal(strMoney, numberOfDecimal);
			return decimal.Parse(ret.Replace('.', ','), vi);
		}


		public static int ParseToInt(string strMoney)
		{
			System.Globalization.CultureInfo vi = new System.Globalization.CultureInfo("vi-VN");
			int newMoney = 0;
			if (strMoney.Trim() != "")
				try
				{
					if (strMoney.Contains(".")) strMoney = strMoney.Replace('.', ',');
					newMoney = int.Parse(strMoney, vi);
				}
				catch
				{
					newMoney = 0;
				}
			return newMoney;
		}

		#region Reading Number
		private static string[] mangso = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };

		private static string dochangchuc(int so, bool daydu)
		{
			string chuoi = "";
			int chuc = so / 10;
			int donvi = so % 10;
			if (chuc > 1)
			{
				chuoi = " " + mangso[chuc] + " mươi";
				if (donvi == 1)
				{
					chuoi += " một";
				}
			}
			else if (chuc == 1)
			{
				chuoi = " mười";
				if (donvi == 1)
				{
					chuoi += " một";
				}
			}
			else if (daydu && donvi > 0)
			{
				chuoi = " lẻ";
			}
			if (donvi == 5 && chuc > 1)
			{
				chuoi += " lăm";
			}
			else if (donvi > 1 || (donvi == 1 && chuc == 0))
			{
				chuoi += " " + mangso[donvi];
			}
			return chuoi;
		}
		
		private static string docblock(int so, bool daydu)
		{
			string chuoi = "";
			int trăm = so / 100;
			so = so % 100;
			if (daydu || trăm > 0)
			{
				chuoi = " " + mangso[trăm] + " trăm";
				chuoi += dochangchuc(so, true);
			}
			else
			{
				chuoi = dochangchuc(so, false);
			}
			return chuoi;
		}
		
		private static string dochangtrieu(int so, bool daydu)
		{
			string chuoi = "";
			int trieu = so / 1000000;
			so = so % 1000000;
			if (trieu > 0)
			{
				chuoi = docblock(trieu, daydu) + " triệu";
				daydu = true;
			}
			int nghin = so / 1000;
			so = so % 1000;
			if (nghin > 0)
			{
				chuoi += docblock(nghin, daydu) + " nghìn";
				daydu = true;
			}
			if (so > 0)
			{
				chuoi += docblock(so, daydu);
			}
			return chuoi;
		}

		public static string ReadNumber(int so)
		{
			if (so == 0) { return mangso[0]; }
			string chuoi = "";
			string hauto = "";
			int ty = 0;
			do
			{
				ty = so % 1000000000;
				so = so / 1000000000;
				if (so > 0)
				{
					chuoi = dochangtrieu(ty, true) + hauto + chuoi; // +" đồng";
				}
				else
				{
					chuoi = dochangtrieu(ty, false) + hauto + chuoi; // +" đồng";
				}
				hauto = " tỉ";
			} while (so > 0);
			return chuoi;
		}
		#endregion
	}
}
