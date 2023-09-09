using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileMaintenanceApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            using (var db = new FileMaintenanceDBContext())
            {
                //Option 2: Login
                //Parametros
                var option = new SqlParameter("@Option", 2);
                var userName = new SqlParameter("@UserName", txtUserName.Text);
                var passWord = new SqlParameter("@Password", txtPassword.Text);

                var respuesta = db.sp_authenticate((int)option.Value, 
                    userName.Value.ToString(), passWord.Value.ToString());
              
                if(respuesta.SingleOrDefault() ==1) {
                    MessageBox.Show("Login correcto");
                }
                else { MessageBox.Show("Login incorrecto"); }
            }
        }
    }
}
