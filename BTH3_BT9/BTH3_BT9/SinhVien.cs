using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTH3_BT9
{
    public class SinhVien
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public string ChuyenNganh { get; set; }
        public string GioiTinh { get; set; }
        public List<string> MonDaDangKy { get; set; }
        public int SoMonDangKy
        {
            get
            {
                if (MonDaDangKy == null)
                {
                    return 0; 
                }
                return MonDaDangKy.Count;
            }
        }
    }
}
