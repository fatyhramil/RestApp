//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pract_pr_22
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ownership
    {
        public int ID { get; set; }
        public Nullable<int> IDUser { get; set; }
        public Nullable<int> IDRest { get; set; }
    
        public virtual Restourant Restourant { get; set; }
        public virtual User User { get; set; }
    }
}
