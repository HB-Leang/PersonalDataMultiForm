using System.Reflection;

namespace PersonalDataMultiForm
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            btnRefresh.Click += DoClickRefresh;
            btnNew.Click += DoClickNew;
            btnEdit.Click += DoClickEdit;
            btnDelete.Click += DoClickDelete;
            LoadPeople();
        }

        private void DoClickDelete(object? sender, EventArgs e)
        {
            if (dgvPeople.CurrentRow == null) return;
            Person? per = Program.people.FirstOrDefault(p => p.No == (int)dgvPeople.CurrentRow.Cells[0].Value);
            if(per == null) return;
            if (Program._editing.Contains(per)) {
                MessageBox.Show($"Person No : {per.No} is editing.", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            var result = MessageBox.Show($"Are you sure you want to delete Person No : {per.No} ?", "Deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            if(Program.people.Remove(per)) dgvPeople.Rows.Remove(dgvPeople.CurrentRow);

            
        }

        private void DoClickEdit(object? sender, EventArgs e)
        {
            if (dgvPeople.CurrentRow == null) return;
            Person? per = Program.people.FirstOrDefault(p => p.No == (int)dgvPeople.CurrentRow.Cells[0].Value);
            if(per == null) return;
            if(Program._editing.Contains(per))
            {
                MessageBox.Show("This person's edit page already open.", "Updating", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            EditForm edit = new EditForm(per);
            edit.UpdateCurPerson += DoOnUpdate;
            edit.Show();
            Program._editing.Add(per);
            edit.FormClosed += (sender, e) => Program._editing.Remove(per);
        }

        private void DoOnUpdate(EditForm sender, Person per)
        {
            foreach(DataGridViewRow row in dgvPeople.Rows)
            {
                if ((int)row.Cells[0].Value == per.No)
                {
                    row.SetValues(per.No, per.Name, per.Gender, per.Age);
                }
            }
        }

        private void DoClickRefresh(object? sender, EventArgs e)
        {
            dgvPeople.Rows.Clear();
            foreach (Person per in Program.people)
            {
                dgvPeople.Rows.Add(per.No, per.Name, per.Gender, per.Age.ToString());
            }
        }

        private void DoClickNew(object? sender, EventArgs e)
        {
            CreateForm frm = new CreateForm();
            frm.PersonCreated += (sender, per) =>
            {
                dgvPeople.Rows.Add(per.No, per.Name, per.Gender, per.Age);
            };
            frm.Show();
        }
        void ConfigGridView()
        {
            foreach(DataGridViewColumn col in dgvPeople.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                if(col.Name == "Column4")
                {
                    col.DefaultCellStyle.Format = "N0";
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }
        private void LoadPeople()
        {
            Program.people.Clear();
            string[] lines = File.ReadAllLines("people.txt");
            foreach (string line in lines)
            {
                string[] arr = line.Split("/");
                if (arr.Length < 3) continue;
                if (byte.TryParse(arr[2], out byte age) == false) continue;
                Person person = new Person(age, arr[0], arr[1]);
                Program.people.Add(person);

            }
        }
    }
}