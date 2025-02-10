using System.Collections.ObjectModel;
using System.Windows;

namespace WpfTodoListApp
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public ObservableCollection<TodoTask> TodoTasks { get; set; } = new();

    public MainWindow()
    {
      InitializeComponent();

      DataContext = this;
    }

    private void OpenTaskCreationWindow(object sender, RoutedEventArgs e)
    {
      TaskCreationWindow addTaskWindow = new TaskCreationWindow
      {
        Owner = this
      };

      if (addTaskWindow.ShowDialog() == true)
      {
        TodoTasks.Add(addTaskWindow.TaskResult);
      }
    }
  }
}