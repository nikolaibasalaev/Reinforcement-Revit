using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Autodesk.Revit.UI;

namespace Reinforcement.DublicateView
{
    public partial class DublicateViewsForm : Form
    {
        private DublicateViews m_instance;
        private System.ComponentModel.Container m_components = null;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        public System.Windows.Forms.RadioButton topRebarRadio;
        public System.Windows.Forms.RadioButton bottomRebarRadio;
        public System.Windows.Forms.RadioButton topAddRebarRadio;
        public System.Windows.Forms.RadioButton bottomAddRebarRadio;
        private System.Windows.Forms.Label viewLabel;
        public System.Windows.Forms.TextBox viewTextBox;
        private bool m_isReset;

        public bool IsReset
        {
            get
            {
                return m_isReset;
            }
            set
            {
                m_isReset = value;
            }
        }

        public DublicateViewsForm(DublicateViews Inst)
        {
            m_isReset = false;
            m_instance = Inst;
            if (null == m_instance)
              {
                  TaskDialog.Show("Revit", "Load Application Failed");
              }
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (m_components != null)
                {
                    m_components.Dispose();
                }
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
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonTopRebar = new System.Windows.Forms.RadioButton();
            this.radioButtonBottomRebar = new System.Windows.Forms.RadioButton();
            this.textBoxCurView = new System.Windows.Forms.TextBox();
            this.radioButtonBottomAdd = new System.Windows.Forms.RadioButton();
            this.radioButtonTopAdd = new System.Windows.Forms.RadioButton();
            this.Okbutton = new System.Windows.Forms.Button();
            this.cancelbutton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current View:";
            // 
            // radioButtonTopRebar
            // 
            this.radioButtonTopRebar.AutoSize = true;
            this.radioButtonTopRebar.Location = new System.Drawing.Point(34, 101);
            this.radioButtonTopRebar.Name = "radioButtonTopRebar";
            this.radioButtonTopRebar.Size = new System.Drawing.Size(101, 17);
            this.radioButtonTopRebar.TabIndex = 2;
            this.radioButtonTopRebar.TabStop = true;
            this.radioButtonTopRebar.Text = "Top main rebars";
            this.radioButtonTopRebar.UseVisualStyleBackColor = true;
            // 
            // radioButtonBottomRebar
            // 
            this.radioButtonBottomRebar.AutoSize = true;
            this.radioButtonBottomRebar.Location = new System.Drawing.Point(34, 124);
            this.radioButtonBottomRebar.Name = "radioButtonBottomRebar";
            this.radioButtonBottomRebar.Size = new System.Drawing.Size(115, 17);
            this.radioButtonBottomRebar.TabIndex = 3;
            this.radioButtonBottomRebar.TabStop = true;
            this.radioButtonBottomRebar.Text = "Bottom main rebars";
            this.radioButtonBottomRebar.UseVisualStyleBackColor = true;
            // 
            // textBoxCurView
            // 
            this.textBoxCurView.Location = new System.Drawing.Point(107, 30);
            this.textBoxCurView.Name = "textBoxCurView";
            this.textBoxCurView.Size = new System.Drawing.Size(401, 20);
            this.textBoxCurView.TabIndex = 4;
            this.textBoxCurView.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // radioButtonBottomAdd
            // 
            this.radioButtonBottomAdd.AutoSize = true;
            this.radioButtonBottomAdd.Location = new System.Drawing.Point(34, 170);
            this.radioButtonBottomAdd.Name = "radioButtonBottomAdd";
            this.radioButtonBottomAdd.Size = new System.Drawing.Size(138, 17);
            this.radioButtonBottomAdd.TabIndex = 5;
            this.radioButtonBottomAdd.TabStop = true;
            this.radioButtonBottomAdd.Text = "Bottom additional rebars";
            this.radioButtonBottomAdd.UseVisualStyleBackColor = true;
            // 
            // radioButtonTopAdd
            // 
            this.radioButtonTopAdd.AutoSize = true;
            this.radioButtonTopAdd.Location = new System.Drawing.Point(34, 147);
            this.radioButtonTopAdd.Name = "radioButtonTopAdd";
            this.radioButtonTopAdd.Size = new System.Drawing.Size(124, 17);
            this.radioButtonTopAdd.TabIndex = 6;
            this.radioButtonTopAdd.TabStop = true;
            this.radioButtonTopAdd.Text = "Top additional rebars";
            this.radioButtonTopAdd.UseVisualStyleBackColor = true;
            // 
            // Okbutton
            // 
            this.Okbutton.Location = new System.Drawing.Point(352, 188);
            this.Okbutton.Name = "Okbutton";
            this.Okbutton.Size = new System.Drawing.Size(75, 23);
            this.Okbutton.TabIndex = 7;
            this.Okbutton.Text = "OK";
            this.Okbutton.UseVisualStyleBackColor = true;
            // 
            // cancelbutton
            // 
            this.cancelbutton.Location = new System.Drawing.Point(433, 188);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(75, 23);
            this.cancelbutton.TabIndex = 8;
            this.cancelbutton.Text = "Cancel";
            this.cancelbutton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Views to create:";
            // 
            // DublicateViewsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 228);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancelbutton);
            this.Controls.Add(this.Okbutton);
            this.Controls.Add(this.radioButtonTopAdd);
            this.Controls.Add(this.radioButtonBottomAdd);
            this.Controls.Add(this.textBoxCurView);
            this.Controls.Add(this.radioButtonBottomRebar);
            this.Controls.Add(this.radioButtonTopRebar);
            this.Controls.Add(this.label1);
            this.Name = "DublicateViewsForm";
            this.Text = "DublicateViewsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private void okButton_Click(object sender, System.EventArgs e)
        {
            if (IsReset)
            {
               // m_instance.RotateElement();

            }
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void cancelButton_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }

        private void singleRadio_CheckedChanged(object sender, System.EventArgs e)
        {
            m_isReset = true;
            m_instance.topRebarView = true;
        }

        private void singleRadio_CheckedChanged1(object sender, System.EventArgs e)
        {
            m_isReset = true;
            m_instance.bottomRebarView = true;
        }

        private void singleRadio_CheckedChanged2(object sender, System.EventArgs e)
        {
            m_isReset = true;
            m_instance.topAddRebarView = true;
        }

        private void singleRadio_CheckedChanged3(object sender, System.EventArgs e)
        {
            m_isReset = true;
            m_instance.bottomAddRebarView = true;
        }



         private System.Windows.Forms.Label label1;
         private System.Windows.Forms.RadioButton radioButtonTopRebar;
         private System.Windows.Forms.RadioButton radioButtonBottomRebar;
         private System.Windows.Forms.TextBox textBoxCurView;
         private System.Windows.Forms.RadioButton radioButtonBottomAdd;
         private System.Windows.Forms.RadioButton radioButtonTopAdd;
         private System.Windows.Forms.Button Okbutton;
         private System.Windows.Forms.Button cancelbutton;
         private System.Windows.Forms.Label label2;
    }
}