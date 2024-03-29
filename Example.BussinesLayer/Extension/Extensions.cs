﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.DataAccessLayer;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Example.DataAccessLayer.Abstract;
using Example.DataAccessLayer.Concrate;
using Example.BussinesLayer.Abstract;
using Example.BussinesLayer.Concrate;
using Microsoft.AspNetCore.Http;
using Example.Entity.ComplexType;
using Example.CORE.Model;
using System.Net;

public static class Extensions
{

    public static bool CheckEnumField(this Enum Item)
    {
        var Values = Enum.GetValues(Item.GetType());
        var Enums = Values.Cast<Enum>().Select(x => x.GetType().GetField(x.ToString()).GetValue(x.ToString())).ToList();
        return Enums.Any(x => x.ToString() == Item.ToString());
    }
    public static int GetUserId(this HttpContext context)
    {

        var UserId = context.User.Claims.FirstOrDefault(x => x.Type == "ID")?.Value;

        return Convert.ToInt32(UserId);
    }


    public static ServiceResult<T> SuccessResult<T>(this IHttpContextAccessor Context, T Data, string Message, HttpStatusCode statusCode = HttpStatusCode.Accepted)
    {

        Context.HttpContext.Response.StatusCode = (int)statusCode;


        return ServiceResult<T>.SuccessResult(Data,Message,(int)statusCode);
    }


    public static ServiceResult<T> FailureResult<T>(this IHttpContextAccessor Context, string Message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
    {

        Context.HttpContext.Response.StatusCode = (int)statusCode;


        return ServiceResult<T>.FailureResult(Message, (int)statusCode);
    }
    public static void SetIOC(this IServiceCollection IOC)
    {

        IOC.AddScoped<IUserRepoStory, UserRepoStoryManager>();
        IOC.AddScoped<IUserService, UserManager>();
        IOC.AddScoped<IVehiclesRepoStory, VehiclesRepoStoryManager>();
        IOC.AddScoped<IVehicles, VehiclesManager>();
        IOC.AddScoped<ICheckDataBase, CheckDataBase>();
        IOC.AddScoped<IVehicleFactory<Car>, CarManager>();
        IOC.AddScoped<IVehicleFactory<Bus>, BusManager>();
        IOC.AddScoped<IVehicleFactory<Boat>, BoatManager>();
        IOC.AddScoped<IToggleLight<Car>, CarManager>();
        IOC.AddScoped<IremoveVehicle<Car>, CarManager>();


        var Config = IOC.BuildServiceProvider().GetRequiredService<IConfiguration>();

        Settings.Instance.ConnectionString = Config.GetConnectionString("DefaultConnection");

        var Check = IOC.BuildServiceProvider().GetRequiredService<ICheckDataBase>();

        Check.CheckDb();



    }
}

