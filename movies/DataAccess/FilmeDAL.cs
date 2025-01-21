using Microsoft.Data.SqlClient;
using movies.Data;

public class FilmeDAL
{
    private readonly Banco _banco;

    public FilmeDAL(Banco banco)
    {
        _banco = banco;
    }
}