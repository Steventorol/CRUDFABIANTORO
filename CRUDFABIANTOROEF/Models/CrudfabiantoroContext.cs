using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CRUDFABIANTOROEF.Models;

public partial class CrudfabiantoroContext : DbContext
{
    public CrudfabiantoroContext()
    {
    }

    public CrudfabiantoroContext(DbContextOptions<CrudfabiantoroContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autor> Autors { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Editoriale> Editoriales { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<LibrosAutor> LibrosAutors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-KM6DIQV\\MSSQLSERVER01;Initial Catalog=CRUDFABIANTORO;Integrated Security=True;Trust Server Certificate=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autor>(entity =>
        {
            entity.HasKey(e => e.Idautor).HasName("PK__Autor__9C1E582E5F13BED2");

            entity.ToTable("Autor");

            entity.Property(e => e.Idautor).ValueGeneratedNever();
            entity.Property(e => e.Apellido)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Pais)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.CodigoCategoria).HasName("PK__Categori__738F04AD86A0EB7A");

            entity.Property(e => e.CodigoCategoria)
                .ValueGeneratedNever()
                .HasColumnName("Codigo_categoria");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Editoriale>(entity =>
        {
            entity.HasKey(e => e.Nit).HasName("PK__Editoria__C7D1D6DBF2D1ACA6");

            entity.Property(e => e.Nit).ValueGeneratedNever();
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Sitioweb)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.Isbn).HasName("PK__Libros__9271CED185DE025B");

            entity.Property(e => e.Isbn)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CodigoCategoria).HasColumnName("Codigo_categoria");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro).HasColumnName("Fecha_registro");
            entity.Property(e => e.NitEditorial).HasColumnName("Nit_editorial");
            entity.Property(e => e.NombreAutor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nombre_autor");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.CodigoCategoriaNavigation).WithMany(p => p.Libros)
                .HasForeignKey(d => d.CodigoCategoria)
                .HasConstraintName("FK__Libros__Codigo_c__3B75D760");

            entity.HasOne(d => d.NitEditorialNavigation).WithMany(p => p.Libros)
                .HasForeignKey(d => d.NitEditorial)
                .HasConstraintName("FK__Libros__Nit_edit__3C69FB99");
        });

        modelBuilder.Entity<LibrosAutor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Libros_A__3214EC079CAEB849");

            entity.ToTable("Libros_Autor");

            entity.Property(e => e.Isbn)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdautorNavigation).WithMany(p => p.LibrosAutors)
                .HasForeignKey(d => d.Idautor)
                .HasConstraintName("FK__Libros_Au__Idaut__412EB0B6");

            entity.HasOne(d => d.IsbnNavigation).WithMany(p => p.LibrosAutors)
                .HasForeignKey(d => d.Isbn)
                .HasConstraintName("FK__Libros_Aut__Isbn__4222D4EF");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
