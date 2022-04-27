using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ver1;
using Zadanie1;

namespace Zadanie2
{
    public class MultidimensionalDevice : Copier
    {
        public int FaxCounter { get; set; } = 0;

        public MultidimensionalDevice()
        {
            
        }


        public void ScanPrintAndFax()
        {
            if (state == IDevice.State.on)
            {
                Scan(out IDocument document, IDocument.FormatType.JPG);
                Print(document);
                Fax(document);
            }
        }
    }
}
