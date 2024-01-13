using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalDataMultiForm
{
    public partial class CreateForm : Form
    {
        public CreateForm()
        {
            InitializeComponent();
            cmbGender.DataSource = new String[] { "Male", "Female" };

            btnCreate.Click += DoClickCreate;
        }

        private void DoClickCreate(object? sender, EventArgs e)
        {
            if (txtName.Text == null) return;
            if (byte.TryParse(txtAge.Text, out byte age) == false)
            {
                MessageBox.Show("Invalid Age", "Creating", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            Person person = new Person(age, txtName.Text, cmbGender.SelectedItem.ToString()!);

            Program.people.Add(person);


            PersonCreated?.Invoke(this, person);
        }

        private void CreateForm_Load(object sender, EventArgs e)
        {

        }

        public event PersonEventHandler? PersonCreated;
    }
}
