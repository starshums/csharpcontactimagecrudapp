using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SelectingImageTestDB
{
    public partial class SelectedUser : Form
    {
        public SelectedUser()
        {
            InitializeComponent();
        }

        private void SelectedUser_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = UserList.tableItem.Rows[0][1].ToString() + " " + UserList.tableItem.Rows[0][2].ToString() + " Data";
                lblID.Text = UserList.tableItem.Rows[0][0].ToString();
                lblfName.Text = UserList.tableItem.Rows[0][1].ToString();
                lbllName.Text = UserList.tableItem.Rows[0][2].ToString();
                lblNameF.Text = UserList.tableItem.Rows[0][1].ToString();
                lblNameL.Text = UserList.tableItem.Rows[0][2].ToString();
                lblBirthday.Text = UserList.tableItem.Rows[0][3].ToString();
                lblState.Text = UserList.tableItem.Rows[0][4].ToString();
                Byte[] img = new Byte[0];
                img = (Byte[])(UserList.tableItem.Rows[0][5]);
                MemoryStream mstrm = new MemoryStream(img);
                pbxUserImage.Image = Image.FromStream(mstrm);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
