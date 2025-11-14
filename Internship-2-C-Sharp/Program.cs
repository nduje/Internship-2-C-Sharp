using System.Collections.Concurrent;
using System.Reflection.Metadata;
using System.Transactions;

namespace Internship_2_C_Sharp
{
    internal class Program
    {
        static int users_number = 3;
        static int trips_number = 5;

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
                            { 
                                1, new Tuple<string, double, double, double, double>
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
                            { 
                                2, new Tuple<string, double, double, double, double>
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
                            { 
                                4, new Tuple<string, double, double, double, double>
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
                Console.WriteLine("");

                chooseFromMainMenu(users);
            }

            static void chooseFromMainMenu(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                Console.Write("Odabir: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("");

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
                Console.WriteLine("");

                chooseFromUsersMenu(users);
            }

            static void chooseFromUsersMenu(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                Console.Write("Odabir: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("");

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
                            editUser(users);
                            break;
                        case 4:
                            showUsersListMenu(users);
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
                Console.WriteLine("");

                chooseFromTripsMenu(users);
            }

            static void chooseFromTripsMenu(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                Console.Write("Odabir: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("");

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
                            showTripsListMenu(users);
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

                Console.WriteLine("");

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

                Console.WriteLine("");

                users[++users_number] = new Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>
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

            static void editUser(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                while (true)
                {
                    Console.Write("Odaberite korisnika: (korisnik unosi id) ");

                    if (int.TryParse(Console.ReadLine(), out int user_id))
                    {
                        if (users.ContainsKey(user_id))
                        {
                            string user_firstname, user_lastname, user_date_of_birth;

                            do
                            {
                                Console.Write("Unesite novo ime: ");
                                user_firstname = Console.ReadLine() ?? "";
                            } while (string.IsNullOrEmpty(user_firstname));

                            do
                            {
                                Console.Write("Unesite novo prezime: ");
                                user_lastname = Console.ReadLine() ?? "";
                            } while (string.IsNullOrEmpty(user_lastname));

                            do
                            {
                                Console.Write("Unesite novi datum rođenja (YYYY-MM-DD): ");
                                user_date_of_birth = Console.ReadLine() ?? "";
                            } while (string.IsNullOrEmpty(user_date_of_birth) || !isDateValid(user_date_of_birth));

                            Console.WriteLine("");

                            users[user_id] = new Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>
                                (
                                    user_firstname,
                                    user_lastname,
                                    user_date_of_birth,
                                    users[user_id].Item4
                                );

                            Console.WriteLine("Korisnik ureden");
                            Console.WriteLine("");
                            break;
                        }

                        else
                        {
                            Console.WriteLine("Korisnik ne postoji");
                            Console.WriteLine("");
                        }
                    }

                    else
                    {
                        Console.WriteLine("Unos nije valjan");
                        Console.WriteLine("");
                    }
                }

                showUsersMenu(users);
            }

            static void showUsersListMenu(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                Console.WriteLine("Pregled svih korisnika: ");
                Console.WriteLine("a - Ispis svih korisnika abecedno po prezimenu");
                Console.WriteLine("b - Svih onih koji imaju više od 20 godina");
                Console.WriteLine("c - Svih onih koji imaju barem 2 putovanja");
                Console.WriteLine("");

                chooseFromUsersListMenu(users);
            }

            static void chooseFromUsersListMenu(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                while (true)
                {
                    Console.Write("Odabir: ");

                    if (char.TryParse((Console.ReadLine() ?? "").ToLower(), out char choice))
                    {
                        switch (choice)
                        {
                            case 'a':
                                sortAllUsers(users);
                                break;
                            case 'b':
                                filterUsersOlderThan20(users);
                                break;
                            case 'c':
                                filterUsersWithMinTwoTrips(users);
                                break;
                            default:
                                Console.WriteLine("Unos nije valjan");
                                Console.WriteLine("");
                                break;

                        }
                    }

                    else
                    {
                        Console.WriteLine("Unos nije valjan");
                        Console.WriteLine("");
                    }
                }
            }

            static void sortAllUsers(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                var sortedUsers = users.OrderBy(u => u.Value.Item2).ToDictionary(u => u.Key, u => u.Value);

                listFilteredUsers(sortedUsers);

                showUsersMenu(users);
            }

            static void filterUsersOlderThan20(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                var sortedUsersOlderThan20 = users
                    .OrderBy(u => u.Value.Item2)
                    .Where(u =>
                    {
                        if (DateTime.TryParse(u.Value.Item3, out DateTime birthDate))
                        {
                            DateTime twentyYearsAgo = DateTime.Now.AddYears(-20);

                            return birthDate <= twentyYearsAgo;
                        }

                        return false;
                    } )
                    .ToDictionary(u => u.Key, u => u.Value);

                listFilteredUsers(sortedUsersOlderThan20);

                showUsersMenu(users);
            }

            static void filterUsersWithMinTwoTrips(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                var sortedUsersWithMinTwoTrips = users
                    .OrderBy(u => u.Value.Item2)
                    .Where(u =>
                    {
                        if (u.Value.Item4.Count >= 2)
                        {
                            return true;
                        }

                        return false;
                    })
                    .ToDictionary(u => u.Key, u => u.Value);

                listFilteredUsers(sortedUsersWithMinTwoTrips);

                showUsersMenu(users);
            }

            static void listFilteredUsers(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> sortedUsers)
            {
                Console.WriteLine("");
                Console.WriteLine("{0, -8} {1, -16} {2, -16} {3}", "ID", "Ime", "Prezime", "Datum rođenja");

                foreach (var user in sortedUsers)
                {
                    Console.WriteLine("{0, -8} {1, -16} {2, -16} {3}", user.Key, user.Value.Item1, user.Value.Item2, user.Value.Item3);
                }

                Console.WriteLine("");
            }

            static void showTripsListMenu(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                Console.WriteLine("Pregled svih putovanja: ");
                Console.WriteLine("a - Sva putovanja redom kako su spremljena");
                Console.WriteLine("b - Sva putovanja sortirana po trošku uzlazno");
                Console.WriteLine("c - Sva putovanja sortirana po trošku silazno");
                Console.WriteLine("d - Sva putovanja sortirana po kilometraži uzlazno");
                Console.WriteLine("e - Sva putovanja sortirana po kilometraži silazno");
                Console.WriteLine("f - Sva putovanja sortirana po datumu ulazno");
                Console.WriteLine("g - Sva putovanja sortirana po datumu silazno");
                Console.WriteLine("");

                chooseFromTripsListMenu(users);
            }

            static void chooseFromTripsListMenu(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                while (true)
                {
                    Console.Write("Odabir: ");

                    if (char.TryParse((Console.ReadLine() ?? "").ToLower(), out char choice))
                    {
                        Console.WriteLine("");

                        switch (choice)
                        {
                            case 'a':
                                sortTrips(users);
                                break;
                            case 'b':
                                sortTripsByPriceAscending(users);
                                break;
                            case 'c':
                                sortTripsByPriceDescending(users);
                                break;
                            case 'd':
                                sortTripsByDistanceAscending(users);
                                break;
                            case 'e':
                                sortTripsByDistanceDescending(users);
                                break;
                            case 'f':
                                sortTripsByDateAscending(users);
                                break;
                            case 'g':
                                sortTripsByDateDescending(users);
                                break;
                            default:
                                Console.WriteLine("Unos nije valjan");
                                Console.WriteLine("");
                                break;

                        }
                    }

                    else
                    {
                        Console.WriteLine("Unos nije valjan");
                        Console.WriteLine("");
                    }
                }

                
            }

            static void fetchTrips(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users, List<Tuple<string, double, double, double, double>> all_trips)
            {
                foreach (var user in users)
                {
                    var trips = user.Value.Item4;

                    foreach (var trip in trips)
                    {
                        all_trips.Add(Tuple.Create(trip.Value.Item1, trip.Value.Item2, trip.Value.Item3, trip.Value.Item4, trip.Value.Item5));
                    }
                }
            }

            static void showTrips(List<Tuple<string, double, double, double, double>> trips)
            {
                int trips_counter = 0;

                foreach (var trip in trips)
                {
                    Console.WriteLine("Putovanje #{0}", ++trips_counter);
                    Console.WriteLine("Datum: {0}", trip.Item1);
                    Console.WriteLine("Kilometri: {0}", trip.Item2);
                    Console.WriteLine("Gorivo: {0} L", trip.Item3);
                    Console.WriteLine("Cijena po litri: {0} EUR", trip.Item4);
                    Console.WriteLine("Ukupno: {0} EUR", trip.Item5);
                    Console.WriteLine("");
                }
            }

            static void sortTrips(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                Console.WriteLine("Sva putovanja kako su spremljena:");
                Console.WriteLine("");

                var all_trips = new List<Tuple<string, double, double, double, double>>();

                fetchTrips(users, all_trips);

                showTrips(all_trips);

                showTripsMenu(users);
            }

            static void sortTripsByPriceAscending(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                Console.WriteLine("Sva putovanja sortirana po trošku uzlazno:");
                Console.WriteLine("");

                var all_trips = new List<Tuple<string, double, double, double, double>>();

                fetchTrips(users, all_trips);

                var sorted_trips = all_trips.OrderBy(u => u.Item5).ToList();

                showTrips(sorted_trips);

                showTripsMenu(users);
            }

            static void sortTripsByPriceDescending(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                Console.WriteLine("Sva putovanja sortirana po trošku silazno:");
                Console.WriteLine("");

                var all_trips = new List<Tuple<string, double, double, double, double>>();

                fetchTrips(users, all_trips);

                var sorted_trips = all_trips.OrderByDescending(u => u.Item5).ToList();

                showTrips(sorted_trips);

                showTripsMenu(users);
            }

            static void sortTripsByDistanceAscending(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                Console.WriteLine("Sva putovanja sortirana po kilometraži uzlazno:");
                Console.WriteLine("");

                var all_trips = new List<Tuple<string, double, double, double, double>>();

                fetchTrips(users, all_trips);

                var sorted_trips = all_trips.OrderBy(u => u.Item2).ToList();

                showTrips(sorted_trips);

                showTripsMenu(users);
            }

            static void sortTripsByDistanceDescending(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                Console.WriteLine("Sva putovanja sortirana po kilometraži silazno:");
                Console.WriteLine("");

                var all_trips = new List<Tuple<string, double, double, double, double>>();

                fetchTrips(users, all_trips);

                var sorted_trips = all_trips.OrderByDescending(u => u.Item2).ToList();

                showTrips(sorted_trips);

                showTripsMenu(users);
            }

            static void sortTripsByDateAscending(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                Console.WriteLine("Sva putovanja sortirana po kilometraži silazno:");
                Console.WriteLine("");

                var all_trips = new List<Tuple<string, double, double, double, double>>();

                fetchTrips(users, all_trips);

                var sorted_trips = all_trips.OrderBy(u => u.Item1).ToList();

                showTrips(sorted_trips);

                showTripsMenu(users);
            }

            static void sortTripsByDateDescending(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                Console.WriteLine("Sva putovanja sortirana po kilometraži silazno:");
                Console.WriteLine("");

                var all_trips = new List<Tuple<string, double, double, double, double>>();

                fetchTrips(users, all_trips);

                var sorted_trips = all_trips.OrderByDescending(u => u.Item1).ToList();

                showTrips(sorted_trips);

                showTripsMenu(users);
            }
        }
    }
}
