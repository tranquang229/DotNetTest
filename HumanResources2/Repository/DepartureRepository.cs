﻿using System;
using Dapper;
using HumanResources2.Context;
using HumanResources2.Interfaces;
using HumanResources2.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HumanResources2.Repository;

public class DepartureRepository: IDepartureRepository
{
    private readonly DapperContext _context;
    public DepartureRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Departure>> Create(Departure entity)
    {
        string query = $"INSERT INTO Departures(DepartureId, Name) VALUES (\'{entity.DepartureID}\', \'{entity.Name}\');";

            using (var connection = _context.CreateConnection())
        {
            var dapartures = await connection.QueryAsync<Departure>(query);
            return dapartures;
        }
        //    //throw new NotImplementedException();
    }

    public Task<IEnumerable<Departure>> Delete(Departure entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Departure>> FindAll()
    {
        var query = "SELECT de.DepartureID, de.Name FROM Departures as de";
        using (var connection = _context.CreateConnection())
        {
            var dapartures = await connection.QueryAsync<Departure>(query);
            return dapartures;
        }
    }

    public async Task<IEnumerable<Departure>> FindOneById(Departure entity)
    {
        var query = $"SELECT de.DepartureID, de.Name FROM Departures as de WHERE de.DepartureID = {entity.DepartureID}";
        using (var connection = _context.CreateConnection())
        {
            var daparture = await connection.QueryAsync<Departure>(query);
            return daparture;
        }
        //throw new NotImplementedException();
    }

    public async Task<IEnumerable<Departure>> Update(Departure entity)
    {
        var query = $"UPDATE Departures SET Name=\'{entity.Name}\' WHERE DepartureID = {entity.DepartureID}";
        using (var connection = _context.CreateConnection())
        {
            var daparture = await connection.QueryAsync<Departure>(query);
            return daparture;
        }
        throw new NotImplementedException();
    }

}

