using System;
using System.IO;
using System.Threading.Tasks;

public class FileReader
{
    private Action<string> _updatecactusLabel;

    public FileReader(Action<string> updatecactusLabel)
    {
        _updatecactusLabel = updatecactusLabel;
    }

    public async Task ReadFileOnNetwork()
    {
        //on pi string filePath = @"\\raspberrypi\shared_folder\data.txt";
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "data.txt"); //local

        try
        {
           
            if (File.Exists(filePath))
            {               
                string fileContent = await File.ReadAllTextAsync(filePath);
                _updatecactusLabel(fileContent);  
            }
            else
            {
                _updatecactusLabel("Bestand niet gevonden.");
            }
        }
        catch (Exception ex)
        {
            _updatecactusLabel("Er is een fout opgetreden: " + ex.Message);
        }
    }
}