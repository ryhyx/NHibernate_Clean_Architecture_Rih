using Domain.Concrete.Schema.HR;
using Domain.Contract.Base;

namespace Domain.Contract.Schema.HR;

public interface IRoleRepository : IBaseRepository<Role>
{
    IRoleRepository GetRoleById(int id);
    IRoleRepository GetRoleByCode(short id);

}