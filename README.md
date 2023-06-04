# TombOfTheMask
The Tomb Of The Mask game was programmed by me using C# and SplashKit library.

My program takes inspiration from the game called Tomb Of The Mask. In order to win the stages, the player has to overcome obstacles and goes through all the cells of the stage. 

The users will be ranked by their current stage and the amount of time that they take for every stage.

# UML diagram
![TOTM drawio](https://github.com/nglinhbao/TombOfTheMask/assets/110576552/64c52cac-78b1-4033-ae39-9189581e46f2)

# Gameplay
<img width="451" alt="image" src="https://github.com/nglinhbao/TombOfTheMask/assets/110576552/3c56c791-2068-46ed-b385-c2cc343aaf0f">
<img width="451" alt="image" src="https://github.com/nglinhbao/TombOfTheMask/assets/110576552/c0859ae3-450a-480c-a6c9-656e939a77f5">
<img width="451" alt="image" src="https://github.com/nglinhbao/TombOfTheMask/assets/110576552/c36bca48-96e5-42b5-b96f-599592f5b5c1">


# Design patterns
•	Factory method: a creational design pattern that provides an interface for creating objects in a superclass, but allows subclasses to alter the type of objects that will be created. The code includes a TileFactory class that encapsulates the creation of Tile objects based on different types. The factory method CreateTile is responsible for creating the appropriate tile object based on the given type. This design pattern allows subclasses (RedTile, BlueTile, GreenTile, etc.) to define their specific implementations while the TileFactory provides a common interface for creating tiles. This promotes flexibility, extensibility, and separation of object creation logic from the client code.

•	Command method: Command is a behavioral design pattern that turns a request into a stand-alone object that contains all information about the request. This transformation lets you pass requests as a method arguments, delay or queue a request’s execution, and support undoable operations. By using the Command pattern, the code achieves better separation of concerns, promotes flexibility and extensibility, and provides a foundation for implementing undo/redo functionality if needed in the future.

•	Model-View-Controller design pattern: MVC is a commonly used pattern for designing software applications that separates the application's concerns into three components: Model, View, and Controller. The MVC pattern provides several benefits, including separation of concerns, modularity, and ease of maintenance. It allows for the independent development and testing of each component, promotes code reuse, and facilitates the addition of new features or modifications without affecting the other components.
