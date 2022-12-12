﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CarDTO
    {
        public int Id { get; set; }
        
        public string CategoryName { get; set; }
       

        public double Rent { get; set; }

        public int? RentId { get; set; }
    }
}
