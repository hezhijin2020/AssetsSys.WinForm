namespace RightingSys.WinForm.SubForm.pgBaseForm
{
    partial class AssetsCategoryForm
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
            this.tlType = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.sbtnSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtSortCode = new DevExpress.XtraEditors.TextEdit();
            this.txtSimpleCode = new DevExpress.XtraEditors.TextEdit();
            this.txtFullName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tlParentID = new DevExpress.XtraEditors.TreeListLookUpEdit();
            this.treeListLookUpEdit1TreeList = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn6 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSortCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSimpleCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlParentID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1TreeList)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.tlType);
            this.panelControl1.Location = new System.Drawing.Point(13, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(281, 263);
            this.panelControl1.TabIndex = 0;
            // 
            // tlType
            // 
            this.tlType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlType.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListColumn3});
            this.tlType.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlType.IndicatorWidth = 40;
            this.tlType.KeyFieldName = "Id";
            this.tlType.Location = new System.Drawing.Point(5, 5);
            this.tlType.Name = "tlType";
            this.tlType.OptionsBehavior.Editable = false;
            this.tlType.OptionsView.EnableAppearanceEvenRow = true;
            this.tlType.OptionsView.EnableAppearanceOddRow = true;
            this.tlType.ParentFieldName = "ParentId";
            this.tlType.Size = new System.Drawing.Size(271, 253);
            this.tlType.TabIndex = 0;
            this.tlType.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tlType_FocusedNodeChanged);
            //this.tlType.CustomDrawNodeIndicator += new DevExpress.XtraTreeList.CustomDrawNodeIndicatorEventHandler(this.tlType_CustomDrawNodeIndicator);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "名称";
            this.treeListColumn1.FieldName = "CategoryName";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 151;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "简码";
            this.treeListColumn2.FieldName = "SimpleCode";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 51;
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "排序码";
            this.treeListColumn3.FieldName = "SortCode";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 2;
            this.treeListColumn3.Width = 60;
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.Controls.Add(this.sbtnSave);
            this.panelControl2.Controls.Add(this.txtSortCode);
            this.panelControl2.Controls.Add(this.txtSimpleCode);
            this.panelControl2.Controls.Add(this.txtFullName);
            this.panelControl2.Controls.Add(this.labelControl4);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.tlParentID);
            this.panelControl2.Location = new System.Drawing.Point(309, 12);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(267, 263);
            this.panelControl2.TabIndex = 1;
            // 
            // sbtnSave
            // 
            this.sbtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnSave.Location = new System.Drawing.Point(176, 140);
            this.sbtnSave.Name = "sbtnSave";
            this.sbtnSave.Size = new System.Drawing.Size(75, 23);
            this.sbtnSave.TabIndex = 10;
            this.sbtnSave.Text = "保存";
            this.sbtnSave.Click += new System.EventHandler(this.sbtnSave_Click);
            // 
            // txtSortCode
            // 
            this.txtSortCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSortCode.Location = new System.Drawing.Point(54, 105);
            this.txtSortCode.Name = "txtSortCode";
            this.txtSortCode.Size = new System.Drawing.Size(197, 20);
            this.txtSortCode.TabIndex = 8;
            // 
            // txtSimpleCode
            // 
            this.txtSimpleCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSimpleCode.Location = new System.Drawing.Point(54, 76);
            this.txtSimpleCode.Name = "txtSimpleCode";
            this.txtSimpleCode.Size = new System.Drawing.Size(197, 20);
            this.txtSimpleCode.TabIndex = 7;
            // 
            // txtFullName
            // 
            this.txtFullName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFullName.Location = new System.Drawing.Point(54, 47);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(197, 20);
            this.txtFullName.TabIndex = 6;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 108);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 14);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "排序码";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(24, 79);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(24, 14);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "简码";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(24, 50);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "名称";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(24, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "上级";
            // 
            // tlParentID
            // 
            this.tlParentID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tlParentID.Location = new System.Drawing.Point(54, 18);
            this.tlParentID.Name = "tlParentID";
            this.tlParentID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tlParentID.Properties.DisplayMember = "CategoryName";
            this.tlParentID.Properties.NullText = "";
            this.tlParentID.Properties.TreeList = this.treeListLookUpEdit1TreeList;
            this.tlParentID.Properties.ValueMember = "Id";
            this.tlParentID.Size = new System.Drawing.Size(197, 20);
            this.tlParentID.TabIndex = 5;
            // 
            // treeListLookUpEdit1TreeList
            // 
            this.treeListLookUpEdit1TreeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn4,
            this.treeListColumn5,
            this.treeListColumn6});
            this.treeListLookUpEdit1TreeList.KeyFieldName = "Id";
            this.treeListLookUpEdit1TreeList.Location = new System.Drawing.Point(0, 0);
            this.treeListLookUpEdit1TreeList.Name = "treeListLookUpEdit1TreeList";
            this.treeListLookUpEdit1TreeList.OptionsView.EnableAppearanceEvenRow = true;
            this.treeListLookUpEdit1TreeList.OptionsView.EnableAppearanceOddRow = true;
            this.treeListLookUpEdit1TreeList.OptionsView.ShowIndentAsRowStyle = true;
            this.treeListLookUpEdit1TreeList.ParentFieldName = "ParentId";
            this.treeListLookUpEdit1TreeList.Size = new System.Drawing.Size(400, 200);
            this.treeListLookUpEdit1TreeList.TabIndex = 0;
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.Caption = "名称";
            this.treeListColumn4.FieldName = "CategoryName";
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.Visible = true;
            this.treeListColumn4.VisibleIndex = 0;
            // 
            // treeListColumn5
            // 
            this.treeListColumn5.Caption = "简码";
            this.treeListColumn5.FieldName = "SimpleCode";
            this.treeListColumn5.Name = "treeListColumn5";
            this.treeListColumn5.Visible = true;
            this.treeListColumn5.VisibleIndex = 1;
            // 
            // treeListColumn6
            // 
            this.treeListColumn6.Caption = "排序码";
            this.treeListColumn6.FieldName = "SortCode";
            this.treeListColumn6.Name = "treeListColumn6";
            this.treeListColumn6.Visible = true;
            this.treeListColumn6.VisibleIndex = 2;
            // 
            // AssetsCategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 287);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "AssetsCategoryForm";
            this.Text = "资产类别";
            this.Load += new System.EventHandler(this.FA_TypeSetup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSortCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSimpleCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlParentID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1TreeList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraTreeList.TreeList tlType;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraEditors.SimpleButton sbtnSave;
        private DevExpress.XtraEditors.TextEdit txtSortCode;
        private DevExpress.XtraEditors.TextEdit txtSimpleCode;
        private DevExpress.XtraEditors.TextEdit txtFullName;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TreeListLookUpEdit tlParentID;
        private DevExpress.XtraTreeList.TreeList treeListLookUpEdit1TreeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn5;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn6;
    }
}