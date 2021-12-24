using System;
using System.Collections.Generic;

namespace TelefonRehberi
{
    class Program
    {
        public static List<Number> rehber = new List<Number>();
        static void Main(string[] args)
        {


            selectionPage();

        }
        public static void selectionPage()
        {
            Console.WriteLine("Lütfen Yapmak İstediğiniz İşlemi Seçiniz :)");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) Yeni Numara Kaydetmek");
            Console.WriteLine("(2) Varolan Numarayı Silmek");
            Console.WriteLine("(3) Varolan Numarayı Güncelleme");
            Console.WriteLine("(4) Rehberi Listelemek");
            Console.WriteLine("(5) Rehberde Arama Yapmak");

            int selection = int.MinValue;
            selectionControl(ref selection);

            switch (selection)
            {
                case 1:
                    addToRehber();
                    break;
                case 2:
                    removeInRehber();
                    break;
                case 3:
                    updateRehber();
                    break;
                case 4:
                    rehberListele();
                    break;
                case 5:
                    Search();
                    break;

            }

        }

        public static void selectionControl(ref int selection)
        {
            while (true)
            {
                bool isInt = Int32.TryParse(Console.ReadLine(), out selection);
                if (selection > 0 && selection < 6 && isInt)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim , tekrar deneyiniz");

                }

            }
        }

        public static void addToRehber()
        {
            Number number = new Number();
            Console.WriteLine(" Lütfen isim giriniz             : ");
            number.name = Console.ReadLine();
            Console.WriteLine(" Lütfen soyisim giriniz          :");
            number.surname = Console.ReadLine();
            Console.WriteLine(" Lütfen telefon numarası giriniz :");
            number.phoneNumber = Console.ReadLine();

            rehber.Add(number);

            Console.WriteLine("Numara Ekleme Basarili ");
            selectionPage();

        }

        public static void removeInRehber()
        {

            Console.WriteLine(" Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz:");
            string name = Console.ReadLine();
            bool isSuccesful = false;
            foreach (var item in rehber)
            {
                if (item.name == name || item.surname == name)
                {
                    Console.WriteLine($"{name} isimli kişi rehberden silinmek üzere, onaylıyor musunuz ?(y/n)");
                    char choice = Convert.ToChar(Console.ReadLine());
                    switch (choice)
                    {
                        case 'y':
                            rehber.Remove(item);
                            isSuccesful = true;
                            Console.WriteLine("Numara Silindi");
                            selectionPage();
                            break;
                        case 'n':
                            Console.WriteLine("Numara Silme Onayı Basarısız. Ana sayfaya yönlendiriliyorsunuz..");
                            selectionPage();
                            break;
                        default:
                            Console.WriteLine("Yanlıs karakter seçimi . Ana sayfaya yönlendiriliyorsunuz");
                            selectionPage();
                            break;


                    }

                }
            }
            if (!isSuccesful)
            {
                Console.WriteLine("  Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("  * Silmeyi sonlandırmak için : (1)");
                Console.WriteLine("  * Yeniden denemek için      : (2)");
                int choice = Int32.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        selectionPage();
                        break;
                    case 2:
                        removeInRehber();
                        break;
                    default:
                        Console.WriteLine("Yanlış karakter girişi . Ana sayfaya yönlendiriliyorsunuz..");
                        selectionPage();
                        break;
                }

            }

        }

        public static void updateRehber()
        {

            Console.WriteLine(" Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz:");
            string name = Console.ReadLine();
            bool isSuccesful = false;
            foreach (var item in rehber)
            {
                if (item.name == name || item.surname == name)
                {
                    isSuccesful = true;
                    Console.WriteLine($"{name} adlı kişinin yeni numarasını giriniz");
                    rehber[rehber.IndexOf(item)].phoneNumber = Console.ReadLine();
                    Console.WriteLine("Güncelleme Basarili");
                    selectionPage();
                }
            }
            if (!isSuccesful)
            {
                Console.WriteLine("  Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("  * Güncellemeyi sonlandırmak için : (1)");
                Console.WriteLine("  * Yeniden denemek için      : (2)");
                int choice = Int32.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        selectionPage();
                        break;
                    case 2:
                        updateRehber();
                        break;
                    default:
                        Console.WriteLine("Yanlış karakter girişi . Ana sayfaya yönlendiriliyorsunuz..");
                        selectionPage();
                        break;
                }

            }

        }

        public static void rehberListele()
        {  
            Console.WriteLine("Telefon Rehberi ");
            Console.WriteLine("*********************** ");

            foreach (var item in rehber)
            {
                Console.WriteLine($"Isim: {item.name}");
                Console.WriteLine($"Soyisim: {item.surname}");
                Console.WriteLine($"Numara: {item.phoneNumber}");
                Console.WriteLine("---------------------");

            }

            selectionPage();
        }

        public static void Search()
        {
            Console.WriteLine(" Arama yapmak istediğiniz tipi seçiniz.");
            Console.WriteLine("*********************** \n");
            Console.WriteLine(" İsim veya soyisime göre arama yapmak için: (1)");
            Console.WriteLine(" Telefon numarasına göre arama yapmak için: (2)");
            int choice = Int32.Parse(Console.ReadLine());
            string searchElement;
            switch (choice)
            {
                case 1:
                    Console.WriteLine("İsim veya soyisim giriniz");
                    searchElement = Console.ReadLine();
                    foreach (var item in rehber)
                    {
                        if (item.name == searchElement || item.surname == searchElement)
                        {
                            Console.WriteLine($"Isim: {item.name}");
                            Console.WriteLine($"Soyisim: {item.surname}");
                            Console.WriteLine($"Numara: {item.phoneNumber}");
                            Console.WriteLine("---------------------");
                        }
                    }
                    selectionPage();

                    break;
                case 2:
                    Console.WriteLine("Numara giriniz");
                    searchElement = Console.ReadLine();
                    foreach (var item in rehber)
                    {
                        if (item.phoneNumber == searchElement)
                        {
                            Console.WriteLine($"Isim: {item.name}");
                            Console.WriteLine($"Soyisim: {item.surname}");
                            Console.WriteLine($"Numara: {item.phoneNumber}");
                            Console.WriteLine("---------------------");
                        }
                    }
                    selectionPage();
                    break;
                default:
                    Console.WriteLine("Yanlış karakter girişi . Ana sayfaya yönlendiriliyorsunuz..");
                    selectionPage();
                    break;
            }





        }
    }
}
