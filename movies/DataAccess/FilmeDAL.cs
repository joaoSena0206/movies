using Microsoft.Data.SqlClient;
using movies.Data;

public class FilmeDAL
{
    private readonly Banco _banco;

    public FilmeDAL(Banco banco)
    {
        _banco = banco;
    }

    public List<Filme> ObterFilmes(string tipoFiltro)
    {
        string comando = "";

        switch (tipoFiltro.ToLower())
        {
            case "populares":
                comando = @"
                SELECT
	                cd_filme AS Codigo,
	                qt_duracao_filme AS Duracao,
	                qt_avaliacao_filme AS Avaliacao,
	                nm_filme AS Nome
                FROM filme
                ORDER BY qt_avaliacao_filme DESC";
                break;

            case "recentes":
                comando = @"
                SELECT TOP(5)
	                cd_filme AS Codigo,
	                qt_duracao_filme AS Duracao,
	                qt_avaliacao_filme AS Avaliacao,
	                nm_filme AS Nome
                FROM filme
                ORDER BY cd_filme DESC";
                break;

            case "aleatorios":
                comando = @"
                SELECT TOP(5)
	                cd_filme AS Codigo,
	                qt_duracao_filme AS Duracao,
	                qt_avaliacao_filme AS Avaliacao,
	                nm_filme AS Nome
                FROM filme
                ORDER BY NEWID() DESC";
                break;

            default:
                comando = @"
                SELECT TOP(5)
	                cd_filme AS Codigo,
	                qt_duracao_filme AS Duracao,
	                qt_avaliacao_filme AS Avaliacao,
	                nm_filme AS Nome
                FROM filme
                ORDER BY NEWID() DESC";
                break;
        }

        using (SqlDataReader reader = _banco.ExecutarConsulta(comando))
        {
            List<Filme> filmes = new List<Filme>();

            while (reader.Read())
            {
                Filme filme = new Filme();
                filme.Codigo = reader.GetInt32(0);
                filme.Duracao = reader.GetTimeSpan(1);
                filme.Avaliacao = reader.GetDecimal(2);
                filme.Nome = reader.GetString(3);

                filmes.Add(filme);
            }

            return filmes;
        }
    }
}