using Dominio.Entidades;
using Infra.pdf;
using Infra.xml;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace FinanceiroEsxTest
{
    public class ExtractFileData
    {
        private readonly ILogger<ExtractFileData> _logger;
        private readonly IExtractFromXML _extractFromXml;
        private readonly IExtractFromPdf _extractFromPdf;

        public ExtractFileData(ILogger<ExtractFileData> logger, IExtractFromXML extractFromXML, IExtractFromPdf extractFromPdf)
        {
            _logger = logger;
            _extractFromXml = extractFromXML;
            _extractFromPdf = extractFromPdf;
        }

        [Function("ExtractFileData")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "processFile")] HttpRequest req)
        {
            _logger.LogInformation("Função de extração de dados iniciada");

            var form = await req.ReadFormAsync();
            var pdfFile = form.Files["pdf"];

            if (pdfFile == null)
            {
                _logger.LogWarning("PDF não fornecido");
                return new BadRequestObjectResult("Arquivo PDF necessário");
            }

            NFSeData dataPdf;
            using (var pdfStream = pdfFile.OpenReadStream())
            {
                dataPdf = _extractFromPdf.ExtractPdfData(pdfStream);
            }

            var jsonResult = JsonSerializer.Serialize(dataPdf);

            _logger.LogInformation("Extração de dados do PDF com sucesso!");
            return new OkObjectResult(jsonResult);
        }
    }
}
