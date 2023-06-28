using Akka.Actor;

namespace ActorModelDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ActorSystem actorSystem = ActorSystem.Create("MySystem");
            IActorRef reservator = actorSystem.ActorOf<ReservationActor>("reservator");
            reservator.Tell(new BookTheRoom { RoomNumber = 1});
            reservator.Tell(new BookTheRoom { RoomNumber = 1 });

            Console.ReadLine();
        }
    }
}