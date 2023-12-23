using BlazorUploads.Entities;

namespace BlazorUploads.Repositories;

public interface IUploadRepository
{
    Task UploadArquivoDb(ArquivoUpload arquivo);
    Task<IEnumerable<ArquivoUpload>> GetArquivos();
    Task<ArquivoUpload> GetArquivo(int id);
    Task DeletaArquivo(int id);
}
