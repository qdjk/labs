using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{

    public abstract class Product
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
        public virtual void PrintName() { Console.WriteLine($"Продукт: {Name}"); }
        public abstract void Buy();

    }
    public class Goods : Product
    {
        public int Price { get; set; }

        public Goods() 
        {
            Price = 0;
        }
        public Goods(string name, int price) : base(name)
        {
            Price = price;
        }
        public override void PrintName()
        {
            Console.WriteLine($"Товар: {Name} ; Цена: {Price}");
        }
        public override void Buy()
        {
            Console.WriteLine($"Увидел предмет: {Name}");
            if (Price == -1) { Console.WriteLine($"Узнал что товар: {Name} не продается"); }
            else
            {
                Console.WriteLine($"Товар: {Name} был куплен за {Price}");
            }
            
        }
    }

    public class Toys : Goods
    {
        
        public int AgeCategory { get; set; }

        public Toys()
        {
            AgeCategory = 0;
        }
        public Toys(string Name, int Price ,int ageCategory):base(Name, Price)
        {
            AgeCategory = ageCategory;
        }
        public override void PrintName() { Console.WriteLine($"Товар: {Name} ; Цена: {Price} ; Возрастная категория: {AgeCategory}"); }
        public override void Buy()
        {

            Console.WriteLine($"Товар {Name} не понравился");
        }

    }

    public class MilkProduct : Goods
    {


        public int Life { get; set; }
        public MilkProduct() { Life = 0; }
        public MilkProduct(string Name, int Price, int life) : base(Name, Price)
        {
            Life = life;
        }
        public override void PrintName()
        {
            Console.WriteLine($"Товар: {Name} ; Цена: {Price} ; Срок годности: {Life} дней");
        }
        public override void Buy()
        {
            Console.WriteLine($"Товар {Name} не понравился");
        }
    }

    internal class Program
    {
            static void Main(string[] args)
            {
            Product product = new Goods();
           
             Product[] inventory = { new Goods("Монитор", 15000), new Goods("Стол", 5000), new Toys("Плюшевый медведь", 1200, 3), new Toys("Кубик Рубика", 800, 6), new MilkProduct("Молоко", 80, 7) };

            foreach(var item in inventory)
            {
                item.PrintName();
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Покупатель зашел в магазин: ");

            foreach (var item in inventory)
            {
                item.Buy();
            }

        }
    }
}