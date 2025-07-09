namespace MySchool
{
    partial class ctrlTeacherMiniCard
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
            this.pbTeacherImage = new System.Windows.Forms.PictureBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbTeacherImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbTeacherImage
            // 
            this.pbTeacherImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbTeacherImage.Location = new System.Drawing.Point(0, 0);
            this.pbTeacherImage.Name = "pbTeacherImage";
            this.pbTeacherImage.Size = new System.Drawing.Size(47, 50);
            this.pbTeacherImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTeacherImage.TabIndex = 1;
            this.pbTeacherImage.TabStop = false;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.Location = new System.Drawing.Point(53, 6);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(134, 17);
            this.lblFullName.TabIndex = 113;
            this.lblFullName.Text = "Dhia Eddine DJEDDI";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubject.Location = new System.Drawing.Point(53, 28);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(76, 17);
            this.lblSubject.TabIndex = 116;
            this.lblSubject.Text = "24/01/2004";
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
            this.btnSelect.TabIndex = 145;
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // ctrlTeacherMiniCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.pbTeacherImage);
            this.Name = "ctrlTeacherMiniCard";
            this.Size = new System.Drawing.Size(262, 50);
            ((System.ComponentModel.ISupportInitialize)(this.pbTeacherImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbTeacherImage;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Button btnSelect;
    }
}
