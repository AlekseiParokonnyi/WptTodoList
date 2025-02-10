using System.Windows;

namespace WpfTodoListApp;

/// <summary>
/// Interaction logic for TaskCreationWindow.xaml
/// </summary>
public partial class TaskCreationWindow : Window
{
  public TodoTask TaskResult { get; private set; }

  public TaskCreationWindow()
  {
    InitializeComponent();
  }

  private void AddTaskClick(object sender, RoutedEventArgs e)
  {
    if (string.IsNullOrWhiteSpace(TaskNameInput.Text))
    {
      MessageBox.Show("Task cannot be empty");
      return;
    }

    TaskResult = new TodoTask
    {
      Name = TaskNameInput.Text,
      Description = TaskDescriptionInput.Text,
      Created = DateTime.UtcNow
    };

    DialogResult = true;
  }
}
