using System;
using System.Diagnostics;
using System.Windows.Forms;



namespace VPN
{
    public partial class VPN : Form
    {
        public VPN()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://github.com/Egorio1",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://github.com/artaka",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "VPN")
                {
                    string configPath = System.IO.Path.Combine(Application.StartupPath, "wg0-client-user.conf"); //Конфигурация для запуска из папки с exe-файлом
                    var processInfo = new ProcessStartInfo
                    {
                        FileName = @"wireguard.exe",
                        Arguments = $"/installtunnelservice \"{configPath}\"", //Запуск конфигурации
                        Verb = "runas",
                        UseShellExecute = true
                    };

                    Process.Start(processInfo);
                    MessageBox.Show("Подключение запущено...");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            disconnect();
        }
        private void disconnect()
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "sc",
                    Arguments = "stop WireGuardTunnel$wg0-client-user",
                    Verb = "runas",
                    UseShellExecute = true
                })?.WaitForExit();

                MessageBox.Show("Отключено");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        
    }
}
