namespace Task04
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Monster : IMove, IAttack
    {
        public abstract string Name { get; set; }

        public abstract int Health { get; set; }

        public abstract int Difficulity { get; set; }

        public abstract int ActionPoints { get; set; }

        public abstract void Attack();

        public abstract bool CanAttack();

        public abstract bool IsPossibleMove();

        public abstract void Move();
    }
}
