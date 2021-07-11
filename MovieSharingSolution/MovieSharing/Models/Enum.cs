namespace MovieSharing.Models
{
    /// <summary>
    /// movie status enum
    /// </summary>
    public enum MovieStatus
    {
        Available = 0,
        Borrowed = 1,
        RequestInProgress = 2,
        RequestReturn = 3,
        ReturnInProcess = 4
    }
    /// <summary>
    /// action enum
    /// </summary>
    public enum ActionStatus
    {

        BorrowMovie = 1,
        ReturnMovie = 2,
        AcceptBorrow = 3,
        AcceptReturn = 4,
        RejectBorrow = 5,
        CancelReturn = 6,
        CancelRequest = 7,
        CancelBorrow = 8,
        RequestReturn = 9,
        ForceReturn = 10,
        Details = 11,
        Delete = 12

    }
}
