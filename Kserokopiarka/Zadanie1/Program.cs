using ver1;
using Zadanie1;

class Program
{
    static void Main()
    {
        var xerox = new Copier();
        xerox.PowerOn();
        //xerox.PowerOn();
        //xerox.PowerOff();
        IDocument doc1 = new PDFDocument("aaa.pdf");
        xerox.Print(in doc1);

        //IDocument doc2;
        //xerox.Scan(out doc2);

        //xerox.ScanAndPrint();
        System.Console.WriteLine(xerox.Counter);
        System.Console.WriteLine(xerox.PrintCounter);
        System.Console.WriteLine(xerox.ScanCounter);
        //xerox.Print("aaa.pdf");
        //xerox.Scan("aaa.jpg");
        //xerox.Scan("aaa.txt");
    }
}