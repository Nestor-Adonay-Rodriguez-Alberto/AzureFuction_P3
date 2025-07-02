using Infraestructura.Persistence.Tables;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Infraestructura.Persistence.Configuration
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresa", "dbo");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("Id")
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(e => e.Nombre)
                   .HasColumnName("Nombre")
                   .IsRequired()
                   .HasColumnType("nvarchar(max)");
        
            // RELACION: Esta "Empresa" enta en un "Departamento"
            builder.HasMany(e => e.Departamentos)
                   .WithOne(d => d.Empresa)
                   .HasForeignKey(d => d.EmpresaId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
