using Infraestructura.Persistence.Tables;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Infraestructura.Persistence.Configuration
{
    public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.ToTable("Empleado", "dbo");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("Id")
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(e => e.Nombre)
                   .HasColumnName("Nombre")
                   .IsRequired()
                   .HasColumnType("nvarchar(max)");

            builder.Property(e => e.DepartamentoId)
                   .HasColumnName("DepartamentoId")
                   .IsRequired();


            // RELACION: Un "Empleado" tiene un "Departamento"
            builder.HasOne(d => d.Departamento)
               .WithMany(e => e.Empleados)
               .HasForeignKey(d => d.DepartamentoId)
               .OnDelete(DeleteBehavior.Restrict);

            // RELACION: Este "Empleado" esta en un "Proyecto"
            builder.HasMany(e => e.Proyectos)
               .WithOne(p => p.Empleado)
               .HasForeignKey(p => p.EmpleadoId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
