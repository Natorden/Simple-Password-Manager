
using Password_Manager_Desktop_Client.crypto;
using Web_Client.DTOs;

namespace Password_Manager_Desktop_Client
{
    public partial class AddCredentials : UserControl
    {
        private string? _cr_sitename;
        private string? _cr_username;
        private string? _cr_password;

        private CreateVaultPage _parentUserControl;
        private Form1 _parent;

        public AddCredentials(CreateVaultPage parentUserControl, Form1 parent)
        {
            _parentUserControl = parentUserControl;
            _parent = parent;
            InitializeComponent();
        }

        private void siteName_TextChanged(object sender, EventArgs e)
        {
            _cr_sitename = siteName.Text;
        }

        private void userName_TextChanged(object sender, EventArgs e)
        {
            _cr_username = userName.Text;
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            _cr_password = password.Text;
        }

        private void add_Click(object sender, EventArgs e)
        {
            var credentialDto = CreateCredentialDto();

            _parentUserControl.AddCredentialsToDto(credentialDto);

            ClearFields();

            ShowSuccess("Successfully added the credentials!");
        }

        private void close_Click(object sender, EventArgs e)
        {
            _parent.SetPage(_parentUserControl);
            this.Hide();
        }

        private DecryptedCredentialsDto CreateCredentialDto()
        {
            var credentials = new DecryptedCredentialsDto()
            {
                Sitename = _cr_sitename,
                Username = _cr_username,
                Password = _cr_password
            };

            return credentials;
        }

        private void ClearFields()
        {
            siteName.Text = "";
            userName.Text = "";
            password.Text = "";

            _cr_sitename = "";
            _cr_username = "";
            _cr_password = "";
        }

        public void ShowSuccess(string text)
        {
            var successBar = new CustomControls.NotificationLabelBar
            {
                BackColor = Color.Green,
                ButtonColor = Color.Maroon,
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point),
                ForeColor = Color.White,
                Location = new Point(0, 40),
                Margin = new Padding(5, 5, 5, 5),
                Name = "notificationLblBar",
                Size = new Size(Width, 0),
                Text = text
            };

            Controls.Add(successBar);
            successBar.BringToFront();
            successBar.ShowNotificationAsync(2000);
        }
    }
}
