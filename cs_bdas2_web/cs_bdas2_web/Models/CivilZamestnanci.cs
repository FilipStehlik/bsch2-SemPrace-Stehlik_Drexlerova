using System;
using System.Collections.Generic;

namespace cs_bdas2_web.Models;

public partial class CivilZamestnanci
{
    /// <summary>
    /// Tabulka civilní zaměstnanec je informační centrum oledně každého civ. zaměstnance. V případě potřeby lze vyhledat jeho informace oddělení a pracovní pozici
    /// </summary>
    public decimal IdOsoba { get; set; }

    public decimal? IdOddeleni { get; set; }

    public decimal? IdPozice { get; set; }

    public virtual Oddeleni? IdOddeleniNavigation { get; set; }

    public virtual Osoby IdOsobaNavigation { get; set; } = null!;

    public virtual Pozice? IdPoziceNavigation { get; set; }
}
