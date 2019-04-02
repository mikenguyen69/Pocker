using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pocker.Core.Interfaces;
using Pocker.Core.Tests.Helpers;

namespace Pocker.Core.Tests.Services
{
    [TestClass]
    public class TwoCardsPockerGameTests
    {
        private IGameService _game;
        private IDealerService _dealer;

        public TwoCardsPockerGameTests()
        {
            DependencyInjector injector = new DependencyInjector();
            _game = injector.ResolveService<IGameService>();
        }

        //public void 
    }
}
