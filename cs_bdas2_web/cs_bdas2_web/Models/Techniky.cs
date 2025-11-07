using System;
using System.Collections.Generic;

namespace cs_bdas2_web.Models;

public partial class Techniky
{
    /// <summary>
    /// Technika musí mít datum výroby z důvodu bezpečí. Je také povinno býti uloženo v určitém útvaru.
    /// </summary>
    public decimal IdTechnika { get; set; }

    public string Nazev { get; set; } = null!;

    public DateTime DatumVyroby { get; set; }

    public decimal IdUtvar { get; set; }

    public virtual Utvary IdUtvarNavigation { get; set; } = null!;
}
