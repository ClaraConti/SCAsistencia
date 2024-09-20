using System;
using System.Linq;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaControlAsistencia
{
    public partial class frmDocente : System.Web.UI.Page
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        private CAsistenciaDataContext asistencia = new CAsistenciaDataContext(cadena);

        private void Listar()
        {
            var consulta = from D in asistencia.TDocente
                           select D;
            gvDocente.DataSource = consulta.ToList();
            gvDocente.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Listar();
                btnActualizar.Visible = false;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                TDocente nuevoDocente = new TDocente
                {
                    Nombre = txtNombre.Text,
                    Telefono = txtTelefono.Text,
                    CodUsuario = txtCodUsuario.Text
                };

                asistencia.TDocente.InsertOnSubmit(nuevoDocente);
                asistencia.SubmitChanges();
                Listar();
                lblMensaje.Text = "Docente agregado correctamente.";
                lblMensaje.CssClass = "alert alert-success";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al agregar docente: " + ex.Message;
                lblMensaje.CssClass = "alert alert-danger";
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string codUsuario = txtCodUsuario.Text;
                var docente = asistencia.TDocente.SingleOrDefault(d => d.CodUsuario == codUsuario);

                if (docente != null)
                {
                    docente.Nombre = txtNombre.Text;
                    docente.Telefono = txtTelefono.Text;

                    asistencia.SubmitChanges();
                    Listar();
                    lblMensaje.Text = "Docente actualizado correctamente.";
                    lblMensaje.CssClass = "alert alert-success";
                }
                else
                {
                    lblMensaje.Text = "Docente no encontrado.";
                    lblMensaje.CssClass = "alert alert-warning";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al actualizar docente: " + ex.Message;
                lblMensaje.CssClass = "alert alert-danger";
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtBuscar.Text;
                var consulta = from D in asistencia.TDocente
                               where D.Nombre.Contains(nombre)
                               select D;

                gvDocente.DataSource = consulta.ToList();
                gvDocente.DataBind();

                lblMensaje.Text = consulta.Any() ? "" : "Docente no encontrado.";
                lblMensaje.CssClass = consulta.Any() ? "" : "alert alert-warning";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al buscar docente: " + ex.Message;
                lblMensaje.CssClass = "alert alert-danger";
            }
        }

        protected void btnVerTodos_Click(object sender, EventArgs e)
        {
            Listar();
        }

        protected void gvDocente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Editar")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    var docente = asistencia.TDocente.SingleOrDefault(d => d.IdDocente == index);

                    if (docente != null)
                    {
                        txtNombre.Text = docente.Nombre;
                        txtTelefono.Text = docente.Telefono;
                        txtCodUsuario.Text = docente.CodUsuario;

                        btnActualizar.Visible = true; 
                    }
                }
                else if (e.CommandName == "Eliminar")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    var docente = asistencia.TDocente.SingleOrDefault(d => d.IdDocente == index);

                    if (docente != null)
                    {
                        asistencia.TDocente.DeleteOnSubmit(docente);
                        asistencia.SubmitChanges();
                        Listar();
                        lblMensaje.Text = "Docente eliminado correctamente.";
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
