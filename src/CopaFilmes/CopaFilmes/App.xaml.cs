﻿using CopaFilmes.AutoMapper.Config;
using CopaFilmes.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CopaFilmes
{
    public partial class App : Application
    {
        #region Properties 
        public static App Current;
        public Page CurrentPage { get; set; } 
        #endregion

        public App()
        {
            Current = this;
            InitializeComponent();
            AutoMapperConfig.RegisterMappings();
            ModuleInitializer.Initialize();

            MainPage = new NavigationPage(new  MoviePage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
