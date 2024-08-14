## Overview

Simple C# .NET console application designed to track bus drivers' break times and identify the busiest time period. It calculates the period during which the maximum number of drivers are on break, based on minute-accurate time entries.

## Features

- **Tracks break times:** bus drivers can register their break start and end times.
- **Calculates the busiest time:** application calculates the time period where most bus drivers are on break.
- **Accepts file and command line inputs:** time entries can be entered via file or command line.

## Setup

1. Clone the repository
2. Restore dependencies
   ```
   dotnet restore
   ```
3. Build the application
   ```
   dotnet build
   ```
4. Run the application
   ```
   dotnet run -- filename <path_to_file>
   ```
