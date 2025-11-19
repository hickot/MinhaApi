
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace MinhaApi;

public class Utils
{
    public Object GetFormateJson (String json)
    {
         var retorno = new
            {
                chave = "valor",
                nome = "Douglas",
                informacoes = new
                {
                    idade = 34,
                    dataNascimento = "07/02/1991",
                    telefone = "+5521984263016"
                }
            };
        return retorno;
    }

    public Object GetFormatJson (String json)
    {
        string jsonFormatter = JsonSerializer.Serialize(json);
        return jsonFormatter;
    }

    public async Task<string?> GetJson()
    {
        var caminho = Path.Combine(Directory.GetCurrentDirectory(), "Data", "mock.json");

        if (!File.Exists(caminho))
            return null;

        var conteudo = await File.ReadAllTextAsync(caminho);
        return conteudo;
    }   
}