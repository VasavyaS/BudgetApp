# BudgetApp

## Overview

BudgetApp is a personal financial management web application developed using **ASP.NET Core** and **Razor Pages/MVC**. Its primary purpose is to help users manage their expenses and income by categorizing transactions efficiently. The application provides an intuitive interface backed by a robust backend framework, allowing users to create, edit, delete, and view transactions and categories.

---

## Features

- **Dashboard for Categories and Transactions**
    - View, create, edit, and delete both categories and transactions.
    - Filtering and searching capabilities for transactions by date, category, or name.
- **Dynamic Modals**
    - Operations like creating, editing, and deleting are done using dynamic modals for seamless user experience.
- **Category and Transaction Management**
    - Assign transactions to categories for better organization.
    - CRUD (Create, Read, Update, Delete) implementation for both entities.
- **Data Validation**
    - Comprehensive front-end and server-side validation for all forms.
- **AJAX Integration**
    - Fully integrated with AJAX to enhance responsiveness and reduce page reloads.
- **Bootstrap Styling**
    - Modern UI styling with **Bootstrap 5** for responsive and clean design.

---

## Technologies Used

**Backend:**
- **.NET 8.0**: Latest framework version with high performance.
- **ASP.NET Core MVC**: Framework for building web apps.
- **Entity Framework Core**: ORM for database handling.
- **SQL Server**: Relational database for storage.

**Frontend:**
- **Razor Views**: For building dynamic server-side rendered pages.
- **Bootstrap 5**: For responsive and styled user interface.
- **jQuery & AJAX**: For dynamic modal operations.

---

## Requirements

To run this application, ensure your environment meets the following requirements:

1. **.NET SDK 8.0** or higher installed ([Download here](https://dotnet.microsoft.com/download)).
2. **SQL Server** or a compatible database.
3. A development environment/IDE such as **JetBrains Rider**, **Visual Studio**, or **Visual Studio Code**.

---

## Getting Started

### 1. Clone the Repository

```bash
git clone <repository-url>
cd BudgetApp
```

### 2. Configure the Database

Update the connection string in `appsettings.json` to point to your SQL Server database:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=PersonalFinanceDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

### 3. Database Setup

Run migrations to create the necessary database structure:

```bash
dotnet ef database update
```

### 4. Run the Application

Start the application:

```bash
dotnet run
```

Navigate to [https://localhost:5001](https://localhost:5001) or [http://localhost:5000](http://localhost:5000).

---
