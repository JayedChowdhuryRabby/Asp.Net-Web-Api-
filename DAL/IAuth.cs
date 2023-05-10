namespace DAL
{
    public interface IAuth<Ret>
    {
        Ret Authenticate(string email, string pass);
    }
}