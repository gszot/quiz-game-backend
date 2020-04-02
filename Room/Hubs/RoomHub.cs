using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using Tasak.Api.Room.Models;
using Tasak.Api.Room.Services;

namespace Tasak.Api.Room.Hubs
{
    public class RoomHub : Hub
    {
        private readonly IRoomService _roomService;
        public RoomHub(IRoomService roomService)
        {
            _roomService = roomService;
        }
        public override async Task OnConnectedAsync()
        {
            //Debug.WriteLine("asddbjajfbjwehfbjwehgbejrhgbejrgbejrgberjg");
            Debug.WriteLine("connected: ", Context.ConnectionId);
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            Debug.WriteLine("disconnected: ", Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }
        public void PostAnswer(string answer)
        {

        }
        public async Task HubStartQuiz()
        {
            var teacherid = Context.ConnectionId;
            Debug.WriteLine("startquizhub");
            var roomPair = _roomService.Rooms.FirstOrDefault(x => x.Key == teacherid);
            if(roomPair.Value != null)
            {
                await roomPair.Value.StartQuiz();
            }
        }
        public async Task HubStopQuestion()
        {
            var teacherid = Context.ConnectionId;
            Debug.WriteLine("stopquestionhub");
            var roomPair = _roomService.Rooms.FirstOrDefault(x => x.Key == teacherid);
            if (roomPair.Value != null)
            {
                await roomPair.Value.StopQuestion();
            }
        }
        public async Task HubNextQuestion()
        {
            var teacherid = Context.ConnectionId;
            Debug.WriteLine("nextquesitonhub");
            var roomPair = _roomService.Rooms.FirstOrDefault(x => x.Key == teacherid);
            if (roomPair.Value != null)
            {
                await roomPair.Value.NextQuestion();
            }
        }
    }
}
