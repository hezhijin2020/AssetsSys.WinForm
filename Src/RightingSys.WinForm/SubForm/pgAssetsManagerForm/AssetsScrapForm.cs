using DevExpress.XtraReports.UI;
using RightingSys.WinForm.Utils.cls;
using RightingSys.WinForm.Utils.clsEnum;
using System.Windows.Forms;

namespace RightingSys.WinForm.SubForm.pgAssetsManagerForm
{
    public partial class AssetsScrapForm : BaseForm
    {
        BLL.ScrapOrderManager bll = new BLL.ScrapOrderManager();
        public AssetsScrapForm()
        {
            InitializeComponent();
            Query();
        }

        /// <summary>
        /// 初始化工具菜单
        /// </summary>
        public override void InitFeatureButton()
        {
            base.SetFeatureButton(FeatureButton.Add,FeatureButton.Query,FeatureButton.Export,FeatureButton.Print);
        }
        /// <summary>
        /// 新增报废单
        /// </summary>
        public override void AddNew()
        {
            AssetsScrapAddNewForm sub = new AssetsScrapAddNewForm();
            if (sub.ShowDialog() == DialogResult.OK)
            {
                Query();
            }
        }

        /// <summary>
        /// 查询报废单信息
        /// </summary>
        public override void Query()
        {
            gcData.DataSource = bll.GetAllTable();
            gvData.BestFitColumns();
        }

        /// <summary>
        /// 导出查询信息
        /// </summary>
        public override void Export()
        {
            clsPublic.DevExprot(gcData);
        }

        /// <summary>
        /// 打印报废单
        /// </summary>
        public override void Print()
        {
            object  ScrapNo = gvData.GetFocusedRowCellValue("ScrapNo");
            if (ScrapNo != null && gvData.FocusedRowHandle >= 0)
            {
                DevReport.rptScrapOrder rpt = new DevReport.rptScrapOrder(ScrapNo.ToString());
                rpt.ShowPreview();
            }
        }
    }
}
