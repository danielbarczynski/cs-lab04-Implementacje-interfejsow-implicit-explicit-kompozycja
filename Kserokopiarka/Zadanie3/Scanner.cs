using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ver1;

namespace Zadanie3
{
    public class Scanner : IScanner
    {
        public int Counter { get; set; }
        public int ScanCounter { get; set; }

        protected IDevice.State state = IDevice.State.off;
        public IDevice.State GetState() => state;

        public void PowerOff() // nie wiem czy ma dziedziczyc po basedevice, wiec przekopiowuje te metody, trzymam sie diagramu
        {
            if (state == IDevice.State.on)
            {
                state = IDevice.State.off;
                Console.WriteLine("... Device is off !");
            }
        }

        public void PowerOn()
        {
            if (state == IDevice.State.off)
            {
                state = IDevice.State.on;
                Counter++;
                Console.WriteLine("Device is on ...");
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
            if (state == IDevice.State.on)
                Console.WriteLine($"{date} Scan: {document.GetFileName()}");
        }

    }
}
