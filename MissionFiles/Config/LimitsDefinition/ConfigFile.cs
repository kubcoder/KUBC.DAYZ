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
        while (reader.Read())
        {
            if (reader.IsStartElement())
            {
                if (reader.Name == ROOT_ELEMENT_NAME)
                {
                    ReadData(reader.ReadSubtree());
                }
            }
        }
    }

    private void ReadData(XmlReader reader)
    {
        while (reader.Read())
        {
            if (reader.IsStartElement())
            {
                switch (reader.Name)
                {
                    case Categories.ROOT_ELEMENT_NAME:
                        Categories.ReadXml(reader.ReadSubtree());
                        break;
                }
            }
        }
    }

    /// <inheritdoc/>
    public void WriteXml(XmlWriter writer)
    {
        throw new NotImplementedException();
    }

    private const string ROOT_ELEMENT_NAME = "lists";
}
