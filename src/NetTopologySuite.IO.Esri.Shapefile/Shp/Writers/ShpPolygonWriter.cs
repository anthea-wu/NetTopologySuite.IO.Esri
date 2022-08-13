using NetTopologySuite.Geometries;
using System.IO;

namespace NetTopologySuite.IO.Esri.Shp.Writers
{

    /// <summary>
    /// Polygon SHP file writer.
    /// </summary>
    public class ShpPolygonWriter : ShpWriter<Polygon>
    {
        /// <inheritdoc/>
        public ShpPolygonWriter(Stream shpStream, Stream shxStream, ShapeType type) : base(shpStream, shxStream, type)
        {
            if (!ShapeType.IsPolygon())
                ThrowUnsupportedShapeTypeException();
        }

        internal override void WriteGeometry(Polygon polygon, Stream stream)
        {
            var partsBuilder = new ShpMultiPartBuilder(1, 4);

            partsBuilder.AddPart(polygon.Shell.CoordinateSequence);
            partsBuilder.WriteParts(stream, HasZ, HasM);
            partsBuilder.UpdateExtent(Extent);
        }
    }


}
