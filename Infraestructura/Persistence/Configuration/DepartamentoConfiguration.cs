using Infraestructura.Persistence.Tables;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Infraestructura.Persistence.Configuration
{
    public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.ToTable("Departamento", "dbo");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("Id")
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(e => e.Nombre)
                   .HasColumnName("Nombre")
                   .IsRequired()
                   .HasColumnType("nvarchar(max)");

            builder.Property(e => e.EmpresaId)
                   .HasColumnName("EmpresaId")
                   .IsRequired();


            // RELACION: Un "Departamento" tiene una "Empresa"
            builder.HasOne(d => d.Empresa)
               .WithMany(e => e.Departamentos)
               .HasForeignKey(d => d.EmpresaId)
               .OnDelete(DeleteBehavior.Restrict);

            // RELACION: Este "Departamento" esta en un "Empleado"
            builder.HasMany(d => d.Empleados)
                   .WithOne(e => e.Departamento)
                   .HasForeignKey(e => e.DepartamentoId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
