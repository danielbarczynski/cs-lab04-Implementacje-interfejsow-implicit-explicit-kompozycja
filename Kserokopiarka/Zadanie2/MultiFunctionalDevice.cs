using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ver1;
using Zadanie1;

namespace Zadanie2
{
    public class MultifunctionalDevice : Copier, IFax, IScanner, IPrinter
    {
        public int FaxCounter { get; set; } = 0;

        public void Fax(in IDocument document)
        {
            if (state == IDevice.State.on)
            {
                DateTime date = DateTime.Now;
                FaxCounter++;
                Console.WriteLine($"{date} Fax: {document.GetFileName()}");
            }
        }

        public void ScanPrintAndFax()
        {
            if (state == IDevice.State.on)
            {
                Scan(out IDocument document, IDocument.FormatType.JPG);
                Print(in document);
                Fax(in document);
            }
        }
    }
}
