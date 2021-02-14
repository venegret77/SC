using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementation
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository groupRepository;
        private readonly IStudentRepository studentRepository;

        public GroupService(IGroupRepository groupRepository, IStudentRepository studentRepository)
        {
            this.groupRepository = groupRepository;
            this.studentRepository = studentRepository;
        }
    }
}
