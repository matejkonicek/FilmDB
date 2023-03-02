# Movie Search Application
This is a C# console application that uses the OMDb API to search for movies by name and display their details. The application is written in C# and uses the HttpClient class to send HTTP requests to the API and the System.Text.Json namespace to deserialize JSON responses.

Prerequisites
Before running the application, you will need to obtain an API key from the OMDb API website. Once you have an API key, replace the --yourkey-- placeholder in the code with your actual API key.

Usage
To run the application, open a command prompt or terminal window and navigate to the directory containing the executable. Then, run the executable by typing the following command:

Copy code
dotnet ConsoleApp2.dll
When prompted, enter the name of the movie you want to search for. The application will send a request to the OMDb API with the movie name and display the details of the first matching result. If no matching result is found, the application will display an error message.

Code Overview
The application consists of a single class, Program, which contains a nested Movie class and a Rating class. The Movie and Rating classes represent the structure of the JSON responses returned by the OMDb API.

The Main method of the Program class is the entry point of the application. It creates a new instance of the HttpClient class and enters a loop that prompts the user for a movie name and sends a request to the API with the user's input. If the API returns a successful response, the method deserializes the response into a Movie object and displays its details. If the API returns an error response, the method displays an error message.

Dependencies
.NET 5.0 or later
System.Net.Http
System.Text.Json
