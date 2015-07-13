﻿using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Web.Http;
using GISCommunity.WebApi.Models;
using System.Configuration;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;

namespace GISCommunity.WebApi.Controllers
{
    public class PortalsController : ApiController
    {
        [Route("sharing/rest/portals/self")]
        [HttpGet]
        public String Self()
        {
            return "hi";
        }



        [AllowAnonymous]
        [Route("sharing/rest/portals/languages")]
        [HttpGet]
        public List<LanguageEntry> GetLanguages()
        {
            var key = "urn:languages:";

            using (var cachecon = ConnectionMultiplexer.Connect(ConfigurationManager.ConnectionStrings["CacheDB"].ToString()))
            {
                IDatabase cache = cachecon.GetDatabase();
                if (cache.KeyExists(key))
                {
                    return JsonConvert.DeserializeObject<List<LanguageEntry>>(cache.StringGet(key));
                }
            }

            var languages = new List<LanguageEntry>(30);
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLStore"].ToString()))
            {
                var command = new SqlCommand("SELECT [LANGUAGE],[CULTURE],[LOCALIZEDNAME] FROM [OneGISDB].[dbo].[LANGUAGES]", connection);
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        languages.Add(new LanguageEntry()
                        {
                            Language = reader.GetString(0),
                            Culture = reader.GetString(1),
                            LocalizedName = reader.GetString(2)
                        });
                    }
                }
                reader.Close();
            }
            if (languages.Count == 0)
            {
                using (var cachecon = ConnectionMultiplexer.Connect(ConfigurationManager.ConnectionStrings["CacheDB"].ToString()))
                {
                    IDatabase cache = cachecon.GetDatabase();
                    if (cache.KeyExists(key))
                    {
                        cache.StringSetAsync(key, JsonConvert.SerializeObject(languages));
                    }
                }
            }

            return languages;
        }

        [AllowAnonymous]
        [Route("sharing/rest/portals/regions")]
        [HttpGet]
        public List<RegionEntry> GetRegions(string culture = "en")
        {
            culture = culture.ToLower();
            var key = "urn:regions:" + culture;

            using (var cachecon = ConnectionMultiplexer.Connect(ConfigurationManager.ConnectionStrings["CacheDB"].ToString()))
            {
                IDatabase cache = cachecon.GetDatabase();
                if (cache.KeyExists(key))
                {
                    return JsonConvert.DeserializeObject<List<RegionEntry>>(cache.StringGet(key));
                }
            }

            var regions = new List<RegionEntry>(80);
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLStore"].ToString()))
            {
                var command = new SqlCommand("SELECT [NAME],[REGION],[LOCALIZEDNAME] FROM [dbo].[REGIONS] WHERE [CULTURE]=@lang;", connection);
                var parameter = new SqlParameter()
                {
                    ParameterName = "@lang",
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Input,
                    Value = culture
                };
                command.Parameters.Add(parameter);
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        regions.Add(new RegionEntry()
                        {
                            Name = reader.GetString(0),
                            Region = reader.GetString(1),
                            LocalizedName = reader.GetString(2)
                        });
                    }
                }
                reader.Close();
            }
            if (regions.Count == 0)
            {
                using (var cachecon = ConnectionMultiplexer.Connect(ConfigurationManager.ConnectionStrings["CacheDB"].ToString()))
                {
                    IDatabase cache = cachecon.GetDatabase();
                    if (cache.KeyExists(key))
                    {
                        cache.StringSetAsync(key, JsonConvert.SerializeObject(regions));
                    }
                }
            }

            return regions;
        }

    }
}
