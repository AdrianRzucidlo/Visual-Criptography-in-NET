using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace VisualCryptography
{
    internal class VisualCriptographyAlgorithm
    {
        public static void Encrypt(string path)
        {
            Bitmap myImageBitMap = new Bitmap(path);
            var bitMap = new int[100, 100];
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    bitMap[i, j] = myImageBitMap.GetPixel(i, j).R == 0 ? 1 : 0;
                }
            }
            var rnd = new Random();
            var firstImage = new Bitmap(100, 100);
            var secondImage = new Bitmap(100, 100);
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if (bitMap[i, j] == 0)
                    {
                        var r = rnd.Next(0, 100) % 2;
                        if (r == 0)
                        {
                            firstImage.SetPixel(i, j, Color.White);
                            secondImage.SetPixel(i, j, Color.Black);
                        }
                        else
                        {
                            firstImage.SetPixel(i, j, Color.Black);
                            secondImage.SetPixel(i, j, Color.White);
                        }
                    }
                    if (bitMap[i, j] == 1)
                    {
                        var r = rnd.Next(0, 100) % 2;
                        if (r == 0)
                        {
                            firstImage.SetPixel(i, j, Color.White);
                            secondImage.SetPixel(i, j, Color.White);
                        }
                        else
                        {
                            firstImage.SetPixel(i, j, Color.Black);
                            secondImage.SetPixel(i, j, Color.Black);
                        }
                    }
                }
            }
            firstImage.Save("firstEncrypted.png", ImageFormat.Png);
            secondImage.Save("secondEncrypted.png", ImageFormat.Png);
        }

        public static void Decrypt(string firstPath,string secondPath)
        {
            var firstBitMap = (Bitmap)Bitmap.FromFile(firstPath);
            var secondBitMap = (Bitmap)Bitmap.FromFile(secondPath);
            Bitmap resultBitMap = new Bitmap(100,100);

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if (firstBitMap.GetPixel(i, j) == secondBitMap.GetPixel(i, j))
                    {
                        resultBitMap.SetPixel(j, i, firstBitMap.GetPixel(i, j));
                    }
                    else
                    {
                        resultBitMap.SetPixel(j, i, Color.Gray);
                    }
                }
            }
            resultBitMap.Save("decryptedImage.png", ImageFormat.Png);
        }
    }
}
