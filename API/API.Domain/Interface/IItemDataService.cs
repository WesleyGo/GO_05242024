using API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Interface
{
    public interface IItemDataService
    {
        IEnumerable<Item> GetAllItems();
        Item GetItemById(int id);
        void UpdateItem(Item item);
        void AddItem(Item item);
    }
}
