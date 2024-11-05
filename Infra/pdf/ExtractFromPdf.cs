using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf;
using System.Text.RegularExpressions;
using Dominio.Entidades;

namespace Infra.pdf
{
    public class ExtractFromPdf : IExtractFromPdf
    {

        public NFSeData ExtractPdfData(Stream pdfStream)
        {
            var nfseData = new NFSeData();
            string pdfText = ExtractTextFromPdf(pdfStream);

            Console.WriteLine(pdfText);

            nfseData.NumeroNFS = ExtractField(pdfText, @"N[uú]mero da NFS-e\s*(\d+)");
            nfseData.ChaveAcesso = ExtractField(pdfText, @"Chave de Acesso da NFS-e\s*(\d+)");
            nfseData.DataEmissao = ExtractField(pdfText, @"Data e Hora da emiss[aã]o da NFS-e\s*([\d/]+ \d{2}:\d{2}:\d{2})");
            nfseData.DataCompetencia = ExtractField(pdfText, @"Compet[eê]ncia da NFS-e\s*([\d/]+)");
            nfseData.SerieDPS = ExtractField(pdfText, @"S[eé]rie da DPS\s*(\d+)");

            nfseData.EmitenteNome = ExtractField(pdfText, @"Nome / Nome Empresarial\s*(.+?)\n");
            nfseData.EmitenteCNPJ = ExtractField(pdfText, @"CNPJ / CPF / NIF\s*([\d\.\-\/]+)");

            nfseData.ValorServico = ExtractField(pdfText, @"Valor do Servi[cç]o\s*R\$\s*([\d,\.]+)");
            nfseData.ValorDesconto = ExtractField(pdfText, @"Desconto Condicionado\s*R\$\s*([\d,\.]+)");

            return nfseData;
        }

        private string ExtractTextFromPdf(Stream pdfStream)
        {
            string result = "";
            using (var pdfReader = new PdfReader(pdfStream))
            using (var pdfDoc = new PdfDocument(pdfReader))
            {
                for (int page = 1; page <= pdfDoc.GetNumberOfPages(); page++)
                {
                    var strategy = new SimpleTextExtractionStrategy();
                    string content = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(page), strategy);
                    result += content;
                }
            }
            return result;
        }

        private string ExtractField(string text, string pattern)
        {
            var match = Regex.Match(text, pattern);
            return match.Success ? match.Groups[1].Value : null;
        }
    }
}