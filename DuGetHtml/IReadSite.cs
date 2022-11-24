namespace DuGetHtml;

internal interface IReadSite
{
	void Prepare();
	void Clean();
	void ReadPage(ReadParam param, StreamWriter sw);
	ReadParam CreateParam(string url);
}
