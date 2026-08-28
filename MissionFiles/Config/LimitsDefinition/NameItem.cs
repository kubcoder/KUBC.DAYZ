using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace KUBC.DAYZ.MissionFiles.Config.LimitsDefinition;

/// <summary>
/// Обобщенный элемент чтения списка имен
/// </summary>
public abstract class NameItem : List<string>, IXmlSerializable
{
    /// <inheritdoc/>
    public XmlSchema? GetSchema()
    {
        return null;
    }
    /// <summary>
    /// Имя элемента данных
    /// </summary>
    protected abstract string ElementName { get; }

    private const string ATTR_NAME = "name";

    /// <inheritdoc/>
    public void ReadXml(XmlReader reader)
    {
        Clear();
        while (reader.Read())
        {
            if (reader.IsStartElement())
            {
                if (reader.Name == ElementName)
                {
                    var name = reader.GetAttribute(ATTR_NAME);
                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        Add(name);
                    }

                }

            }
        }
    }

    /// <inheritdoc/>
    public void WriteXml(XmlWriter writer)
    {
        throw new NotImplementedException();
    }
}
