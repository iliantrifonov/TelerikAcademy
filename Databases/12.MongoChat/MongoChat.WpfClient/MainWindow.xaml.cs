namespace MongoChat.WpfClient
{
    using MongoChat.Data;
    using MongoChat.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Thread updatePostsThread;
        public MainWindow()
        {
            InitializeComponent();
            this.UpdatePostsEachMsAsync();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string messageText = Message.Text;
            string userName = User.Text;
            var message = new Message()
            {
                Date = DateTime.Now,
                Text = messageText,
                User = new User()
                {
                    UserName = userName,
                },
            };

            ChatData.AddMessage(message);

            Message.Text = "";
            Message.Focus();
        }

        private async void ShowAllPostsAsync()
        {
            var postsAsString = await this.GetPostsAsString();

            ListMessages.Text = postsAsString.ToString();
            ListMessages.ScrollToEnd();
        }

        private Task<string> GetPostsAsString()
        {
            return Task.Run(() =>
            {
                var messages = ChatData.GetTop100Messages();

                var messagesAsString = new StringBuilder(150);

                foreach (var message in messages)
                {
                    string format = "{0}: {1} - {2}";
                    messagesAsString.AppendLine(string.Format(format, message.Date, message.User, message.Text));
                }

                return messagesAsString.ToString();
            });
        }

        private async void UpdatePostsEachMsAsync(int refreshMs = 500)
        {
            this.updatePostsThread = new Thread(async () =>
            {
                while (true)
                {
                    ListMessages.Dispatcher.BeginInvoke((Action)(async () => this.ShowAllPostsAsync()));
                    Thread.Sleep(refreshMs);
                }
            });

            this.updatePostsThread.Start();
        }
    }
}
