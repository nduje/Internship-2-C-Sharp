namespace Internship_2_C_Sharp
{
    internal class Program
    {
        static int users_number = 3;

        static void Main(string[] args)
        {
            var users = new Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>>()
            {
                {1, new Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>
                    (
                        "Duje",
                        "Dujić",
                        "2000-01-06",
                        new Dictionary<int, Tuple<string, double, double, double, double>>()
                        {
                            { 1, new Tuple<string, double, double, double, double>
                                (
                                    "2025-02-14",
                                    184,
                                    12.3,
                                    1.54,
                                    18.94
                                )
                            }
                        }
                    )
                },
                {2, new Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>
                    (
                        "Marko",
                        "Markić",
                        "1998-11-30",
                        new Dictionary<int, Tuple<string, double, double, double, double>>()
                        {
                            { 2, new Tuple<string, double, double, double, double>
                                (
                                    "2025-03-02",
                                    342,
                                    23.7,
                                    1.52,
                                    36.02
                                )
                            },
                            {
                                3, new Tuple<string, double, double, double, double>
                                (
                                    "2025-04-19",
                                    515,
                                    34.5,
                                    1.57,
                                    54.16
                                )
                            }
                        }
                    )
                },
                { 3, new Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>
                    (
                        "Josip",
                        "Josipović",
                        "1991-06-30",
                        new Dictionary<int, Tuple<string, double, double, double, double>>()
                        {
                            { 4, new Tuple<string, double, double, double, double>
                                (
                                    "2025-06-11",
                                    128,
                                    8.6,
                                    1.49,
                                    12.81
                                )
                            },
                            {
                                5, new Tuple<string, double, double, double, double>
                                (
                                    "2025-11-11",
                                    267,
                                    17.4,
                                    1.56,
                                    27.14
                                )
                            }
                        }
                    )
                }
            };

            Console.WriteLine("APLIKACIJA ZA EVIDENCIJU GORIVA");
            showMainMenu(users);

            static void showMainMenu(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                Console.WriteLine("1 - Korisnici");
                Console.WriteLine("2 - Putovanja");
                Console.WriteLine("0 - Izlaz iz aplikacije");
                Console.WriteLine();

                chooseFromMainMenu(users);
            }

            static void chooseFromMainMenu(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                Console.Write("Odabir: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine();

                    switch (choice)
                    {
                        case 0:
                            return;
                        case 1:
                            showUsersMenu(users);
                            break;
                        case 2:
                            showTripsMenu(users);
                            break;
                        default:
                            Console.WriteLine("Unos nije valjan");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Unos nije valjan");
                }
            }

            static void showUsersMenu(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                Console.WriteLine("1 - Unos novog korisnika");
                Console.WriteLine("2 - Brisanje korisnika");
                Console.WriteLine("3 - Uređivanje korisnika");
                Console.WriteLine("4 - Pregled svih korisnika");
                Console.WriteLine("0 - Povratak na glavni izbornik");
                Console.WriteLine();

                chooseFromUsersMenu(users);
            }

            static void chooseFromUsersMenu(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                Console.Write("Odabir: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine();

                    switch (choice)
                    {
                        case 0:
                            showMainMenu(users);
                            break;
                        case 1:
                            addNewUser(users);
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        default:
                            Console.WriteLine("Unos nije valjan");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Unos nije valjan");
                }
            }

            static void showTripsMenu(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                Console.WriteLine("1 - Unos novog putovanja");
                Console.WriteLine("2 - Brisanje putovanja");
                Console.WriteLine("3 - Uređivanje postojećeg putovanja");
                Console.WriteLine("4 - Pregled svih putovanja");
                Console.WriteLine("5 - Izvještaji i analize");
                Console.WriteLine("0 - Povratak na glavni izbornik");
                Console.WriteLine();

                chooseFromTripsMenu(users);
            }

            static void chooseFromTripsMenu(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                Console.Write("Odabir: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine();

                    switch (choice)
                    {
                        case 0:
                            showMainMenu(users);
                            break;
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        default:
                            Console.WriteLine("Unos nije valjan");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Unos nije valjan");
                }
            }

            static void addNewUser(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                Console.WriteLine("UNOS NOVOG KORISNIKA");

                Console.WriteLine();

                string user_firstname, user_lastname, user_date_of_birth;

                do
                {
                    Console.Write("Unesite ime: ");
                    user_firstname = Console.ReadLine() ?? "";
                } while (string.IsNullOrEmpty(user_firstname));

                do
                {
                    Console.Write("Unesite prezime: ");
                    user_lastname = Console.ReadLine() ?? "";
                } while (string.IsNullOrEmpty(user_lastname));

                do
                {
                    Console.Write("Unesite datum rođenja (YYYY-MM-DD): ");
                    user_date_of_birth = Console.ReadLine() ?? "";
                } while (string.IsNullOrEmpty(user_date_of_birth) || !isDateValid(user_date_of_birth));

                Console.WriteLine();

                users[users_number++] = new Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>
                    (
                        user_firstname,
                        user_lastname,
                        user_date_of_birth,
                        new Dictionary<int, Tuple<string, double, double, double, double>>()
                        {

                        }
                    );

                Console.WriteLine("Dodan novi korisnik");
                Console.WriteLine("");

                showUsersMenu(users);
            }

            static bool isDateValid(string date)
            {
                if (date.Length != 10 && date[4] != '-' && date[7] != '-')
                    return false;

                string string_year = date.Substring(0, 4);
                string string_month = date.Substring(5, 2);
                string string_day = date.Substring(8, 2);

                if (int.TryParse(string_year, out int year) && int.TryParse(string_month, out int month) && int.TryParse(string_day, out int day))
                {
                    if (year <= 2025 && month >= 1 && month <= 12 && day >= 1 && day <= 31)
                        return true;
                }

                return false;
            }
        }
    }
}
