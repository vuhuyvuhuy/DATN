using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace BusinessLogic.Entities
{
   public class XEVO
    {
        public int ID { get; set; }
        public DateTime NgayGioVao { get; set; }
        public DateTime NgayGioRa { get; set; }
        public string maloai { get; set; }
        public string sothe { get; set; }
        public string manv { get; set; }
        public string biensoxe { get; set; }
        public byte[] AnhPhiaTruoc { get; set; }
        public byte[] AnhPhiaSau { get; set; }
        public bool TinhTrang { get; set; }
    }
}
