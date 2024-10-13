using System;
using System.Collections.Generic;

namespace DACNPM.Models;

public partial class TbHopDong
{
    public int IdHopDong { get; set; }

    public int? IdPhong { get; set; }

    public int? IdSinhVien { get; set; }

    public int? IdNhanVien { get; set; }

    public DateTime? NgayBatDau { get; set; }

    public DateTime? NgayKetThuc { get; set; }

    public decimal? TienCoc { get; set; }

    public int? TrangThai { get; set; }

    public string? ChuY { get; set; }

    public virtual TbNhanVien? IdNhanVienNavigation { get; set; }

    public virtual TbPhong? IdPhongNavigation { get; set; }

    public virtual TbSinhVien? IdSinhVienNavigation { get; set; }

    public virtual ICollection<TbHoaDon> TbHoaDons { get; set; } = new List<TbHoaDon>();
}
