using System;
using System.Collections.Generic;

namespace cs_bdas2_web.Models;

public partial class Skoleni
{
    /// <summary>
    /// Školení je pro vojáka nezbytné. Může být ale vytvořeno i bez přímého zahájení, tedy i bez aktuálních vojáků. Jakmile ale bude s dostatečným počtem zahájeno, ude muset býti i do nějaké doby ukončeno.
    /// </summary>
    public decimal IdSkoleni { get; set; }

    public string Nazev { get; set; } = null!;

    public DateTime? DatumZahajeni { get; set; }

    public DateTime? DatumUkonceni { get; set; }

    public string? Poznamka { get; set; }

    public virtual ICollection<Vojaci> IdVojaks { get; set; } = new List<Vojaci>();
}
