# Hydrogen Atom Simulation

This project simulates the energy levels of a hydrogen atom using a combination of C# and Q#. The frontend provides an interactive way to visualize the energy levels, and the backend API calculates the energy levels using Q#.

## Prerequisites

- .NET 5.0 SDK
- Visual Studio or Visual Studio Code (with C# and Q# extensions)

## Project Structure

- `hydrogen_atom_simulation`: Q# library implementing the quantum simulation of the hydrogen atom's energy levels
- `QSharpApi`: C# API project that exposes the Q# simulation as a RESTful API
- `frontend`: Simple frontend to visualize the energy levels and interact with the API

## Getting Started

1. Clone the repository:

git clone https://github.com/yourusername/hydrogen-atom-simulation.git

css
Copy code

2. Navigate to the `QSharpApi` directory and run the following command to restore packages and build the project:

dotnet restore
dotnet build

markdown
Copy code

3. Start the API server:

dotnet run

markdown
Copy code

The API should now be running at `http://localhost:5000`.

4. Open the `frontend` directory in your favorite text editor or IDE, and modify the `index.html` file to point to the running API.

5. Open `index.html` in your web browser to start using the frontend.

## License

This project is licensed under the [MIT License](LICENSE).
