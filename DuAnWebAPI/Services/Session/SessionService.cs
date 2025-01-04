
using DuAnWebData.Data;

namespace DuAnWebAPI.Services.Session
{
    public class SessionService : SessionLogin
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public SessionService(IHttpContextAccessor httpContextAccessor,)
        {
            _contextAccessor = httpContextAccessor;
        }
        public Guid GetAccountId()
        {
            
                var accountIdStr = _contextAccessor.HttpContext.Session.GetString("AccountId");
                return string.IsNullOrEmpty(accountIdStr) ? Guid.Empty : Guid.Parse(accountIdStr);
            
        }
        public  void SetaccountName(string Name)
        {
              _contextAccessor.HttpContext.Session.SetString("AcountName", Name);
        }

        public string GetAccountName()
        {
            return _contextAccessor.HttpContext.Session.GetString("AcountName");
        }
        public void SetAccountId(Guid accountId)
        {
            _contextAccessor.HttpContext.Session.GetString("AccountId",accountId)
        }
        
    }
}
