using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class Program {
    public static void Main() {
        Console.WriteLine("\r\n           __                     __       __                                                 \r\n          |  \\                  _|  \\_    |  \\                                                \r\n  ______  | $$____    ______   /   $$ \\  _| $$_    __   __   __   ______    ______    ______  \r\n /      \\ | $$    \\  /      \\ |  $$$$$$\\|   $$ \\  |  \\ |  \\ |  \\ |      \\  /      \\  /      \\ \r\n|  $$$$$$\\| $$$$$$$\\|  $$$$$$\\| $$___\\$$ \\$$$$$$  | $$ | $$ | $$  \\$$$$$$\\|  $$$$$$\\|  $$$$$$\\\r\n| $$  | $$| $$  | $$| $$  | $$ \\$$    \\   | $$ __ | $$ | $$ | $$ /      $$| $$   \\$$| $$    $$\r\n| $$__| $$| $$  | $$| $$__/ $$ _\\$$$$$$\\  | $$|  \\| $$_/ $$_/ $$|  $$$$$$$| $$      | $$$$$$$$\r\n \\$$    $$| $$  | $$ \\$$    $$|  \\__/ $$   \\$$  $$ \\$$   $$   $$ \\$$    $$| $$       \\$$     \\\r\n _\\$$$$$$$ \\$$   \\$$  \\$$$$$$  \\$$    $$    \\$$$$   \\$$$$$\\$$$$   \\$$$$$$$ \\$$        \\$$$$$$$\r\n|  \\__| $$                      \\$$$$$$                                                       \r\n \\$$    $$                        \\$$                                                         \r\n  \\$$$$$$                                                                                     \r\n");
        Thread.Sleep(1000);
        Console.Write("[>] Enter the text to be encrypted: ");

        string text = Console.ReadLine();
        string encryptedtext = Crypto.EncryptString(text);

        Console.Write($"\n[+] Encrypted text: {encryptedtext}\n");
        Console.Write("\n[>] Press any key to close.");
        Console.ReadKey();
        Environment.Exit(0);
    }
}

public class Crypto {
    private static readonly string key = ""; // Your base64 key
    private static readonly string iv = "";  // Your base64 IV

    public static string EncryptString(string plainText) {
        using (Aes aesAlg = Aes.Create()) {
            aesAlg.Key = Convert.FromBase64String(key);
            aesAlg.IV = Convert.FromBase64String(iv);
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (var msEncrypt = new MemoryStream()) {
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)) {
                    using (var swEncrypt = new StreamWriter(csEncrypt)) {
                        swEncrypt.Write(plainText);
                    }

                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }
    }
}