using DevExpress.XtraTreeList.Nodes;
using RightingSys.WinForm.Utils.cls;
using RightingSys.WinForm.Utils.clsEnum;
using System;
using System.Collections.Generic;

namespace RightingSys.WinForm.SubForm.pgAssetsManagerForm.pgBaseForm
{
    public partial class AssetsCategoryForm : BaseForm
    {
        BLL.AssetsCategoryManager categoryManager = new BLL.AssetsCategoryManager();
         List<Models.ys_AssetsCategory> dbList = new List<Models.ys_AssetsCategory>();
         Models.ys_AssetsCategory model = new Models.ys_AssetsCategory();
        private bool IsAddNew = false;
        public AssetsCategoryForm()
        {
            InitializeComponent();
        }
        public override void InitFeatureButton()
        {
            base.SetFeatureButton(new FeatureButton[] { FeatureButton.Add, FeatureButton.Delete, FeatureButton.Query });
        }
        public override void AddNew()
        {
            IsAddNew = true;
            tlParentID.EditValue = null;
            txtFullName.Text = txtSimpleCode.Text = txtSortCode.Text = "";
            model = new Models.ys_AssetsCategory();
            model.Id = Guid.NewGuid();
        }
        public override void Delete()
        {
            TreeListNode node = tlType.FocusedNode;
            if (node != null)
            {
                if (node.Nodes.Count > 0)
                {
                    clsPublic.ShowMessage("该功能下面有子类别，不能删除！", Text);
                }
                else
                {
                    Guid Id = (Guid)node.GetValue("Id");
                    if (categoryManager.ExistsAssetsById(Id))
                    {
                        clsPublic.ShowMessage("该类别已被引用不能删除！！", Text);
                        return;
                    }
                    
                    if (clsPublic.GetMessageBoxYesNoResult("是否删除该类别，删除将不能恢复？", Text))
                    {
                        if (categoryManager.Delete(Id))
                        {
                            Query();
                            clsPublic.ShowMessage("删除成功！！", Text);
                        }
                        else
                        {
                            clsPublic.ShowMessage("删除失败！！", Text);
                        }
                    }
                }
            }
        }
        public override void Query()
        {
            tlType.DataSource = tlParentID.Properties.DataSource = dbList = categoryManager.GetAllList();
            tlType.ExpandAll();
        }
        private void sbtnSave_Click(object sender, EventArgs e)
        {
            if (txtFullName.Text.Trim() == "" || tlParentID.EditValue == null)
            {
                clsPublic.ShowMessage("名称和上级不能为空", Text);
                return;
            }
            model.ParentId = tlParentID.EditValue == null ? Guid.Empty : (Guid)tlParentID.EditValue;
            model.CategoryName = txtFullName.Text.Trim();
            model.SimpleCode = txtSimpleCode.Text.Trim().ToUpper();
            model.SortCode = txtSortCode.Text.Trim();
          

            if (model.Id == model.ParentId)
            {
                clsPublic.ShowMessage("节点的父节点不能为当前节点！", Text);
                return;
            }
            if (IsAddNew && categoryManager.AddNew(model))
            {
                clsPublic.ShowMessage("新增成功", Text);
                Query();
            }
            else
            {
                if (categoryManager.Modify(model))
                {
                    clsPublic.ShowMessage("修改成功", Text);
                    Query();
                }
            }
        }

        private void FA_TypeSetup_Load(object sender, EventArgs e)
        {
            Query();
        }

        private void tlType_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            TreeListNode node = tlType.FocusedNode;
            if (node != null)
            {
                if (node.ParentNode == null)
                {
                    return;
                }
                IsAddNew = false;
                Guid Id = (Guid)node.GetValue("Id");
                model = dbList.Find(s => s.Id == Id);
                tlParentID.EditValue = model.ParentId;
                txtFullName.Text = model.CategoryName;
                txtSimpleCode.Text = model.SimpleCode;
                txtSortCode.Text = model.SortCode;
            }

        }
       
    }
}
