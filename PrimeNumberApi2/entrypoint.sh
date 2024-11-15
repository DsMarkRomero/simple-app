#!/bin/bash
# Wait for SQL Server to be available
echo "Waiting for SQL Server to be available..."
sleep 20s

# Run the SQL script to create the database and tables
/opt/mssql-tools/bin/sqlcmd -S db -U mark -P 1234 -d master -i /app/PrimeNumberDB.sql

# Start the application
dotnet PrimeNumberApi2.dll