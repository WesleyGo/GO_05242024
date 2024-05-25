using API.Domain.Models;
using API.Infrastructure.Db;
using API.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Infrastructure
{
    public class ItemDataService(ItemDbContext _context) : IItemDataService
    {
        public void AddItem(Item item)
        {
            _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();
        }

        public IEnumerable<Item> GetAllItems()
        {
            var items = _context.Items.ToList();
            return _context.Items.ToList();
        }

        public Item GetItemById(int id)
        {
            return _context.Items.First(x => x.Id == id);
        }

        public void UpdateItem(Item item)
        {
            _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
