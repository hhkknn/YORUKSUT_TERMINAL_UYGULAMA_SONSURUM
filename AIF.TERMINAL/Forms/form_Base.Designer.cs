namespace AIF.TERMINAL.Forms
{
    partial class form_Base
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
            this.baseLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.baseExitButton = new System.Windows.Forms.Button();
            this.baseLabel = new System.Windows.Forms.Label();
            this.baseBackButton = new System.Windows.Forms.Button();
            this.baseLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // baseLayoutPanel
            // 
            this.baseLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.baseLayoutPanel.BackColor = System.Drawing.Color.Gold;
            this.baseLayoutPanel.ColumnCount = 3;
            this.baseLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.baseLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.baseLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.baseLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.baseLayoutPanel.Controls.Add(this.baseExitButton, 2, 0);
            this.baseLayoutPanel.Controls.Add(this.baseLabel, 1, 0);
            this.baseLayoutPanel.Controls.Add(this.baseBackButton, 0, 0);
            this.baseLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.baseLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.baseLayoutPanel.Name = "baseLayoutPanel";
            this.baseLayoutPanel.RowCount = 1;
            this.baseLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.baseLayoutPanel.Size = new System.Drawing.Size(405, 56);
            this.baseLayoutPanel.TabIndex = 0;
            // 
            // baseExitButton
            // 
            this.baseExitButton.AutoSize = true;
            this.baseExitButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.baseExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.baseExitButton.Location = new System.Drawing.Point(346, 3);
            this.baseExitButton.Name = "baseExitButton";
            this.baseExitButton.Size = new System.Drawing.Size(56, 50);
            this.baseExitButton.TabIndex = 3;
            this.baseExitButton.Text = "X";
            this.baseExitButton.UseVisualStyleBackColor = true;
            this.baseExitButton.Click += new System.EventHandler(this.baseExitButton_Click);
            // 
            // baseLabel
            // 
            this.baseLabel.AutoSize = true;
            this.baseLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.baseLabel.Location = new System.Drawing.Point(63, 0);
            this.baseLabel.Name = "baseLabel";
            this.baseLabel.Size = new System.Drawing.Size(277, 56);
            this.baseLabel.TabIndex = 0;
            this.baseLabel.Text = "AIFTEAM ERP DEPO OTOMASYONU";
            this.baseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // baseBackButton
            // 
            this.baseBackButton.AutoSize = true;
            this.baseBackButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseBackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.baseBackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.baseBackButton.Location = new System.Drawing.Point(3, 3);
            this.baseBackButton.Name = "baseBackButton";
            this.baseBackButton.Size = new System.Drawing.Size(54, 50);
            this.baseBackButton.TabIndex = 1;
            this.baseBackButton.Text = "<<";
            this.baseBackButton.UseVisualStyleBackColor = true;
            this.baseBackButton.Click += new System.EventHandler(this.baseBackButton_Click);
            // 
            // form_Base
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::AIF.TERMINAL.Properties.Resources.Arkaplan_gri_jpeg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(405, 450);
            this.Controls.Add(this.baseLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "form_Base";
            this.Text = "form_Base";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.form_Base_Load);
            this.Resize += new System.EventHandler(this.form_Base_Resize);
            this.baseLayoutPanel.ResumeLayout(false);
            this.baseLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel baseLayoutPanel;
        private System.Windows.Forms.Label baseLabel;
        private System.Windows.Forms.Button baseBackButton;
        private System.Windows.Forms.Button baseExitButton;
    }
}