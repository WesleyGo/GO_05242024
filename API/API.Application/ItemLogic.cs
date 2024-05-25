
using API.Domain.Models;
using API.Domain.Interface;

namespace API.Application
{
    public class ItemLogic(IItemDataService _dataService) : IItemLogic
    {
        public void AddItem(Item item)
        {
            _dataService.AddItem(item);
        }

        public IEnumerable<Item> GetAllItems()
        {
            return _dataService.GetAllItems();
        }

        public Item GetItemById(int id)
        {
            return _dataService.GetItemById(id);
        }

        public void UpdateItem(Item item)
        {
            _dataService.UpdateItem(item);
        }
    }
}
