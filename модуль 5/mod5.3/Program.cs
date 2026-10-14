using System;
using System.Windows.Forms;
class TodoAppForm : Form
{
    private TextBox txtTask;
    private CheckedListBox checkedListBox;
    private Button btnAdd;
    private Button btnDelete;
    public TodoAppForm()
    {
        this.Text = "Учет задач";
        this.Width = 450;
        this.Height = 400;
        txtTask = new TextBox() { Left = 15, Top = 15, Width = 260 };
        btnAdd = new Button() { Text = "Добавить", Left = 285, Top = 13, Width = 130 };
        btnAdd.Click += (s, e) => {
            if (!string.IsNullOrWhiteSpace(txtTask.Text))
            {
                checkedListBox.Items.Add(txtTask.Text);
                txtTask.Clear();
            }
        };
        checkedListBox = new CheckedListBox() { Left = 15, Top = 55, Width = 400, Height = 230 };
        btnDelete = new Button() { Text = "Удалить выбранные", Left = 15, Top = 300, Width = 150 };
        btnDelete.Click += (s, e) => {
            for (int i = checkedListBox.Items.Count - 1; i >= 0; i--)
            {
                if (checkedListBox.GetItemChecked(i) || checkedListBox.SelectedIndex == i)
                {
                    checkedListBox.Items.RemoveAt(i);
                }
            }
        };
        this.Controls.Add(txtTask);
        this.Controls.Add(btnAdd);
        this.Controls.Add(checkedListBox);
        this.Controls.Add(btnDelete);
    }
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new TodoAppForm());
    }
    private TextBox textBox1;
    private Button button1;
    private CheckedListBox checkedListBox1;
    private Button button2;
    private void InitializeComponent()
    {
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.button1 = new System.Windows.Forms.Button();
        this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
        this.button2 = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // textBox1
        this.textBox1.Location = new System.Drawing.Point(172, 30);
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new System.Drawing.Size(152, 22);
        this.textBox1.TabIndex = 0;
        // button1
        this.button1.Location = new System.Drawing.Point(172, 73);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(152, 23);
        this.button1.TabIndex = 1;
        this.button1.Text = "добавить";
        this.button1.UseVisualStyleBackColor = true;
        // checkedListBox1
        this.checkedListBox1.FormattingEnabled = true;
        this.checkedListBox1.Location = new System.Drawing.Point(132, 134);
        this.checkedListBox1.Name = "checkedListBox1";
        this.checkedListBox1.Size = new System.Drawing.Size(657, 310);
        this.checkedListBox1.TabIndex = 2;
        this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
        // button2
        this.button2.Location = new System.Drawing.Point(172, 481);
        this.button2.Name = "button2";
        this.button2.Size = new System.Drawing.Size(152, 23);
        this.button2.TabIndex = 3;
        this.button2.Text = "удалить выбранные";
        this.button2.UseVisualStyleBackColor = true;
        // TodoAppForm
        this.ClientSize = new System.Drawing.Size(1049, 624);
        this.Controls.Add(this.button2);
        this.Controls.Add(this.checkedListBox1);
        this.Controls.Add(this.button1);
        this.Controls.Add(this.textBox1);
        this.Name = "TodoAppForm";
        this.Load += new System.EventHandler(this.TodoAppForm_Load);
        this.ResumeLayout(false);
        this.PerformLayout();
    }
    private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    private void TodoAppForm_Load(object sender, EventArgs e)
    {
    }
}
