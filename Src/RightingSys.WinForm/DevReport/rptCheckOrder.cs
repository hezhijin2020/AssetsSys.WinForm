using System;

namespace RightingSys.WinForm.DevReport
{
    public partial class rptCheckOrder : DevExpress.XtraReports.UI.XtraReport
    {
       
        public rptCheckOrder(Models.ys_CheckOrder model)
        {
            InitializeComponent();
            InitialRptForm(model);
        }
        public void InitialRptForm(Models.ys_CheckOrder model)
        {

            #region 获取数据
            BLL.CheckOrderManager manager = new BLL.CheckOrderManager();
            System.Data.DataTable dt = manager.GetAllTable(model.Id);
            this.DataSource = dt;
            #endregion

            #region 订单信息
            this.IsAudit.Checked = model.IsAudit;
            IsAudit.Text= IsAudit.Checked == true ? "已审核" : "未审核";
            labCheckday.Text = model.Checkday.ToString();
            labCheckNo.Text = model.CheckNo;
            labDescription.Text = model.Description;
            labOperator.Text = model.OperatorName;
            labPrintTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            #endregion

            #region 订单明细
            txtName.DataBindings.Add("Text", null, "Name");
            txtBarcode.DataBindings.Add("Text", null, "Barcode");
            txtModel.DataBindings.Add("Text", null, "Model");
            txtCategory.DataBindings.Add("Text", null, "CategoryName");
            txtStatus.DataBindings.Add("Text", null, "StatusName");
            txtIsCheck.DataBindings.Add("Text", null, "IsSelect");
            txtIsCheckTime.DataBindings.Add("Text", null, "IsCheckTime");
            txtCheckUserName.DataBindings.Add("Text", null, "CheckUserName");
            #endregion
        }

    }
}
