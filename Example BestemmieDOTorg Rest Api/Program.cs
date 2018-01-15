using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;  //Pacchetto nuget per gestione json //http://www.newtonsoft.com/json
namespace Example_BestemmieDOTorg_Rest_Api
{
    class Program
    {

        static string DoGET(string url)
        {
            string response = "";
            try
            {
                WebRequest wGetUrl = WebRequest.Create(url);
                Stream objStream = wGetUrl.GetResponse().GetResponseStream();
                StreamReader stReader = new StreamReader(objStream);
                response = stReader.ReadToEnd();
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore GET: " + ex.Message);
                return null;
            }
        }

       static List<bestemmie> DeserializeBestemmie(string json)
        {
            List<bestemmie> bestList = new List<bestemmie>();
            try
            {
                //Deserializzo la risposta in json della get
                bestList = JsonConvert.DeserializeObject<List<bestemmie>>(json);
                return bestList;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore deserializzazione: " + ex.Message);
                return null;
            }
        }
        static void Main(string[] args)
        {
            /*
             * Bestemmie.org Rest Api example in c#
             * http://www.bestemmie.org/
             * For more about this project visit: http://www.bestemmie.org/bestemmie/about/
             * For the api guideline visit: http://www.bestemmie.org/bestemmie/api_show/
             *
             *
             *
             *      Trafitto 
             * */

            int menu;
            string url = "";
            string r = "";
            List<bestemmie> bestemmia;
            do
            {
                Console.WriteLine("C# Example Bestemmie.org REST API\n\n");
                Console.WriteLine("1- Lista tutte le bestemmie\n2- Bestemmia random\n0- Esci\n\n");
                menu=Convert.ToInt32( Console.ReadLine());
                switch (menu)
                {
                    case 1:
                         url = "http://www.bestemmie.org/api/bestemmie/?format=json"; //Url lista bestemmie 

                        r = DoGET(url);
                        bestemmia = DeserializeBestemmie(r);

                        foreach (bestemmie b in bestemmia)
                        {
                            Console.WriteLine(b.bestemmia_upp);
                            Console.WriteLine(b.bestemmia_low);
                        }
                        Console.WriteLine("");
                        break;
                    case 2:
                        url = "http://www.bestemmie.org/api/bestemmie/random?format=json"; //Url bestemmia random

                        r = DoGET(url);
                        bestemmia = DeserializeBestemmie(r);

                        foreach (bestemmie b in bestemmia)
                        {
                            Console.WriteLine(b.bestemmia_upp);
                            Console.WriteLine(b.bestemmia_low);
                        }
                        Console.WriteLine("");
                        break;
                      

                }


            }
            while (menu != 0);

            Console.WriteLine("Ciao da Bestemmie.org   Riempiamo il mondo di bestemmie!");
           

        }
    }
}
