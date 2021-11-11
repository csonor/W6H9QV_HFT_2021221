using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace W6H9QV_HFT_2021221.Repository
{
	public abstract class Repository<T> : IRepository<T> where T : class
	{
		protected DbContext ctx;

		public Repository(DbContext ctx)
		{
			this.ctx = ctx;
		}

		public IQueryable<T> GetAll()
		{
			return ctx.Set<T>();
		}

		public abstract T GetBy(int id);

		public abstract T GetBy(string name);
	}
}
