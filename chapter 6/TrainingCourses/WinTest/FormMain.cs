namespace WinTest
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        private async void buttonReload_Click(object sender, EventArgs e)
        {
            dataGridViewMain.DataSource = await Operation.GetCourses();
        }
        private async void dataGridViewMain_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewMain.RowCount > 0)
            {
                int id = (int)dataGridViewMain.CurrentRow.Cells[0].Value;
                var course = await Operation.GetCourses(id);
                toolStripStatusLabelId.Text = course.Id.ToString();
                toolStripStatusLabelRow.Text = course.Title;
            }
        }
        private async void buttonAdd_Click(object sender, EventArgs e)
        {
            //if (textBoxTitle.Text.Trim().Length==0)
            //{
            //    MessageBox.Show("Внесите наименование курса", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //if (textBoxHours.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show("Внесите количество часов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            int h;
            if (!int.TryParse(textBoxHours.Text.Trim(), out h))
            {
                MessageBox.Show("Внесите правильное количество часов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var course = new Course() { Title = textBoxTitle.Text.Trim(), Hours = h };
            var newId = await Operation.InsertCourse(course);
            if (newId > 0)
            {
                dataGridViewMain.DataSource = await Operation.GetCourses();
                MessageBox.Show("Добавление произведено успешно", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private async void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewMain.RowCount == 0)
            {
                MessageBox.Show("Записи для изменения не найдены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string title = dataGridViewMain.CurrentRow.Cells[1].Value?.ToString()?.Trim() ?? string.Empty;
            if (title.Length == 0)
            {
                MessageBox.Show("Внесите наименование курса", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int id = Convert.ToInt32(dataGridViewMain.CurrentRow.Cells[0].Value);
            int h = Convert.ToInt32(dataGridViewMain.CurrentRow.Cells[2].Value);
            var course = new Course() { Title = title, Hours = h };
            var IsUpdate = await Operation.UpdateCourse(id, course);
            if (IsUpdate)
            {
                dataGridViewMain.DataSource = await Operation.GetCourses();
                MessageBox.Show($"Изменение для {id}: {course.Title} произведено успешно", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }
        private async void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewMain.RowCount == 0)
            {
                MessageBox.Show("Записи для удаления не найдены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int id = Convert.ToInt32(dataGridViewMain.CurrentRow.Cells[0].Value);
            var IsDel = await Operation.DeleteCourse(id);
            if (IsDel)
            {
                dataGridViewMain.DataSource = await Operation.GetCourses();
                MessageBox.Show($"Удаление {id} произведено успешно", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void dataGridViewMain_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewMain.Columns[0].Visible = false;
        }
    }
}