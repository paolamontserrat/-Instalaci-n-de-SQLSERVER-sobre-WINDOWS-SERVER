using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Biblioteca
{
    public partial class _default : Page
    {
        private clsDaoLibros daoLibros;

        protected void Page_Load(object sender, EventArgs e)
        {
            daoLibros = new clsDaoLibros();
            if (!IsPostBack)
            {
                CargarLibros();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            // Validaciones manuales de los campos obligatorios
            if (string.IsNullOrWhiteSpace(txtISBN.Text) ||
                string.IsNullOrWhiteSpace(txtTitulo.Text) ||
                string.IsNullOrWhiteSpace(txtEdicion.Text) ||
                string.IsNullOrWhiteSpace(txtAnio.Text) ||
                string.IsNullOrWhiteSpace(txtAutores.Text) ||
                string.IsNullOrWhiteSpace(txtPais.Text) ||
                string.IsNullOrWhiteSpace(txtCarrera.Text) ||
                string.IsNullOrWhiteSpace(txtMateria.Text))
            {
                lblMensaje.Text = "Todos los campos obligatorios deben ser completados.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Validación del año (debe ser un número de 4 dígitos)
            if (txtAnio.Text.Length != 4 || !int.TryParse(txtAnio.Text, out int anio))
            {
                lblMensaje.Text = "El año debe ser un número de exactamente 4 dígitos.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            try
            {
                clsLibro libro = new clsLibro
                {
                    ISBN = txtISBN.Text,
                    Titulo = txtTitulo.Text,
                    NumeroEdicion = Convert.ToInt32(txtEdicion.Text),
                    AnioPublicacion = anio,
                    Autores = txtAutores.Text,
                    Pais = txtPais.Text,
                    Sinopsis = txtSinopsis.Text,
                    Carrera = txtCarrera.Text,
                    Materia = txtMateria.Text
                };

                string resultado = daoLibros.AgregarLibro(libro);
                lblMensaje.Text = resultado;
                lblMensaje.ForeColor = resultado.Contains("existe") ? System.Drawing.Color.Red : System.Drawing.Color.Green;

                if (!resultado.Contains("existe"))
                {
                    CargarLibros();
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al guardar el libro: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void CargarLibros()
        {
            List<clsLibro> libros = daoLibros.ObtenerLibros();
            gvLibros.DataSource = libros;
            gvLibros.DataBind();
        }
    }
}
