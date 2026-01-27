# ChessGame

A Chess game built with **.NET and C#**.

This project is a console/desktop chess game implemented in C# using .NET. It features the core mechanics of chess, including a board, pieces, and gameplay logic. Feel free to explore, improve, and extend it! :contentReference[oaicite:1]{index=1}

## 🧠 Overview

- 🗂️ Built with **C# (.NET)**  
- ♟️ Chess rules and logic implemented  
- 🖥️ Simple visual representation (console)  
- ♟️ Allows two players to play a full game of chess  
- 📦 Includes main entry point (`Program.cs`) and game logic classes (`Screen.cs`, etc.) 

## 🚀 Features

✔ Board and pieces representation  
✔ Basic movement logic for all pieces  
✔ Player turn control  
✔ Game loop flow  
✔ Console/Window display for board state  
✔ Extensible code structure for rule improvements

## 🛠️ Getting Started

### Requirements

- .NET 6 (or later) SDK installed  
- A C# IDE (Visual Studio, VS Code, Rider, etc.)  

### Clone the repository

```bash
git clone https://github.com/donzzim/ChessGame.git
```
### Build & Run

1. Open the solution file (ChessGame.sln) in your IDE
2. Build the project
3. Run the application
Or via command line:
```bash
cd ChessGame
dotnet build
dotnet run --project ChessGame.csproj
```

## 📁 Project Struture
```text
ChessGame/
├── ChessGame.sln
├── ChessGame.csproj
├── Program.cs
├── Screen.cs
├── chess/              # Core classes (Board, Pieces, Moves, etc.)
├── chessboard/         # Rendering / visualization logic
└── README.md
```
## 🧩 How to Play

- The game runs in a console or window.

- Follow prompts to move pieces.

- Use standard chess notation or coordinate-based input.

- The game enforces turn order.

## 🛠️ How It Works

The main parts of the game include:

✔ **Board Representation** – Tracks piece positions

✔ **Piece Logic** – Each chess piece implements its own movement rules

✔ **Game Loop** – Handles player turns, move validation, game state

✔ **Rendering** – Displays the board state in the console/window
