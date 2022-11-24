using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace DuGetHtml;

internal class ReadSiteNaverBlog : IReadSite
{
	private IWebDriver? _drv;


	public void Clean()
	{
		_drv?.Quit();
	}

	public void Prepare()
	{
		_drv = new EdgeDriver();
	}

	public ReadParam CreateParam(string url)
	{
		var slash = url.LastIndexOf('/') + 1;
		return new ReadParam(url[..slash], Statics.ConvertLong(url[slash..]));
	}

	public void ReadPage(ReadParam param, StreamWriter sw)
	{
		if (_drv == null) return;

		var url = $"{param.BaseUrl}{param.Index}";

		_drv.Navigate().GoToUrl(url);
		_drv.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

		//
		param.Title = _drv.Title;
		var n = param.Title.IndexOf(" : 네이버 블로그", StringComparison.Ordinal);
		if (n >= 0)
			param.Title = param.Title[..n];

		var blogdate = _drv.FindElement(By.ClassName("blog_date"));
		if (blogdate != null)
			param.Date = blogdate.Text;

		//
		var semtext = _drv.FindElement(By.CssSelector("div.se-main-container"));
		if (semtext != null)
			param.Text = semtext.Text;

		//
		var postlist = _drv.FindElement(By.CssSelector("div.wrap_postlist"));
		if (postlist == null) 
			return;

		List<long> nexts = new();
		var afs = postlist.FindElements(By.CssSelector("a.link"));
		foreach (var a in afs)
		{
			try
			{
				var href = a.GetAttribute("href");
				var logat = href.IndexOf("logNo", StringComparison.Ordinal) + 6;
				var logno = href[logat..];
				var item = Statics.ConvertLong(logno);

				if (item > param.Index) nexts.Add(item);
			}
			catch
			{
				// ignored
			}
		}

		if (nexts.Count <= 0) 
			return;

		nexts.Sort();
		param.NextIndex = nexts[0];
	}
}
