namespace Task04
{
    using System;

    public class Player : IMove, IAttack
    {
        public string Name { get; set; }

        public int AttackPoints { get; set; }

        public int Health { get; set; }

        public int ActionPoints { get; set; }

        public void Attack()
        {
            throw new NotImplementedException();
        }

        public bool IsPossibleMove()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public bool CanPickUpBonus()
        {
            throw new NotImplementedException();
        }

        public void PickUpBonus(Bonus bonus)
        {
            bonus.Change(this);
            throw new NotImplementedException();
        }

        void IAttack.Attack()
        {
            throw new NotImplementedException();
        }

        bool IAttack.CanAttack()
        {
            throw new NotImplementedException();
        }
    }
}
