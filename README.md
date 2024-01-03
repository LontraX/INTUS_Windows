# Sales Order Management Web App

## Description

This project is a web application for managing sales order data. It consists of two main components: an API project for handling data operations and a Blazor WebAssembly project for the user interface.

## Prerequisites

- .NET 6 SDK
- Visual Studio

## Getting Started

1. Clone the repository:

    ```bash
    git clone https://github.com/LontraX/INTUS_Windows.git
    ```

2. Open the solution in Visual Studio.

3. Set the API project and Blazor WebAssembly project as startup projects:
   - Right-click on the solution in the Solution Explorer.
   - Select "Set Startup Projects..."
   - Choose "Multiple startup projects" and set the action to "Start" for both the API and Blazor WebAssembly projects.

4. Press F5 or click "Start" to run both projects simultaneously.

5. The API should be accessible at `https://localhost:7052/swagger/index.html`, and the Blazor WebAssembly app at `https://localhost:4437`.

## Usage

- Upon launching the web application, you will be presented with an interface to view and manage sales order data.
- The API project handles data operations and is automatically started with the Blazor WebAssembly project.


