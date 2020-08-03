using RightingSys.WinForm.Utils.cls;
using System;
using System.Windows.Forms;

namespace RightingSys.WinForm.SubForm.pgAssetsManagerForm.pageBaseinfo
{
    public partial class SystemEditForm :BaseForm
    {
        RightingSys.BLL.SystemManager systemMg = new RightingSys.BLL.SystemManager();
        RightingSys.Models.ACL_System model = new RightingSys.Models.ACL_System();
        public SystemEditForm()
        { 
            InitializeComponent();
            txtsysID.Text = "新Id";
        }

        public SystemEditForm(Guid Id)
        {
            InitializeComponent();
            model = systemMg.GetOneById(Id);
            txtsysID.Text = model.Id.ToString();
            txtsysName.Text = model.SystemName;
            txtSortCode.Text = model.SortCode;
            txtSimpleCode.Text = model.SimpleCode;
            txtRemark.Text = model.SystemDescription;
        }

        public  bool bnSave()
        {
            bool count = false;
            if (txtsysName.Text.Trim()=="")
            {
                MessageBox.Show("系统名称不能为空！",Text);
                txtsysName.Focus();
                return count;
            }
            if (txtsysID.Text=="新Id")
            {
                if (systemMg.ExistsByName(txtsysName.Text.Trim()))
                {
                    MessageBox.Show("系统名称已经存在！", Text);
                    txtsysName.Focus();
                    return count;
                }
            }

           
            model.SystemName = txtsysName.Text.Trim();
            model.SimpleCode = txtSimpleCode.Text;
            model.SortCode = txtSortCode.Text;
            model.SystemDescription = txtRemark.Text;

            if (txtsysID.Text == "新Id")
            {
                model.Id = clsPublic.GetObjGUID(txtsysID.Text);
                count = systemMg.AddNew(model);
                MessageBox.Show("新增成功！", Text);
            }
            else {
                count = systemMg.Modify(model);
                MessageBox.Show("修改成功！", Text);
            }
            return count;
        }

        private void btnNewAdd_Click(object sender, EventArgs e)
        {
            if (bnSave())
            {
                txtsysID.Text = "";
                txtsysName.Text = "";
                txtSortCode.Text ="";
                txtSimpleCode.Text = "";
                txtRemark.Text = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (bnSave())
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
