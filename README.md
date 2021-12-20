# BDSA2021-LitExplore
## How to start the application
1. Make sure docker is running
2. Navigate to `\LitExplore` 
3. Run `Start-Application.ps1` in PowerShell

The script will save the necessary info to reconnect to the docker container in `\LitExplore\.local\secrets`. (Make sure to delete the secrets folder if you delete the docker container so the script will generate a new one).
If the application doesn't start correctly for some reason, try running 'Start-Application.ps1' a second time.

## Accessing the web interface
When the application has started, it will log a url in the terminal (should be 'https://localhost:5001'). Open this in a webbrowser to access the interface.

## Creating a project
To create a project, you must be logged in (using the "Log in" button in the top right corner of the page).
Next, you type the name of the project you want to create in the box labled "New project" and press the green "+" button beside it.
You open the project by clicking on the project in the list under "Your Projects".

## Adding papers to the project
You add the first paper by pressing the "+" button next to "Project Litterature". Here, you can either search for a paper by name or see a list of recommended papers.
The recomended papers are based on the papers which are currently in your project, so there will not be anything here until you add your first paper.

Gathering papers for the database is not really part of our vertical slice. Because of this, the amount of papers in the database is very small since they are only there to demonstrate the functionality of the application.
A good serch term for finding your first paper in this small set of papers is "Coffee".

> ###### About the papers in the database
> We used [Google Scholar](https://scholar.google.com/) to gather papers for the database. We use more or less random papers based on the search term "Coffee".
