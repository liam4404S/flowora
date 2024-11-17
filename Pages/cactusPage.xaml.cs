using flowora.Pages; 
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
            ReadFileFromNetwork(); 
        }

        private async void ReadFileFromNetwork()
        {
            await _fileReader.ReadFileOnNetwork();
        }
    }
}