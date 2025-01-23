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
                SELECT TOP(5)
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

    public Filme ObterDadosFilme(int cdFilme)
    {
        string comando = @"
        SELECT 
	        nm_filme,
	        nm_original_filme,
	        dt_ano_lancamento,
	        nm_faixa_etaria,
	        qt_duracao_filme,
	        STRING_AGG(nm_genero, ',') AS nm_genero,
	        ds_sinopse_filme,
	        qt_avaliacao_filme,
	        nm_diretor
        FROM filme AS f
        JOIN filme_genero fg ON (f.cd_filme = fg.cd_filme)
        JOIN genero g ON (g.cd_genero = fg.cd_genero)
        JOIN diretor d ON (f.cd_diretor = d.cd_diretor)
        WHERE f.cd_filme = @CdFilme
        GROUP BY
	        nm_filme,
	        nm_original_filme,
	        dt_ano_lancamento,
	        nm_faixa_etaria,
	        qt_duracao_filme,
	        ds_sinopse_filme,
	        qt_avaliacao_filme,
	        nm_diretor";

        List<SqlParameter> parameters = new List<SqlParameter>();
        parameters.Add(new SqlParameter("CdFilme", cdFilme));

        Filme filme = new Filme();

        using (SqlDataReader reader = _banco.ExecutarConsulta(comando, parameters))
        {
            if (reader.Read())
            {
                Diretor diretor = new Diretor();
                diretor.Nome = reader.GetString(8);

                filme.Codigo = cdFilme;
                filme.Nome = reader.GetString(0);
                filme.NomeOriginal = reader.GetString(1);
                filme.AnoLancamento = reader.GetInt32(2);
                filme.FaixaEtaria = reader.GetString(3);
                filme.Duracao = reader.GetTimeSpan(4);
                filme.Generos = reader.GetString(5).Split(",");
                filme.Sinopse = reader.GetString(6);
                filme.Avaliacao = reader.GetDecimal(7);
                filme.Diretor = diretor;
            }
        }

        return filme;
    }
}