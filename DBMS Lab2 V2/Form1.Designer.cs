namespace DBMS_Lab2_V2
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
            this.GridFirst = new System.Windows.Forms.DataGridView();
            this.GridSecond = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GridFirst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSecond)).BeginInit();
            this.SuspendLayout();
            // 
            // GridFirst
            // 
            this.GridFirst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridFirst.Location = new System.Drawing.Point(12, 12);
            this.GridFirst.Name = "GridFirst";
            this.GridFirst.RowTemplate.Height = 24;
            this.GridFirst.Size = new System.Drawing.Size(776, 160);
            this.GridFirst.TabIndex = 0;
            this.GridFirst.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridFirst_CellContentClick);
            // 
            // GridSecond
            // 
            this.GridSecond.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridSecond.Location = new System.Drawing.Point(12, 258);
            this.GridSecond.Name = "GridSecond";
            this.GridSecond.RowTemplate.Height = 24;
            this.GridSecond.Size = new System.Drawing.Size(776, 180);
            this.GridSecond.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(160, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(502, 60);
            this.button1.TabIndex = 2;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.GridSecond);
            this.Controls.Add(this.GridFirst);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.GridFirst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSecond)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GridFirst;
        private System.Windows.Forms.DataGridView GridSecond;
        private System.Windows.Forms.Button button1;
    }
}

