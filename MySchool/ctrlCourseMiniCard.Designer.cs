namespace MySchool
{
    partial class ctrlCourseMiniCard
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
            this.btnSelect = new System.Windows.Forms.Button();
            this.lblTeacherName = new System.Windows.Forms.Label();
            this.lblCourseName = new System.Windows.Forms.Label();
            this.pbTeacherImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbTeacherImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.White;
            this.btnSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelect.FlatAppearance.BorderSize = 0;
            this.btnSelect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.Image = global::MySchool.Properties.Resources.Select_32;
            this.btnSelect.Location = new System.Drawing.Point(220, 8);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(33, 33);
            this.btnSelect.TabIndex = 149;
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click_1);
            // 
            // lblTeacherName
            // 
            this.lblTeacherName.AutoSize = true;
            this.lblTeacherName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeacherName.Location = new System.Drawing.Point(53, 28);
            this.lblTeacherName.Name = "lblTeacherName";
            this.lblTeacherName.Size = new System.Drawing.Size(130, 17);
            this.lblTeacherName.TabIndex = 148;
            this.lblTeacherName.Text = "DhiaEddine DJEDDI";
            // 
            // lblCourseName
            // 
            this.lblCourseName.AutoSize = true;
            this.lblCourseName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourseName.Location = new System.Drawing.Point(53, 6);
            this.lblCourseName.Name = "lblCourseName";
            this.lblCourseName.Size = new System.Drawing.Size(47, 17);
            this.lblCourseName.TabIndex = 147;
            this.lblCourseName.Text = "Arabic";
            // 
            // pbTeacherImage
            // 
            this.pbTeacherImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbTeacherImage.Location = new System.Drawing.Point(0, 0);
            this.pbTeacherImage.Name = "pbTeacherImage";
            this.pbTeacherImage.Size = new System.Drawing.Size(47, 50);
            this.pbTeacherImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTeacherImage.TabIndex = 146;
            this.pbTeacherImage.TabStop = false;
            // 
            // ctrlCourseMiniCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.lblTeacherName);
            this.Controls.Add(this.lblCourseName);
            this.Controls.Add(this.pbTeacherImage);
            this.Name = "ctrlCourseMiniCard";
            this.Size = new System.Drawing.Size(262, 50);
            this.Load += new System.EventHandler(this.ctrlCourseMiniCard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTeacherImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label lblTeacherName;
        private System.Windows.Forms.Label lblCourseName;
        private System.Windows.Forms.PictureBox pbTeacherImage;
    }
}
