// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string url = "https://www2.san.gva.es/bolsa/lstCandidatosListaOperativa.jsp";
HttpClient client = new HttpClient();

var values = new Dictionary<string, string>
{
    {"codedicion", "19.0.7.0" },
    {"turnoCode","O" },
    {"departamentoCod", "ALY" },
    {"categoriaCod", "0001" },
    {"turnoDesc", "Ordinari" },
    {"categoriaDesc", "ENGINYER D'APLICACIONS I SISTEMES" },
    {"departamentoDesc", "ALCOY" },
    {"posicionFinal", "50" },
    {"posicionInicial", "1" },
    {"nw", "true" },
    {"titulo", "Reedició de les llistes d`ocupació temporal de l`edició 19.0.7 (resolución recursos i correccions). Publicació i entrada en vigor 13/01/2023." }
};

var content = new FormUrlEncodedContent(values);

var response = await client.PostAsync(url, content);

var responseString = await response.Content.ReadAsStringAsync();

var subString = responseString.Substring(responseString.IndexOf("<table"));

HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
doc.LoadHtml(subString);

List<List<string>> table = doc.DocumentNode.SelectSingleNode("//table")
            .Descendants("tr")
            .Skip(1)
            .Where(tr => tr.Elements("td").Count() > 1)
            .Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList())
            .ToList();

var asd = "";