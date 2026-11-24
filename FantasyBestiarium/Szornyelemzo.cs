using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyBestiarium
{
    internal class Szornyelemzo
    {
        private List<Szorny> szornyek;

        public Szornyelemzo(List<Szorny> szornyek)
        {
            this.szornyek = szornyek;
        }
        public int VeszelyesSzornyekSzama()
        {
            return szornyek.Count(szorny => szorny.VeszelyesE);
        }

        public IEnumerable<string> GyengeSzornyekNevei()
        {
            return szornyek.Where(szorny => szorny.VeszelyessegiSzint < 4)
                           .Select(szorny => szorny.Nev);
        }
        public IEnumerable<string> Zsakmanyok()
        {
            return szornyek.Select(szorny => szorny.LeggyakoribbZsakmany)
                           .Distinct()
                           .OrderBy(zsakmany => zsakmany);
        }
        public int LegkisebbVeszelyessegiSzint()
        {
            return szornyek.Min(szorny => szorny.VeszelyessegiSzint);
        }
        public IEnumerable<Szorny> NemveszelyesSzornyek()
        {
            return szornyek.Where(szorny => !szorny.VeszelyesE)
                        .OrderBy(szorny => szorny.VeszelyessegiSzint);
        }
        public bool VanVizGyengeVeszelyesSzorny()
        {
            return szornyek.Any(szorny => szorny.FoGyengeseg.ToLower().Contains("víz") && szorny.VeszelyesE);
        }
        public IEnumerable<string> SzornyekSzamaZsakanyonkent()
        {
            return szornyek.GroupBy(szorny => szorny.LeggyakoribbZsakmany)
                           .Select(group => $"{group.Key}: {group.Count()}");
        }
        public IEnumerable<string> LegveszelyesebbElohelyek()
        {
            return szornyek.GroupBy(szorny => szorny.Elohely)
                           .Select(group => new
                           {
                               Elohely = group.Key,
                               AtlagVeszelyessegiSzint = group.Average(szorny => szorny.VeszelyessegiSzint)
                           })
                           .OrderByDescending(x => x.AtlagVeszelyessegiSzint)
                           .Where(x => x.AtlagVeszelyessegiSzint > 6)
                           .Select(x => x.Elohely);
        }

    }
}
