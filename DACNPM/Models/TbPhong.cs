using System;
using System.Collections.Generic;

namespace DACNPM.Models;

public partial class TbPhong
{
    public int IdPhong { get; set; }

    public string? TenPhong { get; set; }

    public decimal? DonGia { get; set; }

    public int? SoNguoiMax { get; set; }

    public string? LoaiPhong { get; set; }

    public bool? TrangThai { get; set; }

    public string? MoTa { get; set; }

    public virtual ICollection<TbHopDong> TbHopDongs { get; set; } = new List<TbHopDong>();

    public virtual ICollection<TbThanhVienPhong> TbThanhVienPhongs { get; set; } = new List<TbThanhVienPhong>();
}
