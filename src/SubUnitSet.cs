
using Elements.Geometry;
using Domino;
using Newtonsoft.Json;
using Elements.Geometry.Solids;

namespace Elements
{
    public class SubUnitSet : GeometricElement
    {
        public SubUnitSet(SubUnitSetOverrideAddition add)
        {
            foreach (var set in add.Value.SubUnits)
            {
                var category = set.Category ??= "Uncategorized";
                var r = Polygon.Rectangle(set.Width, set.Length);
                // var su = new SubUnit(new SubUnitOverrideAddition(Guid.NewGuid().ToString(), new SubUnitIdentity(Guid.NewGuid().ToString()), new SubUnitOverrideAdditionValue(r, set.Color, set.TypeName ??= "Sample", category, set.Height)));
                var su = new SubUnitSolo(r, set.Height, set.TypeName ??= "Sample", category, set.Color, Guid.NewGuid().ToString());
                su.Set = this.Id;
                this.SubUnits.Add(su);
            }

            this.AddId = add.Id;
        }

        // public List<SubUnit> subUnits { get; set; } = new List<SubUnit>();
        public List<SubUnitSolo> SubUnits { get; set; } = new List<SubUnitSolo>();

        [JsonProperty("Add Id")]
        public string AddId { get; set; }

        public bool Match(SubUnitSetIdentity identity)
        {
            return identity.AddId == this.AddId;
        }

        public SubUnitSet Update(SubUnitSetOverride edit)
        {
            var updated = new List<SubUnitSolo>();
            foreach (var set in edit.Value.SubUnits)
            {
                var category = set.Category ??= "Uncategorized";
                var r = Polygon.Rectangle(set.Width, set.Length);
                // var su = new SubUnit(new SubUnitOverrideAddition(Guid.NewGuid().ToString(), new SubUnitIdentity(Guid.NewGuid().ToString()), new SubUnitOverrideAdditionValue(r, set.Color, set.TypeName ??= "Sample", category, set.Height)));
                var su = new SubUnitSolo(r, set.Height, set.TypeName ??= "Sample", category, set.Color, Guid.NewGuid().ToString());
                updated.Add(su);
            }
            this.SubUnits = updated;
            return this;
        }

        public override void UpdateRepresentations()
        {
            foreach (var sub in SubUnits)
            {
                sub.UpdateRepresentations();
                // Representation.SolidOperations.Add(
                //     new Lamina(sub.Boundary)
                // );
                // Representation.SolidOperations.Add(
                //     new Extrude(sub.Boundary, sub.Height, Vector3.ZAxis, false)
                // );
                // this.Material = new Material(sub.TypeName)
                // {
                //     Color = sub.Color
                // };
            }

            // this.Material = new Material("TESTING")
            // {
            //     Color = "#FF0000"
            // };
        }
    }
}