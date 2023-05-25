using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace OOPLab4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PaintBox = new System.Windows.Forms.Panel();
            this.checkBoxCtrl = new System.Windows.Forms.CheckBox();
            this.checkBoxCollision = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // PaintBox
            // 
            this.PaintBox.Location = new System.Drawing.Point(78, 77);
            this.PaintBox.Name = "PaintBox";
            this.PaintBox.Size = new System.Drawing.Size(566, 312);
            this.PaintBox.TabIndex = 0;
            this.PaintBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintBox_Paint);
            this.PaintBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PaintBox_MouseClick);
            // 
            // checkBoxCtrl
            // 
            this.checkBoxCtrl.AutoSize = true;
            this.checkBoxCtrl.Location = new System.Drawing.Point(79, 32);
            this.checkBoxCtrl.Name = "checkBoxCtrl";
            this.checkBoxCtrl.Size = new System.Drawing.Size(102, 24);
            this.checkBoxCtrl.TabIndex = 1;
            this.checkBoxCtrl.Text = "Ctrl Button";
            this.checkBoxCtrl.UseVisualStyleBackColor = true;
            this.checkBoxCtrl.CheckedChanged += new System.EventHandler(this.checkBoxCtrl_CheckedChanged);
            // 
            // checkBoxCollision
            // 
            this.checkBoxCollision.AutoSize = true;
            this.checkBoxCollision.Location = new System.Drawing.Point(187, 32);
            this.checkBoxCollision.Name = "checkBoxCollision";
            this.checkBoxCollision.Size = new System.Drawing.Size(145, 24);
            this.checkBoxCollision.TabIndex = 2;
            this.checkBoxCollision.Text = "Multiple collision";
            this.checkBoxCollision.UseVisualStyleBackColor = true;
            this.checkBoxCollision.CheckedChanged += new System.EventHandler(this.checkBoxCollision_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBoxCollision);
            this.Controls.Add(this.checkBoxCtrl);
            this.Controls.Add(this.PaintBox);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel PaintBox;
        private CheckBox checkBoxCtrl;
        private CheckBox checkBoxCollision;
    }
}