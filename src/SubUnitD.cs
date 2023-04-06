// using Elements.Geometry;
// using Domino;
// using Newtonsoft.Json;
// using Elements.Geometry.Solids;

// namespace Elements
// {
//     public class SubUnitD : GeometricElement
//     {
//         public SubUnitD(SubUnitDOverrideAddition add)
//         {
//             this.Boundary = add.Value.Boundary;
//             this.Border = add.Value.Boundary.Perimeter;
//             this.AddId = add.Id;
//         }

//         public Profile Boundary { get; set; }
//         public Polygon Border { get; set; }
//         public double Height { get; set; } = 1;

//         [JsonProperty("Type Name")]
//         public string TypeName { get; set; }

//         [JsonProperty("Add Id")]
//         public string AddId { get; set; }

//         public bool Match(SubUnitDIdentity identity)
//         {
//             return identity.AddId == this.AddId;
//         }

//         public SubUnitD Update(SubUnitDOverride edit)
//         {
//             this.Boundary = edit.Value.Boundary;
//             this.Border = edit.Value.Boundary.Perimeter;
//             this.TypeName = edit.Value.TypeName;
//             return this;
//         }

//         public override void UpdateRepresentations()
//         {
//             Representation = new Lamina(Boundary, false);

//             // this.Representation = new Floor(Boundary, 1.0).Representation;
//             // this.Representation = new Space(Boundary, 1.0).Representation;
//             Representation.SolidOperations.Add(
//                 new Extrude(Boundary, Height, Vector3.ZAxis, false)
//             );

//             this.Material = new Material("Sample")
//             {
//                 Color = "#AEC6CF"
//             };
//         }
//     }
// }