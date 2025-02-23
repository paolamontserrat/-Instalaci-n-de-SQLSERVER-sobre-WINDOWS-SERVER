<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Biblioteca._default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Registro de Libros</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Registro de Libros</h2>
            <table>
                <tr>
                    <td>ISBN:</td>
                    <td><asp:TextBox ID="txtISBN" runat="server" /></td>
                </tr>
                <tr>
                    <td>Título:</td>
                    <td><asp:TextBox ID="txtTitulo" runat="server" /></td>
                </tr>
                <tr>
                    <td>Número de Edición:</td>
                    <td><asp:TextBox ID="txtEdicion" runat="server" /></td>
                </tr>
                <tr>
                    <td>Año de Publicación:</td>
                    <td>
                        <asp:TextBox ID="txtAnio" runat="server" TextMode="Number" />
                        <asp:RequiredFieldValidator ID="rfvAnio" runat="server" ControlToValidate="txtAnio"
                            ErrorMessage="El año de publicación es obligatorio." ForeColor="Red" Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="revAnio" runat="server" ControlToValidate="txtAnio"
                            ValidationExpression="^\d{4}$" ErrorMessage="El año debe tener exactamente 4 dígitos." 
                            ForeColor="Red" Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td>Autores:</td>
                    <td><asp:TextBox ID="txtAutores" runat="server" /></td>
                </tr>
                <tr>
                    <td>País de Publicación:</td>
                    <td><asp:TextBox ID="txtPais" runat="server" /></td>
                </tr>
                <tr>
                    <td>Sinopsis:</td>
                    <td><asp:TextBox ID="txtSinopsis" runat="server" TextMode="MultiLine" Rows="3" /></td>
                </tr>
                <tr>
                    <td>Carrera:</td>
                    <td><asp:TextBox ID="txtCarrera" runat="server" /></td>
                </tr>
                <tr>
                    <td>Materia:</td>
                    <td><asp:TextBox ID="txtMateria" runat="server" /></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center;">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                    </td>
                </tr>
            </table>
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
            <h2>Lista de Libros Registrados</h2>
            <asp:GridView ID="gvLibros" runat="server" AutoGenerateColumns="true" />
        </div>
    </form>
</body>
</html>