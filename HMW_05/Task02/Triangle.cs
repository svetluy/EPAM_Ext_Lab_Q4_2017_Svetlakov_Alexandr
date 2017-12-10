namespace Task02
{
    using static System.Math;

    public class Triangle
    {
        private int _a;
        private int _b;
        private int _c;

        public int A
        {
            get => _a;
            private set
            {
                if (value <= 0)
                {
                    _a = 1;
                    // throw new ArgumentOutOfRangeException(nameof(value));
                }
                _a = value;
            }
        }
        public int B
        {
            get => _b;
            private set
            {
                if (value <= 0)
                {
                    _b = 1;
                    // throw new ArgumentOutOfRangeException(nameof(value));
                }
                _b = value;
            }
        }
        public int C
        {
            get => _c;
            private set
            {
                if (value <= 0)
                {
                    _c = 1;
                    // throw new ArgumentOutOfRangeException(nameof(value));
                }
                _c = value;
            }
        }

        private static bool IsExist(int a, int b, int c)
        {
            return a < b + c && b < a + c && c < b + a;
        }

        public double Perimeter => _a + _b + _c;

        public double Square
        {
            get
            {
                double p = Perimeter / 2;
                return Sqrt(p * (p - _a) * (p - _b) * (p - _c));
            }
        }

        public Triangle()
        {
            _a = 1;
            _b = 1;
            _c = 1;
        }
        public Triangle(int a, int b, int c)
        {
            if (IsExist(a,b,c))
            {
                _a = a;
                _b = b;
                _c = c;
            }
            else
            {
                System.Console.WriteLine("Triangle isn't exist, stock values");
                _a = 1;
                _b = 1;
                _c = 1;
            }
        }

        public override string ToString()
        {
            return $"a = {_a}, b = {_b}, c = {_c}";
        }
    }
}
