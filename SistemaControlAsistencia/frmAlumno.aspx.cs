using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaControlAsistencia
{
    public partial class frmAlumno : System.Web.UI.Page
    {
        // Llamar a la cadena de conexión
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        // Llamar al mapeado objeto Relacional
        private CAsistenciaDataContext dbContext = new CAsistenciaDataContext(cadena);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Listar();
                btnActualizar.Visible = false; // Ocultar el botón de actualizar inicialmente
            }
        }

        private void Listar()
        {
            var consulta = from A in dbContext.TAlumno
                           select A;
            gvAlumno.DataSource = consulta;
            gvAlumno.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si el código de usuario ya existe
                var usuarioExistente = dbContext.TUsuario.SingleOrDefault(u => u.CodUsuario == txtCodUsuario.Text);

                if (usuarioExistente == null)
                {
                    lblMensaje.Text = "El código de usuario no existe.";
                    return;
                }

                TAlumno nuevoAlumno = new TAlumno
                {
                    Nombre = txtNombre.Text,
                    Telefono = txtTelefono.Text,
                    CodUsuario = txtCodUsuario.Text
                };

                dbContext.TAlumno.InsertOnSubmit(nuevoAlumno);
                dbContext.SubmitChanges();
                Listar();
                lblMensaje.Text = "Alumno agregado correctamente.";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al agregar alumno: " + ex.Message;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text;
                var alumno = dbContext.TAlumno.SingleOrDefault(a => a.Nombre == nombre);

                if (alumno != null)
                {
                    dbContext.TAlumno.DeleteOnSubmit(alumno);
                    dbContext.SubmitChanges();
                    Listar();
                    lblMensaje.Text = "Alumno eliminado correctamente.";
                }
                else
                {
                    lblMensaje.Text = "Alumno no encontrado.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al eliminar alumno: " + ex.Message;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text;
                var alumno = dbContext.TAlumno.SingleOrDefault(a => a.Nombre == nombre);

                if (alumno != null)
                {
                    alumno.Nombre = txtNombre.Text;
                    alumno.Telefono = txtTelefono.Text;
                    alumno.CodUsuario = txtCodUsuario.Text;

                    dbContext.SubmitChanges();
                    Listar();
                    lblMensaje.Text = "Alumno actualizado correctamente.";
                }
                else
                {
                    lblMensaje.Text = "Alumno no encontrado.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al actualizar alumno: " + ex.Message;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtBuscar.Text;
                var consulta = from A in dbContext.TAlumno
                               where A.Nombre == nombre
                               select A;

                gvAlumno.DataSource = consulta.ToList();
                gvAlumno.DataBind();

                if (!consulta.Any())
                {
                    lblMensaje.Text = "Alumno no encontrado.";
                }
                else
                {
                    lblMensaje.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al buscar alumno: " + ex.Message;
            }
        }

        protected void btnVerTodos_Click(object sender, EventArgs e)
        {
            Listar();
        }

        protected void gvAlumno_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvAlumno.SelectedRow;
            txtNombre.Text = row.Cells[2].Text;
            txtTelefono.Text = row.Cells[3].Text;
            txtCodUsuario.Text = row.Cells[4].Text;

            btnActualizar.Visible = true; // Mostrar el botón de actualizar cuando se selecciona una fila
        }
    }
}
