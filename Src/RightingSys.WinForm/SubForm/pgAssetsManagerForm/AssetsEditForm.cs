using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Xml;
using System.Windows.Forms;

namespace RightingSys.WinForm.SubForm.pgAssetsManagerForm
{
    public partial class AssetsEditForm : BaseForm
    {
        #region 声明变量和实列化对象
        bool IsAddNew = false;
        DataTable dtXmlInf = null;
        BLL.AssetsManager assetsManager = new BLL.AssetsManager();
        Models.ys_Assets model = new Models.ys_Assets();

       
        private List<Models.ACL_User> UserList;
        #endregion

        #region 构造函数
        public AssetsEditForm()
        {
            InitializeComponent();
            IsAddNew = true;
            InitialForm();
        }

        public AssetsEditForm(Models.ys_Assets smodel) : this()
        {
            model = smodel;
            IsAddNew = false;
            groupUserInfo.Enabled = false;
            d_Buytime.Enabled = false;
            txtPrice.ReadOnly = true;

            txt_FA_Name.Text = model.Name;
            cbtlCategory.EditValue = model.CategoryId;
            txt_Barcode.Text = model.Barcode;
            cbCompany.EditValue = model.CompanyId;
            d_Buytime.DateTime = model.Buyday;
            txt_FA_Model.Text = model.Model;
            cbStock.EditValue = model.StockId;
            txtPrice.EditValue = model.Price;
            cblocation.Text = model.Location;
            txt_FA_Desc.Text = model.Description;
            setXmlInf(model.XmlInf);
        }

        #endregion

        #region 生成领用单

        public void AddLyOrder()
        {
            Models.ys_ApplyOrder lyModel = new Models.ys_ApplyOrder();
            BLL.ApplyOrderManager applyOrderManager = new BLL.ApplyOrderManager();
            if (cbtlDepartment.EditValue != null || cbtlDepartment.EditValue != null)
            {
                lyModel.ApplyNo = applyOrderManager.GetNewApplyNo();//生成订单号
                lyModel.Id = Guid.NewGuid();
                lyModel.Location = cblocation.Text;

                lyModel.ApplyUserId = Utils.cls.clsPublic.GetObjGUID(cbUser.EditValue);
                lyModel.ApplyUserName = cbUser.Text;

                if (cbtlDepartment.EditValue == null)
                {
                    lyModel.ApplyDepartmentId = Utils.cls.clsPublic.GetObjGUID(cbUser.Properties.View.GetFocusedRowCellValue("DepartmentId"));
                }
                else
                {
                    lyModel.ApplyDepartmentId = Utils.cls.clsPublic.GetObjGUID(cbtlDepartment.EditValue);
                }

                lyModel.OperatorId = AppPublic.appSession._UserId;
                lyModel.OperatorName = AppPublic.appSession._FullName;
                lyModel.Description = "登记时生成";
                lyModel.Applyday = DateTime.Now;

                List<Models.ys_ApplyOrderDetail> details = new List<Models.ys_ApplyOrderDetail>();

                Models.ys_ApplyOrderDetail d = new Models.ys_ApplyOrderDetail();
                model = assetsManager.GetOneById(model.Id);
                d.AssetsId = model.Id;
                d.ApplyId = lyModel.Id;
                d.OldStatusId = model.StatusId;
                details.Add(d);

                lyModel.Detail = details ;
                //生成新的领用单
                if (applyOrderManager.AddNew(lyModel))
                {
                    AppPublic.appPublic.ShowMessage("领用单生成成功！", Text);
                }
                else
                {
                    AppPublic.appPublic.ShowMessage("领用单生成失败！", Text);
                }
            }
        }
        #endregion

        #region sbtn 增 删 改 保 添加、删除、清空方法
        private void sbtn_Colse_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sbtn_Add_Click(object sender, EventArgs e)
        {
            if (cb_FieldName.Text.Trim() != "" || txt_FieldValue.Text.Trim() != "")
            {
                dtXmlInf.Rows.Add(cb_FieldName.Text, txt_FieldValue.Text);
            }
            else
            {
                MessageBox.Show("字段名和字段值不能为空！", "提示");
            }
        }

