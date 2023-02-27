using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab1_ClientWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                using (var client = new HttpClient())
                {
                    var url = "http://localhost:8080/mult";

                    var requestBody = new
                    {
                        param1 = "1",
                        param2 = "2"
                    };

                    int parmA = 2;

                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response =  client.PostAsync(url, ParmA);

                    if (response.Result.IsSuccessStatusCode)
                    {
                        var result =  response.Result.Content.ReadAsStringAsync();
                        MessageBox.Show(result.ToString());
                        // process the result here
                    }
                    else
                    {
                        // handle the error
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
