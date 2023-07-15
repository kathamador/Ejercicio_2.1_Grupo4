using App.Utiles;
using App.Views;
using MediaManager;
using System;
using System.IO;
using Xamarin.Forms;

namespace App
{
    public partial class App : Application
    {

        static Videos lugaresRepositorio;
        public static Videos VideosRepositorio
        {
            get
            {
                if (lugaresRepositorio == null)
                {
                    string dbname = "Proc.db3";
                    string dbpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    string dbfulp = Path.Combine(dbpath, dbname);
                    lugaresRepositorio = new Videos(dbfulp);
                }

                return lugaresRepositorio;
            }
        }


        public App()
        {
            InitializeComponent();
            //CrossMediaManager.Current.Speed = 1F;
            MainPage = new NavigationPage(new ListaVideos());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
