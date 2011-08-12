using System;
using System.Configuration;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity;

namespace Jobin.Model.DataStore
{
	internal partial class Factory : IModelFactory
	{
		public static IModelFactory Get()
		{
			UnityConfigurationSection unityConfig = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
			UnityContainerElement containerElement = unityConfig.Containers["ES.DataStore.Factory"];

			UnityContainer container = new UnityContainer();
			containerElement.Configure(container);
			
			IModelFactory factory = (IModelFactory)container.Resolve<IModelFactory>();
			if (factory == null) throw new ApplicationException("O factory IModelFactory não está configurado!");
			return factory;
		}
		public IDataStore Resolve<IDataStore>()
		{
			switch (typeof(IDataStore).Name)
			{
				case "IAvaliacoesDalc":
					return (IDataStore)(object)new AvaliacoesDalc();
				case "ICategoriasDalc":
					return (IDataStore)(object)new CategoriasDalc();
				case "IDestaquesDalc":
					return (IDataStore)(object)new DestaquesDalc();
				case "IEnderecoDalc":
					return (IDataStore)(object)new EnderecoDalc();
				case "IExperienciaDalc":
					return (IDataStore)(object)new ExperienciaDalc();
				case "IFormacoesDalc":
					return (IDataStore)(object)new FormacoesDalc();
				case "IFornecedoresDalc":
					return (IDataStore)(object)new FornecedoresDalc();
				case "IMensagensDalc":
					return (IDataStore)(object)new MensagensDalc();
				case "IOportunidadesDalc":
					return (IDataStore)(object)new OportunidadesDalc();
				case "IPessoaFisicaDalc":
					return (IDataStore)(object)new PessoaFisicaDalc();
				case "IPessoaJuridicaDalc":
					return (IDataStore)(object)new PessoaJuridicaDalc();
				case "ISegmentosDalc":
					return (IDataStore)(object)new SegmentosDalc();
				case "ITelefonesDalc":
					return (IDataStore)(object)new TelefonesDalc();
				case "IUsuariosDalc":
					return (IDataStore)(object)new UsuariosDalc();
				default:
					object dataStoreInstance = null;
					ResolvePartial<IDataStore>(ref dataStoreInstance);
					if (dataStoreInstance != null) return (IDataStore)dataStoreInstance;
					break;
			}

			throw new ApplicationException("DataStore " + typeof(IDataStore).Name + " não está configurado no Factory!");
		}
		partial void ResolvePartial<IDataStore>(ref object dataStore);
	}
}
