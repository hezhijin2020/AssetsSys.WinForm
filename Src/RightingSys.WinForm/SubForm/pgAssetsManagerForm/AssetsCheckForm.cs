using RightingSys.WinForm.AppPublic.Enum;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;

namespace RightingSys.WinForm.SubForm.pgAssetsManagerForm
{
    public partial class AssetsCheckForm : BaseForm
    {
        Models.ys_CheckOrder model = new Models.ys_CheckOrder();
        BLL.CheckOrderManager manager = new BLL.CheckOrderManager();
        List<Models.ys_CheckOrder> allList = new List<Models.ys_CheckOrder>();

        public AssetsCheckForm()
        {
            InitializeComponent();
            Checkday.EditValue = DateTime.Now;
            txtOperatorName.Text = AppPublic.appSession._FullName;
            Query();

        }

        /// <summary>
        /// 功能初始化
        /// </summary>
        public override void InitFeatureButton()
        {
            base.SetFeatureButton(FeatureButton.Add,FeatureButton.Query,FeatureButton.Save,FeatureButton.Delete);
        }

        /// <summary>
        /// 查询方法
        /// </summary>
        public override void Query()
        {
            gcData.DataSource = allList = manager.GetAllList();
        }
        /// <summary>
        /// 保存方法 
        /// </summary>
        public override void Save()
        {
            if (txtCheckNo.Text == "")
            {
                MessageBox.Show("没有要保存的数据");return;
            }
            if (model.Id == Guid.Empty)
            {
                model.Id = Guid.NewGuid();
                model.CheckNo = manager.GetNewCheckNo();
                model.Checkday = Checkday.DateTime;
                model.Description = txtDescription.Text;
                model.OperatorId = AppPublic.appSession._UserId;
                model.OperatorName = AppPublic.appSession._FullName;
                model.IsAudit = false;
                model.IsAuditday = DateTime.Parse("2020-01-01");
                if (manager.AddNew(model))
                {
                    MessageBox.Show("成功");
                }
                else
                {
                    MessageBox.Show("失败");
                }
            }
            else
            {
                if (model.IsAudit)
                {
                    MessageBox.Show("盘点单已审核不能更改");return;
                }
                model.Checkday = Checkday.DateTime;
                model.Description = txtDescription.Text;
                model.OperatorId = AppPublic.appSession._UserId;
                model.OperatorName = AppPublic.appSession._FullName;
                if (manager.Modify(model))
                {
                    MessageBox.Show("成功");
                }
                else
                {
                    MessageBox.Show("失败");
                }
            }
            Query();
        }

        /// <summary>
        /// 新增方法
        /// </summary>
        public override void AddNew()
        {
            model = new Models.ys_CheckOrder();
            this.txtCheckNo.Text = "新单号";
            model.Id = Guid.Empty;
            Checkday.EditValue = DateTime.Now;
            txtDescription.Text = "";
            cIsAudit.Checked = false;
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
        /// 选择行改变事件
        /// </summary>
        private void gvData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                Guid Id = (Guid)gvData.GetFocusedRowCellValue("Id");
                model=  allList.FirstOrDefault(a => a.Id == Id);
                if (model != null) {
                    txtCheckNo.Text = model.CheckNo;
                    Checkday.EditValue = model.Checkday;
                    txtOperatorName.Text = model.OperatorName;
                    txtDescription.Text = model.Description;
                    cIsAudit.Checked = model.IsAudit;
                }
                   
            }

        }

        /// <summary>
        /// 显示盘点机的审核情况
        /// </summary>
        private void cIsAudit_CheckedChanged(object sender, EventArgs e)
        {
            if (cIsAudit.Checked)
            {
                cIsAudit.Text = "已审核";
            }
            else {
                cIsAudit.Text = "未审核";
            }
        }
        
        /// <summary>
        /// 双击进入盘点明细
        /// </summary>
        private void gvData_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = gvData.CalcHitInfo(new Point(e.X, e.Y));
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                //判断光标是否在行范围内 
                if (hInfo.InRow)
                {
                    //取得选定行信息 
                    Guid checkId = (Guid)gvData.GetRowCellValue(gvData.FocusedRowHandle, "Id");
                    AssetsCheckEditForm sub = new AssetsCheckEditForm(checkId);
                    sub.ShowDialog();
                }
            }
        }
    }
}
