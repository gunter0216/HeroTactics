using Zenject;

namespace App.Common.Autumn.Runtime.Collection
{
    public interface IConfigurator
    {
        void Configuration(DiContainer container);
    }
}