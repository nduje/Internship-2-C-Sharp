namespace Internship_2_C_Sharp
{
    internal class Program
    {
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
        }
    }
}
