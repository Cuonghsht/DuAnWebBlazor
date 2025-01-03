namespace DuAnWebAPI.Services.Session
{
    public interface SessionLogin
    {
        string AccountName { get; set; }
        Guid AccountId { get; set; }

        string GetAccountName();
        Guid GetAccountId();
        void SetaccountName(string accountname);

    }

}
