# Web app for managing laundry at home!

Super simple web app for managing laundry at home, feel free to steal from it or use it to solve laundry handling conflicts at your house :)

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
On my to-do list is first of all adding e-mail notifications; Currently the app gives basic UI signals *on* the website, i.e. "a laundry" is in red if it needs attention; attention is need when the status has not been updated in 3.5 hours (and status is not done_done).
First up is therefore to add a cron-able endpoint somewhere to run every 30 min or so, and if any "laundries" are found that require attention, an e-mail is sent to all users.

That's it for me currently - thanks for reading! :)
