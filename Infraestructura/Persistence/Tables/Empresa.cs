using System;


namespace Infraestructura.Persistence.Tables
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Departamento> Departamentos { get; set; }
    }
}
