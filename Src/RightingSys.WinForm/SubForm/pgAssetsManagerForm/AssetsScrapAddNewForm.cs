using RightingSys.WinForm.Utils.cls;
using RightingSys.WinForm.Utils.clsEnum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace RightingSys.WinForm.SubForm.pgAssetsManagerForm
{
    public partial class AssetsScrapAddNewForm : BaseForm
    {
        #region  声明变量
        List<Models.ys_Assets> AllAssets = null;//资产控件的数据集
        List<Models.ys_Assets> selectAssets = new List<Models.ys_Assets>();//选择资产的数据集
        
        BLL.ScrapOrderManager bll = new BLL.ScrapOrderManager();//领用资产的业务类实列化
        #endregion

        public AssetsScrapAddNewForm()
        {
            InitializeComponent();
            Initial();
        }

     

        /// <summary>
        /// 窗体的及控件的初始化
        /// </summary>
        private void Initial()
        {
           //职员信息的初始化
            AppPublic.Control.InitalControlHelper.ACL_User_GridLookUpEdit(StaffID);
         
            //资产信息的初始化
            AppPublic.Control.InitalControlHelper.Assets_GridLookUpEdit(glu_FA, null, false);
            glu_FA.Properties.DataSource = AllAssets = AppPublic.Control.InitalControlHelper.GetAssetListByStatus(new AssetsStatus[] {AssetsStatus.XZ, AssetsStatus.ZY, AssetsStatus.WX });

           
            //控件数据的绑定
            gcData.DataSource = selectAssets;
            //日期控件的赋值
            bfday.DateTime = DateTime.Now;

            //仓库选择控件的初始化
            AppPublic.Control.InitalControlHelper.ys_AssetsStock_GridLookUpEdit(glu_FA_Stock);
            txtUserName.Text = clsSession._FullName;
        }

        /// <summary>
        /// 取消领用操作
        /// </summary>
        private void sbtnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }
        /// <summary>
        /// 保存领用单信息
        /// </summary>
        private void sbtnSave_Click(object sender, EventArgs e)
        {   
            //检查用户输入是否合法、部门、人员、资产信息
            if (StaffID.EditValue != null && selectAssets.Count > 0)
            {
                List<Models.ys_ScrapOrder> list = new List<Models.ys_ScrapOrder>();
                foreach(Models.ys_Assets a in selectAssets)
                {
                    var model = new Models.ys_ScrapOrder();
                    model.ScrapNo = bll.GetNewScrapNo();//生成订单号
                    model.ScrapUserId = clsPublic.GetObjGUID(StaffID.EditValue);
                    model.ScrapUserName = StaffID.Text;
                    model.OperatorId = clsSession._UserId;
                    model.OperatorName = clsSession._FullName;
                    model.ScrapDescription = txt_Desc.Text;
                    model.Scrapday = bfday.DateTime;
                    model.IsAudit = true;
                    model.AssetsId = a.Id;
                    model.IsRemoved = false;
                    model.OldStatusId = a.StatusId;
                    model.CreateTime = DateTime.Now;
                    list.Add(model);
                }
                //生成新的领用单
                if (bll.AddNew(list))
                {
                    clsPublic.ShowMessage("保存成功！", Text);
                    base.DialogResult = DialogResult.OK;
                }
                else
                {
                    clsPublic.ShowMessage("保存失败！", Text);
                }
            }
            else
            {
                clsPublic.ShowMessage("职员、或清理的资产信息不能为空！", Text);
            }
        }

        /// <summary>
        /// 添加选择的数据集记录
        /// </summary>
        private void sbtnAdd_Click(object sender, EventArgs e)
        {
            if (glu_FA.EditValue != null)
            {
                Models.ys_Assets m = AllAssets.Find(s => s.Id.Equals(glu_FA.EditValue));
                AllAssets.Remove(m);
                selectAssets.Add(m);
                glu_FA_Stock_EditValueChanged(null, null);
                glu_FA.EditValue = null;
                gcData.RefreshDataSource();
            }
        }

        /// <summary> 
        /// 删除选择的数据集记录
        /// </summary>
        private void sbtnDelete_Click(object sender, EventArgs e)
        {
            if (gvData.FocusedRowHandle>= 0)
            {
                Models.ys_Assets m = selectAssets.Find(s => s.Id.Equals(gvData.GetFocusedRowCellValue("Id")));

                selectAssets.Remove(m);
                AllAssets.Add(m);
                glu_FA_Stock_EditValueChanged(null, null);
                gcData.RefreshDataSource();
            }
        }

        /// <summary>
        /// 仓库控件选择值更改事件,处理资产控件数据
        /// </summary>
        private void glu_FA_Stock_EditValueChanged(object sender, EventArgs e)
        {
            if (glu_FA_Stock.EditValue == null)
            {
                glu_FA.Properties.DataSource = AllAssets;
                return;
            }
            glu_FA.Properties.DataSource = AllAssets.FindAll(s => s.StockId.Equals(glu_FA_Stock.EditValue));
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
    }
}
