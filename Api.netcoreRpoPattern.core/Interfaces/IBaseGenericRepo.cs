using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Api.netcoreRpoPattern.core.Interfaces
{
	public interface IBaseGenericRepo<T> where T : class
	{
		Task<T> GetById(int id);
		Task <IEnumerable<T>> GetAll(string[]includes=null);
		T Find(Expression<Func<T, bool>> match, string[]includes=null);
		
	}
}
