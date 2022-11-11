using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.IO;

namespace FIle_Encyrptor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.Text = System.Web.Security.Membership.GeneratePassword(30, 8);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Clear();
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string FilePath = openFileDialog.FileName;
                    textBox1.Text = FilePath;

                    string FileName = openFileDialog.SafeFileName;
                    string FileExt = Path.GetExtension(FilePath);
                    var FileSize = new FileInfo(FilePath).Length;

                    label3.Text = FileName;
                    label5.Text = FilePath;
                    label7.Text = FileExt;
                    label10.Text = FileSize.ToString() + " Bytes";

                }
                else
                {
                    MessageBox.Show("File corrupted or missing!");
                }
            }
            catch (Exception s)
            {
                MessageBox.Show(s.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != string.Empty)
            {
                try
                {
                    byte[] data = File.ReadAllBytes(textBox1.Text);
                    byte[] pw = Encoding.UTF8.GetBytes(textBox2.Text);

                    if (MessageBox.Show("BACKUP YOUR PASSWORD!", "READ THIS!", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                    {
                        byte[] encrypted = Aes.Encrypt(data, pw);
                        File.WriteAllBytes(textBox1.Text, encrypted);
                        MessageBox.Show("File Encrypted!");
                    }
                }
                catch (Exception s)
                {
                    MessageBox.Show(s.ToString());
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                textBox4.Clear();
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string FilePath = openFileDialog.FileName;
                    textBox4.Text = FilePath;

                    string FileName = openFileDialog.SafeFileName;
                    string FileExt = Path.GetExtension(FilePath);
                    var FileSize = new FileInfo(FilePath).Length;

                    label20.Text = FileName;
                    label18.Text = FilePath;
                    label16.Text = FileExt;
                    label13.Text = FileSize.ToString() + " Bytes";

                }
                else
                {
                    MessageBox.Show("File corrupted or missing!");
                }
            }
            catch (Exception s)
            {
                MessageBox.Show(s.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != string.Empty)
            {
                try
                {
                    byte[] data11 = File.ReadAllBytes(textBox4.Text);
                    byte[] pw11 = Encoding.UTF8.GetBytes(textBox3.Text);

                    if (MessageBox.Show("MAKE SURE THE PASSWORD IS CORRECT OR THE FILE WIL BE CORRUPTED!", "READ THIS!", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                    {
                        byte[] Decrypted = Aes.Decrypt(data11, pw11);
                        File.WriteAllBytes(textBox4.Text, Decrypted);
                        MessageBox.Show("File Decrypted!");
                    }

                }
                catch (Exception s)
                {
                    MessageBox.Show(s.ToString());
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

