namespace MySchool
{
    partial class ctrlGroupInfo
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
            this.lblMaxSeatsNumber = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblGroupID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCreatedByUser
            // 
            this.lblCreatedByUser.AutoSize = true;
            this.lblCreatedByUser.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedByUser.Location = new System.Drawing.Point(381, 7);
            this.lblCreatedByUser.Name = "lblCreatedByUser";
            this.lblCreatedByUser.Size = new System.Drawing.Size(130, 17);
            this.lblCreatedByUser.TabIndex = 131;
            this.lblCreatedByUser.Text = "DhiaEddine DJEDDI";
            // 
            // lblMaxSeatsNumber
            // 
            this.lblMaxSeatsNumber.AutoSize = true;
            this.lblMaxSeatsNumber.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxSeatsNumber.Location = new System.Drawing.Point(272, 7);
            this.lblMaxSeatsNumber.Name = "lblMaxSeatsNumber";
            this.lblMaxSeatsNumber.Size = new System.Drawing.Size(36, 17);
            this.lblMaxSeatsNumber.TabIndex = 129;
            this.lblMaxSeatsNumber.Text = "1000";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(100, 7);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(47, 17);
            this.lblName.TabIndex = 128;
            this.lblName.Text = "Arabic";
            // 
            // lblGroupID
            // 
            this.lblGroupID.AutoSize = true;
            this.lblGroupID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroupID.Location = new System.Drawing.Point(22, 7);
            this.lblGroupID.Name = "lblGroupID";
            this.lblGroupID.Size = new System.Drawing.Size(29, 17);
            this.lblGroupID.TabIndex = 127;
            this.lblGroupID.Text = "100";
            // 
            // ctrlGroupInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblCreatedByUser);
            this.Controls.Add(this.lblMaxSeatsNumber);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblGroupID);
            this.Name = "ctrlGroupInfo";
            this.Size = new System.Drawing.Size(530, 30);
            this.Load += new System.EventHandler(this.ctrlGroupInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCreatedByUser;
        private System.Windows.Forms.Label lblMaxSeatsNumber;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblGroupID;
    }
}
