namespace RightingSys.WinForm.SubForm.pgAssetsManagerForm
{
    partial class AssetsAllotEditForm
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
            this.tlocation = new DevExpress.XtraEditors.TextEdit();
            this.tApplyday = new DevExpress.XtraEditors.DateEdit();
            this.cbUser = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.treeListLookUpEdit1TreeList = new DevExpress.XtraTreeList.TreeList();
            this.cbtlDepartment = new DevExpress.XtraEditors.TreeListLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tApplyday.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tApplyday.Properties)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1TreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbtlDepartment.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.labelControl8);
            this.panelControl1.Controls.Add(this.tDescription);
            this.panelControl1.Controls.Add(this.tlocation);
            this.panelControl1.Controls.Add(this.tApplyday);
            this.panelControl1.Controls.Add(this.cbUser);
            this.panelControl1.Controls.Add(this.cbtlDepartment);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.tEditUser);
            this.panelControl1.Location = new System.Drawing.Point(10, 10);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(676, 75);
            this.panelControl1.TabIndex = 0;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(542, 15);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(36, 14);
            this.labelControl8.TabIndex = 10;
            this.labelControl8.Text = "经办人";
            // 
            // tDescription
            // 
            this.tDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tDescription.Location = new System.Drawing.Point(246, 42);
            this.tDescription.Name = "tDescription";
            this.tDescription.Size = new System.Drawing.Size(412, 20);
            this.tDescription.TabIndex = 9;
            // 
            // tlocation
            // 
            this.tlocation.Location = new System.Drawing.Point(71, 42);
            this.tlocation.Name = "tlocation";
            this.tlocation.Size = new System.Drawing.Size(135, 20);
            this.tlocation.TabIndex = 8;
            // 
            // tApplyday
            // 
            this.tApplyday.EditValue = null;
            this.tApplyday.Location = new System.Drawing.Point(428, 12);
            this.tApplyday.Name = "tApplyday";
            this.tApplyday.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tApplyday.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tApplyday.Size = new System.Drawing.Size(108, 20);
            this.tApplyday.TabIndex = 7;
            // 
            // cbUser
            // 
            this.cbUser.Location = new System.Drawing.Point(268, 12);
            this.cbUser.Name = "cbUser";
            this.cbUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbUser.Properties.PopupView = this.gridLookUpEdit1View;
            this.cbUser.Properties.ReadOnly = true;
            this.cbUser.Size = new System.Drawing.Size(100, 20);
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
            this.labelControl5.Location = new System.Drawing.Point(214, 15);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(48, 14);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "接收人员";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(17, 45);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 14);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "使用地点";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(211, 44);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(24, 14);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "备注";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(374, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "接收时间";
            // 
            // tEditUser
            // 
            this.tEditUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tEditUser.Enabled = false;
            this.tEditUser.Location = new System.Drawing.Point(584, 12);
            this.tEditUser.Name = "tEditUser";
            this.tEditUser.Properties.DisplayFormat.FormatString = "d";
            this.tEditUser.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tEditUser.Properties.EditFormat.FormatString = "d";
            this.tEditUser.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tEditUser.Properties.Mask.EditMask = "d";
            this.tEditUser.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.tEditUser.Size = new System.Drawing.Size(74, 20);
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
            this.groupControl1.Size = new System.Drawing.Size(457, 173);
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
            this.gcData.Size = new System.Drawing.Size(447, 144);
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
            this.sbtnSave.Location = new System.Drawing.Point(521, 270);
            this.sbtnSave.Name = "sbtnSave";
            this.sbtnSave.Size = new System.Drawing.Size(66, 29);
            this.sbtnSave.TabIndex = 2;
            this.sbtnSave.Text = "保存";
            this.sbtnSave.Click += new System.EventHandler(this.sbtnSave_Click);
            // 
            // sbtnCancel
            // 
            this.sbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnCancel.Location = new System.Drawing.Point(603, 269);
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
            this.groupControl2.Location = new System.Drawing.Point(473, 91);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(213, 173);
            this.groupControl2.TabIndex = 17;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(17, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "接收部门";
            // 
            // treeListLookUpEdit1TreeList
            // 
            this.treeListLookUpEdit1TreeList.Location = new System.Drawing.Point(0, 0);
            this.treeListLookUpEdit1TreeList.Name = "treeListLookUpEdit1TreeList";
            this.treeListLookUpEdit1TreeList.OptionsView.ShowIndentAsRowStyle = true;
            this.treeListLookUpEdit1TreeList.Size = new System.Drawing.Size(400, 200);
            this.treeListLookUpEdit1TreeList.TabIndex = 0;
            // 
            // cbtlDepartment
            // 
            this.cbtlDepartment.Location = new System.Drawing.Point(71, 12);
            this.cbtlDepartment.Name = "cbtlDepartment";
            this.cbtlDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbtlDepartment.Properties.TreeList = this.treeListLookUpEdit1TreeList;
            this.cbtlDepartment.Size = new System.Drawing.Size(135, 20);
            this.cbtlDepartment.TabIndex = 5;
            this.cbtlDepartment.EditValueChanged += new System.EventHandler(this.tl_Dept_EditValueChanged);
            // 
            // AssetsAllotEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 302);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.sbtnCancel);
            this.Controls.Add(this.sbtnSave);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AssetsAllotEditForm";
            this.Text = "调拔单";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tApplyday.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tApplyday.Properties)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1TreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbtlDepartment.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit tlocation;
        private DevExpress.XtraEditors.DateEdit tApplyday;
        private DevExpress.XtraEditors.GridLookUpEdit cbUser;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
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
        private DevExpress.XtraEditors.TreeListLookUpEdit cbtlDepartment;
        private DevExpress.XtraTreeList.TreeList treeListLookUpEdit1TreeList;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}