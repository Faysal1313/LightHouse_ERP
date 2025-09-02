# Lighthouse ERP System - ACS RPL Project
=>This repository was created recently to provide easy access and review for the ACS assessment.
==>The project itself was originally developed in 2019. A Lighthouse ERP demonstration video is also attached.
ℹ️ Technical Notes & Improvement Areas
This project reflects an early developmental stage and may contain some practices that can be improved for a production environment:

Current Practices:
Database Connection Management: Handled through a centralized static class.
Query Execution: Direct use of SQL queries.
Error Management: There is a basic error logging system.
Areas for Future Improvement:
Parameterized Queries: To enhance security and prevent SQL Injection attacks.
Dependency Injection: To make connection management more flexible and testable.
Repository Pattern: To separate business logic from data logic.
Async/Await: To improve application performance in long-running operations.
Configuration Management: More secure handling of connection data.
Note: These observations reflect the development of technical skills and the ability to critique and improve code.

📌 Overview
Lighthouse ERP is a comprehensive desktop-based Enterprise Resource Planning system developed for small and medium enterprises using C# .NET Framework and SQL Server. The system manages complete business operations including Accounting, Sales, Purchases, Inventory, Human Resources, and Point-of-Sale functionality.

🏗️ Project Architecture & Solution Structure
📂 Solution Directory Structure
text
```
LighthouseERP/
├───📁 Account/
│   └───📁 report_account/
│       ├───📁 report_finance_statment/
│       ├───📁 report_form_account/
│       └───📁 report_screen/
│
├───📁 HR/
│   └───📁 report_hr/
│
├───📁 Images/
├───📁 import_excel/
├───📁 Inventory/
│   └───📁 printer_items/
│       └───📁 report_items/
│           └───📁 report_screen/
│
├───📁 Log_in/
├───📁 notification/
├───📁 opening_closing/
│   └───📁 close_db/
│
├───📁 POS/
├───📁 Purchase/
│   └───📁 report_purchase/
│       └───📁 form_report_purchase/
│
├───📁 Sales/
│   └───📁 sales_report/
│       └───📁 sale_forms/
│
├───📁 ship_jop/
├───📁 type_and_book/
└───📁 Classes/
```
🔧 Technical Implementation
🎯 Custom Database Connectivity Implementation
Note: This project implements a custom database access layer without using Entity Framework. The connection management is handled through a static class that provides centralized database operations.

Core Database Connection Class
csharp
public static class db
{
    // Database connection parameters
    public static string dbname;
    public static string ip;
    public static string sql_pass;
    public static string sql_user;
    public static string DBxx;
    public static SqlConnection conn;
    public static SqlCommand cmd;

    // Static constructor for initialization
    static db()
    {
        db.dbname = frm_login.strdb;
        db.ip = Settings.Default.server;
        db.sql_pass = Settings.Default.sql_pass;
        db.sql_user = Settings.Default.sql_name;
        db.DBxx = "Data Source=" + db.ip + " ;Initial Catalog=" + db.dbname + " ;Integrated Security=False ; USER ID='" + db.sql_user + "' ; Password='" + db.sql_pass + "'";
        db.conn = new SqlConnection(db.DBxx);
        db.cmd = new SqlCommand("", db.conn);
    }

    // Open database connection
    public static void Open()
    {
        try
        {
            if (db.conn.State != ConnectionState.Closed)
                return;
            db.conn.Open();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message + "       \nPlease restart the application and select the correct database\n", "Error");
            db.log_error(string.Concat(ex));
        }
    }

    // Close database connection
    public static void Close()
    {
        if (db.conn.State != ConnectionState.Open)
            return;
        db.conn.Close();
    }

    // Execute query and return DataTable
    public static DataTable GetData(string select)
    {
        DataTable dataTable = new DataTable();
        db.cmd.CommandText = select;
        dataTable.Load(cmd.ExecuteReader());
        return dataTable;
    }

    // Error logging method
    private static void log_error(string errorMessage)
    {
        File.AppendAllText("error_log.txt", DateTime.Now + ": " + errorMessage + Environment.NewLine);
    }
}
🛠️ Technology Stack
Frontend: Windows Forms (.NET Framework)

Backend: C# with ADO.NET

Database: Microsoft SQL Server

Data Access: Custom database layer without ORM

Architecture: Modular structure with separation of concerns

Reporting: Integrated reporting system across all modules

📊 Module Overview
🔹 Account Module
Financial statements reporting

Account forms management

Finance screen reporting

🔹 HR Module
Human resources reporting

Employee management

Payroll processing

🔹 Inventory Module
Stock management

Items reporting

Printer integration for items

🔹 Sales Module
Sales reporting

Sales forms management

Customer relationship management

🔹 Purchase Module
Procurement management

Purchase reporting

Supplier management

🔹 Additional Modules
POS: Point of Sale system

Import/Export: Excel data integration

Notifications: System alerts and messages

Shipping: Job management and tracking

🎯 ANZSCO Skills Demonstrated
This project demonstrates competency for Software Engineer (261313):

✅ Software Architecture: Modular design with separation of concerns

✅ Database Management: Custom SQL Server implementation

✅ Business Logic: Complex ERP system development

✅ Reporting Systems: Comprehensive reporting across all modules

✅ User Interface: Windows Forms application development

✅ Data Integration: Excel import/export functionality

⚙️ Technical Features
Modular Design: Separate modules for each business function

Custom Reporting: Advanced reporting capabilities across all modules

Data Integration: Excel import/export functionality

User Authentication: Secure login system

Inventory Management: Complete stock control system

Financial Processing: Accounting and finance management

🔄 Workflow Integration
The system integrates multiple business workflows:

Sales to Inventory: Automatic stock updates on sales

Purchase to Accounting: Financial tracking of procurement

HR to Reporting: Employee performance reporting

POS to Sales: Real-time sales data integration

