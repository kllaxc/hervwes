using System;
using System.Drawing;
using System.Windows.Forms;

namespace mod5._1
{
    // Интерфейс "Рисунок" с методами для рисования линий, кругов и прямоугольников
    public interface IDrawingCanvas
    {
        void DrawLine(Graphics g, Pen pen, Point start, Point end);
        void DrawCircle(Graphics g, Pen pen, Rectangle rect);
        void DrawRectangle(Graphics g, Pen pen, Rectangle rect);
    }

    // Реализация интерфейса в классе для работы с холстом
    public class CanvasRenderer : IDrawingCanvas
    {
        public void DrawLine(Graphics g, Pen pen, Point start, Point end) => g.DrawLine(pen, start, end);
        public void DrawCircle(Graphics g, Pen pen, Rectangle rect) => g.DrawEllipse(pen, rect);
        public void DrawRectangle(Graphics g, Pen pen, Rectangle rect) => g.DrawRectangle(pen, rect);
    }

    // Главная форма приложения
    public class CanvasForm : Form
    {
        private ComboBox cbFigureType;
        private Panel canvasPanel;
        private Point startPoint;
        private bool isMouseDown = false;

        private IDrawingCanvas canvasDrawer;
        private Bitmap backingBitmap;
        private Graphics surfaceGraphics;

        public CanvasForm()
        {
            this.Text = "Приложение для рисования (Интерфейс «Рисунок»)";
            this.Width = 850;
            this.Height = 600;

            canvasDrawer = new CanvasRenderer();

            // Верхняя панель управления
            Panel controlPanel = new Panel() { Dock = DockStyle.Top, Height = 45, BackColor = Color.WhiteSmoke };

            Label lbl = new Label() { Text = "Фигура:", Left = 15, Top = 13, AutoSize = true };

            cbFigureType = new ComboBox() { Left = 75, Top = 10, Width = 150 };
            cbFigureType.Items.AddRange(new string[] { "Линия", "Круг", "Прямоугольник" });
            cbFigureType.SelectedIndex = 0;

            Button btnClear = new Button() { Text = "Очистить холст", Left = 240, Top = 8, Width = 130, Height = 28 };
            btnClear.Click += (s, e) => {
                if (surfaceGraphics != null)
                {
                    surfaceGraphics.Clear(Color.White);
                    canvasPanel.Invalidate();
                }
            };

            controlPanel.Controls.Add(lbl);
            controlPanel.Controls.Add(cbFigureType);
            controlPanel.Controls.Add(btnClear);

            // Панель холста для рисования
            canvasPanel = new Panel() { Dock = DockStyle.Fill, BackColor = Color.White };
            canvasPanel.MouseDown += (s, e) => { startPoint = e.Location; isMouseDown = true; };
            canvasPanel.MouseUp += CanvasPanel_MouseUp;
            canvasPanel.Paint += (s, e) => { if (backingBitmap != null) e.Graphics.DrawImage(backingBitmap, 0, 0); };

            canvasPanel.Resize += (s, e) => {
                if (canvasPanel.Width > 0 && canvasPanel.Height > 0)
                {
                    Bitmap newBmp = new Bitmap(canvasPanel.Width, canvasPanel.Height);
                    if (backingBitmap != null)
                    {
                        using (Graphics g = Graphics.FromImage(newBmp)) { g.DrawImage(backingBitmap, 0, 0); }
                    }
                    backingBitmap = newBmp;
                    surfaceGraphics = Graphics.FromImage(backingBitmap);
                    surfaceGraphics.Clear(Color.White);
                }
            };

            this.Controls.Add(canvasPanel);
            this.Controls.Add(controlPanel);
        }

        private void CanvasPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (isMouseDown && e.Button == MouseButtons.Left)
            {
                Point endPoint = e.Location;
                Pen pen = new Pen(Color.DarkBlue, 2);

                int x = Math.Min(startPoint.X, endPoint.X);
                int y = Math.Min(startPoint.Y, endPoint.Y);
                int width = Math.Abs(endPoint.X - startPoint.X);
                int height = Math.Abs(endPoint.Y - startPoint.Y);

                string selected = cbFigureType.SelectedItem.ToString();
                if (selected == "Линия")
                {
                    canvasDrawer.DrawLine(surfaceGraphics, pen, startPoint, endPoint);
                }
                else if (selected == "Круг")
                {
                    canvasDrawer.DrawCircle(surfaceGraphics, pen, new Rectangle(x, y, width, width));
                }
                else if (selected == "Прямоугольник")
                {
                    canvasDrawer.DrawRectangle(surfaceGraphics, pen, new Rectangle(x, y, width, height));
                }

                isMouseDown = false;
                canvasPanel.Invalidate();
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CanvasForm());
        }
    }
}