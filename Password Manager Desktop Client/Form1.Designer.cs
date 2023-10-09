namespace Password_Manager_Desktop_Client;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.logInBtn = new System.Windows.Forms.Button();
            this.emailInput = new System.Windows.Forms.TextBox();
            this.passwordInput = new System.Windows.Forms.TextBox();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // logInBtn
            // 
            this.logInBtn.Location = new System.Drawing.Point(370, 383);
            this.logInBtn.Name = "logInBtn";
            this.logInBtn.Size = new System.Drawing.Size(75, 23);
            this.logInBtn.TabIndex = 0;
            this.logInBtn.Text = "Log In";
            this.logInBtn.UseVisualStyleBackColor = true;
            this.logInBtn.Click += new System.EventHandler(this.logInBtn_Click);
            // 
            // emailInput
            // 
            this.emailInput.Location = new System.Drawing.Point(336, 153);
            this.emailInput.Name = "emailInput";
            this.emailInput.Size = new System.Drawing.Size(149, 23);
            this.emailInput.TabIndex = 1;
            this.emailInput.TextChanged += new System.EventHandler(this.emailInput_Changed);
            // 
            // passwordInput
            // 
            this.passwordInput.Location = new System.Drawing.Point(336, 217);
            this.passwordInput.Name = "passwordInput";
            this.passwordInput.Size = new System.Drawing.Size(149, 23);
            this.passwordInput.TabIndex = 2;
            this.passwordInput.TextChanged += new System.EventHandler(this.passwordInput_Changed);
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(389, 135);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(36, 15);
            this.EmailLabel.TabIndex = 3;
            this.EmailLabel.Text = "Email";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(379, 199);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(57, 15);
            this.PasswordLabel.TabIndex = 4;
            this.PasswordLabel.Text = "Password";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.passwordInput);
            this.Controls.Add(this.emailInput);
            this.Controls.Add(this.logInBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private Button logInBtn;
    private TextBox emailInput;
    private TextBox passwordInput;
    private Label EmailLabel;
    private Label PasswordLabel;
}
