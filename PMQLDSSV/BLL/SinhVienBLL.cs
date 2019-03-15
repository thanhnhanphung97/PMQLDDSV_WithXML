using PMQLDSSV.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace PMQLDSSV.BLL
{
    public class SinhVienBLL
    {
        XmlDocument doc = new XmlDocument();
        XmlElement root;

        // kéo thả file DSSinhVien.xml để lấy đường dẫn 
        string fileName = @"D:\Study\Code\Visual\Project\PMQLDSSV\PMQLDSSV\DSSinhVien.xml";

        public SinhVienBLL()
        {
            doc.Load(fileName);
            root = doc.DocumentElement;
        }

        public void AddSV(SinhVienDTO newSV)
        {
            XmlNode sv = doc.CreateElement("sinhvien");

            XmlElement masv = doc.CreateElement("masv");
            masv.InnerText = newSV.MaSV;
            sv.AppendChild(masv);

            XmlElement gioitinh = doc.CreateElement("gioitinh");
            gioitinh.InnerText = newSV.GioiTinh;
            sv.AppendChild(gioitinh);

            XmlElement tenlop = doc.CreateElement("tenlop");
            tenlop.InnerText = newSV.TenLop;
            sv.AppendChild(tenlop);

            XmlElement ho = doc.CreateElement("ho");
            ho.InnerText = newSV.Ho;
            sv.AppendChild(ho);

            XmlElement ten = doc.CreateElement("ten");
            ten.InnerText = newSV.Ten;
            sv.AppendChild(ten);

            XmlElement ngaysinh = doc.CreateElement("ngaysinh");
            ngaysinh.InnerText = newSV.NgaySinh.ToShortDateString().ToString();
            sv.AppendChild(ngaysinh);

            XmlElement hocbong = doc.CreateElement("hocbong");
            hocbong.InnerText = newSV.HocBong.ToString();
            sv.AppendChild(hocbong);

            root.AppendChild(sv);
            doc.Save(fileName);
        }

        public void EditSV(SinhVienDTO editSV)
        {
            XmlNode sv = root.SelectSingleNode("sinhvien[masv = '" + editSV.MaSV + "']");
            if(sv != null)
            {
                XmlNode newSV = doc.CreateElement("sinhvien");

                XmlElement masv = doc.CreateElement("masv");
                masv.InnerText = editSV.MaSV;
                newSV.AppendChild(masv);

                XmlElement gioitinh = doc.CreateElement("gioitinh");
                gioitinh.InnerText = editSV.GioiTinh;
                newSV.AppendChild(gioitinh);

                XmlElement tenlop = doc.CreateElement("tenlop");
                tenlop.InnerText = editSV.TenLop;
                newSV.AppendChild(tenlop);

                XmlElement ho = doc.CreateElement("ho");
                ho.InnerText = editSV.Ho;
                newSV.AppendChild(ho);

                XmlElement ten = doc.CreateElement("ten");
                ten.InnerText = editSV.Ten;
                newSV.AppendChild(ten);

                XmlElement ngaysinh = doc.CreateElement("ngaysinh");
                ngaysinh.InnerText = editSV.NgaySinh.ToShortDateString().ToString();
                newSV.AppendChild(ngaysinh);

                XmlElement hocbong = doc.CreateElement("hocbong");
                hocbong.InnerText = editSV.HocBong.ToString();
                newSV.AppendChild(hocbong);

                //Save
                root.ReplaceChild(newSV,sv);
                doc.Save(fileName);
            }
        }

        public void DeleteSV(SinhVienDTO deleteSV)
        {
            XmlNode sv = root.SelectSingleNode("sinhvien[masv = '"+ deleteSV.MaSV +"']");
            if(sv != null)
            {
                root.RemoveChild(sv);

                doc.Save(fileName);
            }
        }

        public void SearchSV(string searchString,DataGridView dtgv,string searchClass)
        {
            dtgv.Rows.Clear();
            dtgv.ColumnCount = 7;

            int id = 0;
            XmlNodeList sv;
            if(searchClass == "Mã Sinh Viên") sv = root.SelectNodes("sinhvien[masv = '" + searchString + "']");
            else sv = root.SelectNodes("sinhvien[ten = '" + searchString + "']");

            foreach (XmlNode item in sv)
            {
                dtgv.Rows.Add();
                dtgv.Rows[id].Cells[0].Value = item.SelectSingleNode("masv").InnerText;
                dtgv.Rows[id].Cells[1].Value = item.SelectSingleNode("ho").InnerText;
                dtgv.Rows[id].Cells[2].Value = item.SelectSingleNode("ten").InnerText;
                dtgv.Rows[id].Cells[3].Value = item.SelectSingleNode("ngaysinh").InnerText;
                dtgv.Rows[id].Cells[4].Value = item.SelectSingleNode("gioitinh").InnerText;
                dtgv.Rows[id].Cells[5].Value = item.SelectSingleNode("hocbong").InnerText;
                dtgv.Rows[id].Cells[6].Value = item.SelectSingleNode("tenlop").InnerText;

                id++;
            }
            
        }

        public void ShowDSSV(DataGridView dtgv)
        {
            dtgv.Rows.Clear();
            dtgv.ColumnCount = 7;
            int id = 0;
            XmlNodeList ds = root.SelectNodes("sinhvien");
            foreach (XmlNode item in ds)
            {
                dtgv.Rows.Add();
                dtgv.Rows[id].Cells[0].Value = item.SelectSingleNode("masv").InnerText;
                dtgv.Rows[id].Cells[1].Value = item.SelectSingleNode("ho").InnerText;
                dtgv.Rows[id].Cells[2].Value = item.SelectSingleNode("ten").InnerText;
                dtgv.Rows[id].Cells[3].Value = item.SelectSingleNode("ngaysinh").InnerText;
                dtgv.Rows[id].Cells[4].Value = item.SelectSingleNode("gioitinh").InnerText;
                dtgv.Rows[id].Cells[5].Value = item.SelectSingleNode("hocbong").InnerText;
                dtgv.Rows[id].Cells[6].Value = item.SelectSingleNode("tenlop").InnerText;

                id++;
            }
        }

        public bool CheckMaSV(string maSV)
        {
            XmlNode sv = root.SelectSingleNode("sinhvien[masv='" + maSV + "']");
            if (sv != null) return false;
            else return true;
        }
    }
}
