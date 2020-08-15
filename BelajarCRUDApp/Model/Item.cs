using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarCRUDApp.Model
{
    [Table("tb_m_item")]
    public class Item
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public long Price { get; set; }
        public Supplier supplier { get; set; }
    }
}
