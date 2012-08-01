using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace ApplicationUtils.Utils.ZipUtils.Core
{
	/// <summary>
	/// NameFilter is a string matching class which allows for both positive and negative
	/// matching.
	/// A filter is a sequence of independant <see cref="Regex">regular expressions</see> separated by semi-colons ';'
	/// Each expression can be prefixed by a plus '+' sign or a minus '-' sign to denote the expression
	/// is intended to include or exclude names.  If neither a plus or minus sign is found include is the default
	/// A given name is tested for inclusion before checking exclusions.  Only names matching an include spec 
	/// and not matching an exclude spec are deemed to match the filter.
	/// An empty filter matches any name.
	/// </summary>
	/// <example>The following expression includes all name ending in '.dat' with the exception of 'dummy.dat'
	/// "+\.dat$;-^dummy\.dat$"
	/// </example>
	public class NameFilter : IScanFilter
	{
		#region Constructors

		/// <summary>
		/// Construct an instance based on the filter expression passed
		/// </summary>
		/// <param name="filter">The filter expression.</param>
		public NameFilter(string filter)
		{
			filter_ = filter;
			inclusions_ = new ArrayList();
			exclusions_ = new ArrayList();
			Compile();
		}

		#endregion

		/// <summary>
		/// Test a string to see if it is a valid regular expression.
		/// </summary>
		/// <param name="expression">The expression to test.</param>
		/// <returns>True if expression is a valid <see cref="System.Text.RegularExpressions.Regex"/> false otherwise.</returns>
		public static bool IsValidExpression(string expression)
		{
			bool result = true;
			try
			{
				Regex exp = new Regex(expression, RegexOptions.IgnoreCase | RegexOptions.Singleline);
			}
			catch
			{
				result = false;
			}
			return result;
		}

		/// <summary>
		/// Test an expression to see if it is valid as a filter.
		/// </summary>
		/// <param name="toTest">The filter expression to test.</param>
		/// <returns>True if the expression is valid, false otherwise.</returns>
		public static bool IsValidFilterExpression(string toTest)
		{
			if (toTest == null)
			{
				throw new ArgumentNullException("toTest");
			}

			bool result = true;

			try
			{
				string[] items = toTest.Split(';');
				for (int i = 0; i < items.Length; ++i)
				{
					if (items[i] != null && items[i].Length > 0)
					{
						string toCompile;

						if (items[i][0] == '+')
						{
							toCompile = items[i].Substring(1, items[i].Length - 1);
						}
						else if (items[i][0] == '-')
						{
							toCompile = items[i].Substring(1, items[i].Length - 1);
						}
						else
						{
							toCompile = items[i];
						}

						Regex testRegex = new Regex(toCompile, RegexOptions.IgnoreCase | RegexOptions.Singleline);
					}
				}
			}
			catch (Exception)
			{
				result = false;
			}

			return result;
		}

		/// <summary>
		/// Convert this filter to its string equivalent.
		/// </summary>
		/// <returns>The string equivalent for this filter.</returns>
		public override string ToString()
		{
			return filter_;
		}

		/// <summary>
		/// Test a value to see if it is included by the filter.
		/// </summary>
		/// <param name="name">The value to test.</param>
		/// <returns>True if the value is included, false otherwise.</returns>
		public bool IsIncluded(string name)
		{
			bool result = false;
			if (inclusions_.Count == 0)
			{
				result = true;
			}
			else
			{
				foreach (Regex r in inclusions_)
				{
					if (r.IsMatch(name))
					{
						result = true;
						break;
					}
				}
			}
			return result;
		}

		/// <summary>
		/// Test a value to see if it is excluded by the filter.
		/// </summary>
		/// <param name="name">The value to test.</param>
		/// <returns>True if the value is excluded, false otherwise.</returns>
		public bool IsExcluded(string name)
		{
			bool result = false;
			foreach (Regex r in exclusions_)
			{
				if (r.IsMatch(name))
				{
					result = true;
					break;
				}
			}
			return result;
		}

		#region IScanFilter Members

		/// <summary>
		/// Test a value to see if it matches the filter.
		/// </summary>
		/// <param name="name">The value to test.</param>
		/// <returns>True if the value matches, false otherwise.</returns>
		public bool IsMatch(string name)
		{
			return IsIncluded(name) && (IsExcluded(name) == false);
		}

		#endregion

		/// <summary>
		/// Compile this filter.
		/// </summary>
		private void Compile()
		{
			// TODO: Check to see if combining RE's makes it faster/smaller.
			// simple scheme would be to have one RE for inclusion and one for exclusion.
			if (filter_ == null)
			{
				return;
			}

			// TODO: Allow for paths to include ';'
			string[] items = filter_.Split(';');
			for (int i = 0; i < items.Length; ++i)
			{
				if ((items[i] != null) && (items[i].Length > 0))
				{
					bool include = (items[i][0] != '-');
					string toCompile;

					if (items[i][0] == '+')
					{
						toCompile = items[i].Substring(1, items[i].Length - 1);
					}
					else if (items[i][0] == '-')
					{
						toCompile = items[i].Substring(1, items[i].Length - 1);
					}
					else
					{
						toCompile = items[i];
					}

					// NOTE: Regular expressions can fail to compile here for a number of reasons that cause an exception
					// these are left unhandled here as the caller is responsible for ensuring all is valid.
					// several functions IsValidFilterExpression and IsValidExpression are provided for such checking
					if (include)
					{
						inclusions_.Add(new Regex(toCompile, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline));
					}
					else
					{
						exclusions_.Add(new Regex(toCompile, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline));
					}
				}
			}
		}

		#region Instance Fields

		private readonly string filter_;
		private readonly ArrayList inclusions_;
		private readonly ArrayList exclusions_;

		#endregion
	}
}