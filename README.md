# Web app for managing laundry at home!

Super simple web app in C#/.NET Core for managing laundry at home, feel free to steal from it or use it to solve laundry handling conflicts at your house :)

Usage should be fairly self-explanatory, you add a wash, and set up a cronjob for https://your-domain.com/Cronie and the app checks at the given interval for whether there are unfinished (not "Done_done") washes that have not been updated in more than 3.5 hours, and, if there are, an e-mail will be sent to all registered users with a heads-up about it!

"UI-signals", i.e. washes requiring attention is given a bright yellow color in the web-interface as well.

## Setup / Install
Run the standard migrations on the sqlite database, i.e. 
`dotnet ef migrations add whatever_you_feel_for`
and
`dotnet ef database update`
Then you should be able to install and run the app using 
`dotnet publish -c Release --self-contained -r linux-64` or whatever. 

## Users
Shamelessly uses default Identity for all auth-purposes.

## ToDo
Looks and functionality is very basic, on purpose, so it's easy to change stuff and style it the way you want.

That's it for me currently - thanks for reading! :)
