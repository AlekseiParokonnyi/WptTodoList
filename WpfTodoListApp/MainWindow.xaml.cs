using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

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

    private void DeleteTodoTask(object sender, RoutedEventArgs e)
    {
      if (sender is Button { DataContext: TodoTask taskToDelete })
      {
        TodoTasks.Remove(taskToDelete);
      }
    }
  }
}