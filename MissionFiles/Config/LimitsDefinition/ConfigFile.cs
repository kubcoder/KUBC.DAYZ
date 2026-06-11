using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace KUBC.DAYZ.MissionFiles.Config.LimitsDefinition;

/// <summary>
/// Сущность файла конфигурации лимитов
/// </summary>
public class ConfigFile : IXmlSerializable
{
    /// <summary>
    /// Список доступных категорий игровых предметов
    /// </summary>
    public Categories Categories = [];


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
