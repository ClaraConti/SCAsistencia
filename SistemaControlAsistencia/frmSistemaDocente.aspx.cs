using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaControlAsistencia
{
    public partial class frmSistemaDocente : Page
    {
        private static string cadena = System.Configuration.ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        private CAsistenciaDataContext asistencia = new CAsistenciaDataContext(cadena);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCursos();
                CargarCurso();
            }
        }

        
        private void CargarCursos()
        {
            
            var codUsuario = (string)Session["CodUsuario"];

            var docente = asistencia.TDocente.FirstOrDefault(d => d.CodUsuario == codUsuario);
            if (docente != null)
            {
                
                var cursosAsignados = from curso in asistencia.TCurso
                                      where curso.IdDocente == docente.IdDocente
                                      select new
                                      {
                                          curso.NombreCurso,
                                          curso.Descripcion,
                                          curso.Nivel
                                      };

               
                gvCursos.DataSource = cursosAsignados.ToList();
                gvCursos.DataBind();
            }
        }

        private void CargarCurso()
        {
            var codUsuario = (string)Session["CodUsuario"];
            var docente = asistencia.TDocente.FirstOrDefault(d => d.CodUsuario == codUsuario);

            if (docente != null)
            {
                
                var cursos = from curso in asistencia.TCurso
                             where curso.IdDocente == docente.IdDocente
                             select new
                             {
                                 curso.IdCurso,
                                 curso.NombreCurso
                             };

                ddlCursos.DataSource = cursos.ToList();
                ddlCursos.DataTextField = "NombreCurso";
                ddlCursos.DataValueField = "IdCurso";
                ddlCursos.DataBind();
            }
        }

       
        protected void btnRegistrarAsistencia_Click(object sender, EventArgs e)
        {
            int idCurso = int.Parse(ddlCursos.SelectedValue);
            
            Response.Redirect("frmAsistencia.aspx?idCurso=" + idCurso);
        }


        
        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Session.Remove("CodUsuario");
            Response.Redirect("frmLogin.aspx");
        }
    }
}

