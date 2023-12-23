using Microsoft.AspNetCore.Components.Forms;

namespace BlazorUploads.Services;

public class UploadService : IUploadService
{
    private readonly IWebHostEnvironment _environment;
    private readonly ILogger<UploadService> logger;

    public UploadService(IWebHostEnvironment environment, 
                         ILogger<UploadService> logger)
    {
        _environment = environment;
        this.logger = logger;
    }
    public async Task<(int, string)> ArquivoUploadAsync(IBrowserFile arquivo, 
                                                        int tamanhoMaximoPermitido, 
                                                        string[] extensoesPermitidas)
    {
        var diretorioUpload = Path.Combine(_environment.WebRootPath, "uploads");

        if (!Directory.Exists(diretorioUpload))
        {
            Directory.CreateDirectory(diretorioUpload);
        }

        if (arquivo.Size > tamanhoMaximoPermitido)
        {
            var mensagem = $"Arquivo: {arquivo.Name} excede o tamanho máximo permitido.";
            logger.LogInformation(mensagem);
            return (0, mensagem);
        }

        var arquivoExtensao = Path.GetExtension(arquivo.Name);

        if (!extensoesPermitidas.Contains(arquivoExtensao))
        {
            var mensagem = $"Arquivo: {arquivo.Name}, tipo de Arquivo não permitido";
            logger.LogInformation(mensagem);
            return (0, mensagem);
        }

        //altera o nome do arquivo
        var nomeArquivoSeguro = $"{Guid.NewGuid()}{arquivoExtensao}";
        //obtem o caminho do arquivo em wwwroot 
        var path = Path.Combine(diretorioUpload, nomeArquivoSeguro);
        //cria o arquivo
        await using var fs = new FileStream(path, FileMode.Create);
        // lê e copia paraa memoria
        await arquivo.OpenReadStream(tamanhoMaximoPermitido).CopyToAsync(fs);
        return (1, nomeArquivoSeguro);
    }
}
