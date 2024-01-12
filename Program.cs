using System.Security.Cryptography.X509Certificates;

namespace Zadania_6
{
    public class Prostokat
    {
        private double dlugosc;
        private double szerokosc;
        public Prostokat(double dlugosc, double szerokosc)
        {
            this.dlugosc = dlugosc;
            this.szerokosc = szerokosc;
        }
        private double powierzchnia()
        {
            return dlugosc * szerokosc;
        }
        private double obwod()
        {
            return 2 * dlugosc + 2 * szerokosc;
        }
        public void Prezentuj()
        {
            Console.WriteLine("Powierzchnia prostokąta: {0,10:F4}", powierzchnia());
            Console.WriteLine("Obwód prostokąta: {0,10:F4}", obwod());
        }
        public static double powierzNajwiek(Prostokat[] tab)
        {
            double powNaj = 0;
            foreach (Prostokat p in tab)
            {
                if (p.powierzchnia() > powNaj)
                {
                    powNaj = p.powierzchnia();
                }
            }
            return powNaj;
        }
    }

    public class LicznikEnergElektr
    {
        private double stanPoczatkowy;
        private double stanBiezacy;
        public LicznikEnergElektr(double stPocz)
        {
            stanPoczatkowy = stPocz;
            stanBiezacy = stPocz;
        }
        public void UstawStanBiezacy (double stBiez)
        {
            if (stanBiezacy <= stBiez)
            {
                stanBiezacy = stBiez;
                Console.WriteLine("Ustawiono stan bieżący na: {0,10:F4}", stanBiezacy);
            }
            else
            {
                Console.WriteLine("Niedozwolona próba ustawienia stanu bieżącego na wartość mniejszą: {0,10:F4}", stBiez);
            }
        }
        public void PokazStany()
        {
            Console.WriteLine("          Stan początkowy: {0,10:F4},          Stan bieżący: {1,10:F4}", stanPoczatkowy, stanBiezacy);
        }
        public double ZuzytaEnergia()
        {
            return stanBiezacy - stanPoczatkowy;
        }
    }

