namespace DesafioDevOps.Helper
{
    public interface IEmail
    {
        bool Enviar(String email, String assunto, string menssagem);
    }
}
