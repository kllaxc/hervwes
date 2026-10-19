namespace mod_7
{
    // Делегат для передачи логов в интерфейс
    public delegate void StatusUpdateHandler(string message);

    public interface ICryptoService
    {
        byte[] Encrypt(byte[] plaintext, string hexKey, string hexIv, string mode);
        byte[] Decrypt(byte[] ciphertext, string hexKey, string hexIv, string mode);
    }

    public class GostCryptoService : ICryptoService
    {
        public event StatusUpdateHandler OnStatusChanged;

        public byte[] Encrypt(byte[] plaintext, string hexKey, string hexIv, string mode)
        {
            OnStatusChanged?.Invoke($"Запуск шифрования в режиме {mode}...");
            return plaintext; // Здесь твое ядро ГОСТ
        }

        public byte[] Decrypt(byte[] ciphertext, string hexKey, string hexIv, string mode)
        {
            OnStatusChanged?.Invoke($"Запуск расшифрования в режиме {mode}...");
            return ciphertext; // Здесь твое ядро ГОСТ
        }
    }
}