using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTH3_BT9
{
    public static class DuLieuMonHoc
    {
        public static Dictionary<string, List<string>> DanhSachMonHocTheoChuyenNganh = new Dictionary<string, List<string>>()
        {
            {"Hệ Thống Thông Tin", new List<string> {"Cơ Sở Dữ Liệu", "Cơ Sở DL NC", "PTTK Hệ thống thông tin", "Quản trị mạng", "An toàn thông tin"}},
            {"Kỹ Thuật Phần Mềm", new List<string> {"Thiết kế hệ thống", "Kiểm thử phần mềm", "Lập trình Web", "Phân tích yêu cầu"}},
            {"Khoa Học Máy Tính", new List<string> {"Giải thuật nâng cao", "Trí tuệ nhân tạo", "Học máy", "Xử lý ảnh"}},
            {"Kỹ Thuật Máy Tính", new List<string> {"Kiến trúc máy tính", "Hệ điều hành", "Vi xử lý", "Thiết kế mạch số"}},
            {"Trí Tuệ Nhân Tạo", new List<string> {"Machine Learning", "Deep Learning", "Xử lý ngôn ngữ tự nhiên", "Thị giác máy tính"}},
            {"An Toàn Thông Tin", new List<string> {"Mật mã học", "Kiểm thử xâm nhập", "Quản lý rủi ro", "Pháp chế ATTT"}},
            {"Truyền Thông Đa Phương Tiện", new List<string> {"Thiết kế đồ họa", "Sản xuất video", "Truyền thông số", "Thương mại di động"}},
            {"Thương Mại Điện Tử", new List<string> {"Marketing số", "Quản trị sàn TMĐT", "Luật thương mại", "Phân tích kinh doanh"}},
            {"Công Nghệ Thông Tin", new List<string> {"Lập trình C cơ bản", "Cấu trúc dữ liệu", "Mạng máy tính", "Toán rời rạc"}},
            {"Công Nghệ Thông Tin Việt Nhật", new List<string> {"Lập trình cơ bản", "Cấu trúc DL", "Tiếng Nhật chuyên ngành", "Văn hóa công sở Nhật"}}
        };
        public static List<string> GetChuyenNganhList()
        {
            return DanhSachMonHocTheoChuyenNganh.Keys.ToList();
        }
    }
}
