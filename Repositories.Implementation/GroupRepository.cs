using Data.EntityFramework;
using Repositories.Interfaces;

namespace Repositories.Implementation
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ApplicationContext applicationContext;

        public GroupRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }
    }
}
