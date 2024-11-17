using flowora.Pages;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace flowora
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<string> Planten { get; set; } = new ObservableCollection<string>();
        public ICommand PlantLabelTappedCommand { get; }
        public ICommand MenuIconTappedCommand { get; }
        private bool isPageLoading = false;

        public MainPage()
        {
            InitializeComponent();
            MenuIconTappedCommand = new Command(OnMenuIconTapped);

            PlantLabelTappedCommand = new Command<string>(OnLabelTapped);

            BindingContext = this;
            Planten.Add("cactus");
        }

        private void OnMenuIconTapped(object parameter)
        {

        }

        public async void OnLabelTapped(string plantName)
        {
            if (isPageLoading)
                return;
            isPageLoading = true;

            if(plantName == "cactus")
            {
                await Navigation.PushAsync(new CactusPage());
            }
            else if (Planten.Contains(plantName))
            {
                await Navigation.PushAsync(new PlantdetailPage(plantName));
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

            await Navigation.PushAsync(new newplantPage(this));
            await btnWaitTimer();
            isPageLoading = false;
        }
    }
}
