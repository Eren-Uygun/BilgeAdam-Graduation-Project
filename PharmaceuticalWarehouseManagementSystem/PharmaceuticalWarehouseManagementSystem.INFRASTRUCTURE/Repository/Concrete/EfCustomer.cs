using PharmaceuticalWarehouseManagementSystem.DAL.Context;
using PharmaceuticalWarehouseManagementSystem.ENTITY.Entity;
using PharmaceuticalWarehouseManagementSystem.INFRASTRUCTURE.KernelRepository.Abstract;
using PharmaceuticalWarehouseManagementSystem.INFRASTRUCTURE.KernelRepository.Concrete;
using PharmaceuticalWarehouseManagementSystem.INFRASTRUCTURE.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaceuticalWarehouseManagementSystem.INFRASTRUCTURE.Repository.Concrete
{
   public class EfCustomer:EfEntityRepositoryBase<Customer>,ICustomerRepository
    {
        public EfCustomer(ProjectContext context):base(context)
        {

        }
    }
}
