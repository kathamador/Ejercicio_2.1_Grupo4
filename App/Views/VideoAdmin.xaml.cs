using App.Models;
using MediaManager;
using Plugin.Media;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App
{
    public partial class VideoAdmin : ContentPage
    {
        Video modelo = new Video();

        public VideoAdmin()
        {
            InitializeComponent();
            Task.Run(() => CrossMediaManager.Current.Stop());
        }

        public VideoAdmin(Video video)
        {
            InitializeComponent();
            BtTomar.IsVisible = false;
            BtSalvar.IsVisible = false;
            TxtNombre.Text = video.NombreVideo;
            videov.Source = video.Ubicacion;
        }

        private async void BtTomarVideo_Clicked(object sender, EventArgs e)
        {

            var video = await CrossMedia.Current.TakeVideoAsync(new Plugin.Media.Abstractions.StoreVideoOptions
            {
                Directory = "Movies",
                Name = $"{Guid.NewGuid()}_video.mp4",
                SaveToAlbum = true
            });

            if (video != null)
            {
                videov.Source = video.Path;
                await CrossMediaManager.Current.Play();
                CrossMediaManager.Current.Speed = 1F;
                modelo.Ubicacion = video.Path;
            }
        }

        private async void BtSalvar_Clicked(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(TxtNombre.Text?.Trim()))
            {
                await DisplayAlert("Aviso", "Ingrese el nombre", "Aceptar");
                return;
            }

            modelo.NombreVideo = TxtNombre.Text;

            var registradoCorrectamente = await App.VideosRepositorio.Add(modelo) > 0;

            if (registradoCorrectamente)
            {
                TxtNombre.Text = null;
                await DisplayAlert("Éxito", "Registrado correctamente", "Aceptar");
                await Navigation.PopAsync();
            }
            else
                await DisplayAlert("Aviso", "Ocurrió un error al registrar, revise los valores", "Aceptar");

        }

    }
}
