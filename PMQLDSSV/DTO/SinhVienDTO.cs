using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQLDSSV.DTO
{
    public class SinhVienDTO
    {
        private string _MaSV;
        private string _GioiTinh;
        private string _TenLop;
        private string _Ho;
        private string _Ten;
        private DateTime _NgaySinh;
        private int _HocBong;

        public string MaSV
        {
            get
            {
                return _MaSV;
            }

            set
            {
                _MaSV = value;
            }
        }

        public string GioiTinh
        {
            get
            {
                return _GioiTinh;
            }

            set
            {
                _GioiTinh = value;
            }
        }

        public string TenLop
        {
            get
            {
                return _TenLop;
            }

            set
            {
                _TenLop = value;
            }
        }

        public string Ho
        {
            get
            {
                return _Ho;
            }

            set
            {
                _Ho = value;
            }
        }

        public string Ten
        {
            get
            {
                return _Ten;
            }

            set
            {
                _Ten = value;
            }
        }

        public DateTime NgaySinh
        {
            get
            {
                return _NgaySinh;
            }

            set
            {
                _NgaySinh = value;
            }
        }

        public int HocBong
        {
            get
            {
                return _HocBong;
            }

            set
            {
                _HocBong = value;
            }
        }
    }
}
