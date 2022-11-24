using System.Text.RegularExpressions;

namespace DuGetHtml;

internal class ReadSiteViorate : IReadSite
{
	private static readonly Regex rex_get_title = new("<title>(.+)<\\/title>", RegexOptions.IgnoreCase);
	private static readonly Regex rex_get_date = new("<span class=\"date\">(.+)<\\/span>", RegexOptions.IgnoreCase);
	private static readonly Regex rex_strip_tag = new("<[^>]*>", RegexOptions.IgnoreCase);
	private static readonly Regex rex_strip_amp = new("&[^;]*;", RegexOptions.IgnoreCase);
	private static readonly Regex rex_strip_list = new("<a href=\"\\/(\\d{1,10})\">(.+)<\\/a>", RegexOptions.IgnoreCase);
	private static readonly Regex rex_strip_tag_po = new("<[p][^>]*>", RegexOptions.IgnoreCase);
	private static readonly Regex rex_strip_tag_pc = new("<(\\/)p>", RegexOptions.IgnoreCase);
	private static readonly Regex rex_strip_tag_br = new("<br[^>]*(\\/)?>", RegexOptions.IgnoreCase);

	public void Clean()
	{

	}

	public ReadParam CreateParam(string url)
	{
		var slash = url.LastIndexOf('/') + 1;
		return new ReadParam(url[..slash], Statics.ConvertLong(url[slash..]));
	}

	public void Prepare()
	{
	}

	public void ReadPage(ReadParam param, StreamWriter sw)
	{
		var url = $"{param.BaseUrl}{param.Index}";

		try
		{
			HttpClient hc = new();
			var res = hc.GetStringAsync(url);
			var html = res.Result;

			//
			param.Title = string.Empty;
			var mm = rex_get_title.Match(html);
			if (mm.Groups.Count > 1) param.Title = mm.Groups[1].Value;

			param.Date = string.Empty;
			mm = rex_get_date.Match(html);
			if (mm.Groups.Count > 1) param.Date = mm.Groups[1].Value;

			//
			var bdiv = html.IndexOf("<div class=\"entry-content\">", StringComparison.Ordinal);
			if (bdiv < 0) throw new Exception("시작 지점이 없어요");
			var ediv = html.IndexOf("</div>", bdiv, StringComparison.Ordinal);
			if (ediv < 0) throw new Exception("끝 지점이 없어요");

			var striphtml = html[bdiv..ediv];
			striphtml = rex_strip_tag_po.Replace(striphtml, string.Empty);
			striphtml = rex_strip_tag_pc.Replace(striphtml, "\n");
			striphtml = rex_strip_tag_br.Replace(striphtml, "\n");
			striphtml = rex_strip_tag.Replace(striphtml, string.Empty);
			striphtml = striphtml.
				Replace("\n\n\n", "\n\n").
				Replace("\r\n\r\n\r\n", "\n\n").
				Replace("&nbsp;", string.Empty);
			param.Text = rex_strip_amp.Replace(striphtml, "⊙");

			//
			bdiv = html.IndexOf("<div class=\"another_category another_category_color_gray\">", StringComparison.Ordinal);
			if (bdiv < 0) throw new Exception("시작 지점이 없어요");
			ediv = html.IndexOf("</div>", bdiv, StringComparison.Ordinal);
			if (ediv < 0) throw new Exception("끝 지점이 없어요");

			var nexts = rex_strip_list
				.Matches(html[bdiv..ediv])
				.TakeWhile(m => m.Groups.Count >= 3)
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
