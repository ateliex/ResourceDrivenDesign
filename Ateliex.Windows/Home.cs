using Ateliex.Cadastro.Modelos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Xml;

namespace Ateliex
{
    public class HomeResource : Resource
    {
        public Uri CadastroUri { get; set; }

        public Uri DecisoesUri { get; set; }

        public HomeResource()
        {
            CadastroUri = new Uri("/cadastro", UriKind.Relative);
        }

        public CadastroResource GetCadastro()
        {
            var httpResponse = httpClient.GetAsync(CadastroUri).Result;

            var result = httpResponse.Content.ReadAsStringAsync().Result;

            var xml = new XmlDocument();

            xml.Load(httpResponse.Content.ReadAsStreamAsync().Result);

            var menu = xml.SelectSingleNode("//div[contains(@class,'menu')]");

            var modelosHRef = menu.SelectSingleNode("a[@rel='modelos']").Attributes["href"].Value;

            var resource = new CadastroResource
            {
                ModelosUri = new Uri(modelosHRef, UriKind.Relative)
            };

            return resource;
        }
    }

    public class CadastroResource : Resource
    {
        public Uri ModelosUri { get; set; }

        public ModelosResource GetModelos()
        {
            var resource = new ModelosResource();

            var httpResponse = httpClient.GetAsync(ModelosUri).Result;

            var result = httpResponse.Content.ReadAsStringAsync().Result;

            var xml = new XmlDocument();

            xml.Load(httpResponse.Content.ReadAsStreamAsync().Result);

            var itens = xml.SelectNodes("//tr[@class='resource']");

            foreach (XmlNode item in itens)
            {
                var codigo = item.SelectSingleNode("td[@class='Codigo']").InnerText;

                var nome = item.SelectSingleNode("td[@class='Nome']").InnerText;

                var custoDeProducao = Convert.ToDecimal(item.SelectSingleNode("td[@class='CustoDeProducao']").InnerText);

                resource.Add(new ModeloResource { Codigo = codigo, Nome = nome, CustoDeProducao = custoDeProducao });
            }

            return resource;
        }
    }
}
