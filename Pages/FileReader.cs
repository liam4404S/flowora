using System;
using System.IO;
using System.Threading.Tasks;

public class FileReader
{
    public async Task ReadFileOnNetwork()
    {
        string filePath = @"\\raspberrypi\shared_folder\data.txt"; 

        try
        {
           
            if (File.Exists(filePath))
            {               
                string fileContent = await File.ReadAllTextAsync(filePath);
                Console.WriteLine(fileContent);  
            }
            else
            {
                Console.WriteLine("Bestand niet gevonden.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Er is een fout opgetreden: " + ex.Message);
        }
    }
}