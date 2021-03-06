﻿using AutoMapper;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Vidly.Dto;
using Vidly.Models;

namespace Vidly
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // TODO: Learn AutoMapper (configure in bootstrapper class?)
            Mapper.Initialize(cfg =>
            {
                // DOMAIN TO DTO
                cfg.CreateMap<Customer, CustomerDto>();
                cfg.CreateMap<Movie, MovieDto>();
                cfg.CreateMap<MembershipType, MembershipTypeDto>();
                cfg.CreateMap<Genre, GenreDto>();
                cfg.CreateMap<Rental, RentalDto>();

                // DTO TO DOMAIN
                cfg.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, option => option.Ignore());
                cfg.CreateMap<MovieDto, Movie>().ForMember(c => c.Id, option => option.Ignore());
            });

            // WEB API
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // ASP.NET 4.7 DEFAULTS
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
