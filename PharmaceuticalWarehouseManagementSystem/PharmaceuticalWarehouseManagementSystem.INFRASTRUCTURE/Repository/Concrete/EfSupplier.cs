using PharmaceuticalWarehouseManagementSystem.DAL.Context;
using PharmaceuticalWarehouseManagementSystem.ENTITY.Entity;
using PharmaceuticalWarehouseManagementSystem.INFRASTRUCTURE.KernelRepository.Concrete;
using PharmaceuticalWarehouseManagementSystem.INFRASTRUCTURE.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaceuticalWarehouseManagementSystem.INFRASTRUCTURE.Repository.Concrete
{
    public class EfSupplier : EfEntityRepositoryBase<Supplier>, ISupplierRepository
    {
        public EfSupplier(ProjectContext context) : base(context)
        {

        }
    }
}
