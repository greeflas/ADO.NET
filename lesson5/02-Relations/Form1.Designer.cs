namespace _02_Relations
{
    partial class Form1
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
            this.dataGridViewRegions = new System.Windows.Forms.DataGridView();
            this.dataGridViewCities = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRegions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCities)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewRegions
            // 
            this.dataGridViewRegions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRegions.Location = new System.Drawing.Point(12, 29);
            this.dataGridViewRegions.Name = "dataGridViewRegions";
            this.dataGridViewRegions.Size = new System.Drawing.Size(552, 150);
            this.dataGridViewRegions.TabIndex = 0;
            // 
            // dataGridViewCities
            // 
            this.dataGridViewCities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCities.Location = new System.Drawing.Point(12, 208);
            this.dataGridViewCities.Name = "dataGridViewCities";
            this.dataGridViewCities.Size = new System.Drawing.Size(552, 150);
            this.dataGridViewCities.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Regions";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cities";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 371);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewCities);
            this.Controls.Add(this.dataGridViewRegions);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADO.NET";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRegions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCities)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewRegions;
        private System.Windows.Forms.DataGridView dataGridViewCities;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

