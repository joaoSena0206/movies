using Microsoft.Data.SqlClient;
using movies.Data;

public class FilmeDAL
{
    private readonly Banco _banco;

    public FilmeDAL(Banco banco)
    {
        _banco = banco;
    }

    public List<Filme> ObterPopulares()
    {
        string comando = $@"
        SELECT
	        cd_filme AS Codigo,
	        qt_duracao_filme AS Duracao,
	        qt_avaliacao_filme AS Avaliacao,
	        nm_filme AS Nome
        FROM filme
        ORDER BY qt_avaliacao_filme DESC";

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