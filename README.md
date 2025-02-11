# Star Wars API Client Application
## main
This is a basic console app that queries the Star Wars API hosted by Pipedream, 
initial scope is to be able to input a range in megalights (decimal user input), 
query the API for data on several starships, and return how many pitstops are required
for each to reach their destination. 

## usage
TODO - add usage instructions

## tech notes
TODO - decide whether to store data only for query (should reduce memory usage, simpler to make)
or build data for all starships on launch (expensive startup, improved performance, will need lists for JSON objs)

This uses Spectre.Console 0.49.1 to format and constrain user input, 
has lovely parts for validating user input before attempting to execute with it