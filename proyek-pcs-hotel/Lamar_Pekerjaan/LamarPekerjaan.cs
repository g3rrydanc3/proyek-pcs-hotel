using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
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
using System.Net;
using System.Net.Mail;

namespace proyek_pcs_hotel
{
    public partial class LamarPekerjaan : Form
    {
        public OracleConnection conn;
        String fileLocation, fileName;
        String appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\Pictures\";
        int urutan;

        public LamarPekerjaan()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Application.StartupPath;
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "Open File JPG, JPEG, PNG";
            openFileDialog1.Filter = "JPG, JPEG, PNG files|*.JPG|*.JPEG|*.PNG";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileLocation = openFileDialog1.FileName;
                textBoxFoto.Text = fileLocation;
                fileName = openFileDialog1.SafeFileName;
                pictureBox1.ImageLocation = fileLocation;
            }
        }

        private void textBoxTelepon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -2))
            {
                e.Handled = true;
            }
        }

        private void textBoxEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '@') && ((sender as TextBox).Text.IndexOf('@') > -1))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxNama.Text) || String.IsNullOrEmpty(textBoxTempatLahir.Text) || String.IsNullOrEmpty(textBoxAgama.Text) || String.IsNullOrEmpty(textBoxAlamat.Text) || String.IsNullOrEmpty(textBoxTelepon.Text) || String.IsNullOrEmpty(textBoxEmail.Text) || String.IsNullOrEmpty(textBoxPendidikan.Text) || String.IsNullOrEmpty(textBoxFoto.Text) || (radioButton1.Checked == false && radioButton2.Checked == false) || (radioButton3.Checked == false && radioButton4.Checked == false) || (radioButton5.Checked == false && radioButton6.Checked == false && radioButton7.Checked == false && radioButton8.Checked == false && radioButton9.Checked == false))
            {
                MessageBox.Show("Semua Isian harap diisi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("Are you sure?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    OracleDataAdapter adap = new OracleDataAdapter("select max(kode_pelamar) from pelamar", conn);
                    DataTable dt = new DataTable();
                    adap.Fill(dt);
                    if (dt.Rows[0].ItemArray[0].ToString() == "")
                    {
                        urutan = 1;
                    }
                    else
                    {
                        urutan = Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString()) + 1;
                    }
                    String[] potong = fileName.Split('.');
                    int length = potong.Count()-1;
                    String fileSimpan = urutan + "." + potong[length];

                    OracleCommand cmd = new OracleCommand("insert into pelamar values(:a, :b, :c, to_date(:d, 'DD-MM-YY'), :f, :e, :g, :h, :i, :j, :k, :l, :n, :m)", conn);
                    cmd.Parameters.Add(":a", urutan);
                    cmd.Parameters.Add(":b", textBoxNama.Text);
                    cmd.Parameters.Add(":c", textBoxTempatLahir.Text);
                    cmd.Parameters.Add(":d", dateTimePicker1.Value.ToString("dd-MM-yy"));
                    
                    if (radioButton1.Checked == true)
                    {
                        cmd.Parameters.Add(":f", "Laki-laki");
                    }
                    else if (radioButton2.Checked == true)
                    {
                        cmd.Parameters.Add(":f", "Perempuan");
                    }
                    cmd.Parameters.Add(":e", textBoxAgama.Text);

                    if (radioButton3.Checked == true)
                    {
                        cmd.Parameters.Add(":g", "WNI");
                    }
                    else if (radioButton4.Checked == true)
                    {
                        cmd.Parameters.Add(":g", "WNA");
                    }

                    if(checkBox1.Checked == true)
                    {
                        cmd.Parameters.Add(":h", "Menikah");
                    }
                    else
                    {
                        cmd.Parameters.Add(":h", "Single");
                    }

                    cmd.Parameters.Add(":i", textBoxPendidikan.Text);
                    cmd.Parameters.Add(":j", textBoxAlamat.Text);
                    cmd.Parameters.Add(":k", textBoxTelepon.Text);
                    cmd.Parameters.Add(":l", textBoxEmail.Text);
                    cmd.Parameters.Add(":n", fileSimpan);
                    if (radioButton5.Checked == true)
                    {
                        cmd.Parameters.Add(":m", 5);
                    }
                    else if (radioButton6.Checked == true)
                    {
                        cmd.Parameters.Add(":m", 1);
                    }
                    else if (radioButton7.Checked == true)
                    {
                        cmd.Parameters.Add(":m", 2);
                    }
                    else if (radioButton8.Checked == true)
                    {
                        cmd.Parameters.Add(":m", 3);
                    }
                    else if (radioButton9.Checked == true)
                    {
                        cmd.Parameters.Add(":m", 4);
                    }
                    MessageBox.Show(urutan.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Selamat! Anda berhasil melamar pekerjaan");
                    File.Copy(fileLocation, appPath + fileSimpan);


                    /**string smtpAddress = "smtp.gmail.com";
                    int portNumber = 587;
                    bool enableSSL = true;

                    string emailFrom = "andhikakurnia21@gmail.com";
                    string password = "windows098";
                    string emailTo = "alfonsiaronnalf@gmail.com";
                    string subject = "Hello";
                    string body = "Hello, I'm just writing this to say Hi!";

                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress(emailFrom);
                        mail.To.Add(emailTo);
                        mail.Subject = subject;
                        mail.Body = body;
                        mail.IsBodyHtml = true;
                        // Can set to false, if you are sending pure text.

                        //mail.Attachments.Add(new Attachment("C:\\SomeFile.txt"));
                        //mail.Attachments.Add(new Attachment("C:\\SomeZip.zip"));

                        using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                        {
                            smtp.Credentials = new NetworkCredential(emailFrom, password);
                            smtp.EnableSsl = enableSSL;
                            smtp.Send(mail);
                        }
                    }*/

                    /*var fromAddress = new MailAddress("andhikakurnia21@gmail.com", "HOTEL TRANSILVINIA");
                    var toAddress = new MailAddress("alfonsiaronnalf@gmail.com", "Ronna");
                    const string fromPassword = "windows098";
                    const string subject = "Halo";
                    const string body = "Selamat";

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 1521,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                    };
                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(message);
                    }
                    this.Close();*/
                }
            }
        }
    }
}
