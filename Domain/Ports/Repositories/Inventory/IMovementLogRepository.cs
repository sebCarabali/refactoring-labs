using Domain.Models.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ports.Repositories.Inventory
{
    public interface IMovementLogRepository
    {
        Task AddMovementLogAsync(MovementLog movementLog);
    }
}
