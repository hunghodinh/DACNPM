using System;
using System.Collections.Generic;

namespace DACNPM.Models;

public partial class TbDichVu
{
    public int IdDichVu { get; set; }

    public string? TenDichVu { get; set; }

    public decimal? DonGia { get; set; }

    public virtual ICollection<TbHoaDon> TbHoaDons { get; set; } = new List<TbHoaDon>();
}
