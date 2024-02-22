namespace AIF.TERMINAL.Forms
{
    partial class DepoSorgulama
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblWareHouseCode = new System.Windows.Forms.Label();
            this.lblWareHouseName = new System.Windows.Forms.Label();
            this.dtgWareHouseDetails = new System.Windows.Forms.DataGridView();
            this.txtWareHouseCode = new System.Windows.Forms.TextBox();
            this.cmbWareHouseName = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.frmName = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgWareHouseDetails)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tableLayoutPanel1.Controls.Add(this.lblWareHouseCode, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblWareHouseName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.dtgWareHouseDetails, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtWareHouseCode, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbWareHouseName, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnDelete, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnQuery, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.vScrollBar1, 4, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 56);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(405, 394);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // lblWareHouseCode
            // 
            this.lblWareHouseCode.AutoSize = true;
            this.lblWareHouseCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWareHouseCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWareHouseCode.Location = new System.Drawing.Point(11, 15);
            this.lblWareHouseCode.Name = "lblWareHouseCode";
            this.lblWareHouseCode.Padding = new System.Windows.Forms.Padding(0, 14, 0, 0);
            this.lblWareHouseCode.Size = new System.Drawing.Size(115, 19);
            this.lblWareHouseCode.TabIndex = 4;
            this.lblWareHouseCode.Text = "DEPO KODU";
            // 
            // lblWareHouseName
            // 
            this.lblWareHouseName.AutoSize = true;
            this.lblWareHouseName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWareHouseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWareHouseName.Location = new System.Drawing.Point(11, 34);
            this.lblWareHouseName.Name = "lblWareHouseName";
            this.lblWareHouseName.Padding = new System.Windows.Forms.Padding(0, 14, 0, 0);
            this.lblWareHouseName.Size = new System.Drawing.Size(115, 19);
            this.lblWareHouseName.TabIndex = 3;
            this.lblWareHouseName.Text = "DEPO TANIMI";
            // 
            // dtgWareHouseDetails
            // 
            this.dtgWareHouseDetails.AllowUserToAddRows = false;
            this.dtgWareHouseDetails.AllowUserToDeleteRows = false;
            this.dtgWareHouseDetails.AllowUserToResizeRows = false;
            this.dtgWareHouseDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgWareHouseDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgWareHouseDetails.ColumnHeadersHeight = 29;
            this.tableLayoutPanel1.SetColumnSpan(this.dtgWareHouseDetails, 3);
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgWareHouseDetails.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgWareHouseDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgWareHouseDetails.EnableHeadersVisualStyles = false;
            this.dtgWareHouseDetails.Location = new System.Drawing.Point(11, 67);
            this.dtgWareHouseDetails.Name = "dtgWareHouseDetails";
            this.dtgWareHouseDetails.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgWareHouseDetails.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgWareHouseDetails.RowHeadersVisible = false;
            this.dtgWareHouseDetails.RowHeadersWidth = 51;
            this.dtgWareHouseDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgWareHouseDetails.Size = new System.Drawing.Size(361, 218);
            this.dtgWareHouseDetails.TabIndex = 6;
            this.dtgWareHouseDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgWareHouseDetails_CellClick);
            this.dtgWareHouseDetails.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dtgWareHouseDetails_Scroll);
            this.dtgWareHouseDetails.DoubleClick += new System.EventHandler(this.dtgWareHouseDetails_DoubleClick);
            // 
            // txtWareHouseCode
            // 
            this.txtWareHouseCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtWareHouseCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtWareHouseCode.Location = new System.Drawing.Point(132, 18);
            this.txtWareHouseCode.Name = "txtWareHouseCode";
            this.txtWareHouseCode.Size = new System.Drawing.Size(176, 20);
            this.txtWareHouseCode.TabIndex = 14;
            this.txtWareHouseCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWareHouseCode_KeyDown);
            // 
            // cmbWareHouseName
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cmbWareHouseName, 3);
            this.cmbWareHouseName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbWareHouseName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWareHouseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbWareHouseName.FormattingEnabled = true;
            this.cmbWareHouseName.Location = new System.Drawing.Point(132, 37);
            this.cmbWareHouseName.Name = "cmbWareHouseName";
            this.cmbWareHouseName.Size = new System.Drawing.Size(260, 21);
            this.cmbWareHouseName.TabIndex = 43;
            this.cmbWareHouseName.SelectedValueChanged += new System.EventHandler(this.cmbWareHouseName_SelectedValueChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 4);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.frmName, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(11, 353);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(381, 38);
            this.tableLayoutPanel2.TabIndex = 40;
            // 
            // frmName
            // 
            this.frmName.AutoSize = true;
            this.frmName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frmName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.frmName.Location = new System.Drawing.Point(79, 5);
            this.frmName.Name = "frmName";
            this.frmName.Size = new System.Drawing.Size(222, 22);
            this.frmName.TabIndex = 0;
            this.frmName.Text = "form";
            this.frmName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Gold;
            this.tableLayoutPanel1.SetColumnSpan(this.btnDelete, 4);
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDelete.Location = new System.Drawing.Point(11, 322);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(381, 25);
            this.btnDelete.TabIndex = 41;
            this.btnDelete.Text = "TEMİZLE";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.BackColor = System.Drawing.Color.Gold;
            this.tableLayoutPanel1.SetColumnSpan(this.btnQuery, 4);
            this.btnQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnQuery.Location = new System.Drawing.Point(11, 291);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(381, 25);
            this.btnQuery.TabIndex = 44;
            this.btnQuery.Text = "SORGULA";
            this.btnQuery.UseVisualStyleBackColor = false;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vScrollBar1.Location = new System.Drawing.Point(375, 64);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(20, 224);
            this.vScrollBar1.TabIndex = 45;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // DepoSorgulama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AIF.TERMINAL.Properties.Resources.Arkaplan_gri_jpeg;
            this.ClientSize = new System.Drawing.Size(405, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DepoSorgulama";
            this.Text = "DepoSorgulama";
            this.Load += new System.EventHandler(this.DepoSorgulama_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgWareHouseDetails)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblWareHouseCode;
        private System.Windows.Forms.Label lblWareHouseName;
        private System.Windows.Forms.DataGridView dtgWareHouseDetails;
        private System.Windows.Forms.TextBox txtWareHouseCode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label frmName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cmbWareHouseName;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.VScrollBar vScrollBar1;
    }
}