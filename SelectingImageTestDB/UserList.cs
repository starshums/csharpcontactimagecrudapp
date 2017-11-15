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
    public partial class UserList : Form
    {
        public UserList()
        {
            InitializeComponent();
            this.lvUserlist.Click +=new EventHandler(lvUserlist_Click);
        }

        public static ListViewItem lvi = new ListViewItem();
        public static DataTable table = new DataTable();
        public static DataTable tableItem = new DataTable();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Form1 frm = new Form1();

                if (frm != null)
                {
                    table.Clear();
                    lvUserlist.Clear();
                    this.Close();
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static int imgCount = 0;

        private void FillTable()
        {
            table = Form1.dataSet.Tables["user"];
        }

        private void UserList_Load(object sender, EventArgs e)
        {
            try
            {
                FillTable();

                foreach (DataRow row in table.Rows)
                {
                    var imageBytes = (byte[])row[5];
                    MemoryStream memStm = new MemoryStream(imageBytes);
                    memStm.Seek(0, SeekOrigin.Begin);
                    Image image = Image.FromStream(memStm);

                    ilUserImgList.Images.Add(imgCount.ToString(), image);

                    ilUserImgList.ImageSize = new Size(32, 32);
                    lvUserlist.LargeImageList = ilUserImgList;

                    lvi = lvUserlist.Items.Add(row[1].ToString());
                    lvi.ImageKey = imgCount.ToString();

                    imgCount++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lvUserlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lvUserlist_Click(object sender, EventArgs e)
        {
            try
            {
                FillTable();
                tableItem = table.Clone();

                if (lvUserlist.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < lvUserlist.Items.Count; i++)
                    {
                        if (lvUserlist.Items[i].Selected == true)
                        {
                            foreach (DataRow row in table.Rows)
                            {
                                if (lvUserlist.Items[i].ToString().Contains(row[1].ToString()))
                                {
                                    tableItem.ImportRow(row);
                                    break;
                                }
                            }
                        }
                    }

                    SelectedUser frmSlctUser = new SelectedUser();
                    frmSlctUser.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
