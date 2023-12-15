# Restaurant Manager System

## Introduction
The Restaurant Manager System is a comprehensive MAUI-based application designed for managing restaurant reservations. It facilitates the handling of server information, table details, and customer reservations seamlessly.

## Technology Stack
- .NET MAUI
- Oracle Database
- C#

## Installation
1. Clone the repository to your local machine.
2. Ensure that .NET MAUI is installed on your system.
3. Set up an Oracle database and ensure it is running.

## Database Setup
1. Run the `create.sql` script to create the necessary tables in your Oracle database.
2. Execute the `populate.sql` script to fill the tables with initial data.

## Usage
The application comprises various functionalities, such as creating reservations, viewing reservations, and managing server information. Key pages include:
- **Home Page**: For server login.
- **Create Reservation**: To create new reservations.
- **View Reservation**: To view and update reservation details.

## Key Classes
- `Database`: Handles all database operations.
- `Reservation`: Represents a reservation with properties like customer name, reservation time, etc.
- `Server`: Represents a server with properties such as name, ID, and password.

## Contributing
Contributions to the project are welcome. Please follow standard coding practices and submit pull requests for any new features or bug fixes.

## License
This project is licensed under the [MIT License](LICENSE).

## Contact
For any queries or feedback, please contact dexter.balino@edu.sait.ca.
