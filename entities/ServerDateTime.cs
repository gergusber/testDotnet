
public class ServerDateTime
{
  public DateTime Date { get; set; } // here should be the value needed.

  public static ServerDateTime AddMilliseconds(double value)
  {
    return this.Date.AddMilliseconds(value); //TODO: Here i imagine that we have a way to add milliseconds to the date provided.
  }
}