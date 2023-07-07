using System.Threading.Tasks;
using System.Collections.Generic;

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
