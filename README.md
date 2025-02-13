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

## A Note on Consistency in the Star Wars Universe
Star Wars is a big setting, with hundreds of different writers. I've observed a <strong>Bayeux Tapestry</strong> of inconsistency because of this, and this extends to units of measurement.
The Star Wars API uses "MGLT" as an undefined unit, so I thought "hmm, I should probably make sure that it is Mega-Light-Seconds that I presume it to be". 
I look it up and find a fandom wiki, stating it's a unit of distance. "Perfect, just as I thought". Then I realise it's the "SW-Desolation.fandom.com" wiki, and I think "I should probably check a more reputable source".
Then I find a reddit thread where someone asks what it is, and the top comment is "MGLT is a unit of speed, not distance". Another says "It's an acronym for Magic George Lucas Term".
Someone posts an extract from a short story where the writer uses MGLT as a unit of speed, and classically has no sense of scale.

I've settled on a "screw everything, modern sci-fi uses light-seconds as a common measure, so I'm using that" approach. I'll assume that MGLT is the range of a ship.
SI convention means that mega is 10^6, and C is 299,792,458 m/s, so <strong>1 Magic George Lucas Term is 299,792,458,000,000 Metres, or 299,792,458,000 Kilometres</strong>.
A light year in km is 9,454,254,955,488,000, and the distance between stars is usually on the order of tens to hundreds of light years, whereas a light second is 0.0317 light years which won't fly (heh), so lets bump it up to minutes.
a mega-light-minute is 17,987,547,480,000 km, or 0.5 light years. Perfect scale. 

I... I think I've gone too far in a few places. 
Should probably just use the API's MGLT as a unit of distance that it can travel to compare to user input...