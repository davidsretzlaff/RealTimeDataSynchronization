# Project Documentation: Real-Time Data Synchronization between Windows and Web Applications

## Overview

This document provides detailed instructions on how to build and run two interconnected applications: a Windows application (Application 1) and a web application (Application 2). These applications demonstrate real-time data synchronization between them.

## Project Structure

- **Application 1: Windows Application**
  - Developed using Windows Forms with .NET 8.
  - Features an input field and an output field.
  - The input field captures user text input.
  - The output field displays text received from Application 2.

- **Application 2: Web Application**
  - Developed using .NET Core with React.js for the frontend.
  - Hosted on a local web server.
  - Features an input field and an output field.
  - The input field captures user text input.
  - The output field displays text received from Application 1.

- **Real-Time Data Synchronization**
  - Utilizes SignalR in .NET Core for real-time communication.
  - Implements bidirectional text synchronization between Application 1 and Application 2.

## Configuration Instructions

### Prerequisites
- .NET SDK 8.0 or higher
- Docker
- Node.js and npm
- Visual Studio or Visual Studio Code

### Building and Running the Applications

#### Application 1: Windows Application

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/davidsretzlaff/RealTimeDataSynchronization.git
   cd your-repository/ApplicationOne
   ```

2. **Restore Dependencies:**
   ```bash
   dotnet restore
   ```

3. **Build the Application:**
   ```bash
   dotnet build
   ```

4. **Run the Application:**
   ```bash
   dotnet run (you can run as many instances as you want)
   ```

#### Application 2: Web Application

1. **Clone the Repository:**
   ```bash
   cd your-repository/RealTimeDataSynchronization
   ```

2. **Run with Docker:**
   - Ensure you are in the `RealTimeDataSynchronization` directory.
   - Execute the following command to start Docker Compose:
     ```bash
     docker-compose up
     ```

3. **Access the Web Application:**
   - After Docker Compose finishes configuration, the web application will be available in the browser at `http://localhost:3000`.

### Unit Testing

- To run unit tests in .NET Core:
  ```bash
  cd your-repository/RealTimeDataSynchronization/ApplicationTwo/Service/src/Hub
  dotnet test
  ```

## Implemented Features Description

- **Real-Time Text Synchronization:**
  - Through SignalR, any text entered into the input field of one application is instantly reflected in the output field of the other application.

- **Input Validation:**
  - Messages cannot be null and must not exceed 300 characters. Unit tests have been implemented to ensure this validation.

- **Simple and Intuitive User Interface:**
  - Both applications feature a minimalist interface with an input field and an output field.

- **Scalability:**
  - The system supports multiple instances of Application 1 connecting and synchronizing with a single instance of Application 2, and vice versa.

## Technical Choices

### Technical Choices

- **.NET 8 and .NET Core:**
  - Chosen for their robustness, SignalR support, and ease of integration with other technologies.
  
- **SignalR:**
  - Utilized for real-time communication due to its efficiency and built-in support in .NET Core.

- **React.js:**
  - Chosen for the frontend of Application 2 for its popularity, ease of use, and ability to create dynamic user interfaces.

- **Docker:**
  - Used to streamline the configuration and execution of the web application, ensuring a consistent and replicable environment.

## Conclusion

This project demonstrates an effective solution for real-time data synchronization between a local application and a web application.
The provided instructions enable easy replication of the development and execution environments.
The technical choices and challenges overcome during development reinforce the robustness and scalability of the implemented solution.

### Images
- ## Application Two sending message
![image](https://github.com/davidsretzlaff/RealTimeDataSynchronization/assets/14004154/635e5fab-f1cf-437d-945e-edbc00f577cc)

- ## Applications One received message
![image](https://github.com/davidsretzlaff/RealTimeDataSynchronization/assets/14004154/c58570e8-7b88-4b64-8621-67867d42c1bb)

- ## Application One sending message
![image](https://github.com/davidsretzlaff/RealTimeDataSynchronization/assets/14004154/9aab8db7-4b6d-4ecf-897c-415600f4f9df)

- ## Application Two received message
![image](https://github.com/davidsretzlaff/RealTimeDataSynchronization/assets/14004154/e4a3a2b2-75c1-48d0-9b3d-2d8ad3353151)


