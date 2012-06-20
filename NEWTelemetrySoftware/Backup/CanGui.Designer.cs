namespace CanLogger
{
    partial class CanGui
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
            this.SLblStatus = new System.Windows.Forms.Label();
            this.LblStatus = new System.Windows.Forms.Label();
            this.listTable = new System.Windows.Forms.ListView();
            this.chGroupName = new System.Windows.Forms.ColumnHeader();
            this.chEntryName = new System.Windows.Forms.ColumnHeader();
            this.chID = new System.Windows.Forms.ColumnHeader();
            this.chValue = new System.Windows.Forms.ColumnHeader();
            this.chTime = new System.Windows.Forms.ColumnHeader();
            this.lblStatusLeft = new System.Windows.Forms.Label();
            this.lblStatusRight = new System.Windows.Forms.Label();
            this.btFlush = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SLblStatus
            // 
            this.SLblStatus.AutoSize = true;
            this.SLblStatus.Location = new System.Drawing.Point(21, 143);
            this.SLblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SLblStatus.Name = "SLblStatus";
            this.SLblStatus.Size = new System.Drawing.Size(52, 17);
            this.SLblStatus.TabIndex = 2;
            this.SLblStatus.Text = "Status:";
            // 
            // LblStatus
            // 
            this.LblStatus.AutoSize = true;
            this.LblStatus.Location = new System.Drawing.Point(83, 143);
            this.LblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(0, 17);
            this.LblStatus.TabIndex = 3;
            // 
            // listTable
            // 
            this.listTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chGroupName,
            this.chEntryName,
            this.chID,
            this.chValue,
            this.chTime});
            this.listTable.FullRowSelect = true;
            this.listTable.GridLines = true;
            this.listTable.Location = new System.Drawing.Point(16, 117);
            this.listTable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listTable.MultiSelect = false;
            this.listTable.Name = "listTable";
            this.listTable.Size = new System.Drawing.Size(743, 516);
            this.listTable.TabIndex = 4;
            this.listTable.UseCompatibleStateImageBehavior = false;
            this.listTable.View = System.Windows.Forms.View.Details;
            // 
            // chGroupName
            // 
            this.chGroupName.Text = "Group Name";
            this.chGroupName.Width = 121;
            // 
            // chEntryName
            // 
            this.chEntryName.Text = "Entry Name";
            this.chEntryName.Width = 271;
            // 
            // chID
            // 
            this.chID.Text = "ID";
            // 
            // chValue
            // 
            this.chValue.Text = "Value";
            this.chValue.Width = 84;
            // 
            // chTime
            // 
            this.chTime.Text = "Time";
            this.chTime.Width = 200;
            // 
            // lblStatusLeft
            // 
            this.lblStatusLeft.AutoSize = true;
            this.lblStatusLeft.Location = new System.Drawing.Point(221, 15);
            this.lblStatusLeft.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatusLeft.Name = "lblStatusLeft";
            this.lblStatusLeft.Size = new System.Drawing.Size(52, 17);
            this.lblStatusLeft.TabIndex = 6;
            this.lblStatusLeft.Text = "Status:";
            // 
            // lblStatusRight
            // 
            this.lblStatusRight.AutoSize = true;
            this.lblStatusRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusRight.ForeColor = System.Drawing.Color.Red;
            this.lblStatusRight.Location = new System.Drawing.Point(269, 15);
            this.lblStatusRight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatusRight.Name = "lblStatusRight";
            this.lblStatusRight.Size = new System.Drawing.Size(123, 17);
            this.lblStatusRight.TabIndex = 7;
            this.lblStatusRight.Text = "NOT Connected";
            // 
            // btFlush
            // 
            this.btFlush.Location = new System.Drawing.Point(564, 64);
            this.btFlush.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btFlush.Name = "btFlush";
            this.btFlush.Size = new System.Drawing.Size(196, 46);
            this.btFlush.TabIndex = 8;
            this.btFlush.Text = "Flush";
            this.btFlush.UseVisualStyleBackColor = true;
            this.btFlush.Click += new System.EventHandler(this.btFlush_Click);
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(17, 15);
            this.btStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(196, 44);
            this.btStart.TabIndex = 9;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(17, 64);
            this.btStop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(196, 46);
            this.btStop.TabIndex = 10;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // CanGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 649);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.btFlush);
            this.Controls.Add(this.lblStatusRight);
            this.Controls.Add(this.lblStatusLeft);
            this.Controls.Add(this.listTable);
            this.Controls.Add(this.LblStatus);
            this.Controls.Add(this.SLblStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CanGui";
            this.Text = "Can Bus Logger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SLblStatus;
        private System.Windows.Forms.Label LblStatus;
        private System.Windows.Forms.ListView listTable;
        private System.Windows.Forms.ColumnHeader chGroupName;
        private System.Windows.Forms.ColumnHeader chID;
        private System.Windows.Forms.ColumnHeader chValue;
        private System.Windows.Forms.ColumnHeader chTime;
        private System.Windows.Forms.ColumnHeader chEntryName;
        private System.Windows.Forms.Label lblStatusLeft;
        private System.Windows.Forms.Label lblStatusRight;
        private System.Windows.Forms.Button btFlush;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btStop;
    }
}

