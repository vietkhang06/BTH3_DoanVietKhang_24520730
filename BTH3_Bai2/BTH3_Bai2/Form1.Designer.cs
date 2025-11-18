namespace BTH3_Bai2
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
            this.btnRepaint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRepaint
            // 
            this.btnRepaint.Location = new System.Drawing.Point(314, 55);
            this.btnRepaint.Name = "btnRepaint";
            this.btnRepaint.Size = new System.Drawing.Size(140, 44);
            this.btnRepaint.TabIndex = 0;
            this.btnRepaint.Text = "Repaint";
            this.btnRepaint.UseVisualStyleBackColor = true;
            this.btnRepaint.Click += new System.EventHandler(this.btnRepaint_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRepaint);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRepaint;
    }
}

