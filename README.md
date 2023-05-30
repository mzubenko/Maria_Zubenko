# Maria_Zubenko WebAPI Hometask

This is a SpecFlow Visual Studio Project, so it requires a SpecFlow extension for VS. You can install it by following instructions via the link: https://docs.specflow.org/projects/getting-started/en/latest/GettingStarted/Step1.html

In order for this project to work you need the following packages installed: NUnit, NUnit.ConsoleRunner, NUnit3TestAdapter, Microsoft.NET.Test.Sdk. The project uses .Net Core 3.1

The tests refer to the Dropbox API. In order for the project to run you'll need to create your App in the Dropbox and generate an access token for it. The instructions are via the link: https://developers.dropbox.com/oauth-guide. You also will need to change the path in the Support.cs file for your own.

To run this project you may open Microsoft Visual Studio 2022 and go to the menu "Test" -> "Run all tests". Or you may as well use Solution Explorer. To open it go to the menu "View" -> "Solution Explorer". It is also possible to run it from the cmd: you will need to enter a folder with the project using "cd" command and run the tests using "dotnet test" command

Note: I had problems uploading code to a remote repository, therefore this branch wasn't initially ceated from the main branch, so it doesn't have a .gitignore file
