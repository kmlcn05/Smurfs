using.System.Data.SqlClient;

namespace WebUI.Models
{
    public class LoginModel
    {
        private InitializeComponent();
    }

    public string conString = "Data Source=45.158.14.184;User ID=sa;Password=***********";
    private void btnLogin_Click(object sender, RoutedEventArgs e)
    {
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        if (con.Stage==System.Data.ConnectionState.Open)
        
        var sorgu = (from x in db.Login
                     where x.USERNAME == TxtUserName.Text & x.PASSWORD == TxtPassword.Text
                     select x);
        if (sorgu.Any())
        {
            LoginModel lg1 = new LoginModel();
            lg1.Show();
            this.Hide();
        }
        else
        {
            MessageBox.Show("Invalid Username or Password, Please Try Again", "Login Error", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
}
}
