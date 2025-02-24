using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using WpfTodoListApp.Models;

namespace WpfTodoListApp.ViewModels;

// ReSharper disable PartialTypeWithSinglePart
public partial class TodoListViewModel : ObservableObject
{
  // ReSharper disable once UnusedMember.Local
  [ObservableProperty]
  private ObservableCollection<TodoTask> _todoTasks = new();

  public IRelayCommand OpenTaskCreationCommand { get; }
  public IRelayCommand<TodoTask> DeleteTodoTaskCommand { get; }

  public TodoListViewModel()
  {
    OpenTaskCreationCommand = new RelayCommand(OpenTaskCreationWindow);
    DeleteTodoTaskCommand = new RelayCommand<TodoTask>(DeleteTask);

    WeakReferenceMessenger.Default.Register<TodoTask>(this, (_, task) =>
    {
      TodoTasks.Add(task);
    });
  }

  private void OpenTaskCreationWindow()
  {
    var addTaskWindow = new TaskCreationWindow
    {
      Owner = System.Windows.Application.Current.MainWindow
    };
    addTaskWindow.ShowDialog();
  }

  private void DeleteTask(TodoTask task)
  {
    if (task != null && TodoTasks.Contains(task))
    {
      TodoTasks.Remove(task);
    }
  }
}