using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForAngular11.Models
{
    public class PaymentDetailConstext:DbContext
    {
        public PaymentDetailConstext(DbContextOptions<PaymentDetailConstext> options):base(options)
        {

        }

        public DbSet<PaymentDetail> PaymentDetails { get; set; }
    }
}
