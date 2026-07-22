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

namespace ToDoApp
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
        private void AddToDoButton_Click(object sender, RoutedEventArgs e)
        {
            string toDoText=ToDoInput.Text;
            MessageBox.Show(toDoText);
            if (!string.IsNullOrEmpty(toDoText))
            {
                TextBlock toDoItem = new TextBlock  
                {
                    Text = toDoText,
                    Margin = new Thickness(5,0,0,0),
                    Foreground = new SolidColorBrush(Colors.White),

                };
                toDoList.Children.Add(toDoItem);
                ToDoInput.Clear();
            }
        }
    }
}