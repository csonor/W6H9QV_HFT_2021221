namespace W6H9QV_HFT_2021221.WpfClient.Services
{
	interface IAddOrEditEntityService<T>
	{
		void Add();
		void Edit(T item);
	}
}
