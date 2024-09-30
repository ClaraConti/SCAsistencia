using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaControlAsistencia
{
    public partial class frmSistemaAlumno : Page
    {
        
        private static string cadena = System.Configuration.ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        private CAsistenciaDataContext asistencia = new CAsistenciaDataContext(cadena);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCursos(); 
            }
        }

      
        private void CargarCursos()
        {
            
            var codUsuario = (string)Session["CodUsuario"];
            var alumno = asistencia.TAlumno.FirstOrDefault(a => a.CodUsuario == codUsuario);

            if (alumno != null)
            {
               
                var cursosInscritos = from curso in asistencia.TCurso
                                      join inscripcion in asistencia.TInscripcion on curso.IdCurso equals inscripcion.IdCurso
                                      where inscripcion.IdAlumno == alumno.IdAlumno
                                      select new
                                      {
                                          curso.IdCurso,
                                          curso.NombreCurso
                                      };

               
                ddlCursos.DataSource = cursosInscritos.ToList();
                ddlCursos.DataTextField = "NombreCurso";
                ddlCursos.DataValueField = "IdCurso";
                ddlCursos.DataBind();
            }
            else
            {
               
                lblMensaje.Text = "No se encontró al alumno.";
            }
        }

        
        protected void ddlCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            int idCurso = int.Parse(ddlCursos.SelectedValue);

           
            var codUsuario = (string)Session["CodUsuario"];
            var alumno = asistencia.TAlumno.FirstOrDefault(a => a.CodUsuario == codUsuario);

            if (alumno != null)
            {
               
                var faltas = from a in asistencia.TAsistencia
                             join curso in asistencia.TCurso on a.IdCurso equals curso.IdCurso
                             where a.IdCurso == idCurso && a.IdAlumno == alumno.IdAlumno && a.Estado == "Falta"
                             select new
                             {
                                 FechaFalta = a.Fecha,   
                                 Curso = curso.NombreCurso
                             };

                
                gvFaltas.DataSource = faltas.ToList();
                gvFaltas.DataBind();

                
                if (!faltas.Any())
                {
                    lblMensaje.Text = "No se encontraron faltas para este curso.";
                }
                else
                {
                    lblMensaje.Text = ""; 
                }
            }
        }

        
        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Session.Remove("CodUsuario");
            Response.Redirect("frmLogin.aspx");
        }
    }
}
