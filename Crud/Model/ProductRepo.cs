using System;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace  Crud.Model
{
     public class ProductRepo
     {
         private string connectionString;
         public ProductRepo()
         {
             connectionString=@"Data Source=MW-LT-022\SARTHAK;Initial Catalog=employee;Integrated Security=True;";
         }
         public IDbConnection Connection
         {
             get
             {
                 return new SqlConnection(connectionString);
             }
             
         }
         public void Add(Product product)
         {
             using (IDbConnection dbConnection=Connection)
             {
                 string sQuery=@"INSERT INTO product(Name,Quantity,Price) VALUES(@Name,@Quantity,@Price)";
                 dbConnection.Open();
                 dbConnection.Execute(sQuery,product);
             }
         }
         public IEnumerable<Product> GetAll()
         {
             using (IDbConnection dbConnection=Connection)
             {
                 string sQuery=@"SELECT * FROM product";
                 dbConnection.Open();
                 return dbConnection.Query<Product>(sQuery);
             }
         }
         public Product GetById(int id)
         {
             using (IDbConnection dbConnection=Connection)
             {
                 string sQuery=@"SELECT * FROM product WHERE ProductId=@ProductId";
                 dbConnection.Open();
                 return dbConnection.Query<Product>(sQuery,new {ProductId=id}).FirstOrDefault();
             }
         }
          public void Delete(int id)
         {
             using (IDbConnection dbConnection=Connection)
             {
                 string sQuery=@"DELETE FROM product WHERE ProductId=@ProductId";
                 dbConnection.Open();
                 dbConnection.Execute(sQuery,new{ProductId=id});
             }
         }
         public void Update(Product product)
         {
             using (IDbConnection dbConnection=Connection)
             {
                 string sQuery=@"UPDATE product SET Name=@Name,Quantity=@Quantity,Price=@Price WHERE ProductId=@ProductId";
                 dbConnection.Open();
                 dbConnection.Query(sQuery,product);
             }
         }
     }
}