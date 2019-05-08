using org.pdfclown.documents;
using org.pdfclown.documents.contents.composition;
using org.pdfclown.files;
using PdfiumViewer;
using System;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using File = System.IO.File;

namespace PdfOptimizer
{
    public class PdfConverter : IConvertToPdf
    {
        private string _inputFile;
        private string _outputDir;
        private string fileNameWithoutExtension => Path.GetFileNameWithoutExtension(_inputFile);
        private string imageTempDir => $"{_outputDir}\\{fileNameWithoutExtension}";
        private string outputFile => $"{_outputDir}\\{fileNameWithoutExtension}.pdf";
        private int dpi => int.Parse(ConfigurationManager.AppSettings["dpi"]);

        public FileInfo Convert(string inputFile, string outputDir, CancellationToken token)
        {
            try
            {
                if (token.IsCancellationRequested)
                {
                    token.ThrowIfCancellationRequested();
                }
                _inputFile = inputFile;
                _outputDir = outputDir;

                if (File.Exists(inputFile))
                {
                    ToImages();
                    if (token.IsCancellationRequested)
                    {
                        ClearTempImages();
                        token.ThrowIfCancellationRequested();
                    }
                    ImagesToPdf(token);
                    return new FileInfo(outputFile);
                }
                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void ToImages()
        {
            if (!Directory.Exists(imageTempDir))
            {
                Directory.CreateDirectory(imageTempDir);
            }
            using (var doc = PdfDocument.Load(_inputFile))
            {
                for (int pageIndex = 0; pageIndex < doc.PageCount; pageIndex++)
                {
                    var size = doc.PageSizes[pageIndex];
                    using (var image = doc.Render(pageIndex, (int)size.Width, (int)size.Height, dpi, dpi, PdfRenderFlags.CorrectFromDpi))
                    {
                        image.Save($"{imageTempDir}\\output_{pageIndex}.jpg", ImageFormat.Jpeg);
                    }
                }
            }
        }

        private void ImagesToPdf(CancellationToken token)
        {
            using (org.pdfclown.files.File file = new org.pdfclown.files.File())
            {
                var images = Directory.GetFiles(imageTempDir, "*.jpg");
                for (int index = 0; index < images.Length; index++)
                {
                    using (var steam = new FileStream($"{imageTempDir}\\output_{index}.jpg", FileMode.Open))
                    {
                        var image = org.pdfclown.documents.contents.entities.Image.Get(steam);
                        var size = new SizeF(image.Width, image.Height);
                        Page page = new Page(file.Document, size);
                        file.Document.Pages.Add(page);
                        PrimitiveComposer primitiveComposer = new PrimitiveComposer(page);
                        primitiveComposer.ShowXObject(image.ToXObject(file.Document), new PointF(0, 0), size);
                        primitiveComposer.Flush();
                    }
                }
                if (token.IsCancellationRequested)
                {
                    ClearTempImages();
                    token.ThrowIfCancellationRequested();
                }
                file.Save(outputFile, SerializationModeEnum.Standard);
            }
            ClearTempImages();
        }

        private void ClearTempImages()
        {
            if (Directory.Exists(imageTempDir))
            {
                Directory.Delete(imageTempDir, true);
            }
        }
    }
}
