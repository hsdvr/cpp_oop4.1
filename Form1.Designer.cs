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
            this.setFigure = new System.Windows.Forms.ComboBox();
            this.setColor = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // PaintBox
            // 
            this.PaintBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PaintBox.AutoSize = true;
            this.PaintBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PaintBox.Location = new System.Drawing.Point(56, 53);
            this.PaintBox.Margin = new System.Windows.Forms.Padding(2);
            this.PaintBox.Name = "PaintBox";
            this.PaintBox.Size = new System.Drawing.Size(635, 447);
            this.PaintBox.TabIndex = 0;
            this.PaintBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintBox_Paint);
            this.PaintBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PaintBox_MouseClick);
            this.PaintBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PaintBox_MouseMove);
            this.PaintBox.Resize += new System.EventHandler(this.PaintBox_Resize);
            // 
            // checkBoxCtrl
            // 
            this.checkBoxCtrl.AutoSize = true;
            this.checkBoxCtrl.Location = new System.Drawing.Point(59, 21);
            this.checkBoxCtrl.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxCtrl.Name = "checkBoxCtrl";
            this.checkBoxCtrl.Size = new System.Drawing.Size(75, 17);
            this.checkBoxCtrl.TabIndex = 1;
            this.checkBoxCtrl.Text = "Ctrl Button";
            this.checkBoxCtrl.UseVisualStyleBackColor = true;
            this.checkBoxCtrl.CheckedChanged += new System.EventHandler(this.checkBoxCtrl_CheckedChanged);
            // 
            // checkBoxCollision
            // 
            this.checkBoxCollision.AutoSize = true;
            this.checkBoxCollision.Location = new System.Drawing.Point(140, 21);
            this.checkBoxCollision.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxCollision.Name = "checkBoxCollision";
            this.checkBoxCollision.Size = new System.Drawing.Size(102, 17);
            this.checkBoxCollision.TabIndex = 2;
            this.checkBoxCollision.Text = "Multiple collision";
            this.checkBoxCollision.UseVisualStyleBackColor = true;
            this.checkBoxCollision.CheckedChanged += new System.EventHandler(this.checkBoxCollision_CheckedChanged);
            // 
            // setFigure
            // 
            this.setFigure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.setFigure.FormattingEnabled = true;
            this.setFigure.Location = new System.Drawing.Point(412, 10);
            this.setFigure.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.setFigure.Name = "setFigure";
            this.setFigure.Size = new System.Drawing.Size(104, 21);
            this.setFigure.TabIndex = 3;
            this.setFigure.SelectedIndexChanged += new System.EventHandler(this.setFigure_SelectedIndexChanged);
            // 
            // setColor
            // 
            this.setColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.setColor.FormattingEnabled = true;
            this.setColor.Location = new System.Drawing.Point(295, 10);
            this.setColor.Margin = new System.Windows.Forms.Padding(2);
            this.setColor.Name = "setColor";
            this.setColor.Size = new System.Drawing.Size(114, 21);
            this.setColor.TabIndex = 4;
            this.setColor.SelectedIndexChanged += new System.EventHandler(this.setColor_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 527);
            this.Controls.Add(this.setColor);
            this.Controls.Add(this.setFigure);
            this.Controls.Add(this.checkBoxCollision);
            this.Controls.Add(this.checkBoxCtrl);
            this.Controls.Add(this.PaintBox);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private ComboBox setFigure;
        private ComboBox setColor;
    }
}