using System;
using System.IO;
using Registration.Services;

namespace Utils.FileProcessing
{
    public abstract class FileProcessor
    {
        protected readonly string _iFile;
        protected readonly string _oFile;

        public FileProcessor(string iFile, string oFile)
        {
            _iFile = iFile;
            _oFile = oFile;
        }

        public void ProcessFile()
        {
            var reader = new StreamReader(_iFile);
            var writer = new StreamWriter(_oFile);

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                line = line.Trim();
                if (IsValidLine(line))
                {
                    var result = ProcessLine(line);
                    writer.WriteLine(result);
                }
            }

            reader.Close();
            writer.Close();
        }

        protected abstract bool IsValidLine(string line);
        protected abstract string ProcessLine(string line);
    }

    public class DigitGenerationFileProcessor : FileProcessor
    {
        public DigitGenerationFileProcessor(string iFile, string oFile)
            : base(iFile, oFile) { }
        
        protected override bool IsValidLine(string line)
        {
            return RegistrationService.IsFormatValid(line);
        }

        protected override string ProcessLine(string line)
        {
            var digit = RegistrationService.GetDigit(line);
            return line + "-" + digit.ToString();
        }
    }

    public class DigitVerificationFileProcessor : FileProcessor
    {
        public DigitVerificationFileProcessor(string iFile, string oFile)
            : base(iFile, oFile) { }
        
        protected override bool IsValidLine(string line)
        {
            if (line.Length != 6) return false;
            
            var parts = line.Split(new char[] {'-'});
            if (parts.Length != 2 || parts[1].Length != 1)
                return false;
            
            return RegistrationService.IsFormatValid(parts[0]);
        }

        protected override string ProcessLine(string line)
        {
            var parts = line.Split(new char[] {'-'});
            var registration = parts[0];
            var digit = Convert.ToChar(parts[1]);
            
            if (digit == RegistrationService.GetDigit(registration))
                return line + " verdadeiro";
            else
                return line + " falso";
        }
    }
}