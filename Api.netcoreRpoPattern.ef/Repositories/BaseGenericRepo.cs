using Api.netcoreRpoPattern.core.Data;
using Api.netcoreRpoPattern.core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Api.netcoreRpoPattern.ef.Repositories
{
	//this is comment
	public class BaseGenericRepo<T> : IBaseGenericRepo<T> where T : class
	{
		protected readonly ApplicationDbContext _context;

		public BaseGenericRepo(ApplicationDbContext context)
		{
			_context = context;
		}

		public T Find(Expression<Func<T, bool>> match, string[]includes=null)
		{
			IQueryable<T> query= _context.Set<T>();
			if(includes != null)
			{
				foreach(var include in includes)
					query=query.Include(include);
			}
			return  query.SingleOrDefault(match);
		}

		public async Task<IEnumerable<T>> GetAll(string[]includes=null)
		{
			IQueryable<T> query= _context.Set<T>();
			if(includes != null)
			{
				foreach (var include in includes)
					query=query.Include(include);
			}
			return await query.ToListAsync();
		}

		public async Task <T> GetById(int id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		
	}
}
