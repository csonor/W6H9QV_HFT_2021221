using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W6H9QV_HFT_2021221.Models;

namespace W6H9QV_HFT_2021221.WpfClient.Services
{
	interface IAddOrEditEntityService<T>
	{
		void Add();
		void Edit(T item);
	}
}
