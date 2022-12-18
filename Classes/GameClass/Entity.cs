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

        public States Stats { get; init; }

        public Entity(string name)
        {
            this.name = name;
            Level = new(1,0);
            Stats = new States();
        }
        public virtual string Info() { return $"Name: {Name}\n{Level.Info()}"; }
    }
}
