# LMSCode"# LMSCode" 
HI,i have just concentrated on the backend,The UI is not much perfect

Please install the file.Inside that there is a Database folder and a backup file.Restore that back up in sql and run the solution in visual studio.
login with credentials UserName: admin@demo Password :123
or
if you want to create a new user go to the user table and create new admin user with isadmin boolean true

Description of the project
• I have created a new project in asp.net web application. In right bar there is a login button.so user can login
• The login page is common for member and librarian. There is a user table for storing user details .in that table I have a filed called isadmin. If we are creating a member then this Boolean will be false. So if a member is logined it will redirect to User page and if its admin it will redirect to Admin page
• After login , admin can see Book management,add new member and a dash board
• In book management admin can add new book details also can sree the book details ,also can edit and delete
• In add new member admin can add new member and can see all users ,also can edit and delete
• if the user is login member can see the book details
