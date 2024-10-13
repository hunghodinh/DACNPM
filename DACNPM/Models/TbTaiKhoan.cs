using System;
using System.Collections.Generic;

namespace DACNPM.Models;

public partial class TbTaiKhoan
{
    public int IdTaiKhoan { get; set; }

    public int? IdNhanVien { get; set; }

    public string? TenTk { get; set; }

    public string? MatKhau { get; set; }

    public virtual TbNhanVien? IdNhanVienNavigation { get; set; }
}
