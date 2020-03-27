using PharmaceuticalWarehouseManagementSystem.DAL.Context;
using PharmaceuticalWarehouseManagementSystem.ENTITY.Entity;
using PharmaceuticalWarehouseManagementSystem.INFRASTRUCTURE.KernelRepository.Concrete;
using PharmaceuticalWarehouseManagementSystem.INFRASTRUCTURE.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmaceuticalWarehouseManagementSystem.INFRASTRUCTURE.Repository.Concrete
{
    public class EfEmployee : EfEntityRepositoryBase<Employee>, IEmployeeRepository
    {
        public EfEmployee(ProjectContext context) : base(context)
        {

        }
    }
}
