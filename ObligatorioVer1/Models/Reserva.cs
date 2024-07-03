using System;
using System.Collections.Generic;

namespace ObligatorioVer1.Models;

public partial class Reserva
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public int MesaId { get; set; }

    public DateOnly FechaReserva { get; set; }

    public string Estado { get; set; } = null!;

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Mesa Mesa { get; set; } = null!;

    public virtual ICollection<Ordene> Ordenes { get; set; } = new List<Ordene>();

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
