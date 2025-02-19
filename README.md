# Star Wars API Client Application
## main
This is a basic console app that queries the Star Wars API hosted at swapi.dev/api/.
initial scope is to be able to input a range in megalights (decimal user input), 
query the API for summarised data on all starships, full data on individual ships 
and return how many pitstops are required for each to reach their destination. 

## installation / usage
The app is a console app, and can be run from the command line with `dotnet run` or with the compiled binary.
The app will prompt the user with a welcome message and a choice selection. 
Navigation is done by using the arrow keys and the enter key. Text input is
validated before accepting it, currently only allowing decimal numbers.

## tech notes
This uses Spectre.Console 0.49.1 to format and constrain user input, 
has lovely parts for validating user input before attempting to execute with it.
The API client is a simple HttpClient with the NewtonSoft JSON deserialisation.
