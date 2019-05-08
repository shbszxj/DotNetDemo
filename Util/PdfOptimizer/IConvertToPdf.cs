using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PdfOptimizer
{
    public interface IConvertToPdf
    {
        FileInfo Convert(string inputFile, string outputDir, CancellationToken token);
    }
}
