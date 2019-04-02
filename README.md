# 2 cards automated power game
This is sample pocker game app following SOLID, DRY, TDD and design patterns

## 1. Design
Key design elements: 
1. Domain driven design: 
* Deck has list of Cards which is composited by Suit and Rank
* Game has a number of Rounds and each Rounds has a list of PlayerHand (which is composited of Player and a set of Cards)
* Design the service as stateless: GameRuleService and DealerService for example
* Handle exceptions of invalid number of players, rounds or cards setup etc.

2. Design pattern uses
* OOP for design models
* Dependency Injection (via class constructor for all services, repositories and so on)
* Repository pattern for generic repository of BaseEntity type implementation
* And more 

3. Principles and practice
* SOLID, DRY
* TDD

## 2. Requirement

1. .NET 4.6.1 ++
2. Visual Studio 2018

## 3. How-to Run

1. Download the project file from github link 
2. Open unzip the project
2. Open Pocker.sln
3. Right click on the Pocker.ConsoleApp and select "Set as Startup Project"
4. Click Start
5. Following the instruction on the Console Windows and enjoy the game !

Happy coding !
