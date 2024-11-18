using flowora.Pages; 
using System;

namespace flowora.Pages
{
    public partial class CactusPage : ContentPage
    {
        private FileReader _fileReader;

        public CactusPage()
        {
            Content = cactusDataLabel;
            InitializeComponent();
            _fileReader = new FileReader(UpdatecactusLabel);
            StartFileReadTimer();
        }

        private void UpdatecactusLabel(string fileContent)
        {
            cactusDataLabel.Text = fileContent; 
        }

        private void StartFileReadTimer()
        {
            Device.StartTimer(TimeSpan.FromSeconds(3), () =>
            {
                ReadFileFromNetwork();
                return true; 
            });
        }

        private async void ReadFileFromNetwork()
        {
            await _fileReader.ReadFileOnNetwork();
        }
    }
}