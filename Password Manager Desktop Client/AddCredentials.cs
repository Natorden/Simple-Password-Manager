
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

        public AddCredentials(CreateVaultPage parentUserControl)
        {
            _parentUserControl = parentUserControl;
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
        }


        private void close_Click(object sender, EventArgs e)
        {
            _parentUserControl.Controls.Remove(this);
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

    }
}
