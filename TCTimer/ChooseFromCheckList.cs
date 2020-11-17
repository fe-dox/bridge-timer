using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TCTimer
{
    // TODO: There is a very similar class in TC. Please merge them when integrating it with TC
    public sealed partial class ChooseFromCheckList<T> : Form
    {
        public ChooseFromCheckList(List<CheckListOption<T>> checklistElements, List<CheckListOption<T>> checkedElements,
            string windowTitle, string label, bool resetToDefault = false)
        {
            InitializeComponent();
            buttonResetToDefault.Visible = resetToDefault;
            buttonResetToDefault.Text = "Reset";
            foreach (var element in checklistElements)
            {
                checkedListBox.Items.Add(element, checkedElements?.Contains(element) ?? false);
            }

            Text = windowTitle;
            label1.Text = label;
            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";

            Height = Math.Min(350, 125 + 17 * checklistElements.Count);
        }

        public List<T> Selected => checkedListBox.CheckedItems.Cast<CheckListOption<T>>().Select(o => o.Value).ToList();

        public List<T> NotSelected => checkedListBox.Items.Cast<CheckListOption<T>>().Select(o => o.Value)
            .Except(Selected).ToList();

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void buttonResetToDefault_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;
        }
    }
}