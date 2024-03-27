namespace Ictshop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;


    [Table("ReviewSanPham")]
    public partial class ReviewSanPham
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Sanpham")]
        public int SanPhamID { get; set; }
        
        public string UserName { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Content { get; set; }

        public int Rate { get; set; }
            
        public DateTime CreateDate { get; set; }
         public string Avatar { get; set; }

        public virtual Sanpham Sanpham { get; set; }
    }
}