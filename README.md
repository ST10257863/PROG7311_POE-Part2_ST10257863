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
  dotnet restore
  
3. **Database Setup**
- Open the `appsettings.json` file and ensure the connection string is correct for your environment.
- Run the following commands to apply migrations and create the database:
  ```
  dotnet ef database update
  ```

4. **Run the Application**
dotnet run

The application should now be running on `https://localhost:5001` (or a similar port).

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
- If you encounter any issues with database migrations, try deleting the `Migrations` folder and running `Add-Migration InitialCreate` followed by `Update-Database`.
- For any other issues, please check the console output for error messages and ensure all prerequisites are correctly installed.
