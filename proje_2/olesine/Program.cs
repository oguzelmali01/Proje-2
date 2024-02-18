using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace proje2
{
    internal class Program
    {
        static Dictionary<string, List<string>> bolgeler = new Dictionary<string, List<string>>
        {
            { "Akdeniz", new List<string> { "Antalya", "Burdur", "Isparta", "Mersin", "Adana", "Hatay", "Osmaniye", "Kahramanmaras" } },
{ "Dogu Anadolu", new List<string> { "Malatya", "Erzincan", "Elazig", "Tunceli", "Bingol", "Erzurum", "Mus", "Bitlis", "Sirnak", "Kars", "Agri", "Ardahan", "Van", "Igdir", "Hakkari" } },
{ "Ege", new List<string> { "Izmir", "Aydin", "Mugla", "Manisa", "Denizli", "Usak", "Kutahya", "Afyon" } },
{ "Guneydogu Anadolu", new List<string> { "Gaziantep", "Kilis", "Adiyaman", "Sanliurfa", "Diyarbakir", "Mardin", "Batman", "Siirt" } },
{ "Ic Anadolu", new List<string> { "Eskisehir", "Konya", "Ankara", "Cankiri", "Aksaray", "Kirikkale", "Kirsehir", "Yozgat", "Nigde", "Nevsehir", "Kayseri", "Karaman", "Sivas" } },
{ "Karadeniz", new List<string> { "Bolu", "Duzce", "Zonguldak", "Karabuk", "Bartin", "Kastamonu", "Corum", "Sinop", "Samsun", "Amasya", "Tokat", "Ordu", "Giresun", "Gumushane", "Trabzon", "Bayburt", "Rize", "Artvin" } },
{ "Marmara", new List<string> { "Canakkale", "Balikesir", "Edirne", "Tekirdag", "Kirklareli", "Istanbul", "Bursa", "Yalova", "Kocaeli", "Bilecik", "Sakarya" } }

        };

        static List<string> sadecebolgeler = new List<string>() { "Akdeniz", "Dogu Anadolu", "Ege", "Guneydogu Anadolu", "Ic Anadolu", "Karadeniz", "Marmara" };

        static void Main(string[] args)
        {
            List<List<UM_Alanı>> GenericList = new List<List<UM_Alanı>>(7);
            for (int i = 0; i < 7; i++)
            {
                GenericList.Add(new List<UM_Alanı>());
            }
            //1.SORU
            //UNESCO_Dünya_Mirası_Listesi(UM_Alanı_Listesi_Bulma(), GenericList);
            //2.SORU
            //Yigit();
            //Kuyruk();
            //3.SORU
            Oncelikli_Kuyruk();


        }
        static void UNESCO_Dünya_Mirası_Listesi(List<UM_Alanı> umAlanListesi, List<List<UM_Alanı>> GenericList)
        {
            

            foreach (var umalanim in umAlanListesi)
            {
                string bulunanBolge = GetBolgeBySehir(bolgeler, umalanim.İl_Adı);
                int indeks = sadecebolgeler.IndexOf(bulunanBolge);
                GenericList[indeks].Add(umalanim);
            }
            PrintGenericList(GenericList);

        }
        static List<UM_Alanı> UM_Alanı_Listesi_Bulma()
        {
            List<UM_Alanı> umAlanListesi = new List<UM_Alanı>();

            string cityFilePath = "veri.txt";

            using (StreamReader cityFile = new StreamReader(cityFilePath))
            {
                string row;
                while ((row = cityFile.ReadLine()) != null)
                {
                    string[] parcalar = row.Split(',');

                    // İlgili parçaları kullanarak UM_Alanı nesnesi oluşturma
                    string alanAdi = parcalar[0].Trim();
                    string ilAdi = parcalar[1].Trim();
                    int ilanYili = int.Parse(parcalar[2].Trim());

                    UM_Alanı umAlan = new UM_Alanı(alanAdi, ilAdi, ilanYili);

                    // Oluşturulan UM_Alanı nesnesini listeye ekleme
                    umAlanListesi.Add(umAlan);
                }
            }
            return umAlanListesi;
        }

        static string GetBolgeBySehir(Dictionary<string, List<string>> bolgeler, string sehir)
        {
            string bolgeadi = null;

            foreach (var bolge in bolgeler)
            {
                if (bolge.Value.Contains(sehir))
                {
                    bolgeadi=bolge.Key;
                }
            }
            return bolgeadi;
        }
        static void PrintGenericList(List<List<UM_Alanı>> genericList)
        {
            for (int i = 0; i < genericList.Count; i++)
            {
                Console.WriteLine($"Bölge: {sadecebolgeler[i]}");
                foreach (var umAlan in genericList[i])
                {
                    Console.WriteLine($"Alan Adı: {umAlan.Alan_Adi}, İl Adı: {umAlan.İl_Adı}, İlan Yılı: {umAlan.İlan_Yılı}");
                }
                Console.WriteLine();
            }
        }
        static void Yigit()

        {
            
            StackX stacklistem = new StackX(999);
            List<UM_Alanı> umAlanListesi = UM_Alanı_Listesi_Bulma();
            for (int i = 0; i < umAlanListesi.Count; i++)
            {
                stacklistem.push(umAlanListesi[i]);
            }
            for(int i=0; i<umAlanListesi.Count; i++)
            {
                UM_Alanı x = stacklistem.pop();
                Console.WriteLine($"Alan Adı: {x.Alan_Adi}, İl Adı: {x.İl_Adı}, İlan Yılı: {x.İlan_Yılı}");
            }

        }
        static void Kuyruk()
        {
            Queue queuelistem = new Queue(999);
            List<UM_Alanı> umAlanListesi = UM_Alanı_Listesi_Bulma();
            for(int i = 0;i< umAlanListesi.Count; i++)
            {
                queuelistem.insert(umAlanListesi[i]);
            }
            for (int i = 0; i < umAlanListesi.Count; i++)
            {
                UM_Alanı y = queuelistem.remove();
                Console.WriteLine($"Alan Adı: {y.Alan_Adi}, İl Adı: {y.İl_Adı}, İlan Yılı: {y.İlan_Yılı}");
            }
        }
        static void Oncelikli_Kuyruk()
        {
            PrioritiyQueue Priorityqueuelistem = new PrioritiyQueue();
            List<UM_Alanı> umAlanListesi = UM_Alanı_Listesi_Bulma();

            foreach (var umAlan in umAlanListesi)
            {
                Priorityqueuelistem.Ekle(umAlan);
            }

          
            for (int i = 0; i < umAlanListesi.Count; i++)
            {
                UM_Alanı y = Priorityqueuelistem.Sil();
                if (y != null)
                {
                    Console.WriteLine($"Alan Adı: {y.Alan_Adi}, İl Adı: {y.İl_Adı}, İlan Yılı: {y.İlan_Yılı}");
                }
            }
        }




    }

    public class UM_Alanı
    {
        // Özellikler (Properties)
        public string Alan_Adi { get; set; }
        public string İl_Adı { get; set; }
        public int İlan_Yılı { get; set; }

        // Kurucu Metot (Constructor)
        public UM_Alanı(string Alan_Adi, string İl_Adı, int İlan_Yılı)
        {
            this.Alan_Adi = Alan_Adi;
            this.İl_Adı = İl_Adı;
            this.İlan_Yılı = İlan_Yılı;
        }
    }
    class StackX
    {
        private int maxSize; // size of stack array
        private UM_Alanı[] stackArray;
        private int top; // top of stack
                         //--------------------------------------------------------------
        public StackX(int s) // constructor
        {
            maxSize = s; // set array size
            stackArray = new UM_Alanı[maxSize]; // create array
            top = -1; // no items yet
        }
        //--------------------------------------------------------------
        public void push(UM_Alanı j) // put item on top of stack
        {
            stackArray[++top] = j; // increment top, insert item
        }
        public UM_Alanı pop() // take item from top of stack
        {
            return stackArray[top--]; // access item, decrement top
        }
        //--------------------------------------------------------------
        public UM_Alanı peek() // peek at top of stack
        {
            return stackArray[top];
        }
        //--------------------------------------------------------------
        public bool isEmpty() // true if stack is empty
        {
            return (top == -1);
        }
        //--------------------------------------------------------------
        public bool isFull() // true if stack is full
        {
            return (top == maxSize - 1);
        }
        //--------------------------------------------------------------
    } 
    class Queue
    {
        private int maxSize;
        private UM_Alanı[] queArray;
        private int front;
        private int rear;
        private int nItems;
        //--------------------------------------------------------------
        public Queue(int s) // constructor
        {
            maxSize = s;
            queArray = new UM_Alanı[maxSize];
            front = 0;
            rear = -1;
            nItems = 0;
        }
        //--------------------------------------------------------------
        public void insert(UM_Alanı j) // put item at rear of queue
        {
            if (rear == maxSize - 1) // deal with wraparound
                rear = -1;
            queArray[++rear] = j; // increment rear and insert
            nItems++; // one more item
        }
        //--------------------------------------------------------------
        public UM_Alanı remove() // take item from front of queue
        {
            UM_Alanı temp = queArray[front++]; // get value and incr front
            if (front == maxSize) // deal with wraparound
                front = 0;
            nItems--; // one less item
            return temp;
        }
        //--------------------------------------------------------------
        public UM_Alanı peekFront() // peek at front of queue
        {
            return queArray[front];
        }
        //--------------------------------------------------------------
        public bool isEmpty() // true if queue is empty
        {
            return (nItems == 0);
        }
        //--------------------------------------------------------------
        public bool isFull() // true if queue is full
        {
            return (nItems == maxSize);
        }
        //--------------------------------------------------------------
        public int size() // number of items in queue
        {
            return nItems;
        }
        //--------------------------------------------------------------
    } 
    class PrioritiyQueue
    {
        private List<UM_Alanı> umAlanListesi;

        public PrioritiyQueue()
        {
            umAlanListesi = new List<UM_Alanı>();
        }

        public void Ekle(UM_Alanı umAlan)
        {
            umAlanListesi.Add(umAlan);
        }
        public UM_Alanı Sil()
        {
            if (umAlanListesi.Count == 0)
            {
                return null;
            }

            UM_Alanı enOncelikli = umAlanListesi[0];
            foreach (var umAlan in umAlanListesi)
            {
                if (string.Compare(umAlan.Alan_Adi, enOncelikli.Alan_Adi) < 0)
                {
                    enOncelikli = umAlan;
                }
            }

            umAlanListesi.Remove(enOncelikli);
            return enOncelikli;

        }
    }
}
