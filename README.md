# BobFinal Project

## Overview

BobFinal is a C# Windows Forms application that simulates a village management game. Players can build various properties, manage resources, and interact with a market to buy and sell resources.

## Features

- **Grid-based Village Management**: Build and manage properties on a grid.
- **Resource Management**: Track and manage resources like Dollars, Gold, Lumber, and Diamond.
- **Market System**: Buy and sell resources with fluctuating conversion rates.
- **Full-Screen Mode**: The application opens in full-screen mode for an immersive experience.
- **New Day Timer**: Prevents spamming the "New Day" button by adding a cooldown timer.

## Getting Started

### Prerequisites

- .NET Framework
- Visual Studio or JetBrains Rider

### Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/yourusername/bobfinal.git
    ```
2. Open the solution in your preferred IDE (Visual Studio or JetBrains Rider).

### Running the Application

1. Build the solution.
2. Run the application.

## Code Structure

- `Program.cs`: Entry point of the application.
- `Form1.cs`: Main form containing the game logic and UI components.
- `Form1.Designer.cs`: Designer file for `Form1`, containing UI element definitions.
- `CustomPictureBox.cs`: Custom PictureBox class with additional properties.
- `Property.cs`: Abstract class representing a property in the game.
- `House.cs`, `Farm.cs`, `Sawmill.cs`, `Mine.cs`, `Cafe.cs`: Concrete implementations of different properties.
- `Resource.cs`: Class representing a resource with methods to manage its quantity and UI updates.
- `Market.cs`: Static class for updating resource conversion rates.

## Usage

### Building Properties

1. Select a property from the list.
2. Click on an empty tile on the grid to build the selected property.

### Managing Resources

- Resources are automatically updated daily based on the properties built.
- Use the market to buy and sell resources.

### Market

1. Select a resource from the market list.
2. Enter the amount to buy or sell.
3. Confirm the transaction.

## Contributing

Contributions are welcome! Please fork the repository and create a pull request with your changes.

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.

## Acknowledgements

- Thanks to the developers of the .NET Framework and Windows Forms for providing the tools to build this application.
