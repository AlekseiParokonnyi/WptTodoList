namespace WpfTodoListApp;

public record TodoTask
{
  public string Name { get; init; }
  public string Description { get; init; }
  public DateTime Created { get; init; }
}