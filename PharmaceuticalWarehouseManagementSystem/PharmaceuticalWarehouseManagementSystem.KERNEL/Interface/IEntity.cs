using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaceuticalWarehouseManagementSystem.KERNEL.Interface
{
   public interface IEntity<T>
    { 
        T ID { get; set; }

    }
}
