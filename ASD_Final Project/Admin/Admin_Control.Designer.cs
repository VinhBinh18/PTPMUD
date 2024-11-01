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
            this.components = new System.ComponentModel.Container();
            this.btn_del = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.txt_address = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_role = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_phone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Button();
            this.pn = new System.Windows.Forms.Panel();
            this.pn_btn_submit = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_role = new System.Windows.Forms.ComboBox();
            this.pn_txt_address = new System.Windows.Forms.TextBox();
            this.pn_txt_phone = new System.Windows.Forms.TextBox();
            this.pn_txt_name = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Address = new System.Windows.Forms.Label();
            this.labe100 = new System.Windows.Forms.Label();
            this.wHMANAGEMENTDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.pn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wHMANAGEMENTDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_del
            // 
            this.btn_del.Location = new System.Drawing.Point(185, 369);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(75, 23);
            this.btn_del.TabIndex = 25;
            this.btn_del.Text = "Xóa";
            this.btn_del.UseVisualStyleBackColor = true;
            // 
            // btn_edit
            // 
            this.btn_edit.Location = new System.Drawing.Point(339, 369);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(75, 23);
            this.btn_edit.TabIndex = 24;
            this.btn_edit.Text = "Sửa";
            this.btn_edit.UseVisualStyleBackColor = true;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(520, 369);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 23;
            this.btn_save.Text = "Lưu";
            this.btn_save.UseVisualStyleBackColor = true;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.ColumnHeadersHeight = 29;
            this.dgv.Location = new System.Drawing.Point(41, 185);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv.Size = new System.Drawing.Size(721, 150);
            this.dgv.TabIndex = 22;
            // 
            // txt_address
            // 
            this.txt_address.Location = new System.Drawing.Point(121, 125);
            this.txt_address.Name = "txt_address";
            this.txt_address.Size = new System.Drawing.Size(100, 20);
            this.txt_address.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Address";
            // 
            // txt_role
            // 
            this.txt_role.Location = new System.Drawing.Point(387, 125);
            this.txt_role.Name = "txt_role";
            this.txt_role.Size = new System.Drawing.Size(100, 20);
            this.txt_role.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(304, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Role";
            // 
            // txt_phone
            // 
            this.txt_phone.Location = new System.Drawing.Point(387, 59);
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.Size = new System.Drawing.Size(100, 20);
            this.txt_phone.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(304, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Phone";
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(121, 59);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(100, 20);
            this.txt_name.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "User name";
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(41, 369);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 13;
            this.btn_add.Text = "Thêm";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // pn
            // 
            this.pn.Controls.Add(this.pn_btn_submit);
            this.pn.Controls.Add(this.label5);
            this.pn.Controls.Add(this.cmb_role);
            this.pn.Controls.Add(this.pn_txt_address);
            this.pn.Controls.Add(this.pn_txt_phone);
            this.pn.Controls.Add(this.pn_txt_name);
            this.pn.Controls.Add(this.label7);
            this.pn.Controls.Add(this.Address);
            this.pn.Controls.Add(this.labe100);
            this.pn.Location = new System.Drawing.Point(574, 23);
            this.pn.Name = "pn";
            this.pn.Size = new System.Drawing.Size(230, 132);
            this.pn.TabIndex = 26;
            this.pn.Visible = false;
            this.pn.VisibleChanged += new System.EventHandler(this.pn_VisibleChanged);
            // 
            // pn_btn_submit
            // 
            this.pn_btn_submit.Location = new System.Drawing.Point(328, 277);
            this.pn_btn_submit.Name = "pn_btn_submit";
            this.pn_btn_submit.Size = new System.Drawing.Size(75, 23);
            this.pn_btn_submit.TabIndex = 12;
            this.pn_btn_submit.Text = "Submit";
            this.pn_btn_submit.UseVisualStyleBackColor = true;
            this.pn_btn_submit.Click += new System.EventHandler(this.pn_btn_submit_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Role";
            // 
            // cmb_role
            // 
            this.cmb_role.FormattingEnabled = true;
            this.cmb_role.Location = new System.Drawing.Point(363, 166);
            this.cmb_role.Name = "cmb_role";
            this.cmb_role.Size = new System.Drawing.Size(121, 21);
            this.cmb_role.TabIndex = 10;
            // 
            // pn_txt_address
            // 
            this.pn_txt_address.Location = new System.Drawing.Point(363, 90);
            this.pn_txt_address.Name = "pn_txt_address";
            this.pn_txt_address.Size = new System.Drawing.Size(100, 20);
            this.pn_txt_address.TabIndex = 9;
            // 
            // pn_txt_phone
            // 
            this.pn_txt_phone.Location = new System.Drawing.Point(363, 128);
            this.pn_txt_phone.Name = "pn_txt_phone";
            this.pn_txt_phone.Size = new System.Drawing.Size(100, 20);
            this.pn_txt_phone.TabIndex = 8;
            // 
            // pn_txt_name
            // 
            this.pn_txt_name.Location = new System.Drawing.Point(363, 55);
            this.pn_txt_name.Name = "pn_txt_name";
            this.pn_txt_name.Size = new System.Drawing.Size(100, 20);
            this.pn_txt_name.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Phone";
            // 
            // Address
            // 
            this.Address.AutoSize = true;
            this.Address.Location = new System.Drawing.Point(41, 90);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(45, 13);
            this.Address.TabIndex = 1;
            this.Address.Text = "Address";
            // 
            // labe100
            // 
            this.labe100.AutoSize = true;
            this.labe100.Location = new System.Drawing.Point(41, 46);
            this.labe100.Name = "labe100";
            this.labe100.Size = new System.Drawing.Size(35, 13);
            this.labe100.TabIndex = 0;
            this.labe100.Text = "Name";
            // 
            // wH_MANAGEMENTDataSet
            // 
            // 
            // wHMANAGEMENTDataSetBindingSource
            // 
            this.wHMANAGEMENTDataSetBindingSource.Position = 0;
            // 
            // Admin_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pn);
            this.Controls.Add(this.btn_del);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.txt_address);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_role);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_phone);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_add);
            this.Name = "Admin_Control";
            this.Text = "Admin_Control";
            this.Load += new System.EventHandler(this.Admin_Control_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.pn.ResumeLayout(false);
            this.pn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wHMANAGEMENTDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TextBox txt_address;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_role;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_phone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Panel pn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label Address;
        private System.Windows.Forms.Label labe100;
        private System.Windows.Forms.TextBox pn_txt_address;
        private System.Windows.Forms.TextBox pn_txt_phone;
        private System.Windows.Forms.TextBox pn_txt_name;
        private System.Windows.Forms.Button pn_btn_submit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_role;
        private System.Windows.Forms.BindingSource wHMANAGEMENTDataSetBindingSource;
    }
}