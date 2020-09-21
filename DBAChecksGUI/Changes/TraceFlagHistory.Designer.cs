﻿namespace DBAChecksGUI.Changes
{
    partial class TraceFlagHistory
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Instance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TraceFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChangeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Change = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvFlags = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlags)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Instance,
            this.TraceFlag,
            this.ChangeDate,
            this.Change});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 51;
            this.dgv.Size = new System.Drawing.Size(676, 194);
            this.dgv.TabIndex = 0;
            // 
            // Instance
            // 
            this.Instance.DataPropertyName = "ConnectionID";
            this.Instance.HeaderText = "Instance";
            this.Instance.MinimumWidth = 6;
            this.Instance.Name = "Instance";
            this.Instance.ReadOnly = true;
            this.Instance.Width = 90;
            // 
            // TraceFlag
            // 
            this.TraceFlag.DataPropertyName = "TraceFlag";
            this.TraceFlag.HeaderText = "Trace Flag";
            this.TraceFlag.MinimumWidth = 6;
            this.TraceFlag.Name = "TraceFlag";
            this.TraceFlag.ReadOnly = true;
            this.TraceFlag.Width = 105;
            // 
            // ChangeDate
            // 
            this.ChangeDate.DataPropertyName = "ChangeDate";
            this.ChangeDate.HeaderText = "Change Date";
            this.ChangeDate.MinimumWidth = 6;
            this.ChangeDate.Name = "ChangeDate";
            this.ChangeDate.ReadOnly = true;
            this.ChangeDate.Width = 120;
            // 
            // Change
            // 
            this.Change.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Change.DataPropertyName = "Change";
            this.Change.HeaderText = "Change";
            this.Change.MinimumWidth = 6;
            this.Change.Name = "Change";
            this.Change.ReadOnly = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvFlags);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgv);
            this.splitContainer1.Size = new System.Drawing.Size(676, 395);
            this.splitContainer1.SplitterDistance = 197;
            this.splitContainer1.TabIndex = 2;
            // 
            // dgvFlags
            // 
            this.dgvFlags.AllowUserToAddRows = false;
            this.dgvFlags.AllowUserToDeleteRows = false;
            this.dgvFlags.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvFlags.BackgroundColor = System.Drawing.Color.White;
            this.dgvFlags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFlags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFlags.Location = new System.Drawing.Point(0, 0);
            this.dgvFlags.Name = "dgvFlags";
            this.dgvFlags.ReadOnly = true;
            this.dgvFlags.RowHeadersVisible = false;
            this.dgvFlags.RowHeadersWidth = 51;
            this.dgvFlags.RowTemplate.Height = 24;
            this.dgvFlags.Size = new System.Drawing.Size(676, 197);
            this.dgvFlags.TabIndex = 0;
            // 
            // TraceFlagHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "TraceFlagHistory";
            this.Size = new System.Drawing.Size(676, 395);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlags)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Instance;
        private System.Windows.Forms.DataGridViewTextBoxColumn TraceFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChangeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Change;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvFlags;
    }
}