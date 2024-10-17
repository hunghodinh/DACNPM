using System;
using System.Collections.Generic;

namespace DACNPM.Models;

public partial class TbNhanVien
{
    public int IdNhanVien { get; set; }

    public string? TenNhanVien { get; set; }

    public string? SoDt { get; set; }

    public string? Email { get; set; }

    public string? Cccd { get; set; }

    public DateTime? NgaySinh { get; set; }

    public bool? GioTinh { get; set; }
	public string? ChucVu { get; set; }

	public virtual ICollection<TbHopDong> TbHopDongs { get; set; } = new List<TbHopDong>();

    public virtual ICollection<TbTaiKhoan> TbTaiKhoans { get; set; } = new List<TbTaiKhoan>();
}
