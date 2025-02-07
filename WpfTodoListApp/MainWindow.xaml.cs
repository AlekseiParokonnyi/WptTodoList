using System.Collections.ObjectModel;
using System.Windows;

namespace WpfTodoListApp
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public ObservableCollection<string> TodoTasks { get; set; } = new();

    public MainWindow()
    {
      InitializeComponent();

      DataContext = this;
    }

    private void OpenTaskCreationWindow(object sender, RoutedEventArgs e)
    {
      TaskCreationWindow taskWindow = new TaskCreationWindow
      {
        Owner = this
      };

      if (taskWindow.ShowDialog() == true)
      {
        TodoTasks.Add(taskWindow.TaskResult);
      }
    }
  }
}