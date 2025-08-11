namespace MySchool
{
    partial class ctrlTeacherInfo
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblTeacherID = new System.Windows.Forms.Label();
            this.lblPersonID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCreatedByUser
            // 
            this.lblCreatedByUser.AutoSize = true;
            this.lblCreatedByUser.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedByUser.Location = new System.Drawing.Point(617, 7);
            this.lblCreatedByUser.Name = "lblCreatedByUser";
            this.lblCreatedByUser.Size = new System.Drawing.Size(130, 17);
            this.lblCreatedByUser.TabIndex = 131;
            this.lblCreatedByUser.Text = "DhiaEddine DJEDDI";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(518, 7);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(46, 17);
            this.lblStatus.TabIndex = 130;
            this.lblStatus.Text = "Active";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubject.Location = new System.Drawing.Point(386, 7);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(47, 17);
            this.lblSubject.TabIndex = 129;
            this.lblSubject.Text = "Arabic";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(177, 7);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(130, 17);
            this.lblName.TabIndex = 128;
            this.lblName.Text = "DhiaEddine DJEDDI";
            // 
            // lblTeacherID
            // 
            this.lblTeacherID.AutoSize = true;
            this.lblTeacherID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeacherID.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTeacherID.Location = new System.Drawing.Point(12, 7);
            this.lblTeacherID.Name = "lblTeacherID";
            this.lblTeacherID.Size = new System.Drawing.Size(29, 17);
            this.lblTeacherID.TabIndex = 127;
            this.lblTeacherID.Text = "100";
            // 
            // lblPersonID
            // 
            this.lblPersonID.AutoSize = true;
            this.lblPersonID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonID.ForeColor = System.Drawing.Color.Red;
            this.lblPersonID.Location = new System.Drawing.Point(85, 7);
            this.lblPersonID.Name = "lblPersonID";
            this.lblPersonID.Size = new System.Drawing.Size(29, 17);
            this.lblPersonID.TabIndex = 132;
            this.lblPersonID.Text = "100";
            // 
            // ctrlTeacherInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblPersonID);
            this.Controls.Add(this.lblCreatedByUser);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblTeacherID);
            this.Name = "ctrlTeacherInfo";
            this.Size = new System.Drawing.Size(775, 30);
            this.Load += new System.EventHandler(this.ctrlTeacherInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCreatedByUser;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblTeacherID;
        private System.Windows.Forms.Label lblPersonID;
    }
}
