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
                Console.WriteLine($"{date} Print: {document}");
            }
        }
        public void Scan(out IDocument? document)
        {
            document = null;
            DateTime date = DateTime.Now;
            if (isOn)
            {
                if (document?.GetFormatType() == IDocument.FormatType.PDF)
                {
                    PDFDocument documentScan = new PDFDocument("");
                    documentScan.GetFileName();
                    documentScan.ChangeFileName("PDFScan" + document.GetFileName());
                    document = documentScan;
                }
                else if (document?.GetFormatType() == IDocument.FormatType.JPG)
                {
                    ImageDocument documentScan = new ImageDocument("");
                    documentScan.ChangeFileName("PDFScan" + document.GetFileName());
                    document = documentScan;
                }
                else
                {
                    TextDocument documentScan = new TextDocument("");
                    documentScan.ChangeFileName("PDFScan" + document?.GetFileName());
                    document = documentScan;
                }

                Console.WriteLine($"{date} Scan: {document}{++ScanCounter}");
            }
        }
        public void ScanAndPrint()
        {
            if (isOn)
            {
                IDocument document = new ImageDocument("aaa.jpg");
                DateTime date = DateTime.Now;
                PrintCounter++;

                Console.WriteLine($"{date} Scan: {document}{++ScanCounter}");
                Console.WriteLine($"{date} Print: {document}");
            }
        }
    }
}
