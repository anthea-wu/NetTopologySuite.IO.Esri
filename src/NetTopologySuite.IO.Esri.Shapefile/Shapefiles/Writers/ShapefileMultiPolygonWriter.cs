using NetTopologySuite.Geometries;
using NetTopologySuite.IO.Esri.Dbf.Fields;
using NetTopologySuite.IO.Esri.Shp.Writers;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NetTopologySuite.IO.Esri.Shapefiles.Writers
{

    /// <summary>
    /// Polygon shapefile writer.
    /// </summary>
    public class ShapefileMultiPolygonWriter : ShapefileWriter<MultiPolygon>
    {
        /// <inheritdoc/>
        public ShapefileMultiPolygonWriter(Stream shpStream, Stream shxStream, Stream dbfStream, ShapeType type, IReadOnlyList<DbfField> fields, Encoding encoding = null)
            : base(shpStream, shxStream, dbfStream, type, fields, encoding)
        { }

        /// <inheritdoc/>
        public ShapefileMultiPolygonWriter(string shpPath, ShapeType type, IReadOnlyList<DbfField> fields, Encoding encoding = null, string projection = null)
            : base(shpPath, type, fields, encoding, projection)
        { }

        /// <inheritdoc/>
        public ShapefileMultiPolygonWriter(string shpPath, ShapeType type, params DbfField[] fields)
            : base(shpPath, type, fields)
        {
        }

        internal override ShpWriter<MultiPolygon> CreateShpWriter(Stream shpStream, Stream shxStream)
        {
            return new ShpMultiPolygonWriter(shpStream, shxStream, ShapeType);
        }
    }
}