    public class Punkt
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public Punkt(double x, double y)
        {
            X = x;
            Y = y;
        }
        public void Przesun(double dx, double dy)
        {
            X += dx;
            Y += dy;
            Console.WriteLine("Przesunięto punkt o:          dx = {0,10:F4},          dy = {1,10:F4}", dx, dy);
        }
        public void Wyswietl()
        {
            Console.WriteLine("          Współrzędne punktu:          x = {0,10:F4},          y = {1,10:F4}", X, Y);
        }
        public static bool CzyWspolliniowe(Punkt[] tab)
        {
            if (tab.Length < 3) return false;
            if (tab[0].X == tab[1].X) return tab[1].X == tab[2].X;
            double a = (tab[0].Y - tab[1].Y) / (tab[0].X - tab[1].X);
            double b = tab[0].Y - a * tab[0].X;
            return Math.Round(tab[2].Y, 6) == Math.Round(a * tab[2].X + b, 6);
        }
    }

    public class Odcinek
    {
        private Punkt pA;
        private Punkt pB;
        public Odcinek(Punkt pA, Punkt pB)
        {
            this.pA = pA;
            this.pB = pB;
        }
        public double DlugoscOdcinka()
        {
            return Math.Sqrt(Math.Pow((pA.X - pB.X), 2) + Math.Pow((pA.Y - pB.Y), 2));
        }
    }

    public class Prostopadloscian
    {
        private double dlugosc;
        private double szerokosc;
        private double wysokosc;
        public Prostopadloscian(double dlugosc, double szerokosc, double wysokosc)
        {
            this.dlugosc = dlugosc;
            this.szerokosc = szerokosc;
            this.wysokosc = wysokosc;
        }
        public void Wyswietl()
        {
            Console.WriteLine("          Miary prostopadłościanu: długość = {0,-10:F4}, szerokość = {1,-10:F4}, wysokość = {2,-10:F4}", dlugosc, szerokosc, wysokosc);
        }
        public double objetosc()
        {
            return dlugosc * szerokosc * wysokosc;
        }
        public static string porownajObjetosci(Prostopadloscian p1, Prostopadloscian p2)
        {
            string wynik;
            if (p1.objetosc() < p2.objetosc())
                wynik = " <, Objętość pierwszego prostopadłościanu jest mniejsza od drugiego";
            else if (p1.objetosc() > p2.objetosc())
                wynik = " >, Objętość pierwszego prostopadłościanu jest większa od drugiego";
            else
                wynik = "==, Objętości obu prostopadłościanów są równe";
            return wynik;
        }
    }

    public struct struProstokat
    {
        private double dlugosc;
        private double szerokosc;
        public struProstokat(double dlugosc, double szerokosc)
        {
            this.dlugosc = dlugosc;
            this.szerokosc = szerokosc;
        }
        private double powierzchnia()
        {
            return dlugosc * szerokosc;
        }
        private double obwod()
        {
            return 2 * dlugosc + 2 * szerokosc;
        }
        public void Prezentuj()
        {
            Console.WriteLine("Powierzchnia prostokąta: {0,10:F4}", powierzchnia());
            Console.WriteLine("Obwód prostokąta: {0,10:F4}", obwod());
        }
    }

    public struct KandydatNaStudia
    {
        public string nazwisko;
        private int punktyMatematyka;
        private int punktyInformatyka;
        private int punktyJezykObcy;
        public KandydatNaStudia(string nazw, int punMat, int punInf, int punJOb)
        {
            nazwisko = nazw;
            punktyMatematyka = punMat;
            punktyInformatyka = punInf;
            punktyJezykObcy = punJOb;
        }
        public double PunktyRazemWgPrzelicznika()
        {
            return 0.6 * punktyMatematyka + 0.5 * punktyInformatyka + 0.2 * punktyJezykObcy;
        }
    }

    internal class Program
    {
        static void Zad_01()
        {
            Prostokat p = new Prostokat(16.28, 9.173);
            p.Prezentuj();
            Console.ReadKey();
        }

        static void Zad_02()
        {
            Prostokat[] tab_p = new Prostokat[5];
            tab_p[0] = new Prostokat(16.28, 9.173);
            tab_p[1] = new Prostokat(42.421, 45.9228);
            tab_p[2] = new Prostokat(92.011, 66.931);
            tab_p[3] = new Prostokat(28.9828, 73.231);
            tab_p[4] = new Prostokat(81.25, 39.11);
            foreach (Prostokat p in tab_p)
            {
                p.Prezentuj();
            }
            Console.ReadKey();
        }

        static void Zad_03()
        {
            Prostokat[] tab_p =
            {
                new Prostokat(16.28, 9.173),
                new Prostokat(42.421, 45.9228),
                new Prostokat(92.011, 66.931),
                new Prostokat(28.9828, 73.231),
                new Prostokat(81.25, 39.11)
            };
            Console.WriteLine("Powierzchnia największego prostokąta: {0,10:F4}", Prostokat.powierzNajwiek(tab_p));
            Console.ReadKey();
        }

        static void Zad_04()
        {
            LicznikEnergElektr le = new LicznikEnergElektr(25.73);
            le.PokazStany();
            Console.WriteLine("          Ilość zużytej energii elektrycznej: {0,10:F4}", le.ZuzytaEnergia());
            le.UstawStanBiezacy(36.6);
            le.PokazStany();
            le.UstawStanBiezacy(29.1746);
            le.PokazStany();
            le.UstawStanBiezacy(42.192);
            le.PokazStany();
            Console.WriteLine("          Ilość zużytej energii elektrycznej: {0,10:F4}", le.ZuzytaEnergia());
            Console.ReadKey();
        }

        static void Zad_05()
        {
            Punkt p = new Punkt(2.71, -3.14);
            p.Wyswietl();
            p.Przesun(5.38, 9.23);
            p.Wyswietl();
            p.Przesun(-4.82, 7.29);
            p.Wyswietl();
            Console.ReadKey();
        }

        static void Zad_06()
        {
            Punkt[] tab_p = new Punkt[3];
            tab_p[0] = new Punkt(2, 5);
            tab_p[1] = new Punkt(-3, 7);
            tab_p[2] = new Punkt(4, -6);
            for (int i = 0; i < tab_p.Length; i++)
            {
                tab_p[i].Wyswietl();
            }
            Console.WriteLine("Czy trzy punkty z tablicy obiektów klasy Punkt są współliniowe ?: {0}", Punkt.CzyWspolliniowe(tab_p) ? "TAK" : "NIE");
            tab_p[2].Przesun(8, 7);
            for (int i = 0; i < tab_p.Length; i++)
            {
                tab_p[i].Wyswietl();
            }
            Console.WriteLine("Czy trzy punkty z tablicy obiektów klasy Punkt są współliniowe ?: {0}", Punkt.CzyWspolliniowe(tab_p) ? "TAK" : "NIE");
            Console.ReadKey();
        }

        static void Zad_07()
        {
            Punkt p1 = new Punkt(2, -5);
            Punkt p2 = new Punkt(-8, 7);
            Odcinek odc = new Odcinek(p1, p2);
            p1.Wyswietl();
            p2.Wyswietl();
            Console.WriteLine("Długość odcinka: {0,10:F4}", odc.DlugoscOdcinka());
            Console.ReadKey();
        }

        static void Zad_08()
        {
            Prostopadloscian p1 = new Prostopadloscian(5, 7, 9);
            Prostopadloscian p2 = new Prostopadloscian(6, 8, 4);
            Prostopadloscian p3 = new Prostopadloscian(15, 3, 7);
            p1.Wyswietl();
            Console.WriteLine("Objętość prostopadłościanu: {0,10:F4}", p1.objetosc());
            p2.Wyswietl();
            Console.WriteLine("Objętość prostopadłościanu: {0,10:F4}", p2.objetosc());
            Console.WriteLine(Prostopadloscian.porownajObjetosci(p1, p2));
            p1.Wyswietl();
            Console.WriteLine("Objętość prostopadłościanu: {0,10:F4}", p1.objetosc());
            p3.Wyswietl();
            Console.WriteLine("Objętość prostopadłościanu: {0,10:F4}", p3.objetosc());
            Console.WriteLine(Prostopadloscian.porownajObjetosci(p1, p3));
            Console.ReadKey();
        }

        static void Zad_09_a()
        {
            struProstokat p = new struProstokat(16.28, 9.173);
            Console.WriteLine("---struct---");
            p.Prezentuj();
            Console.ReadKey();
        }

        static void Zad_09_b()
        {
            struProstokat[] tab_p = new struProstokat[5];
            tab_p[0] = new struProstokat(16.28, 9.173);
            tab_p[1] = new struProstokat(42.421, 45.9228);
            tab_p[2] = new struProstokat(92.011, 66.931);
            tab_p[3] = new struProstokat(28.9828, 73.231);
            tab_p[4] = new struProstokat(81.25, 39.11);
            Console.WriteLine("---struct---");
            foreach (struProstokat p in tab_p)
            {
                p.Prezentuj();
            }
            Console.ReadKey();
        }

        static void Zad_10()
        {
            KandydatNaStudia[] tabKnS =
            {
                new KandydatNaStudia("Kowalski", 49, 83, 64),
                new KandydatNaStudia("Malinowska", 58, 72, 93),
                new KandydatNaStudia("Nowakowska", 71, 94, 42),
                new KandydatNaStudia("Wiśniewski", 67, 76, 73),
                new KandydatNaStudia("Niedźwiedzki", 59, 87, 88),
                new KandydatNaStudia("Skowrońska", 75, 78, 67),
            };
            foreach (KandydatNaStudia k in tabKnS)
            {
                Console.WriteLine("Nazwisko: {0, -20},    Obliczona łączna liczba punktów: {1,10:F4}", k.nazwisko, k.PunktyRazemWgPrzelicznika());
            }
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("\nZadanie 6.1");
            Zad_01();

            Console.WriteLine("\nZadanie 6.2");
            Zad_02();

            Console.WriteLine("\nZadanie 6.3");
            Zad_03();

            Console.WriteLine("\nZadanie 6.4");
            Zad_04();

            Console.WriteLine("\nZadanie 6.5");
            Zad_05();

            Console.WriteLine("\nZadanie 6.6");
            Zad_06();

            Console.WriteLine("\nZadanie 6.7");
            Zad_07();

            Console.WriteLine("\nZadanie 6.8");
            Zad_08();

            Console.WriteLine("\nZadanie 6.9.a");
            Zad_09_a();
            Console.WriteLine("\nZadanie 6.9.b");
            Zad_09_b();

            Console.WriteLine("\nZadanie 6.10");
            Zad_10();

            Console.WriteLine("\nKoniec");
            Console.ReadKey();
        }
    }
}
