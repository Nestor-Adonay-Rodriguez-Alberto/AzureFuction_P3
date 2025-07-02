using System;


namespace Infraestructura.Persistence.Tables
{
    public class Proyecto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int EmpleadoId { get; set; }
        public bool Status { get; set; }

        public Empleado Empleado { get; set; }
    }
}
