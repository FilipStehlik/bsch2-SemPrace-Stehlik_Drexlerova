using System;
using System.Collections.Generic;

namespace cs_bdas2_web.Models;

public partial class LogTable
{
    public string? Tabulka { get; set; }

    public string? Operace { get; set; }

    public DateTime? Cas { get; set; }

    public string? Uzivatel { get; set; }
}
