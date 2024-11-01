﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace K22CNT4_TTCD1_DinhTienLuc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.Status = true;
            this.Carts = new HashSet<Cart>();
        }
    
        public int Id { get; set; }
        [Required(ErrorMessage = "Hãy nhập tên người dùng:")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Hãy nhập email:")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Hãy nhập mật khẩu:")]
        public string Password { get; set; }
        public bool Status { get; set; }
        public Nullable<bool> Role { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
