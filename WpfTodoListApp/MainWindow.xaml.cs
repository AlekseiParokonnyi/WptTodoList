﻿using WpfTodoListApp.ViewModels;

namespace WpfTodoListApp
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow
  {
    public MainWindow()
    {
      InitializeComponent();

      DataContext = new TodoListViewModel();
    }
  }
}