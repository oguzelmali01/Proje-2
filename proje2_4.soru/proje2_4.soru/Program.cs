using System;
using System.Collections.Generic;
using System.Linq;

class PrioritiyQueue
{
    private List<int> items;

    public PrioritiyQueue()
    {
        items = new List<int>();
    }

    public void Ekle(int item)
    {
        items.Add(item);
        items.Sort(); // Tamsayıları artan sırada sırala
    }

    public int? Sil()
    {
        if (items.Count == 0)
        {
            return null;
        }

        int enOncelikli = items[0];
        items.RemoveAt(0);
        return enOncelikli;
    }
}

class Program
{
    static void Main()
    {
        int[] adeturun = { 10, 4, 8, 6, 7, 1, 15, 9, 3, 2 };
        PrioritiyQueue kuyruk = new PrioritiyQueue();

        foreach (var urunAdeti in adeturun)
        {
            kuyruk.Ekle(urunAdeti);
        }

        List<double> tamamlanmaSureleri = new List<double>();
        while (true)
        {
            int ?urunAdeti = kuyruk.Sil();
            if (urunAdeti == null)
                break;

            double tamamlanmaSuresi = urunAdeti.Value * 2.5;
            tamamlanmaSureleri.Add(tamamlanmaSuresi);
            Console.WriteLine($"Müşteri Sepeti: {urunAdeti} ürün, İşlem Tamamlanma Süresi: {tamamlanmaSuresi} saniye");
        }

        double ortalamaSure = tamamlanmaSureleri.Average();
        Console.WriteLine($"Ortalama İşlem Tamamlanma Süresi: {ortalamaSure} saniye");
    }
}
