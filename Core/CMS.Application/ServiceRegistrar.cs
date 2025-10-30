using CMS.Application.Common.Business;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application;

public static class ServiceRegistrar
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {

        services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.LicenseKey = "eyJhbGciOiJSUzI1NiIsImtpZCI6Ikx1Y2t5UGVubnlTb2Z0d2FyZUxpY2Vuc2VLZXkvYmJiMTNhY2I1OTkwNGQ4OWI0Y2IxYzg1ZjA4OGNjZjkiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2x1Y2t5cGVubnlzb2Z0d2FyZS5jb20iLCJhdWQiOiJMdWNreVBlbm55U29mdHdhcmUiLCJleHAiOiIxNzkyMTA4ODAwIiwiaWF0IjoiMTc2MDYzMDg1MyIsImFjY291bnRfaWQiOiIwMTk5ZWRjNWY2Mzg3NjMzODUwODliZjEwMDcyMTlhYyIsImN1c3RvbWVyX2lkIjoiY3RtXzAxazdwd2RrZHFieXYzNDBuNGJtNXFlYjVwIiwic3ViX2lkIjoiLSIsImVkaXRpb24iOiIwIiwidHlwZSI6IjIifQ.rAJFCjLipxf2JNc7udDQKSImW_fEKzHmCqXr_dx66hmzD64Vrahoer3NAjeCojJi-Ers6q-42h2cb8rNN7QS5bCylX3tiHmZoFkmVqpxz6lqtYDk1WP8jOk9RpbGuykB-leaxgGlNpz6avHzqt_YSu9lPgTZLNnFpFlDvTfTwYZqxHfLyPl2opCwMHEHCzZiHi2GdV5j5sTscyi5xXsNWCNHJi5_1GUFpjZ1-EH3rBaAgFbfsdaf0Xalk1SL5r8Ruh8n5kfuyfLYg0ryPjQU28MPHk0YdN18ChMjvsenyX7UYOgXievw1WVVOASku9BjjmnsPXWuCikI_yCTabvoZA";
        });
        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BusinessRule));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }

    public static IServiceCollection AddSubClassesOfType(this IServiceCollection services, Assembly assembly, Type type)
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (var item in types)
                services.AddScoped(item);
        return services;
    }
}
