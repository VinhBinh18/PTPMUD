namespace ASD_Final_Project.Admin
{
    partial class Admin_Control
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
            this.pn_user_btn_del = new System.Windows.Forms.Button();
            this.pn_user_btn_edit = new System.Windows.Forms.Button();
            this.pn_user_dgv = new System.Windows.Forms.DataGridView();
            this.pn_user_txt_address = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pn_user_txt_role = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pn_user_txt_phone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pn_user_txt_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pn_user_btn_add = new System.Windows.Forms.Button();
            this.pn_user_add = new System.Windows.Forms.Panel();
            this.pn_user_add_btn_close = new System.Windows.Forms.Button();
            this.pn_user_btn_submit = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pn_user_cmb_role = new System.Windows.Forms.ComboBox();
            this.pn_user_add_txt_address = new System.Windows.Forms.TextBox();
            this.pn_user_add_txt_phone = new System.Windows.Forms.TextBox();
            this.pn_user_add_txt_name = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Address = new System.Windows.Forms.Label();
            this.labe100 = new System.Windows.Forms.Label();
            this.pn_user = new System.Windows.Forms.Panel();
            this.btn_user = new System.Windows.Forms.Button();
            this.btn_warehouse = new System.Windows.Forms.Button();
            this.pn_wh = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_home = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_role = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.pn_home = new System.Windows.Forms.Panel();
            this.pn_dgv_product = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pn_user_dgv)).BeginInit();
            this.pn_user_add.SuspendLayout();
            this.pn_user.SuspendLayout();
            this.pn_wh.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pn_dgv_product)).BeginInit();
            this.SuspendLayout();
            // 
            // pn_user_btn_del
            // 
            this.pn_user_btn_del.Location = new System.Drawing.Point(45, 387);
            this.pn_user_btn_del.Name = "pn_user_btn_del";
            this.pn_user_btn_del.Size = new System.Drawing.Size(75, 23);
            this.pn_user_btn_del.TabIndex = 25;
            this.pn_user_btn_del.Text = "Xóa";
            this.pn_user_btn_del.UseVisualStyleBackColor = true;
            this.pn_user_btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // pn_user_btn_edit
            // 
            this.pn_user_btn_edit.Location = new System.Drawing.Point(45, 427);
            this.pn_user_btn_edit.Name = "pn_user_btn_edit";
            this.pn_user_btn_edit.Size = new System.Drawing.Size(75, 23);
            this.pn_user_btn_edit.TabIndex = 24;
            this.pn_user_btn_edit.Text = "Sửa";
            this.pn_user_btn_edit.UseVisualStyleBackColor = true;
            // 
            // pn_user_dgv
            // 
            this.pn_user_dgv.AllowUserToAddRows = false;
            this.pn_user_dgv.AllowUserToDeleteRows = false;
            this.pn_user_dgv.AllowUserToResizeColumns = false;
            this.pn_user_dgv.ColumnHeadersHeight = 29;
            this.pn_user_dgv.Location = new System.Drawing.Point(45, 170);
            this.pn_user_dgv.Name = "pn_user_dgv";
            this.pn_user_dgv.ReadOnly = true;
            this.pn_user_dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.pn_user_dgv.Size = new System.Drawing.Size(656, 150);
            this.pn_user_dgv.TabIndex = 22;
            this.pn_user_dgv.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
            // 
            // pn_user_txt_address
            // 
            this.pn_user_txt_address.Location = new System.Drawing.Point(106, 117);
            this.pn_user_txt_address.Name = "pn_user_txt_address";
            this.pn_user_txt_address.Size = new System.Drawing.Size(100, 20);
            this.pn_user_txt_address.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Address";
            // 
            // pn_user_txt_role
            // 
            this.pn_user_txt_role.Location = new System.Drawing.Point(256, 117);
            this.pn_user_txt_role.Name = "pn_user_txt_role";
            this.pn_user_txt_role.Size = new System.Drawing.Size(100, 20);
            this.pn_user_txt_role.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Role";
            // 
            // pn_user_txt_phone
            // 
            this.pn_user_txt_phone.Location = new System.Drawing.Point(256, 51);
            this.pn_user_txt_phone.Name = "pn_user_txt_phone";
            this.pn_user_txt_phone.Size = new System.Drawing.Size(100, 20);
            this.pn_user_txt_phone.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Phone";
            // 
            // pn_user_txt_name
            // 
            this.pn_user_txt_name.Location = new System.Drawing.Point(106, 51);
            this.pn_user_txt_name.Name = "pn_user_txt_name";
            this.pn_user_txt_name.Size = new System.Drawing.Size(100, 20);
            this.pn_user_txt_name.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "User name";
            // 
            // pn_user_btn_add
            // 
            this.pn_user_btn_add.Location = new System.Drawing.Point(46, 347);
            this.pn_user_btn_add.Name = "pn_user_btn_add";
            this.pn_user_btn_add.Size = new System.Drawing.Size(75, 23);
            this.pn_user_btn_add.TabIndex = 13;
            this.pn_user_btn_add.Text = "Thêm";
            this.pn_user_btn_add.UseVisualStyleBackColor = true;
            this.pn_user_btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // pn_user_add
            // 
            this.pn_user_add.BackColor = System.Drawing.Color.MistyRose;
            this.pn_user_add.Controls.Add(this.pn_user_add_btn_close);
            this.pn_user_add.Controls.Add(this.pn_user_btn_submit);
            this.pn_user_add.Controls.Add(this.label5);
            this.pn_user_add.Controls.Add(this.pn_user_cmb_role);
            this.pn_user_add.Controls.Add(this.pn_user_add_txt_address);
            this.pn_user_add.Controls.Add(this.pn_user_add_txt_phone);
            this.pn_user_add.Controls.Add(this.pn_user_add_txt_name);
            this.pn_user_add.Controls.Add(this.label7);
            this.pn_user_add.Controls.Add(this.Address);
            this.pn_user_add.Controls.Add(this.labe100);
            this.pn_user_add.Dock = System.Windows.Forms.DockStyle.Right;
            this.pn_user_add.Location = new System.Drawing.Point(807, 0);
            this.pn_user_add.Margin = new System.Windows.Forms.Padding(2);
            this.pn_user_add.Name = "pn_user_add";
            this.pn_user_add.Size = new System.Drawing.Size(38, 596);
            this.pn_user_add.TabIndex = 26;
            this.pn_user_add.Visible = false;
            this.pn_user_add.VisibleChanged += new System.EventHandler(this.pn_VisibleChanged);
            this.pn_user_add.Paint += new System.Windows.Forms.PaintEventHandler(this.pn_add_Paint);
            // 
            // pn_user_add_btn_close
            // 
            this.pn_user_add_btn_close.BackColor = System.Drawing.Color.Red;
            this.pn_user_add_btn_close.Location = new System.Drawing.Point(0, 0);
            this.pn_user_add_btn_close.Margin = new System.Windows.Forms.Padding(0);
            this.pn_user_add_btn_close.Name = "pn_user_add_btn_close";
            this.pn_user_add_btn_close.Size = new System.Drawing.Size(25, 25);
            this.pn_user_add_btn_close.TabIndex = 13;
            this.pn_user_add_btn_close.Text = "X";
            this.pn_user_add_btn_close.UseVisualStyleBackColor = false;
            this.pn_user_add_btn_close.Click += new System.EventHandler(this.pn_user_add_btn_close_Click);
            // 
            // pn_user_btn_submit
            // 
            this.pn_user_btn_submit.Location = new System.Drawing.Point(50, 193);
            this.pn_user_btn_submit.Margin = new System.Windows.Forms.Padding(2);
            this.pn_user_btn_submit.Name = "pn_user_btn_submit";
            this.pn_user_btn_submit.Size = new System.Drawing.Size(122, 45);
            this.pn_user_btn_submit.TabIndex = 12;
            this.pn_user_btn_submit.Text = "Submit";
            this.pn_user_btn_submit.UseVisualStyleBackColor = true;
            this.pn_user_btn_submit.Click += new System.EventHandler(this.pn_btn_submit_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Role";
            // 
            // pn_user_cmb_role
            // 
            this.pn_user_cmb_role.FormattingEnabled = true;
            this.pn_user_cmb_role.Items.AddRange(new object[] {
            "Admin",
            "Manager",
            "Staff"});
            this.pn_user_cmb_role.Location = new System.Drawing.Point(76, 125);
            this.pn_user_cmb_role.Margin = new System.Windows.Forms.Padding(2);
            this.pn_user_cmb_role.Name = "pn_user_cmb_role";
            this.pn_user_cmb_role.Size = new System.Drawing.Size(121, 21);
            this.pn_user_cmb_role.TabIndex = 10;
            // 
            // pn_user_add_txt_address
            // 
            this.pn_user_add_txt_address.Location = new System.Drawing.Point(76, 63);
            this.pn_user_add_txt_address.Margin = new System.Windows.Forms.Padding(2);
            this.pn_user_add_txt_address.Multiline = true;
            this.pn_user_add_txt_address.Name = "pn_user_add_txt_address";
            this.pn_user_add_txt_address.Size = new System.Drawing.Size(121, 17);
            this.pn_user_add_txt_address.TabIndex = 9;
            // 
            // pn_user_add_txt_phone
            // 
            this.pn_user_add_txt_phone.Location = new System.Drawing.Point(76, 94);
            this.pn_user_add_txt_phone.Margin = new System.Windows.Forms.Padding(2);
            this.pn_user_add_txt_phone.Multiline = true;
            this.pn_user_add_txt_phone.Name = "pn_user_add_txt_phone";
            this.pn_user_add_txt_phone.Size = new System.Drawing.Size(121, 17);
            this.pn_user_add_txt_phone.TabIndex = 8;
            // 
            // pn_user_add_txt_name
            // 
            this.pn_user_add_txt_name.Location = new System.Drawing.Point(76, 35);
            this.pn_user_add_txt_name.Margin = new System.Windows.Forms.Padding(2);
            this.pn_user_add_txt_name.Multiline = true;
            this.pn_user_add_txt_name.Name = "pn_user_add_txt_name";
            this.pn_user_add_txt_name.Size = new System.Drawing.Size(121, 17);
            this.pn_user_add_txt_name.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 99);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Phone";
            // 
            // Address
            // 
            this.Address.AutoSize = true;
            this.Address.Location = new System.Drawing.Point(12, 71);
            this.Address.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(45, 13);
            this.Address.TabIndex = 1;
            this.Address.Text = "Address";
            // 
            // labe100
            // 
            this.labe100.AutoSize = true;
            this.labe100.Location = new System.Drawing.Point(12, 35);
            this.labe100.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labe100.Name = "labe100";
            this.labe100.Size = new System.Drawing.Size(35, 13);
            this.labe100.TabIndex = 0;
            this.labe100.Text = "Name";
            // 
            // pn_user
            // 
            this.pn_user.BackColor = System.Drawing.Color.DarkOrange;
            this.pn_user.Controls.Add(this.pn_user_txt_phone);
            this.pn_user.Controls.Add(this.label1);
            this.pn_user.Controls.Add(this.pn_user_txt_name);
            this.pn_user.Controls.Add(this.pn_user_btn_del);
            this.pn_user.Controls.Add(this.label2);
            this.pn_user.Controls.Add(this.pn_user_btn_edit);
            this.pn_user.Controls.Add(this.label3);
            this.pn_user.Controls.Add(this.pn_user_btn_add);
            this.pn_user.Controls.Add(this.pn_user_txt_role);
            this.pn_user.Controls.Add(this.label4);
            this.pn_user.Controls.Add(this.pn_user_dgv);
            this.pn_user.Controls.Add(this.pn_user_txt_address);
            this.pn_user.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_user.Location = new System.Drawing.Point(127, 100);
            this.pn_user.Name = "pn_user";
            this.pn_user.Size = new System.Drawing.Size(680, 496);
            this.pn_user.TabIndex = 29;
            // 
            // btn_user
            // 
            this.btn_user.Location = new System.Drawing.Point(12, 214);
            this.btn_user.Name = "btn_user";
            this.btn_user.Size = new System.Drawing.Size(108, 45);
            this.btn_user.TabIndex = 30;
            this.btn_user.Text = "button1";
            this.btn_user.UseVisualStyleBackColor = true;
            this.btn_user.Click += new System.EventHandler(this.btn_user_Click);
            // 
            // btn_warehouse
            // 
            this.btn_warehouse.Location = new System.Drawing.Point(12, 319);
            this.btn_warehouse.Name = "btn_warehouse";
            this.btn_warehouse.Size = new System.Drawing.Size(108, 45);
            this.btn_warehouse.TabIndex = 31;
            this.btn_warehouse.Text = "button2";
            this.btn_warehouse.UseVisualStyleBackColor = true;
            this.btn_warehouse.Click += new System.EventHandler(this.btn_warehouse_Click);
            // 
            // pn_wh
            // 
            this.pn_wh.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pn_wh.Controls.Add(this.pn_dgv_product);
            this.pn_wh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_wh.Location = new System.Drawing.Point(127, 100);
            this.pn_wh.Name = "pn_wh";
            this.pn_wh.Size = new System.Drawing.Size(680, 496);
            this.pn_wh.TabIndex = 32;
            this.pn_wh.Paint += new System.Windows.Forms.PaintEventHandler(this.pn_wh_Paint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PapayaWhip;
            this.panel1.Controls.Add(this.btn_home);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btn_user);
            this.panel1.Controls.Add(this.btn_warehouse);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(127, 596);
            this.panel1.TabIndex = 0;
            // 
            // btn_home
            // 
            this.btn_home.Location = new System.Drawing.Point(12, 137);
            this.btn_home.Name = "btn_home";
            this.btn_home.Size = new System.Drawing.Size(108, 45);
            this.btn_home.TabIndex = 34;
            this.btn_home.Text = "button1";
            this.btn_home.UseVisualStyleBackColor = true;
            this.btn_home.Click += new System.EventHandler(this.btn_home_Click);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(144, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1321, 101);
            this.panel2.TabIndex = 33;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.IndianRed;
            this.panel3.Controls.Add(this.lbl_role);
            this.panel3.Controls.Add(this.lbl_name);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(127, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(680, 100);
            this.panel3.TabIndex = 33;
            // 
            // lbl_role
            // 
            this.lbl_role.AutoSize = true;
            this.lbl_role.Location = new System.Drawing.Point(136, 39);
            this.lbl_role.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_role.Name = "lbl_role";
            this.lbl_role.Size = new System.Drawing.Size(35, 13);
            this.lbl_role.TabIndex = 30;
            this.lbl_role.Text = "label8";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(43, 39);
            this.lbl_name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(35, 13);
            this.lbl_name.TabIndex = 29;
            this.lbl_name.Text = "label6";
            // 
            // pn_home
            // 
            this.pn_home.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_home.Location = new System.Drawing.Point(127, 100);
            this.pn_home.Name = "pn_home";
            this.pn_home.Size = new System.Drawing.Size(680, 496);
            this.pn_home.TabIndex = 0;
            // 
            // pn_dgv_product
            // 
            this.pn_dgv_product.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pn_dgv_product.Location = new System.Drawing.Point(46, 170);
            this.pn_dgv_product.Name = "pn_dgv_product";
            this.pn_dgv_product.Size = new System.Drawing.Size(655, 150);
            this.pn_dgv_product.TabIndex = 0;
            // 
            // Admin_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 596);
            this.Controls.Add(this.pn_wh);
            this.Controls.Add(this.pn_user);
            this.Controls.Add(this.pn_home);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pn_user_add);
            this.Name = "Admin_Control";
            this.Text = "Admin_Control";
            this.Load += new System.EventHandler(this.Admin_Control_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pn_user_dgv)).EndInit();
            this.pn_user_add.ResumeLayout(false);
            this.pn_user_add.PerformLayout();
            this.pn_user.ResumeLayout(false);
            this.pn_user.PerformLayout();
            this.pn_wh.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pn_dgv_product)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button pn_user_btn_del;
        private System.Windows.Forms.Button pn_user_btn_edit;
        private System.Windows.Forms.DataGridView pn_user_dgv;
        private System.Windows.Forms.TextBox pn_user_txt_address;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox pn_user_txt_role;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox pn_user_txt_phone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pn_user_txt_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button pn_user_btn_add;
        private System.Windows.Forms.Panel pn_user_add;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label Address;
        private System.Windows.Forms.Label labe100;
        private System.Windows.Forms.TextBox pn_user_add_txt_address;
        private System.Windows.Forms.TextBox pn_user_add_txt_phone;
        private System.Windows.Forms.TextBox pn_user_add_txt_name;
        private System.Windows.Forms.Button pn_user_btn_submit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox pn_user_cmb_role;
        private System.Windows.Forms.Panel pn_user;
        private System.Windows.Forms.Button btn_user;
        private System.Windows.Forms.Button btn_warehouse;
        private System.Windows.Forms.Panel pn_wh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_role;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Button btn_home;
        private System.Windows.Forms.Panel pn_home;
        private System.Windows.Forms.Button pn_user_add_btn_close;
        private System.Windows.Forms.DataGridView pn_dgv_product;
    }
}