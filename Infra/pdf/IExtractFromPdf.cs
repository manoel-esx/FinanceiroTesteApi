using Dominio.Entidades;

namespace Infra.pdf
{
    public interface IExtractFromPdf
    {
        NFSeData ExtractPdfData(Stream pdfFile);
    }
}
