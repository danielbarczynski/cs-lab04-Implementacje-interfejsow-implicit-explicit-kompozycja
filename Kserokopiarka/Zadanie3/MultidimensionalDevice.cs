using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ver1;
using Zadanie1;
using Zadanie3;

namespace Zadanie2
{
    public class MultidimensionalDevice : Copier 
    {
        public Fax Fax; // robie public by sie dalo wywolac w mainie, juz mi sie nie chce zmieniac struktury kodu, wiec zostane przy tym
        private readonly Printer Printer;
        private readonly Scanner Scanner;

        public MultidimensionalDevice(Scanner scanner, Printer printer, Fax fax) : base(scanner, printer)
        {
            Scanner = scanner;
            Printer = printer;
            Fax = fax;
        }


        public void ScanPrintAndFax()
        {
            if (state == IDevice.State.on)
            {
                Scan(out IDocument document, IDocument.FormatType.JPG);
                Print(in document);
                Fax.Faxx(in document); // wywolywanie bedzie z klasy poniewaz jej nie dziedziczy (nie wiem czy o to chodzilo)
            }
        }
    }
}
