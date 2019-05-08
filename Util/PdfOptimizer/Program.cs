namespace PdfOptimizer
{
    class Program
    {
        private static string inputFile = @"C:\Temp\test1.pdf";
        private static string outputFolder = @"C:\Temp";

        static void Main(string[] args)
        {
            new PdfConverter().Convert(inputFile, outputFolder, new System.Threading.CancellationToken());
        }
    }
}
