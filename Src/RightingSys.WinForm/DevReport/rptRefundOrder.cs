using System;

namespace RightingSys.WinForm.DevReport
{
    public partial class rptRefundOrder : DevExpress.XtraReports.UI.XtraReport
    {
       
        public rptRefundOrder(Guid Id)
        {
            InitializeComponent();
            InitialRptForm(Id);
        }
        public void InitialRptForm(Guid Id)
        {

            #region 获取数据
            BLL.RefundOrderManager manager = new BLL.RefundOrderManager();
            System.Data.DataTable dt = manager.GetTableOneById(Id);
            this.DataSource = dt;
            #endregion

            #region 订单信息
            labApplyday.Text = dt.Rows[0]["Refundday"].ToString();
            labApplyNo.Text = dt.Rows[0]["RefundNo"].ToString();
            labApplyUser.Text = dt.Rows[0]["RefundUserName"].ToString();
            labDescription.Text = dt.Rows[0]["RefundDescription"].ToString();
            labOperator.Text = dt.Rows[0]["OperatorName"].ToString();
            labPrintTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            #endregion

            #region 订单明细
            txtBarcode.DataBindings.Add("Text", null, "Barcode");
            txtbuyday.DataBindings.Add("Text", null, "Buyday");
            txtCategory.DataBindings.Add("Text", null, "CategoryName");
            txtModel.DataBindings.Add("Text", null, "Model");
            txtName.DataBindings.Add("Text", null, "Name");
            txtPrice.DataBindings.Add("Text", null, "Price");
            txtStock.DataBindings.Add("Text", null, "StockName");

            #endregion
        }

    }
}
