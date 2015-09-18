using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace bunny_files
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            DriveInfo[] ListDrives = DriveInfo.GetDrives();

            try
            {
                foreach (DriveInfo Drive in ListDrives)
                {
                    if (Drive.DriveType == DriveType.Removable)
                    {
                        usb_devices.Items.Add(Drive);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error al momento de cargar las unidades, intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void usb_devices_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("¿Está seguro de que desea continuar? Esta acción no puede ser revertida.", "Formatear unidad", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }

        private void format()
        {

        }
    }
}
