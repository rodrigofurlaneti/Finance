namespace Finance.Data.Interface
{
    public interface IDbConnectionWrapper : IDisposable
    {
        IDbCommandWrapper CreateCommand();
        void Open();
    }
}
