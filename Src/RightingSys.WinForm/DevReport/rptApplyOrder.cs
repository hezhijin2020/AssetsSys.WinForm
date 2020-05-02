using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace RightingSys.WinForm.DevReport
{
    public partial class rptApplyOrder : DevExpress.XtraReports.UI.XtraReport
    {
       
        public rptApplyOrder(Guid Id)
        {
            InitializeComponent();
            InitialRptForm(Id);
        }
        public void InitialRptForm(Guid Id)
        {

            #region 获取数据
            BLL.ApplyOrderManager manager = new BLL.ApplyOrderManager();
            System.Data.DataTable dt = manager.GetTableOneById(Id);
            this.DataSource = dt;
            #endregion

            #region 订单信息
            labApplyday.Text = dt.Rows[0]["Applyday"].ToString();
            labApplyDeparment.Text = dt.Rows[0]["ApplyDepartmentName"].ToString();
            labApplyNo.Text = dt.Rows[0]["ApplyNo"].ToString();
            labApplyUser.Text = dt.Rows[0]["ApplyUserName"].ToString();
            labDescription.Text = dt.Rows[0]["ApplyDescription"].ToString();
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
