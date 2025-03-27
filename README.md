# Shared Memory Data Concurrency (C# + C++ Integration)

This project demonstrates a shared memory concurrency system using C# and C++ to process and organize student data with multithreading support.

## Overview

The application is divided into two main components:

- **L1_A (C#)**: This part handles student data management, sorting using custom comparators, and monitoring sorted results with multithreading using monitors.
- **L1_B (C++)**: A separate C++ component using a Visual Studio solution to demonstrate integration, possibly for comparison or extension.

## Features

- Student class model with custom sorting logic.
- Thread-safe result accumulation using monitor-based synchronization (`SortedResultMonitor`).
- Supports sorting by name, grade, or year.
- Dual-language implementation showcasing concurrency concepts in both C# and C++.

## File Structure

```
SharedMemoryDataConcurrency/
│
├── L1_A/                        # C# Application
│   ├── Program.cs              # Main program to run threads and sorting
│   ├── Student.cs              # Student model
│   ├── StudentComparer.cs     # Custom comparer for sorting
│   └── SortedResultMonitor.cs # Monitor for thread-safe result storage
```

## How to Run

### Steps
1. Open `L1_A.sln` in Visual Studio.
2. Build the solution.
3. Run the project `L1_A` to see thread-based sorting and results.
