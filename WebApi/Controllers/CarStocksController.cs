using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CarStocksController : ApiController
    {
        private CarContext db = new CarContext();

        // GET: api/CarStocks
        public IQueryable<CarStock> GetCarStock()
        {
            return db.CarStock;
        }

        // GET: api/CarStocks/5
        [ResponseType(typeof(CarStock))]
        public IHttpActionResult GetCarStock(int id)
        {
            CarStock carStock = db.CarStock.Find(id);
            if (carStock == null)
            {
                return NotFound();
            }

            return Ok(carStock);
        }

        // PUT: api/CarStocks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCarStock(int id, CarStock carStock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carStock.Id)
            {
                return BadRequest();
            }

            db.Entry(carStock).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarStockExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CarStocks
        [ResponseType(typeof(CarStock))]
        public IHttpActionResult PostCarStock(CarStock carStock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CarStock.Add(carStock);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = carStock.Id }, carStock);
        }

        // DELETE: api/CarStocks/5
        [ResponseType(typeof(CarStock))]
        public IHttpActionResult DeleteCarStock(int id)
        {
            CarStock carStock = db.CarStock.Find(id);
            if (carStock == null)
            {
                return NotFound();
            }

            db.CarStock.Remove(carStock);
            db.SaveChanges();

            return Ok(carStock);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarStockExists(int id)
        {
            return db.CarStock.Count(e => e.Id == id) > 0;
        }
    }
}