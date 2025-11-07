using System;
using System.Collections.Generic;

namespace cs_bdas2_web.Models;

public partial class Lokality
{
    /// <summary>
    /// Lokalita je pro misi nezbytnou součástí. X a Y souřadnice jsou díky technologiím možné, a povinné udávat. Ulice, psč či obec jsou jen informační doplněk.
    /// </summary>
    public decimal IdLokalita { get; set; }

    public decimal SouradniceX { get; set; }

    public decimal SouradniceY { get; set; }

    public string? Ulice { get; set; }

    public decimal? CisloPopisne { get; set; }

    public string? Psc { get; set; }

    public string? Obec { get; set; }

    public virtual ICollection<Mise> Mises { get; set; } = new List<Mise>();
}
