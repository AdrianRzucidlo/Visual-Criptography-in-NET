using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using VisualCryptography;

Console.WriteLine("Kryptografia wizualna");
while(true)
{
    Console.WriteLine("Chcesz zaszyfrować obrazek czy odszyfrować go?(Z/O)");
    var choice = Console.ReadLine();
    switch (choice.ToUpper())
    {
        case "Z":
            Console.WriteLine("Podaj ścieżkę do pliku, który ma zostać podzielony na dwa obrazy:");
            var path = Console.ReadLine();
            if (!File.Exists(path))
            {
                Console.WriteLine("Zła ścieżka.");
                return;
            }
            VisualCriptographyAlgorithm.Encrypt(path);
            Console.WriteLine("Obrazek zaszyfrowany!");
            break;

        case "O":
            Console.WriteLine("Podaj ścieżkę do pierwszego pliku: ");
            var path1 = Console.ReadLine();
            if (!File.Exists(path1))
            {
                Console.WriteLine("Zła ścieżka.");
                return;
            }
            Console.WriteLine("Podaj ścieżkę do drugiego pliku: ");
            var path2 = Console.ReadLine();
            if (!File.Exists(path2))
            {
                Console.WriteLine("Zła ścieżka.");
                return;
            }
            VisualCriptographyAlgorithm.Decrypt(path1,path2);
            Console.WriteLine("Obrazek odszyfrowany");
            break;
        default: Console.WriteLine("Nieodpowiedni wybór."); return;
    }
}