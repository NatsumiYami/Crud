using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using Conexion;
using EntityFramework.DynamicFilters;

namespace Crud
{
    public partial class Prueba : DbContext
    {
        public Prueba()
            : base("name=Prueba")
        {
        }

        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }


        private void AddMyFilters(ref DbModelBuilder modelBuilder)
        {
            modelBuilder.Filter("banActivo", (ISoftDelete d) => d.banActivo, false);

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.Email)
                .IsUnicode(false);

            AddMyFilters (ref modelBuilder);

            modelBuilder.Filter("banActivo", (ISoftDelete d) => d.banActivo, false);

         /*      public override int SaveChanges()
        {
            foreach (var empleado in ChangeTracker.Entries<Empleado>()
                .Where(e => e.State == EntityState.Deleted && e.Metadata.GetProperties().Any(x => x.Name == "banActivo")))
            {
                empleado.State = EntityState.Unchanged;
                empleado.CurrentValues["banActivo"] = true;
            }
            return base.SaveChanges();
        }


        /*   modelBuilder.Filter("banActivo",
                   (Empleado b, Guid Id_empleado, bool banActivo) => (b.Id_empleado == Id_empleado) && (b.banActivo == banActivo),
                   () => GetPersonIDFromPrincipal(Thread.CurrentPrincipal),
                   () => false);*/

    }

        /*   public override int SaveChanges()
           {
               foreach (var empleado in ChangeTracker.Entries<Empleado>()
                   .Where(e => e.State == EntityState.Deleted && e.Entity is Empleado))
               {
                   empleado.State = EntityState.Unchanged;
                   empleado.CurrentValues["banActivo"] = true;
               }
               return base.SaveChanges();
           }*/


        /*TODO ESTO VA EN EL CONTROLADOR
           [HttpGet]
        public static IEnumerable<Empleado> GetAllDeleted()
            {
                var result = new List<Empleado>();

                using (var ctx = new Prueba())
                {
                    ctx.DisableFilter("banAcntivo");
                    result = ctx.Empleado.Include(x => x.banActivo).Where(x=> x.banActivo).ToList();
                    ctx.EnableFilter("banAcntivo");
                }

                return result;
            }
        
        
          [HttpPut]
           public IHttpActionResult BajaAlumno(int id)
           {
               var Empleados = conexion.Empleado.Find(id);
               using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
               {
                   SqlCommand cmd = new SqlCommand();
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.CommandText = "SPBajaEmpleado";
                   cmd.Parameters.Add("@Id_empleado", SqlDbType.BigInt).Value = Int64.Parse(Id_empleado);
                   cmd.Connection = connection;
                   connection.Open();
                   cmd.ExecuteNonQuery();
               }
               return NotFound();

          public async Task<IEnumerable> SaveChanges(int id)
             {
                 var candidate = await conexion.Empleado.FindAsync(id);

                 conexion.SaveChanges();
                 return bool.FalseString;
             }
        [HttpPatch("{id}")]
              public async Task<IActionResult> Patch(int id, JsonPatchDocument<Estudiante> _Estudiante)
              {
                  var Estudiante = await ctx.Estudiante.FindAsync(id);
                  if (Estudiante == null)
                  {
                      return NotFound();
                  }

                  _Estudiante.ApplyTo(Estudiante, ModelState);

                  await ctx.SaveChangesAsync();
                  return Ok(Estudiante);

            //borrado logico
        /*[HttpDelete("{id}")]
         public async Task<IHttpActionResult> Delete(long id)*/

        // actualizar nuevo
        /*  [HttpPut]
            public async Task<IHttpActionResult> Update(long id, [FromBody] Empleado item)
            {
                if (item == null || id == 0)
                {
                    return BadRequest();
                }
                conexion.Entry(item).State = EntityState.Modified;
                await conexion.SaveChangesAsync();

                return NotFound();
            }*/
        /*     [HttpPatch]
     public async Task<IHttpActionResult> Update(long id, [FromBody] string estatus)
     {
         var Empleado = await conexion.Empleado.FindAsync(id);
         if (Empleado == null || id == 0)
         {

           conexion.Entry(estatus).State = EntityState.Modified;
             await conexion.SaveChangesAsync();
             return Ok(estatus);
         }

           else
         {
             return NotFound();
         }
   }*/

        //actualizar
        /*    [HttpPut]
             public IHttpActionResult Update(int id, [FromBody] Empleado Empleados)

             {
                  var editar = conexion.Empleado.Find(id);
                 editar.banActivo = Empleados.banActivo;
                 conexion.Entry(Empleados).State = EntityState.Modified;
                 conexion.SaveChanges();
                 return Ok();


             }*/

        /*  DataTable dt = new DataTable();
             {

                 StringBuilder consulta = new StringBuilder(); //manejo de cadenas
                 consulta.AppendLine("select * from Empleado");//añade linea
                 SqlCommand cmd = new SqlCommand(consulta.ToString()); //se envia la consulta
                 cmd.CommandType = CommandType.Text;

                 using (SqlDataAdapter da = new SqlDataAdapter(cmd)) //Llenar tabla
                 {
                     lista.Fill(dt); //se le envia la variable de la consulta para llenar la informacion de la tabla
                 }

             }*/








    }


    //Metodo nueva de prueba para generar reporte en excel

    /*   [HttpGet]
       public async FileResult Task<ActionResult>Exportar()

           { 
           Id_empleado = 1;

               using (var empleado = new HttpClient())
               {
                   empleado.BaseAddress = new Uri("http://localhost:60608/");

               }

                   DataTable dt = new DataTable(); // almacena la consulta que se realiza a la base de datos 
               using (SqlConnection cn = new SqlConnection("Data Source=WCIFUENTES;Initial Catalog=IngresoEmpleado;Integrated Security=True"))//conexion

           {
                   cn.Open();
                   StringBuilder consulta = new StringBuilder(); //manejo de cadenas
                   consulta.AppendLine("select * from Empleado");//añade linea
                   SqlCommand cmd = new SqlCommand(consulta.ToString(), cn); //se envia la consulta
                 //  cmd.Parameters.AddWithValue("@Id_empleado", Id_empleado);//parametros de la consulta
                   cmd.CommandType = CommandType.Text;


                   using (SqlDataAdapter da = new SqlDataAdapter(cmd)) //Llenar tabla
                   {
                       da.Fill(dt); //se le envia la variable de la consulta para llenar la informacion de la tabla
                   }
               }


               //Generar libro mediante libreria CLOSEDXML

               dt.TableName = "Datos";

               using (XLWorkbook libro = new XLWorkbook()) // variable para crear libro con CLOSEDXML
               {
                   var hoja = libro.Worksheets.Add(dt);
                   hoja.ColumnsUsed().AdjustToContents();

                   using (MemoryStream stream = new MemoryStream()) //donde se almacenara
                   {
                       libro.SaveAs(stream);
                       return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Reporte " + DateTime.Now.ToString() + ".xlsx");
                   }
               } 

           }*/

    /*
     [HttpGet]
    public async Task<FileResult> Exportar(int Id_empleado)
    {
        Id_empleado = 1;


            string URL = "http://localhost:60608/";

        DataTable dt = new DataTable();
        {
            List<Empleado> lista = new List<Empleado>();    
        using (var empleado = new HttpClient())
        {
            empleado.BaseAddress = new Uri(URL);
            empleado.DefaultRequestHeaders.Clear();
            empleado.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage respuesta = await empleado.GetAsync("api/Empleado");
                if (respuesta.IsSuccessStatusCode)
                {
                    var contenido = respuesta.Content.ReadAsStringAsync().Result;
                    lista = JsonConvert.DeserializeObject<List<Empleado>>(contenido);



                    dt.TableName = "Datos";


                    using (XLWorkbook libro = new XLWorkbook()) // variable para crear libro con CLOSEDXML
                    {
                      var hoja = libro.Worksheets.Add(Id_empleado);
                       hoja.ColumnsUsed().AdjustToContents();


                        using (MemoryStream stream = new MemoryStream()) //donde se almacenara
                        {
                            libro.SaveAs(stream);
                            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Reporte " + DateTime.Now.ToString() + ".xlsx");

                        }
                    }


                }
            }
            return null;


        } */

}

