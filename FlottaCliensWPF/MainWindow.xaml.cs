using FlottaCliensWPF.DTO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlottaCliensWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:5000")
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void loginbtn_Click(object sender, RoutedEventArgs e)
        {
            LoginDTO logindto = new LoginDTO()
            {
                LoginName = loginnametxt.Text,
                Password = passwordtxt.Text
            };
            string dtoString = JsonSerializer.Serialize(logindto,JsonSerializerOptions.Default);
            var body = new StringContent(dtoString,Encoding.UTF8,"application/json");
            var valasz = await client.PostAsync("/api/Login", body);
            result.Text = valasz.StatusCode.ToString();
        }
    }
}