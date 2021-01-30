using System.Linq;

namespace MockPractice.StringManipulator
{
	public class StringManipulator
	{
		public bool IsVowel(char c)
		{
			var vowels = new char[] { 'a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U', 'y', 'Y' };
			return vowels.Contains(c);
		}

		public string Transform(string s)
		{
			var lc = s.ToLower();
			var x = lc.Where(c => IsVowel(c));
			var y = lc.Where(c => !IsVowel(c));

			return new string(x.Concat(y).ToArray());
		}
	}
}
