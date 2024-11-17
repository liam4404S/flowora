using flowora.Pages;  // Zorg ervoor dat je juiste namespace gebruikt
using System;

namespace flowora.Pages
{
    public partial class CactusPage : ContentPage
    {
        private readonly FileReader _fileReader;

        public CactusPage()
        {
            InitializeComponent();
            _fileReader = new FileReader();
            ReadFileFromNetwork();  // Roep de methode aan om het bestand te lezen
        }

        private async void ReadFileFromNetwork()
        {
            await _fileReader.ReadFileOnNetwork();
        }
    }
}