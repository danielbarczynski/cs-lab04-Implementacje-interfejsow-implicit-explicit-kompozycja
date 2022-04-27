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

        public Copier(Scanner scanner, Printer printer) // nie mam pojecia czy fax tez uwzgledniac
        {
            Scanner = scanner;
            Printer = printer;
        }
        public void Scan(out IDocument document)
        {
            if (state == State.on)
            {
                Scanner.PowerOn();
                Scanner.Scan(out document, IDocument.FormatType.JPG);
                Scanner.PowerOff();
            }
            else
            {
                document = null;
            }

        }

        public void Scan(out IDocument document, IDocument.FormatType formatType)
        {
            if (state == State.on)
            {
                Scanner.PowerOn();
                Scanner.Scan(out document, formatType);
                Scanner.PowerOff();
            }
            else
            {
                document = null;
            }
        }

        public void Print(in IDocument document)
        {
            if (state == State.on)
            {
                Printer.PowerOn();
                Printer.Print(in document);
                Printer.PowerOff();
            }
        }

        public void ScanAndPrint()
        {
            if (state == State.on)
            {
                IDocument document;
                Scanner.PowerOn();
                Scanner.Scan(out document, IDocument.FormatType.JPG);
                Scanner.PowerOff();
                Printer.PowerOn();
                Printer.Print(in document);
                Printer.PowerOff();
            }
        }
    }
}
