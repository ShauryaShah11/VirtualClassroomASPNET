# VirtualClassroomASPNET

## Database Setup

### Attach the Database

1. Open SQL Server Management Studio (SSMS).
2. Connect to your local SQL Server instance.
3. Right-click on "Databases" in the Object Explorer.
4. Select "Attach" and choose the `Virtual_classroom.mdf` file.

### Get the Database Path

1. After attaching the database, right-click on it in SSMS.
2. Choose "Properties" and navigate to the "File" tab.
3. Note down the "Path" of the `.mdf` file.

## Updating web.config

1. Open your ASP.NET project in Visual Studio.
2. Locate the `web.config` file in the project's root directory.
3. Update the connection string in `web.config` to point to the database file path:

    ```xml
    <connectionStrings>
        <add name="MyConnectionString" 
             connectionString="Data Source=.\SQLExpress;AttachDbFilename=PATH_TO_YOUR_DATABASE_MDF;Integrated Security=True;" 
             providerName="System.Data.SqlClient" />
    </connectionStrings>
    ```

   Replace `PATH_TO_YOUR_DATABASE_MDF` with the path obtained in the previous step.
