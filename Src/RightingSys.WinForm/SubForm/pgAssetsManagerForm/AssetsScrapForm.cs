using DevExpress.XtraReports.UI;
using RightingSys.WinForm.AppPublic.Enum;
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

        public override void InitFeatureButton()
        {
            base.SetFeatureButton(FeatureButton.Add,FeatureButton.Query,FeatureButton.Export,FeatureButton.Preview,FeatureButton.Print);
        }

        public override void AddNew()
        {
            AssetsScrapAddNewForm sub = new AssetsScrapAddNewForm();
            if (sub.ShowDialog() == DialogResult.OK)
            {
                Query();
            }
        }

        public override void Query()
        {
            gcData.DataSource = bll.GetAllTable();
            gvData.BestFitColumns();
        }

        public override void Export()
        {
           // AppPublic.appPublic.DevExprot(gcData);
        }

        public override void Preview()
        {
            //AppPublic.appPublic.DevPreview(gcData, "资产清理单",true);
        }

        public override void Print()
        {
            object  BFID = gvData.GetFocusedRowCellValue( "BFID");
            if (BFID != null && gvData.FocusedRowHandle >= 0)
            {
                //AppPublic.Report.rep_Bforder repbf = new AppPublic.Report.rep_Bforder(BFID.ToString());
                //repbf.ShowPreview();
            }
        }
    }
}
