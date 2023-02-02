namespace UI.WinForm.ChildForms
{
    partial class FormClientMaintenance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClientMaintenance));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.titleBar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelMultiInsert = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panelAddedControl = new System.Windows.Forms.Panel();
            this.rbMultiInsert = new System.Windows.Forms.RadioButton();
            this.rbSingleInsert = new System.Windows.Forms.RadioButton();
            this.panelMultiInsert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelAddedControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleBar
            // 
            this.titleBar.BackColor = System.Drawing.Color.RoyalBlue;
            this.titleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar.Location = new System.Drawing.Point(1, 41);
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(752, 40);
            this.titleBar.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(142, 18);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "User maintenance\r\n";
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(712, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 1;
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // lblTitle1
            // 
            this.lblTitle1.AutoSize = true;
            this.lblTitle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lblTitle1.ForeColor = System.Drawing.Color.DimGray;
            this.lblTitle1.Location = new System.Drawing.Point(23, 54);
            this.lblTitle1.Name = "lblTitle1";
            this.lblTitle1.Size = new System.Drawing.Size(155, 26);
            this.lblTitle1.TabIndex = 94;
            this.lblTitle1.Text = "Mantenimiento";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(25, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 89;
            this.label1.Text = "Nombre:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.txtFirstName.Location = new System.Drawing.Point(28, 118);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(230, 22);
            this.txtFirstName.TabIndex = 1;
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.txtLastName.Location = new System.Drawing.Point(28, 174);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(230, 22);
            this.txtLastName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(25, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 96;
            this.label2.Text = "Apellido:";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.txtEmail.Location = new System.Drawing.Point(28, 233);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(230, 22);
            this.txtEmail.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(25, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 98;
            this.label3.Text = "Email:";
            // 
            // panelMultiInsert
            // 
            this.panelMultiInsert.Controls.Add(this.dataGridView1);
            this.panelMultiInsert.Controls.Add(this.btnAddClient);
            this.panelMultiInsert.Location = new System.Drawing.Point(2, 308);
            this.panelMultiInsert.Name = "panelMultiInsert";
            this.panelMultiInsert.Size = new System.Drawing.Size(750, 330);
            this.panelMultiInsert.TabIndex = 10;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 40;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(238)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.LightGray;
            this.dataGridView1.Location = new System.Drawing.Point(9, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 40;
            this.dataGridView1.RowTemplate.Height = 40;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(732, 282);
            this.dataGridView1.TabIndex = 108;
            // 
            // btnAddClient
            // 
            this.btnAddClient.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnAddClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.btnAddClient.ForeColor = System.Drawing.Color.White;
            this.btnAddClient.Location = new System.Drawing.Point(296, 3);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(150, 40);
            this.btnAddClient.TabIndex = 4;
            this.btnAddClient.Text = "Agregar";
            this.btnAddClient.UseVisualStyleBackColor = false;
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(212, 654);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 40);
            this.btnCancel.TabIndex = 99;
            this.btnCancel.Text = "X  Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(388, 654);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 40);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // panelAddedControl
            // 
            this.panelAddedControl.Controls.Add(this.rbMultiInsert);
            this.panelAddedControl.Controls.Add(this.rbSingleInsert);
            this.panelAddedControl.Location = new System.Drawing.Point(503, 45);
            this.panelAddedControl.Name = "panelAddedControl";
            this.panelAddedControl.Size = new System.Drawing.Size(241, 30);
            this.panelAddedControl.TabIndex = 106;
            // 
            // rbMultiInsert
            // 
            this.rbMultiInsert.AutoSize = true;
            this.rbMultiInsert.Checked = true;
            this.rbMultiInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMultiInsert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbMultiInsert.Location = new System.Drawing.Point(109, 3);
            this.rbMultiInsert.Name = "rbMultiInsert";
            this.rbMultiInsert.Size = new System.Drawing.Size(122, 19);
            this.rbMultiInsert.TabIndex = 6;
            this.rbMultiInsert.TabStop = true;
            this.rbMultiInsert.Text = "Inserción múltiple";
            this.rbMultiInsert.UseVisualStyleBackColor = true;
            // 
            // rbSingleInsert
            // 
            this.rbSingleInsert.AutoSize = true;
            this.rbSingleInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSingleInsert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbSingleInsert.Location = new System.Drawing.Point(8, 3);
            this.rbSingleInsert.Name = "rbSingleInsert";
            this.rbSingleInsert.Size = new System.Drawing.Size(95, 19);
            this.rbSingleInsert.TabIndex = 5;
            this.rbSingleInsert.Text = "Inserto único";
            this.rbSingleInsert.UseVisualStyleBackColor = true;
            this.rbSingleInsert.CheckedChanged += new System.EventHandler(this.rbSingleInsert_CheckedChanged_1);
            // 
            // FormClientMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(754, 715);
            this.Controls.Add(this.panelAddedControl);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panelMultiInsert);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormClientMaintenance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Client Maintenance";
            this.Controls.SetChildIndex(this.lblTitle1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtFirstName, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtLastName, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtEmail, 0);
            this.Controls.SetChildIndex(this.panelMultiInsert, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.panelAddedControl, 0);
            this.panelMultiInsert.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelAddedControl.ResumeLayout(false);
            this.panelAddedControl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel titleBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Label lblTitle1;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtFirstName;
        internal System.Windows.Forms.TextBox txtLastName;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtEmail;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelMultiInsert;
        internal System.Windows.Forms.Button btnAddClient;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panelAddedControl;
        private System.Windows.Forms.RadioButton rbMultiInsert;
        private System.Windows.Forms.RadioButton rbSingleInsert;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}