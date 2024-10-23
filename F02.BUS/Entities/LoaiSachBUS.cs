using F03.DAL.Lib;
using F03.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;

namespace F02.BUS.Entities
{
    public class LoaiSachBUS
    {
        private LoaiSachDAL loaiSachDAL;

        public LoaiSachBUS()
        {
            loaiSachDAL = new LoaiSachDAL();
        }

        // Lấy danh sách tất cả thể loại sách (nghiệp vụ gọi DAL)
        public List<LoaiSach> GetAllLoaiSach()
        {
            return loaiSachDAL.GetAllLoaiSach();
        }


        public int? GetMaLoaiByTenLoai(string tenLoai)
        {
           
            return loaiSachDAL.GetMaLoaiByTenLoai(tenLoai);
        }
    }
}
