namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Utente.userOptions();
            Console.ReadLine();
        }

        public static List<DateTime> logs = new List<DateTime>();
        public static class Utente
        {
            public static string userData = "francesco";
            public static string userPass = "1234";
            public static string username = "";
            public static string password = "";

            public static bool isUserLogged = false;
            public static DateTime dataLogin;

            public static void Login()
            {
                if (!isUserLogged)
                {
                    Console.WriteLine("Inserisci il tuo username:");
                    Utente.username = Console.ReadLine();
                    Console.WriteLine("Inserisci la tua password:");
                    Utente.password = Console.ReadLine();
                    Console.WriteLine("Conferma la password:");
                    string passwordCheck = Console.ReadLine();

                    if (Utente.password == passwordCheck && Utente.username == Utente.userData && Utente.password == Utente.userPass)
                    {
                        isUserLogged = true;
                        dataLogin = DateTime.Now;
                        logs.Add(dataLogin);
                        Console.Clear();
                        Console.WriteLine($"L'utente {userData} è correttamente loggato - {dataLogin}");
                    }
                    else
                    {
                        Console.WriteLine("Si è verificato un'errore durante il login");
                    }
                }
                else
                {
                    Console.WriteLine($"L'utente {username} è già loggato");
                }
            }

            public static void Logout()
            {   
                if (username != "")
                {
                    username = "";
                    password = "";
                    isUserLogged = false;
                    Console.WriteLine("Hai effettuato il logout correttamente");
                }
                else
                {
                    isUserLogged = false;
                    Console.WriteLine("Nessun utente è loggato al momento");
                }
            }

            public static void StampLoginDateTime()
            {
                if (isUserLogged)
                {
                    Console.WriteLine($"L'utente {username} ha loggato il {dataLogin}");
                }
                else
                {
                    Console.WriteLine("L'utente non è loggato in questo momento");
                }
                
            }
            public static void StampAllLoginDateTime()
            {
                if (logs.Count > 0)
                {
                    Console.WriteLine("Lista logs:");
                    logs.ForEach(log =>
                    {
                        Console.WriteLine($"{username} ha loggato il {log}");
                    });
                }
                else
                {
                    Console.WriteLine("L'utente non ha mai loggato fin'ora");
                }
            }

            public static void userOptions()
            {
                Console.WriteLine("");
                Console.WriteLine("***** OPERAZIONI ***** \n");
                Console.WriteLine("Scegli l'operazione da effettuare: \n 1. Login \n 2. Logout \n 3. Verifica la data di login \n 4. Mostra la lista della date di login \n 5. Chiudi l'applicazione");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Clear();
                        Utente.Login();
                        userOptions();
                        break;
                    case "2":
                        Console.Clear();
                        Utente.Logout();
                        userOptions();
                        break;
                    case "3":
                        Console.Clear();
                        Utente.StampLoginDateTime();
                        userOptions();
                        break;
                    case "4":
                        Console.Clear();
                        Utente.StampAllLoginDateTime();
                        userOptions();
                        break;
                    case "5":
                        Console.WriteLine("Premi invio due volte per chiudere l'applicazione");
                        break;
                    default:
                        Console.WriteLine("Scelta non valida");
                        userOptions();
                        break;
                }

            }
        }

    }
}