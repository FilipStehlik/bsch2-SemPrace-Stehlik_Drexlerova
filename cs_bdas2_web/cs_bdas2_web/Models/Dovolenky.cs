using System;
using System.Collections.Generic;

namespace cs_bdas2_web.Models;

public partial class Dovolenky
{
    /// <summary>
    /// Dovolenka je možná pro každou osobu v databázi. Pokud je uznáno datum zahájení, tak datum ukončení později také.
    /// </summary>
    public decimal IdDovolenka { get; set; }

    public DateTime DatumZahajeni { get; set; }

    public DateTime? DatumUkonceni { get; set; }

    public string Duvod { get; set; } = null!;

    public virtual ICollection<Osoby> Osobies { get; set; } = new List<Osoby>();
}
