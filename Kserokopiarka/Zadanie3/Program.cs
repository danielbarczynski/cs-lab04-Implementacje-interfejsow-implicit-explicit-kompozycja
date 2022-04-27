using ver1;
using Zadanie1;
using Zadanie2;
using Zadanie3;

class Program
{
    static void Main()
    {
        var printer = new Printer();
        var scanner = new Scanner();
        var fax = new Fax();

        var xerox = new MultidimensionalDevice(scanner, printer, fax);
        xerox.PowerOn();
        IDocument doc1 = new PDFDocument("aaa.pdf");
        xerox.Print(in doc1);
        
        IDocument doc2;
        xerox.Scan(out doc2);
        xerox.Fax.Faxx(in doc1); 

        xerox.ScanPrintAndFax();
        System.Console.WriteLine(xerox.Counter);
        System.Console.WriteLine(xerox.PrintCounter);
        System.Console.WriteLine(xerox.ScanCounter);
        Console.WriteLine(xerox.Fax.FaxCounter);

    }
}