namespace Task04
{
    using System;

    public class Bear : Monster
    {
        public override string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override int Health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override int Difficulity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override int ActionPoints { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void Attack()
        {
            throw new NotImplementedException();
        }

        public override bool CanAttack()
        {
            throw new NotImplementedException();
        }

        public override bool IsPossibleMove()
        {
            throw new NotImplementedException();
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
