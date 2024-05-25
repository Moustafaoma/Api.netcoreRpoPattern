using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.netcoreRpoPattern.core.Data
{
	public class Book
	{
        public int Id { get; set; }
        [Required,MaxLength(250)]
		public string Title { get; set; }
        public virtual Author? Author { get; set; }
        public int AuthorId { get; set; }
    }
}
