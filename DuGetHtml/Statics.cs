using System.Text.RegularExpressions;

namespace DuGetHtml;

internal static class Statics
{
	public static bool RegexTest(string s)
	{
		Regex r = new Regex("<title>(.+)<\\/title>");
		if (r.IsMatch(s)) return true;

		return false;
	}

	/*
	[GeneratedRegex("<title>(.+)<\\/title>")]
	public static partial Regex reg_get_title();
	[GeneratedRegex("<span class=\"date\">(.+)<\\/span>")]
	public static partial Regex reg_get_date();
	[GeneratedRegex("<p class=\"blog_date\">(.+)[<\\/p>|\\n]")]
	public static partial Regex reg_get_blog_date();
	[GeneratedRegex("<[^>]*>")]
	public static partial Regex reg_strip_tag();
	[GeneratedRegex("&[^;]*;")]
	public static partial Regex reg_strip_amp();
	[GeneratedRegex("<a href=\"\\/(\\d{1,10})\">(.+)<\\/a>")]
	public static partial Regex reg_strip_list();
	[GeneratedRegex("logno=\"(\\d{1,20})\"")]
	public static partial Regex reg_naver_blog_logno();
	*/

	public static long ConvertLong(string value)
	{
		return long.TryParse(value, out var result) ? result : -1;
	}
}
