﻿using System.IO;

namespace LitExplore.Repository.Tests;

public class DatabaseTests
{
    // Enable this test and run it to seed the database without running the whole program. 
    [Fact(Skip = "We don't want to modify the live database when testing.")]
    public void SeedTest()
    {
        File.WriteAllText("appsettings.json", "{}");
        var db = new Database();
        db.Seed();
    }
}
