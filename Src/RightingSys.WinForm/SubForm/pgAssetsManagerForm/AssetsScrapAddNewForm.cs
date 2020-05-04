using RightingSys.WinForm.Utils.clsEnum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace RightingSys.WinForm.SubForm.pgAssetsManagerForm
{
    public partial class AssetsScrapAddNewForm : BaseForm
    {
        public AssetsScrapAddNewForm()
        {
            InitializeComponent();
            Initial();
        }

        #region  声明变量
        List<Models.ACL_User> aCL_Users = new List<Models.ACL_User>();//职员的控件的数据集
        List<Models.ys_Assets> ListAsset = null;//资产控件的数据集
        List<Models.ys_ScrapOrder> SelectListAsset = new List<Models.ys_ScrapOrder>();//选择资产的数据集

        Models.ys_ScrapOrder model = new Models.ys_ScrapOrder(); //领用资产的数据模型
        BLL.ScrapOrderManager bll = new BLL.ScrapOrderManager();//领用资产的业务类实列化
        BLL.AssetsManager assetsManager = new BLL.AssetsManager();
        #endregion

        /// <summary>
        /// 窗体的及控件的初始化
        /// </summary>
        private void Initial()
        {
           //职员信息的初始化
            AppPublic.Control.InitalControlHelper.ACL_User_GridLookUpEdit(StaffID, false);
            StaffID.Properties.DataSource = aCL_Users = AppPublic.Control.InitalControlHelper.GetAllUser();
           //部门信息的初始化
            AppPublic.Control.InitalControlHelper.ACL_Department_TreeListLookUpEdit(tl_Dept);
            //资产信息的初始化
            AppPublic.Control.InitalControlHelper.Assets_GridLookUpEdit(glu_FA, null, false);
            glu_FA.Properties.DataSource = ListAsset = AppPublic.Control.InitalControlHelper.GetAssetListByStatus(new AssetsStatus[] {AssetsStatus.XZ, AssetsStatus.ZY, AssetsStatus.WX });

           
            //控件数据的绑定
            gcData.DataSource = SelectListAsset;
            //日期控件的赋值
            bfday.DateTime = DateTime.Now;

            //仓库选择控件的初始化
            AppPublic.Control.InitalControlHelper.ys_AssetsStock_GridLookUpEdit(glu_FA_Stock);
            glu_FA_Stock.EditValue = 1;//设置默认值

            txtUserName.Text = AppPublic.appSession._FullName;
            MinID.EditValue = 1;
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
            if (tl_Dept.EditValue != null&& StaffID.EditValue != null &&MinID.EditValue!=null&& SelectListAsset.Count > 0)
            {
                model.ScrapNo = bll.GetNewScrapNo();//生成订单号
                model.ScrapUserId = AppPublic.appPublic.GetObjGUID(StaffID.EditValue);
                model.ScrapUserName = StaffID.Text;
                model.OperatorId = AppPublic.appSession._UserId;
                model.ScrapDescription = txt_Desc.Text;
                model.Scrapday = bfday.DateTime;
                model.IsAudit = true;

                //生成新的领用单
                if (bll.AddNew(SelectListAsset))
                {
                    AppPublic.appPublic.ShowMessage("保存成功！", Text);
                    base.DialogResult = DialogResult.OK;
                }
                else {
                    AppPublic.appPublic.ShowMessage("保存失败！", Text);
                }
            }
            else
            {
                AppPublic.appPublic.ShowMessage("部门、职员、或领用的资产信息不能为空！", Text);
            }
        }
        /// <summary>
        /// 添加选择的数据集记录
        /// </summary>
        private void sbtnAdd_Click(object sender, EventArgs e)
        {
            if (glu_FA.EditValue != null)
            {
                Models.ys_Assets m = ListAsset.Find(s => s.Id.Equals(glu_FA.EditValue));
                ListAsset.Remove(m);

                Models.ys_ScrapOrder smodel = new Models.ys_ScrapOrder();
                smodel.AssetsModel = m;
                SelectListAsset.Add(smodel);
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
                Models.ys_ScrapOrder m = SelectListAsset.Find(s => s.Id.Equals(gvData.GetFocusedRowCellValue("Id")));
                SelectListAsset.Remove(m);
                Models.ys_Assets amodel = assetsManager.GetOneById(model.AssetsId);
                ListAsset.Add(amodel);
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
                glu_FA.Properties.DataSource = ListAsset;
                return;
            }
            glu_FA.Properties.DataSource = ListAsset.FindAll(s => s.StockId.Equals(glu_FA_Stock.EditValue));
        }

        /// <summary>
        /// 部门控件选择值更改事件,处理职员控件数据
        /// </summary>
        private void tl_Dept_EditValueChanged(object sender, EventArgs e)
        {
            //if (tl_Dept.EditValue == null)
            //{
            //    dvStaff.RowFilter = string.Format("DeptID='{0}'", Guid.Empty);
            //    return;
            //}
            //Guid ID = (Guid)tl_Dept.EditValue;
            //dvStaff.RowFilter = string.Format("DeptID ='{0}'", ID);
            //StaffID.Properties.DataSource = dvStaff;
        }
    }
}
