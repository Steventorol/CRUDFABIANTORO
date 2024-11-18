using System;
using System.Collections.Generic;

namespace CRUDFABIANTOROEF.Models;

public partial class LibrosAutor
{
    public int Id { get; set; }

    public int? Idautor { get; set; }

    public string? Isbn { get; set; }

    public virtual Autor? IdautorNavigation { get; set; }

    public virtual Libro? IsbnNavigation { get; set; }
}
