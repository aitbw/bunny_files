using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using iTextSharp.text.pdf;

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
                        usb_devices.Items.Add(Drive.Name.Remove(2));
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error al momento de cargar las unidades, intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                else if ((usb_devices.Text == "") || (ofd.FileName == ""))
                {
                    MessageBox.Show("No ha seleccionado la unidad a formatear o no ha cargado un PDF.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                edit_pdf(ofd.FileName, (name + ofd.SafeFileName));
                MessageBox.Show("Unidad formateada y PDF escrito con éxito.", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error al momento de escribir el PDF.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        OpenFileDialog ofd = new OpenFileDialog();

        private void button2_Click(object sender, EventArgs e)
        {
            ofd.Filter = "PDF|*.pdf";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                label3.Text = ofd.SafeFileName;
                label3.Show();
                load_fields(ofd.FileName);
            }
        }

        public void edit_pdf(string oldfile, string newfile)
        {
            using (var existingFS = new FileStream(oldfile, FileMode.Open))
            using (var newFS = new FileStream(newfile, FileMode.Create))
            {
                var pdf = new PdfReader(existingFS);
                var stamper = new PdfStamper(pdf, newFS);
                var form = stamper.AcroFields;
                var fieldKeys = form.Fields.Keys;
                int n = 0;

                foreach (string fieldKey in fieldKeys)
                {
                    form.SetField(fieldKey, formulario.Controls[n].Text);
                    n++;
                }

                stamper.FormFlattening = true;

                stamper.Close();
                pdf.Close();
            }
        }

        public void load_fields(string file)
        {
            using (var loadfile = new FileStream(file, FileMode.Open))
            {
                var pdf = new PdfReader(loadfile);
                var form = pdf.AcroFields;
                var fieldKeys = form.Fields.Keys;
                TextBox[] fields = new TextBox[fieldKeys.Count];
                Label[] labels = new Label[fieldKeys.Count];

                for (int x = formulario.Controls.Count - 1; x >= 0; x--)
                {
                    if ((formulario.Controls[x] is TextBox) || (formulario.Controls[x] is Label))
                    {
                        formulario.Controls[x].Dispose();
                    }
                }

                for (int i = 0; i < fieldKeys.Count; i++)
                {
                    fields[i] = new TextBox();
                }

                for (int j = 0; j < fieldKeys.Count; j++)
                {
                    formulario.Controls.Add(fields[j]);
                    formulario.Show();
                }

                pdf.Close();
            }
        }
    }
}
