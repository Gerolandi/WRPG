using System.Buffers.Text;
using System;
using System.Text.Json.Serialization;

namespace WRPG.Classes.GameClass.DataClasses
{
    public class Level
    {
        public event Action XpValueChanged;

        public int CurrentLevel { get { return level; } init { level = value; } }
        private int level;
        public float CurrentXp { get { return xp; } init { xp = value; } }
        private float xp;

        [JsonIgnore]
        public float XpForPastLevel { get { return NextLevel(1); } }
        [JsonIgnore]
        public float XpForNewLevel { get { return NextLevel(); } }
        [JsonIgnore]
        public string GetLevelRelation { get { return $"{CurrentXp}/{XpForNewLevel}"; } }
        public Level(int level,float xp)
        {
            this.level = level;
            this.xp = xp;
        }
        public Level()
        {

        }
        private float NextLevel(int levelDown = 0)
        {
            return (float)Math.Floor(100 * Math.Pow(level - levelDown, 1.2439545f));
        }
        public void XdAdd(float value)
        {
            if (value <= 0) return;
            xp = xp + value;
            CheckForNewLevel();
            XpValueChanged.Invoke();

        }
        private void CheckForNewLevel()
        {
            if(CurrentXp >= XpForNewLevel) { level++; }
        }
    }
}
