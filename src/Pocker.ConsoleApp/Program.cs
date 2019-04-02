using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Pocker.Core.Entities;
using Pocker.Core.Helpers;
using Pocker.Core.Interfaces;
using Pocker.Core.Repositories;
using Pocker.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocker.ConsoleApp
{
    class Program
    {
        private static IServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            RegisterServices();
            var playerRepository = ResolveService<IRepository<Player>>();
            var dealerService = ResolveService<IDealerService>();

            // Key commands as following
            // 5: for continue

            DisplayMessage(" --------------------------------------- \t\n  Welcome to the two cards pocker game\t\n ---------------------------------------");
            DisplayGameCommands();


            string gameCommand = Console.ReadLine().ToLower(); 
            while (gameCommand != "q")
            {
                if (gameCommand == "1")
                {
                    DisplayMessage(" The new game is starting soon ");

                    int numberOfPlayers;
                    DisplayMessage(" Please enter number of players [2 - 6]: ");
                    while (!Int32.TryParse(Console.ReadLine(), out numberOfPlayers) || (numberOfPlayers < 2 || numberOfPlayers > 6))
                    {
                        DisplayMessage(" You have entered an invalid number of players. Please try again [2 - 6]");
                    }

                    int numberOfRounds;
                    DisplayMessage(" Please enter number of rounds [2 - 5]: ");
                    while (!Int32.TryParse(Console.ReadLine(), out numberOfRounds) || (numberOfRounds < 2 || numberOfRounds > 5))
                    {
                        DisplayMessage(" You have entered an invalid number of rounds. Please try again [2 - 5]");
                    }

                    // 1. Setup players
                    var playerList = playerRepository.List();
                    // Shuffle it for more random
                    ListUtility.Shuffle(playerList);
                    playerList = playerList.Take(numberOfPlayers).ToList();

                    DisplayMessage(string.Format(" Following players have joined the table : \t\n    {0}\t\n", string.Join(", ", playerList.Select(x => x.Name))));

                    // 2. Setup Deck and Game
                    Deck deck = new Deck();
                    TwoCardsGame game = new TwoCardsGame(playerList, numberOfRounds);

                    // 3. Play the game
                    int count = 1;
                    PlayGame(dealerService, deck, game, count);

                    // 4. Overall winner
                    var winners = dealerService.GetWinners(game);

                    DisplayMessage(string.Format("\t\n  And the overall winner of all {0} rounds are {1} with total score of {2}", 
                        numberOfRounds, 
                        string.Join(",", winners.Select(x => x.Name)), 
                        game.WinningScore));

                    DisplayGameCommands();
                }
                else
                {
                    DisplayMessage(string.Format(" You have entered an unsupported command [{0}]. Please try again. ", gameCommand));
                    
                }
                gameCommand = Console.ReadLine().ToLower();
              
            }
        }

        private static void PlayGame(IDealerService dealerService, Deck deck, TwoCardsGame game, int count)
        {
            foreach (var round in game.GameRounds)
            {
                // reset the deck before each rounds to ensure all cards are invisible
                deck.Reset();

                DisplayMessage(string.Format(" -------> Round {0} has started <------- ", count++));
                dealerService.Shuffle(deck, 1);
                DisplayMessage(" 1. Dealer shuffled the deck 1 time");

                // 2. Deal the cards to all the players
                foreach (var hand in round.PlayerHands)
                {
                    dealerService.DealCards(deck, hand);
                }

                DisplayMessage(string.Format(" 2. Dealer dealt the cards to players as following: \t\n      {0} ", string.Join(", ", round.PlayerHands.Select(x => x.GetCardsOnHandString()))));

                // 3. Calculate the power of all cards on each player hand
                foreach (var hand in round.PlayerHands)
                {
                    dealerService.CalculateHandRank(hand);
                }

                // 4. Nominal the score to 0 – weakest to strongest x-1(where x = number of players)
                // Just simply sort the player hands by power desc and then pick the first one as the winner
                dealerService.AssignScore(round, round.PlayerHands.Count - 1);

                DisplayMessage(string.Format(" 3. Dealer assessed the cards to players and provided ranking as following: \t\n      {0}\t\n", string.Join(", ", round.PlayerHands.Select(x => x.GetHandRankingString()))));
            }
        }

        #region Helpers
        private static void DisplayGameCommands()
        {
            DisplayMessage("\t\n To play the game please use following command: ");
            DisplayMessage("   [Press 1] To start a new game ");
            DisplayMessage("   [Press Q or q] To end now !");
        }

        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        private static void RegisterServices()
        {
            var builder = new ContainerBuilder();

            // register for all the repositories
            builder.RegisterType<Repository<Player>>().As<IRepository<Player>>();

            // Mock the database only
            builder.RegisterType<PockerDatabase>().As<IPockerDatabase>();

            // register for services
            builder.RegisterType<DealerService>().As<IDealerService>();
            builder.RegisterType<TwoCardsGameRule>().As<IGameRuleService>();

            var appContainer = builder.Build();
            _serviceProvider = new AutofacServiceProvider(appContainer);
        }

        private static T ResolveService<T>()
        {
            return _serviceProvider.GetService<T>();
        }
        #endregion
    }
}
