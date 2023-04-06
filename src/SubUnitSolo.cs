using Elements.Geometry;
using Domino;
using Newtonsoft.Json;
using Elements.Geometry.Solids;

namespace Elements
{
    public class SubUnitSolo : GeometricElement
    {
        public SubUnitSolo(Profile Boundary, double? Height, string TypeName, string Category, Color Color, string Id)
        {
            this.Boundary = Boundary;
            this.Height = Height ?? 0.01;
            this.TypeName = TypeName;
            this.Category = Category;
            this.Color = Color;
            this.AddId = Id;
        }

        private Profile boundary;
        public Profile Boundary
        {
            get
            {
                return boundary;
            }
            set
            {
                boundary = value;

                this.Width = value.Perimeter.Bounds().Max.X - Boundary.Perimeter.Bounds().Min.X;
                this.Length = value.Perimeter.Bounds().Max.Y - Boundary.Perimeter.Bounds().Min.Y;
            }
        }
        public double Height { get; set; } = 1;

        [JsonProperty("Type Name")]
        public string TypeName { get; set; }

        [JsonProperty("Add Id")]
        public string AddId { get; set; }
        public Guid Set { get; set; }
        public Color Color { get; set; } = "#AEC6CF";
        public string Category { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }

        public bool Match(string AddId)
        {
            return AddId == this.AddId;
        }

        public override void UpdateRepresentations()
        {

            var rep = new Representation();
            rep = new Lamina(Boundary, false);
            rep.SolidOperations.Add(
                new Extrude(Boundary, Height, Vector3.ZAxis, false)
            );
            this.Representation = rep;
            this.Material = new Material(this.TypeName)
            {
                Color = Color
            };
        }
    }
}