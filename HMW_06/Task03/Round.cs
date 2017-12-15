namespace Task03
{
    using System;

    public class Round : Figure
    {
        private const int StockValue = 1;
        private const string Name = "Round";

        private int r;
        private int width;

        public Round()
        {
            this.r = StockValue;
        }

        public Round(int x, int y, int r)
        {
            this.X = x;
            this.Y = y;
            this.R = r;
        }

        public override int Width
        {
            get => this.width;
            set
            {
                this.Height = value;
                this.width = value;
                this.R = value;
                this.X += this.R;
                this.Y += this.R;
            }
        }

        public int R
        {
            get => this.r;
            private set
            {
                if (value <= 0)
                {
                    this.r = StockValue;
                }

                if (value > 0)
                {
                    this.r = this.Width / 2;
                }
            }
        }

        public override double Length => Math.PI * this.r;

        public override double Area => 2 * Math.PI * Math.Pow(this.r, 2);

        public override string ToString()
        {
            return $"{Name} center: (x = {X}, y = {Y}), Radius = {R}, Length = {Length:f3}, Area = {Area:f3}";
        }
    }
}
