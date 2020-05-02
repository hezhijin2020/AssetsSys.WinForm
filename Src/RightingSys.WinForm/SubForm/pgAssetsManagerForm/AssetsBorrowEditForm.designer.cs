namespace RightingSys.WinForm.SubForm.pgAssetsManagerForm
{
    partial class AssetsBorrowEditForm
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.tDescription = new DevExpress.XtraEditors.TextEdit();
            this.tBorrowday = new DevExpress.XtraEditors.DateEdit();
            this.cbUser = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.tEditUser = new DevExpress.XtraEditors.TextEdit();
            this.sbtnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.cbAssets = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gvAsset = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.cbStock = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.sbtnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gcData = new DevExpress.XtraGrid.GridControl();
            this.gvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.AssetsId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sbtnSave = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.tPlenday = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBorrowday.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBorrowday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEditUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAssets.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAsset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbStock.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tPlenday.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tPlenday.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.tPlenday);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.labelControl8);
            this.panelControl1.Controls.Add(this.tDescription);
            this.panelControl1.Controls.Add(this.tBorrowday);
            this.panelControl1.Controls.Add(this.cbUser);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.tEditUser);
            this.panelControl1.Location = new System.Drawing.Point(10, 10);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(634, 75);
            this.panelControl1.TabIndex = 0;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(497, 15);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(36, 14);
            this.labelControl8.TabIndex = 10;
            this.labelControl8.Text = "经办人";
            // 
            // tDescription
            // 
            this.tDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tDescription.Location = new System.Drawing.Point(71, 41);
            this.tDescription.Name = "tDescription";
            this.tDescription.Size = new System.Drawing.Size(545, 20);
            this.tDescription.TabIndex = 9;
            // 
            // tBorrowday
            // 
            this.tBorrowday.EditValue = null;
            this.tBorrowday.Location = new System.Drawing.Point(220, 12);
            this.tBorrowday.Name = "tBorrowday";
            this.tBorrowday.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tBorrowday.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tBorrowday.Size = new System.Drawing.Size(106, 20);
            this.tBorrowday.TabIndex = 7;
            // 
            // cbUser
            // 
            this.cbUser.Location = new System.Drawing.Point(71, 12);
            this.cbUser.Name = "cbUser";
            this.cbUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbUser.Properties.PopupView = this.gridLookUpEdit1View;
            this.cbUser.Properties.ReadOnly = true;
            this.cbUser.Size = new System.Drawing.Size(88, 20);
            this.cbUser.TabIndex = 6;
            this.cbUser.Click += new System.EventHandler(this.cbUser_Click);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(17, 15);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(48, 14);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "申请人员";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(17, 43);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 14);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "借用描述";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(166, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "借用日期";
            // 
            // tEditUser
            // 
            this.tEditUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tEditUser.Enabled = false;
            this.tEditUser.Location = new System.Drawing.Point(539, 12);
            this.tEditUser.Name = "tEditUser";
            this.tEditUser.Properties.DisplayFormat.FormatString = "d";
            this.tEditUser.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tEditUser.Properties.EditFormat.FormatString = "d";
            this.tEditUser.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tEditUser.Properties.Mask.EditMask = "d";
            this.tEditUser.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.tEditUser.Size = new System.Drawing.Size(77, 20);
            this.tEditUser.TabIndex = 11;
            // 
            // sbtnDelete
            // 
            this.sbtnDelete.Location = new System.Drawing.Point(129, 86);
            this.sbtnDelete.Name = "sbtnDelete";
            this.sbtnDelete.Size = new System.Drawing.Size(66, 21);
            this.sbtnDelete.TabIndex = 16;
            this.sbtnDelete.Text = "删除";
            this.sbtnDelete.Click += new System.EventHandler(this.sbtnDelete_Click);
            // 
            // cbAssets
            // 
            this.cbAssets.Location = new System.Drawing.Point(48, 60);
            this.cbAssets.Name = "cbAssets";
            this.cbAssets.Properties.AutoComplete = false;
            this.cbAssets.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbAssets.Properties.PopupSizeable = false;
            this.cbAssets.Properties.PopupView = this.gvAsset;
            this.cbAssets.Properties.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.ContentWidth;
            this.cbAssets.Size = new System.Drawing.Size(147, 20);
            this.cbAssets.TabIndex = 15;
            // 
            // gvAsset
            // 
            this.gvAsset.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvAsset.Name = "gvAsset";
            this.gvAsset.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvAsset.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(15, 63);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(24, 14);
            this.labelControl7.TabIndex = 14;
            this.labelControl7.Text = "资产";
            // 
            // cbStock
            // 
            this.cbStock.Location = new System.Drawing.Point(48, 34);
            this.cbStock.Name = "cbStock";
            this.cbStock.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbStock.Properties.PopupView = this.gridView2;
            this.cbStock.Size = new System.Drawing.Size(147, 20);
            this.cbStock.TabIndex = 13;
            this.cbStock.EditValueChanged += new System.EventHandler(this.cbStock_EditValueChanged);
            // 
            // gridView2
            // 
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(15, 36);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(24, 14);
            this.labelControl6.TabIndex = 12;
            this.labelControl6.Text = "仓库";
            // 
            // sbtnAdd
            // 
            this.sbtnAdd.Location = new System.Drawing.Point(48, 86);
            this.sbtnAdd.Name = "sbtnAdd";
            this.sbtnAdd.Size = new System.Drawing.Size(66, 21);
            this.sbtnAdd.TabIndex = 11;
            this.sbtnAdd.Text = "添加";
            this.sbtnAdd.Click += new System.EventHandler(this.sbtnAdd_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.gcData);
            this.groupControl1.Location = new System.Drawing.Point(10, 91);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(415, 194);
            this.groupControl1.TabIndex = 1;
            // 
            // gcData
            // 
            this.gcData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcData.Location = new System.Drawing.Point(5, 24);
            this.gcData.MainView = this.gvData;
            this.gcData.Name = "gcData";
            this.gcData.Size = new System.Drawing.Size(405, 165);
            this.gcData.TabIndex = 0;
            this.gcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvData});
            // 
            // gvData
            // 
            this.gvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.AssetsId,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.gvData.CustomizationFormBounds = new System.Drawing.Rectangle(313, 242, 210, 179);
            this.gvData.GridControl = this.gcData;
            this.gvData.Name = "gvData";
            this.gvData.OptionsView.EnableAppearanceEvenRow = true;
            this.gvData.OptionsView.EnableAppearanceOddRow = true;
            this.gvData.OptionsView.ShowGroupPanel = false;
            // 
            // AssetsId
            // 
            this.AssetsId.Caption = "编号";
            this.AssetsId.FieldName = "Id";
            this.AssetsId.Name = "AssetsId";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "名称";
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "条码";
            this.gridColumn3.FieldName = "Barcode";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "型号";
            this.gridColumn4.FieldName = "Model";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "部门";
            this.gridColumn5.FieldName = "DepartmentName";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "人员";
            this.gridColumn6.FieldName = "UserName";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "仓库";
            this.gridColumn7.FieldName = "StockName";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            // 
            // sbtnSave
            // 
            this.sbtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnSave.Location = new System.Drawing.Point(479, 291);
            this.sbtnSave.Name = "sbtnSave";
            this.sbtnSave.Size = new System.Drawing.Size(66, 29);
            this.sbtnSave.TabIndex = 2;
            this.sbtnSave.Text = "保存";
            this.sbtnSave.Click += new System.EventHandler(this.sbtnSave_Click);
            // 
            // sbtnCancel
            // 
            this.sbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnCancel.Location = new System.Drawing.Point(561, 290);
            this.sbtnCancel.Name = "sbtnCancel";
            this.sbtnCancel.Size = new System.Drawing.Size(66, 29);
            this.sbtnCancel.TabIndex = 3;
            this.sbtnCancel.Text = "取消";
            this.sbtnCancel.Click += new System.EventHandler(this.sbtnCancel_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.sbtnDelete);
            this.groupControl2.Controls.Add(this.labelControl6);
            this.groupControl2.Controls.Add(this.sbtnAdd);
            this.groupControl2.Controls.Add(this.cbStock);
            this.groupControl2.Controls.Add(this.labelControl7);
            this.groupControl2.Controls.Add(this.cbAssets);
            this.groupControl2.Location = new System.Drawing.Point(431, 91);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(213, 194);
            this.groupControl2.TabIndex = 17;
            // 
            // tPlenday
            // 
            this.tPlenday.EditValue = null;
            this.tPlenday.Location = new System.Drawing.Point(385, 12);
            this.tPlenday.Name = "tPlenday";
            this.tPlenday.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tPlenday.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tPlenday.Size = new System.Drawing.Size(106, 20);
            this.tPlenday.TabIndex = 13;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(332, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "归还时间";
            // 
            // AssetsBorrowEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 323);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.sbtnCancel);
            this.Controls.Add(this.sbtnSave);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AssetsBorrowEditForm";
            this.Text = "借用单";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBorrowday.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBorrowday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEditUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAssets.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAsset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbStock.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tPlenday.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tPlenday.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton sbtnDelete;
        private DevExpress.XtraEditors.GridLookUpEdit cbAssets;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAsset;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.GridLookUpEdit cbStock;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SimpleButton sbtnAdd;
        private DevExpress.XtraEditors.TextEdit tDescription;
        private DevExpress.XtraEditors.DateEdit tBorrowday;
        private DevExpress.XtraEditors.GridLookUpEdit cbUser;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl gcData;
        private DevExpress.XtraGrid.Views.Grid.GridView gvData;
        private DevExpress.XtraEditors.SimpleButton sbtnSave;
        private DevExpress.XtraEditors.SimpleButton sbtnCancel;
        private DevExpress.XtraGrid.Columns.GridColumn AssetsId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit tEditUser;
        private DevExpress.XtraEditors.DateEdit tPlenday;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}