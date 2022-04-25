using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ver1;

namespace Zadanie1
{
    internal class Copier
    {
        private bool isOn;
        public int Counter { get; set; } = 0; // uruchomienia kserokopiarki
        public int PrintCounter { get; set; } = 0;
        public int ScanCounter { get; set; } = 0;
        public void PowerOn()
        {
            if (isOn == false)
            {
                isOn = true;
                Counter++;
                Console.WriteLine("Urządzenie włączone");
            }
        }
        public void PowerOff()
        {
            if (isOn)
            {
                isOn = false;
                Console.WriteLine("Urządzenie wyłączone");
            }
        }
        public void Print(in IDocument document)
        {
            if (isOn)
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
            if (isOn)
                Console.WriteLine($"{date} Scan: {document.GetFileName()}");
        }

        public void ScanAndPrint()
        {
            if (isOn)
            {
                Scan(out IDocument document, IDocument.FormatType.JPG);
                Print(document);
            }
        }
    }
}
