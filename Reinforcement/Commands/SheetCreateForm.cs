﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reinforcement
{
    public partial class SheetCreateForm : Form
    {
        public SheetCreateForm(ViewsMgr data)
        {
            m_data = data;
            InitializeComponent();
        }
        private void AllViewsForm_Load(object sender, EventArgs e)
        {
            foreach (string s in m_data.AllTitleBlocksNames)
            {
                titleBlocksListBox.Items.Add(s);
            }
        }

        private void oKButton_Click(object sender, EventArgs e)
        {
           // m_data.SelectViews();
            m_data.SheetName = sheetNameTextBox.Text;

            if (1 == titleBlocksListBox.SelectedItems.Count)
            {
                string titleBlock = titleBlocksListBox.SelectedItems[0].ToString();
                m_data.ChooseTitleBlock(titleBlock);
            }
        }
        #region CheckTreeNode
        private void CheckNode(TreeNode node, bool check)
        {
            if (0 < node.Nodes.Count)
            {
                if (node.Checked)
                {
                    node.Expand();
                }
                else
                {
                    node.Collapse();
                }

                foreach (TreeNode t in node.Nodes)
                {
                    t.Checked = check;
                    CheckNode(t, check);
                }
            }
        }
        private void allViewsTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            CheckNode(e.Node, e.Node.Checked);
        }
        #endregion

        /// <summary>
        /// Select title block to generate sheet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void titleBlocksListBox_MouseClick(object sender, MouseEventArgs e)
        {
            int idx = titleBlocksListBox.SelectedIndex;
            if (0 < idx)
            {
                titleBlocksListBox.SetSelected(idx, true);
            }
        }

    }
}
