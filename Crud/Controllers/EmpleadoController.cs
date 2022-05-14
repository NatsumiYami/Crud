using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Conexion;
using EntityFramework.DynamicFilters;

namespace Crud.Controllers
{
    public class EmpleadoController : ApiController
    {
        private IngresoEmpleadoEntities conexion = new IngresoEmpleadoEntities();

   

        //Listado

     [HttpGet]
      public IEnumerable<Empleado> Get()
        
        {
            using (IngresoEmpleadoEntities Empleados = new IngresoEmpleadoEntities())
            {
                return Empleados.Empleado.ToList();
            }
        }

        //Listado de clientes por cada registro
        [HttpGet]
        public Empleado Get(int id)
        {
            using (IngresoEmpleadoEntities Empleados = new IngresoEmpleadoEntities())
            {
                return Empleados.Empleado.FirstOrDefault(e => e.Id_empleado == id);
            }
        }
        //Metodo de agregar empleado

        [HttpPost]
        public IHttpActionResult AgregarEmpleado([FromBody] Empleado Empleados)
        {
            if (ModelState.IsValid)
            {
                conexion.Empleado.Add(Empleados);
                conexion.SaveChanges();
                return Ok(Empleados);
            }
            else
            {
                return BadRequest();
            }
        }



        //Metodo de actualizar empleado
        [HttpPut]
            public IHttpActionResult ActualizarEmpleado(int id, [FromBody] Empleado Empleados)
            {
                if (ModelState.IsValid)
                {
                    var existe = conexion.Empleado.Count(c => c.Id_empleado == id) > 0;
                    if (existe)
                    {
                        conexion.Entry(Empleados).State = EntityState.Modified;
                        conexion.SaveChanges();
                        return Ok();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }


        //Metodo de eliminar empleado

        [HttpDelete]
            public IHttpActionResult EliminarEmpleado(int id)
            {
                var Empleados = conexion.Empleado.Find(id);
                if (Empleados != null)
                {
                    conexion.Empleado.Remove(Empleados);
                    conexion.SaveChanges();
                    return Ok(Empleados);
                }
                else
                {
                    return NotFound();
                }
            }

        //Metodo de cambiar columna banActivo
      [HttpPatch]
        public async Task<IHttpActionResult> UpdateTodoItem(int id, Models.Edit todoItemDTO)
        {
            if (id != todoItemDTO.Id_empleado)
            {
                return BadRequest();
            }

            var todoItem = await conexion.Empleado.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            todoItem.banActivo = todoItemDTO.banActivo;

            try
            {
                await conexion.SaveChangesAsync();
                //object o = null;
                //int a = (int)o;

            }
            catch (Exception) 
            {
                return NotFound();
            }
            return Ok(todoItemDTO);

        }


        //parte nueva prueba reporteria

     
      


        }

    }
    


