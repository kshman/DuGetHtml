using System.Text;
using System.Text.RegularExpressions;

namespace DuGetHtml;

internal class ReadSiteMnb : IReadSite
{
	private static readonly Regex rex_get_title = new("<title>(.+)<\\/title>");
	private static readonly Regex rex_get_blog_date = new("<p class=\"blog_date\">(.+)[<\\/p>|\\n]");
	private static readonly Regex rex_strip_tag = new("<[^>]*>");
	private static readonly Regex rex_strip_amp = new("&[^;]*;");
	private static readonly Regex rex_logno = new("logno=\"(\\d{1,20})\"");

	public void Clean()
	{
	}

	public void Prepare()
	{
	}

	public ReadParam CreateParam(string url)
	{
		var slash = url.LastIndexOf('/') + 1;
		return new ReadParam(url[..slash], Statics.ConvertLong(url[slash..]));
	}

	public void ReadPage(ReadParam param, StreamWriter sw)
	{
		var url = $"{param.BaseUrl}{param.Index}";

		try
		{
			HttpClient hc = new();
			var res = hc.GetStringAsync(url);
			var html = res.Result;

			html = rex_strip_amp.Replace(html, "⊙");

			//
			var mm = rex_get_title.Match(html);
			if (mm.Groups.Count > 1)
			{
				param.Title = mm.Groups[1].Value;
				var n = param.Title.IndexOf(" : 네이버 블로그", StringComparison.Ordinal);
				if (n >= 0)
					param.Title = param.Title[..n];
			}

			param.Date = string.Empty;
			mm = rex_get_blog_date.Match(html);
			if (mm.Groups.Count > 1) param.Date = mm.Groups[1].Value;

			//
			StringBuilder sb = new();
			var bdiv = 0;
			int ediv;
			while (true)
			{
				bdiv = html.IndexOf("<div class=\"se-module se-module-text\">", bdiv, StringComparison.Ordinal);
				if (bdiv < 0) break;
				ediv = html.IndexOf("</div>", bdiv, StringComparison.Ordinal);
				if (ediv < 0) break;

				var stripeol = html[bdiv..ediv].Replace("<!-- } SE-TEXT -->", "\n");
				var striphtml = rex_strip_tag.Replace(stripeol, string.Empty);

				if (striphtml.Length > 0)
					sb.AppendLine(striphtml);

				bdiv = ediv;
			}

			if (sb.Length > 0)
				param.Text = sb.ToString();

			//
			bdiv = html.IndexOf("<tbody id=\"postBottomTitleListBody\">", StringComparison.Ordinal);
			if (bdiv < 0) throw new Exception("시작 지점이 없어요");
			ediv = html.IndexOf("</tbody>", bdiv, StringComparison.Ordinal);
			if (ediv < 0) throw new Exception("끝 지점이 없어요");

			var nexts = rex_logno.Matches(html[bdiv..ediv])
				.TakeWhile(m => m.Groups.Count >= 2)
				.Select(m => Statics.ConvertLong(m.Groups[1].Value))
				.Where(item => item > param.Index)
				.ToList();

			if (nexts.Count <= 0)
				return;

			nexts.Sort();
			param.NextIndex = nexts[0];
		}
		catch (Exception ex)
		{
			param.Text += Environment.NewLine;
			param.Text += ex.Message;
		}
	}
}
