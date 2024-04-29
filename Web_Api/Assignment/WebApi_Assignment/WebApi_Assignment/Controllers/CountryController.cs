using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_Assignment.Models;


namespace WebApi_Assignment.Controllers

    {
        [RoutePrefix("api/User")]
        public class CountryController : ApiController
        {
            static List<Country> countrylist = new List<Country>()
        {
            new Country{ID=1, CountryName="India", Capital="New Delhi"},
             new Country{ID=2, CountryName="Karnataka", Capital="Bengaluru"},
              new Country{ID=3, CountryName="Chennai", Capital="Tamil Nadu"},
               new Country{ID=4, CountryName="Thiruvananthapuram", Capital="Kerala"},

        };

            [HttpGet]
            [Route("All")]
            public IEnumerable<Country> Get()
            {
                return countrylist;
            }
            [HttpGet]
            [Route("Bymessage")]
            public HttpResponseMessage GetAllCountry()
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, countrylist);
                // response.Content = new StringContent("Hello All");
                return response;
            }
            [HttpGet]
            [Route("ByID")]
            public IHttpActionResult CountryByID(int cid)
            {
                var country = countrylist.Find(c => c.ID == cid);
                if (country == null)
                {
                    return NotFound();
                }
                return Ok(country);
            }

            [HttpGet]
            [Route("GetName")]

            public IHttpActionResult GetCountryByName(int cid)
            {
                string cname = countrylist.Where(c => c.ID == cid).SingleOrDefault()?.CountryName;
                if (cname == null)
                {
                    return NotFound();
                }
                return Ok(cname);
            }
            [HttpGet]
            [Route("GetByCapital")]
            public IHttpActionResult GetCountryByCapital(string capital)
            {
                var country = countrylist.Find(c => c.Capital == capital);
                if (country == null)
                {
                    return NotFound();
                }
                return Ok(country);
            }


            //post
            [HttpPost]
            [Route("AllPost")]
            public List<Country> PostAll([FromBody] Country country)
            {
                countrylist.Add(country);
                return countrylist;
            }

            [HttpPost]
            [Route("countrypost")]
            public void Countrypost([FromUri] int Id, string countryname, string capital)
            {
                Country country = new Country();
                country.ID = Id;
                country.CountryName = countryname;
                country.Capital = capital;
                countrylist.Add(country);
            }

            [HttpPut]
            [Route("updcountry")]
            public void Put(int cid, [FromUri] Country c)
            {
                countrylist[cid - 1] = c;
            }

            [HttpDelete]
            [Route("delcountry")]
            public void Delete(int cid)
            {
                countrylist.RemoveAt(cid - 1);
            }
        }
    }
