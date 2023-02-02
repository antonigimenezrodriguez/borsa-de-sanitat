using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace BorsaSanitat
{
    public static class Constantes
    {
        public const string URL_SITUACIO = "https://www2.san.gva.es/bolsa/intervalosSituacionCandidatos.jsp";
        public const string URL_PUNTUACIO = "https://www2.san.gva.es/bolsa/lstCandidatosListaOperativa.jsp";
    }

    public static class Utils
    {
        public static List<List<string>> HtmlTable2List(string html)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            List<List<string>> table = doc.DocumentNode.SelectSingleNode("//table")
                        .Descendants("tr")
                        .Skip(1)
                        .Where(tr => tr.Elements("td").Count() > 1)
                        .Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList())
                        .ToList();
            return table;
        }

        public static async Task<string> realizarDescargaWeb(string url, Dictionary<string, string> values)
        {
            HttpClient client = new HttpClient();
            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync(url, content);

            return await response.Content.ReadAsStringAsync();
        }
    }


}
