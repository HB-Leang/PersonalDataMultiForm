using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalDataMultiForm
{
    public delegate void UpdatedHandler(EditForm sender, Person per);
    public partial class EditForm : Form
    {
        Person _curPer = default!;
        public event UpdatedHandler? UpdateCurPerson;

        public EditForm(Person per)
        {

            InitializeComponent();
            _curPer = per;
            cmbGender.DataSource = new String[] { "Male", "Female" };
            LoadCurPerson();
            btnUpdate.Click += DoClicKUpdate;
            btnCancel.Click += DoClickCancel;
        }

        private void DoClickCancel(object? sender, EventArgs e)
        {
            Program._editing.Remove(_curPer);
            this.Dispose();
        }

        void LoadCurPerson()
        {
            txtNo.Text = _curPer.No.ToString();
            txtName.Text = _curPer.Name;
            txtAge.Text = _curPer.Age.ToString();
            cmbGender.SelectedItem = _curPer.Gender;
        }

        private void DoClicKUpdate(object? sender, EventArgs e)
        {
            if (byte.TryParse(txtAge.Text, out byte age) == false)
            {
                MessageBox.Show("Invalid Age.", "Updating", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _curPer.Name = txtName.Text;
            _curPer.Gender = cmbGender.SelectedItem.ToString()!;
            _curPer.Age = age;
            UpdateCurPerson!.Invoke(this, _curPer);
            MessageBox.Show($"Person No {_curPer.No}\'s Info Updated", "Updating", MessageBoxButtons.OK);
        }

        private void EditForm_Load(object sender, EventArgs e)
        {

        }
    }
}
