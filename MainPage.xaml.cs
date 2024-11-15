﻿using flowora.Pages;
using System.Windows.Input;

namespace flowora
{
    public partial class MainPage : ContentPage
    {
        public ICommand PlantLabelTappedCommand { get; }
        private bool isPageLoading = false;

        public MainPage()
        {
            InitializeComponent();

            PlantLabelTappedCommand = new Command<string>(OnLabelTapped);

            BindingContext = this;
        }


        public async void OnLabelTapped(string plantName)
        {
            if (isPageLoading)
                return;
            isPageLoading = true;

            switch (plantName)
            {
                case "cactus":
                    await Navigation.PushAsync(new CactusPage());
                    break;
            }
            await btnWaitTimer();
            isPageLoading = false;
        }
        private async Task btnWaitTimer()
        {
           await Task.Delay(1500);
        }

        private async void nieuweplantBtnClicked(object sender, EventArgs e)
        {
            if (isPageLoading)
                return;
            isPageLoading = true;

            await Navigation.PushAsync(new newplantPage());
            await btnWaitTimer();
            isPageLoading = false;
        }
    }
}
