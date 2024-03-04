# JWT Token Generator API

This project provides a simple API endpoint for generating JSON Web Tokens (JWTs). JWTs are commonly used for authentication and authorization in web applications.

## Installation

To run the project locally, follow these steps:

1. Clone this repository to your local machine:

   ```bash
   git clone https://github.com/Iamslok/JWT-Token-Generator-API.git
   ```

2. Navigate to the project directory:

   ```bash
   cd jwt_token_generator
   ```

3. Install dependencies:

   ```bash
   dotnet restore
   ```

4. Run the project:

   ```bash
   dotnet run
   ```

The API will start running at `https://localhost:7288/swagger/index.html`.

## Usage

This API provides a single endpoint for generating JWT tokens. The endpoint accepts a JSON payload containing the necessary information for generating the token.

## API Endpoints

### `POST /GenerateJWTToken`

Generates a JWT token based on the provided input.

#### Request Body

- `requestModel`: A JSON object containing the following properties:
  - `CliamType`: The type of claim to be included in the token.
  - `CliamValue`: The value of the claim to be included in the token.

#### Response

- Returns a JSON object containing the generated JWT token and its expiration timestamp.

## Sample Request

```json
{
  "requestModel": {
    "CliamType": "Role",
    "CliamValue": "Admin"
  }
}
```

## Sample Response

```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c",
  "tokenExpiresAt": "2024-03-05T10:00:00Z"
}
```

## Configuration

The application uses configuration settings stored in the `appsettings.Development.json` file. You can modify these settings as needed, including the JWT secret key and other application-specific configurations.

## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvements, please open an issue or create a pull request.

---

Feel free to customize this README file according to your project's specific details and requirements.
