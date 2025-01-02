
namespace DuAnWebAPI.Services.Session
{
    public class SessionService : SessionLogin
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public SessionService(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }

        public string AccountName { get => _contextAccessor.HttpContext.Session.GetString("AcountName"); set => _contextAccessor.HttpContext.Session.SetString("AcountName", value); }
        public Guid AccountId
        {
            get
            {
                var accountIdStr = _contextAccessor.HttpContext.Session.GetString("AccountId");
                return string.IsNullOrEmpty(accountIdStr) ? Guid.Empty : Guid.Parse(accountIdStr);
            }
            set => _contextAccessor.HttpContext.Session.SetString("AccountId", value.ToString());
        }

        public Guid GetAccountId()
        {
            
                var accountIdStr = _contextAccessor.HttpContext.Session.GetString("AccountId");
                return string.IsNullOrEmpty(accountIdStr) ? Guid.Empty : Guid.Parse(accountIdStr);
            
        }

        public string GetAccountName()
        {
            return _contextAccessor.HttpContext.Session.GetString("AcountName");
        }
    }
}
