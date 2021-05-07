using System;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace Crud.Model
{
    public class Product
    {
        [Key]
        public int ProductId{get; set;}
        public string Name{get; set;}
        public int Quantity{get; set;}
        public double Price{get; set;}

    }
}
