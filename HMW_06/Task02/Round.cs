namespace Task02
{
    using static System.Math;

    public class Round
    {
        private const int StockValue = 1;

        private int r;

        public Round()
        {
            this.X = 0;
            this.Y = 0;
            this.r = StockValue;
        }

        public Round(int x, int y, int r)
        {
            this.X = x;
            this.Y = y;
            this.R = r;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int R
        {
            get => this.r;
            set
            {
                if (value <= 0)
                {
                    this.r = StockValue;
                }

                if (value > 0)
                {
                    this.r = value;
                }
            }
        }

        public double Сircumference => PI * this.r;

        public double Area => PI * Pow(this.r, 2);

        public override string ToString()
        {
            return $"Round center: (x = {X}, y = {Y}), Radius = {R}, Circumference = {Сircumference:f3}, Area = {Area:f3}";
        }
    }
}
