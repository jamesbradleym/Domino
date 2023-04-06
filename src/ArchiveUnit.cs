// using Elements.Geometry;
// using Domino;
// using Newtonsoft.Json;
// using Elements.Geometry.Solids;

// namespace Elements
// {
//     public class ArchiveUnit : GeometricElement
//     {
//         public ArchiveUnit(ArchiveUnitOverrideAddition add)
//         {
//             this.Boundary = add.Value.Boundary;
//             // this.Height = add.Value.Height;
//             this.AddId = add.Id;
//         }

//         public Profile Boundary { get; set; }

//         [JsonProperty("Add Id")]
//         public string AddId { get; set; }
//         public string Color { get; set; } = "#AEC6CF";

//         public bool Match(ArchiveUnitIdentity identity)
//         {
//             return identity.AddId == this.AddId;
//         }

//         public ArchiveUnit Update(ArchiveUnitOverride edit)
//         {
//             this.Boundary = edit.Value.Boundary;
//             return this;
//         }

//         public override void UpdateRepresentations()
//         {
//             Representation = new Lamina(Boundary, false);
//             Representation.SolidOperations.Add(
//                 new Extrude(Boundary, 1.0, Vector3.ZAxis, false)
//             );

//             this.Material = new Material("Sample")
//             {
//                 Color = Color
//             };
//         }
//     }
// }