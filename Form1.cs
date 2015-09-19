using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

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
                        string ko = Drive.VolumeLabel;
                        string dt = System.Convert.ToString(Drive.VolumeLabel);
                        usb_devices.Items.Add(Drive.Name.Remove(2));
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
            if (MessageBox.Show("¿Está seguro de que desea continuar? Esta acción no puede ser revertida.", "Formatear unidad", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string ui = System.Environment.GetFolderPath(Environment.SpecialFolder.System);
                string newui = ui.Remove(2);

                if (usb_devices.Text == newui)
                {
                    MessageBox.Show("La unidad " + newui.Remove(1) + " no puede ser formateada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (usb_devices.Text == "")
                {
                    MessageBox.Show("Por favor, seleccione una unidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string type = "/q";
                    string fs = "FAT32";
                    format(type, fs, usb_devices.Text);
                }
            }
        }

        private void format(string type, string filesystem, string name)
        {
            StreamWriter w_r;
            w_r = File.CreateText(@"bunny.bat");
            w_r.WriteLine("format /y" + type + "/fs:" + filesystem + " " + name);
            w_r.Close();
            System.Diagnostics.Process Proc1 = new System.Diagnostics.Process();
            Proc1.StartInfo.FileName = @"bunny.bat";
            Proc1.StartInfo.UseShellExecute = false;
            Proc1.StartInfo.CreateNoWindow = true;
            Proc1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Proc1.Start();
            Proc1.WaitForExit();
            File.Delete(@"bunny.bat");
            MessageBox.Show("Unidad formateada con éxito.", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
