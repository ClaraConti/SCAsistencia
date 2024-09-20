using System;
using System.Linq;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaControlAsistencia
{
    public partial class frmAlumno : System.Web.UI.Page
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        private CAsistenciaDataContext asistencia = new CAsistenciaDataContext(cadena);

        private void Listar()
        {
            var consulta = from A in asistencia.TAlumno
                           select A;
            gvAlumno.DataSource = consulta.ToList();
            gvAlumno.DataBind();
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
                
                TAlumno nuevoAlumno = new TAlumno
                {
                    Nombre = txtNombre.Text,
                    CursoGrado = txtCursoGrado.Text,
                    Nivel = txtNivel.Text,
                    Telefono = txtTelefono.Text,
                    CodUsuario = txtCodUsuario.Text,
                    Direccion = txtDireccion.Text
                };

                asistencia.TAlumno.InsertOnSubmit(nuevoAlumno);
                asistencia.SubmitChanges();
                Listar();
                lblMensaje.Text = "Alumno agregado correctamente.";
                lblMensaje.CssClass = "alert alert-success";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al agregar alumno: " + ex.Message;
                lblMensaje.CssClass = "alert alert-danger";
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string codUsuario = txtCodUsuario.Text;
                var alumno = asistencia.TAlumno.SingleOrDefault(a => a.CodUsuario == codUsuario);

                if (alumno != null)
                {
                    alumno.Nombre = txtNombre.Text;
                    alumno.CursoGrado = txtCursoGrado.Text;
                    alumno.Nivel = txtNivel.Text;
                    alumno.Telefono = txtTelefono.Text;
                    alumno.Direccion = txtDireccion.Text;

                    asistencia.SubmitChanges();
                    Listar();
                    lblMensaje.Text = "Alumno actualizado correctamente.";
                    lblMensaje.CssClass = "alert alert-success";
                }
                else
                {
                    lblMensaje.Text = "Alumno no encontrado.";
                    lblMensaje.CssClass = "alert alert-warning";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al actualizar alumno: " + ex.Message;
                lblMensaje.CssClass = "alert alert-danger";
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtBuscar.Text; 
                var consulta = from A in asistencia.TAlumno
                               where A.Nombre.Contains(nombre) 
                               select A;

                gvAlumno.DataSource = consulta.ToList();
                gvAlumno.DataBind();

                lblMensaje.Text = consulta.Any() ? "" : "Alumno no encontrado.";
                lblMensaje.CssClass = consulta.Any() ? "" : "alert alert-warning";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al buscar alumno: " + ex.Message;
                lblMensaje.CssClass = "alert alert-danger";
            }
        }


        protected void btnVerTodos_Click(object sender, EventArgs e)
        {
            Listar();
        }

        protected void gvAlumno_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Editar")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    var alumno = asistencia.TAlumno.SingleOrDefault(a => a.IdAlumno == index);

                    if (alumno != null)
                    {
                        txtNombre.Text = alumno.Nombre;
                        txtCursoGrado.Text = alumno.CursoGrado;
                        txtNivel.Text = alumno.Nivel;
                        txtTelefono.Text = alumno.Telefono;
                        txtCodUsuario.Text = alumno.CodUsuario;
                        txtDireccion.Text = alumno.Direccion;

                        btnActualizar.Visible = true; 
                                                      
                    }
                }
                else if (e.CommandName == "Eliminar")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    var alumno = asistencia.TAlumno.SingleOrDefault(a => a.IdAlumno == index);

                    if (alumno != null)
                    {
                        asistencia.TAlumno.DeleteOnSubmit(alumno);
                        asistencia.SubmitChanges();
                        Listar();
                        lblMensaje.Text = "Alumno eliminado correctamente.";
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