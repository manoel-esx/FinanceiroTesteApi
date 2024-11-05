

using Dominio.Entidades;

namespace Infra.xml
{
    public interface IExtractFromXML
    {
        NFSeData ExtractDataXml(Stream xmlFile);
    }
}
