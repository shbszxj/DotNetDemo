﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Data.Entity;

public class TestContext : DbContext
{
    public TestContext()
    {

    }

    public DbSet<Car> Cars { get; set; }
}