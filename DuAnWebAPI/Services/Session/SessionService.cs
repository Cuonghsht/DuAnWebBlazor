
using DuAnWebData.Data;

namespace DuAnWebAPI.Services.Session
{
    public class SessionService : SessionLogin
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly DataContext _dataContext;
        public SessionService(IHttpContextAccessor httpContextAccessor,DataContext data)
        {
            _contextAccessor = httpContextAccessor;
            _dataContext = data;
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
        public  void SetaccountName(string Name)
        {
              _contextAccessor.HttpContext.Session.SetString("AcountName", Name);
        }

        public string GetAccountName()
        {
            return _contextAccessor.HttpContext.Session.GetString("AcountName");
        }
        
    }
}
