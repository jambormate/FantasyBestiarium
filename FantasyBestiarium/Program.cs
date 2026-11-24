namespace FantasyBestiarium
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Szornyelemzo szornyelemzo = new Szornyelemzo(new SzornyAdatbazis().Feltolt());

            Console.WriteLine($"A veszélyes szörnyek száma: {szornyelemzo.VeszelyesSzornyekSzama()}");
            foreach (var nev in szornyelemzo.GyengeSzornyekNevei())
            {
                Console.WriteLine($"Gyenge szörny neve: {nev}");
            }
            foreach (var zsakmany in szornyelemzo.Zsakmanyok())
            {
                Console.WriteLine($"Zsákmány: {zsakmany}");
            }
            Console.WriteLine($"A legalacsonyabb veszélyiségi szint: {szornyelemzo.LegkisebbVeszelyessegiSzint()}");
            foreach (var szorny in szornyelemzo.NemveszelyesSzornyek())
            {
                Console.WriteLine($"Nem veszélyes szörny: {szorny.Nev}, Veszélyességi szint: {szorny.VeszelyessegiSzint}");
            }
            Console.WriteLine($"Van-e vízre gyenge szörny aki veszélyes: {szornyelemzo.VanVizGyengeVeszelyesSzorny()}");
            foreach(var szornyekSzamaZsakanyonkent in szornyelemzo.SzornyekSzamaZsakanyonkent())
            {
                Console.WriteLine(szornyekSzamaZsakanyonkent);
            }
            foreach(var legveszelyesebbElohely in szornyelemzo.LegveszelyesebbElohelyek())
            {
                Console.WriteLine($"Legveszélyesebb élőhelyek: {legveszelyesebbElohely}");
            }
        }
    }
}
