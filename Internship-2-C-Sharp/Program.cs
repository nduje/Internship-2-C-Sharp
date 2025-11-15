using System.Collections.Concurrent;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
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
                        "Dujic",
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
                        "Markic",
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
                        "Josipovic",
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
            chooseFromMainMenu(users);

            static void showMainMenu()
            {
                Console.WriteLine("1 - Korisnici");
                Console.WriteLine("2 - Putovanja");
                Console.WriteLine("3 - Statistika");
                Console.WriteLine("0 - Izlaz iz aplikacije");
                Console.WriteLine("");
            }

            static void chooseFromMainMenu(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                bool isOver = true;

                while (isOver)
                {
                    Console.WriteLine("");

                    showMainMenu();

                    Console.Write("Odabir: ");

                    if (int.TryParse(Console.ReadLine(), out int choice))
                    {
                        switch (choice)
                        {
                            case 0:
                                isOver = true;
                                return;
                            case 1:
                                chooseFromUsersMenu(users);
                                break;
                            case 2:
                                chooseFromTripsMenu(users);
                                break;
                            case 3:
                                chooseFromStatsMenu(users);
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
            }

            static void showUsersMenu()
            {
                Console.WriteLine("1 - Unos novog korisnika");
                Console.WriteLine("2 - Brisanje korisnika");
                Console.WriteLine("3 - Uređivanje korisnika");
                Console.WriteLine("4 - Pregled svih korisnika");
                Console.WriteLine("0 - Povratak na glavni izbornik");
                Console.WriteLine("");
            }

            static void chooseFromUsersMenu(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                bool isOver = true;

                while (isOver)
                {
                    Console.WriteLine("");

                    showUsersMenu();

                    Console.Write("Odabir: ");

                    if (int.TryParse(Console.ReadLine(), out int choice))
                    {                        
                        switch (choice)
                        {
                            case 0:
                                isOver = false;
                                break;
                            case 1:
                                addNewUser(users);
                                break;
                            case 2:
                                chooseFromDeleteUsersMenu(users);
                                break;
                            case 3:
                                editUser(users);
                                break;
                            case 4:
                                chooseFromUsersListMenu(users);
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
            }

            static void showTripsMenu()
            {
                Console.WriteLine("1 - Unos novog putovanja");
                Console.WriteLine("2 - Brisanje putovanja");
                Console.WriteLine("3 - Uređivanje postojećeg putovanja");
                Console.WriteLine("4 - Pregled svih putovanja");
                Console.WriteLine("5 - Izvještaji i analize");
                Console.WriteLine("0 - Povratak na glavni izbornik");
                Console.WriteLine("");
            }

            static void chooseFromTripsMenu(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                bool isOver = true;

                while (isOver)
                {
                    Console.WriteLine("");

                    showTripsMenu();

                    Console.Write("Odabir: ");

                    if (int.TryParse(Console.ReadLine(), out int choice))
                    {
                        switch (choice)
                        {
                            case 0:
                                isOver = false;
                                break;
                            case 1:
                                checkAddNewTrip(users);
                                break;
                            case 2:
                                chooseFromDeleteTripsMenu(users);
                                break;
                            case 3:
                                editTrip(users);
                                break;
                            case 4:
                                chooseFromTripsListMenu(users);
                                break;
                            case 5:
                                checkTripsReport(users);
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
            }

            static void showStatsMenu()
            {
                Console.WriteLine("1 - Korisnik s najvećim ukupnim troškom goriva");
                Console.WriteLine("2 - Korisnik s najviše putovanja");
                Console.WriteLine("3 - Prosječan broj putovanja po korisniku");
                Console.WriteLine("4 - Ukupan broj prijeđenih kilometara svih korisnika");
                Console.WriteLine("0 - Povratak na glavni izbornik");
                Console.WriteLine("");
            }

            static void chooseFromStatsMenu(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                bool isOver = true;

                while (isOver)
                {
                    Console.WriteLine("");

                    showStatsMenu();

                    Console.Write("Odabir: ");

                    if (int.TryParse(Console.ReadLine(), out int choice))
                    {
                        switch (choice)
                        {
                            case 0:
                                isOver = false;
                                break;
                            case 1:
                                showUserWithHighestFuelCost(users);
                                break;
                            case 2:
                                showUserWithMostTrips(users);
                                break;
                            case 3:
                                showAverageTripsPerUser(users);
                                break;
                            case 4:
                                showTotalDistance(users);
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
            }

            static void addNewUser(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                Console.WriteLine("");
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

                Console.WriteLine("Dodan novi korisnik {0} {1} ({2})", user_firstname, user_lastname, users_number);
            }

            static bool isDateValid(string date)
            {
                if (date.Length != 10 || date[4] != '-' || date[7] != '-')
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

            static void showDeleteUsersMenu()
            {
                Console.WriteLine("Brisanje korisnika:");
                Console.WriteLine("a - Po ID-u");
                Console.WriteLine("b - Po imenu i prezimenu");
                Console.WriteLine("");
            }

            static void chooseFromDeleteUsersMenu(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                bool isOver = true;

                while (isOver)
                {
                    if (!users.Any())
                    {
                        Console.WriteLine("Ne postoji niti jedan korisnik u memoriji");
                        Console.WriteLine("");
                        break;
                    }

                    Console.WriteLine("");

                    showDeleteUsersMenu();

                    Console.Write("Odabir: ");

                    if (char.TryParse((Console.ReadLine() ?? "").ToLower(), out char choice))
                    {
                        switch (choice)
                        {
                            case 'a':
                                deleteUserById(users);
                                isOver = false;
                                break;
                            case 'b':
                                deleteUserByName(users);
                                isOver = false;
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
            }

            static bool checkInput()
            {
                string input = "";

                while (true)
                {
                    input = Console.ReadLine()?.Trim().ToLower() ?? "";

                    if (input == "da" || input == "ne")
                        break;

                    else
                    {
                        Console.Write("Unos nije valjan, ponovite upis (DA/NE) ");
                        continue;
                    }
                }
;
                Console.WriteLine("");

                if (input == "da")
                    return true;

                else return false;
            }

            static void deleteUserById(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                Console.WriteLine("");
                Console.WriteLine("BRISANJE POSTOJEĆEG KORISNIKA PO IDENTIFIKATORU");
                Console.WriteLine("");

                while (true)
                {
                    Console.Write("Odaberite korisnika (unesite ID): ");

                    if (int.TryParse(Console.ReadLine(), out int user_id))
                    {
                        if (users.ContainsKey(user_id))
                        {
                            string first_name = users[user_id].Item1;
                            string last_name = users[user_id].Item2;

                            Console.WriteLine("");
                            Console.Write("Jeste li sigurni da želite obrisati korisnika {0} {1} ({2})? (DA/NE) ", first_name, last_name, user_id);

                            if (checkInput())
                            {
                                users.Remove(user_id);

                                Console.WriteLine("Korisnik {0} {1} ({2}) je obrisan", first_name, last_name, user_id);
                            }

                            else
                            {
                                Console.WriteLine("Brisanje korisnika {0} {1} ({2}) je prekinuto", first_name, last_name, user_id);
                            }

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
            }

            static void deleteUserByName(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                Console.WriteLine("");
                Console.WriteLine("BRISANJE POSTOJEĆEG KORISNIKA PO IMENU I PREZIMENU");
                Console.WriteLine("");

                string full_name = "";
                bool isOver = false;

                do
                {
                    Console.Write("Odaberite korisnika (unesite ime i prezime): ");
                    full_name = (Console.ReadLine() ?? "").Trim();

                    if (string.IsNullOrEmpty(full_name) || !full_name.All(c => char.IsLetter(c) || c == ' '))
                    {
                        Console.WriteLine("Unos nije valjan");
                        Console.WriteLine("");
                        continue;
                    }

                    foreach (var user in users)
                    {
                        string first_name = user.Value.Item1;
                        string last_name = user.Value.Item2;
                        int user_id = user.Key;

                        if (full_name.ToLower().Equals(first_name.ToLower() + " " + last_name.ToLower()))
                        {
                            Console.WriteLine("");
                            Console.Write("Jeste li sigurni da želite obrisati korisnika {0} {1} ({2})? (DA/NE) ", first_name, last_name, user_id);

                            if (checkInput())
                            {
                                users.Remove(user_id);
                                Console.WriteLine("Korisnik {0} {1} ({2}) je obrisan", first_name, last_name, user_id);
                            }

                            else
                            {
                                Console.WriteLine("Brisanje korisnika {0} {1} ({2}) je prekinuto", first_name, last_name, user_id);
                            }

                            isOver = true;
                            break;
                        }
                    }

                    if (!isOver)
                    {
                        Console.WriteLine("Korisnik ne postoji");
                        Console.WriteLine("");
                    }
                } while (!isOver);
            }

            static void editUser(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                Console.WriteLine("");
                Console.WriteLine("UREĐIVANJE POSTOJECEG KORISNIKA PO IDENTIFIKATORU");
                Console.WriteLine("");

                while (true)
                {
                    Console.Write("Odaberite korisnika (unesite ID): ");

                    if (int.TryParse(Console.ReadLine(), out int user_id))
                    {
                        if (users.ContainsKey(user_id))
                        {
                            string user_firstname, user_lastname, user_date_of_birth;

                            Console.WriteLine("");
                            Console.WriteLine("Ureduje se korisnik {0} {1} ({2})", users[user_id].Item1, users[user_id].Item2, user_id);
                            Console.WriteLine("");

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
                            Console.Write("Jeste li sigurni da želite urediti dosadašnjeg korisnika {0} {1} ({2})? (DA/NE) ", users[user_id].Item1, users[user_id].Item2, user_id);

                            if (checkInput())
                            {
                                users[user_id] = new Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>
                                (
                                    user_firstname,
                                    user_lastname,
                                    user_date_of_birth,
                                    users[user_id].Item4
                                );

                                Console.WriteLine("Korisnik {0} {1} ({2}) je ureden", user_firstname, user_lastname, user_id);
                            }

                            else
                            {
                                Console.WriteLine("Uređivanje korisnika {0} {1} ({2}) je prekinuto", users[user_id].Item1, users[user_id].Item2, user_id);
                            }

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
            }

            static void showUsersListMenu()
            {
                Console.WriteLine("Pregled svih korisnika: ");
                Console.WriteLine("a - Ispis svih korisnika abecedno po prezimenu");
                Console.WriteLine("b - Svih onih koji imaju više od 20 godina");
                Console.WriteLine("c - Svih onih koji imaju barem 2 putovanja");
                Console.WriteLine("");
            }

            static void chooseFromUsersListMenu(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                bool isOver = true;

                while (isOver)
                {
                    Console.WriteLine("");

                    showUsersListMenu();

                    Console.Write("Odabir: ");

                    if (char.TryParse((Console.ReadLine() ?? "").ToLower(), out char choice))
                    {
                        switch (choice)
                        {
                            case 'a':
                                sortAllUsers(users);
                                isOver = false;
                                break;
                            case 'b':
                                filterUsersOlderThan20(users);
                                isOver = false;
                                break;
                            case 'c':
                                filterUsersWithMinTwoTrips(users);
                                isOver = false;
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
            }

            static void sortAllUsers(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                var sortedUsers = users.OrderBy(u => u.Value.Item2).ToDictionary(u => u.Key, u => u.Value);

                Console.WriteLine("");
                Console.WriteLine("Prikaz svih korisnika abecedno po prezimenu:");
                listFilteredUsers(sortedUsers);
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

                Console.WriteLine("");
                Console.WriteLine("Prikaz svih onih korisnika koji imaju više od 20 godina:");
                listFilteredUsers(sortedUsersOlderThan20);
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

                Console.WriteLine("");
                Console.WriteLine("Prikaz svih onih korisnika koji imaju barem 2 putovanja:");
                listFilteredUsers(sortedUsersWithMinTwoTrips);
            }

            static void listFilteredUsers(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> sortedUsers)
            {
                Console.WriteLine("{0, -8} {1, -16} {2, -16} {3}", "ID", "Ime", "Prezime", "Datum rođenja");

                foreach (var user in sortedUsers)
                {
                    Console.WriteLine("{0, -8} {1, -16} {2, -16} {3}", user.Key, user.Value.Item1, user.Value.Item2, user.Value.Item3);
                }
            }

            static void checkAddNewTrip(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                bool isOver = true;

                while (isOver)
                {
                    Console.Write("Unesi ID korisnika kojem želiš dodati novo putovanje: ");

                    if (int.TryParse(Console.ReadLine(), out int user_id))
                    {
                        if (isUserValid(users, user_id))
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Odabran je korisnik {0} {1} ({2})", users[user_id].Item1, users[user_id].Item2, user_id);
                            addNewTrip(users, user_id);
                            isOver = false;
                        }

                        else
                        {
                            Console.WriteLine("Korisnik s ID-em {0} ne postoji", user_id);
                            Console.WriteLine("");
                        }
                    }

                    else
                    {
                        Console.WriteLine("Unos nije valjan");
                        Console.WriteLine("");
                    }
                }
            }

            static void addNewTrip(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users, int user_id)
            {
                Console.WriteLine("");
                Console.WriteLine("UNOS NOVOG PUTOVANJA");
                Console.WriteLine("");

                double distance, fuel_consumption, fuel_cost, total_fuel_cost;
                string trip_date;

                do
                {
                    Console.Write("Unesite datum putovanja (YYYY-MM-DD): ");
                    trip_date = Console.ReadLine() ?? "";
                } while (string.IsNullOrEmpty(trip_date) || !isDateValid(trip_date));

                while(true)
                {
                    Console.Write("Unesite prijeđenu kilometražu: ");
                    if (double.TryParse(Console.ReadLine(), out distance) && distance > 0)
                        break;
                    Console.Write("Unos nije valjan");
                }

                while (true)
                {
                    Console.Write("Unesite količinu potrošenog goriva: ");
                    if (double.TryParse(Console.ReadLine(), out fuel_consumption) && fuel_consumption > 0)
                        break;
                    Console.WriteLine("Unos nije valjan");
                }

                while (true)
                {
                    Console.Write("Unesite cijenu goriva po litri: ");
                    if (double.TryParse(Console.ReadLine(), out fuel_cost) && fuel_cost > 0)
                        break;
                    Console.WriteLine("Unos nije valjan");
                }

                total_fuel_cost = calculateTotalFuelCost(fuel_consumption, fuel_cost);

                Console.WriteLine("");

                var user_trips = users[user_id].Item4;
                var new_trip = Tuple.Create(trip_date, distance, fuel_consumption, fuel_cost, total_fuel_cost);

                user_trips[++trips_number] = new_trip;

                Console.WriteLine("Dodano novo putovanje:");
                Console.WriteLine("Datum: {0}", user_trips[trips_number].Item1);
                Console.WriteLine("Kilometri: {0}", user_trips[trips_number].Item2);
                Console.WriteLine("Gorivo: {0} L", user_trips[trips_number].Item3);
                Console.WriteLine("Cijena po litri: {0} EUR", user_trips[trips_number].Item4);
                Console.WriteLine("Ukupno: {0} EUR", user_trips[trips_number].Item5);
            }

            static void showDeleteTripsMenu()
            {
                Console.WriteLine("Brisanje putovanja:");
                Console.WriteLine("a - Po ID-u");
                Console.WriteLine("b - Svih putovanja skupljih od unesenog iznosa");
                Console.WriteLine("c - Svih putovanja jeftinijih od unesenog iznosa");
                Console.WriteLine("");
            }

            static void chooseFromDeleteTripsMenu(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                bool isOver = true;

                while (isOver)
                {
                    if (!checkTrips(users))
                    {
                        Console.WriteLine("Ne postoji niti jedno putovanje u memoriji");
                        Console.WriteLine("");
                        break;
                    }

                    Console.WriteLine("");

                    showDeleteTripsMenu();

                    Console.Write("Odabir: ");

                    if (char.TryParse((Console.ReadLine() ?? "").ToLower(), out char choice))
                    {
                        switch (choice)
                        {
                            case 'a':
                                deleteTripById(users);
                                isOver = false;
                                break;
                            case 'b':
                                deleteTripsMoreExpensiveThan(users);
                                isOver = false;
                                break;
                            case 'c':
                                deleteTripsCheaperThan(users);
                                isOver = false;
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
            }

            static void deleteTripById(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                Console.WriteLine("");
                Console.WriteLine("BRISANJE POSTOJEĆEG PUTOVANJA PO IDENTIFIKATORU");
                Console.WriteLine("");

                while (true)
                {
                    Console.Write("Odaberite putovanje (unesite ID): ");

                    if (int.TryParse(Console.ReadLine(), out int trip_id))
                    {
                        int user_id = 0;

                        if (isTripValid(users, trip_id, ref user_id))
                        {
                            Console.WriteLine("");
                            Console.Write("Jeste li sigurni da želite obrisati putovanje s identifikatorom ({0})? (DA/NE) ", trip_id);

                            if (checkInput())
                            {
                                users[user_id].Item4.Remove(trip_id);

                                Console.WriteLine("Putovanje s identifikatorom ({0}) je obrisano", trip_id);
                            }

                            else
                            {
                                Console.WriteLine("Brisanje putovanja s identifikatorom ({0}) je prekinuto", trip_id);
                            }

                            break;
                        }

                        else
                        {
                            Console.WriteLine("Putovanje s identifikatorom ({0}) ne postoji", trip_id);
                            Console.WriteLine("");
                        }
                    }

                    else
                    {
                        Console.WriteLine("Unos nije valjan");
                        Console.WriteLine("");
                    }
                }
            }

            static void deleteTripsMoreExpensiveThan(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                Console.WriteLine("");
                Console.WriteLine("BRISANJE POSTOJEĆIH PUTOVANJA SKUPLJIH OD UNESENOG IZNOSA");
                Console.WriteLine("");

                while (true)
                {
                    var filtered_trips_per_user = new Dictionary<int, List<int>>() { };

                    Console.Write("Odaberite iznos: ");

                    if (double.TryParse(Console.ReadLine(), out double threshold))
                    {
                        findTrips(users, filtered_trips_per_user, threshold, false);

                        if (filtered_trips_per_user.Any())
                        {
                            Console.WriteLine("");
                            Console.Write("Želite li obrisati putovanja skuplja od unesenog iznosa ({0} EUR)? (DA/NE) ", threshold);

                            if (checkInput())
                            {

                                foreach (var user in filtered_trips_per_user)
                                {
                                    int user_id = user.Key;
                                    List<int> trip_ids = user.Value;

                                    foreach (int trip_id in trip_ids)
                                    {
                                        users[user_id].Item4.Remove(trip_id);
                                    }
                                }

                                Console.WriteLine("Putovanja skuplja od unesenog iznosa ({0} EUR) su obrisana", threshold);
                            }

                            else
                            {
                                Console.WriteLine("Brisanje putovanja skupljih od unesenog iznosa ({0} EUR) je prekinuto", threshold);
                            }

                            break;
                        }

                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Putovanja skuplja od unesenog iznosa ({0} EUR) ne postoje", threshold);
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

            static void deleteTripsCheaperThan(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {

                Console.WriteLine("");
                Console.WriteLine("BRISANJE POSTOJEĆIH PUTOVANJA JEFTINIJIH OD UNESENOG IZNOSA");
                Console.WriteLine("");

                while (true)
                {
                    var filtered_trips_per_user = new Dictionary<int, List<int>>() { };

                    Console.Write("Odaberite iznos: ");

                    if (double.TryParse(Console.ReadLine(), out double threshold))
                    {
                        findTrips(users, filtered_trips_per_user, threshold, true);

                        if (filtered_trips_per_user.Any())
                        {
                            Console.WriteLine("");
                            Console.Write("Želite li obrisati putovanja jeftinija od unesenog iznosa ({0} EUR)? (DA/NE) ", threshold);

                            if (checkInput())
                            {
                                foreach (var user in filtered_trips_per_user)
                                {
                                    int user_id = user.Key;
                                    List<int> trip_ids = user.Value;

                                    foreach (int trip_id in trip_ids)
                                    {
                                        users[user_id].Item4.Remove(trip_id);
                                    }
                                }

                                Console.WriteLine("Putovanja jeftinija od unesenog iznosa ({0} EUR) su obrisana", threshold);
                            }

                            else
                            {
                                Console.WriteLine("Brisanje putovanja jeftinijih od unesenog iznosa ({0} EUR) je prekinuto", threshold);
                            }

                            break;
                        }

                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Putovanja jeftinija od unesenog iznosa ({0} EUR) ne postoje", threshold);
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

            static void findTrips(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users, Dictionary<int, List<int>> filtered_trips_per_user, double threshold, bool cheaper)
            {
                foreach (var user in users)
                {
                    int user_id = user.Key;
                    var trips = user.Value.Item4;

                    foreach (var trip in trips)
                    {
                        int trip_id = trip.Key;

                        switch (cheaper)
                        {
                            case true:
                                if (trip.Value.Item5 < threshold)
                                {
                                    if (!filtered_trips_per_user.ContainsKey(user_id))
                                    {
                                        filtered_trips_per_user[user_id] = new List<int>();
                                    }

                                    filtered_trips_per_user[user_id].Add(trip_id);
                                }
                                break;

                            case false:
                                if (trip.Value.Item5 > threshold)
                                {
                                    if (!filtered_trips_per_user.ContainsKey(user_id))
                                    {
                                        filtered_trips_per_user[user_id] = new List<int>();
                                    }

                                    filtered_trips_per_user[user_id].Add(trip_id);
                                }
                                break;
                        }
                    }
                }
            }

            static bool checkTrips(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                foreach (var user in users)
                {
                    var trips = user.Value.Item4;

                    if (trips.Any())
                    {
                        return true;
                    }
                }

                return false;
            }

            static void editTrip(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                Console.WriteLine("UREĐIVANJE POSTOJECEG PUTOVANJA PO IDENTIFIKATORU");
                Console.WriteLine("");

                while (true)
                {
                    Console.Write("Odaberite putovanje (unesite ID): ");

                    if (int.TryParse(Console.ReadLine(), out int trip_id))
                    {
                        int user_id = 0;

                        if (isTripValid(users, trip_id, ref user_id))
                        {
                            double distance, fuel_consumption, fuel_cost, total_fuel_cost;
                            string trip_date;

                            do
                            {
                                Console.Write("Unesite datum putovanja (YYYY-MM-DD) (ili ostavite prazno ako ne zelite promjene): ");
                                trip_date = Console.ReadLine() ?? "";

                                if (string.IsNullOrEmpty(trip_date))
                                {
                                    trip_date = users[user_id].Item4[trip_id].Item1;
                                    break;
                                }
                            } while (!isDateValid(trip_date));

                            while (true)
                            {
                                Console.Write("Unesite prijeđenu kilometražu (ili ostavite prazno ako ne zelite promjene): ");
                                string input = Console.ReadLine() ?? "";

                                if (string.IsNullOrEmpty(input))
                                {
                                    distance = users[user_id].Item4[trip_id].Item2;
                                    break;
                                }

                                else if (double.TryParse(input, out distance) && distance > 0)
                                    break;

                                Console.WriteLine("Unos nije valjan");
                            }

                            while (true)
                            {
                                Console.Write("Unesite količinu potrošenog goriva (ili ostavite prazno ako ne zelite promjene): ");
                                string input = Console.ReadLine() ?? "";

                                if (string.IsNullOrEmpty(input))
                                {
                                    fuel_consumption = users[user_id].Item4[trip_id].Item3;
                                    break;
                                }

                                else if (double.TryParse(input, out fuel_consumption) && fuel_consumption > 0)
                                    break;

                                Console.WriteLine("Unos nije valjan");
                            }

                            while (true)
                            {
                                
                                Console.Write("Unesite cijenu goriva po litri (ili ostavite prazno ako ne zelite promjene): ");
                                string input = Console.ReadLine() ?? "";

                                if (string.IsNullOrEmpty(input))
                                {
                                    fuel_cost = users[user_id].Item4[trip_id].Item4;
                                    break;
                                }

                                else if (double.TryParse(input, out fuel_cost) && fuel_cost > 0)
                                    break;

                                Console.WriteLine("Unos nije valjan");
                            }

                            total_fuel_cost = calculateTotalFuelCost(fuel_consumption, fuel_cost);

                            Console.WriteLine("");
                            Console.Write("Želite li urediti putovanje s identifikatorom ({0})? (DA/NE) ", trip_id);

                            if(checkInput())
                            {
                                users[user_id].Item4[trip_id] = new Tuple<string, double, double, double, double>
                                (
                                    trip_date,
                                    distance,
                                    fuel_consumption,
                                    fuel_cost,
                                    total_fuel_cost
                                );

                                Console.WriteLine("Putovanje s identifikatorom ({0}) je uredeno:", trip_id);
                                Console.WriteLine();

                                showTrips(new List<Tuple<string, double, double, double, double>>
                                {
                                    users[user_id].Item4[trip_id]
                                });
                            }

                            else
                            {
                                Console.WriteLine("Uređivanje putovanja s identifikatorom ({0}) je prekinuto", trip_id);
                                Console.WriteLine();
                            }

                            break;
                        }

                        else
                        {
                            Console.WriteLine("Putovanje s identifikatorom ({0}) ne postoji", trip_id);
                            Console.WriteLine("");
                        }
                    }

                    else
                    {
                        Console.WriteLine("Unos nije valjan");
                        Console.WriteLine("");
                    }
                }
            }

            static bool isTripValid(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users, int trip_id, ref int user_id)
            {
                foreach (var user in users)
                {
                    user_id = user.Key;
                    var trips = user.Value.Item4;

                    foreach (var trip in trips)
                    {
                        if (trip.Key == trip_id)
                            return true;
                    }
                }

                return false;
            }

            static double calculateTotalFuelCost(double fuel_consumption, double fuel_cost)
            {
                return fuel_consumption * fuel_cost;
            }

            static void showTripsListMenu()
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
            }

            static void chooseFromTripsListMenu(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                bool isOver = true;

                while (isOver)
                {
                    Console.WriteLine("");

                    showTripsListMenu();

                    Console.Write("Odabir: ");

                    if (char.TryParse((Console.ReadLine() ?? "").ToLower(), out char choice))
                    {
                        switch (choice)
                        {
                            case 'a':
                                sortTrips(users);
                                isOver = false;
                                break;
                            case 'b':
                                sortTripsByPriceAscending(users);
                                isOver = false;
                                break;
                            case 'c':
                                sortTripsByPriceDescending(users);
                                isOver = false;
                                break;
                            case 'd':
                                sortTripsByDistanceAscending(users);
                                isOver = false;
                                break;
                            case 'e':
                                sortTripsByDistanceDescending(users);
                                isOver = false;
                                break;
                            case 'f':
                                sortTripsByDateAscending(users);
                                isOver = false;
                                break;
                            case 'g':
                                sortTripsByDateDescending(users);
                                isOver = false;
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

                if (!trips.Any())
                {
                    Console.WriteLine("GREŠKA: Lista je prazna");
                    return;
                }

                foreach (var trip in trips)
                {
                    if (trips.Count > 1)
                        Console.WriteLine("Putovanje #{0}", ++trips_counter);
                    Console.WriteLine("Datum: {0}", trip.Item1);
                    Console.WriteLine("Kilometri: {0:F2}", trip.Item2);
                    Console.WriteLine("Gorivo: {0:F2} L", trip.Item3);
                    Console.WriteLine("Cijena po litri: {0:F2} EUR", trip.Item4);
                    Console.WriteLine("Ukupno: {0:F2} EUR", trip.Item5);
                    if (trip != trips.Last())
                        Console.WriteLine("");
                }
            }

            static void sortTrips(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                Console.WriteLine("");
                Console.WriteLine("Sva putovanja kako su spremljena:");
                Console.WriteLine("");

                var all_trips = new List<Tuple<string, double, double, double, double>>();

                fetchTrips(users, all_trips);

                showTrips(all_trips);
            }

            static void sortTripsByPriceAscending(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                Console.WriteLine("");
                Console.WriteLine("Sva putovanja sortirana po trošku uzlazno:");
                Console.WriteLine("");

                var all_trips = new List<Tuple<string, double, double, double, double>>();

                fetchTrips(users, all_trips);

                var sorted_trips = all_trips.OrderBy(u => u.Item5).ToList();

                showTrips(sorted_trips);
            }

            static void sortTripsByPriceDescending(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                Console.WriteLine("");
                Console.WriteLine("Sva putovanja sortirana po trošku silazno:");
                Console.WriteLine("");

                var all_trips = new List<Tuple<string, double, double, double, double>>();

                fetchTrips(users, all_trips);

                var sorted_trips = all_trips.OrderByDescending(u => u.Item5).ToList();

                showTrips(sorted_trips);
            }

            static void sortTripsByDistanceAscending(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                Console.WriteLine("");
                Console.WriteLine("Sva putovanja sortirana po kilometraži uzlazno:");
                Console.WriteLine("");

                var all_trips = new List<Tuple<string, double, double, double, double>>();

                fetchTrips(users, all_trips);

                var sorted_trips = all_trips.OrderBy(u => u.Item2).ToList();

                showTrips(sorted_trips);
            }

            static void sortTripsByDistanceDescending(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                Console.WriteLine("");
                Console.WriteLine("Sva putovanja sortirana po kilometraži silazno:");
                Console.WriteLine("");

                var all_trips = new List<Tuple<string, double, double, double, double>>();

                fetchTrips(users, all_trips);

                var sorted_trips = all_trips.OrderByDescending(u => u.Item2).ToList();

                showTrips(sorted_trips);
            }

            static void sortTripsByDateAscending(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                Console.WriteLine("");
                Console.WriteLine("Sva putovanja sortirana po kilometraži silazno:");
                Console.WriteLine("");

                var all_trips = new List<Tuple<string, double, double, double, double>>();

                fetchTrips(users, all_trips);

                var sorted_trips = all_trips.OrderBy(u => u.Item1).ToList();

                showTrips(sorted_trips);
            }

            static void sortTripsByDateDescending(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                Console.WriteLine("");
                Console.WriteLine("Sva putovanja sortirana po kilometraži silazno:");
                Console.WriteLine("");

                var all_trips = new List<Tuple<string, double, double, double, double>>();

                fetchTrips(users, all_trips);

                var sorted_trips = all_trips.OrderByDescending(u => u.Item1).ToList();

                showTrips(sorted_trips);
            }

            static bool isUserValid(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users, int user_id)
            {
                if (users.ContainsKey(user_id))
                {
                    return true;
                }

                return false;
            }

            static void filterTripsFromUser(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users, int user_id, List<Tuple<string, double, double, double, double>> trips)
            {
                var user_trips = users[user_id].Item4;

                foreach (var trip in user_trips)
                {
                    trips.Add(Tuple.Create(trip.Value.Item1, trip.Value.Item2, trip.Value.Item3, trip.Value.Item4, trip.Value.Item5));
                }
            }

            static void checkTripsReport(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                bool isOver = true;

                while (isOver)
                {

                    Console.WriteLine("");
                    Console.Write("Unesi ID korisnika za kojeg želiš izvještaj: ");

                    if (int.TryParse(Console.ReadLine(), out int user_id))
                    {
                        if (isUserValid(users, user_id))
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Odabran je korisnik {0} {1} ({2})", users[user_id].Item1, users[user_id].Item2, user_id);
                            var trips = new List<Tuple<string, double, double, double, double>>();
                            filterTripsFromUser(users, user_id, trips);
                            chooseFromTripsReportMenu(trips);
                            isOver = false;
                        }

                        else
                        {
                            Console.WriteLine("Korisnik s ID-em {0} ne postoji", user_id);
                        }
                    }

                    else
                    {
                        Console.WriteLine("Unos nije valjan");
                    }
                }
            }
            
            static void showTripsReportMenu()
            {
                Console.WriteLine("Izvještaji i analize: ");
                Console.WriteLine("a - Ukupna potrošnja goriva");
                Console.WriteLine("b - Ukupni troškovi goriva");
                Console.WriteLine("c - Prosječna potrošnja goriva u L/100km");
                Console.WriteLine("d - Putovanje s najvećom potrošnjom goriva");
                Console.WriteLine("e - Pregled putovanja po određenom datumu");
                Console.WriteLine("");
            }

            static void chooseFromTripsReportMenu(List<Tuple<string, double, double, double, double>> trips)
            {
                bool isOver = true;

                while (isOver)
                {
                    Console.WriteLine("");

                    showTripsReportMenu();

                    Console.Write("Odabir: ");

                    if (char.TryParse((Console.ReadLine() ?? "").ToLower(), out char choice))
                    {
                        switch (choice)
                        {
                            case 'a':
                                showTotalFuelConsumption(trips);
                                isOver = false;
                                break;
                            case 'b':
                                showTotalFuelCost(trips);
                                isOver = false;
                                break;
                            case 'c':
                                showAverageFuelConsumption(trips);
                                isOver = false;
                                break;
                            case 'd':
                                showMaxConsumptionTrip(trips);
                                isOver = false;
                                break;
                            case 'e':
                                showTripsByDate(trips);
                                isOver = false;
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
            }

            static void showTotalFuelConsumption(List<Tuple<string, double, double, double, double>> trips)
            {
                double total_fuel_consumption = 0.0;

                foreach (var trip in trips)
                {
                    total_fuel_consumption += trip.Item3;
                }

                Console.WriteLine("Ukupna potrošnja goriva je: {0} L", total_fuel_consumption);
            }

            static void showTotalFuelCost(List<Tuple<string, double, double, double, double>> trips)
            {
                double total_fuel_cost = 0.0;

                foreach (var trip in trips)
                {
                    total_fuel_cost += trip.Item5;
                }

                Console.WriteLine("");
                Console.WriteLine("Ukupna potrošnja goriva je: {0} EUR", total_fuel_cost);
            }

            static void showAverageFuelConsumption(List<Tuple<string, double, double, double, double>> trips)
            {
                double average_fuel_consumption = 0.0;
                double total_distance = 0.0;
                double total_fuel_consumption = 0.0;

                foreach (var trip in trips)
                {
                    total_distance += trip.Item2;
                    total_fuel_consumption += trip.Item3;
                }

                average_fuel_consumption = (total_fuel_consumption / total_distance) * 100;

                Console.WriteLine("");
                Console.WriteLine("Ukupna potrošnja goriva je: {0:F2} L/100km", average_fuel_consumption);
            }

            static void showMaxConsumptionTrip(List<Tuple<string, double, double, double, double>> trips)
            {
                var maximum_consumption_trip = trips.MaxBy(u => u.Item4);

                if (maximum_consumption_trip == null) { return; }

                Console.WriteLine("");
                Console.WriteLine("Putovanje s najvećom potrošnjom goriva:");
                Console.WriteLine("Datum: {0}", maximum_consumption_trip.Item1);
                Console.WriteLine("Kilometri: {0}", maximum_consumption_trip.Item2);
                Console.WriteLine("Gorivo: {0} L", maximum_consumption_trip.Item3);
                Console.WriteLine("Cijena po litri: {0} EUR", maximum_consumption_trip.Item4);
                Console.WriteLine("Ukupno: {0} EUR", maximum_consumption_trip.Item5);
            }

            static void showTripsByDate(List<Tuple<string, double, double, double, double>> trips)
            {
                string trip_date;

                do
                {
                    Console.WriteLine("");
                    Console.Write("Unesite datum putovanja (YYYY-MM-DD): ");
                    trip_date = Console.ReadLine() ?? "";
                } while (string.IsNullOrEmpty(trip_date) || !isDateValid(trip_date));

                var filtered_trips = trips.Where(u => trip_date == u.Item1).ToList();

                if (filtered_trips.Count == 0)
                {
                    Console.WriteLine("Ne postoji niti jedno putovanje datuma {0}", trip_date);
                }

                else
                {
                    Console.WriteLine("");
                    showTrips(filtered_trips);
                }
            }

            static void showUserWithHighestFuelCost(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                int max_user_id = 0;
                double max_fuel_cost = 0;

                foreach (var user in users)
                {
                    int user_id = user.Key;
                    var trips = user.Value.Item4;

                    double total_fuel_cost = 0;

                    foreach (var trip in trips)
                    {
                        total_fuel_cost += trip.Value.Item5;
                    }

                    if (total_fuel_cost > max_fuel_cost)
                    {
                        max_fuel_cost = total_fuel_cost;
                        max_user_id = user_id;
                    }
                }

                Console.WriteLine("");
                Console.WriteLine("Korisnik s najvećom ukupnim troškom goriva je {0} {1} ({2}) i on iznosi: {3} EUR", users[max_user_id].Item1, users[max_user_id].Item2, max_user_id, max_fuel_cost);
            }

            static void showUserWithMostTrips(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                var users_id = new List<int>();
                int most_trips_number = 0;

                foreach (var user in users)
                {
                    int user_id = user.Key;
                    var trips = user.Value.Item4;

                    if (trips.Count > most_trips_number)
                    {
                        users_id.Clear();
                        users_id.Add(user_id);
                        most_trips_number = trips.Count;
                    }

                    else if (trips.Count == most_trips_number)
                    {
                        users_id.Add(user_id);
                    }
                }

                Console.WriteLine("");
                Console.WriteLine("Korisnici s najviše putovanja ({0}):", most_trips_number);
                Console.WriteLine("{0, -8} {1, -16} {2, -16}", "ID", "Ime", "Prezime");

                foreach (var user_id in users_id)
                {
                    Console.WriteLine("{0, -8} {1, -16} {2}", user_id, users[user_id].Item1, users[user_id].Item2);
                }
            }

            static void showAverageTripsPerUser(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                int total_number_of_users = users.Count;
                int total_number_of_trips = 0;
                double average_trips_per_user = 0.0;

                foreach (var user in users)
                {
                    var trips = user.Value.Item4;
                    total_number_of_trips += trips.Count;
                }

                average_trips_per_user = (double) total_number_of_trips / total_number_of_users;

                Console.WriteLine("");
                Console.WriteLine("Ukupno ima {0} korisnika i {1} putovanja", total_number_of_users, total_number_of_trips);
                Console.WriteLine("Prosječan broj putovanja po korisniku iznosi: {0:F2}", average_trips_per_user);
            }

            static void showTotalDistance(Dictionary<int, Tuple<string, string, string, Dictionary<int, Tuple<string, double, double, double, double>>>> users)
            {
                int total_number_of_users = users.Count;
                int total_number_of_trips = 0;
                double total_distance = 0.0;

                foreach (var user in users)
                {
                    var trips = user.Value.Item4;
                    total_number_of_trips += trips.Count;

                    foreach (var trip in trips)
                    {
                        double distance = trip.Value.Item2;
                        total_distance += distance;
                    }
                }

                Console.WriteLine("");
                Console.WriteLine("Ukupno ima {0} korisnika i {1} putovanja", total_number_of_users, total_number_of_trips);
                Console.WriteLine("Zajedno su svi korisnici prešli: {0:F2} km", total_distance);
            }
        }
    }
}
