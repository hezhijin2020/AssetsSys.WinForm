namespace RightingSys.WinForm.SubForm.pgAssetsManagerForm
{
    partial class AssetsScrapForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gcData = new DevExpress.XtraGrid.GridControl();
            this.gvData = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.Band_Require = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.Band_RequireDetail = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColumn10 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).BeginInit();
            this.SuspendLayout();
            // 
            // gcData
            // 
            this.gcData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcData.Location = new System.Drawing.Point(12, 12);
            this.gcData.MainView = this.gvData;
            this.gcData.Name = "gcData";
            this.gcData.Size = new System.Drawing.Size(618, 142);
            this.gcData.TabIndex = 0;
            this.gcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvData});
            // 
            // gvData
            // 
            this.gvData.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.Band_Require,
            this.Band_RequireDetail});
            this.gvData.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.gridColumn2,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn8,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn20,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19});
            this.gvData.GridControl = this.gcData;
            this.gvData.IndicatorWidth = 40;
            this.gvData.Name = "gvData";
            this.gvData.OptionsBehavior.Editable = false;
            this.gvData.OptionsView.AllowCellMerge = true;
            this.gvData.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.gvData.OptionsView.ColumnAutoWidth = false;
            this.gvData.OptionsView.EnableAppearanceEvenRow = true;
            this.gvData.OptionsView.EnableAppearanceOddRow = true;
            this.gvData.OptionsView.ShowGroupPanel = false;
            // 
            // Band_Require
            // 
            this.Band_Require.Caption = "订单信息";
            this.Band_Require.Columns.Add(this.gridColumn2);
            this.Band_Require.Columns.Add(this.gridColumn4);
            this.Band_Require.Columns.Add(this.gridColumn6);
            this.Band_Require.Columns.Add(this.gridColumn5);
            this.Band_Require.Columns.Add(this.gridColumn8);
            this.Band_Require.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.Band_Require.Name = "Band_Require";
            this.Band_Require.VisibleIndex = 0;
            this.Band_Require.Width = 375;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "单号";
            this.gridColumn2.FieldName = "ScrapNo";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn2.OptionsColumn.AllowMove = false;
            this.gridColumn2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.Visible = true;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "职员";
            this.gridColumn4.FieldName = "ScrapUserName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn4.OptionsColumn.AllowMove = false;
            this.gridColumn4.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.Visible = true;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "经办人";
            this.gridColumn6.FieldName = "OperatorName";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn6.OptionsColumn.AllowMove = false;
            this.gridColumn6.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.Visible = true;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "日期";
            this.gridColumn5.FieldName = "Scrapday";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn5.OptionsColumn.AllowMove = false;
            this.gridColumn5.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.Visible = true;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "说明";
            this.gridColumn8.FieldName = "ScrapDescription";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn8.OptionsColumn.AllowMove = false;
            this.gridColumn8.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn8.Visible = true;
            // 
            // Band_RequireDetail
            // 
            this.Band_RequireDetail.Caption = "订单明细";
            this.Band_RequireDetail.Columns.Add(this.gridColumn10);
            this.Band_RequireDetail.Columns.Add(this.gridColumn11);
            this.Band_RequireDetail.Columns.Add(this.gridColumn12);
            this.Band_RequireDetail.Columns.Add(this.gridColumn13);
            this.Band_RequireDetail.Columns.Add(this.gridColumn14);
            this.Band_RequireDetail.Columns.Add(this.gridColumn15);
            this.Band_RequireDetail.Columns.Add(this.gridColumn16);
            this.Band_RequireDetail.Columns.Add(this.gridColumn17);
            this.Band_RequireDetail.Columns.Add(this.gridColumn18);
            this.Band_RequireDetail.Columns.Add(this.gridColumn19);
            this.Band_RequireDetail.Name = "Band_RequireDetail";
            this.Band_RequireDetail.VisibleIndex = 1;
            this.Band_RequireDetail.Width = 750;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "名称";
            this.gridColumn10.FieldName = "Name";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn10.OptionsColumn.AllowMove = false;
            this.gridColumn10.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn10.Visible = true;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "编码";
            this.gridColumn11.FieldName = "Barcode";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn11.OptionsColumn.AllowMove = false;
            this.gridColumn11.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn11.Visible = true;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "型号";
            this.gridColumn12.FieldName = "Model";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn12.OptionsColumn.AllowMove = false;
            this.gridColumn12.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn12.Visible = true;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "类别";
            this.gridColumn13.FieldName = "CategoryName";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn13.OptionsColumn.AllowMove = false;
            this.gridColumn13.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn13.Visible = true;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "部门";
            this.gridColumn14.FieldName = "DepartmentName";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn14.OptionsColumn.AllowMove = false;
            this.gridColumn14.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn14.Visible = true;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "人员";
            this.gridColumn15.FieldName = "UserName";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn15.OptionsColumn.AllowMove = false;
            this.gridColumn15.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn15.Visible = true;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "位置";
            this.gridColumn16.FieldName = "Location";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn16.OptionsColumn.AllowMove = false;
            this.gridColumn16.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn16.Visible = true;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "产值";
            this.gridColumn17.FieldName = "Price";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn17.OptionsColumn.AllowMove = false;
            this.gridColumn17.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn17.Visible = true;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "仓库";
            this.gridColumn18.FieldName = "StockName";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn18.OptionsColumn.AllowMove = false;
            this.gridColumn18.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn18.Visible = true;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "状态";
            this.gridColumn19.FieldName = "StatusName";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn19.OptionsColumn.AllowMove = false;
            this.gridColumn19.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn19.Visible = true;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "购买时间";
            this.gridColumn20.FieldName = "Buyday";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Visible = true;
            // 
            // AssetsScrapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 166);
            this.Controls.Add(this.gcData);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AssetsScrapForm";
            this.Text = "资产清理";
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcData;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView gvData;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand Band_Require;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn4;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn5;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn6;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn8;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand Band_RequireDetail;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn10;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn11;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn12;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn13;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn14;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn15;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn16;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn17;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn18;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn19;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn20;
    }
}