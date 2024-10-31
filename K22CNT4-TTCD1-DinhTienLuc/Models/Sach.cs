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

    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            this.Carts = new HashSet<Cart>();
        }
    
        public int Id { get; set; }
        [Required(ErrorMessage = "Chọn danh mục sách:")]
        public int IdDanhMuc { get; set; }
        [Required(ErrorMessage = "Hãy nhập tên sách:")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Hãy nhập số lượng:")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Hãy nhập giá:")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Hãy nhập mô tả:")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Hãy nhập ảnh:")]
        public string Images { get; set; }
        [Required(ErrorMessage = "Hãy chọn trạng thái:")]
        public bool Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual DanhMucSach DanhMucSach { get; set; }
    }
}
