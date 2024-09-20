using System;
using System.Linq;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaControlAsistencia
{
    public partial class frmAsignatura : System.Web.UI.Page
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        private CAsistenciaDataContext asistencia = new CAsistenciaDataContext(cadena);

        private void Listar()
        {
            var consulta = from A in asistencia.TAsignatura
                           join D in asistencia.TDocente on A.IdDocente equals D.IdDocente
                           select new
                           {
                               A.IdAsignatura,
                               A.NombreAsignatura,
                               A.DescripcionAsignatura,
                               DocenteNombre = D.Nombre 
                           };
            gvAsignatura.DataSource = consulta.ToList();
            gvAsignatura.DataBind();
        }


        private void CargarDocentes()
        {
            var docentes = from D in asistencia.TDocente
                           select new
                           {
                               D.IdDocente,
                               D.Nombre 
                           };
            ddlDocente.DataSource = docentes.ToList();
            ddlDocente.DataTextField = "Nombre";
            ddlDocente.DataValueField = "IdDocente";
            ddlDocente.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Listar(); 
                CargarDocentes(); 

                btnActualizar.Visible = false; 
            }
        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                TAsignatura nuevaAsignatura = new TAsignatura
                {
                    NombreAsignatura = txtNombreAsignatura.Text,
                   
                    DescripcionAsignatura = txtDescripcion.Text,
                    IdDocente = int.Parse(ddlDocente.SelectedValue) 
                };

                asistencia.TAsignatura.InsertOnSubmit(nuevaAsignatura);
                asistencia.SubmitChanges();
                Listar();
                lblMensaje.Text = "Asignatura agregada correctamente.";
                lblMensaje.CssClass = "alert alert-success";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al agregar asignatura: " + ex.Message;
                lblMensaje.CssClass = "alert alert-danger";
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["IdAsignatura"] != null)
                {
                    int idAsignatura = Convert.ToInt32(ViewState["IdAsignatura"]);
                    var asignatura = asistencia.TAsignatura.SingleOrDefault(a => a.IdAsignatura == idAsignatura);

                    if (asignatura != null)
                    {
                        asignatura.NombreAsignatura = txtNombreAsignatura.Text;
                        asignatura.DescripcionAsignatura = txtDescripcion.Text;
                        asignatura.IdDocente = int.Parse(ddlDocente.SelectedValue);

                        asistencia.SubmitChanges();
                        Listar();
                        lblMensaje.Text = "Asignatura actualizada correctamente.";
                        lblMensaje.CssClass = "alert alert-success";
                    }
                    else
                    {
                        lblMensaje.Text = "Asignatura no encontrada.";
                        lblMensaje.CssClass = "alert alert-warning";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al actualizar asignatura: " + ex.Message;
                lblMensaje.CssClass = "alert alert-danger";
            }
        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtBuscar.Text;
                var consulta = from A in asistencia.TAsignatura
                               where A.NombreAsignatura.Contains(nombre)
                               select A;

                gvAsignatura.DataSource = consulta.ToList();
                gvAsignatura.DataBind();

                lblMensaje.Text = consulta.Any() ? "" : "Asignatura no encontrada.";
                lblMensaje.CssClass = consulta.Any() ? "" : "alert alert-warning";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al buscar asignatura: " + ex.Message;
                lblMensaje.CssClass = "alert alert-danger";
            }
        }

        protected void btnVerTodas_Click(object sender, EventArgs e)
        {
            Listar();
        }

        protected void gvAsignatura_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Editar")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    var asignatura = asistencia.TAsignatura.SingleOrDefault(a => a.IdAsignatura == index);

                    if (asignatura != null)
                    {
                        txtNombreAsignatura.Text = asignatura.NombreAsignatura;
                        txtDescripcion.Text = asignatura.DescripcionAsignatura;
                        ddlDocente.SelectedValue = asignatura.IdDocente.ToString();

                        ViewState["IdAsignatura"] = asignatura.IdAsignatura;
                        btnActualizar.Visible = true; // Asegúrate de que el botón se muestre
                    }
                }

                else if (e.CommandName == "Eliminar")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    var asignatura = asistencia.TAsignatura.SingleOrDefault(a => a.IdAsignatura == index);

                    if (asignatura != null)
                    {
                        asistencia.TAsignatura.DeleteOnSubmit(asignatura);
                        asistencia.SubmitChanges();
                        Listar();
                        lblMensaje.Text = "Asignatura eliminada correctamente.";
                        lblMensaje.CssClass = "alert alert-success";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al procesar la acción: " + ex.Message;
                lblMensaje.CssClass = "alert alert-danger";
            }
        }

    }
}
