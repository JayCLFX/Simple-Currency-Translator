using Newtonsoft.Json.Linq;
using System.Net;

namespace CurrencyTranslator
{
    public class Library
    {
        public static string Base_Currency = null;
        public static string Translate_Currency = null;
        public static string Ammount = null;

        public static WebClient webClient = new WebClient();

        public static async Task GetCurrencys()
        {
            try
            {
                Base_Currency = null;
                Translate_Currency = null;
                Ammount = null;

                string translation_json = null;
                dynamic translation_data = null;
                translation_json = webClient.DownloadString($"https://api.frankfurter.app/currencies");
                translation_data = JObject.Parse(translation_json);
                Console.WriteLine(translation_data);

                Console.ForegroundColor= ConsoleColor.Yellow;
                Console.WriteLine("\n\n Press any Key to Continue!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine(); Console.Clear(); return;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"An Error Occured:   {ex.Message}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static async Task GetTranslation()
        {
            try
            {
                Base_Currency = null;
                Translate_Currency = null;
                Ammount = null;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("State youre own Currency: (EUR/USD,etc)\n");
                Console.ForegroundColor = ConsoleColor.White;
                Base_Currency = Console.ReadLine(); Console.Clear();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("State the Currency you wanna convert to:  (EUR/USD,etc)\n");
                Console.ForegroundColor = ConsoleColor.White;
                Translate_Currency = Console.ReadLine(); Console.Clear();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("State the Amount you wann convert from youre own Currency to the other Currency:");
                Console.ForegroundColor = ConsoleColor.White;
                Ammount = Console.ReadLine(); Console.Clear();

                string translation_json = null;
                dynamic translation_data = null;
                translation_json = webClient.DownloadString($"https://api.frankfurter.app/latest?amount={Ammount}&from={Base_Currency}&to={Translate_Currency}");
                translation_data = JObject.Parse(translation_json);
                var data = translation_data.rates;
                Console.WriteLine(data);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\n Press any Key to Continue!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine(); Console.Clear(); return;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"An Error Occured:   {ex.Message}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static async Task GetFromCurrency()
        {
            try
            {
                Base_Currency = null;
                Translate_Currency = null;
                Ammount = null;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("State the Currency you wanna search for: (EUR/USD,etc)\n");
                Console.ForegroundColor = ConsoleColor.White;
                Base_Currency = Console.ReadLine(); Console.Clear();

                string translation_json = null;
                dynamic translation_data = null;
                translation_json = webClient.DownloadString($"https://api.frankfurter.app/latest?from={Base_Currency}");
                translation_data = JObject.Parse(translation_json);
                var data = translation_data.rates;
                Console.WriteLine(data);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\n Press any Key to Continue!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine(); Console.Clear(); return;
            }
            catch (Exception ex )
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"An Error Occured:   {ex.Message}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

    }
}
