namespace SelectingImageTestDB
{
    partial class UserList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserList));
            this.lvUserlist = new System.Windows.Forms.ListView();
            this.ilUserImgList = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvUserlist
            // 
            resources.ApplyResources(this.lvUserlist, "lvUserlist");
            this.lvUserlist.Name = "lvUserlist";
            this.lvUserlist.UseCompatibleStateImageBehavior = false;
            this.lvUserlist.SelectedIndexChanged += new System.EventHandler(this.lvUserlist_SelectedIndexChanged);
            // 
            // ilUserImgList
            // 
            this.ilUserImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            resources.ApplyResources(this.ilUserImgList, "ilUserImgList");
            this.ilUserImgList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.button1, "button1");
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UserList
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvUserlist);
            this.MaximizeBox = false;
            this.Name = "UserList";
            this.Load += new System.EventHandler(this.UserList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvUserlist;
        private System.Windows.Forms.ImageList ilUserImgList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}