
using System.Text.Json;

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

}