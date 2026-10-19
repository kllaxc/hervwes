using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
namespace mod_7
{
    public partial class MainWindow : Window
    {
        private readonly ICryptoService _cryptoService;

        public MainWindow()
        {
            InitializeComponent();

            // Создаем сервис и подписываемся на делегат статусов
            var gostService = new GostCryptoService();
            gostService.OnStatusChanged += ShowStatusMessage;
            _cryptoService = gostService;

            if (CbMode.Items.Count == 0)
            {
                CbMode.Items.Add(new ComboBoxItem { Content = "ECB" });
                CbMode.Items.Add(new ComboBoxItem { Content = "CBC" });
                CbMode.SelectedIndex = 0; // ИСПРАВЛЕНО: ItemIndex -> SelectedIndex
            }
        }
        // Метод, соответствующий делегату StatusUpdateHandler
        private void ShowStatusMessage(string message)
        {
            Title = $"mod 7 | Статус: {message}";
        }
        private void CbMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        private void BtnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(TxtPlaintext.Text);
                string key = TxtKey.Text.Trim();
                string mode = ((CbMode.SelectedItem as ComboBoxItem)?.Content?.ToString()) ?? "ECB";
                if (key.Length != 64)
                {
                    MessageBox.Show("Ошибка: Ключ должен содержать ровно 64 HEX-знака!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                byte[] encryptedData = _cryptoService.Encrypt(data, key, string.Empty, mode);
                // Перевод в HEX через BitConverter
                TxtCiphertext.Text = BitConverter.ToString(encryptedData).Replace("-", "");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void BtnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string hexText = TxtCiphertext.Text.Trim().Replace(" ", "");
                byte[] data = HexStringToByteArray(hexText);
                string key = TxtKey.Text.Trim();
                string mode = ((CbMode.SelectedItem as ComboBoxItem)?.Content?.ToString()) ?? "ECB";
                byte[] decryptedData = _cryptoService.Decrypt(data, key, string.Empty, mode);
                TxtPlaintext.Text = Encoding.UTF8.GetString(decryptedData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка расшифрования: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            int fileNumber = 1;
            string fileName;
            do
            {
                fileName = $"result{fileNumber}.txt";
                fileNumber++;
            } while (File.Exists(fileName));
            var sb = new StringBuilder();
            sb.AppendLine($"Время: {DateTime.Now}");
            sb.AppendLine($"Режим: {(CbMode.SelectedItem as ComboBoxItem)?.Content}");
            sb.AppendLine($"Ключ: {TxtKey.Text}");
            sb.AppendLine($"Открытый текст: {TxtPlaintext.Text}");
            sb.AppendLine($"Шифротекст: {TxtCiphertext.Text}");
            File.WriteAllText(fileName, sb.ToString(), Encoding.UTF8);
            MessageBox.Show($"Отчет успешно сохранен в файл: {fileName}", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private byte[] HexStringToByteArray(string hex)
        {
            int numberChars = hex.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }
    }
}