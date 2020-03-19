using PharmaceuticalWarehouseManagementSystem.DAL.Context;
using PharmaceuticalWarehouseManagementSystem.ENTITY.Entity;
using PharmaceuticalWarehouseManagementSystem.INFRASTRUCTURE.KernelRepository.Concrete;
using PharmaceuticalWarehouseManagementSystem.INFRASTRUCTURE.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaceuticalWarehouseManagementSystem.INFRASTRUCTURE.Repository.Concrete
{
    public class EfCategory:EfEntityRepositoryBase<Category>,ICategoryRepository
    {
        public EfCategory(ProjectContext context):base(context)
        {

        }
    }
}
