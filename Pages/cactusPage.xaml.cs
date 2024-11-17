using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace flowora.Pages
{

	public partial class CactusPage : ContentPage
	{
        //aangesloten op pi: string filePath = "/home/pi/data.txt";
        private string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "data.txt");

        public CactusPage()
        {
            InitializeComponent();
            StartFileReadTimer();
        }

        private void StartFileReadTimer()
        {
            Device.StartTimer(TimeSpan.FromSeconds(2), () =>
            {
                ReadFileAndUpdateUI();
                return true;
            });
        }

        private async void ReadFileAndUpdateUI()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string fileContent = await File.ReadAllTextAsync(filePath);
                    cactusDataLabel.Text = fileContent;
                }
                else
                {
                    cactusDataLabel.Text = "Bestand niet gevonden.";
                }
            }
            catch (Exception ex)
            {
                cactusDataLabel.Text = "Er is een fout opgetreden: " + ex.Message;
            }
        }
    }
}