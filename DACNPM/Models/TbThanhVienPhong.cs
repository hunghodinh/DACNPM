using System;
using System.Collections.Generic;

namespace DACNPM.Models;

public partial class TbThanhVienPhong
{
    public int Id { get; set; }

    public int IdSinhVien { get; set; }

    public int IdPhong { get; set; }

    public virtual TbPhong IdPhongNavigation { get; set; } = null!;

    public virtual TbSinhVien IdSinhVienNavigation { get; set; } = null!;
}
