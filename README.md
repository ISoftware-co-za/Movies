# User Interface
Search for up to 50 matching current movies.

![Search](/Documents/Search.png)

Tap movie to see more details.

![Search result details](/Documents/Search_result_details.png)

Tap **iMdb website** to visit the movie's page on the iMDb website.

![Search result details](/Documents/iMdb_website_for_movie.png)

# Architecture

![Search result details](/Documents/ComponentDiagram.png)

### Movies.View.Android
The Android version of the Movie application.
### Movies.View.iOS
The iOS version of the Movie application.
### Movies.View.UWP
The Windows 10 mobile version of the Movie application.
### Movies.ViewModel
The ViewModel bridging the View and the Model.
### Movies.Model
The Model, performing the actual searching.
### ViewModelConnectors.Android
Classes used to connect Android Views to ViewModel elements.
### ViewModelConnectors.iOS
Classes used to connect iOS UIViews to ViewModel elements.
