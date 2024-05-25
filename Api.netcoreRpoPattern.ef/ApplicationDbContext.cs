using Api.netcoreRpoPattern.core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.netcoreRpoPattern.ef
{
	public class ApplicationDbContext:DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }
        public virtual DbSet<Author> Authors { get; set; }
		public virtual DbSet<Book> Books { get; set; }

	}
}
