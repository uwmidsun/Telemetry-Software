using System;
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;

namespace Telemetry
{
public class DBConnection
{
    private SQLiteConnection _SqliteCon;

    public void OpenDatabase(string dbFileName)
    {
        try
        {
            _SqliteCon = new SQLiteConnection("Data Source=" + dbFileName);
        }
        catch (SQLiteException e)
        {
            System.Console.WriteLine("DBConnection::OpenDatabase Exception Caught: " + e.ToString());
            Environment.Exit(0);
        }
    }
    
    public void PrepareTables()
    {	
        string[] fields = { "", "", "", "", "" };
        string[] types = { "INTEGER", "REAL", "REAL", "REAL", "REAL" };
        fields[0] = "time";
        
        //MotorDriveDriverControls
        if(!TableExists("MotorDriveDriverControls"))
        {
            fields[0] = "time";
            fields[1] = "motorCurrent";
            fields[2] = "motorVelocity";
            CreateTable("MotorDriveDriverControls", fields, types, 3);
        }

        //MotorPowerDriverControls
        if(!TableExists("MotorPowerDriverControls"))
        {
            fields[0] = "time";
            fields[1] = "busCurrent";
            CreateTable("MotorPowerDriverControls", fields, types, 2);
        }
        
        //VelocityMeasurement
        if(!TableExists("VelocityMeasurement"))
        {
            fields[0] = "time";
            fields[1] = "vehicleVelocity";
            fields[2] = "motorVelocity";
            CreateTable("VelocityMeasurement", fields, types, 3);
        }
            
        //BusMeasurement
        if(!TableExists("BusMeasurement"))
        {
            fields[0] = "time";
            fields[1] = "busCurrent";
            fields[2] = "busVoltage";
            CreateTable("BusMeasurement", fields, types, 3);
        }
            
        //OdometerandBusAmpHoursMeasurement
        if(!TableExists("OdometerandBusAmpHoursMeasurement"))
        {
            fields[0] = "time";
            fields[1] = "DCBusAmpHours";
            fields[2] = "odometer";
            CreateTable("OdometerandBusAmpHoursMeasurement", fields, types, 3);
        }

        //Battery voltages
        int curVoltage = 1;
        while (curVoltage < 32)
        {
            string curTableName = "BatteryVoltages_" + curVoltage.ToString() + "To" + (curVoltage + 3).ToString();
            if (!TableExists(curTableName))
            {
                for (int i = 1; i < 5; ++i)
                {
                    fields[i] = "Voltage_" + curVoltage.ToString();
                    curVoltage++;
                }
                CreateTable(curTableName, fields, types, 5);
            }
            else
            {
                curVoltage += 4;
            }
        }

        //Add the battery temperatures
        if (!TableExists("BatteryTemperatures_1To4"))
        {
            fields[0] = "time";
            fields[1] = "Temperature_1";
            fields[2] = "Temperature_2";
            fields[3] = "Temperature_3";
            fields[4] = "Temperature_4";
            CreateTable("BatteryTemperatures_1To4", fields, types, 5);
        }
        if (!TableExists("BatteryTemperatures_5To8"))
        {
            fields[0] = "time";
            fields[1] = "Temperature_5";
            fields[2] = "Temperature_6";
            fields[3] = "Temperature_7";
            fields[4] = "Temperature_8";
            CreateTable("BatteryTemperatures_5To8", fields, types, 5);
        }

        if (!TableExists("BatteryTemperatures_9To10"))
        {
            fields[0] = "time";
            fields[1] = "Temperature_9";
            fields[2] = "Temperature_10";
            CreateTable("BatteryTemperatures_9To10", fields, types, 3);
        }

        if (!TableExists("BatteryCurrents_1To2"))
        {
            fields[0] = "time";
            fields[1] = "Current_1";
            fields[2] = "Current_2";
            CreateTable("BatteryCurrents_1To2", fields, types, 3);
        }

        if (!TableExists("BatteryCurrents_3To4"))
        {
            fields[0] = "time";
            fields[1] = "Current_3";
            fields[2] = "Current_4";
            CreateTable("BatteryCurrents_3To4", fields, types, 3);
        }

        if (!TableExists("Battery_OverUnder_Ref"))
        {
            fields[0] = "time";
            fields[1] = "OverRef";
            fields[2] = "UnderRef";
            CreateTable("Battery_OverUnder_Ref", fields, types, 3);
        }

        if (!TableExists("Battery_Temperature_OverRef"))
        {
            fields[0] = "time";
            fields[1] = "TempRef";
            CreateTable("Battery_Temperature_OverRef", fields, types, 2);
        }

        if (!TableExists("Battery_Current_OverRef"))
        {
            fields[0] = "time";
            fields[1] = "CHG";
            fields[2] = "DCHG";
            CreateTable("Battery_Current_OverRef", fields, types, 3);
        }
    }
    
