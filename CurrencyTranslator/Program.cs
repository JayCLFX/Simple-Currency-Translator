namespace CurrencyTranslator
{
    public class Program
    {
        static void Main(string[] args)
        {
            State();
        }

        public static void State()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Currency Translator\n\n 1. Show all Currencys\n 2. Make a Conversion\n 3. Get All from Currency ");
            Console.ForegroundColor = ConsoleColor.White;
            var answer = Console.ReadLine();
            switch (answer)
            {
                case "1":
                Console.Clear(); var task1 = Task.Run((Func<Task>)Library.GetCurrencys); task1.Wait(); break;
                case "2":
                Console.Clear(); var task2 = Task.Run((Func<Task>)Library.GetTranslation); task2.Wait(); break;
                case "3":
                Console.Clear(); var task3 = Task.Run((Func<Task>)Library.GetFromCurrency); task3.Wait(); break;
            }
            State();
        }
    }
}
