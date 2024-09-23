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
                CargarNiveles();
            }
        }

        private void CargarNiveles()
        {
            ddlNivel.Items.Clear();
            ddlNivel.Items.Add(new ListItem("Seleccionar Nivel", ""));
            ddlNivel.Items.Add(new ListItem("Primaria", "Primaria"));
            ddlNivel.Items.Add(new ListItem("Secundaria", "Secundaria"));
        }

        protected void ddlNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlGrado.Items.Clear();
            ddlGrado.Items.Add(new ListItem("Seleccionar Grado", ""));
            int maxGrado = ddlNivel.SelectedValue == "Primaria" ? 6 : 5;

            for (int i = 1; i <= maxGrado; i++)
            {
                ddlGrado.Items.Add(new ListItem($"{i}er Grado", i.ToString()));
            }

            
            CargarAsignaturas();
        }

        private void CargarAsignaturas()
        {
            ddlAsignatura.Items.Clear();
            ddlAsignatura.Items.Add(new ListItem("Seleccionar Asignatura", ""));

            string nivel = ddlNivel.SelectedValue; 

            
            if (!string.IsNullOrEmpty(nivel))
            {
                var asignaturas = from a in asistencia.TAsignatura
                                  where a.Nivel == nivel 
                                  select a;

                foreach (var asignatura in asignaturas)
                {
                    ddlAsignatura.Items.Add(new ListItem(asignatura.NombreAsignatura, asignatura.IdAsignatura.ToString()));
                }
            }
        }


        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            string nivel = ddlNivel.SelectedValue;
            string grado = ddlGrado.SelectedValue;
            string trimestre = ddlTrimestre.SelectedValue;
            string asignaturaId = ddlAsignatura.SelectedValue;

            if (string.IsNullOrEmpty(nivel) || string.IsNullOrEmpty(grado) || string.IsNullOrEmpty(trimestre) || string.IsNullOrEmpty(asignaturaId))
            {
                lblMensaje.Text = "Por favor, seleccione todos los campos para generar el reporte.";
                return;
            }

            var fechaInicio = "";
            var fechaFin = "";

            switch (trimestre)
            {
                case "1er Trimestre":
                    fechaInicio = "2024-03-01";
                    fechaFin = "2024-05-31";
                    break;
                case "2do Trimestre":
                    fechaInicio = "2024-06-01";
                    fechaFin = "2024-08-31";
                    break;
                case "3er Trimestre":
                    fechaInicio = "2024-09-01";
                    fechaFin = "2024-11-30";
                    break;
            }

            var reporte = from A in asistencia.TAsistencia
                          join Al in asistencia.TAlumno on A.IdAlumno equals Al.IdAlumno
                          join I in asistencia.TInscripcion on A.IdAlumno equals I.IdAlumno
                          join Asig in asistencia.TAsignatura on I.IdAsignatura equals Asig.IdAsignatura
                          where Al.Nivel == nivel
                                && Al.CursoGrado == grado
                                && A.Fecha >= DateTime.Parse(fechaInicio)
                                && A.Fecha <= DateTime.Parse(fechaFin)
                                && Asig.IdAsignatura.ToString() == asignaturaId 
                          select new
                          {
                              NombreAlumno = Al.Nombre, 
                              CursoGrado = Al.CursoGrado,
                              Asignatura = Asig.NombreAsignatura,
                              A.Fecha,
                              A.Estado
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
                lblMensaje.Text = "No se encontraron registros de asistencia para los filtros seleccionados.";
            }
        }



    }
}
