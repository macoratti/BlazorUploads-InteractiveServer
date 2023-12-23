using Microsoft.AspNetCore.Components.Forms;

namespace BlazorUploads.Services;

public interface IUploadService
{
    Task<(int, string)> ArquivoUploadAsync(IBrowserFile arquivo, 
                                           int tamanhoMaximoArquivo, 
                                           string[] extensoesPermitidas);
}
