Strategy Pattern Allocation Management System
Overview
Welcome to the Strategy Pattern Allocation Management System! This project is designed to manage the expiration and availability of various types of allocations, such as vacation days, sick leave, remote work days, etc. The system updates allocation availability daily, following specific business rules for each allocation category.

This project implements the Strategy Pattern to handle the diverse behaviors associated with different types of allocations. By utilizing this design pattern, we achieve a flexible and maintainable codebase that can easily accommodate new allocation types and behaviors.

Table of Contents
Background
Features
Design Patterns Used
Strategy Pattern
What is the Strategy Pattern?
Why Use the Strategy Pattern?
Project Structure
Getting Started
Prerequisites
Running the Application
Testing
Contributing
License
Background
In the context of resource management, allocations represent entities that manage the expiration and availability of days or resources that can be requested (e.g., vacation days, remote work days). These allocations:

Have a DaysToExpiration value indicating the number of days before the allocation expires.
Have an Availability value indicating the number of days or units available for request.
The system updates the availability of each allocation daily, following specific rules that vary based on the allocation category.

Features
Daily Update of Allocations: Automatically updates the DaysToExpiration and Availability of each allocation every day.
Support for Multiple Allocation Categories: Handles various allocation types like "Vacation", "Sickness", "HomeWork", "RemoteWork", and "Compensated" allocations.
Extensible Design: Easily add new allocation types and behaviors without modifying existing code.
Strategy Pattern Implementation: Uses the Strategy Pattern to encapsulate the behaviors of different allocation types.
Design Patterns Used
Strategy Pattern
What is the Strategy Pattern?
The Strategy Pattern is a behavioral design pattern that allows you to define a family of algorithms, encapsulate each one as a separate class, and make them interchangeable. This pattern enables the algorithm to vary independently from the clients that use it.

In simpler terms, the Strategy Pattern lets you select the algorithm's behavior at runtime. It encapsulates related algorithms (strategies) so that they are interchangeable within that family.

Why Use the Strategy Pattern?
In this project, different allocation types have unique behaviors when updating their availability and expiration. By using the Strategy Pattern, we can:

Encapsulate Behaviors: Each allocation type's update logic is encapsulated in its own strategy class.
Promote Open/Closed Principle: We can add new allocation types without modifying existing code, thus the system is open for extension but closed for modification.
Enhance Maintainability: Separating the behaviors makes the code easier to understand, maintain, and test.
Increase Flexibility: Strategies can be changed or combined at runtime, allowing for dynamic behavior adjustments.
Project Structure
mathematica
Copiar código
StrategyPattern/
├── StrategyPattern.Domain/
│   ├── Entities/
│   │   └── Allocation.cs
│   ├── Services/
│   │   ├── Strategies/
│   │   │   ├── IUpdateStrategy.cs
│   │   │   ├── DefaultUpdateStrategy.cs
│   │   │   ├── VacationUpdateStrategy.cs
│   │   │   ├── HomeWorkUpdateStrategy.cs
│   │   │   ├── RemoteWorkUpdateStrategy.cs
│   │   │   ├── SicknessUpdateStrategy.cs
│   │   │   └── CompensatedUpdateStrategy.cs
│   │   └── Factories/
│   │       └── UpdateStrategyFactory.cs
├── StrategyPattern.Application/
│   ├── Services/
│   │   ├── IAllocationService.cs
│   │   └── AllocationService.cs
│   └── StrategyProgram.cs
├── StrategyPattern.Presentation/
│   └── Program.cs
├── StrategyPattern.Tests/
│   ├── DefaultUpdateStrategyTests.cs
│   ├── VacationUpdateStrategyTests.cs
│   ├── HomeWorkUpdateStrategyTests.cs
│   ├── RemoteWorkUpdateStrategyTests.cs
│   ├── SicknessUpdateStrategyTests.cs
│   ├── CompensatedUpdateStrategyTests.cs
│   └── AllocationServiceTests.cs
└── README.md
StrategyPattern.Domain: Contains the domain entities, strategies, and factories.
StrategyPattern.Application: Contains application services and orchestrators.
StrategyPattern.Presentation: The entry point of the application.
StrategyPattern.Tests: Contains all unit tests for the strategies and services.
Getting Started
Prerequisites
.NET SDK installed on your machine.
Running the Application
Clone the Repository

bash
Copiar código
git clone https://github.com/yourusername/StrategyPattern.git
Navigate to the Presentation Directory

bash
Copiar código
cd StrategyPattern/StrategyPattern.Presentation
Run the Application

bash
Copiar código
dotnet run
You should see the output of the application, showing the daily updates of each allocation.

Testing
To run the unit tests:

Navigate to the Tests Directory

bash
Copiar código
cd StrategyPattern/StrategyPattern.Tests
Run the Tests

bash
Copiar código
dotnet test
This will execute all the unit tests and display the results.

Contributing
Contributions are welcome! Please fork the repository and submit a pull request with your enhancements.

When contributing, please:

Follow the existing coding style.
Write unit tests for your changes.
Update the documentation if necessary.
License
This project is licensed under the MIT License - see the LICENSE file for details.