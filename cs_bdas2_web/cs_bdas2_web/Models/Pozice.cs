using System;
using System.Collections.Generic;

namespace cs_bdas2_web.Models;

public partial class Pozice
{
    /// <summary>
    /// Pozice je informace pro civilního zaměstnance.
    /// </summary>
    public decimal IdPozice { get; set; }

    public string Nazev { get; set; } = null!;

    public virtual ICollection<CivilZamestnanci> CivilZamestnancis { get; set; } = new List<CivilZamestnanci>();
}
