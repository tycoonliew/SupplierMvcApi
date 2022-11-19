# Supplier Mvc Api

## Summary
Manages products and suppliers for companies. 
Built on ASP.Net MVC. Uses Dapper as an ORM. 
Currently uses an SQLite DB for demonstration purposes, but can be expanded to include other DBs through IDataService.

## Installation
This project requires the [.Net 5 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/5.0) to run. 

### CLI instructions
Navigate to the project path and run ```dotnet restore``` then ```dotnet run```.

You should be able to access the frontend interface through http://localhost:5000 or https://localhost:5001 by default.

### Visual studio instructions
Alternatively you can simply open the .sln file in Visual Studio and press 'Start Debugging'.

## API Routes
**Products**

```GET /api/products```
returns list of Products

```POST /api/products```
takes a body of type Product
adds it to the database
```
{
	"ProductName": "Test Product",
	"SKU": "exampleSKU",
	"Availability": true,
	"SupplierId": 1
}
```

**Suppliers**

```GET /api/suppliers```
returns list of Suppliers

```POST /api/suppliers```
takes body of type Supplier
adds it to database
```
{
	"SupplierName": "Example Supplier"
}
```

