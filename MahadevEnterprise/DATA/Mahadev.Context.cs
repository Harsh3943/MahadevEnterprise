﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MahadevEnterprise.DATA
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class MahadevEnterpriseEntities : DbContext
    {
        public MahadevEnterpriseEntities()
            : base("name=MahadevEnterpriseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CustomerMaster> CustomerMasters { get; set; }
        public virtual DbSet<InvoiceMaster> InvoiceMasters { get; set; }
        public virtual DbSet<OrderMaster> OrderMasters { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<StockMaster> StockMasters { get; set; }
        public virtual DbSet<SupplierMaster> SupplierMasters { get; set; }
        public virtual DbSet<UnitMaster> UnitMasters { get; set; }
    
        public virtual ObjectResult<SP_GETOrdorCustomer_Result> SP_GETOrdorCustomer()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GETOrdorCustomer_Result>("SP_GETOrdorCustomer");
        }
    
        public virtual ObjectResult<SP_GetProduct_Result> SP_GetProduct()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetProduct_Result>("SP_GetProduct");
        }
    
        public virtual ObjectResult<SP_GETStock_Result> SP_GETStock()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GETStock_Result>("SP_GETStock");
        }
    
        public virtual ObjectResult<SP_GetSupplier_Result> SP_GetSupplier()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetSupplier_Result>("SP_GetSupplier");
        }
    
        public virtual ObjectResult<SP_GetUnit_Result> SP_GetUnit()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetUnit_Result>("SP_GetUnit");
        }
    
        public virtual int SP_SETOrdorCustomer(string firstName, string lastName, string email, string mobile, string address, Nullable<int> productId, Nullable<int> quantity, Nullable<decimal> totalPrice)
        {
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var mobileParameter = mobile != null ?
                new ObjectParameter("Mobile", mobile) :
                new ObjectParameter("Mobile", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var productIdParameter = productId.HasValue ?
                new ObjectParameter("ProductId", productId) :
                new ObjectParameter("ProductId", typeof(int));
    
            var quantityParameter = quantity.HasValue ?
                new ObjectParameter("Quantity", quantity) :
                new ObjectParameter("Quantity", typeof(int));
    
            var totalPriceParameter = totalPrice.HasValue ?
                new ObjectParameter("TotalPrice", totalPrice) :
                new ObjectParameter("TotalPrice", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_SETOrdorCustomer", firstNameParameter, lastNameParameter, emailParameter, mobileParameter, addressParameter, productIdParameter, quantityParameter, totalPriceParameter);
        }
    
        public virtual int SP_SETStock(Nullable<int> productId, Nullable<int> supplierId, Nullable<int> stockQuantity, Nullable<int> unitId)
        {
            var productIdParameter = productId.HasValue ?
                new ObjectParameter("ProductId", productId) :
                new ObjectParameter("ProductId", typeof(int));
    
            var supplierIdParameter = supplierId.HasValue ?
                new ObjectParameter("SupplierId", supplierId) :
                new ObjectParameter("SupplierId", typeof(int));
    
            var stockQuantityParameter = stockQuantity.HasValue ?
                new ObjectParameter("StockQuantity", stockQuantity) :
                new ObjectParameter("StockQuantity", typeof(int));
    
            var unitIdParameter = unitId.HasValue ?
                new ObjectParameter("UnitId", unitId) :
                new ObjectParameter("UnitId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_SETStock", productIdParameter, supplierIdParameter, stockQuantityParameter, unitIdParameter);
        }
    }
}