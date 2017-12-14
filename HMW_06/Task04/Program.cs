namespace Task04
{
    using static InitGame;

    public class Program
    {
        public static void Main(string[] args)
        {
            GameField game = new GameField
            {
                Height = 10,
                Width = 10,
                Player = new Player(),
                Monsters = CreateMonsters(),
                Bonuses = CreateBonuses(),
                Obstacles = CreateObstacles()
            };

            do
            {
                if (game.Player.IsPossibleMove())
                {
                    if (game.Player.CanPickUpBonus())
                    {
                        game.Player.PickUpBonus(game.Bonuses.Dequeue());
                    }
                    else
                    {
                        if (game.Player.IsPossibleMove())
                        {
                            game.Player.Move();
                        }
                    }
                }

                foreach (var monster in game.Monsters)
                {
                    if (monster.CanAttack())
                    {
                        monster.Attack();
                    }
                    else
                    {
                        monster.Move();
                    }
                }
            }
            while (game.Bonuses.Count != 0 || game.Player.Health != 0);
        }  
    }
}
