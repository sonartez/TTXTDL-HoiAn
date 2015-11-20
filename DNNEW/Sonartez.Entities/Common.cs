using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Sonartez.Entities
{
    public class Categories
    {
        public const string KhachSan = "Khách sạn";
        public const string AmThuc = "Ẩm thực mua sắm";
        public const string VanChuyen = "Vận chuyển, Lữ Hành";
        public const string CoQuan = "Cơ Quan Nhà Nước";
        public const string NganHang = "Ngân Hàng, ATM";
        public const string GiaiTri = "Vui chơi, giải trí, nghiên cứu";
        public const string DiemDen = "Điểm đến";
   
        public static List<listItem> listValue = new List<listItem> { 
            new listItem { Display = KhachSan, Value = KhachSan },
            new listItem { Display = VanChuyen, Value = VanChuyen },
            new listItem { Display = CoQuan, Value = CoQuan },
            new listItem { Display = NganHang, Value = NganHang },
            new listItem { Display = GiaiTri, Value = GiaiTri },
            new listItem { Display = AmThuc, Value = AmThuc },
             new listItem { Display = DiemDen, Value = DiemDen }
        };
    }
    public class Permission
    {
        public const string Normal = "Nhân viên";
        public const string Approval = "Kiểm duyệt";
        public const string Report = "Xem báo cáo";
        public const string Admin = "Toàn quyền";
        public static List<listItem> listValue = new List<listItem> { 
            new listItem { Display = Normal, Value = Normal },
            new listItem { Display = Approval, Value = Approval },
            new listItem { Display = Report, Value = Report },
            new listItem { Display = Admin, Value = Admin } 
        };
    }
    public class Locations
    {
        public const string HoiAn = "Hội An";
        public const string TamKy = "Tam Kỳ";
        public const string DienBan = "Điện Bàn";
        public const string ThangBinh = "Thăng Bình";
        public const string DuyXuyen = "Duy Xuyên";
        public const string QueSon = "Quế Sơn";
        public const string NuiThanh = "Núi Thành";
        public const string NamTraMy = "Nam Trà My";
        public const string BacTraMy = "Bắc Trà My";
        public const string HiepDuc = "Hiệp Đức";
        public const string DongGiang = "Đông Giang";
        public const string NamGiang = "Nam Giang";
        public const string TayGiang = "Tây Giang";
        public const string NongSon = "Nông Sơn";
        public const string DaiLoc = "Đại Lộc";
        public const string PhuNinh = "Phú Ninh";
        public const string TienPhuoc = "Tiên Phước";
        public const string PhuocSon = "Phước Sơn";
    

        public static List<listItem> listValue = new List<listItem> { 
            new listItem { Display = HoiAn, Value = HoiAn },
            new listItem { Display = TamKy, Value = TamKy },
            new listItem { Display = DienBan, Value = DienBan },
            new listItem { Display = ThangBinh, Value = ThangBinh } ,
            new listItem { Display = DuyXuyen, Value = DuyXuyen },
            new listItem { Display = QueSon, Value = QueSon },
            new listItem { Display = NuiThanh, Value = NuiThanh },
            new listItem { Display = NamTraMy, Value = NamTraMy },
            new listItem { Display = BacTraMy, Value = BacTraMy },
            new listItem { Display = HiepDuc, Value = HiepDuc },
            new listItem { Display = DongGiang, Value = DongGiang },
            new listItem { Display = NamGiang, Value = NamGiang },
            new listItem { Display = TayGiang, Value = TayGiang },
            new listItem { Display = NongSon, Value = NongSon },
            new listItem { Display = DaiLoc, Value = DaiLoc },
            new listItem { Display = PhuNinh, Value = PhuNinh },
            new listItem { Display = TienPhuoc, Value = TienPhuoc } ,
            new listItem { Display = PhuocSon, Value = PhuocSon } 

        };
    }

    public class ConsultantType
    {
        public const string Anonymus = "Khách vãng lai";
        public const string Single = "Cá nhân";
        public const string Team = "Nhóm";
        public const string PhoneCall = "Hotline";
        public static List<listItem> listValue = new List<listItem> { 
            new listItem { Display = Anonymus, Value = Anonymus }, 
            new listItem { Display = Single, Value = Single }, 
            new listItem { Display = Team, Value = Team }, 
            new listItem { Display = PhoneCall, Value = PhoneCall } 
        };
    }

    public class InformationType
    {
        public const string All = "Tất cả";
        public const string NoLimit = "Thường xuyên";
        public const string Limited = "Giới hạn thời gian";

        public static List<listItem> listValue = new List<listItem> { 
            new listItem { Display = All, Value = All }, 
            new listItem { Display = NoLimit, Value = NoLimit }, 
            new listItem { Display = Limited, Value = Limited } 
        };
    }

    public class InformationStatus
    {
        public const string All = "Tất cả";
        public const string Pending = "Chưa duyệt";
        public const string Approved = "Đã duyệt";
        public const string Expired = "Hết hạn";
        public const string Rejected = "Không duyệt";
        public static List<listItem> listValue = new List<listItem> { 
            new listItem { Display = All, Value = All }, 
            new listItem { Display = Pending, Value = Pending }, 
            new listItem { Display = Approved, Value = Approved }, 
            new listItem { Display = Expired, Value = Expired } 
        };
    }

    public class ConsultantFinishType
    {
        public const string Good = "Hoàn Thành";
        public const string Normal = "Hài lòng";
        public const string Bad = "Chưa tốt";
        public const string Incomplete = "Đang xử lý";
        public static List<listItem> listValue = new List<listItem> { 
            new listItem { Display = Good, Value = Good },
            new listItem { Display = Normal, Value = Normal }, 
            new listItem { Display = Bad, Value = Bad }, 
            new listItem { Display = Incomplete, Value = Incomplete } 
        };
    }
    public class ConsultantStatus
    {
        public const string OK = "Ok";
    }

    public class listItem
    {
        public string Display { set; get; }
        public string Value { set; get; }
    }


/// <summary>
/// Methods to remove HTML from strings.
/// </summary>
public static class HtmlRemoval
{
    /// <summary>
    /// Remove HTML from string with Regex.
    /// </summary>
    public static string StripTagsRegex(string source)
    {
	return Regex.Replace(source, "<.*?>", string.Empty);
    }

    /// <summary>
    /// Compiled regular expression for performance.
    /// </summary>
    static Regex _htmlRegex = new Regex("<.*?>", RegexOptions.Compiled);

    /// <summary>
    /// Remove HTML from string with compiled Regex.
    /// </summary>
    public static string StripTagsRegexCompiled(string source)
    {
	return _htmlRegex.Replace(source, string.Empty);
    }

    /// <summary>
    /// Remove HTML tags from string using char array.
    /// </summary>
    public static string StripTagsCharArray(string source)
    {
	char[] array = new char[source.Length];
	int arrayIndex = 0;
	bool inside = false;

	for (int i = 0; i < source.Length; i++)
	{
	    char let = source[i];
	    if (let == '<')
	    {
		inside = true;
		continue;
	    }
	    if (let == '>')
	    {
		inside = false;
		continue;
	    }
	    if (!inside)
	    {
		array[arrayIndex] = let;
		arrayIndex++;
	    }
	}
	return new string(array, 0, arrayIndex);
    }
}
}
