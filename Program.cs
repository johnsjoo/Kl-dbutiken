using System;
using System.Collections.Generic;

namespace Klädbutiken
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Cloth> store = new List<Cloth>();
            List<Cloth> shoppingCart = new List<Cloth>();

            while (true)
            {


                if (store.Count >= 5)
                {
                    Console.WriteLine("Nu kan du börja handla");
                    break;

                }

                Cloth cloth = new Cloth();
                Console.WriteLine("Hej och välkommen till butiken!");

                cloth = ClothTypeChecker(cloth);

                cloth = SizeChecker(cloth);

                cloth = ColorChecker(cloth);

                cloth = PriceChecker(cloth);

                //Lägger till kläder i butikens sortiment i listan "store"
                store.Add(cloth);


                //Skriver ut butikens sortiment från lista store som vi lagt till själva
                foreach (Cloth c in store)
                {
                    Console.WriteLine("Klädtyp: " + Enum.GetName(typeof(ClothType), c.Type) + "| Storlek: " + Enum.GetName(typeof(Size), c.Size) + "| Färg: " + Enum.GetName(typeof(Color), c.Color) + "| Pris: " + c.Price + "kr");

                }

            }
            Console.Clear();


            int counter4 = 1;
            while (true)
            {
                int index = 0;
                ConsoleKeyInfo key = Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Tryck på 'A' och 'Z' för att blädra och 'Enter' för att köpa!");
                Console.WriteLine("Här är de tillgängliga plaggen i butiken");
                switch (key.Key)
                {
                    //stega upp
                    case ConsoleKey.A:
                        if (counter4 >= 0 || counter4 < store.Count)
                        {
                            counter4--;
                            if (counter4 <= 0)
                            {
                                counter4++;
                            }
                            foreach (Cloth c in store)
                            {
                                index++;
                                if (counter4 == index)
                                {
                                    Console.WriteLine("[Klädtyp: " + Enum.GetName(typeof(ClothType), c.Type) + "| Storlek: " + Enum.GetName(typeof(Size), c.Size) + "| Färg: " + Enum.GetName(typeof(Color), c.Color) + "| Pris: " + c.Price + "kr]");


                                }
                                else
                                {
                                    Console.WriteLine("Klädtyp: " + Enum.GetName(typeof(ClothType), c.Type) + "| Storlek: " + Enum.GetName(typeof(Size), c.Size) + "| Färg: " + Enum.GetName(typeof(Color), c.Color) + "| Pris: " + c.Price + "kr");

                                }
                            }
                            Console.WriteLine("Counter: " + counter4);
                        }
                        break;

                    //stega ner
                    case ConsoleKey.Z:
                        if (counter4 <= store.Count)
                        {
                            counter4++;
                            if (counter4 >= 6)
                            {
                                counter4--;
                            }
                            foreach (Cloth c in store)
                            {
                                index++;
                                if (counter4 == index)
                                {
                                    Console.WriteLine("[Klädtyp: " + Enum.GetName(typeof(ClothType), c.Type) + "| Storlek: " + Enum.GetName(typeof(Size), c.Size) + "| Färg: " + Enum.GetName(typeof(Color), c.Color) + "| Pris: " + c.Price + "kr]");


                                }
                                else
                                {
                                    Console.WriteLine("Klädtyp: " + Enum.GetName(typeof(ClothType), c.Type) + "| Storlek: " + Enum.GetName(typeof(Size), c.Size) + "| Färg: " + Enum.GetName(typeof(Color), c.Color) + "| Pris: " + c.Price + "kr");

                                }
                            }
                            Console.WriteLine("Counter: " + counter4);
                        }
                        break;
                    case ConsoleKey.Enter:
                        index++;
                        shoppingCart.Add(store[index]);
                        foreach (Cloth c in shoppingCart)
                        {
                            Console.WriteLine("Klädtyp: " + Enum.GetName(typeof(ClothType), c.Type) + "| Storlek: " + Enum.GetName(typeof(Size), c.Size) + "| Färg: " + Enum.GetName(typeof(Color), c.Color) + "| Pris: " + c.Price + "kr");

                        }
                        break;


                }


            }
















        }

        private static Cloth ClothTypeChecker(Cloth cloth)
        {
            //Felhantering av userinput(klädestyp)
            bool typeCheck = false;
            while (typeCheck == false)
            {
                try
                {
                    //Lägg till typ av klädesplagg
                    Console.Write($"klädestyp: ");
                    int counter1 = 0;
                    foreach (string type in Enum.GetNames(typeof(ClothType)))
                    {
                        Console.Write(counter1 + "-" + type + " ");
                        counter1++;

                    }
                    int typeInput = int.Parse(Console.ReadLine());
                    cloth.Type = typeInput;
                    typeCheck = true;

                }
                catch
                {
                    Console.WriteLine("Du valde inte en giltig typ!");

                }

            }

            return cloth;
        }

        private static Cloth SizeChecker(Cloth cloth)
        {
            //Felhantering av storlek
            bool sizeCheck = false;
            while (sizeCheck == false)
            {

                try
                {
                    //Lägg till storlek
                    Console.Write("Välj storlek: ");
                    int counter2 = 0;
                    foreach (string size in Enum.GetNames(typeof(Size)))
                    {
                        Console.Write(counter2 + "-" + size + " ");
                        counter2++;
                    }
                    int sizeInput = int.Parse(Console.ReadLine());
                    cloth.Size = sizeInput;
                    sizeCheck = true;
                }
                catch
                {
                    Console.WriteLine("Du valde inte ett giltig storlek!");
                }
            }

            return cloth;
        }

        private static Cloth ColorChecker(Cloth cloth)
        {
            //Felhantering av färg
            bool colorCheck = false;
            while (colorCheck == false)
            {
                try
                {
                    //Lägg till färg på plagget
                    Console.Write("Ange färg: ");
                    int counter3 = 0;
                    foreach (string color in Enum.GetNames(typeof(Color)))
                    {
                        Console.Write(counter3 + "-" + color + " ");
                        counter3++;

                    }
                    int colorInput = int.Parse(Console.ReadLine());
                    cloth.Color = colorInput;
                    colorCheck = true;

                }
                catch
                {
                    Console.WriteLine("Du valde inte en giltig färg!");
                }



            }

            return cloth;
        }

        private static Cloth PriceChecker(Cloth cloth)
        {
            //Felhantering av pris
            bool priceChecker = false;
            while (priceChecker == false)
            {
                try
                {
                    Console.Write("Ange pris: ");
                    int inputPrice = int.Parse(Console.ReadLine());
                    cloth.Price = inputPrice;
                    priceChecker = true;
                }
                catch
                {
                    Console.WriteLine("Du skrev inte in ett giltigt pris");
                }

            }

            return cloth;
        }


        enum ClothType
        {
            Tshirt,
            Pants,
            Shoes,
            Hoodie


        }
        enum Size
        {
            XS,
            S,
            M,
            L,
            XL,
        }
        enum Color
        {
            Red,
            Blue,
            Yellow,
            Black,
            White

        }




    }
    struct Cloth
    {
        public int Type;
        public int Size;
        public int Color;
        public int Price;


    }


}
