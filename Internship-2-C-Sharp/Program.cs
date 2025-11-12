namespace Internship_2_C_Sharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void showMainMenu()
            {
                Console.WriteLine("1 - Korisnici");
                Console.WriteLine("2 - Putovanja");
                Console.WriteLine("0 - Izlaz iz aplikacije");
                Console.WriteLine();

                chooseFromMainMenu();
            }

            static void chooseFromMainMenu()
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
                            showUsersMenu();
                            break;
                        case 2:
                            showTripsMenu();
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

            static void showUsersMenu()
            {
                Console.WriteLine("1 - Unos novog korisnika");
                Console.WriteLine("2 - Brisanje korisnika");
                Console.WriteLine("3 - Uređivanje korisnika");
                Console.WriteLine("4 - Pregled svih korisnika");
                Console.WriteLine("0 - Povratak na glavni izbornik");
                Console.WriteLine();

                chooseFromUsersMenu();
            }

            static void chooseFromUsersMenu()
            {
                Console.Write("Odabir: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine();

                    switch (choice)
                    {
                        case 0:
                            showMainMenu();
                            break;
                        case 1:
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

            static void showTripsMenu()
            {
                Console.WriteLine("1 - Unos novog putovanja");
                Console.WriteLine("2 - Brisanje putovanja");
                Console.WriteLine("3 - Uređivanje postojećeg putovanja");
                Console.WriteLine("4 - Pregled svih putovanja");
                Console.WriteLine("5 - Izvještaji i analize");
                Console.WriteLine("0 - Povratak na glavni izbornik");
                Console.WriteLine();

                chooseFromTripsMenu();
            }

            static void chooseFromTripsMenu()
            {
                Console.Write("Odabir: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine();

                    switch (choice)
                    {
                        case 0:
                            showMainMenu();
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
            showMainMenu();
        }
    }
}
