using System;
using System.IO;
using Utils.FileProcessing;

namespace app
{
    class Program
    {
        static readonly string INPUT_DIR = "input";
        static readonly string OUTPUT_DIR = "output";
        static readonly string INPUT_FILE_ONE = "matriculasSemDV.txt";
        static readonly string INPUT_FILE_TWO = "matriculasParaVerificar.txt";
        static readonly string OUTPUT_FILE_ONE = "matriculasComDV.txt";
        static readonly string OUTPUT_FILE_TWO = "matriculasVerificadas.txt";

        static void Main(string[] args)
        {
            Directory.CreateDirectory(OUTPUT_DIR);

            var fileProcessors = new FileProcessor[] {
                new DigitGenerationFileProcessor(
                    INPUT_DIR + "/" + INPUT_FILE_ONE,
                    OUTPUT_DIR + "/" + OUTPUT_FILE_ONE
                ),
                new DigitVerificationFileProcessor(
                    INPUT_DIR + "/" + INPUT_FILE_TWO,
                    OUTPUT_DIR + "/" + OUTPUT_FILE_TWO
                )
            };

            foreach (var fp in fileProcessors) fp.ProcessFile();

            Console.WriteLine("Done! Results can be found in the /output directory.");
        }
    }
}