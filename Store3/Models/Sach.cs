namespace Store3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSach { get; set; }

        public string TenSach { get; set; }

        public int? GiaBan { get; set; }

        public string MoTa { get; set; }

        [Column(TypeName = "ntext")]
        public string HinhAnh { get; set; }

        public DateTime? NgayCapNhap { get; set; }

        public int? SLTon { get; set; }

        public int? MaNXB { get; set; }

        public int? MaTL { get; set; }

        public int? MaTG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

        public virtual NXB NXB { get; set; }

        public virtual TacGia TacGia { get; set; }

        public virtual TheLoai TheLoai { get; set; }
    }
}
