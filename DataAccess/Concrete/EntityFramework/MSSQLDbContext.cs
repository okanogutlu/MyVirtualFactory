using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class MSSQLDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//Hangi veritabanı ile ilişkili
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=MyVirsualFactory;Trusted_Connection=true");
        }

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
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<WorkCenterOperation> WorkCenterOperations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //    modelBuilder.Entity<OrderItem>()
            //        .HasOne(p => p.Order) //Bir Order'ın
            //        .WithMany(b => b.OrderItems)
            //        .HasForeignKey(f =>f.OrderID); //Birden fazla OrderItem'ı vardır.

            //    modelBuilder.Entity<Product>()
            //    .HasOne<Stock>(s => s.Stock)//Bir Product'ın
            //    .WithOne(ad => ad.Product)
            //    .HasForeignKey<Stock>(f => f.ProductID);//Bir stock değeri vardır.

            //    modelBuilder.Entity<SubProductTree>()
            //       .HasOne(p => p.Product) //Bir Product'ın
            //       .WithMany(b => b.ProductTrees)
            //       .HasForeignKey(f=>f.ProductID); //Birden fazla ProductTree'si vardır.

            //    modelBuilder.Entity<SubProductTree>()
            //      .HasOne(p => p.SubProduct) //Bir SubProduct'ın
            //      .WithMany(b => b.ProductTrees)
            //      .HasForeignKey(f=>f.SubProductID); //Birden fazla ProductTree'si vardır.

            //    modelBuilder.Entity<WorkCenterOperation>()
            //     .HasOne(p => p.WorkCenter) //Bir WorkCenter'ın
            //     .WithMany(b => b.WorkCenterOperations)
            //     .HasForeignKey(f=>f.WorkCenterID); //Birden fazla WorkCenterOperation'i vardır.

            //    modelBuilder.Entity<WorkCenterOperation>()
            //    .HasOne(p => p.Operation) //Bir Operasyonun'ın
            //    .WithMany(b => b.WorkCenterOperations)
            //    .HasForeignKey(f=>f.OperationID); //Birden fazla WorkCenterOperation'i vardır.

            modelBuilder.Entity<Order>()
            .HasOne(p =>p.User ) //Bir User'ın
            .WithMany(p => (ICollection<Order>)p.Orders)
            .HasForeignKey(f => f.UserID); //Birden fazla Order'i vardır.

           // modelBuilder.Entity<ProjectState>()
           //.HasMany(h => (ICollection<ProjectRoleState>)h.ProjectRoleStates)
           //.WithOne()
           //.HasForeignKey(p => p.ProjectGuid);
        }
    }
}
