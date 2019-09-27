namespace Reinforcement.DublicateView
{
    partial class DublicateViewsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; 
        /// otherwise, false.</param>
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCurView = new System.Windows.Forms.TextBox();
            this.Okbutton = new System.Windows.Forms.Button();
            this.cancelbutton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.topMainRebarview = new System.Windows.Forms.CheckBox();
            this.bottomMainRebarView = new System.Windows.Forms.CheckBox();
            this.topAdditionalRebarView = new System.Windows.Forms.CheckBox();
            this.bottomAdditionalRebarView = new System.Windows.Forms.CheckBox();
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
            // textBoxCurView
            // 
            this.textBoxCurView.Location = new System.Drawing.Point(107, 30);
            this.textBoxCurView.Name = "textBoxCurView";
            this.textBoxCurView.Size = new System.Drawing.Size(401, 20);
            this.textBoxCurView.TabIndex = 4;
            this.textBoxCurView.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
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
            // topMainRebarview
            // 
            this.topMainRebarview.AutoSize = true;
            this.topMainRebarview.Location = new System.Drawing.Point(34, 91);
            this.topMainRebarview.Name = "topMainRebarview";
            this.topMainRebarview.Size = new System.Drawing.Size(97, 17);
            this.topMainRebarview.TabIndex = 10;
            this.topMainRebarview.Text = "Top main rebar";
            this.topMainRebarview.UseVisualStyleBackColor = true;
            this.topMainRebarview.CheckedChanged += new System.EventHandler(this.topMainRebarview_CheckedChanged);
            // 
            // bottomMainRebarView
            // 
            this.bottomMainRebarView.AutoSize = true;
            this.bottomMainRebarView.Location = new System.Drawing.Point(34, 113);
            this.bottomMainRebarView.Name = "bottomMainRebarView";
            this.bottomMainRebarView.Size = new System.Drawing.Size(111, 17);
            this.bottomMainRebarView.TabIndex = 11;
            this.bottomMainRebarView.Text = "Bottom main rebar";
            this.bottomMainRebarView.UseVisualStyleBackColor = true;
            this.bottomMainRebarView.CheckedChanged += new System.EventHandler(this.bottomMainRebarView_CheckedChanged);
            // 
            // topAdditionalRebarView
            // 
            this.topAdditionalRebarView.AutoSize = true;
            this.topAdditionalRebarView.Location = new System.Drawing.Point(34, 136);
            this.topAdditionalRebarView.Name = "topAdditionalRebarView";
            this.topAdditionalRebarView.Size = new System.Drawing.Size(120, 17);
            this.topAdditionalRebarView.TabIndex = 12;
            this.topAdditionalRebarView.Text = "Top additional rebar";
            this.topAdditionalRebarView.UseVisualStyleBackColor = true;
            this.topAdditionalRebarView.CheckedChanged += new System.EventHandler(this.topAdditionalRebarView_CheckedChanged);
            // 
            // bottomAdditionalRebarView
            // 
            this.bottomAdditionalRebarView.AutoSize = true;
            this.bottomAdditionalRebarView.Location = new System.Drawing.Point(34, 159);
            this.bottomAdditionalRebarView.Name = "bottomAdditionalRebarView";
            this.bottomAdditionalRebarView.Size = new System.Drawing.Size(134, 17);
            this.bottomAdditionalRebarView.TabIndex = 13;
            this.bottomAdditionalRebarView.Text = "Bottom additional rebar";
            this.bottomAdditionalRebarView.UseVisualStyleBackColor = true;
            this.bottomAdditionalRebarView.CheckedChanged += new System.EventHandler(this.bottomAdditionalRebarView_CheckedChanged);
            // 
            // DublicateViewsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 228);
            this.Controls.Add(this.bottomAdditionalRebarView);
            this.Controls.Add(this.topAdditionalRebarView);
            this.Controls.Add(this.bottomMainRebarView);
            this.Controls.Add(this.topMainRebarview);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancelbutton);
            this.Controls.Add(this.Okbutton);
            this.Controls.Add(this.textBoxCurView);
            this.Controls.Add(this.label1);
            this.Name = "DublicateViewsForm";
            this.Text = "DublicateViewsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
       
         private System.Windows.Forms.Label label1;
         private System.Windows.Forms.TextBox textBoxCurView;
         private System.Windows.Forms.Button Okbutton;
         private System.Windows.Forms.Button cancelbutton;
         private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox topMainRebarview;
        private System.Windows.Forms.CheckBox bottomMainRebarView;
        private System.Windows.Forms.CheckBox topAdditionalRebarView;
        private System.Windows.Forms.CheckBox bottomAdditionalRebarView;
    }
}