    public bool TableExists(string tableName)
    {
        DataTable dataTable = GetDataTable("SELECT name FROM sqlite_master WHERE type='table' UNION ALL SELECT name FROM sqlite_temp_master WHERE type='table' ORDER BY name");
        foreach(DataRow row in dataTable.Select())
        {
            if(row["name"].ToString() == tableName)
            {
                return true;
            }
        }
        return false;
    }

    public void CreateTable(string tableName, string[] fields, string[] types, int lengthOfArray) 
    {
        ///Aiming for:
        /**CREATE TABLE My_table
        (
            my_field1   INT,
            my_field2   VARCHAR(50),
            my_field3   DATE         NOT NULL,
            PRIMARY KEY (my_field1, my_field2) 
        );*/
        
        if(TableExists(tableName))
        {
            Console.WriteLine("Table already exists.  Try deleting table first");
        }
        else
        {
            string input = "";
            
            input += "CREATE TABLE " + tableName + "(";
            
            for(int i = 0; i < lengthOfArray; i++){
                input += fields[i] + " " + types[i] + ",";
            }
            
            input = input.Remove(input.Length - 1,1); //Removes last comma ','
            
            input += ");";

            ExecuteNonQuery(input);
            Console.WriteLine("New Table Generated: " + tableName);
        }
        
        if(!TableExists(tableName))
        {
            Console.WriteLine("Failed to Create Table");
            Environment.Exit(0);
        }
    }
    
    public void DeleteTable(string tableName)
    {
        //Aiming for:
        //DROP TABLE tableName
        
        if(TableExists(tableName))
        {
            int numChangedRows = ExecuteNonQuery("DROP TABLE " + tableName);
            System.Console.WriteLine("Dropped Table: " + tableName);   
        }
        else
        {
            Console.Write("Table does not exist");   
        }
    }
    
    public void SaveMessageList(List<CANMessage> msgList)
    {
        string inputString = "";
        
        for(int i = 0; i < msgList.Count; ++i){

            //msg_2floats[0] = msgList[i].HighInt();    //DOUBLE CHECK IF REVERSED
            //msg_2floats[1] = msgList[i].LowInt();
            string[] fields = {"REAL", "REAL", "REAL", "REAL"};

            uint curId = msgList[i].getId();

            //MotorDriveDriverControls
            if(curId == Globals.DCBA + 1){
            
                fields[0] = "motorCurrent";
                fields[1] = "motorVelocity";
                inputString += GetInsertString("MotorDriveDriverControls", fields, msgList[i].getArr(), 2);
            
            //MotorPowerDriverControls
            }else if(curId == Globals.DCBA + 2){
                
                fields[0] = "busCurrent";
                inputString += GetInsertString("MotorPowerDriverControls", fields, msgList[i].getArr(), 1);
            
            //VelocityMeasurement	
            }else if(curId == Globals.MCBA + 3){
            
                fields[0] = "vehicleVelocity";
                fields[1] = "motorVelocity";
                inputString += GetInsertString("VelocityMeasurement", fields, msgList[i].getArr(), 2);
            
            //BusMeasurement
            }else if(curId == Globals.MCBA + 2){
            
                fields[0] = "busCurrent";
                fields[1] = "busVoltage";
                inputString += GetInsertString("BusMeasurement", fields, msgList[i].getArr(), 2);
            
            //OwowdometerandBusAmpHoursMeasurement
            }else if(curId == Globals.MCBA + 14){
            
                fields[0] = "DCBusAmpHours";
                fields[1] = "odometer";
                inputString += GetInsertString("OdometerandBusAmpHoursMeasurement", fields, msgList[i].getArr(), 2);
            
            //Telemetry
            }else if (curId >= Globals.JORDAN){

                //Battery Voltage
                if(curId <= Globals.JORDAN + 7){

                    uint step = curId - Globals.JORDAN; //subtract 0x700
                    uint botIndex = (step*4) + 1;       //find bottom index (example: 1 in 1to4)
                    fields[0] = "Voltage_" + botIndex;
                    fields[1] = "Voltage_" + botIndex + 1;
                    fields[2] = "Voltage_" + botIndex + 2;
                    fields[3] = "Voltage_" + botIndex + 3;

                    string tableName = "BatteryVoltages_" + botIndex + "To" + botIndex+3;

                    inputString += GetInsertString(tableName, fields, msgList[i].getArr(), 4);
                    
                //Battery Temperatures 1-4
                }else if (curId == Globals.JORDAN + 8){

                    fields[0] = "Temperature_1";
                    fields[1] = "Temperature_2";
                    fields[2] = "Temperature_3";
                    fields[3] = "Temperature_4";

                    inputString += GetInsertString("BatteryTemperatures_1To4", fields, msgList[i].getArr(), 4);

                //Battery Temperatures 5-8
                }else if (curId == Globals.JORDAN + 9){

                    fields[0] = "Temperature_5";
                    fields[1] = "Temperature_6";
                    fields[2] = "Temperature_7";
                    fields[3] = "Temperature_8";

                    inputString += GetInsertString("BatteryTemperatures_5To8", fields, msgList[i].getArr(), 4);
                
                //Battery Temperatures 9-10 and Currents 1-2
                }else if (curId == Globals.JORDAN + 10){

                    fields[0] = "Temperature_9";
                    fields[1] = "Temperature_10";
                    inputString += GetInsertString("BatteryTemperatures_9To10", fields, msgList[i].getArr(), 2);

                    fields[0] = "Current_1";
                    fields[1] = "Current_2";
                    inputString += GetInsertString("BatteryCurrents_1To2", fields, msgList[i].getArr(), 2);

                //Battery Currents 3-4 and OverRef&UnderRef
                }else if (curId == Globals.JORDAN + 11){

                    fields[0] = "Current_3";
                    fields[1] = "Current_4";
                    inputString += GetInsertString("BatteryCurrents_3To4", fields, msgList[i].getArr(), 2);

                    fields[0] = "OverRef";
                    fields[1] = "UnderRef";
                    inputString += GetInsertString("Battery_OverUnder_Ref", fields, msgList[i].getArr(), 2);
                
                //Temperature Reference and Current/Charge? References
                }else if (curId == Globals.JORDAN + 12){

                    fields[0] = "TempRef";
                    inputString += GetInsertString("Battery_Temperature_OverRef", fields, msgList[i].getArr(), 1);

                    fields[0] = "CHG";
                    fields[1] = "DCHG";
                    inputString += GetInsertString("Battery_Current_OverRef", fields, msgList[i].getArr(), 2);
                }
            }

        }
        //System.Console.WriteLine(inputString);
        ExecuteTransaction(inputString);
    }
    
