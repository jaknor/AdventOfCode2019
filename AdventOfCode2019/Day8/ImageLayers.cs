namespace AdventOfCode2019.Day8
{
    using System.Collections.Generic;
    using System.Linq;

    public class ImageLayers
    {
        public List<ImageLayer> Layers { get; }

        public ImageLayers(List<ImageLayer> layers)
        {
            Layers = layers;
        }

        public ImageLayer LayerWithLeastBlack()
        {
            var lowestBlack = Layers.Min(l => l.NrOfZeros);

            return Layers.Single(l => l.NrOfZeros == lowestBlack);
        }

        public SpaceImageColor this[int row, int column]
        {
            get {
                foreach (var layer in Layers.OrderBy(l => l.Index))
                {
                    if (layer[row, column] != SpaceImageColor.Transparent)
                    {
                        return layer[row, column];
                    }    
                }

                return SpaceImageColor.Transparent;
            }
        }
    }
}