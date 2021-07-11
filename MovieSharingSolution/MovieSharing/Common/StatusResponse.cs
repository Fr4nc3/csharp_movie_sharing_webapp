using MovieSharing.Data;
using MovieSharing.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MovieSharing.Common
{
    public class StatusResponse
    {
        /// <summary>
        ///  Execute Movie Actions
        /// </summary>
        /// <param name="_context"></param>
        /// <param name="id"></param>
        /// <param name="action"></param>
        /// <param name="email"></param>
        /// <param name="username"></param>
        /// <param name="redirect"></param>
        /// <returns></returns>
        public static async Task<string> ExecuteMovieAsync(MovieSharingContext _context, long? id, string action, string email, string username, string redirect)
        {


            ActionStatus actionStatus = StatusResponse.GetRealAction(action);
            if (id == null)
            {
                return "nofuound";
            }

            Movie Movie = await _context.Movie.FindAsync(id);
            // nothing if the movie doesn't exist
            if (Movie == null)
            {
                return "nofuound";
            }

            if (actionStatus == ActionStatus.Details)
            {
                return redirect;
            }

            // change movie status depending the action
            switch (actionStatus)
            {
                case ActionStatus.Delete:
                    _context.Movie.Remove(Movie);
                    break;

                case ActionStatus.BorrowMovie:
                    // user start borrow process
                    Movie.SharedDate = DateTime.UtcNow;
                    Movie.SharedWithEmailAddress = email;
                    Movie.SharedWithName = username;
                    Movie.Status = StatusResponse.GetMovieStatus(MovieStatus.RequestInProgress);
                    break;

                case ActionStatus.RequestReturn:
                    Movie.Status = StatusResponse.GetMovieStatus(MovieStatus.RequestReturn);
                    break;

                case ActionStatus.AcceptBorrow:
                    Movie.Status = StatusResponse.GetMovieStatus(MovieStatus.Borrowed);
                    break;
                case ActionStatus.CancelBorrow:
                case ActionStatus.AcceptReturn:
                case ActionStatus.RejectBorrow:
                case ActionStatus.ForceReturn:
                    // movie is available gain
                    Movie.SharedDate = null;
                    Movie.SharedWithEmailAddress = "";
                    Movie.SharedWithName = "";
                    Movie.Status = "";
                    break;

                case ActionStatus.CancelReturn:
                case ActionStatus.CancelRequest:
                    Movie.Status = StatusResponse.GetMovieStatus(MovieStatus.Borrowed);
                    break;

                case ActionStatus.ReturnMovie:
                    Movie.Status = StatusResponse.GetMovieStatus(MovieStatus.ReturnInProcess);
                    break;

            }
            // if the action is not delete we modify the movie
            if (actionStatus != ActionStatus.Delete)
            {
                _context.Attach(Movie).State = EntityState.Modified;
            }


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // no handle error 
            }

            return redirect;
        }
        /// <summary>
        ///  Readable Movie Status
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string GetMovieStatus(MovieStatus status)
        {

            // list of valid status
            switch (status)
            {
                case MovieStatus.Borrowed:
                    return "borrowed";
                case MovieStatus.RequestInProgress:
                    return "request in process";

                case MovieStatus.ReturnInProcess:
                    return "return in process";
                case MovieStatus.RequestReturn:
                    return "request return";
                default:
                    {
                        return "";
                    }

            }
        }

        /// <summary>
        ///  Get action string name
        /// </summary>
        /// <param name="status">Action Status</param>
        /// <returns></returns>
        public static string GetAction(ActionStatus status)
        {
            // list of valid actions
            switch (status)
            {
                case ActionStatus.Delete:
                    return "delete";

                case ActionStatus.BorrowMovie:
                    return "borrowMovie";

                case ActionStatus.RequestReturn:
                    return "requestReturn";

                case ActionStatus.AcceptBorrow:
                    return "acceptBorrow";

                case ActionStatus.RejectBorrow:
                    return "rejectBorrow";

                case ActionStatus.AcceptReturn:
                    return "acceptReturn";

                case ActionStatus.CancelRequest:
                    return "cancelRequest";

                case ActionStatus.ReturnMovie:
                    return "returnMovie";

                case ActionStatus.CancelReturn:
                    return "cancelReturn";

                case ActionStatus.CancelBorrow:
                    return "cancelBorrow";

                case ActionStatus.ForceReturn:
                    return "forceReturn";

                default:
                    {
                        return "details";
                    }

            }
        }
        /// <summary>
        ///  Get Action enum
        /// </summary>
        /// <param name="status">string status</param>
        /// <returns></returns>
        public static ActionStatus GetRealAction(string status)
        {
            // list of valid errors
            switch (status)
            {
                case "delete":
                    return ActionStatus.Delete;

                case "borrowMovie":
                    return ActionStatus.BorrowMovie;

                case "requestReturn":
                    return ActionStatus.RequestReturn;

                case "acceptBorrow":
                    return ActionStatus.AcceptBorrow;

                case "rejectBorrow":
                    return ActionStatus.RejectBorrow;

                case "acceptReturn":
                    return ActionStatus.AcceptReturn;

                case "cancelRequest":
                    return ActionStatus.CancelRequest;

                case "returnMovie":
                    return ActionStatus.ReturnMovie;

                case "cancelReturn":
                    return ActionStatus.CancelReturn;

                case "cancelBorrow":
                    return ActionStatus.CancelBorrow;

                case "forceReturn":
                    return ActionStatus.ForceReturn;

                default:
                    {
                        return ActionStatus.Details;
                    }

            }
        }
    }
}
