using DevExpress.XtraTreeList.Nodes;
using RightingSys.WinForm.Utils.cls;
using RightingSys.WinForm.Utils.clsEnum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RightingSys.WinForm.SubForm.pgAssetsManagerForm.pgBaseForm
{
    public partial class CompanyForm : BaseForm
    {
        
        BLL.CompanyManager companyManager = new BLL.CompanyManager();
        List<Models.ys_Company> dbList = new List<Models.ys_Company>();
        private Models.ys_Company model = new Models.ys_Company();
        public CompanyForm()
        {
            InitializeComponent();Query();
        }

        public override void InitFeatureButton()
        {
            base.SetFeatureButton(new FeatureButton[] { FeatureButton.Add, FeatureButton.Delete, FeatureButton.Query });
        }
        public override void AddNew()
        {
            txtID.Text = "新ID";
            txtFullName.Text
                = txtPersonName.Text
                =txtAddress.Text
                =txtRemark.Text
                =txtTell.Text = "";
        }
        public override void Delete()
        {
            if (gvData.FocusedRowHandle >= 0)
            {
                Guid Id = (Guid)gvData.GetFocusedRowCellValue("Id");
                if (companyManager.ExistsAssetsById(Id))
                {
                    clsPublic.ShowMessage("仓库已被引用不能删数！", Text);return;
                }
                if (clsPublic.GetMessageBoxYesNoResult("是否删除，删除将不能恢复？", Text))
                {
                    if (companyManager.Delete(Id))
                    {
                        Query();
                        clsPublic.ShowMessage("删除成功！！", Text);
                    }
                    else
                    {
                        clsPublic.ShowMessage("删除失败！！", Text);
                    }
                }
            }
        }
        public override void Query()
        {
           gcData.DataSource =dbList= companyManager.GetAllList();
        }
        private void sbtnSave_Click(object sender, EventArgs e)
        {
            if (txtFullName.Text.Trim() == "" || txtPersonName.Text.Trim() == null || txtTell.Text.Trim() == "")
            {
                clsPublic.ShowMessage("名称、联系人、电话不能为空", Text);
                return;
            }
            model.Address = txtAddress.Text;
            model.CompanyName = txtFullName.Text;
            model.Description = txtRemark.Text;
            model.Tell = txtTell.Text;
            model.Contact = txtPersonName.Text;

            if (txtID.Text== "新ID")
            {
                txtID.EditValue = model.Id = Guid.NewGuid();
                if(companyManager.AddNew(model))
                {
                    clsPublic.ShowMessage("新增成功", Text);
                    Query();
                }
            }
            else
            {
                if (companyManager.Modify(model))
                {
                    clsPublic.ShowMessage("修改成功", Text);
                    Query();
                }
            }
        }
        private void gvData_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        private void gvData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            if (gvData.FocusedRowHandle >= 0)
            {
                Guid Id = (Guid)gvData.GetFocusedRowCellValue("Id");
                model = dbList.FirstOrDefault(m => m.Id ==Id );
                txtID.EditValue = model.Id;
                txtAddress.Text = model.Address;
                txtFullName.Text = model.CompanyName;
                txtPersonName.Text = model.Contact;
                txtRemark.Text = model.Description;
                txtTell.Text = model.Tell;
            }
        }
    }
}
