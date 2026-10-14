using System;
using System.Drawing;
using System.Windows.Forms;
namespace mod5._4
{
    public class ImageViewerForm : Form
    {
        private PictureBox pictureBox;
        private Button btnOpen;
        private Button btnZoomIn;
        private Button btnZoomOut;
        private Image originalImage; // Оригинальное изображение для точного расчета
        private float zoomFactor = 1.0f; // Текущий коэффициент масштаба
        public ImageViewerForm()
        {
            this.Text = "Просмотр изображений (Модуль 5, Задание 4)";
            this.Width = 900;
            this.Height = 650;
            // Нижняя панель с кнопками управления
            Panel bottomPanel = new Panel() { Dock = DockStyle.Bottom, Height = 55, BackColor = Color.WhiteSmoke };
            btnOpen = new Button() { Text = "Открыть", Left = 15, Top = 12, Width = 110, Height = 30 };
            btnOpen.Click += (s, e) => {
                using (OpenFileDialog dlg = new OpenFileDialog() { Filter = "Изображения (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|Все файлы (*.*)|*.*" })
                {
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        if (originalImage != null) originalImage.Dispose();
                        originalImage = Image.FromFile(dlg.FileName);
                        zoomFactor = 1.0f; // Сброс масштаба при открытии новой картинки
                        UpdateImageDisplay();
                    }
                }
            };
            btnZoomIn = new Button() { Text = "Увеличить (+)", Left = 135, Top = 12, Width = 115, Height = 30 };
            btnZoomIn.Click += (s, e) => {
                if (originalImage != null)
                {
                    zoomFactor *= 1.5f; 
                    UpdateImageDisplay();
                }
            };
            btnZoomOut = new Button() { Text = "Уменьшить (-)", Left = 260, Top = 12, Width = 115, Height = 30 };
            btnZoomOut.Click += (s, e) => {
                if (originalImage != null)
                {
                    zoomFactor *= 0.65f;
                    if (zoomFactor < 0.05f) zoomFactor = 0.05f; 
                    UpdateImageDisplay();
                }
            };
            bottomPanel.Controls.Add(btnOpen);
            bottomPanel.Controls.Add(btnZoomIn);
            bottomPanel.Controls.Add(btnZoomOut);
            pictureBox = new PictureBox() { Dock = DockStyle.Fill, SizeMode = PictureBoxSizeMode.CenterImage, BackColor = Color.Black };
            this.Controls.Add(pictureBox);
            this.Controls.Add(bottomPanel);
        }
        private void UpdateImageDisplay()
        {
            if (originalImage != null)
            {
                int newWidth = Math.Max(10, (int)(originalImage.Width * zoomFactor));
                int newHeight = Math.Max(10, (int)(originalImage.Height * zoomFactor));
                Bitmap scaledBitmap = new Bitmap(originalImage, newWidth, newHeight);
                if (pictureBox.Image != null && pictureBox.Image != originalImage)
                {
                    pictureBox.Image.Dispose();
                }
                pictureBox.Image = scaledBitmap;
            }
        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ImageViewerForm());
        }
    }
}