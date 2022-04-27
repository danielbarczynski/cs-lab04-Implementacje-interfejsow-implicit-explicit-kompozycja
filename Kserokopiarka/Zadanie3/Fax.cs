using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ver1;

namespace Zadanie3
{
    public class Fax : IFax
    {
        public int Counter { get; set; }
        public int FaxCounter { get; set; }

        protected IDevice.State state = IDevice.State.off;
        public IDevice.State GetState() => state;

        public void PowerOff()
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
        public void Faxx(in IDocument document)
        {
            if (state == IDevice.State.on)
            {
                DateTime date = DateTime.Now;
                FaxCounter++;
                Console.WriteLine($"{date} Fax: {document.GetFileName()}");
            }
        }
    }
}
