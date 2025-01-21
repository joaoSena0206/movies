using Microsoft.Data.SqlClient;
using movies.Data;

public class FilmeDAL
{
    private readonly Banco _banco;

    public FilmeDAL(Banco banco)
    {
        _banco = banco;
    }

    public List<Filme> ObterTodos()
    {
        string comando = @"
        SELECT 
	        cd_filme,
	        qt_duracao_filme,
	        qt_avaliacao_filme,
	        nm_filme
        FROM filme;
        ";

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