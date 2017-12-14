namespace Task04
{
    public abstract class Obstacle
    {
        public abstract string Name { get; set; }

        public abstract int Xcoord { get; set; }

        public abstract int Ycoord { get; set; }

        public abstract int Width { get; set; }

        public abstract int Height { get; set; }
    }
}
