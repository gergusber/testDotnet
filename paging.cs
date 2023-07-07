/*
Description: 
        An application provides users access to data records on a remote server. The 
        application needs to present users with the records chronologically in a paged
        fashion (first ## results, next ## results, etc.), but the remote server can 
        only be queried by date ranges. Further, the data may be changed out-of-band 
        on the server. Therefore, the application will need to contain logic to 
        efficiently query the data that should be returned to the user, while 
        minimizing extra data that is unnecessarily returned from the remote server. 
        Your task is to implement this translation, subject to the constraints below: 

Key Functions: 
        * A function in the application named getRecords is called every time a user 
               wants to view a page of records. This function needs to be implemented. 
        * A function called getRemoteRecords is available for use by the application 
               as needed. This function will handle retrieving data from the remote server. 

Data Records: 
        * Cannot be deleted on the remote server 
        * The ID and Creation Date will never change, but the associated Data may change. 
        * Are in chronological order on the remote server. 
        * When a data record is created on the remote server, the Creation Date will be 
               the current time. Records cannot be created with a Creation Date in the past. 
        * Each record will have a unique value for Creation Date. 
        * Data records can be large, and the network may be slow, so excessive transfer 
               of data records from the server should be avoided. 
        * You may assume that the application is not subject to memory constraints. 

ServerDateTime: 
        * Is a representation of a datetime with percision to the nearest millisecond. 
        * Is the data type used by the remote server's API as such, it MAY NOT BE MODIFIED 
        * Is an immutable data type 
        * Can only be instantiated by using the methods: 
               + getCurrentTime 
               + getMinValue 
               + addMilliseconds 

For your implementation, you should: 
        * Use your favorite object-oriented language. 
        * Use any standard language features and common libraries. 
        * Use correct syntax wherever possible, modifying the starter code if necessary. 
        * Create additional helper methods and/or static/global variables as needed. 
*/

using System.Threading.Tasks;
using System.Collections.Generic;

public class DataRecord

{
  public int ID;
  public ServerDateTime CreationDate;
  public byte[] Data;
}

public class ServerDateTime
{
  public DateTime Date { get; set; } // here should be the value needed.

  public static ServerDateTime AddMilliseconds(double value)
  {
    return this.Date.AddMilliseconds(value); //TODO: Here i imagine that we have a way to add milliseconds to the date provided.
  }
}

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


public class Paging
{
  private readonly ServerDateTime _minValue;
  private readonly ILookRecords _recordsRepository;
  public paging(ILookRecords recordsRepository)
  {
    _minValue = ServerDateTimeProvider.GetMinValue();
    _recordsRepository = recordsRepository;
  }
 
  private int getPageIndex(int pageNumber, int resultsPerPage)
  {
    return (pageNumber - 1) * resultsPerPage;
  }

  public async DataRecord[] getRecords(int pageNumber = 1, int resultsPerPage = 50)
  {
    // Calculate the appropriate notBefore and notAfter ServerDateTime values based on the pageNumber, resultsPerPage, and existing data.
    var currentPageStartIndex = GetPageIndex(pageNumber, resultsPerPage);

    var notBefore = _minValue; // Start from the earliest supported time
    var notAfter = ServerDateTimeProvider.AddMilliseconds(_minValue, currentPageStartIndex);


    // Use the GetRemoteRecords method to retrieve the data records within the specified date range.
    var dataRecords = await _recordsRepository.lookUpRemote(notBefore, notAfter, resultsPerPage);

    // Get data for apply pagination logic to return the desired subset of records.
    var startIndex = currentPageStartIndex % resultsPerPage;
    var endIndex = Math.Min(startIndex + resultsPerPage, dataRecords.Length);

    // Take skip the start index and get the amount 
    DataRecord[] pageRecords = dataRecords.Skip(startIndex).Take(endIndex - startIndex).ToArray();

    return pageRecords;
  }
}
