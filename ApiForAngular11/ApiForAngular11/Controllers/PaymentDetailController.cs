using ApiForAngular11.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForAngular11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailController : ControllerBase
    {
        private PaymentDetailConstext _db;

        public PaymentDetailController(PaymentDetailConstext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDetail>>> GetPaymentDetails()
        {
            return await _db.PaymentDetails.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDetail>> GetPaymentDetail(int id)
        {
            var paymentDetail = await _db.PaymentDetails.FindAsync(id);
            if (paymentDetail== null)
            {
                return NotFound();
            }

            return paymentDetail;
        }

        [HttpPost]
        public async Task<ActionResult<PaymentDetail>> PostPaymentDetail(PaymentDetail paymentDetail)
        {
            _db.PaymentDetails.Add(paymentDetail);
            await _db.SaveChangesAsync();
            return CreatedAtAction("GetPaymentDetail", new { id = paymentDetail.PaymentDetailId }, paymentDetail);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutPaymentDetail(int id, PaymentDetail paymentDetail)
        {
            if (id != paymentDetail.PaymentDetailId)
            {
                return BadRequest();
            }
            _db.Entry(paymentDetail).State = EntityState.Modified;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!PaymentDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public  async Task<ActionResult> DeletePaymentDetail(int id)
        {
            var paymentDetail = await _db.PaymentDetails.FindAsync(id);
            if(paymentDetail == null)
            {
                return NotFound();
            }

            _db.PaymentDetails.Remove(paymentDetail);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentDetailExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
