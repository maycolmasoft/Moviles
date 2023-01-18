using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft;
using Newtonsoft.Json;

namespace Moviles
{
    public partial class MainPage : ContentPage
    {

        private const string Url = "http://192.168.1.100/moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Moviles.Datos> _post;



        public MainPage()
        {
            InitializeComponent();
            obtener();
        }


        public async void obtener() {

            var content = await client.GetStringAsync(Url);
            List<Moviles.Datos> posts = JsonConvert.DeserializeObject<List<Moviles.Datos>>(content);
            _post = new ObservableCollection<Moviles.Datos>(posts);
            Lista.ItemsSource = _post;


        }

        private void btnInsertar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());

        }
    }
}
