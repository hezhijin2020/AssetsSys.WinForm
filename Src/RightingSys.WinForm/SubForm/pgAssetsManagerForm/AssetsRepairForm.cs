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
            gcData.DataSource = manager.GetAllTable();
            gvData.BestFitColumns();
        }

        public override void Export()
        {
           
        }
        public override void Print()
        {
           
        }

        /// <summary>
        /// 双击修改
        /// </summary>
        private void gvData_MouseDown(object sender, MouseEventArgs e)
        {
            if (!(bool)gvData.GetFocusedRowCellValue("IsFinish"))
            {
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo viewInfo = gvData.CalcHitInfo(new Point(e.X, e.Y));
                if (e.Clicks == 2 && e.Button == MouseButtons.Left)
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
        }

       /// <summary>
       /// 显示行号
       /// </summary>
        private void gvData_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        

        /// <summary>
        /// 自定义单元格样式
        /// </summary>
        private void gvData_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "IsFinish")
            {
                if (e.CellValue.Equals(true))
                {
                    e.Appearance.BackColor = Color.Green;
                }
                else
                {
                    e.Appearance.BackColor = Color.Red;
                }
            }
        }
    }
}
