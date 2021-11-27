
namespace WindowsFormsAppgrepo
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.firstname = new System.Windows.Forms.Label();
            this.lastname = new System.Windows.Forms.Label();
            this.firstnamebox = new System.Windows.Forms.TextBox();
            this.lastnamebox = new System.Windows.Forms.TextBox();
            this.btnadd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(25, 24);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(154, 340);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // firstname
            // 
            this.firstname.AutoSize = true;
            this.firstname.Location = new System.Drawing.Point(195, 32);
            this.firstname.Name = "firstname";
            this.firstname.Size = new System.Drawing.Size(70, 17);
            this.firstname.TabIndex = 1;
            this.firstname.Text = "Firstname";
            // 
            // lastname
            // 
            this.lastname.AutoSize = true;
            this.lastname.Location = new System.Drawing.Point(195, 75);
            this.lastname.Name = "lastname";
            this.lastname.Size = new System.Drawing.Size(70, 17);
            this.lastname.TabIndex = 2;
            this.lastname.Text = "Lastname";
            // 
            // firstnamebox
            // 
            this.firstnamebox.Location = new System.Drawing.Point(271, 29);
            this.firstnamebox.Name = "firstnamebox";
            this.firstnamebox.Size = new System.Drawing.Size(133, 22);
            this.firstnamebox.TabIndex = 3;
            // 
            // lastnamebox
            // 
            this.lastnamebox.Location = new System.Drawing.Point(271, 72);
            this.lastnamebox.Name = "lastnamebox";
            this.lastnamebox.Size = new System.Drawing.Size(133, 22);
            this.lastnamebox.TabIndex = 4;
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(198, 117);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(206, 33);
            this.btnadd.TabIndex = 5;
            this.btnadd.Text = "button1";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 384);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.lastnamebox);
            this.Controls.Add(this.firstnamebox);
            this.Controls.Add(this.lastname);
            this.Controls.Add(this.firstname);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label firstname;
        private System.Windows.Forms.Label lastname;
        private System.Windows.Forms.TextBox firstnamebox;
        private System.Windows.Forms.TextBox lastnamebox;
        private System.Windows.Forms.Button btnadd;
    }
}

