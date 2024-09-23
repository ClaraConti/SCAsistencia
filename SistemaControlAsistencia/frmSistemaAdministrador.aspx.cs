using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaControlAsistencia
{
    public partial class frmSistemaAdministrador : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (Session["TipoUsuario"] != null && Session["TipoUsuario"].ToString() == "Administrador")
                {
                    lblAdministrador.Text = $"Bienvenido Admin: {Session["CodUsuario"]}";
                }
                else
                {
                    Response.Redirect("frmLogin.aspx");
                }
            }
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            
            Session.Remove("TipoUsuario");
            Session.Remove("CodUsuario");
            Response.Redirect("frmLogin.aspx");
        }

        protected void btnCrudAlumno_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmAlumno.aspx");
        }

        protected void btnCrudAuxiliar_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmAuxiliar.aspx");
        }

        protected void btnCrudDocente_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmDocente.aspx");
        }

        protected void btnCrudAsistencia_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmAsistencia.aspx");
        }

        protected void btnCrudUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmUsuario.aspx");
        }

        protected void btnCrudAsignatura_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmAsignatura.aspx");
        }
    }
}
