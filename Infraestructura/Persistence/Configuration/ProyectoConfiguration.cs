using Infraestructura.Persistence.Tables;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Infraestructura.Persistence.Configuration
{
    public class ProyectoConfiguration : IEntityTypeConfiguration<Proyecto>
    {
        public void Configure(EntityTypeBuilder<Proyecto> builder)
        {
            builder.ToTable("Proyecto", "dbo");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("Id")
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(e => e.Nombre)
                   .HasColumnName("Nombre")
                   .IsRequired()
                   .HasColumnType("nvarchar(max)");

            builder.Property(e => e.EmpleadoId)
                   .HasColumnName("EmpleadoId")
                   .IsRequired();

            builder.Property(e => e.Status)
                   .HasColumnName("Status")
                   .IsRequired();


            // RELACION: Un "Proyecto" tiene un "Empleado"
            builder.HasOne(e => e.Empleado)
                   .WithMany(e => e.Proyectos)
                   .HasForeignKey(e => e.EmpleadoId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
