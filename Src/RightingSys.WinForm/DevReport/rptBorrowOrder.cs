using System;

namespace RightingSys.WinForm.DevReport
{
    public partial class rptBorrowOrder : DevExpress.XtraReports.UI.XtraReport
    {
       
        public rptBorrowOrder(Guid Id)
        {
            InitializeComponent();
            InitialRptForm(Id);
        }
        public void InitialRptForm(Guid Id)
        {

            #region 获取数据
            BLL.BorrowOrderManager manager = new BLL.BorrowOrderManager();
            System.Data.DataTable dt = manager.GetTableOneById(Id);
            this.DataSource = dt;
            #endregion

            #region 订单信息
            labApplyday.Text = dt.Rows[0]["Borrowday"].ToString();
            labApplyNo.Text = dt.Rows[0]["BorrowNo"].ToString();
            labApplyUser.Text = dt.Rows[0]["BorrowUserName"].ToString();
            labDescription.Text = dt.Rows[0]["BorrowDescription"].ToString();
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
