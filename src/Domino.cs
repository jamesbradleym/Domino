using Elements;
using Elements.Geometry;
using Elements.Geometry.Solids;
using System.Collections.Generic;

namespace Domino
{
    public static class Domino
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model">The input model.</param>
        /// <param name="input">The arguments to the execution.</param>
        /// <returns>A DominoOutputs instance containing computed results and the model with any new elements.</returns>
        public static DominoOutputs Execute(Dictionary<string, Model> inputModels, DominoInputs input)
        {
            var output = new DominoOutputs();

            var texts = new List<(Vector3 location, Vector3 facingDirection, Vector3 lineDirection, string text, Color? color)>();

            var subUnitSets = input.Overrides.SubUnitSet.CreateElements(
                input.Overrides.Additions.SubUnitSet,
                input.Overrides.Removals.SubUnitSet,
                (add) => new SubUnitSet(add),
                (subUnitSet, identity) => subUnitSet.Match(identity),
                (subUnitSet, edit) => subUnitSet.Update(edit)
            );

            foreach (var b in subUnitSets)
            {
                var categories = new Dictionary<String, Dictionary<String, double>>();
                var index = 0;

                foreach (var p in b.SubUnits)
                {
                    var category = p.Category ??= "Uncategorized";
                    var Material = new Material(p.TypeName ??= "Sample")
                    {
                        Color = p.Color
                    };

                    if (!categories.ContainsKey(category))
                    {
                        categories[category] = new Dictionary<String, double>();
                        categories[category]["index"] = index;

                        if (categories[category]["index"] > 0)
                        {
                            var previous = categories.FirstOrDefault(x => x.Value["index"] == index - 1).Key;
                            categories[category]["y"] = categories[previous]["y"] + categories[previous]["maxY"] + 3.0;
                        }
                        else
                        {
                            categories[category]["y"] = 0.0;
                        }

                        categories[category]["x"] = 0.0;
                        categories[category]["maxY"] = p.Length;

                        index++;
                    }

                    p.Transform.Move(categories[category]["x"] + p.Width / 2, categories[category]["y"] + p.Length / 2, 0);

                    // Add Rect for local 'hypar run' viewing
                    var r = Polygon.Rectangle(p.Width, p.Length);

                    r.Transform(new Transform(p.Transform.Origin.X, p.Transform.Origin.Y, p.Transform.Origin.Z));
                    output.Model.AddElement(r);

                    categories[category]["x"] += p.Width + 3.0;
                    categories[category]["maxY"] = Math.Max(p.Length, categories[category]["maxY"]);

                    texts.Add((r.Centroid(), Vector3.ZAxis, Vector3.XAxis, p.TypeName ??= "Type", new Color(1.0f, 0.0f, 0.0f, 1.0f)));
                }
            }
            output.Model.AddElements(subUnitSets);

            texts.Add(((0, 0, 0), Vector3.ZAxis, Vector3.XAxis, $"{subUnitSets.Count}", new Color(1.0f, 0.0f, 0.0f, 1.0f)));
            texts.Add(((0, .5, 0), Vector3.ZAxis, Vector3.XAxis, $"{subUnitSets.First().SubUnits.Count}", new Color(1.0f, 0.0f, 0.0f, 1.0f)));

            var modelText = new ModelText(texts, FontSize.PT36, 30);
            output.Model.AddElement(modelText);

            return output;
        }
    }
}