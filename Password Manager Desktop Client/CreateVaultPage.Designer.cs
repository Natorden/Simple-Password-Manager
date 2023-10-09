namespace Password_Manager_Desktop_Client
{
    partial class CreateVaultPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CredentialsGridView = new System.Windows.Forms.DataGridView();
            this.Site_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddNewPassword_Button = new System.Windows.Forms.Button();
            this.logOut_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CredentialsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // CredentialsGridView
            // 
            this.CredentialsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CredentialsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Site_name,
            this.Username,
            this.Password});
            this.CredentialsGridView.Location = new System.Drawing.Point(3, 102);
            this.CredentialsGridView.Name = "CredentialsGridView";
            this.CredentialsGridView.RowHeadersWidth = 51;
            this.CredentialsGridView.RowTemplate.Height = 29;
            this.CredentialsGridView.Size = new System.Drawing.Size(431, 397);
            this.CredentialsGridView.TabIndex = 0;
            // 
            // Site_name
            // 
            this.Site_name.HeaderText = "Site name";
            this.Site_name.MinimumWidth = 6;
            this.Site_name.Name = "Site_name";
            this.Site_name.Width = 125;
            // 
            // Username
            // 
            this.Username.HeaderText = "Username";
            this.Username.MinimumWidth = 6;
            this.Username.Name = "Username";
            this.Username.Width = 125;
            // 
            // Password
            // 
            this.Password.HeaderText = "Password";
            this.Password.MinimumWidth = 6;
            this.Password.Name = "Password";
            this.Password.Width = 125;
            // 
            // AddNewPassword_Button
            // 
            this.AddNewPassword_Button.Location = new System.Drawing.Point(72, 38);
            this.AddNewPassword_Button.Name = "AddNewPassword_Button";
            this.AddNewPassword_Button.Size = new System.Drawing.Size(94, 29);
            this.AddNewPassword_Button.TabIndex = 1;
            this.AddNewPassword_Button.Text = "Add new";
            this.AddNewPassword_Button.UseVisualStyleBackColor = true;
            this.AddNewPassword_Button.Click += new System.EventHandler(this.AddNewPassword_Click);
            // 
            // logOut_Button
            // 
            this.logOut_Button.Location = new System.Drawing.Point(274, 38);
            this.logOut_Button.Name = "logOut_Button";
            this.logOut_Button.Size = new System.Drawing.Size(94, 29);
            this.logOut_Button.TabIndex = 2;
            this.logOut_Button.Text = "Log out";
            this.logOut_Button.UseVisualStyleBackColor = true;
            this.logOut_Button.Click += new System.EventHandler(this.LogOut_Button_Click);
            // 
            // CreateVaultPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.logOut_Button);
            this.Controls.Add(this.AddNewPassword_Button);
            this.Controls.Add(this.CredentialsGridView);
            this.Name = "CreateVaultPage";
            this.Size = new System.Drawing.Size(437, 502);
            this.Load += new System.EventHandler(this.CreateVaultPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CredentialsGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView CredentialsGridView;
        private DataGridViewTextBoxColumn Site_name;
        private DataGridViewTextBoxColumn Username;
        private DataGridViewTextBoxColumn Password;
        private Button AddNewPassword_Button;
        private Button logOut_Button;
    }
}
