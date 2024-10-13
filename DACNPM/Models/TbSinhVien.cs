using System;
using System.Collections.Generic;

namespace DACNPM.Models;

public partial class TbSinhVien
{
    public int IdSinhVien { get; set; }

    public string? TenSinhVien { get; set; }

    public string? Cccd { get; set; }

    public string? SoDt { get; set; }

    public string? Email { get; set; }

    public DateTime? NgaySinh { get; set; }

    public string? DiaChi { get; set; }

    public bool? GioTinh { get; set; }

    public virtual ICollection<TbHopDong> TbHopDongs { get; set; } = new List<TbHopDong>();

    public virtual ICollection<TbThanhVienPhong> TbThanhVienPhongs { get; set; } = new List<TbThanhVienPhong>();
}
