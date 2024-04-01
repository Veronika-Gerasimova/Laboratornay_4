using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornay_4
{
    public class Plants
    {
        public static Random rnd = new Random();
        public int height = 0;
        //virtual для того чтобы функцию можно было переопределить в классах наследниках
        public virtual String GetInfo()
        {
            var str = String.Format("\nВысота: {0} ", this.height);
            return str;
        }
    }
    public enum FlowersType { домашние, полевые };
    public enum FlowersColors { чёрный, белый, красный, желтый, голубой, зеленый }
    //Цветы
    public class Flowers : Plants
    {
        public FlowersType type = FlowersType.домашние;
        public int numberOfPetals = 0; //количество лепестков
        public FlowersColors colors = FlowersColors.чёрный;

        public override String GetInfo()
        {
            var str = "Я цветок ";
            str += base.GetInfo();
            str += String.Format("\nТип цветов: {0} ", this.type);
            str += String.Format("\nЦвет: {0} ", this.colors);
            str += String.Format("\nКол-во лепестков: {0} ", this.numberOfPetals);
            return str;
        }

        public static Flowers Generate()
        {
            return new Flowers
            {
                colors = (FlowersColors)rnd.Next(0, Enum.GetValues(typeof(FlowersColors)).Length),
                numberOfPetals = 5 + rnd.Next(0, 20),
                type = rnd.Next(0, 2) == 0 ? FlowersType.домашние : FlowersType.полевые,
                height = rnd.Next(5, 40)
            };
        }
    }
    public enum TreesType { хвойное, листовое };
    //Деревья
    public class Trees : Plants
    {
        public TreesType type = TreesType.хвойное;
        public float radius = 0; //радиус

        public override String GetInfo()
        {
            var str = "Я дерево ";
            str += base.GetInfo();
            str += String.Format("\nТип дерева: {0} ", this.type);
            str += String.Format("\nРадиус: {0} ", this.radius);
            return str;
        }

        public static Trees Generate()
        {
            return new Trees
            {
                radius = 5 + rnd.Next(0, 20),
                type = rnd.Next(0, 2) == 0 ? TreesType.хвойное : TreesType.листовое,
                height = rnd.Next(100, 1001)
            };
        }
    }
    //Кустарники
    public class Shrubs : Plants
    {
        public bool availabilityOfFlowers = false; //наличие цветов
        public int numberOfBranches = 0; //кол-во веточек

        public override String GetInfo()
        {
            var str = "Я кустарник ";
            str += base.GetInfo();
            str += String.Format("\nНаличие цветков: {0} ", this.availabilityOfFlowers);
            str += String.Format("\nКол-во веточек: {0} ", this.numberOfBranches);
            return str;
        }

        public static Shrubs Generate()
        {
            return new Shrubs
            {
                numberOfBranches = 5 + rnd.Next(0, 20),
                availabilityOfFlowers = rnd.Next(0, 2) == 0,
                height = rnd.Next(100, 300)
            };
        }
    }
}