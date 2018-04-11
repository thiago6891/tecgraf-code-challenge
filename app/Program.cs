using System;
using System.IO;
using Registration.Services;

namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new RegistrationService();

            // ---------- Part 1 ----------
            var inputFile = new StreamReader("matriculasSemDV.txt");
            var outputFile = new StreamWriter("matriculasComDV.txt");
            
            string line;
            while ((line = inputFile.ReadLine()) != null)
            {
                try
                {
                    int lineInt = Convert.ToInt32(line);
                    if (lineInt < 0 || 9999 < lineInt) continue;
                }
                catch (Exception)
                {
                    continue;
                }

                var digit = service.GetDigit(line);
                outputFile.WriteLine(line + "-" + digit.ToString());
            }

            inputFile.Close();
            outputFile.Close();

            // ---------- Part 2 ----------
            inputFile = new StreamReader("matriculasParaVerificar.txt");
            outputFile = new StreamWriter("matriculasVerificadas.txt");

            while ((line = inputFile.ReadLine()) != null)
            {
                // calculate digit from partial registration
                // compare with given digit and write to output file
            }

            inputFile.Close();
            outputFile.Close();
        }
    }
}
