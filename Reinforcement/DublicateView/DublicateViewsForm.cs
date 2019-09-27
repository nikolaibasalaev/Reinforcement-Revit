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
        
        public DublicateViewsForm(DublicateViews dataBuffer)
        {

            InitializeComponent();
            m_dataBuffer = dataBuffer;
            
        }
        
        private void DublicateViewsForm_Load(object sender, EventArgs e)
        {
            //textBoxCurView.Text = "1244";
           textBoxCurView.Text = m_dataBuffer.currentViewName;
            
            // structualCheckBox.Checked = m_dataBuffer.IsSturctual;
        }
        
        private void okButton_Click(object sender, System.EventArgs e)
        {
            m_dataBuffer.topRebarView = topMainRebarview.Checked;
            m_dataBuffer.bottomRebarView = bottomMainRebarView.Checked;
            m_dataBuffer.topAddRebarView = topAdditionalRebarView.Checked;
            m_dataBuffer.bottomAddRebarView = bottomAdditionalRebarView.Checked;

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
