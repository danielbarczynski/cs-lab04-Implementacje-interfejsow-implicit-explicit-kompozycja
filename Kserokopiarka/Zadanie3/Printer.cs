using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ver1;
using Zadanie1;

namespace Zadanie3
{
    public class Printer : IPrinter
    {
        public int Counter { get; set; }
        public int PrintCounter { get; set; }

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

        public void Print(in IDocument document)
        {
            if (state == IDevice.State.on)
            {
                DateTime date = DateTime.Now;
                PrintCounter++;
                Console.WriteLine($"{date} Print: {document.GetFileName()}");
            }
        }
    }
}
