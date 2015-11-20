using LinqToExcel;
using Sonartez.Entities;
using Sonartez.Helpdesk.Bussiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImportData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            if (DialogResult.OK == fdlg.ShowDialog())
            {
                var excel = new ExcelQueryFactory(fdlg.FileName);
                var indianaCompanies = from c in excel.Worksheet("Sheet1")
                                       select c;
                int ix = 0;
                int il = 0;
                foreach (var item in indianaCompanies)
                {
                    TblInfor newInfo = new TblInfor();


                    string content = "<b>" + item[1].ToString().Trim() + "</b> <br />"
                                    + "" + item[10].ToString().Trim()
                                    + "<br>Khu vực: " + item[9].ToString().Trim()
                                   + "<br>ĐC: " + item[4].ToString().Trim()
                                   + "<br> Số Phòng: " + item[6].ToString().Trim()
                                   + "<br> ĐT: " + item[2].ToString().Trim() + " - FAX: " + item[3].ToString().Trim()
                                   + "<br> Email: " + item[5].ToString().Trim()
                                    + "<br> Chủ đầu tư: " + item[7].ToString().Trim()
                                   + "<br>Giám đốc: " + item[8].ToString().Trim();

                    string tag = "Khách sạn, khach san, ks, " + item[11].ToString().Trim() + ", " + item[2].ToString().Trim();

                    newInfo.CreateDate = DateTime.Now;
                    newInfo.CreateUserID = Guid.Parse("b0b6997c-282b-4aff-b286-b0820cdb0100");
                    newInfo.ID = Guid.NewGuid();
                    newInfo.Category = Categories.KhachSan;
                    newInfo.Location = item[9].ToString().Trim();
                    newInfo.InfoContent = HtmlRemoval.StripTagsRegexCompiled(content);
                    newInfo.InfoContentHtml = content;
                    newInfo.InfoTag = tag;
                    newInfo.InfoTitle = item[1].ToString().Trim() + " " + item[9].ToString().Trim();
                    newInfo.InfoType = InformationType.NoLimit;
                    newInfo.Status = InformationStatus.Approved;

                    newInfo.UpdateDate = DateTime.Now;
                    newInfo.UpdateUserID = Guid.Parse("b0b6997c-282b-4aff-b286-b0820cdb0100");

                    try
                    {
                        BBLInfo b = new BBLInfo();
                        b.InsertOrUpdate(newInfo);

                        ix++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("E - > " + ex.Message);
                        // DevExpress.XtraEditors.XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, this.FindForm(), ex.Message, "Có sự cố", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        il++;
                    }
                }

                Console.WriteLine(ix + " | " + il);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            if (DialogResult.OK == fdlg.ShowDialog())
            {
                var excel = new ExcelQueryFactory(fdlg.FileName);
                var indianaCompanies = from c in excel.Worksheet("Sheet1")
                                       select c;
                int ix = 0;
                int il = 0;
                foreach (var item in indianaCompanies)
                {
                    TblInfor newInfo = new TblInfor();


                    string content = "<b>" + item[2].ToString().Trim() + "</b> " + item[6].ToString().Trim()
                                    + "<br> <i> " + item[3].ToString().Trim() + "</i>"
                                   + "<br> " + item[1].ToString().Trim()
                                   + "<br>Địa chỉ " + item[4].ToString().Trim()
                                   + "<br>ĐT: " + item[5].ToString().Trim() + " - " + item[6].ToString().Trim();

                    string tag = "Ẩm thực, " + item[3].ToString().Trim();

                    newInfo.CreateDate = DateTime.Now;
                    newInfo.CreateUserID = Guid.Parse("b0b6997c-282b-4aff-b286-b0820cdb0100");
                    newInfo.ID = Guid.NewGuid();
                    newInfo.IsDeleted = 0;
                    newInfo.InfoContent = HtmlRemoval.StripTagsRegexCompiled(content);
                    newInfo.InfoContentHtml = content;
                    newInfo.InfoTag = tag;
                    newInfo.Category = Categories.AmThuc;
                    newInfo.Location = item[6].ToString().Trim();
                    newInfo.InfoTitle = item[2].ToString().Trim() + " " + item[6].ToString().Trim();
                    newInfo.InfoType = InformationType.NoLimit;
                    newInfo.Status = InformationStatus.Approved;

                    newInfo.UpdateDate = DateTime.Now;
                    newInfo.UpdateUserID = Guid.Parse("b0b6997c-282b-4aff-b286-b0820cdb0100");

                    try
                    {
                        BBLInfo b = new BBLInfo();
                        b.InsertOrUpdate(newInfo);

                        ix++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("E - > " + ex.Message);
                        // DevExpress.XtraEditors.XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, this.FindForm(), ex.Message, "Có sự cố", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        il++;
                    }
                }

                Console.WriteLine(ix + " | " + il);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            if (DialogResult.OK == fdlg.ShowDialog())
            {
                var excel = new ExcelQueryFactory(fdlg.FileName);
                var indianaCompanies = from c in excel.Worksheet("Sheet1")
                                       select c;
                int ix = 0;
                int il = 0;
                foreach (var item in indianaCompanies)
                {
                    TblInfor newInfo = new TblInfor();


                    string content = "<b>" + item[0].ToString().Trim() + "</b>  Số hiệu :" + item[2].ToString().Trim()
                                    + "<br>Tần suất: " + item[4].ToString().Trim() + " Giá vé : " + item[7].ToString().Trim()
                                   + "<br>Tuyến đường: " + item[3].ToString().Trim()
                                   + "<br>Thời gian hoạt động: " + item[6].ToString().Trim() + " Số chuyến/ngày: " + item[5].ToString().Trim()
                                   + "<br>Đơn vị: " + item[1].ToString().Trim()
                                   + "<br>ĐT: " + item[8].ToString().Trim();

                    string tag = "xe, vận tải, dịch vụ ";

                    newInfo.CreateDate = DateTime.Now;
                    newInfo.CreateUserID = Guid.Parse("b0b6997c-282b-4aff-b286-b0820cdb0100");
                    newInfo.ID = Guid.NewGuid();
                    newInfo.IsDeleted = 0;
                    newInfo.InfoContent = HtmlRemoval.StripTagsRegexCompiled(content);
                    newInfo.InfoContentHtml = content;
                    newInfo.InfoTag = tag;
                    newInfo.InfoTitle = item[0].ToString().Trim();
                    newInfo.InfoType = InformationType.NoLimit;
                    newInfo.Status = InformationStatus.Approved;

                    newInfo.UpdateDate = DateTime.Now;
                    newInfo.UpdateUserID = Guid.Parse("b0b6997c-282b-4aff-b286-b0820cdb0100");

                    try
                    {
                        BBLInfo b = new BBLInfo();
                        b.InsertOrUpdate(newInfo);

                        ix++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("E - > " + ex.Message);
                        // DevExpress.XtraEditors.XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, this.FindForm(), ex.Message, "Có sự cố", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        il++;
                    }
                }

                Console.WriteLine(ix + " | " + il);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            if (DialogResult.OK == fdlg.ShowDialog())
            {
                var excel = new ExcelQueryFactory(fdlg.FileName);
                var indianaCompanies = from c in excel.Worksheet("Sheet1")
                                       select c;
                int ix = 0;
                int il = 0;
                foreach (var item in indianaCompanies)
                {
                    TblInfor newInfo = new TblInfor();


                    string content = "<b>" + item[0].ToString().Trim() + "</b> "
                                    + "<br>Địa chỉ: " + item[1].ToString().Trim()
                                   + "<br>" + item[2].ToString().Trim()
                                   + "<br>ĐT: " + item[3].ToString().Trim();

                    string tag = "dịch vụ";

                    newInfo.CreateDate = DateTime.Now;
                    newInfo.CreateUserID = Guid.Parse("b0b6997c-282b-4aff-b286-b0820cdb0100");
                    newInfo.ID = Guid.NewGuid();
                    newInfo.IsDeleted = 0;
                    newInfo.InfoContent = HtmlRemoval.StripTagsRegexCompiled(content);
                    newInfo.InfoContentHtml = content;
                    newInfo.InfoTag = tag;
                    newInfo.InfoTitle = item[0].ToString().Trim();
                    newInfo.InfoType = InformationType.NoLimit;
                    newInfo.Status = InformationStatus.Approved;

                    newInfo.UpdateDate = DateTime.Now;
                    newInfo.UpdateUserID = Guid.Parse("b0b6997c-282b-4aff-b286-b0820cdb0100");

                    try
                    {
                        BBLInfo b = new BBLInfo();
                        b.InsertOrUpdate(newInfo);

                        ix++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("E - > " + ex.Message);
                        // DevExpress.XtraEditors.XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, this.FindForm(), ex.Message, "Có sự cố", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        il++;
                    }
                }

                Console.WriteLine(ix + " | " + il);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            if (DialogResult.OK == fdlg.ShowDialog())
            {
                var excel = new ExcelQueryFactory(fdlg.FileName);
                var indianaCompanies = from c in excel.Worksheet("Sheet1")
                                       select c;
                int ix = 0;
                int il = 0;
                foreach (var item in indianaCompanies)
                {
                    TblInfor newInfo = new TblInfor();


                    string content = "<b>" + item[1].ToString().Trim() + "</b> "
                         + "<br><u>" + item[9].ToString().Trim() + "</u> (" + item[8].ToString().Trim() + ") " 
                                   + "<br><u>Nội Dung</u><br>: " + item[3].ToString().Trim()
                                   + "<br><u>Địa chỉ</u>:<br> " + item[4].ToString().Trim()
                                    + "<br><u>Đơn vị quản lý</u>:<br> " + item[5].ToString().Trim()
                                    + "<br><u>Điện thoại</u>:<br> " + item[6].ToString().Trim()
                                    +"<br><u>Email</u>:<br> " + item[7].ToString().Trim()
                                   + "<hr><br><u>Hoạt động tham quan</u>:<br> " + item[2].ToString().Trim();
                                  

                    string tag = "điểm đến, diem den ";

                    newInfo.CreateDate = DateTime.Now;
                    newInfo.CreateUserID = Guid.Parse("b0b6997c-282b-4aff-b286-b0820cdb0100");
                    newInfo.ID = Guid.NewGuid();
                    newInfo.IsDeleted = 0;
                    newInfo.InfoContent = HtmlRemoval.StripTagsRegexCompiled(content);
                    newInfo.InfoContentHtml = content;
                    newInfo.InfoTag = tag;
                    newInfo.InfoTitle = item[1].ToString().Trim();
                    newInfo.InfoType = InformationType.NoLimit;
                    newInfo.Status = InformationStatus.Approved;
                    newInfo.Category = Categories.DiemDen;
                    newInfo.Location = item[8].ToString().Trim();
                    newInfo.UpdateDate = DateTime.Now;
                    newInfo.UpdateUserID = Guid.Parse("b0b6997c-282b-4aff-b286-b0820cdb0100");

                    try
                    {
                        BBLInfo b = new BBLInfo();
                        b.InsertOrUpdate(newInfo);

                        ix++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("E - > " + ex.Message);
                        // DevExpress.XtraEditors.XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, this.FindForm(), ex.Message, "Có sự cố", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        il++;
                    }
                }

                Console.WriteLine(ix + " | " + il);
            }
        }

        // Vận Chuyển
        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            if (DialogResult.OK == fdlg.ShowDialog())
            {
                var excel = new ExcelQueryFactory(fdlg.FileName);
                var indianaCompanies = from c in excel.Worksheet("Sheet1")
                                       select c;
                int ix = 0;
                int il = 0;
                foreach (var item in indianaCompanies)
                {
                    TblInfor newInfo = new TblInfor();


                    string content = "<b>" + item[1].ToString().Trim() + "</b> "
                                    + "<br><i>" + item[2].ToString().Trim() + "</i>"
                                   + "<br><u>Loại hình</u>: " + item[6].ToString().Trim()
                                   + "<br><u>Địa chỉ</u>:<br> " + item[3].ToString().Trim()
                                   + "<br><u>Điện thoại</u>:<br> " + item[4].ToString().Trim()
                                   + "<br><u>Email</u>: " + item[5].ToString().Trim();


                    string tag = "Vận chuyên, van chuyen ";

                    newInfo.CreateDate = DateTime.Now;
                    newInfo.CreateUserID = Guid.Parse("b0b6997c-282b-4aff-b286-b0820cdb0100");
                    newInfo.ID = Guid.NewGuid();
                    newInfo.IsDeleted = 0;
                    newInfo.InfoContent = HtmlRemoval.StripTagsRegexCompiled(content);
                    newInfo.InfoContentHtml = content;
                    newInfo.InfoTag = tag;
                    newInfo.InfoTitle = item[1].ToString().Trim();
                    newInfo.InfoType = InformationType.NoLimit;
                    newInfo.Status = InformationStatus.Approved;
                    newInfo.Category = Categories.VanChuyen;
                    newInfo.Location = item[7].ToString().Trim();
                    newInfo.UpdateDate = DateTime.Now;
                    newInfo.UpdateUserID = Guid.Parse("b0b6997c-282b-4aff-b286-b0820cdb0100");

                    try
                    {
                        BBLInfo b = new BBLInfo();
                        b.InsertOrUpdate(newInfo);

                        ix++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("E - > " + ex.Message);
                        // DevExpress.XtraEditors.XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, this.FindForm(), ex.Message, "Có sự cố", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        il++;
                    }
                }

                Console.WriteLine(ix + " | " + il);
            }

        }

        // HUyện
        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            if (DialogResult.OK == fdlg.ShowDialog())
            {
                var excel = new ExcelQueryFactory(fdlg.FileName);
                var indianaCompanies = from c in excel.Worksheet("Sheet1")
                                       select c;
                int ix = 0;
                int il = 0;
                foreach (var item in indianaCompanies)
                {
                    TblInfor newInfo = new TblInfor();


                    string content = "<b>" + item[1].ToString().Trim() + "</b> "
                                    + "<br><i>" + item[2].ToString().Trim() + "</i>"
                                   + "<br><u>Điện Thoại</u>: " + item[3].ToString().Trim()
                                   + "<br><u>Huyện</u>:<br> " + item[5].ToString().Trim()
                                   + "<br><u>Email</u>: " + item[4].ToString().Trim();


                    string tag = "Cơ Quan Hành Chính";

                    newInfo.CreateDate = DateTime.Now;
                    newInfo.CreateUserID = Guid.Parse("b0b6997c-282b-4aff-b286-b0820cdb0100");
                    newInfo.ID = Guid.NewGuid();
                    newInfo.IsDeleted = 0;
                    newInfo.InfoContent = HtmlRemoval.StripTagsRegexCompiled(content);
                    newInfo.InfoContentHtml = content;
                    newInfo.InfoTag = tag;
                    newInfo.InfoTitle = item[1].ToString().Trim();
                    newInfo.InfoType = InformationType.NoLimit;
                    newInfo.Status = InformationStatus.Approved;
                    newInfo.Category = Categories.CoQuan;
                    newInfo.Location = item[5].ToString().Trim();
                    newInfo.UpdateDate = DateTime.Now;
                    newInfo.UpdateUserID = Guid.Parse("b0b6997c-282b-4aff-b286-b0820cdb0100");

                    try
                    {
                        BBLInfo b = new BBLInfo();
                        b.InsertOrUpdate(newInfo);

                        ix++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("E - > " + ex.Message);
                        // DevExpress.XtraEditors.XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, this.FindForm(), ex.Message, "Có sự cố", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        il++;
                    }
                }

                Console.WriteLine(ix + " | " + il);
            }

        }

        // Ngân hàng ATM
        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            if (DialogResult.OK == fdlg.ShowDialog())
            {
                var excel = new ExcelQueryFactory(fdlg.FileName);
                var indianaCompanies = from c in excel.Worksheet("Sheet1")
                                       select c;
                int ix = 0;
                int il = 0;
                foreach (var item in indianaCompanies)
                {
                    TblInfor newInfo = new TblInfor();


                    string content = "<b>" + item[5].ToString().Trim() +" "+ item[1].ToString().Trim() + "</b> "
                                    + "<br><i>" + item[4].ToString().Trim() + "</i>"
                                  
                                   + "<br><u>Địa chỉ</u>:<br> " + item[2].ToString().Trim()
                                   + "<br><u>Điện thoại</u>: " + item[3].ToString().Trim();


                    string tag = "ATM, Ngân Hàng, Bank";

                    newInfo.CreateDate = DateTime.Now;
                    newInfo.CreateUserID = Guid.Parse("b0b6997c-282b-4aff-b286-b0820cdb0100");
                    newInfo.ID = Guid.NewGuid();
                    newInfo.IsDeleted = 0;
                    newInfo.InfoContent = HtmlRemoval.StripTagsRegexCompiled(content);
                    newInfo.InfoContentHtml = content;
                    newInfo.InfoTag = tag;
                    newInfo.InfoTitle =item[5].ToString().Trim() +" "+ item[1].ToString().Trim();
                    newInfo.InfoType = InformationType.NoLimit;
                    newInfo.Status = InformationStatus.Approved;
                    newInfo.Category = Categories.NganHang;
                    newInfo.Location = item[6].ToString().Trim();
                    newInfo.UpdateDate = DateTime.Now;
                    newInfo.UpdateUserID = Guid.Parse("b0b6997c-282b-4aff-b286-b0820cdb0100");

                    try
                    {
                        BBLInfo b = new BBLInfo();
                        b.InsertOrUpdate(newInfo);

                        ix++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("E - > " + ex.Message);
                        // DevExpress.XtraEditors.XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, this.FindForm(), ex.Message, "Có sự cố", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        il++;
                    }
                }

                Console.WriteLine(ix + " | " + il);
            }
        }
    }
}
