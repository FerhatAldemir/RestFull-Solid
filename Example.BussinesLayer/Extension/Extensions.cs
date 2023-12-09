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

public static class Extensions
{

    public static bool CheckEnumField(this Enum Item)
    {
      var Values =  Enum.GetValues(Item.GetType());
       var Enums =Values.Cast<Enum>().Select(x => x.GetType().GetField(x.ToString()).GetValue(x.ToString())).ToList();
      return Enums.Any(x => x.ToString() == Item.ToString());
    }
    public static int GetUserId(this HttpContext context) {

       var UserId = context.User.Claims.FirstOrDefault(x=>x.Type == "ID").Value;

        return Convert.ToInt32(UserId);
    }
    public static void SetIOC(this IServiceCollection IOC)
    {
       
        IOC.AddScoped<IUserRepoStory,UserRepoStoryManager>();
        IOC.AddScoped<IUserService,UserManager>();
        IOC.AddScoped<IVehiclesRepoStory, VehiclesRepoStoryManager>();
        IOC.AddScoped<IVehicles, VehiclesManager>();
        IOC.AddScoped<CarManager>();
        IOC.AddScoped<BusManager>();
        IOC.AddScoped<BoatManager>();


        var Config = IOC.BuildServiceProvider().GetRequiredService<IConfiguration>();
       Example.DataAccessLayer.Settings.ConnectionString = Config.GetConnectionString("DefaultConnection");



    }
}

