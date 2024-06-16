using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            textBlock.Text = textBox.Text;
            textBox.Visibility = Visibility.Collapsed;
            textBlock.Visibility = Visibility.Visible;
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            textBox.Visibility = Visibility.Visible;
            textBlock.Visibility = Visibility.Collapsed;
            textBox.Focus();
        }

        private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Lấy vị trí click chuột
            Point clickPosition = e.GetPosition(this);

            // Kiểm tra xem điểm click có nằm trong phạm vi của TextBox hay không
            if (textBox.Visibility == Visibility.Visible)
            {
                Rect textBoxBounds = new Rect(textBox.TranslatePoint(new Point(), this), new Size(textBox.ActualWidth, textBox.ActualHeight));
                if (!textBoxBounds.Contains(clickPosition))
                {
                    // Nếu không, hủy focus của TextBox
                    FocusManager.SetFocusedElement(this, null);
                    Keyboard.ClearFocus();
                    TextBox_LostFocus(null, null); // Chuyển đổi từ TextBox sang TextBlock
                }
            }
        }
    }
}