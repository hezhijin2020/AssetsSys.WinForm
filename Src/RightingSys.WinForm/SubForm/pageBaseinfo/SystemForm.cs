using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RightingSys.WinForm.Utils.clsEnum;

namespace RightingSys.WinForm.SubForm.pgAssetsManagerForm.pageBaseinfo
{
    public partial class SystemForm :BaseForm
    {

        RightingSys.BLL.SystemManager sysMg = new RightingSys.BLL.SystemManager();
        public SystemForm()
        {
            InitializeComponent();
        }

        public override void InitFeatureButton()
        {
            base.SetFeatureButton(new FeatureButton[] { FeatureButton .Add,FeatureButton.Query,FeatureButton.Modify,FeatureButton.Delete});
            Query();
        }

        public override void AddNew()
        {
            SystemEditForm sub = new SystemEditForm();
            sub.Text = "新增-" + sub.Text;
            sub.ShowDialog();
            Query(); 
        }

        public override void Modify()
        {
            if (gvData.FocusedRowHandle >= 0)
            {
                Guid Id = Guid.Parse(gvData.GetFocusedRowCellValue("Id").ToString());

                SystemEditForm sub = new SystemEditForm(Id);
                sub.Text = "修改-" + sub.Text;
                if (sub.ShowDialog() == DialogResult.OK)
                {
                    Query();
                }
            }
        }

        public override void Delete()
        {
            if(gvData.FocusedRowHandle >=0)
            {
               Guid Id= Guid.Parse( gvData.GetFocusedRowCellValue("Id").ToString());
                if (MessageBox.Show("是否删除该记录？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (sysMg.Delete(Id))
                    {
                        Query();
                        MessageBox.Show("删除成功！", Text);
                    }
                    else
                    {
                        MessageBox.Show("系统出错！", Text);
                    }
                }
            }
        }

        public override void Query()
        {
            gcData.DataSource = sysMg.GetAllSystems();
        }

        private void toolMenuSystemVersion_Click(object sender, EventArgs e)
        {

            if(gvData.FocusedRowHandle>=0)
            {
                Guid _systemId = (Guid)gvData.GetFocusedRowCellValue("Id");
                SystemVersionForm sub = new SystemVersionForm(_systemId);
                sub.ShowDialog();
            }
           
        }
    }
}
