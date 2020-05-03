using System;

namespace RightingSys.WinForm.DevReport
{
    public partial class rptRepairOrder : DevExpress.XtraReports.UI.XtraReport
    {
       
        public rptRepairOrder(string RepairNo)
        {
            InitializeComponent();
            InitialRptForm(RepairNo);
        }
        public void InitialRptForm(string RepairNo)
        {

            #region 获取数据
            BLL.RepairOrderManager manager = new BLL.RepairOrderManager();
            System.Data.DataTable dt = manager.GetTableOneByRepairNo(RepairNo);
            this.DataSource = dt;
            #endregion

            #region 订单信息
            labApplyday.Text = dt.Rows[0]["Repairday"].ToString();
            labApplyNo.Text = dt.Rows[0]["RepairNo"].ToString();
            labApplyUser.Text = dt.Rows[0]["RepairUserName"].ToString();
            labDescription.Text = dt.Rows[0]["RepairDescription"].ToString();
            labOperator.Text = dt.Rows[0]["OperatorName"].ToString();
            labPrintTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            #endregion

            #region 订单明细
            txtModel.DataBindings.Add("Text", null, "Model");
            txtRepairDesc.DataBindings.Add("Text", null, "RepairDescription");
            txtRepairCompany.DataBindings.Add("Text", null, "RepairCompanyName");
            txtRepairReason.DataBindings.Add("Text", null, "RepairReason");
            txtName.DataBindings.Add("Text", null, "Name");
            txtRepairPrice.DataBindings.Add("Text", null, "RepairPrice");
            txtIsFinish.DataBindings.Add("Text", null, "StatusName");
         
            #endregion
        }

    }
}
