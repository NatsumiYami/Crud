using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Web;
using EntityFramework.DynamicFilters;

namespace Crud.Models
{
    public class Empleado : ISoftDelete

    {


        public string Id_empleado { get; private set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime Fecha_nacimiento { get; set; }

      //  [DefaultValue(false)]
        public bool banActivo { get; set; }
    }

  
}