# UTA - Travel Agencies Association - Web Application
(Under Construction)

Application hosted on: [uta.somee.com](http://uta.somee.com/)

## Short description
This Application is for presenting arrangements of travel agencies, members of Travel Agencies Association.
It presents list of Agencies and list of Travel Arrangements. Clicking on agency or arrangement you can see detalis of it.

## Roles
There is only one role implemented, administrator.
He/she can add new agency, arrangement, modify or delete those. 
Agencies must send data to administrator and he/she have to put those data manually, after logged in application.
Administrator, after logged in, have a drop down list named *Baza podataka*, where can choose a table from database to edit.
Visitors can see all agencies, arrangements, and its detalis, but can't add modify or delete those.

## Credentials
Default credentials for administrator:

user: `admin@uta.com`

pass: `Admin!23`

## Web Hosting
This Application has been hosted on [uta.somee.com](http://uta.somee.com/)

Application files uploaded by ftp, and database uploaded by sql script (create tables and seeds) 

## Future goals
- Implement role for agency
  - Sign up form for new agency
  - Modify agency account data, delete account, by agency account owner or administrator
  - Agency can add, modify and delete only its own arrangements
- Upload images to server
  - Agency logo
  - Arrangement pictures
- Add maps APIs for agencies and arrangement destination locations
- Add weather forecast from weather API
