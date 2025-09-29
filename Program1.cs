using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{

    public class Product
    {

        public string Name { get; set; }

        public Product()
        {
            Name = "Неизвестный предмет";
        }

        public Product(string name)
        {
            Name = name;
        }
        public void PrintName() { Console.WriteLine($"Продукт: {Name}"); }
    }
    public class Goods : Product
    {
        private int price;
        public int Price { get; set; }

        public Goods() 
        {
            Price = 0;
        }
        public Goods(string name, int price) : base(name)
        {
            Price = price;
        }
        public void PrintGoods()
        {
            Console.WriteLine($"Товар: {Name} ; Цена: {Price}");
        }
    }

    public class Toys : Goods
    {
        private int _AgeCategory;
        public int AgeCategory { get; set; }

        public Toys()
        {
            AgeCategory = 0;
        }
        public Toys(string Name, int Price ,int ageCategory):base(Name, Price)
        {
            AgeCategory = ageCategory;
        }
        public void PrintToys() { Console.WriteLine($"Товар: {Name} ; Цена: {Price} ; Возрастная категория: {AgeCategory}"); }

    }

    public class MilkProduct : Goods
    {
        private int _Life;

        public int Life { get; set; }
        public MilkProduct() { _Life = 0; }
        public MilkProduct(string Name, int Price, int life):base(Name, Price)
        {
            Life = life;
        }
        public void PrintMilk()
        {
            Console.WriteLine($"Товар: {Name} ; Цена: {Price} ; Срок годности: {Life} дней");
        }


        internal class Program
        {
            static void Main(string[] args)
            {
               
                Product product1 = new Product();
                Product product2 = new Product("Кровать");

                Goods monitor = new Goods("Монитор", 15000);
                Goods table = new Goods("Стол", 5000);

                Toys teddyBear = new Toys("Плюшевый медведь", 1200, 3);
                Toys rubiksCube = new Toys("Кубик Рубика", 800, 6);

                MilkProduct milk = new MilkProduct("Молоко", 80, 7);

                // Вывод информации о продуктах
                Console.WriteLine("=== Продукты ===");
                product1.PrintName();
                product2.PrintName();
                Console.WriteLine();

                // Вывод информации о товарах
                Console.WriteLine("=== Товары ===");
                monitor.PrintGoods();
                table.PrintGoods();
                Console.WriteLine();

                // Вывод информации об игрушках
                Console.WriteLine("=== Игрушки ===");
                teddyBear.PrintToys();
                rubiksCube.PrintToys();
                Console.WriteLine();

                // Вывод информации о молочных продуктах
                Console.WriteLine("=== Молочные продукты ===");
                milk.PrintMilk();

                Console.ReadLine();

            }
        }
    }
}
