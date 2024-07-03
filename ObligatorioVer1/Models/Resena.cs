using System;
using System.Collections.Generic;

namespace ObligatorioVer1.Models;

public partial class Resena
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public int RestauranteId { get; set; }

    public int Puntaje { get; set; }

    public string Comentario { get; set; } = null!;

    public DateOnly FechaResena { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Restaurante Restaurante { get; set; } = null!;
}
