using System;


namespace Infraestructura.Persistence.Tables
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int EmpresaId { get; set; }

        public Empresa Empresa { get; set; }
        public ICollection<Empleado> Empleados { get; set; }
    }
}
