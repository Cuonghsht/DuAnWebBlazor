namespace DuAnWebAPI.Services.Session
{
    public interface SessionLogin
    {
        

        string GetAccountName();
        Guid GetAccountId();
        void SetaccountName(string accountname);
        void SetAccountId(Guid accountid);

    }

}
