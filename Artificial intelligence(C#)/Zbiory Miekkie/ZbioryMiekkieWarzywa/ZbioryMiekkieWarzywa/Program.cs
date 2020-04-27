using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbioryMiekkieWarzywa
{
    class Program
    {
        static void Main(string[] args)
        {
            //Adam Kierat Paweł Gładysz (pair programming)
                int[] salata_tablica = new int[10] { 1, 0, 0, 0, 1, 0, 1, 0, 1, 0 };
                int[] szpinak_tablica = new int[10] { 0, 1, 0, 0, 1, 0, 1, 0, 1, 0 };
                int[] bataty_tablica = new int[10] { 1, 0, 0, 1, 0, 1, 0, 1, 0, 1 };
                int[] papryka_tablica = new int[10] { 1, 0, 1, 0, 0, 1, 1, 0, 1, 0 };
                int[] burak_tablica = new int[10] { 1, 0, 0, 1, 0, 1, 1, 0, 0, 1 };

                double[] klientA = new double[10] { 0.7, 0, 0.4, 0, 0.3, 0, 0, 0, 0, 0 };
                double[] klientB = new double[10] { 0, 0.3, 0, 0.7, 0.4, 0, 0, 0, 0.9, 0 };
                double[] klientC = new double[10] { 0.8, 0, 0, 0.5, 0.9, 0.3, 0, 0, 0, 0 };

                int[][] data_array = new int[][] { salata_tablica, szpinak_tablica, bataty_tablica, papryka_tablica, burak_tablica };

                double[] klientA_wagi = new double[] { 0, 0, 0, 0, 0 };
                double[] klientB_wagi = new double[] { 0, 0, 0, 0, 0 };
                double[] klientC_wagi = new double[] { 0, 0, 0, 0, 0 };

                string[] wybor_Klientow = new string[] { "", "", "" };

                int licznik = 0;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {

                        klientA_wagi[licznik] += data_array[i][j] * klientA[j];
                        klientB_wagi[licznik] += data_array[i][j] * klientB[j];
                        klientC_wagi[licznik] += data_array[i][j] * klientC[j];
                        licznik++;
                        if (licznik == 5) licznik = 0;
                    }
                }

                double KlientA_wartosc_max = klientA_wagi.Max();
                int KlientA_wartosc_max_index = Array.IndexOf(klientA_wagi, KlientA_wartosc_max);

                for (int y = 0; y < klientA_wagi.Length; y++)
                {
                    if (KlientA_wartosc_max == klientA_wagi[y])
                    {
                        wybor_Klientow[0] += "Wybór Klienta A to: " + NajlepszeWarzywo(y);
                    }
                    if (y + 1 == klientA_wagi.Length)
                    {
                        wybor_Klientow[0] += "\r\n";
                    }

                }

                double KlientB_wartosc_max = klientB_wagi.Max();
                int KlientB_wartosc_max_index = Array.IndexOf(klientB_wagi, KlientB_wartosc_max);

                for (int y = 0; y < klientB_wagi.Length; y++)
                {
                    if (KlientB_wartosc_max == klientB_wagi[y])
                    {
                        wybor_Klientow[0] += "Wybór Klienta B to: " + NajlepszeWarzywo(y);
                    }
                    if (y + 1 == klientA_wagi.Length)
                    {
                        wybor_Klientow[0] += "\r\n";
                    }


                }

                double klientC_wartosc_max = klientC_wagi.Max();
                int KlientC_wartosc_max_index = Array.IndexOf(klientC_wagi, klientC_wartosc_max);

                for (int y = 0; y < klientC_wagi.Length; y++)
                {
                    if (klientC_wartosc_max == klientC_wagi[y])
                    {
                        wybor_Klientow[0] += "Wybór Klienta C to: " + NajlepszeWarzywo(y);
                    }
                    if (y + 1 == klientA_wagi.Length)
                    {
                        wybor_Klientow[0] += "\r\n";
                    }


                }
                foreach (string x in wybor_Klientow)
                {
                    Console.WriteLine(x);
                }

              for (int p = 0; p < klientA_wagi.Length; p++)
              {
                  Console.WriteLine(klientA_wagi[p]);
              }
              for (int p = 0; p < klientB_wagi.Length; p++)
              {
                  Console.WriteLine(klientB_wagi[p]);
              }
              for (int p = 0; p < klientC_wagi.Length; p++)
              {
                  Console.WriteLine(klientC_wagi[p]);
              }

                Console.ReadKey();
            }
            static string NajlepszeWarzywo(int Klient_wartosc_max)
            {
                string nazwa = "";
                switch (Klient_wartosc_max)
                {
                    case 0:
                        nazwa = "salata";
                        break;
                    case 1:
                        nazwa = "szpinak";
                        break;
                    case 2:
                        nazwa = "bataty";
                        break;
                    case 3:
                        nazwa = "papryka";
                        break;
                    case 4:
                        nazwa = "burak";
                        break;

                }

                return nazwa;
            }

        }
    }
    }
}
