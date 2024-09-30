using System;
using System.Configuration;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaControlAsistencia
{
    public partial class frmAsistencia : Page
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
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
            string codUsuario = Session["CodUsuario"]?.ToString();
            var docente = asistencia.TDocente.FirstOrDefault(d => d.CodUsuario == codUsuario);

            if (docente != null)
            {
                var cursos = from c in asistencia.TCurso
                             where c.IdDocente == docente.IdDocente
                             select new { c.IdCurso, c.NombreCurso };

                ddlCurso.DataSource = cursos.ToList();
                ddlCurso.DataTextField = "NombreCurso";
                ddlCurso.DataValueField = "IdCurso";
                ddlCurso.DataBind();
            }
        }

      
        protected void ddlCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarAlumnos();
        }

        private void CargarAlumnos()
        {
            int idCurso = int.Parse(ddlCurso.SelectedValue);
            var alumnos = from a in asistencia.TAlumno
                          join ins in asistencia.TInscripcion on a.IdAlumno equals ins.IdAlumno
                          where ins.IdCurso == idCurso
                          select new { a.IdAlumno, a.Nombre };

            gvAlumnos.DataSource = alumnos.ToList();
            gvAlumnos.DataBind();
        }

        
        protected void btnRegistrarAsistencia_Click(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = calAsistencia.SelectedDate.Date;

            foreach (GridViewRow row in gvAlumnos.Rows)
            {
                CheckBox chkAsistencia = (CheckBox)row.FindControl("chkAsistencia");
                int idAlumno = Convert.ToInt32(gvAlumnos.DataKeys[row.RowIndex].Value);
                string estado = chkAsistencia.Checked ? "Presente" : "Falta"; 

                RegistrarAsistencia(idAlumno, estado, fechaSeleccionada);
            }

            lblMensaje.Text = "Asistencia registrada correctamente.";
            lblMensaje.CssClass = "alert alert-success";

            CargarAsistenciaRegistrada();
        }

      
        private void RegistrarAsistencia(int idAlumno, string estado, DateTime fecha)
        {
            var nuevaAsistencia = new TAsistencia
            {
                IdAlumno = idAlumno,
                IdCurso = int.Parse(ddlCurso.SelectedValue),
                Fecha = fecha,
                Periodo = "2024", 
                Estado = estado
            };

            asistencia.TAsistencia.InsertOnSubmit(nuevaAsistencia);
            asistencia.SubmitChanges();
        }

        
        protected void calAsistencia_SelectionChanged(object sender, EventArgs e)
        {
            lblFechaSeleccionada.Text = "Fecha seleccionada: " + calAsistencia.SelectedDate.ToShortDateString();
        }

      
        private void CargarAsistenciaRegistrada()
        {
            int idCurso = int.Parse(ddlCurso.SelectedValue);
            DateTime fechaSeleccionada = calAsistencia.SelectedDate.Date;

            
            var asistenciaRegistrada = from a in asistencia.TAsistencia
                                       join al in asistencia.TAlumno on a.IdAlumno equals al.IdAlumno
                                       where a.IdCurso == idCurso && a.Fecha == fechaSeleccionada
                                       select new
                                       {
                                           al.IdAlumno,
                                           NombreAlumno = al.Nombre, 
                                           a.Estado,
                                           a.Fecha
                                       };

            gvAsistenciaRegistrada.DataSource = asistenciaRegistrada.ToList();
            gvAsistenciaRegistrada.DataBind();
        }

    }
}
