using System;
using System.IO;
class Program
{
    static void Main()
    {

        //julio cesar ramos pereira junior
        string projectRoot = AppDomain.CurrentDomain.BaseDirectory;

        string filePath = @"../../../provinhaBarbadinha.txt";
        
        try
        {
            
            using (StreamReader reader = new StreamReader(filePath))
            {
                string ciphertext = reader.ReadToEnd();

                string decryptedText = DeTeusPulos(ciphertext);

                string replacedText = decryptedText.Replace('@', '\n');
                replacedText = replacedText.Replace("arara", "gloriosa");
                replacedText = replacedText.Replace("ovo", "bondade");
                replacedText = replacedText.Replace("osso", "passam");


                Console.WriteLine("Texto Cífrado");
                Console.WriteLine(ciphertext);

                Console.WriteLine("Texto Descifrado");
                Console.WriteLine(replacedText);

                Console.WriteLine("Número de Caracteres texto cifrado");
                Console.WriteLine(replacedText.Length);

                Console.WriteLine("Número de Caracteres palavras decifrado");
                Console.WriteLine(ContarPalavras(replacedText));

                Console.WriteLine("Palidromos: arara, ovo, osso");

                Console.WriteLine("Texto Descifrado Em maíusculo");

                Console.WriteLine(replacedText.ToUpper());

            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found. Please check the file path. " + filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static string DeTeusPulos(string ciphertext)
    {
        char[] decryptedChars = new char[ciphertext.Length];

        for (int i = 0; i < ciphertext.Length; i++)
        {
            if (i % 5 == 0)
            {
                decryptedChars[i] = (char)(ciphertext[i] - 8);
            }
            else
            {
                decryptedChars[i] = (char)(ciphertext[i] - 16);
            }
        }

        return new string(decryptedChars);
    }
    static int ContarPalavras(string texto)
    {
        
        string[] palavras = texto.Split(new char[] { ' ', '\t', '\n', '\r', '.', ',', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

        
        return palavras.Length;
    }
}