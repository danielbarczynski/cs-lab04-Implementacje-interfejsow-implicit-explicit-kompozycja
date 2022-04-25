using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ver1;
using static ver1.IDevice;

namespace Zadanie1
{
    public class Copier : BaseDevice, IPrinter, IScanner
    {
        public int PrintCounter { get; set; } = 0;
        public int ScanCounter { get; set; } = 0;

        public void Print(in IDocument document)
        {
            if (state == State.on)
            {
                DateTime date = DateTime.Now;
                PrintCounter++;
                Console.WriteLine($"{date} Print: {document.GetFileName()}");
            }
        }
        public void Scan(out IDocument document)
        {
            Scan(out document, IDocument.FormatType.JPG);
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType)
        {
            DateTime date = DateTime.Now;
            switch (formatType)
            {
                case IDocument.FormatType.PDF:
                    document = new PDFDocument($"PDFScan{++ScanCounter}.pdf");
                    break;
                case IDocument.FormatType.TXT:
                    document = new ImageDocument($"TextScan{++ScanCounter}.txt");
                    break;
                default:
                    document = new ImageDocument($"ImageScan{++ScanCounter}.jpg");
                    break;
            }
            if (state == State.on)
                Console.WriteLine($"{date} Scan: {document.GetFileName()}");
        }

        public void ScanAndPrint()
        {
            if (state == State.on)
            {
                Scan(out IDocument document, IDocument.FormatType.JPG);
                Print(document);
            }
        }
    }
}
