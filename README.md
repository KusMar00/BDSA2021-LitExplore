# BDSA2021-LitExplore
## How to start the application
1. Make sure docker is running
2. Navigate to `\LitExplore` 
3. Run `Start-Application.ps1` in PowerShell

The script will save the necessary info to reconnect to the docker container in `\LitExplore\.local\secrets`. (Make sure to delete the secrets folder if you delete the docker container so the script will generate a new one).