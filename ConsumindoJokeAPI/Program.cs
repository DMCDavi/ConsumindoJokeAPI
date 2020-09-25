using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace ConsumindoJokeAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CONSUMINDO UMA API DE PIADAS");
            Console.WriteLine("PUT ON A HAPPY FACE");
            Console.WriteLine("=====================================================");

            Console.WriteLine("Escreva as categorias de piadas que você gostaria de ver, separando-as com vírgulas (Programming,Miscellaneous,Dark,Pun) ou deixe em braco para qualquer uma: ");
            string categories = Console.ReadLine();

            if (String.IsNullOrEmpty(categories))
                categories = "Any";

            Console.WriteLine("Escreva os tipos de piadas que você NÃO gostaria de ver, separando-as com vírgulas (nsfw,religious,political,racist,sexist) ou deixe em branco caso não se importe: ");
            string flags = Console.ReadLine();

            if (!String.IsNullOrEmpty(flags))
                flags = "?blacklistFlags=" + flags;

            GetJoke(categories, flags);
            Console.ReadKey();
        }

        /// <summary>
        /// Busca uma piada na JokeAPI
        /// </summary>
        /// <param name="categories">Categorias de piadas que desejam ser vistas</param>
        /// <param name="flags">Tipos de piadas que não desejam ser vistas</param>
        public static async void GetJoke(string categories, string flags)
        {
            HttpClient httpClient = new HttpClient();

            string url = $"https://sv443.net/jokeapi/v2/joke/{categories}{flags}";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            HttpResponseMessage response = await httpClient.SendAsync(request);
            string dados = await response.Content.ReadAsStringAsync();

            Joke joke = JsonConvert.DeserializeObject<Joke>(dados);

            PrintJoke(joke);
        }

        /// <summary>
        /// Imprime a piada e sua categoria
        /// </summary>
        /// <param name="joke">Objeto da piada recebido pelo JokeAPI</param>
        private static void PrintJoke(Joke joke)
        {
            if (joke.error)
            {
                Console.WriteLine($"Ocorreu um erro ao buscar a piada ;-;");
                Console.WriteLine($"Mensagem de erro: {joke.message}");
            }
            else
            {
                Console.WriteLine($"Categoria: {joke.category}");

                if (joke.type == "single")
                    Console.WriteLine(joke.joke);
                else
                {
                    Console.WriteLine(joke.setup);
                    Console.WriteLine(joke.delivery);
                }

                Console.WriteLine("HAHAHHAA QUE ENGRAÇADO");
            }

        }
    }
}
