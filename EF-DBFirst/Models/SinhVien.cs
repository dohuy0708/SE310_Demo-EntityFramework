using System;
using System.Collections.Generic;

namespace EF_DBFirst.Models;

public partial class SinhVien
{
    public string Mssv { get; set; } = null!;

    public string Ten { get; set; } = null!;

    public string Khoa { get; set; } = null!;
}
