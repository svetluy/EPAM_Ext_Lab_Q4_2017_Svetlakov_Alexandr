namespace Task03
{
    using System;

    public class Ring : Round
    {
        private const string Name = "Ring";

        private int innerR;

        public int InnerR
        {
            get => this.innerR;
            set
            {
                if (value > 0 && value < this.R)
                {
                    this.innerR = value;
                }
            }
        }

        public override double Area => base.Area - (Math.PI * Math.Pow(this.InnerR, 2));

        public override double Length => base.Length + (2 * Math.PI * this.InnerR);

        public override string ToString()
        {
            return $"Figure : {Name}, x = {X}, y = {Y}, Radius = {R}, InnerRadius = {InnerR:f3}, Length = {Length:f3}, Area = {Area:f3}";
        }
    }
}
