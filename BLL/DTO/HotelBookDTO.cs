using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class HotelBookDTO
    {
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
        public int? RoomId { get; set; }

       
    }
}
