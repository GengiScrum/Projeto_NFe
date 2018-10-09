using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Projeto_NFe.Infra.XML.Base
{
    public static class XMLExtension
    {
        public static string Serialize(this object obj)
        {
            StringBuilder sb = new StringBuilder();
            using (XmlWriter writer = XmlWriter.Create(sb, new XmlWriterSettings() { OmitXmlDeclaration = true }))
            {
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(writer, obj);
            }

            return sb.ToString();
        }
    }
}
