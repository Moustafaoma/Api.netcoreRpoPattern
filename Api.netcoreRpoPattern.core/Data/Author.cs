using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.netcoreRpoPattern.core.Data
{
	public class Author
	{
		public int Id { get; set; }
		[Required,MaxLength(100),MinLength(1)]
		public string Name { get; set; }
	}
}
