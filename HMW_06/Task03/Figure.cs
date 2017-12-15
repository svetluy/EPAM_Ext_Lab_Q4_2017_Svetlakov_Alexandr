namespace Task03
{
    public abstract class Figure
    {
        private const string Name = "Round";

        public int X { get; set; }

        public int Y { get; set; }

        public virtual int Width { get; set; }

        public virtual int Height { get; set; }

        public virtual double Area => this.Height * this.Width;

        public virtual double Length => 2 * (this.Height + this.Width);

        public override string ToString()
        {
            return $"Figure : {Name}, X = {X}, Y = {Y}, Width = {Width}, Heigth = {Height}, Area = {Area}, Perimeter = {Length}";
        }
    }
}
