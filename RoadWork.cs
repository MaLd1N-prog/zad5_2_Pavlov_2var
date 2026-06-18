namespace zd3_PavlovMaksim
{
    public class RoadWork
    {

        public string Name { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public double MassPerSqM { get; set; }
        public string SurfaceType { get; set; }
        public int Year { get; set; }

        public RoadWork(string name, double width, double length, double massPerSqM,
                       string surfaceType, int year)
        {
            Name = name;
            Width = width;
            Length = length;
            MassPerSqM = massPerSqM;
            SurfaceType = surfaceType;
            Year = year;
        }

        public virtual double Quality()
        {
            return (Width * Length * MassPerSqM) / 1000;
        }

        public virtual string GetInfo()
        {
            return $"{Name}: {Width}м x {Length}м, {MassPerSqM}кг/м, Q={Quality():F2}";
        }

        public override string ToString()
        {
            return GetInfo();
        }
    }
}
