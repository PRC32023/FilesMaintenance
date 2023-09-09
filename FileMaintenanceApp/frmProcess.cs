using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileMaintenanceApp
{
    public partial class frmProcess : Form
    {
        public frmProcess()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txtPath.Text = folderBrowserDialog1.SelectedPath.ToString();
            #region BusquedaArchivos
           var myDirectory = new DirectoryInfo(txtPath.Text);
            //Recorrer el contenido
            int fileCount = myDirectory.GetFiles().Count();
            #endregion
            //guardar en base de datos
            using(var db = new FileMaintenanceDBContext())
            {
                //Crear objeto para guardar
                var newProcess = new Proceso()
                {
                    ProcessName= txtProcessName.Text,
                    FileCount=fileCount,
                    Path=txtPath.Text,
                    Date=DateTime.Now
                };
                db.Proceso.Add(newProcess);
                db.SaveChanges();
            }

        }

     
    }
}
