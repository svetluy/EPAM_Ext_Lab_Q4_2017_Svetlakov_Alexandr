namespace Task03
{
    using System;

    public class Line : Figure
    {
        private const string Name = "Line";

        private int height;
        private int width;

        public int DestinationX { get; set; }

        public int DestinationY { get; set; }

        public override int Height
        {
            get => this.height;
            set
            {
                this.DestinationY = this.Y + value;
                this.height = value;
            }
        }

        public override int Width
        {
            get => this.width;
            set
            {
                this.DestinationX = this.X + value;
                this.width = value;
            }
        }

        public override double Area => 0; // area of line is 0

        public override double Length => Math.Sqrt(Math.Pow(this.DestinationX - this.X, 2) + Math.Pow(this.DestinationY - this.Y, 2));

        public override string ToString()
        {
            return $"Figure : {Name} , X = {X}, Y = {Y}, Destination X = {DestinationX}, Destination Y = {DestinationY},Length = {Length:f3}";
        }
    }
}
