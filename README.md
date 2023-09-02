# Movie API - ASP.NET Core 7

This is a simple ASP.NET Core 7 Web API project for managing movie data. The API provides endpoints to retrieve movies, get a specific movie by name, add multiple movies in a batch, and update a movie's details.

## Endpoints

### Get All Movies

- **Endpoint**: `/api/Movie`
- **HTTP Method**: GET
- **Description**: Retrieve a list of all movies.
- **Response**: Returns a list of movie objects.

### Get Movie by Name

- **Endpoint**: `/api/Movie/{name}`
- **HTTP Method**: GET
- **Description**: Retrieve a movie by its name.
- **Response**: Returns a movie object if found, or a 404 Not Found status if not found.

### Add Multiple Movies in Batch

- **Endpoint**: `/api/Movie/name`
- **HTTP Method**: POST
- **Description**: Add multiple movies in batch.
- **Request**: Send a JSON array of movie objects in the request body.
- **Response**: Returns the added movies if successful, or a 400 Bad Request or 500 Internal Server Error status in case of errors.

### Update Movie

- **Endpoint**: `/api/Movie/updateOne`
- **HTTP Method**: PUT
- **Description**: Update details of a movie by its name.
- **Request**: Send a movie object with updated details in the request body.
- **Response**: Returns the updated movie if found, or a 400 Bad Request or 404 Not Found status if the movie doesn't exist.

## Technologies Used

- ASP.NET Core 7
- Entity Framework Core
- C#
- JSON

## Getting Started

1. Clone the repository to your local machine:

2. Navigate to the project directory:

3. Build and run the project:

4. Access the API at `http://localhost:5000` (or a different port if configured differently).

## Usage

- Use the provided API endpoints to manage movie data in your application.
- You can send HTTP requests to the endpoints using tools like Postman or by integrating the API into your front-end application.

## License

This project is licensed under the [MIT License](LICENSE).

## Contributors

- [Your Name](https://github.com/yourusername) - Maintainer

Feel free to modify this README to include more project-specific details or instructions as needed. Enjoy working on your ASP.NET Core Web API project!

## Dependencies

This project relies on the following NuGet packages:

- [Microsoft.AspNetCore.OpenApi](https://www.nuget.org/packages/Microsoft.AspNetCore.OpenApi) (Version 7.0.7) - Provides OpenAPI/Swagger support for documenting your API.

- [Swashbuckle.AspNetCore](https://www.nuget.org/packages/Swashbuckle.AspNetCore) (Version 6.5.0) - A tool to generate Swagger documentation for your API.

- [Microsoft.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore) (Version 7.0.10) - Entity Framework Core for working with the database.

- [Microsoft.EntityFrameworkCore.Tools](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools) (Version 7.0.10) - Provides additional tools for Entity Framework Core, such as migrations.

You can find more information about each package by following the provided links to their respective NuGet pages.
