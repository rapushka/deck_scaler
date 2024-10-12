using System.Linq;
using System.Text.RegularExpressions;

namespace Entitas.Generic
{
	internal static class StringExtensions
	{
		/// <summary>
		/// Gives opportunity to use SerializedObject.FindProperty for serialized property 
		/// </summary>
		internal static string WrapSerializedProperty(this string name)
			=> $"<{name}>k__BackingField";

		/// <summary> _fewWordsField -&gt; Few Words Field </summary>
		internal static string Pretty(this string @this)
			=> @this.RemovePrefix("_").FirstToUpper().PascalCaseToSpaces();

		private static string PascalCaseToSpaces(this string @this) => Regex.Replace(@this, "(\\B[A-Z])", " $1");

		private static string RemovePrefix(this string @this, string prefix)
			=> @this.StartsWith(prefix) ? @this[prefix.Length..] : @this;

		private static string FirstToUpper(this string @this)
			=> char.ToUpper(@this.First()) + @this[1..];
	}
}