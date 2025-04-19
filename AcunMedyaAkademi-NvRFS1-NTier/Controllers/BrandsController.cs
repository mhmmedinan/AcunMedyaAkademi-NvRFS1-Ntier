using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace AcunMedyaAkademi_NvRFS1_NTier.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : ControllerBase
{
    private readonly string _connectionString;

    public BrandsController(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("AdonetConnection");
    }

    //localhost:5000/api/brands
    [HttpGet]
    public IActionResult GetBrands()
    {
        var brands = new List<Brand>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {

            string query = "Select Id,Name From Brands";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                brands.Add(new Brand
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                });
            }

            connection.Close();
        }

        //200 döner
        return Ok(brands); //Http status kodları

    }


    [HttpGet("{name}")]
    public IActionResult GetBrands(string name)
    {
        var brands = new List<Brand>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {

            string query = "Select Id,Name From Brands Where Name = '" + name + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                brands.Add(new Brand
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                });
            }

            connection.Close();
        }

        //200 döner
        return Ok(brands); //Http status kodları

    }

}


