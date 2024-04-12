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
            // �������� ������������� ����������
            Form form = new Form();
            form.Text = "��������� ��������";
            form.Size = new Size(500, 500);
            form.StartPosition = FormStartPosition.CenterScreen;

            // ���������� ������ ��� ��������, ���������� � �������� ������ �����
            Button openBtn = new Button();
            openBtn.Text = "�������";
            openBtn.Location = new Point(10, 10);

            Button saveBtn = new Button();
            saveBtn.Text = "���������";
            saveBtn.Location = new Point(100, 10);

            Button newBtn = new Button();
            newBtn.Text = "�����";
            newBtn.Location = new Point(190, 10);

            // ���������� ���������� ��� ������ � �������
            TextBox textBox = new TextBox();
            textBox.Multiline = true;
            textBox.Size = new Size(450, 400);
            textBox.Location = new Point(10, 50);
            textBox.ReadOnly = false;

            // ���������� ������� � ������� ������-���������
            openBtn.Click += (sender, e) =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName; 
                    textBox.Text = File.ReadAllText(fileName); // ��� ��� �������� �����
                }
            };
            saveBtn.Click += (sender, e) =>
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName; // ��� ��� ���������� �����
                    File.WriteAllText(fileName, textBox.Text);
                }
            };
            newBtn.Click += (sender, e) =>
            {
                textBox.Clear(); // ������� ���������� ����
            };

            // ���������� ������� � ������� �������, ����������� �������
            textBox.TextChanged += new EventHandler(textBox_TextChanged);
            void textBox_TextChanged(object sender, EventArgs e)
            {
                if (textBox.Text.Contains("���������") || textBox.Text.Contains("C��������") || textBox.Text.Contains("save") || textBox.Text.Contains("Save"))
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string fileName = saveFileDialog.FileName;
                        File.WriteAllText(fileName, textBox.Text);
                    }
                }
                else if (textBox.Text.Contains("�������") || textBox.Text.Contains("�������") || textBox.Text.Contains("open") || textBox.Text.Contains("Open"))
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string fileName = openFileDialog.FileName;
                        textBox.Text = File.ReadAllText(fileName);
                    }
                }
                else if (textBox.Text.Contains("�����") || textBox.Text.Contains("�����") || textBox.Text.Contains("new") || textBox.Text.Contains("New"))
                {
                    textBox.Clear();
                }
            }

            // ���������� ����������� �� �����
            form.Controls.Add(openBtn);
            form.Controls.Add(saveBtn);
            form.Controls.Add(newBtn);
            form.Controls.Add(textBox);

            // ����������� �����
            Application.Run(form);
        }
    }
}