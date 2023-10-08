using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Data.Configuration
{
    public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
    {
        public void Configure(EntityTypeBuilder<Ciudad> builder){
            builder.ToTable("Ciudad"); //Nombre de la tabla

            builder.HasKey(e => e.Id); //Nos dice que existe una llave unica llamada Id
            builder.Property(e => e.Id); 

            builder.Property(e => e.Nombre) //Nos dice que tiene una llave llamada nombre
            .IsRequired() //Que debe ser obligatoria
            .HasMaxLength(50); // Y con maximo 50 caracteres

            builder.HasOne(p => p.Departamentos) //Relacionada las ciudades con los departamentos
            .WithMany(p => p.Ciudades) //Un departamento puede tener muchas ciudades
            .HasForeignKey(p => p.IdDepartamento); //Las ciudades estan asociadas a ese departamento
        }
    }
}