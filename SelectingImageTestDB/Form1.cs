using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SelectingImageTestDB
{
    public partial class Form1 : Form
    {
        public static string conStr = "Data Source = localhost\\SQLCHEMS; Initial Catalog = DB_Image_Test; Integrated Security = true;";
        public static SqlConnection connection = new SqlConnection(conStr);
        public static SqlCommand command = new SqlCommand();
        public static SqlDataAdapter dataAdapter;
        public static DataSet dataSet = new DataSet();
        static string filename;
        public static int newUserID;
        public static Image avatar;

        public Form1()
        {
            InitializeComponent();
        }

        // QUIT BUTTON!
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you really want to exit ?", "Exit ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Application.Exit();
        }

        // BROWSE PHOTO BUTTON!
        private void btnBrowsePhoto_Click(object sender, EventArgs e)
        {
            DialogResult result = ofdopenImage.ShowDialog();
            if (result == DialogResult.OK)
            {
                filename = ofdopenImage.FileName;
                pbxUserImage.ImageLocation = filename;
                avatar = pbxUserImage.Image;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                dataAdapter = new SqlDataAdapter("SELECT * FROM UserData", connection);
                dataAdapter.Fill(dataSet, "user");

                int count = dataSet.Tables["user"].Rows.Count;

                if (count > 0)
                {
                    newUserID = Convert.ToInt32(dataSet.Tables["user"].Rows[count - 1][0]) + 1;
                    textBox1.Text = newUserID.ToString();
                }
                else
                {
                    newUserID = 1;
                    textBox1.Text = newUserID.ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ADD USER BUTTON!
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" && txtFname.Text == "" && txtLname.Text == "" && txtCurrentState.Text == "")
                {
                    MessageBox.Show("Fields are empty! \n Operation Failed", "Fields are empty!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DataRow row = dataSet.Tables["user"].NewRow();
                    row[0] = textBox1.Text;
                    row[1] = txtFname.Text;
                    row[2] = txtLname.Text;
                    row[3] = dtpBirthday.Value;
                    row[4] = txtCurrentState.Text;
                    FileStream st = new FileStream(@"" + filename + "", FileMode.Open);
                    byte[] buffer = new byte[st.Length];
                    st.Read(buffer, 0, (int)st.Length);
                    st.Close();
                    //row[5] = "SELECT * FROM Openrowset( Bulk '" + filename + "', SINGLE_BLOB) AS img";
                    row[5] = buffer;
                    dataSet.Tables["user"].Rows.Add(row);

                    SqlCommandBuilder comBuild = new SqlCommandBuilder(dataAdapter);
                    dataAdapter.Update(dataSet, "user");
                    string msg = " " + txtFname.Text + " " + txtLname.Text + " has been added!";
                    MessageBox.Show(msg, "User has been added!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnViewList_Click(object sender, EventArgs e)
        {
            try
            {
                UserList userListFrm = new UserList();

                if (userListFrm != null)
                {
                    Hide();
                    userListFrm.Show();
                }
                //else
                //{

                //    //    userListFrm.Activate();
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
