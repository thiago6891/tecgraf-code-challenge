using System.IO;

namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            // ---------- Part 1 ----------
            var inputFile = new StreamReader("matriculasSemDV.txt");
            var outputFile = new StreamWriter("matriculasComDV.txt");
            
            string line;
            while ((line = inputFile.ReadLine()) != null)
            {
                // calculate digit
                // write to output file
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
