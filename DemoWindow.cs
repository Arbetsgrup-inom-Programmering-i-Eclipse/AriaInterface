using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AriaInterfaceDemo
{
    public partial class DemoWindow : Form
    {
        private class SQLCommandParameter
        {
            public string ParameterName { get; set; }
            public string Value { get; set; }
        }

        public DemoWindow()
        {
            InitializeComponent();

            dataGridViewParameters.DataSource = new BindingList<SQLCommandParameter>();
            comboBoxDatabase.Items.AddRange(Enum.GetNames(typeof(AriaDatabase)));
            comboBoxDatabase.SelectedItem = AriaDatabase.TBox.ToString();
        }

        private void ButtonQuery_Click(object sender, EventArgs e)
        {            
            dataGridViewResult.DataSource = AriaInterface.QueryWithErrorMessage(
                (AriaDatabase)Enum.Parse(typeof(AriaDatabase), 
                (string)comboBoxDatabase.SelectedItem), 
                textBoxSQLquery.Text, 
                ((BindingList<SQLCommandParameter>)dataGridViewParameters.DataSource).Select(p => (p.ParameterName, (object)p.Value)).ToArray()
                );
        }
        
        private void DataGridViewResult_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void TextBoxSQLquery_TextChanged(object sender, EventArgs e)
        {
            buttonQuery.Enabled = textBoxSQLquery.Text.Length > 0;
        }
    }
}