    public string GetInsertString(string tableName, string[] fields, float[] messages, int lengthOfArray)
    {	
    
        /*Aiming for:
        INSERT INTO My_table 
            (field1, field2, field3) 
        VALUES 
            ('test', 'N', NULL);
        */
        
        string input = "";
        
        input += "INSERT INTO " + tableName + "(time,";
        
        for(int i = 0; i < lengthOfArray; i++){
            
            input += fields[i];
            
            if(i != (lengthOfArray -1))
                input += ",";
        }

        TimeSpan ts = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0));

        input += ") VALUES (" + ts.TotalMilliseconds + ",";
        
        for(int i = 0; i < lengthOfArray; i++)
        {
            input += messages[i].ToString();
            
            if(i != (lengthOfArray -1))
                input += ",";	
        }
        
        input += ");";
        return input;
    }
    
    private string AddZero(string input)
    {
        if(input.Length <= 1)
        {
            return ("0" + input);
        }
        return input;
    }

    private DataTable GetDataTable(string query)
    {
        DataTable dataTable = new DataTable();

        try
        {
            _SqliteCon.Open();
            SQLiteCommand command = new SQLiteCommand(_SqliteCon);
            command.CommandText = query;

            SQLiteDataReader reader = command.ExecuteReader();
            dataTable.Load(reader);
            reader.Close();
            
            _SqliteCon.Close();
        }
        catch (SQLiteException e)
        {
            System.Console.WriteLine("DBConnection::GetDataTable Exception Caught: " + e.ToString());
            Environment.Exit(0);
        }
        return dataTable;
    }

    private int ExecuteNonQuery(string sql)
    {
        int rowsUpdated = 0;

        try
        {
            _SqliteCon.Open();

            SQLiteCommand command = new SQLiteCommand(_SqliteCon);
            command.CommandText = sql;

            rowsUpdated = command.ExecuteNonQuery();

            _SqliteCon.Close();
        }
        catch (SQLiteException e)
        {
            System.Console.WriteLine("DBConnection::ExecutedNonQuery Exception Caught: " + e.ToString());
            Environment.Exit(0);
        }

        return rowsUpdated;
    }

    public void ExecuteTransaction(string Operations)
    {
        string input = "";
        input += "BEGIN TRANSACTION;" + Operations + "COMMIT;";

        int rowsUpdated = ExecuteNonQuery(input);

        System.Console.WriteLine("Executed Transcation");
    }
}
}