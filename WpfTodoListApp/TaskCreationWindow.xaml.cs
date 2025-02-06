using System.Windows;

namespace WpfTodoListApp;

/// <summary>
/// Interaction logic for TaskCreationWindow.xaml
/// </summary>
public partial class TaskCreationWindow : Window
{
  public string TaskResult { get; private set; } = string.Empty;

  public TaskCreationWindow()
  {
    InitializeComponent();
  }

  private void AddTaskClick(object sender, RoutedEventArgs e)
  {
    if (string.IsNullOrWhiteSpace(TaskInput.Text))
    {
      MessageBox.Show("Task cannot be empty");
      return;
    }

    TaskResult = TaskInput.Text;
    DialogResult = true;
  }
}
