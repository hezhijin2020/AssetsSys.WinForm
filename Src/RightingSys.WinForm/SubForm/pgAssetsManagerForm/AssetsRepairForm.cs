using DevExpress.XtraReports.UI;
using RightingSys.WinForm.AppPublic.Enum;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RightingSys.WinForm.SubForm.pgAssetsManagerForm
{
    public partial class AssetsRepairForm : BaseForm
    {
        BLL.RepairOrderManager  manager = new BLL.RepairOrderManager();
        public AssetsRepairForm()
        {
            InitializeComponent();
        }

        public override void InitFeatureButton()
        {
            base.SetFeatureButton(FeatureButton.Add, FeatureButton.Query,FeatureButton.Export,FeatureButton.Print);
        }

        public override void AddNew()
        {
            AssetsRepairAddNew sub = new AssetsRepairAddNew();
            if (sub.ShowDialog() == DialogResult.OK)
            {
                Query();
            }
        }

        public override void Query()
        {
            gcData.DataSource = manager.GetAllList();
            gvData.BestFitColumns();
        }

        public override void Export()
        {
           
        }

      

        public override void Print()
        {
           
        }

        private void gvData_MouseDown(object sender, MouseEventArgs e)
        {
            int R_IsFlag = AppPublic.appPublic.GetIntValue(gvData.GetFocusedRowCellValue("IsFinish"));
            if (R_IsFlag == 1)
                return;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo viewInfo = gvData.CalcHitInfo(new Point(e.X, e.Y));
            if (e.Clicks == 2&&e.Button==MouseButtons.Left)
            {
                if (viewInfo.InRow)
                {
                    Guid ID = AppPublic.appPublic.GetObjGUID(gvData.GetFocusedRowCellValue("Id"));
                    AssetsRepairFinishForm sub = new AssetsRepairFinishForm(ID);
                    if (sub.ShowDialog() == DialogResult.OK)
                    {
                        Query();
                    }
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
    }
}
