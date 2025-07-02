using System;


namespace Infraestructura.Persistence.Tables
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int DepartamentoId { get; set; }

        public Departamento Departamento { get; set; }
        public ICollection<Proyecto> Proyectos { get; set; }
    }
}
