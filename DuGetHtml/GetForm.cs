using System.Text;

namespace DuGetHtml;

// 블로그에서 책추출
public partial class GetForm : Form
{
	public GetForm()
	{
		InitializeComponent();

#if DEBUG
		UrlText.Text = "https://viorate.tistory.com/576";
		//UrlText.Text = "https://m.blog.naver.com/sluck11315/221790530712";
#endif

		SiteCombo.SelectedIndex = 0;
	}

	private async void LetGoButton_Click(object sender, EventArgs e)
	{
		var url = UrlText.Text;

		if (url.Length == 0)
		{
			TextText.Text = @"URL이 없다!";
			return;
		}

		IReadSite? rs;

		if (url.Contains("/viorate.tistory.com"))
		{
			SiteCombo.SelectedIndex = 1;
			rs = new ReadSiteViorate();
		}
		else if (url.Contains("/m.blog.naver.com"))
		{
			SiteCombo.SelectedIndex = 2;
			rs = new ReadSiteNaverBlog();
		}
		else
		{
			SiteCombo.SelectedIndex = 0;
			TextText.Text = @"지금은 안되는 곳이예여!";
			return;
		}

		LetGoButton.Enabled = false;
		WorkList.Items.Clear();

		var bookname = NameText.Text;
		if (bookname.Length == 0)
			bookname = "du";

		ReadParam param = rs.CreateParam(url);

		await Task.Run(() =>
		{
			string outputfilename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"{bookname}.txt");
			using StreamWriter sw = new(outputfilename, false, Encoding.UTF8);

			rs.Prepare();

			while (true)
			{
#if DEBUG
				if (param.Count > 5) break;
#endif

				param.Count++;
				Invoke(new Action(() => CountText.Text = param.Count.ToString()));

				param.BeforeRead();
				rs.ReadPage(param, sw);
				param.AfterRead(sw);

				Invoke(() =>
				{
					TextText.Text = param.Text;
					WorkList.Items.Add($"{param.Index} → {param.Title}");
					WorkList.TopIndex = WorkList.Items.Count - 1;
				});

				if (param.NextIndex < 0) break;

				param.Index = param.NextIndex;
				Thread.Sleep(20);
			}

			rs.Clean();
		});

		LetGoButton.Enabled = true;
	}
}

