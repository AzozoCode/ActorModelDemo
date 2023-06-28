using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActorModelDemo
{
    internal class ReservationActor:ReceiveActor
    {
        private readonly List<RoomState> _rooms = new List<RoomState>
        {
            new RoomState{ RoomNumber= 1,IsBook=false},
            new RoomState{RoomNumber= 2,IsBook=false},
            new RoomState{RoomNumber= 3,IsBook=true},
            new RoomState{RoomNumber=4,IsBook=true}

        };

        public ReservationActor()
        {
            Receive<BookTheRoom>(msg =>
            {
                var availableRoom = _rooms.SingleOrDefault(x => x.RoomNumber == msg.RoomNumber && !x.IsBook);

                if(availableRoom != null)
                {
                    availableRoom.IsBook = true;
                    Self.Tell(new BookedRoom { RoomNumber = msg.RoomNumber});
                }
            });
        }
    }
}
