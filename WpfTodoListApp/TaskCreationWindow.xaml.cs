using System.Windows;
using WpfTodoListApp.ViewModels;

namespace WpfTodoListApp;

/// <summary>
/// Interaction logic for TaskCreationWindow.xaml
/// </summary>
public partial class TaskCreationWindow : Window
{
  private readonly TaskCreationViewModel _viewModel;

  public TaskCreationWindow()
  {
    InitializeComponent();
    _viewModel = new TaskCreationViewModel();
    _viewModel.OnTaskAdded += (_, _) => Close();
    DataContext = _viewModel;
  }
}
