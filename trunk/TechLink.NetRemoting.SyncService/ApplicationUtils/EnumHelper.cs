using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace ApplicationUtils.Utils
{
	/// <summary>
	/// Summary description for EnumHelper.
	/// </summary>
	public class EnumHelper
	{
		/// <summary>
		/// Translates the specified enumValue, using the currentManager.
		/// </summary>
		/// <param name="currentManager">The current manager.</param>
		/// <param name="enumValue">The enum value.</param>
		/// <returns>The translated string.</returns>
		public static string Translate(IDictionary<string,string> currentManager, Enum enumValue)
		{
			string key = enumValue.GetType().Name + "." + enumValue.ToString();
			return CultureHelper.GetResourceText(currentManager, key, key);
		}

		/// <summary>
		/// Translates the specified enumValue, using the currentManager.
		/// </summary>
		/// <param name="currentManager">The current manager.</param>
		/// <param name="enumValue">The enum value.</param>
		/// <returns>The translated string.</returns>
		public static string Translate(IDictionary<string, string> currentManager, Enum enumValue, string keyAddOn)
		{
			string key = enumValue.GetType().Name + "." + enumValue.ToString() + keyAddOn;
			return CultureHelper.GetResourceText(currentManager, key, key);
		}

		public static string GetAssociatedDescription(Enum value)
		{
			FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
			DescriptionAttribute[] attributes =
				(DescriptionAttribute[]) fieldInfo.GetCustomAttributes(typeof (DescriptionAttribute), false);
			return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
		}

		public static Enum SelectEnumValueBasedOnDescriptionAttribute(Type enumTypeFromWhichToSelect,string descrAtribValOfTheEnumToSelect)
		{
			Array enumValues = Enum.GetValues(enumTypeFromWhichToSelect);
			foreach (Enum enumValue in enumValues)
			{
				string description = GetAssociatedDescription(enumValue);
				if (description.ToLower() == descrAtribValOfTheEnumToSelect)
				{
					return enumValue; 
				}
			}

			return null;
		}

		public static string GetCommaSeparatedDesciptionsForEnum(Type enumType)
		{
			StringBuilder sb = new StringBuilder();
			Array enumValues = Enum.GetValues(enumType);

			foreach (Enum enumValue in enumValues)
			{
				string description = GetAssociatedDescription(enumValue);
				sb.Append(description);
				sb.Append(",");
			}

			if(sb.Length > 0)
			{
				sb.Remove(sb.Length - 2, 1);
			}

			return sb.ToString();
		}
	}
}