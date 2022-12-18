using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WRPG.Classes.GameClass.DataClasses;

namespace WRPG.Classes.GameClass
{
    public abstract class Entity
    {
        public string Name { get { return name; } init { name = value; } }
        private string name;

        public Level Level { get; init; }

        public States Hp { get; set; }
        public States Damage { get; set; }
        public States Defence { get; set; }

        public Entity(string name)
        {
            this.name = name;
            Level = new(1,0);
            Hp = new("Hp",0.5f,1);
            Damage = new("Damage",0.2f,1);
            Defence = new("Defence",03f,1);
        }
    }
}
