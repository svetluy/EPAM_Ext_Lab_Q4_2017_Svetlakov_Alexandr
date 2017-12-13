
namespace Task02
{
    using System;

    public class Ring : Round
    {
        private int innerR;

        public Ring()
        {
        }

        public Ring(int x, int y, int r, int innerR) : base(x, y, r)
        {
            this.InnerR = innerR;
        }

        public int InnerR
        {
            get => this.innerR;
            set
            {
                if (value >= 0 && value < this.R)
                {
                    this.innerR = value;
                }
                else
                {
                    this.innerR = 0;
                }
            }
        }

        public double RingArea => this.Area - (Math.PI * Math.Pow(this.InnerR, 2));

        public double CircumferenceSum => this.Сircumference + (Math.PI * this.InnerR);

        public override string ToString()
        {
            return $"Round center: (x = {X}, y = {Y}), Radius = {R}, InnerRadius = {InnerR} Circumference = {CircumferenceSum:f3}, Area = {RingArea:f3}";
        }
    }
}
