namespace flowora.Pages
{
    public partial class newplantPage : ContentPage
    {
        private readonly MainPage _StartPage;
        public newplantPage(MainPage StartPage)
        {
            InitializeComponent();
            _StartPage = StartPage;
        }

        private async void OnAddPlantClicked(object sender, EventArgs e)
        {
            string newPlantName = PlantNameEntry.Text; 

            if (string.IsNullOrWhiteSpace(newPlantName))
            {
                await DisplayAlert("Fout", "Voer een geldige naam in.", "OK");
                return;
            }

            if (IsPlantInList(newPlantName))
            {
                await DisplayAlert("Fout", $"De plant '{newPlantName}' bestaat al in de lijst.", "OK");
                return;
            }

            bool plantAddedSuccessfully = AddPlantToMainPage(newPlantName);

            if (plantAddedSuccessfully)
            {
                //debug: await DisplayAlert("Succes", $"De plant '{newPlantName}' is toegevoegd! De huidige planten zijn: {string.Join(", ", GetCurrentPlants())}", "OK");
                new PlantdetailPage(newPlantName);
                await Navigation.PopAsync(); 
            }
            else
            {
                await DisplayAlert("Error", "Er is een probleem opgetreden bij het toevoegen van de plant.", "OK");
            }
        }

        private bool IsPlantInList(string plantName)
        {
            return _StartPage.Planten.Contains(plantName);
        }

        private bool AddPlantToMainPage(string newPlantName)
        {
            _StartPage.Planten.Add(newPlantName);
            return true; 
        }

        private List<string> GetCurrentPlants()
        {
            return _StartPage.Planten.ToList();
        }
    }
}