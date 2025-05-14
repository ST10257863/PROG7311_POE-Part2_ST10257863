# Agri Energy Connect - PROG7311 POE Part 2

## Project Overview
This project is an ASP.NET Core web application for managing agricultural products. It allows farmers to add and view their products, and employees to manage farmers and view all products.

## Prerequisites
- .NET 9.0 SDK
- Visual Studio 2022 or later (recommended) or Visual Studio Code
- SQL Server (LocalDB is sufficient for testing)

## Setup Instructions

1. **Clone the Repository**
  ```
  git clone https://github.com/ST10257863/PROG7311_POE-Part2_ST10257863.git
  cd PROG7311_POE-Part2_ST10257863
  ```
2. **Restore Dependencies**
Open a terminal in the project root directory and run:	
  ```  
  dotnet restore
  ```
3. **Database Setup**
- Ensure SQL Server is installed and running on your machine.
- Open the `appsettings.json` file and locate the `ConnectionStrings` section.
- Update the `DefaultConnection` string to match your SQL Server instance. For example:
  ```json
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=AgriEnergyConnect;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
  ```

4. **Apply Database Migrations**
Open a terminal in the project root directory and run:
  ```
  Update-Database
  ```

4. **Run the Application**
  ```
  dotnet run
  ```

The application should now be running on `https://localhost:####` (or a similar port).

## Testing the Application

### Default Test Users
The application is seeded with two test users:

1. **Employee**
- Email: employee@test.com
- Password: Test@123
- Role: Employee

2. **Farmer**
- Email: farmer@test.com
- Password: Test@123
- Role: Farmer

### Testing Steps

1. **Login**
- Navigate to the login page and use one of the test user credentials to log in.

2. **Employee Functions**
If logged in as an employee:
- Add a new farmer account using the "Add Farmer" link in the navigation bar.
- View all products using the "View All Products" link.
- Use the Database Management feature to seed additional data if needed.

3. **Farmer Functions**
If logged in as a farmer:
- Add a new product using the "Add Product" feature.
- View your own products using the "View Your Products" link.

4. **Product Management**
- Use the search, category filter, and farmer filter (for employees) to test the product view functionality.

5. **Logout**
- Use the "Logout" button to end your session.

## Troubleshooting

- If you encounter issues with database connections:
  - Ensure SQL Server is running.
  - Verify the connection string in `appsettings.json` is correct for your environment.
  - Check that you have necessary permissions to create and modify databases.

- If you face problems with migrations:
  - Try deleting the `Migrations` folder.
  - Run `dotnet ef migrations add InitialCreate` to create a new initial migration.
  - Then run `dotnet ef database update` to apply the migration.

- For any other issues:
  - Check the console output for error messages.
  - Ensure all prerequisites are correctly installed.
  - Verify that you're using the correct .NET SDK version (9.0).

  ## Additional Notes

- This application uses SQL Server. Ensure you have the necessary SQL Server instance and permissions set up before running the application.
- The database will be automatically created and seeded with initial data when you run the migrations.