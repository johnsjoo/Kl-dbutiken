﻿using System;
using System.Collections.Generic;
using System.Transactions;

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

                //Lägg till kläder i butikens sortiment i listan "store"
                store.Add(cloth);
                

                //Skriver ut butikens sortiment från lista store som vi lagt till själva
                ClothInStore(store);

            }
            Console.Clear();

            
            int index = 0;
            Console.WriteLine("Välkommen till butiken!Tryck 's' för att börja shoppa!");
            Console.WriteLine("*********************************************************");
            string startShopping = Console.ReadLine();
            Console.Clear();
            //while(keySpressed == false)
            
            if (startShopping == "s")
            {
                while (true)
                {
                    Console.WriteLine("Tryck på 'A' och 'Z' för att blädra och 'Enter' för att köpa!");
                    Console.WriteLine("Här är de tillgängliga plaggen i butiken");
                    foreach (Cloth c in store)
                    {

                        index++;
                        Console.Write(index + ".");
                        Console.WriteLine("Klädtyp: " + Enum.GetName(typeof(ClothType), c.Type) + "| Storlek: " + Enum.GetName(typeof(Size), c.Size) + "| Färg: " + Enum.GetName(typeof(Color), c.Color) + "| Pris: " + c.Price + "kr");

                    }
                    ConsoleKeyInfo key = Console.ReadKey();
                    //Stega ner
                    if (key.Key == ConsoleKey.A)
                    {

                        if (index == store.Count)
                        {
                            index++;
                        }

                    }
                    //Stega upp
                    else if (key.Key == ConsoleKey.Z)
                    {
                        if (true)
                        {
                            index--;
                        }

                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        shoppingCart.Add(store[index]);

                    }

                }    
            }

            













        }

        private static void ClothInStore(List<Cloth> store)
        {
            foreach (Cloth c in store)
            {
                Console.WriteLine("Klädtyp: " + Enum.GetName(typeof(ClothType), c.Type) + "| Storlek: " + Enum.GetName(typeof(Size), c.Size) + "| Färg: " + Enum.GetName(typeof(Color), c.Color) + "| Pris: " + c.Price + "kr");

            }
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
