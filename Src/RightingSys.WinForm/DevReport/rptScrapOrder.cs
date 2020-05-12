using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace RightingSys.WinForm.DevReport
{
    public partial class rptScrapOrder : DevExpress.XtraReports.UI.XtraReport
    {
       
        public rptScrapOrder(string ScrapNo)
        {
            InitializeComponent();
            InitialRptForm(ScrapNo);
        }
        public void InitialRptForm(string ScrapNo)
        {

            #region 获取数据
            BLL.ScrapOrderManager manager = new BLL.ScrapOrderManager();
            System.Data.DataTable dt = manager.GetTableOneByScrapNo(ScrapNo);
            this.DataSource = dt;
            #endregion

            #region 订单信息
            labApplyday.Text = dt.Rows[0]["Scrapday"].ToString();
            labApplyNo.Text = dt.Rows[0]["ScrapNo"].ToString();
            labApplyUser.Text = dt.Rows[0]["ScrapUserName"].ToString();
            labDescription.Text = dt.Rows[0]["ScrapDescription"].ToString();
            labOperator.Text = dt.Rows[0]["OperatorName"].ToString();
            labPrintTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            #endregion

            #region 订单明细
            txtBarcode.DataBindings.Add("Text", null, "Barcode");
            txtDepartmentName.DataBindings.Add("Text", null, "DepartmentName");
            txtCategory.DataBindings.Add("Text", null, "CategoryName");
            txtModel.DataBindings.Add("Text", null, "Model");
            txtName.DataBindings.Add("Text", null, "Name");
            txtUserName.DataBindings.Add("Text", null, "UserName");
            txtStock.DataBindings.Add("Text", null, "StockName");
            txtStock.DataBindings.Add("Text", null, "Price");
            #endregion
        }

    }
}
