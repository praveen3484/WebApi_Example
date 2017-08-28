using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.DTO_s;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class HomeController : ApiController
    {
        private CarContext context;
       public HomeController()
        {
            context = new CarContext();
        }

        //get All data using Mapper
        public IEnumerable<CarStockDTO> GetCarStockData()
        {
            return context.CarStock.ToList().Select(Mapper.Map<CarStock,CarStockDTO>);
        }

        //get Particular data using Mapper
        public CarStockDTO GetSpecificData(int id)
        {
            var cst = context.CarStock.SingleOrDefault(c => c.Id==id);
            if (cst == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<CarStock, CarStockDTO>(cst);
        }

        //post using Mapper
        [HttpPost]
        public IHttpActionResult SetData(CarStockDTO carstockDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var chk = Mapper.Map<CarStockDTO, CarStock>(carstockDTO);
            context.CarStock.Add(chk);
            context.SaveChanges();
            carstockDTO.Id = chk.Id;
            return Created(new Uri(Request.RequestUri + "/" + chk.Id),carstockDTO);
        }
        [HttpPut]
        public void PutData(int id,CarStockDTO carstockDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var abc = context.CarStock.SingleOrDefault(x => x.Id == id);
            if (abc == null)
                throw new HttpResponseException(HttpStatusCode.NoContent);
            Mapper.Map(carstockDTO,abc);
            context.SaveChanges();
            
        }
        [HttpDelete]
        public void DeleteData(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var del = context.CarStock.FirstOrDefault(x => x.Id==id);
            if (del == null)
                throw new HttpResponseException(HttpStatusCode.NoContent);
            context.CarStock.Remove(del);
            context.SaveChanges();
        }
        //[HttpGet]
        //public IHttpActionResult GetCarstock()
        //{
        //    var carst = context.CarStock.Select(x =>x);
        //    return Ok(carst);
        //}
        //[HttpGet]
        //public IHttpActionResult GetCarstock(int id)
        //{
        //    var carst = context.CarStock.FirstOrDefault(x => x.Id == id);
        //    return Ok(carst);
        //}
        //[HttpPut]
        //public IHttpActionResult UpdateCarStock(int id, CarStock carStock)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    if (id != carStock.Id)
        //    {
        //        return BadRequest();
        //    }
        //    context.Entry(carStock).State = EntityState.Modified;
        //    try
        //    {
        //        context.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
                
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        ////[HttpPost]
        ////public IHttpActionResult CreatecarStock(CarStock cs)
        ////{
        ////    var cst = context.CarStock.Add(cs);
        ////    context.SaveChanges();
        ////    return Ok("Successfully inserted");
        ////}
        //[HttpDelete]
        //public IHttpActionResult UpdateCarStock(int id)
        //{
        //    var cst = context.CarStock.FirstOrDefault(x => x.Id == id);
        //    if (cst==null)
        //        return BadRequest();
        //    else
        //    {
        //        context.CarStock.Remove(cst);
        //        context.SaveChanges();

        //    }
        //    return Ok("Successfully Removed");
        //} 





       
    }
}
//List<CarStock> carStock = new List<CarStock>
//{
//    new CarStock {Id=1,CarName="Maruti",CarModel="Swift DZire",CarColor="White",CarPrice=600000 },
//    new CarStock {Id=2,CarName="Ford",CarModel="Figo",CarColor="Apple Green",CarPrice=800000 },
//    new CarStock {Id=3,CarName="Audi",CarModel="Q7",CarColor="Black",CarPrice=2500000 },
//    new CarStock {Id=4,CarName="Audi",CarModel="A3",CarColor="White",CarPrice=2000000 }

//};

//public IHttpActionResult Get()
//{
//    return View(); 
//}


//public IEnumerable<string> Get()
//{
//    return new string[] { "Praveen", "Bhatt" };
//}
//public string Get(int id)
//{
//    return "Get Value";
//}
//public void post(string value)
//{

//}
//public void Put(int id, string value)
//{

//}