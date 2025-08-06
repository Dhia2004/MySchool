namespace MySchool
{
    partial class ctrlSectionInfo
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
            this.lblCreatedByUser = new System.Windows.Forms.Label();
            this.lblGroupsCount = new System.Windows.Forms.Label();
            this.lblNumberOfSeats = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSectionID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCreatedByUser
            // 
            this.lblCreatedByUser.AutoSize = true;
            this.lblCreatedByUser.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedByUser.Location = new System.Drawing.Point(492, 7);
            this.lblCreatedByUser.Name = "lblCreatedByUser";
            this.lblCreatedByUser.Size = new System.Drawing.Size(130, 17);
            this.lblCreatedByUser.TabIndex = 126;
            this.lblCreatedByUser.Text = "DhiaEddine DJEDDI";
            // 
            // lblGroupsCount
            // 
            this.lblGroupsCount.AutoSize = true;
            this.lblGroupsCount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroupsCount.Location = new System.Drawing.Point(373, 7);
            this.lblGroupsCount.Name = "lblGroupsCount";
            this.lblGroupsCount.Size = new System.Drawing.Size(29, 17);
            this.lblGroupsCount.TabIndex = 124;
            this.lblGroupsCount.Text = "100";
            // 
            // lblNumberOfSeats
            // 
            this.lblNumberOfSeats.AutoSize = true;
            this.lblNumberOfSeats.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfSeats.Location = new System.Drawing.Point(264, 7);
            this.lblNumberOfSeats.Name = "lblNumberOfSeats";
            this.lblNumberOfSeats.Size = new System.Drawing.Size(36, 17);
            this.lblNumberOfSeats.TabIndex = 122;
            this.lblNumberOfSeats.Text = "1000";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(92, 7);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(47, 17);
            this.lblName.TabIndex = 121;
            this.lblName.Text = "Arabic";
            // 
            // lblSectionID
            // 
            this.lblSectionID.AutoSize = true;
            this.lblSectionID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSectionID.Location = new System.Drawing.Point(14, 7);
            this.lblSectionID.Name = "lblSectionID";
            this.lblSectionID.Size = new System.Drawing.Size(29, 17);
            this.lblSectionID.TabIndex = 120;
            this.lblSectionID.Text = "100";
            // 
            // ctrlSectionInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblCreatedByUser);
            this.Controls.Add(this.lblGroupsCount);
            this.Controls.Add(this.lblNumberOfSeats);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblSectionID);
            this.Name = "ctrlSectionInfo";
            this.Size = new System.Drawing.Size(653, 30);
            this.Load += new System.EventHandler(this.ctrlSectionInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCreatedByUser;
        private System.Windows.Forms.Label lblGroupsCount;
        private System.Windows.Forms.Label lblNumberOfSeats;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSectionID;
    }
}
