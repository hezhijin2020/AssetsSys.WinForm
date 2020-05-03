
using RightingSys.WinForm.AppPublic.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RightingSys.WinForm.SubForm.pgAssetsManagerForm
{
    public partial class AssetsForm : BaseForm
    {

        #region 声明变量和实列化
        BLL.AssetsManager assetsManager = new BLL.AssetsManager();
        BLL.AssetsCategoryManager categoryManager = new BLL.AssetsCategoryManager();
        List<Models.ys_Assets> AllAssets = new List<Models.ys_Assets>();
        #endregion

        public AssetsForm()
        {
            InitializeComponent(); Query();
        }
        /// <summary>
        /// 功能方法初始化
        /// </summary>
        public override void InitFeatureButton()
        {
            base.SetFeatureButton(new FeatureButton[] { FeatureButton.Add, FeatureButton.Delete,FeatureButton.Modify, FeatureButton.Query });
        }

        /// <summary>
        /// 新增资产信息
        /// </summary>
        public override void AddNew()
        {
            AssetsEditForm sub = new AssetsEditForm();
            sub.ShowDialog();
            Query();
        }

        /// <summary>
        /// 删除资产信息
        /// </summary>
        public override void Delete()
        {
            object obID = gvData.GetFocusedRowCellValue("Id");
            if (obID != null && gvData.GetFocusedRowCellValue("StatusName").ToString() == "闲置")
            {
                if (assetsManager.Delete(AppPublic.appPublic.GetObjGUID(obID)))
                {
                    Query();
                    AppPublic.appPublic.ShowMessage("成功", Text);
                }
            }
        }

        /// <summary>
        /// 修改产资信息
        /// </summary>
        public override void Modify()
        {
            object objId = gvData.GetFocusedRowCellValue("Id");
            if (objId != null && gvData.GetFocusedRowCellValue("StatusName").ToString() != "报废" && gvData.GetFocusedRowCellValue("StatusName").ToString() != "删除")
            {
                Models.ys_Assets model= AllAssets.FirstOrDefault(a => a.Id == (Guid)objId);
                AssetsEditForm sub = new AssetsEditForm(model);
                if (sub.ShowDialog() == DialogResult.OK)
                {
                    Query();
                }
            }
        }

        /// <summary>
        /// 查询资产信息
        /// </summary>
        public override void Query()
        {
            #region 类型树
            tlAssetsCategory.DataSource = categoryManager.GetAllList();
            tlAssetsCategory.ExpandAll();
            #endregion

            #region 查询所以有资产信息
            gcData.DataSource = AllAssets= assetsManager.GetAllList();
            gvData.BestFitColumns();
            #endregion
        }

        #region 类型树筛选资产
      
        /// <summary>
        ///跟据所选的类别筛选资产信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlAssetsCategory_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
               gcData.DataSource =AllAssets.Where(a=>a.CategoryId==(Guid)e.Node.GetValue("Id"));
            }
        }
        #endregion


        /// <summary>
        /// 显示行号
        /// </summary>
        private void gvData_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                e.Info.DisplayText = Convert.ToString(e.RowHandle + 1);
            }
        }

        /// <summary>
        /// 双击修改资产信息
        /// </summary>
        private void gvData_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = gvData.CalcHitInfo(new Point(e.X, e.Y));
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                //判断光标是否在行范围内 
                if (hInfo.InRow)
                {
                    Modify();
                }
            }
        }

        /// <summary>
        ///  根据状态自定义样试
        /// </summary>
        private void gvData_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if(e.Column.FieldName== "StatusName")
            {
              
                switch (e.CellValue)
                {
                    case "闲置":
                        e.Appearance.BackColor = Color.Gray;
                        break;
                    case "在用":
                        e.Appearance.BackColor =Color.Green;
                        break;
                    case "借用":
                        e.Appearance.BackColor = Color.Orange;
                        break;
                    case "维修":
                        e.Appearance.BackColor = Color.Red;
                        break;
                    case "报废":
                        e.Appearance.BackColor =Color.SeaGreen ;
                        break;
                    default:
                        break;
                }
               

            }
        }
    }
}
