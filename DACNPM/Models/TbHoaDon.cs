using System;
using System.Collections.Generic;

namespace DACNPM.Models;

public partial class TbHoaDon
{
    public int IdHoaDon { get; set; }

    public int? IdHopDong { get; set; }

    public int? IdDichVu { get; set; }

    public DateTime? NgayDong { get; set; }

    public string? NguoiDong { get; set; }

    public decimal? TienPhong { get; set; }

    public decimal? TongTien { get; set; }

    public int? TrangThai { get; set; }

    public string? GhiChu { get; set; }

    public virtual TbDichVu? IdDichVuNavigation { get; set; }

    public virtual TbHopDong? IdHopDongNavigation { get; set; }
}
