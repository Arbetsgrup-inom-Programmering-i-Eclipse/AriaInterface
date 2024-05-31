![Logo](https://github.com/Arbetsgrup-inom-Programmering-i-Eclipse/AriaInterface/blob/master/AriaInterface.png)

# Användning

Lägg till `AriaInterface.cs` i ditt projekt. Använd sedan klassen för att ställa SQL-frågor mot Ariadatabasen enligt nedan.
Detta repository innehåller även en WinForms-applikation som använder `AriaInterface.cs` för att ställa godtyckliga SQL-frågor till valfri Ariadatabas.

# Exempel

### Query
```cs
    (DataTable dataTable, Exception exception) = AriaInterface.Query(AriaDatabase.TBox, "SELECT * FROM Patient WHERE PatientId LIKE 'test%'");
        
    // dataTable kommer vara tom om ett fel uppstår
    // exception innehåller information om felet
   
    foreach(DataRow row in dataTable.Rows)     
    {
        // Lite kod...
        // Eftersom dataTable inte innehåller några rader vid fel så kommer denna kod inte att köras i händelse av fel
    }
```

### Query med parametrar
```cs
    (DataTable dataTable, Exception exception) = AriaInterface.Query(AriaDatabase.TBox, "SELECT * FROM Patient WHERE PatientId LIKE @patId AND PatientSer>@patSerFrom", ("@patId", "test%"), ("@patSerFrom", 10000));
```

### Query där eventuella fel visas genom dialogruta
```cs
    DataTable dataTable = AriaInterface.QueryWithErrorMessage(AriaDatabase.TBox, "SELECT * FROM Patient WHERE PatientId LIKE 'test%'");
    
    // dataTable kommer att vara null om ett fel uppstår

    if(dataTable != null)
    {
        // Lite kod...
    }
```

# License

Distribuerad under MIT License. Se `LICENSE.txt` för mer information.
