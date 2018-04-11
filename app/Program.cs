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
                // Ignoring blank lines and invalid formats
                try
                {
                    if (line.Length != 4) continue;
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
                var regParts = line.Split(new char[] {'-'});
                // Ignoring blank lines and invalid formats
                try
                {
                    if (regParts.Length != 2) continue;
                    if (regParts[0].Length != 4) continue;
                    if (regParts[1].Length != 1) continue;
                    int lineInt = Convert.ToInt32(regParts[0]);
                    if (lineInt < 0 || 9999 < lineInt) continue;
                }
                catch (Exception)
                {
                    continue;
                }
                
                var registration = regParts[0];
                var digit = Convert.ToChar(regParts[1]);
                if (digit == service.GetDigit(registration))
                    outputFile.WriteLine(line + " verdadeiro");
                else
                    outputFile.WriteLine(line + " falso");
            }

            inputFile.Close();
            outputFile.Close();
        }
    }
}
