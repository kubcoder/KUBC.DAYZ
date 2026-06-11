using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace KUBC.DAYZ.MissionFiles.Config.LimitsDefinition;

/// <summary>
/// Категории игровых предметов
/// </summary>
public class Categories : List<string>, IXmlSerializable
{
    /// <inheritdoc/>
    public XmlSchema? GetSchema()
    {
        return null;
    }

    /// <inheritdoc/>
    public void ReadXml(XmlReader reader)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public void WriteXml(XmlWriter writer)
    {
        throw new NotImplementedException();
    }
}
