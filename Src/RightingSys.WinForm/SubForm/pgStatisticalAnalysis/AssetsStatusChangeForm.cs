

using RightingSys.WinForm.Utils.clsEnum;

namespace RightingSys.WinForm.SubForm.pgStatisticalAnalysis
{
    public partial class AssetsStatusChangeForm : BaseForm
    {
        BLL.StatusChangeManager manager = new BLL.StatusChangeManager();

        public AssetsStatusChangeForm()
        {
            InitializeComponent();
            AppPublic.Control.InitalControlHelper.Assets_GridLookUpEdit(cbAssets);
        }

        public override void InitFeatureButton()
        {
            base.SetFeatureButton( FeatureButton.Query,FeatureButton.Export,FeatureButton.Preview);
        }


        public override void Query()
        {
            string where = "";

            if (cbAssets.EditValue != null&&cbAssets.EditValue.ToString()!="")
            {
                where = " where a.AssetsId='" + cbAssets.EditValue + "' ";
                if (dStartTime.EditValue != null)
                {
                    where = where + " and a.CreateTime>'" + dStartTime.DateTime.Date + "' ";
                    if (dEndTime.EditValue != null)
                    {
                        where = where + " and a.CreateTime<='" + dEndTime.DateTime.Date + "' ";
                    }
                }
                else
                {
                   // where = where + " and a.CreateTime>'" + dStartTime.DateTime.Date + "' ";
                    if (dEndTime.EditValue != null)
                    {
                        where = where + " and a.CreateTime<='" + dEndTime.DateTime.Date + "' ";
                    }
                }
            }
            else
            {
                if (dStartTime.EditValue != null)
                {
                    where = where + " where a.CreateTime>'" + dStartTime.DateTime.Date + "' ";
                    if (dEndTime.EditValue != null)
                    {
                        where = where + " and a.CreateTime<='" + dEndTime.DateTime.Date + "' ";
                    }
                }
                else
                {
                    if (dEndTime.EditValue != null)
                    {
                        where = where + "where  a.CreateTime<='" + dEndTime.DateTime.Date + "' ";
                    }
                }
            }
            
            gcData.DataSource = manager.GetTableList(where);
        }

        /// <summary>
        /// 显示行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvData_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
    }
}
