Inputting Users and Payment Details into an Adept Database using C#.

This project was made using C# and Sql Server to allow a user to upload CSV files to a database. The user has a choice of whether to upload to the user table or to the payment table. The two tables are joined together using the foreign key of UserID.

## Installing / Getting started

This is what is needed to install the Importer Application after downloading the folder

Open up either visual studio or the command line.

If you have opened up visual studio you can just run the application from within there. But, within the command

cd to foler where the .csproj is
dotnet run

After executing dotnet run the application will run and the menu will open up.

### Initial Configuration

The only configuration that may need to be done is update or install any dependencies that may be needed.

## Developing
If you would like to build onto this further or develop it more.

git clone https://github.com/Clennox-Geniusssl/Importer.git
cd Importer/
package manager install

By doing it this way it will find this on github and clonme it to your desktop. After this is done you would cd to the folder and then install anything that may be needed extra for it.

## Features

When the application starts there is a menu with three options. The options are import payments from a file, upload users from a file and exit.

Within the menu the arrow keys are used to navigate the menu and enter takes you to the selected option.

The first two options allow you to add the file path to a valid csv file that the headings associate with the heading from the tables. And Exit exits the application.

After a file path has been chosen and it is accepted then the main menu is shown again. There are messages that will appear if the file can't be found and if no file is selected.

If a file can't be found it will say No file found, Please enter a file path and correct file please.

Also if no file path was selected that Can't find file path, Please enter a valid file directory.

## Contributing

Anyone is welcome to contribute to this project. 

If anyone would like to then please fork the repository and use a feature branch.

## Links

- Project homepage: https://your.github.com/Importer/
- Repository: https://github.com/Clennox-Geniusssl/Importer/
- Issue tracker: https://github.com/Clennox-Geniusssl/Importer/issues
- Related projects:
  - Gradebook: https://github.com/Clennox-Geniusssl/gradebook-2