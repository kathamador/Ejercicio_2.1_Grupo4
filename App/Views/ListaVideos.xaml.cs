using App.Models;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaVideos : ContentPage
    {

        public ListaVideos()
        {
            BindingContext = this;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            Lista.ItemsSource = await App.VideosRepositorio.GetAll();
        }

        private async void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count == 0)
                return;

            await Navigation.PushAsync(new VideoAdmin((Video)((CollectionView)sender).SelectedItem));

            ((CollectionView)sender).SelectedItem = null;
        }

        private async void BtNuevo_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new VideoAdmin());
        }

    }
}
