using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornay_4
{
    public class Plants
    {
    }
    public enum FlowersType { type1, type2 };
    public enum FlowersColors { black, white, red, yellow, blue, green }
    //Цветы
    public class Flowers : Plants
    {
        public FlowersType type = FlowersType.type1;
        public int numberOfPetals = 0;
        public FlowersColors colors = FlowersColors.black;

    }
    public enum TreesType { coniferous, leafy };
    //Деревья
    public class Trees : Plants
    {
        public float height = 0;
        public TreesType type = TreesType.coniferous;
        public float radius = 0;

    }
    //Кустарники
    public class Shrubs : Plants
    {
        public bool availabilityOfColors = false;
        public int NumberOfBranches = 0;

    }
}