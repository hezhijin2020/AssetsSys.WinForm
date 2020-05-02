using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace RightingSys.WinForm.DevReport
{
    public partial class rptAllotOrder : DevExpress.XtraReports.UI.XtraReport
    {
       
        public rptAllotOrder(Guid Id)
        {
            InitializeComponent();
            InitialRptForm(Id);
        }
        public void InitialRptForm(Guid Id)
        {

            #region 获取数据
            BLL.AllotOrderManager manager = new BLL.AllotOrderManager();
            System.Data.DataTable dt = manager.GetTableOneById(Id);
            this.DataSource = dt;
            #endregion

            #region 订单信息
            labApplyday.Text = dt.Rows[0]["Allotday"].ToString();
            labApplyDeparment.Text = dt.Rows[0]["AllotDepartmentName"].ToString();
            labApplyNo.Text = dt.Rows[0]["AllotNo"].ToString();
            labApplyUser.Text = dt.Rows[0]["AllotUserName"].ToString();
            labDescription.Text = dt.Rows[0]["AllotDescription"].ToString();
            labOperator.Text = dt.Rows[0]["OperatorName"].ToString();
            labPrintTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            #endregion

            #region 订单明细
            txtBarcode.DataBindings.Add("Text", null, "Barcode");
            txtDepartmentName.DataBindings.Add("Text", null, "OldDepartmentName");
            txtCategory.DataBindings.Add("Text", null, "CategoryName");
            txtModel.DataBindings.Add("Text", null, "Model");
            txtName.DataBindings.Add("Text", null, "Name");
            txtUserName.DataBindings.Add("Text", null, "OldUserName");
            txtStock.DataBindings.Add("Text", null, "StockName");
            #endregion
        }

    }
}
