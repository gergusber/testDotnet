
public static class ServerDateTimeProvider
{
  private static ServerDateTime _serverDateTime;

  public ServerDateTimeProvider()
  {
    ServerDateTime currentTime = new ServerDateTime();// Retrieve the current time from the server clock or something like that
    _serverDateTime = new ServerDateTime(currentTime);
  }

  public static ServerDateTime GetCurrentTime()
  {
    return _serverDateTime;
  }

  public static ServerDateTime GetMinValue()
  {
    return new _serverDateTime.MinValue();
  }

  public static ServerDateTime AddMilliseconds(ServerDateTime source, int millis)
  {
    return source.AddMilliseconds(millis);
  }
}