using System;
using System.Linq;
using System.Configuration;
using System.Web.UI.WebControls;

namespace SistemaControlAsistencia
{
    public partial class frmSistemaAuxiliar : System.Web.UI.Page
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
            var cursos = asistencia.TCurso.Select(c => new { c.IdCurso, c.NombreCurso }).ToList();
            ddlCurso.DataSource = cursos;
            ddlCurso.DataTextField = "NombreCurso";
            ddlCurso.DataValueField = "IdCurso";
            ddlCurso.DataBind();
            ddlCurso.Items.Insert(0, new ListItem("Seleccionar Curso", ""));
        }

        protected void ddlCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarAlumnosInscritos();
        }

        private void CargarAlumnosInscritos()
        {
            if (string.IsNullOrEmpty(ddlCurso.SelectedValue))
            {
                gvAlumnosInscritos.DataSource = null;
                gvAlumnosInscritos.DataBind();
                return;
            }

            int idCurso = int.Parse(ddlCurso.SelectedValue);

            var alumnosInscritos = from a in asistencia.TAlumno
                                   join ins in asistencia.TInscripcion on a.IdAlumno equals ins.IdAlumno
                                   where ins.IdCurso == idCurso
                                   select new
                                   {
                                       NombreAlumno = a.Nombre
                                   };

            gvAlumnosInscritos.DataSource = alumnosInscritos.ToList();
            gvAlumnosInscritos.DataBind();
        }

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ddlCurso.SelectedValue))
            {
                lblMensaje.Text = "Por favor, seleccione un curso.";
                return;
            }

            if (string.IsNullOrEmpty(ddlMes.SelectedValue))
            {
                lblMensaje.Text = "Por favor, seleccione un mes.";
                return;
            }

            int idCurso = int.Parse(ddlCurso.SelectedValue);
            int mesSeleccionado = int.Parse(ddlMes.SelectedValue);
            int añoActual = DateTime.Now.Year;

           
            DateTime fechaInicio = new DateTime(añoActual, mesSeleccionado, 1);
            DateTime fechaFin = fechaInicio.AddMonths(1).AddDays(-1); 

            
            var reporte = from a in asistencia.TAlumno
                          join ins in asistencia.TInscripcion on a.IdAlumno equals ins.IdAlumno
                          where ins.IdCurso == idCurso
                          select new
                          {
                              NombreAlumno = a.Nombre,
                              Mes = fechaInicio.ToString("MMMM"),
                              Presentes = asistencia.TAsistencia.Count(x => x.IdAlumno == a.IdAlumno && x.Fecha >= fechaInicio && x.Fecha <= fechaFin && x.Estado == "Presente"),
                              Faltas = asistencia.TAsistencia.Count(x => x.IdAlumno == a.IdAlumno && x.Fecha >= fechaInicio && x.Fecha <= fechaFin && x.Estado == "Falta")
                          };

            if (reporte.Any())
            {
                gvReporteAsistencia.DataSource = reporte.ToList();
                gvReporteAsistencia.DataBind();
                lblMensaje.Text = "Reporte generado con éxito.";
            }
            else
            {
                gvReporteAsistencia.DataSource = null;
                gvReporteAsistencia.DataBind();
                lblMensaje.Text = "No se encontraron registros de asistencia para el curso seleccionado en el mes indicado.";
            }
        }

    }
}
