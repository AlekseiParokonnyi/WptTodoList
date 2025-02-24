using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using WpfTodoListApp.Models;

namespace WpfTodoListApp.ViewModels;

// ReSharper disable PartialTypeWithSinglePart
public partial class TaskCreationViewModel : ObservableObject
{
  // ReSharper disable once UnusedMember.Local
  [ObservableProperty]
  private string _taskName = string.Empty;

  // ReSharper disable once UnusedMember.Local
  [ObservableProperty]
  private string _taskDescription = string.Empty;

  public IRelayCommand AddTaskCommand { get; }

  public TaskCreationViewModel()
  {
    AddTaskCommand = new RelayCommand(AddTask, CanAddTask);
  }

  private void AddTask()
  {
    var newTask = new TodoTask
    {
      Name = TaskName,
      Description = TaskDescription,
      Created = DateTime.UtcNow
    };

    WeakReferenceMessenger.Default.Send(newTask);

    OnTaskAdded?.Invoke(this, EventArgs.Empty);
  }

  private bool CanAddTask() => !string.IsNullOrWhiteSpace(TaskName);

  partial void OnTaskNameChanged(string value)
  {
    AddTaskCommand.NotifyCanExecuteChanged();
  }

  public event EventHandler OnTaskAdded;
}