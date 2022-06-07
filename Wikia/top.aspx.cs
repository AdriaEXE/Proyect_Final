using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wikia
{
    public partial class top : System.Web.UI.Page
    {
        string strConexion = "Server=(local); Database=css; Integrated Security=true";
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        void cargarDatos()
        {
            using (var conexion = new SqlConnection(strConexion))
            {
                using (var command = new SqlCommand("Select * From topp", conexion))
                {
                    var ds = new DataSet();
                    var da = new SqlDataAdapter(command);
                    da.Fill(ds);

                    rpDatos.DataSource = ds;
                    rpDatos.DataBind();
                }
            }
        }
    }
}