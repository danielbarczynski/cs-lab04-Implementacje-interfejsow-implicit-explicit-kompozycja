using ver1;
using Zadanie2;

class Program
{
    static void Main()
    {
        var xerox = new MultifunctionalDevice();
        xerox.PowerOn();
        IDocument doc1 = new PDFDocument("aaa.pdf");
        xerox.Print(in doc1);

        IDocument doc2;
        xerox.Scan(out doc2);

        IDocument doc3;
        xerox.Fax(in doc1);

        xerox.ScanPrintAndFax();
        System.Console.WriteLine(xerox.Counter);
        System.Console.WriteLine(xerox.PrintCounter);
        System.Console.WriteLine(xerox.ScanCounter);
        Console.WriteLine(xerox.FaxCounter);

    }
}