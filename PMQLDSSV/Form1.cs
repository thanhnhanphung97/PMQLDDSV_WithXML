using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PMQLDSSV.BLL;
using PMQLDSSV.DTO;

namespace PMQLDSSV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnCheckMSV.BackColor = Color.Red;
            cbTenLop.SelectedIndex = 0;
            searchClass.SelectedIndex = 0;
            
        }

        SinhVienBLL svBLL = new SinhVienBLL();
        bool checkMaSV = false;

        private void btnReadFileXML_Click(object sender, EventArgs e)
        {
            dtgvDSSV.ClearSelection();
            svBLL.ShowDSSV(dtgvDSSV);
        }

        private void btnAddSV_Click(object sender, EventArgs e)
        {
            SinhVienDTO svDTO = new SinhVienDTO();
            if ((checkMaSV == true)&&(txtHo.Text != "") && (txtTen.Text != "") && (txtHocBong.Text != ""))
            {
                svDTO.MaSV = txtMSV.Text;
                svDTO.Ho = txtHo.Text;
                svDTO.Ten = txtTen.Text;
                svDTO.NgaySinh = dtNgaySinh.Value;
                string txtSex = "Nữ";
                if (rdNam.Checked == true) txtSex = "Nam";
                svDTO.GioiTinh = txtSex;
                svDTO.HocBong = Int32.Parse(txtHocBong.Text);
                svDTO.TenLop = cbTenLop.Text;

                svBLL.AddSV(svDTO);

                svBLL.ShowDSSV(dtgvDSSV);
            }
            btnRefresh_Click(sender,e);
        }


        private void btnEditSV_Click(object sender, EventArgs e)
        {
            SinhVienDTO svDTO = new SinhVienDTO();
            if ((checkMaSV == false) && (txtHo.Text != "") && (txtTen.Text != "") && (txtHocBong.Text != ""))
            {
                svDTO.MaSV = txtMSV.Text;
                svDTO.Ho = txtHo.Text;
                svDTO.Ten = txtTen.Text;
                svDTO.NgaySinh = dtNgaySinh.Value;
                string txtSex = "Nữ";
                if (rdNam.Checked == true) txtSex = "Nam";
                svDTO.GioiTinh = txtSex;
                svDTO.HocBong = Int32.Parse(txtHocBong.Text);
                svDTO.TenLop = cbTenLop.Text;

                svBLL.EditSV(svDTO);

                svBLL.ShowDSSV(dtgvDSSV);
            }
        }


        private void txtMSV_TextChanged(object sender, EventArgs e)
        {
            if (svBLL.CheckMaSV(txtMSV.Text.Trim()) == true)
            {
                btnCheckMSV.BackColor = Color.Green;
                checkMaSV = true;
            }
            else
            {
                btnCheckMSV.BackColor = Color.Red;
                checkMaSV = false;
            }
        }

        private void txtHocBong_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtMSV.Text = "";
            checkMaSV = false;
            btnCheckMSV.BackColor = Color.Red;

            txtHo.Text = "";
            txtTen.Text = "";
            txtHocBong.Text = "";
            dtNgaySinh.Value = DateTime.Today;
        }

        private void dtgvDSSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > 0)
            {
                DataGridViewRow row = this.dtgvDSSV.Rows[e.RowIndex];

                try
                {
                    txtMSV.Text = row.Cells[0].Value.ToString();
                    txtHo.Text = row.Cells[1].Value.ToString();
                    txtTen.Text = row.Cells[2].Value.ToString();
                    dtNgaySinh.Value = Convert.ToDateTime(row.Cells[3].Value.ToString());
                    if (row.Cells[4].Value.ToString() == "Nam") rdNam.Checked = true;
                    else rdNu.Checked = true;
                    txtHocBong.Text = row.Cells[5].Value.ToString();
                    cbTenLop.Text = row.Cells[6].Value.ToString();
                }
                catch (Exception)
                {
                    
                }
            }

        }

        private void btnDeleteSV_Click(object sender, EventArgs e)
        {
            SinhVienDTO sv = new SinhVienDTO();
            sv.MaSV = txtMSV.Text;
            svBLL.DeleteSV(sv);

            svBLL.ShowDSSV(dtgvDSSV);

            btnRefresh_Click(sender, e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            svBLL.SearchSV(txtSearch.Text, dtgvDSSV,searchClass.Text);
        }
    }
}
