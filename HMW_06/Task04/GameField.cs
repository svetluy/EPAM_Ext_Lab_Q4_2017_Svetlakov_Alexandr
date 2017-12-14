namespace Task04
{
    using System.Collections.Generic;

    public class GameField
    {
        public List<Monster> Monsters { get; set; }

        public List<Obstacle> Obstacles { get; set; }

        public Queue<Bonus> Bonuses { get; set; }

        public Player Player { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }
    }
}
