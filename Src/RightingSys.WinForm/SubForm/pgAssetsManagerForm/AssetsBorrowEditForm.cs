﻿using RightingSys.WinForm.Utils.cls;
using RightingSys.WinForm.Utils.clsEnum;
using RightingSys.WinForm.Utils.ToolForm;
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
    public partial class AssetsBorrowEditForm : BaseForm
    {
        public AssetsBorrowEditForm()
        {
            InitializeComponent();
            Initial();
        }

        #region  声明变量
        List<Models.ACL_User> userList;
        List<Models.ys_Assets> assetsList;
        List<Models.ys_Assets> selectList;
        Models.ys_BorrowOrder model = new Models.ys_BorrowOrder();
        BLL.BorrowOrderManager manager = new BLL.BorrowOrderManager();

        #endregion

        /// <summary>
        /// 窗体的及控件的初始化
        /// </summary>
        private void Initial()
        {
            //职员信息的初始化
            AppPublic.Control.InitalControlHelper.ACL_User_GridLookUpEdit(cbUser, false);
            cbUser.Properties.DataSource = userList = AppPublic.Control.InitalControlHelper.GetAllUser();
            //资产信息的初始化
            AppPublic.Control.InitalControlHelper.Assets_GridLookUpEdit(cbAssets, new AssetsStatus[] { AssetsStatus.XZ,AssetsStatus.ZY },false);
            assetsList = AppPublic.Control.InitalControlHelper.GetAssetListByStatus(new AssetsStatus[] { AssetsStatus.XZ, AssetsStatus.ZY });
            //控件数据的绑定
            gcData.DataSource =selectList=new List<Models.ys_Assets>();
            //日期控件的赋值
            tPlenday.DateTime= tBorrowday.DateTime = DateTime.Now;
            //仓库选择控件的初始化
            AppPublic.Control.InitalControlHelper.ys_AssetsStock_GridLookUpEdit(cbStock);
            cbStock.EditValue = "6494f577-cc6f-464e-bf9a-a2c684013cce";//设置默认值
            cbStock.Enabled = false;
            tEditUser.Text = clsSession._FullName;
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
            if (cbUser.EditValue != null &&selectList.Count > 0)
            {
                model.Id = Guid.NewGuid();
                model.BorrowNo = manager.GetNewBorrowNo();
                model.BorrowUserId = clsPublic.GetObjGUID(cbUser.EditValue);
                model.BorrowUserName = cbUser.Text;
                model.BorrowDepartmentId = userList.FirstOrDefault(a => a.Id == model.BorrowUserId).DepartmentId;
                model.OperatorId = clsSession._UserId;
                model.OperatorName = clsSession._FullName;
                model.Description = tDescription.Text;
                model.Borrowday = tBorrowday.DateTime;
                model.Planday = tPlenday.DateTime;
                model.Detail = new List<Models.ys_BorrowOrderDetail>();
                //循环获取资产数据集
                foreach (Models.ys_Assets m in selectList)
                {
                    Models.ys_BorrowOrderDetail d = new Models.ys_BorrowOrderDetail();
                    d.AssetsId = m.Id;
                    d.BorrowId = model.Id;
                    d.OldDepartmentId = m.DepartmentId;
                    d.OldDepartmentName = m.DepartmentName==null?"":m.DepartmentName;
                    d.OldLocation = m.Location;
                    d.OldStatusId = m.StatusId;
                    d.OldStatusName = m.StatusName;
                    d.OldUserId = m.UserId;
                    d.OldUserName = m.UserName == null ? "" : m.UserName;
                    d.Id = Guid.NewGuid();
                    model.Detail.Add(d);
                }
                //生成新的领用单
                if (manager.AddNew(model))
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
                clsPublic.ShowMessage("借用人员、或借用的资产信息不能为空！", Text);
            }
        }
        /// <summary>
        /// 添加选择的数据集记录
        /// </summary>
        private void sbtnAdd_Click(object sender, EventArgs e)
        {
            if (cbAssets.EditValue != null)
            {
                Models.ys_Assets m = assetsList.FirstOrDefault(a => a.Id.Equals(cbAssets.EditValue));
                assetsList.Remove(m);
                selectList.Add(m);
                cbStock_EditValueChanged(null, null);
                cbAssets.EditValue = null;
                gcData.RefreshDataSource();
            }
        }
        /// <summary>
        /// 删除选择的数据集记录
        /// </summary>
        private void sbtnDelete_Click(object sender, EventArgs e)
        {
            if (gvData.FocusedRowHandle >= 0)
            {
                Models.ys_Assets m=selectList.FirstOrDefault(s => s.Id.Equals(gvData.GetFocusedRowCellValue("Id")));
                assetsList.Add(m);
                selectList.Remove(m);
                cbStock_EditValueChanged(null, null);
                gcData.RefreshDataSource();
            }
        }
       
        /// <summary>
        ///用户指纹识别
        /// </summary>
        private void cbUser_Click(object sender, EventArgs e)
        {
            UserFingerMatching sub = new UserFingerMatching();

            if (sub.ShowDialog() == DialogResult.OK)
            {
                cbUser.EditValue = sub.FingerUserId;
                cbUser.Properties.DataSource = userList;
                sbtnSave.Focus();
            }
        }

        /// <summary>
        /// 仓库控件选择值更改事件,处理资产控件数据
        /// </summary>
        private void cbStock_EditValueChanged(object sender, EventArgs e)
        {
            if (cbStock.EditValue == null)
            {
                cbAssets.Properties.DataSource = assetsList;
                return;
            }
            cbAssets.Properties.DataSource = assetsList.FindAll(a => a.StockId.ToString().ToUpper().Equals("6494f577-cc6f-464e-bf9a-a2c684013cce".ToUpper()));
        }

    }
}
