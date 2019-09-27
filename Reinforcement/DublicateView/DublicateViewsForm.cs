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

        private DublicateViews m_dataBuffer;

        //private DublicateViews m_instance;
        /*
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
        }*/
        
        public DublicateViewsForm(DublicateViews dataBuffer)
        {

            InitializeComponent();
            m_dataBuffer = dataBuffer;
            
        }


        private void DublicateViewsForm_Load(object sender, EventArgs e)
        {
           // wallTypeComboBox.DataSource = m_dataBuffer.WallTypes;
           // wallTypeComboBox.DisplayMember = "Name";

           // structualCheckBox.Checked = m_dataBuffer.IsSturctual;
        }


        private void okButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (this.topMainRebarview.Checked)
                {
                   // m_dataBuffer.CreateDublicate(); 
                }
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch(Exception ex)
            {
                TaskDialog.Show("Revit", ex.Message);
            }
       
        }
        
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void topMainRebarview_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void bottomMainRebarView_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void topAdditionalRebarView_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void bottomAdditionalRebarView_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
