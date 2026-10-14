using System;
using System.IO;
using System.Windows.Forms;
class TextEditorForm : Form
{
    private TextBox txtBox;
    private MenuStrip menuStrip;
    public TextEditorForm()
    {
        this.Text = "Текстовый редактор";
        this.Width = 700;
        this.Height = 500;
        // Многострочное текстовое поле
        txtBox = new TextBox() { Dock = DockStyle.Fill, Multiline = true, ScrollBars = ScrollBars.Both };
        // Меню программы для работы с файлами
        menuStrip = new MenuStrip();
        ToolStripMenuItem fileMenu = new ToolStripMenuItem("Файл");
        ToolStripMenuItem openItem = new ToolStripMenuItem("Открыть");
        openItem.Click += (s, e) => {
            using (OpenFileDialog dlg = new OpenFileDialog() { Filter = "Текстовые файлы (*.txt)|*.txt" })
            {
                if (dlg.ShowDialog() == DialogResult.OK) txtBox.Text = File.ReadAllText(dlg.FileName);
            }
        };
        ToolStripMenuItem saveItem = new ToolStripMenuItem("Сохранить");
        saveItem.Click += (s, e) => {
            using (SaveFileDialog dlg = new SaveFileDialog() { Filter = "Текстовые файлы (*.txt)|*.txt" })
            {
                if (dlg.ShowDialog() == DialogResult.OK) File.WriteAllText(dlg.FileName, txtBox.Text);
            }
        };
        fileMenu.DropDownItems.Add(openItem);
        fileMenu.DropDownItems.Add(saveItem);
        menuStrip.Items.Add(fileMenu);
        this.MainMenuStrip = menuStrip;
        this.Controls.Add(txtBox);
        this.Controls.Add(menuStrip);
    }
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new TextEditorForm());
    }
    private MenuStrip menuStrip1;
    private ToolStripMenuItem открытьToolStripMenuItem;
    private ToolStripMenuItem сохранитьToolStripMenuItem;
    private TextBox textBox1;
    private void InitializeComponent()
    {
        this.menuStrip1 = new System.Windows.Forms.MenuStrip();
        this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.menuStrip1.SuspendLayout();
        this.SuspendLayout();
        // menuStrip1
        this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
        this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem});
        this.menuStrip1.Location = new System.Drawing.Point(0, 0);
        this.menuStrip1.Name = "menuStrip1";
        this.menuStrip1.Size = new System.Drawing.Size(534, 28);
        this.menuStrip1.TabIndex = 0;
        this.menuStrip1.Text = "menuStrip1";
 
        // открытьToolStripMenuItem
        this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
        this.открытьToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
        this.открытьToolStripMenuItem.Text = "открыть";
        // сохранитьToolStripMenuItem
        this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
        this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(95, 24);
        this.сохранитьToolStripMenuItem.Text = "сохранить";
        // textBox1
        this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.textBox1.Location = new System.Drawing.Point(0, 28);
        this.textBox1.Multiline = true;
        this.textBox1.Name = "textBox1";
        this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        this.textBox1.Size = new System.Drawing.Size(534, 326);
        this.textBox1.TabIndex = 1;
        this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
        // TextEditorForm
        this.ClientSize = new System.Drawing.Size(534, 354);
        this.Controls.Add(this.textBox1);
        this.Controls.Add(this.menuStrip1);
        this.MainMenuStrip = this.menuStrip1;
        this.Name = "TextEditorForm";
        this.menuStrip1.ResumeLayout(false);
        this.menuStrip1.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
     }
        private void textBox1_TextChanged(object sender, EventArgs e)
    {
      }
}