        private void sbtn_Del_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否删该字段信息？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                gvXmlInfo.DeleteRow(gvXmlInfo.FocusedRowHandle);
            }
        }

        private void sbtnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否清空所有字段信息？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dtXmlInf.Clear();
            }
        }

       
        private void sbtn_Save_Click(object sender, EventArgs e)
        {

            if (ValiDate())
            {
                if (IsAddNew)
                {
                    model.Id = Guid.NewGuid();
                    if (assetsManager.AddNew(model))
                    {
                        base.DialogResult = DialogResult.OK;
                        AppPublic.appPublic.ShowMessage("保存成功", Text);
                        AddLyOrder();
                    }
                    else
                    {
                        AppPublic.appPublic.ShowMessage("失败", Text);
                    }
                }
                else
                {
                    if (assetsManager.Modify(model))
                    {
                        base.DialogResult = DialogResult.OK;
                        AppPublic.appPublic.ShowMessage("成功", Text);
                    }
                    else
                    {
                        AppPublic.appPublic.ShowMessage("失败", Text);
                    }

                }
            }
        }

        #endregion

        #region 获取和设置资产的扩展信息
        private string getXmlInf()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("root");

            XmlElement row = doc.CreateElement("row");
            string sFieldName = ""; string sFieldValue = "";
            if (dtXmlInf.Rows.Count > 0)
            {
                foreach (DataRow r in dtXmlInf.Rows)
                {
                    sFieldName = AppPublic.appPublic.GetObjectString(r["FieldName"]);
                    sFieldValue = AppPublic.appPublic.GetObjectString(r["FieldValue"]);
                    if (sFieldName != "" && sFieldValue != "")
                    {
                        row.SetAttribute(sFieldName, sFieldValue);
                    }
                }
                root.AppendChild(row);
                doc.AppendChild(root);
                return doc.InnerXml;
            }
            else
            {
                return "";
            }
        }
        private void setXmlInf(string XmlInf)
        {
            if (XmlInf == "")
            {
                return;
            }
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(XmlInf);
            XmlNodeList row = doc.GetElementsByTagName("row");
            string sFieldName = ""; string sFieldValue = "";
            dtXmlInf.Clear();
            foreach (XmlAttribute at in row[0].Attributes)
            {
                sFieldName = at.Name;
                sFieldValue = at.Value;
                dtXmlInf.Rows.Add(sFieldName, sFieldValue);
            }
        }
        #endregion

        #region 用户输入验证和 窗体出初化
        private bool ValiDate()
        {
            if (txt_FA_Name.Text.Trim() != "" && cbtlCategory.EditValue != null && txt_FA_Model.Text.Trim() != "")
            {
                model.OperatorId = AppPublic.appSession._UserId;
                model.OperatorName = AppPublic.appSession._FullName;
                model.CreateTime = model.Buyday = d_Buytime.DateTime;
                model.DepartmentId = AppPublic.appPublic.GetObjGUID(cbtlDepartment);
                model.Description = txt_FA_Desc.Text;
                model.Location = cblocation.Text;
                model.Model = txt_FA_Model.Text;
                model.Name = txt_FA_Name.Text;
                model.Price = AppPublic.appPublic.ToDecimal(txtPrice.Text);
                model.UserId = AppPublic.appPublic.GetObjGUID(cbUser.EditValue);
                model.StockId = AppPublic.appPublic.GetObjGUID(cbStock.EditValue);
                model.CompanyId = AppPublic.appPublic.GetObjGUID(cbCompany.EditValue);
                model.CategoryId = AppPublic.appPublic.GetObjGUID(cbtlCategory.EditValue);
                model.Barcode=  txt_Barcode.Text == "" ? assetsManager.GetNewBarcode() : txt_Barcode.Text;
                if (txt_Barcode.Text == "")
                {
                    model.StatusId = model.DepartmentId == Guid.Empty ? "XZ" : "ZY";
                }
               
                model.XmlInf =getXmlInf();
                return true;
            }
            else
            {
                AppPublic.appPublic.ShowMessage("信息输入不全", Text);
                return false;
            }
        }
        private void InitialForm()
        {
            d_Buytime.DateTime = dLyDay.DateTime = DateTime.Now;
            AppPublic.Control.InitalControlHelper.ACL_User_GridLookUpEdit (cbUser, false);
            cbUser.Properties.DataSource = UserList = AppPublic.Control.InitalControlHelper.GetAllUser();

            AppPublic.Control.InitalControlHelper.ACL_Department_TreeListLookUpEdit(cbtlDepartment);
            
            AppPublic.Control.InitalControlHelper.ys_AssetsStock_GridLookUpEdit(cbStock);
            AppPublic.Control.InitalControlHelper.ys_AssetsCategory_TreeListLookUpEdit(cbtlCategory);
            AppPublic.Control.InitalControlHelper.ys_Company_GridLookUpEdit(cbCompany);
            dtXmlInf = new DataTable();
            dtXmlInf.Columns.AddRange(new DataColumn[] {
                new DataColumn("FieldName",typeof(string)),
                new DataColumn("FieldValue",typeof(string))});
            gcXmlInf.DataSource = dtXmlInf;

            dtXmlInf.Rows.Add("CPU", "");
            dtXmlInf.Rows.Add("内存", "");
            dtXmlInf.Rows.Add("固态硬盘", "");
            dtXmlInf.Rows.Add("机械硬盘", "");
            dtXmlInf.Rows.Add("显示器", "");

            dtXmlInf.Rows.Add("IP地址", "");
            dtXmlInf.Rows.Add("服务代码", "");
            dtXmlInf.Rows.Add("序列号", "");
            dtXmlInf.Rows.Add("服务电话", "");
            dtXmlInf.Rows.Add("保修期限", "");
            dtXmlInf.Rows.Add("用户名", "");
            dtXmlInf.Rows.Add("密码", "");
            dtXmlInf.Rows.Add("管理WEB", "");
            dtXmlInf.Rows.Add("WEB用户", "");
            dtXmlInf.Rows.Add("WEB密码", "");
            dtXmlInf.Rows.Add("MAC地址", "");
        }

        #endregion

        #region  部门和员工联动
        private void cbtlDepartmentt_EditValueChanged(object sender, EventArgs e)
        {
            if (cbtlDepartment.EditValue == null)
            {
                cbUser.Properties.DataSource = UserList;
            }
            else
            {
                Guid Id = (Guid)cbtlDepartment.EditValue;
                cbUser.Properties.DataSource = UserList.FindAll(a => a.DepartmentId == Id);
            }
        }
        #endregion

    }
}
