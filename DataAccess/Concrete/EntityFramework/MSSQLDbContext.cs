using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class MSSQLDbContext:DbContext
    {

        ///<summary>
        ///Properties:
        ///<seealso cref="ProductID ProductName ProductType Stock WorkCenterOperations IsSalable"/>
        /// </summary> 
        public DbSet<Product> Products { get; set; }

        ///<summary>
        ///Properties:
        ///<seealso cref="OperationID OperationName ProductTypes"/>
        /// </summary> 
        public DbSet<Operation> Operations { get; set; }

        ///<summary>
        ///Properties:
        ///<seealso cref="orderItemID Order OrderID Product Amount ProductID"/>
        /// </summary> 
        public DbSet<OrderItem> OrderItems { get; set; }

        ///<summary>
        ///Properties:
        ///<seealso cref="OrderID User UserID OrderDate Deadline OrderItems"/>
        /// </summary> 
        public DbSet<Order> Orders { get; set; }

        ///<summary>
        ///Properties:
        ///<seealso cref="StockID Product ProductID AmountOfStock"/>
        /// </summary> 
        public DbSet<Stock> Stocks { get; set; }

        ///<summary>
        ///Properties:
        ///<seealso cref="SubProductID ProductID Amount"/>
        /// </summary> 
        public DbSet<SubProductTree> SubProductTrees { get; set; }

        public DbSet<User> Users { get; set; }

        ///<summary>
        ///Properties:
        ///<seealso cref="WorkCenterID WorkCenterName Active WorkCenterOperations"/>
        /// </summary> 
        public DbSet<WorkCenter> WorkCenters { get; set; }


        ///<summary>
        ///Properties:
        ///<seealso cref="WcOprID WorkCenter Speed WorkCenterID OperationID Operation"/>
        /// </summary> 
        public DbSet<WorkCenterOperation> WorkCenterOperations { get; set; }

    }
}
