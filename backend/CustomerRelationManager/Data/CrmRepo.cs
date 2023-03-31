using CustomerRelationManager.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CustomerRelationManager.Data
{
    public class CrmRepo : ICrmRepo
    {
        private readonly CrmDBContext _dbContext;

        public CrmRepo(CrmDBContext dbContext)
        {
            dbContext = _dbContext;
        }


    }
}
