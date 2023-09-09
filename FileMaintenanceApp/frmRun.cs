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
    public partial class frmRun : Form
    {
        public frmRun()
        {
            InitializeComponent();
        }

        private void frmRun_Load(object sender, EventArgs e)
        {
            //obteniendo todos los procesos configurados
            using(var db = new FileMaintenanceDBContext())
            {
                grdData.DataSource = db.Proceso.ToList();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //
            int idProceso = (int)grdData.Rows[0].Cells[0].Value;
            //Buscar en la base el proceso obtenido
            using(var db = new FileMaintenanceDBContext())
            {
                var procesoObtenido = db.Proceso.Find(idProceso);
                if (procesoObtenido != null)
                {
                    #region BorradoArchivos
                    var myDirectory = new DirectoryInfo(procesoObtenido.Path);
                    foreach (var fi in myDirectory.GetFiles()) {
                        //Borramos y guardamos a la base
                        
                        var procesoDetalle = new ProcesoDetalle()
                        {
                           IdProceso = idProceso,
                           DeleteDate = DateTime.Now,
                           Extension = fi.Extension,
                           Weight_file = fi.Length * 1024*1024,
                           File_Name = fi.Name
                        };
                        db.ProcesoDetalle.Add(procesoDetalle);
                        db.SaveChanges();
                        fi.Delete();
                    }
                    #endregion
                    MessageBox.Show("Proceso Finalizado");
                }
            }
        }
    }
}
