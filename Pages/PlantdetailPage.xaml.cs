namespace flowora.Pages
{
	public partial class PlantdetailPage : ContentPage
	{
		public PlantdetailPage(string plantName)
		{
			InitializeComponent();

			PlantNameLabel.Text = $"Details van plant : {plantName}";
		}
	}
}