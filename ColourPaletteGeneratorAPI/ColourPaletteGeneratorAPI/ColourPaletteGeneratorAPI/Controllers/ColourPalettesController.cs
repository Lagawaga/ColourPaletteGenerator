﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ColourPaletteGeneratorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColourPalettesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ColourPalettesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                select * from [ColourPalette].[dbo].[ColourPalettes]
            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ColourPalleteConnection");
            SqlDataReader myReader;
            using(SqlConnection myCon=new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using(SqlCommand myCommand=new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();  
                }
            }

            return new JsonResult(table);
        }
                    
    }
}
