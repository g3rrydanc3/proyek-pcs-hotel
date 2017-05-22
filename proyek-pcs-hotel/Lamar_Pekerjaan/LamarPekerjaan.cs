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

namespace proyek_pcs_hotel
{
    public partial class LamarPekerjaan : Form
    {
        public OracleConnection conn;
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
                String filename = openFileDialog1.FileName;
                textBox2.Text = filename;
                pictureBox1.ImageLocation = filename;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text) || String.IsNullOrEmpty(textBox5.Text) || String.IsNullOrEmpty(textBox6.Text) || String.IsNullOrEmpty(textBox8.Text) || String.IsNullOrEmpty(textBox9.Text) || (radioButton1.Checked == false && radioButton2.Checked == false) || (radioButton3.Checked == false && radioButton4.Checked == false))
            {
                MessageBox.Show("Semua Isian harap diisi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //dataGridView1.Rows.Clear();
            }
            else
            {
                var result = MessageBox.Show("Are you sure?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result.ToString() == "Yes")
                {
                    try
                    {
                        /*String SourceLoc = textBox9.Text;
                        FileStream fs = new FileStream(SourceLoc, FileMode.Open, FileAccess.Read);

                        // Create a byte array of file stream length
                        byte[] ImageData = new byte[fs.Length];

                        //Read block of bytes from stream into the byte array
                        fs.Read(ImageData, 0, System.Convert.ToInt32(fs.Length));

                        //Close the File Stream
                        fs.Close();

                        // Step 3
                        // Create Anonymous PL/SQL block string
                        String block = " BEGIN " +
                                       " INSERT INTO testblob (id, photo) VALUES (100, :1); " +
                                       " SELECT photo into :2 from testblob WHERE id = 100; " +
                                       " END; ";

                        // Set command to create Anonymous PL/SQL Block
                        OracleCommand cmd = new OracleCommand();
                        cmd.CommandText = block;
                        cmd.Connection = conn;


                        // Since executing an anonymous PL/SQL block, setting the command type
                        // as Text instead of StoredProcedure
                        cmd.CommandType = CommandType.Text;

                        // Step 4
                        // Setting Oracle parameters

                        // Bind the parameter as OracleDbType.Blob to command for inserting image
                        OracleParameter param = cmd.Parameters.Add("blobtodb", OracleDbType.Blob);
                        param.Direction = ParameterDirection.Input;


                        // Assign Byte Array to Oracle Parameter
                        param.Value = ImageData;

                        // Bind the parameter as OracleDbType.Blob to command for retrieving the image
                        OracleParameter param2 = cmd.Parameters.Add("blobfromdb", OracleDbType.Blob);
                        param2.Direction = ParameterDirection.Output;

                        // Step 5
                        // Execute the Anonymous PL/SQL Block

                        // The anonymous PL/SQL block inserts the image to the
                        // database and then retrieves the images as an output parameter
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Image file inserted to database from " + SourceLoc);

                        // Step 6
                        // Save the retrieved image to the DestinationLoc in the file system

                        // Create a byte array
                        byte[] byteData = new byte[0];

                        // fetch the value of Oracle parameter into the byte array
                        byteData = (byte[])((OracleBlob)(cmd.Parameters[1].Value)).Value;

                        // get the length of the byte array
                        int ArraySize = new int();
                        ArraySize = byteData.GetUpperBound(0);

                        // Write the Blob data fetched from database to the filesystem at the
                        // destination location
                        FileStream fs1 = new FileStream(@DestinationLoc,
                                                        FileMode.OpenOrCreate, FileAccess.Write);
                        fs1.Write(byteData, 0, ArraySize);
                        fs1.Close();

                        Console.WriteLine("Image saved to " + DestinationLoc + " successfully !");
                        Console.WriteLine("");
                        Console.WriteLine("***********************************************************");
                        Console.WriteLine("Before running this application again, execute 'Listing 1' ");
                        */
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        throw;
                    }
                }
            }
        }
    }
}
