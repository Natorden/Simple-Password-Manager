namespace Password_Manager_Desktop_Client
{
    partial class LogInPage
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
            this.userName_label = new System.Windows.Forms.Label();
            this.masterPassword_label = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userName_label
            // 
            this.userName_label.AutoSize = true;
            this.userName_label.Location = new System.Drawing.Point(415, 153);
            this.userName_label.Name = "userName_label";
            this.userName_label.Size = new System.Drawing.Size(75, 20);
            this.userName_label.TabIndex = 0;
            this.userName_label.Text = "Username";
            // 
            // masterPassword_label
            // 
            this.masterPassword_label.AutoSize = true;
            this.masterPassword_label.Location = new System.Drawing.Point(393, 219);
            this.masterPassword_label.Name = "masterPassword_label";
            this.masterPassword_label.Size = new System.Drawing.Size(119, 20);
            this.masterPassword_label.TabIndex = 1;
            this.masterPassword_label.Text = "Master Password";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(365, 176);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(167, 27);
            this.usernameTextBox.TabIndex = 2;
            this.usernameTextBox.TextChanged += new System.EventHandler(this.UsernameText_Changed);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(365, 242);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(167, 27);
            this.passwordTextBox.TabIndex = 3;
            this.passwordTextBox.TextChanged += new System.EventHandler(this.PasswordText_Changed);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(405, 285);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 4;
            this.button1.Text = "Log In";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.LogInButton_Clicked);
            // 
            // LogInPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.masterPassword_label);
            this.Controls.Add(this.userName_label);
            this.Name = "LogInPage";
            this.Size = new System.Drawing.Size(889, 610);
            this.Load += new System.EventHandler(this.LogInPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label userName_label;
        private Label masterPassword_label;
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Button button1;
    }
}
