using Utils.FileProcessing;

namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileProcessors = new FileProcessor[] {
                new DigitGenerationFileProcessor(
                    "matriculasSemDV.txt",
                    "matriculasComDV.txt"
                ),
                new DigitVerificationFileProcessor(
                    "matriculasParaVerificar.txt",
                    "matriculasVerificadas.txt"
                )
            };

            foreach (var fp in fileProcessors) fp.ProcessFile();
        }
    }
}