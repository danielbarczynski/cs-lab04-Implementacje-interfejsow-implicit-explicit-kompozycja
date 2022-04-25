using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    internal class Copier
    {
        private int i = 0;
        private bool isOn;
        public int Counter { get; set; }
        public int PrintCounter { get; set; }
        public int ScanCounter { get; set; }
        public void PowerOn() {
            if (isOn == false)
            {
                isOn = true;
                Console.WriteLine("Urządzenie włączone");
            }
        }
        public void PowerOff() {
            if (isOn)
            {
                isOn = false;
                Console.WriteLine("Urządzenie wyłączone");
            }
        }
        public void Print(string document) {
            if (isOn)
            {
                DateTime date = DateTime.Now;
                Console.WriteLine($"{date} Print: {document}");
            }
        }
        public void Scan(string document) {
            if (isOn)
            {
                DateTime date = DateTime.Now;
                if (document.Contains(".pdf"))
                    document = "PDFScan" + document;
                else if (document.Contains(".jpg"))
                    document = "ImageScan" + document;
                else
                    document = "TextScan" + document;
                Console.WriteLine($"{date} Scan: {document}{++i}");
            }
        }
        public void ScanAndPrint(string document) { 
            if (isOn)
            {
                DateTime date = DateTime.Now;
                if (document.Contains(".jpg"))
                {
                    Console.WriteLine($"{date} Scan: {document}{++i}");
                    Console.WriteLine($"{date} Print: {document}");
                }
            }       
        }
    }
}
