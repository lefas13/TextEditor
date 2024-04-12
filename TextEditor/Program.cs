namespace TextEditor
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Создание динамического интерфейса
            Form form = new Form();
            form.Text = "Текстовый редактор";
            form.Size = new Size(500, 500);
            form.StartPosition = FormStartPosition.CenterScreen;

            // Добавление кнопок для открытия, сохранения и создания нового файла
            Button openBtn = new Button();
            openBtn.Text = "Открыть";
            openBtn.Location = new Point(10, 10);

            Button saveBtn = new Button();
            saveBtn.Text = "Сохранить";
            saveBtn.Location = new Point(100, 10);

            Button newBtn = new Button();
            newBtn.Text = "Новый";
            newBtn.Location = new Point(190, 10);

            // Добавление компонента для работы с текстом
            TextBox textBox = new TextBox();
            textBox.Multiline = true;
            textBox.Size = new Size(450, 400);
            textBox.Location = new Point(10, 50);
            textBox.ReadOnly = false;

            // Добавление событий с помощью лямбда-выражений
            openBtn.Click += (sender, e) =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName; 
                    textBox.Text = File.ReadAllText(fileName); // код для открытия файла
                }
            };
            saveBtn.Click += (sender, e) =>
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName; // код для сохранения файла
                    File.WriteAllText(fileName, textBox.Text);
                }
            };
            newBtn.Click += (sender, e) =>
            {
                textBox.Clear(); // очистка текстового поля
            };

            // Добавление событий с помощью методов, реализующих делегат
            textBox.TextChanged += new EventHandler(textBox_TextChanged);
            void textBox_TextChanged(object sender, EventArgs e)
            {
                if (textBox.Text.Contains("сохранить") || textBox.Text.Contains("Cохранить") || textBox.Text.Contains("save") || textBox.Text.Contains("Save"))
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string fileName = saveFileDialog.FileName;
                        File.WriteAllText(fileName, textBox.Text);
                    }
                }
                else if (textBox.Text.Contains("открыть") || textBox.Text.Contains("Открыть") || textBox.Text.Contains("open") || textBox.Text.Contains("Open"))
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string fileName = openFileDialog.FileName;
                        textBox.Text = File.ReadAllText(fileName);
                    }
                }
                else if (textBox.Text.Contains("новый") || textBox.Text.Contains("Новый") || textBox.Text.Contains("new") || textBox.Text.Contains("New"))
                {
                    textBox.Clear();
                }
            }

            // Добавление компонентов на форму
            form.Controls.Add(openBtn);
            form.Controls.Add(saveBtn);
            form.Controls.Add(newBtn);
            form.Controls.Add(textBox);

            // Отображение формы
            Application.Run(form);
        }
    }
}