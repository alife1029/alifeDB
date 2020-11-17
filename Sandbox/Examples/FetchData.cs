﻿using System;
using alifeDB.Database;

namespace Sandbox.Examples
{
    class FetchData
    {
        public FetchData()
        {
            // Veritabanı imleci oluşturup bir veritabanına bağlanır
            DatabaseCursor database = new DatabaseCursor();
            database.Connect(@"C:\Users\Ali Efe GÜR\Desktop\myDatabase.alfdb", "database");

            // İmleci bir tabloya götürür
            database.GoToTable("personalData");

            /*
                İmlecin bulunduğu tabloda 0. indeksten 5. indekse kadar olan kayıttan 
                id, ad ve soyad sütunlarındaki verileri çeker
            */
            object[][] fetchedDatas = new object[4][];
            for (int i = 0; i < 4; i++)
            {
                fetchedDatas[i] = database.FetchData(
                    i, new string[] { "id", "name", "last_name" }
                );
            }

            for (int i = 0; i < fetchedDatas.Length; i++)
                for (int j = 0; j < fetchedDatas[i].Length; j++)
                    Console.WriteLine(fetchedDatas[i][j]);
        }
    }
}
