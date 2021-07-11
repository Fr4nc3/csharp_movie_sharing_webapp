# csharp_movie_sharing_webapp

movie sharing system using C# Core 5.0 Razor Pages

Solution name MovieSharing
open project and build no error or warning

## Secret for database connection

```
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=tcp:SERVERNAME,1433;Initial Catalog=DATABASENAME;Persist Security Info=False;User ID=USERNAME;Password=PASSWORD;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" --project MovieSharing
```

## Impersonate

Add any user email and name
Impersonate user doesn't add to Azure AD
Impersonate is using cookies two cookies the code is little basic but it was the last thing I implemented

## Rules

- Add Movie
- Add Category
- Add Imperson user
- Delete Movie
  Movies can be deleted only if they are complete returned to the owner
- Delete Category
  Category can be deleted only if they have no movies associated
- Delete Imperson user
  Imperson user can be deleted only if they don't have any shared/owned movies
  this is just for security
- Movie Flow
  Movie Owner
  Create Movie
  Delete Movie
  Edit Movie
- Movie Flow Statuses
  User request Borrow -> Request In process
  Owner Accept Borrow -> Borrowed
  Owner Reject Borrow -> Available Again
  Owner Request Movie Back -> Request Return
  User Return Movie -> Available Again
  User Start Return -> Return in process
  Owner Accept Return -> Available Again
  Movie can be borrowed only if available
  Movie is Available is SharedEmail is empty and status empty
  Owner can only request return and not force availability
  User cannot borrow own movies
  user cannot return other user borrowed users
  Impersonate user takes full flow as owner or user
- bootstrap table and buttons
