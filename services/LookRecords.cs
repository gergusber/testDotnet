public interface ILookRecords<TEntity> where TEntity : class
{
  public Task<IEnumerable<DataRecord>> lookUpRemote(ServerDateTime notBefore, ServerDateTime notAfter, int recordLimit);
}

public class LookRecords : ILookRecords<DataRecord>
{
  public async Task<IEnumerable<DataRecord>> lookUpRemote(ServerDateTime notBefore, ServerDateTime notAfter, int recordLimit = 50)
  {
    DataRecord[] remoteRecords = null; //Here make the fetch call to the server.i imagine that in here we need to inject a service that can take the params and send a search.
    return remoteRecords;
  }
}