using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FifaGuide.Services
{
    public class ApiCall
    {
        static readonly string ApiUrl = "http://tools.fifaguide.com/api/{0}/{1}";


        public async Task<T> GetResponse<T>(string method, string param) where T : class
        {

            var client = new System.Net.Http.HttpClient();

            //Definide o Header de resultado para JSON, para evitar que seja retornado um HTML ou XML
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Formata a Url com o metodo e o parametro enviado e inicia o acesso a Api. Como o acesso será por meio
            //da Internet, pode demorar muito, para que o aplicativo não trave usamos um método assincrono
            //e colocamos a keyword AWAIT, para que a Thread principal - UI - continuo sendo executada
            //e o método so volte a ser executado quando o download das informações for finalizado
            var response = await client.GetAsync(string.Format(ApiUrl, method, param));

            //Lê a string retornada
            var JsonResult = response.Content.ReadAsStringAsync().Result;

            if (typeof(T) == typeof(string))
                return null;

            //Converte o resultado Json para uma Classe utilizando as Libs do Newtonsoft.Json
            var rootobject = JsonConvert.DeserializeObject<T>(JsonResult);

            return rootobject;
        }
    }
}
