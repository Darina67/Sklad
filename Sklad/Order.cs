//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sklad
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int Id { get; set; }
        public Nullable<int> User { get; set; }
        public Nullable<System.DateTime> Orderdate { get; set; }
        public Nullable<System.DateTime> Deliverydate { get; set; }
        public Nullable<int> Status { get; set; }
    
        public virtual ordercomposition ordercomposition { get; set; }
        public virtual orderstatu orderstatu { get; set; }
        public virtual User User1 { get; set; }
    }
}
