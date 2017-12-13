namespace Task03
{
    public abstract class Figure
    {
        private int x;
        private int y;

        public int X
        {
            get => this.x;
            set => this.x = value >= 0 ? value : 0;
        }

        public int Y
        {
            get => this.y;
            set => this.y = value >= 0 ? value : 0;
        }

        public virtual string Name => "Figure";

        public virtual int Width { get; set; }

        public virtual int Height { get; set; }

        public virtual double Area => this.Height * this.Width;

        public virtual double Length => 2 * (this.Height + this.Width);

        public override string ToString()
        {
            return $"X = {X}, Y = {Y}, Width = {Width}, Heigth = {Height}, Area = {Area}, Perimeter = {Length}";
        }
    }
}
