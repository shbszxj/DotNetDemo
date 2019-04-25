using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;

namespace PdfToImage.Test
{
    public class XpsToJpg
    {
        public void SaveXpsPageToBitmap(string xpsFileName)
        {
            XpsDocument xpsDoc = new XpsDocument(xpsFileName, FileAccess.Read);
            FixedDocumentSequence docSeq = xpsDoc.GetFixedDocumentSequence();

            // You can get the total page count from docSeq.PageCount
            for (int pageNum = 0; pageNum < docSeq.DocumentPaginator.PageCount; ++pageNum)
            {
                DocumentPage docPage = docSeq.DocumentPaginator.GetPage(pageNum);
                BitmapImage bitmap = new BitmapImage();
                RenderTargetBitmap renderTarget =
                    new RenderTargetBitmap((int)docPage.Size.Width,
                                            (int)docPage.Size.Height,
                                            96, // WPF (Avalon) units are 96dpi based
                                            96,
                                            System.Windows.Media.PixelFormats.Default);

                renderTarget.Render(docPage.Visual);

                JpegBitmapEncoder encoder = new JpegBitmapEncoder();  // Choose type here ie: JpegBitmapEncoder, etc
                encoder.Frames.Add(BitmapFrame.Create(renderTarget));

                FileStream pageOutStream =
                    new FileStream(xpsFileName + ".Page" + pageNum + ".bmp", FileMode.Create, FileAccess.Write);
                encoder.Save(pageOutStream);
                pageOutStream.Close();
            }
        }
    }
}
