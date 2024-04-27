using System;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;
using System.IO;



namespace Dolgozat;

class Dolgozat
{
    protected string nev;
    protected List<int> pontok;

    public string GetNev()
    {
        return nev;
    }
    public List<int> GetPontok()
    {
        return pontok;
    }

    public Dolgozat(string nev, List<int> pontok)
    {
        this.nev = nev;
        this.pontok = pontok;
    }

    public byte FeladatokSzama()
    {
        return (byte)pontok.Count;
    }

    public int Osszpontszam()
    {
        int osszpont = 0;
        foreach (var pontszam in pontok)
        {
            osszpont += pontszam;
        }

        return osszpont;
    }

    public byte Ertekel(int maxPontszam)
    {
        double szazalek = (double)Osszpontszam() / maxPontszam * 100;
        if (szazalek >= 0 && szazalek <= 40)
        {
            return 2;
        }

        if (szazalek >= 41 && szazalek <= 55)
        {
            return 3;
        }

        if (szazalek >= 56 && szazalek <= 70)
        {
            return 3;
        }

        if (szazalek >= 71 && szazalek <= 85)
        {
            return 4;
        }
        else
        {
            return 5;
        }
    }

    public virtual string Eredmeny(int maxPontszam)
    {
        return $"{nev}: {Osszpontszam()}pont - Érdemjegy: {Ertekel(maxPontszam)}";
    }

    public override string ToString()
    {
        return $"{nev} pontszáma: {Osszpontszam()}";
    }
}

class MDolgozat : Dolgozat
{
    public string temakor;

    public MDolgozat(string nev, List<int> pontok, string temakor) : base(nev, pontok)
    {
        this.temakor = temakor;
    }

    public override string Eredmeny(int maxPontszam)
    {
        return $"{temakor}: {nev}: {Osszpontszam()}pont - Érdemjegy: {Ertekel(maxPontszam)}";
    }
}

class TDolgozat : Dolgozat
{
    public TDolgozat(string nev, List<int> pontok) : base(nev, pontok)
    {
    }

    public override string Eredmeny(int maxPontszam)
    {
        int ertek = Ertekel(maxPontszam);
        if (ertek == 2)
        {
            return $"{nev}: {Osszpontszam()}pont - Eredmény: Nem felelt meg.";
        }

        if (ertek == 3 || ertek == 4)
        {
            return $"{nev}: {Osszpontszam()}pont - Eredmény: Megfelelt.";
        }

        if (ertek == 5)
        {
            return $"{nev}: {Osszpontszam()}pont - Eredmény: Kiválóan megfelelt.";
        }
        else
        {
            return $"{nev}: {Osszpontszam()}pont - Eredmény: Ismeretlen értékelés";
        }
    }
}

class IDolgozat : Dolgozat
{
    protected string csoport;

    public IDolgozat(string nev, List<int> pontok, string csoport) : base(nev, pontok)
    {
        this.csoport = csoport;
    }

    public override string Eredmeny(int maxPontszam)
    {
        return $"{nev}: {Osszpontszam()}pont - Érdemjegy: {Ertekel(maxPontszam)}, {csoport}";
    }
}

class Program
{
    public static List<Dolgozat> dolgozatok = new List<Dolgozat>();

    public static void Beolvas()
    {
        StreamReader input = new StreamReader("dolgozatok.csv", Encoding.Latin1);
        input.ReadLine();
        while (!input.EndOfStream)
        {
            string[] sd = input.ReadLine().Split(';');
            List<int> pontok = new List<int>();
            for (int i = 3; i < sd.Length; i++)
            {
                if (sd[i] != "")
                {
                    pontok.Add(int.Parse(sd[i]));
                }
            }

            switch (sd[2])
            {
                case "Matematika":
                    dolgozatok.Add(new MDolgozat(sd[1], pontok, sd[0]));
                    break;
                case "Történelem":
                    dolgozatok.Add(new TDolgozat(sd[1], pontok));
                    break;
                case "Irodalom":
                    dolgozatok.Add(new IDolgozat(sd[1], pontok, sd[0]));
                    break;
            }
        }
    }

    static void Main(string[] args)
    {
        Beolvas();
        int matematikaDolgozatokSzama = 0;
        foreach (Dolgozat dolgozat in dolgozatok)
        {
            if (dolgozat is MDolgozat)
            {
                matematikaDolgozatokSzama++;
            }
        }

        Console.WriteLine("3.Feladat\nMatematika dolgozatok száma: " + matematikaDolgozatokSzama);

        Console.Write("\n4.Feladat\nAdjon meg egy nevet(Vezetéknév Keresztnév): ");
        string inputnev = Console.ReadLine();
        bool van = false;
        foreach (Dolgozat dolgozat in dolgozatok)
        {
            if (dolgozat is TDolgozat)
            {
                if (dolgozat.GetNev() == inputnev)
                {
                    Console.WriteLine(dolgozat.Eredmeny(30));
                    van = true;
                    break;
                }
            }
        }
        if (!van)
        {
            Console.WriteLine($"{inputnev} nevű tanuló nem írt dolgozatot történelemből!");
        }

        Console.WriteLine("\n5.Feladat");
        System.Console.Write("Adja meg a feladat sorszámát: ");
        int inputfeladat = int.Parse(Console.ReadLine());
        int db = 0;
        double osszpont = 0;
        foreach (Dolgozat dolgozat in dolgozatok)
        {
            if (dolgozat is IDolgozat)
            {
                List<int> pontok = ((IDolgozat)dolgozat).GetPontok();
                if(pontok.Count > inputfeladat - 1)
                {
                    osszpont += pontok[inputfeladat - 1];
                    db++;
                }
            }

        }
        if (db>0)
        {
            double atlag = osszpont / db;
            Console.WriteLine($"Az irodalom dolgozat {inputfeladat}. feladatának átlaga: {atlag}");
        }
        else
        {
            Console.WriteLine("Sajnos ilyen sorszámú feladat nem létezik!");
        }

        Console.WriteLine("\n6.Feladat\nMatematika, Történelem, Irodalom dolgozatok feladataira kapott pontszámokat egy fájlban tároltuk.\nKérem válasszon, melyik dolgozat eredményeit szeretné látni!");
        Console.WriteLine("1. Matematika\n2. Történelem\n3. Irodalom\n");
        Console.Write($"Az ön választása: ");
        int valasztas = int.Parse(Console.ReadLine());

        switch (valasztas)
        {
            case 1:
                Console.WriteLine("Matematika dolgozatok eredményei:");
                foreach (Dolgozat dolgozat in dolgozatok)
                {
                    if (dolgozat is MDolgozat)
                    {
                        Console.WriteLine(dolgozat.Eredmeny(45));
                    }
                }
                break;
            case 2:
                Console.WriteLine("Történelem dolgozatok eredményei:");
                foreach (Dolgozat dolgozat in dolgozatok)
                {
                    if (dolgozat is TDolgozat)
                    {
                        Console.WriteLine(dolgozat.Eredmeny(30));
                    }
                }
                break;
            case 3:
                Console.WriteLine("Irodalom dolgozatok eredményei:");
                foreach (Dolgozat dolgozat in dolgozatok)
                {
                    if (dolgozat is IDolgozat)
                    {
                        Console.WriteLine(dolgozat.Eredmeny(40));
                    }
                }
                break;
            default:
                Console.WriteLine("Sajnos ilyen opció nincs!");
                break;
        }

    }
}