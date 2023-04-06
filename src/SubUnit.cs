// using Elements.Geometry;
// using Domino;
// using Newtonsoft.Json;
// using Elements.Geometry.Solids;

// namespace Elements
// {
//     public class SubUnit : GeometricElement
//     {
//         public SubUnit(SubUnitOverrideAddition add)
//         {
//             this.Boundary = add.Value.Boundary;
//             this.Height = add.Value.Height ?? 0.01;
//             this.TypeName = add.Value.TypeName;
//             this.Category = add.Value.Category;
//             this.Color = add.Value.Color;
//             this.AddId = add.Id;
//         }

//         private Profile boundary;
//         public Profile Boundary
//         {
//             get
//             {
//                 return boundary;
//             }
//             set
//             {
//                 boundary = value;

//                 this.Width = value.Perimeter.Bounds().Max.X - Boundary.Perimeter.Bounds().Min.X;
//                 this.Length = value.Perimeter.Bounds().Max.Y - Boundary.Perimeter.Bounds().Min.Y;
//             }
//         }
//         public double Height { get; set; } = 1;

//         [JsonProperty("Type Name")]
//         public string TypeName { get; set; }

//         [JsonProperty("Add Id")]
//         public string AddId { get; set; }
//         public Color Color { get; set; } = "#AEC6CF";
//         public string Category { get; set; }
//         public double Width { get; set; }
//         public double Length { get; set; }

//         public bool Match(SubUnitIdentity identity)
//         {
//             return identity.AddId == this.AddId;
//         }

//         public SubUnit Update(SubUnitOverride edit)
//         {
//             this.Boundary = edit.Value.Boundary;
//             this.Height = edit.Value.Height;
//             this.TypeName = edit.Value.TypeName;
//             this.Category = edit.Value.Category;
//             this.Color = edit.Value.Color;
//             return this;
//         }

//         public override void UpdateRepresentations()
//         {
//             Representation = new Lamina(Boundary, false);
//             Representation.SolidOperations.Add(
//                 new Extrude(Boundary, Height, Vector3.ZAxis, false)
//             );

//             this.Material = new Material("Sample")
//             {
//                 Color = Color
//             };
//         }
//     }
// }