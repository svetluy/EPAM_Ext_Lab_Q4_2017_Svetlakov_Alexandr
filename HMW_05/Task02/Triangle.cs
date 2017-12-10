namespace Task02
{
    using static System.Math;

    public class Triangle
    {
        private int a;
        private int b;
        private int c;

        public Triangle()
        {
            this.a = 1;
            this.b = 1;
            this.c = 1;
        }

        public Triangle(int a, int b, int c)
        {
            if (IsExist(a, b, c))
            {
                this.a = a;
                this.b = b;
                this.c = c;
            }
            else
            {
                System.Console.WriteLine("Triangle isn't exist, stock values");
                this.a = 1;
                this.b = 1;
                this.c = 1;
            }
        }

        public int A
        {
            get => this.a;
            private set
            {
                if (value <= 0)
                {
                    this.a = 1;
                    //// throw new ArgumentOutOfRangeException(nameof(value));
                }

                this.a = value;
            }
        }

        public int B
        {
            get => this.b;
            private set
            {
                if (value <= 0)
                {
                    this.b = 1;

                    // throw new ArgumentOutOfRangeException(nameof(value));
                }

                this.b = value;
            }
        }

        public int C
        {
            get => this.c;
            private set
            {
                if (value <= 0)
                {
                    this.c = 1;
                    //// throw new ArgumentOutOfRangeException(nameof(value));
                }

                this.c = value;
            }
        }

        public double Perimeter => this.a + this.b + this.c;

        public double Square
        {
            get
            {
                double p = this.Perimeter / 2;
                return Sqrt(p * (p - this.a) * (p - this.b) * (p - this.c));
            }
        }

        public override string ToString()
        {
            return $"a = {this.a}, b = {this.b}, c = {this.c}";
        }

        private static bool IsExist(int a, int b, int c)
        {
            return a < b + c && b < a + c && c < b + a;
        }
    }
}
