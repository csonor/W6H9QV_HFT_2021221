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

		public void AddNew(T type)
		{
			ctx.Add(type);
			ctx.SaveChanges();
		}

		public abstract void ChangeName(int id, string newName);

		public abstract void ChangeName(string name, string newName);

		public abstract void ChangePopulation(int id, int newPopulation);

		public abstract void ChangePopulation(string name, int newPopulation);

		public void DeleteBy(int id)
		{
			var toDel = GetBy(id);
			ctx.Remove(toDel);
			ctx.SaveChanges();
		}

		public void DeleteBy(string name)
		{
			var toDel = GetBy(name);
			ctx.Remove(toDel);
			ctx.SaveChanges();
		}

		public IQueryable<T> GetAll()
		{
			return ctx.Set<T>();
		}

		public abstract T GetBy(int id);

		public abstract T GetBy(string name);

		public abstract void Update(T type);
	}
}
