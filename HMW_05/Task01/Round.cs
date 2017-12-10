namespace Task01
{
    using static System.Math;

    public class Round
    {

        private int _r;

        public int X { get; set; }
        public int Y { get; set; }

        public int R
        {
            get => _r;
            set
            {
                if (value <= 0)
                {
                    _r = 1;
                }

                if (value > 0)
                {
                    _r = value;
                }
            }
        }

        public double Сircumference() => PI * _r;
        public double Square() => PI * Pow(_r,2);

        public Round()
        {
            X = 0;
            Y = 0;
            _r = 1;
        }

        public Round(int x, int y, int r)
        {
            X = x;
            Y = y;
            R = r;
        }

        public override string ToString()
        {
            return $"x = {X}, y = {Y}, Radius = {R}";
        }
    }
}
