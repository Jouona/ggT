using System.Globalization;
using ggt.Utilities;

class Program {
    static void Main(string[] args) {
        int a = Helpers.IntEingabeLesen();
        int b = Helpers.IntEingabeLesen();

        int ggt = FindGTT(a, b);
        Console.WriteLine("Der größte gemeinsame Teiler ist: " + ggt);
    }

    /* vom Prinzip her richtig, aber gibt gibt quasi nur das Verhältnis zurück.
     Funktioniert aber auch einfach von der Grundlage her bei Kommazahlen sowieso nicht */
    static double FindGTTForDoubles(double a, double b) {
        int scaleFactor = GetProperScalingFactor(a, b);
        a *= scaleFactor;
        b *= scaleFactor;
        int gtt = FindGTT((int)a, (int)b);
        return gtt;
    }

    static int FindGTT(int a, int b) {
        while (b != 0) {
            int temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }

    static int GetProperScalingFactor(double a, double b) {
        int factorA = GetDecimalPlaces(a);
        int factorB = GetDecimalPlaces(b);

        int maxDecimalPlaces = Math.Max(factorA, factorB);

        int scaleFactor = (int)Math.Pow(10, maxDecimalPlaces);

        return scaleFactor;
    }

    static int GetDecimalPlaces(double number) {
        string numberText = number.ToString(CultureInfo.InvariantCulture);
        int decimalPointIndex = numberText.IndexOf('.');
        if (decimalPointIndex < 0) {
            return 0;
        }

        return numberText.Length - decimalPointIndex - 1;
    }
}