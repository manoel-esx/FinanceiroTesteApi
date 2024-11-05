using Dominio.Entidades;
using System.Xml.Linq;

namespace Infra.xml
{
    public class ExtractFromXML : IExtractFromXML
    {
        public NFSeData ExtractDataXml(Stream xmlStream)
        {
            XDocument doc = XDocument.Load(xmlStream);
            XNamespace ns = "http://www.sped.fazenda.gov.br/nfse";

            var infNFSe = doc.Element(ns + "NFSe")?.Element(ns + "infNFSe");

            var nfseData = new NFSeData();
            //{
            //    Id = infNFSe?.Attribute("Id")?.Value,
            //    xLocEmi = infNFSe?.Element(ns + "xLocEmi")?.Value,
            //    xLocPrestacao = infNFSe?.Element(ns + "xLocPrestacao")?.Value,
            //    nNFSe = infNFSe?.Element(ns + "nNFSe")?.Value,
            //    cLocIncid = infNFSe?.Element(ns + "cLocIncid")?.Value,
            //    xLocIncid = infNFSe?.Element(ns + "xLocIncid")?.Value,
            //    xTribNac = infNFSe?.Element(ns + "xTribNac")?.Value,
            //    xNBS = infNFSe?.Element(ns + "xNBS")?.Value,
            //    Emit = new Emitente
            //    {
            //        CNPJ = infNFSe?.Element(ns + "emit")?.Element(ns + "CNPJ")?.Value,
            //        xNome = infNFSe?.Element(ns + "emit")?.Element(ns + "xNome")?.Value,
            //        Endereco = new EnderecoNacional
            //        {
            //            xLgr = infNFSe?.Element(ns + "emit")?.Element(ns + "enderNac")?.Element(ns + "xLgr")?.Value,
            //            nro = infNFSe?.Element(ns + "emit")?.Element(ns + "enderNac")?.Element(ns + "nro")?.Value,
            //            xBairro = infNFSe?.Element(ns + "emit")?.Element(ns + "enderNac")?.Element(ns + "xBairro")?.Value,
            //            cMun = infNFSe?.Element(ns + "emit")?.Element(ns + "enderNac")?.Element(ns + "cMun")?.Value,
            //            UF = infNFSe?.Element(ns + "emit")?.Element(ns + "enderNac")?.Element(ns + "UF")?.Value,
            //            CEP = infNFSe?.Element(ns + "emit")?.Element(ns + "enderNac")?.Element(ns + "CEP")?.Value
            //        }
            //    },
            //    Valores = new Valores
            //    {
            //        vTotalRet = infNFSe?.Element(ns + "valores")?.Element(ns + "vTotalRet")?.Value,
            //        vLiq = infNFSe?.Element(ns + "valores")?.Element(ns + "vLiq")?.Value
            //    }
            //};

            return nfseData;
        }

    }
}
