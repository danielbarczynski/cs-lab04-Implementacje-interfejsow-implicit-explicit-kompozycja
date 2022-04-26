using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ver1;
using Zadanie3;
using static ver1.IDevice;

namespace Zadanie1
{
    public class Copier : BaseDevice
    {
        public int PrintCounter { get; set; } = 0;
        public int ScanCounter { get; set; } = 0;

        private readonly Scanner Scanner;
        private readonly Printer Printer;

        public Copier(Scanner scanner, Printer printer)
        {
            Scanner = scanner;
            Printer = printer;
        }

       public void Scan()
        {
            if (state == State.on)
            {
                Scanner.PowerOn();
                Scanner.Scan(out IDocument document, IDocument.FormatType.JPG);
                Scanner.PowerOff();
            }
        }

        public void Print()
        {
            if (state == State.on)
            {
                Printer.PowerOn();
                IDocument doc1 = new PDFDocument("aaa.pdf");
                Printer.Print(in doc1);
                Printer.PowerOff();
            }
        }

        public void ScanAndPrint()
        {
            if (state == State.on)
            {
                Scanner.PowerOn();
                Scanner.Scan(out IDocument document, IDocument.FormatType.JPG);
                Scanner.PowerOff();
                Printer.PowerOn();
                IDocument doc1 = new PDFDocument("aaa.pdf");
                Printer.Print(in doc1);
                Printer.PowerOff();
            }
        }
    }
}
