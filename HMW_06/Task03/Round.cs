namespace Task03
{
    using System;

    public class Round : Figure
    {
        private int r;
        private int width;

        public Round()
        {
            this.X = 0;
            this.Y = 0;
            this.r = 1;
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

        public override string Name => "Round";

        public int R
        {
            get => this.r;
            private set
            {
                if (value <= 0)
                {
                    this.r = 1;
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
            return $"Round center: (x = {X}, y = {Y}), Radius = {R}, Length = {Length:f3}, Area = {Area:f3}";
        }
    }
}
