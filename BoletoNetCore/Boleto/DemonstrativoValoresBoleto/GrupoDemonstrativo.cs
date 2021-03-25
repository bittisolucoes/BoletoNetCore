namespace BoletoNetCore
{
	using System.Collections.ObjectModel;
	public class GrupoDemonstrativo
	{
		#region Fields

		private ObservableCollection<ItemDemonstrativo> _itens;

		#endregion

		#region Public Properties

		public string Descricao { get; set; }

		public ObservableCollection<ItemDemonstrativo> Itens
		{
			get
			{
				return _itens ?? (_itens = new ObservableCollection<ItemDemonstrativo>());
			}
		}

		#endregion
	}
}