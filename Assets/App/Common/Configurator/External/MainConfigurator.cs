using App.Common.Autumn.Runtime.Attributes;
using App.Common.Autumn.Runtime.Collection;
using App.Common.Data.Runtime.Deserializer;
using App.Common.Data.Runtime.JsonLoader;
using App.Common.Data.Runtime.JsonSaver;
using App.Common.Data.Runtime.Serializer;
using App.Core.Startups.External;
using Newtonsoft.Json;
using Zenject;

namespace App.Common.Configurator.External
{
    [Configurator(ContextConstants.GlobalContext)]    
    public class MainConfigurator : IConfigurator
    {
        public void Configuration(DiContainer container)
        {
            container.Bind<IJsonLoader>().FromInstance(BeanJsonLoader());
            container.Bind<IJsonSaver>().FromInstance(BeanJsonSaver());
            container.Bind<IJsonDeserializer>().FromInstance(GetJsonDeserializer());
            container.Bind<IJsonSerializer>().FromInstance(BeanJsonSerializer());
        }

        public JsonSerializerSettings GetJsonSerializerSettings()
        {
            return new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore,
                DateFormatString = "d.M.yyyy HH:mm:ss",
                Formatting = Formatting.Indented
            };
        }

        public IJsonLoader BeanJsonLoader()
        {
            return new DefaultJsonLoader(GetJsonDeserializer());
        }

        private IJsonSaver BeanJsonSaver()
        {
            return new DefaultJsonSaver(BeanJsonSerializer());
        }

        private IJsonDeserializer GetJsonDeserializer()
        {
            return new NewtonsoftJsonDeserializer(GetJsonSerializerSettings());
        }

        private IJsonSerializer BeanJsonSerializer()
        {
            return new NewtonsoftJsonSerializer(GetJsonSerializerSettings());
        }
    }
}