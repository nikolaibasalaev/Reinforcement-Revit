using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void okButton_Click(object sender, System.EventArgs e)
        {
            if (IsReset)
            {
                m_instance.CreateCopies();

            }
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
        
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
