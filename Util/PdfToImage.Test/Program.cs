using Patagames.Pdf;
using Patagames.Pdf.Enums;
using Patagames.Pdf.Net;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;

namespace PdfToImage.Test
{
    class Program
    {
        private static string _projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

        static void Main(string[] args)
        {
            PdfToImages();
            ImagesToPdf();
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }

        private static void PdfToImages()
        {
            int dpi = 96;
            var watch = new Stopwatch();
            watch.Start();
            using (var doc = PdfDocument.Load($"{_projectDir}\\Samples\\input.pdf"))
            {
                int pageCount = doc.Pages.Count;
                for (int index = 0; index < pageCount; index++)
                {
                    var page = doc.Pages[index];
                    int width = (int)(page.Width / 72.0 * dpi);
                    int height = (int)(page.Height / 72.0 * dpi);
                    using (var bitmap = new PdfBitmap(width, height, true))
                    {
                        bitmap.FillRect(0, 0, width, height, FS_COLOR.White);
                        page.Render(bitmap, 0, 0, width, height, PageRotate.Normal, RenderFlags.FPDF_LCD_TEXT);
                        bitmap.Image.Save($"{_projectDir}\\Samples\\outputs\\output_{index}.jpg");
                    }
                }
                watch.Stop();
                Console.WriteLine($"Converting {pageCount} pages took {watch.Elapsed.TotalSeconds} seconds");
            }
        }

        private static void ImagesToPdf()
        {
            var sourceDir = $"{_projectDir}\\Samples\\outputs";
            var target = $"{_projectDir}\\Samples\\combined.pdf";
            PdfCommon.Initialize();
            var watch = new Stopwatch();
            watch.Start();
            using (var doc = PdfDocument.CreateNew())
            {
                var files = Directory.GetFiles(sourceDir, "*.jpg");
                var fileCount = files.Count();
                for (int pageIndex = 0; pageIndex < fileCount; pageIndex++)
                {
                    using (var image = Image.FromFile($"{sourceDir}\\output_{pageIndex}.jpg", true))
                    {
                        using (PdfBitmap pdfBitmap = new PdfBitmap(image.Width, image.Height, true))
                        {
                            using (var g = Graphics.FromImage(pdfBitmap.Image))
                            {
                                g.DrawImage(image, 0, 0, image.Width, image.Height);
                            }
                            var imageObject = PdfImageObject.Create(doc, pdfBitmap, 0, 0);
                            //Calculate size of image in PDF points
                            var size = CalculateSize(pdfBitmap.Width, pdfBitmap.Height, image.HorizontalResolution, image.VerticalResolution);
                            //Add empty page to PDF document
                            doc.Pages.InsertPageAt(pageIndex, size.Width, size.Height);
                            //Insert image to newly created page
                            doc.Pages[pageIndex].PageObjects.Add(imageObject);
                            //set image matrix
                            imageObject.Matrix = new FS_MATRIX(size.Width, 0, 0, size.Height, 0, 0);
                            //Generate PDF page content to content stream
                            doc.Pages[pageIndex].GenerateContent();
                        }
                    }
                }
                doc.Save(target, SaveFlags.NoIncremental);
            }
            watch.Stop();
            Console.WriteLine($"Combine images took {watch.Elapsed.TotalSeconds} seconds");
        }

        private static SizeF CalculateSize(int width, int height, float dpiX, float dpiY)
        {
            return new SizeF()
            {
                Width = width * 72 / dpiX,
                Height = height * 72 / dpiY
            };
        }
    }
}
