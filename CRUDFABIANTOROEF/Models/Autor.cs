using System;
using System.Collections.Generic;

namespace CRUDFABIANTOROEF.Models;

public partial class Autor
{
    public int Idautor { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Pais { get; set; }

    public virtual ICollection<LibrosAutor> LibrosAutors { get; set; } = new List<LibrosAutor>();
}
