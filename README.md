# testDotnet

### Description: 
  An application provides users access to data records on a remote server. The application needs to present users with the records chronologically in a paged 
  fashion (first ## results, next ## results, etc.), but the remote server can only be queried by date ranges. Further, the data may be changed out-of-band 
  on the server. Therefore, the application will need to contain logic to efficiently query the data that should be returned to the user, while 
  minimizing extra data that is unnecessarily returned from the remote server. 
  Your task is to implement this translation, subject to the constraints below: 

  

### Key Functions: 
  > - A function in the application named getRecords is called every time a user wants to view a page of records. This function needs to be implemented. 
  > - A function called getRemoteRecords is available for use by the application as needed. This function will handle retrieving data from the remote server. 

### Data Records: 
        * Cannot be deleted on the remote server 
        * The ID and Creation Date will never change, but the associated Data may change. 
        * Are in chronological order on the remote server. 
        * When a data record is created on the remote server, the Creation Date will be 
               the current time. Records cannot be created with a Creation Date in the past. 
        * Each record will have a unique value for Creation Date. 
        * Data records can be large, and the network may be slow, so excessive transfer 
               of data records from the server should be avoided. 
        * You may assume that the application is not subject to memory constraints. 

  

### ServerDateTime: 
        * Is a representation of a datetime with percision to the nearest millisecond. 
        * Is the data type used by the remote server's API as such, it MAY NOT BE MODIFIED 
        * Is an immutable data type 
        * Can only be instantiated by using the methods: 
               + getCurrentTime 
               + getMinValue 
               + addMilliseconds 

### For your implementation, you should: 
        * Use your favorite object-oriented language. 
        * Use any standard language features and common libraries. 
        * Use correct syntax wherever possible, modifying the starter code if necessary. 
        * Create additional helper methods and/or static/global variables as needed. 
  
```c#

// Perform a remote lookup of data records from the server. 
// Will return at most recordLimit (or 50 records if recordLimit is not in the range [1,50]) 
// notBefore and notAfter are inclusive. 
// SOURCE CODE IS NOT AVAILABLE FOR THIS FUNCTION AND IT MAY NOT BE MODIFIED. 
public DataRecord[] getRemoteRecords(ServerDateTime notBefore, ServerDateTime notAfter, int recordLimit); 

  

// ServerDateTime helper functions 
// Returns a ServerDateTime representing the current instant 
// MAY NOT BE MODIFIED 
public static ServerDateTime getCurrentTime(); 

  

// Returns a ServerDateTime representing the earliest supported time 
// MAY NOT BE MODIFIED 
public static ServerDateTime getMinValue(); 

  

// Returns a ServerDateTime representing a time millis milliseconds after source 
// MAY NOT BE MODIFIED 

public static ServerDateTime addMilliseconds(ServerDateTime source, int millis); 

  

// DataRecord structure. 
// MAY NOT BE MODIFIED 

public class DataRecord 

{ 
    public int ID; 
    public ServerDateTime CreationDate; 
    public byte[] Data; 
} 

  

// TODO: Define data structures and methods as needed to implement paging 
// Returns the up to resultsPerPage DataRecords that should appear on page pageNum 
// May return fewer results if the end of the data set has been reached 
// TODO: Implement this function body 

public DataRecord[] getRecords(int pageNumber, int resultsPerPage)  
{ 
    //Implementation goes here
} 
```