﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crud.Models
{
    public class Edit
    {
        public int Id_empleado { get; set; }
        public bool banActivo { get; set; } = false;    
    }
}