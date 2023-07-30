using k8s.KubeConfigModels;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using Wego.Application.Contracts.Common;
using Wego.Application.Features.Chat;
using Wego.Application.Models.Chat;
using Wego.Application.Models.Common;
using Wego.Domain.Entities;

namespace Wego.HubApi.Hubs
{
    public class ChatHub : Hub
    {
        const string GroupName = "TekosJob";
        private readonly IChatService _chatService;
        public ChatHub(IChatService chatService)
        {
            _chatService = chatService;
        }

        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, GroupName);
            await Clients.Caller.SendAsync("userConnected");
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, GroupName);
            await base.OnDisconnectedAsync(exception);
        }

        public async Task AddUserConnectionId(int profileId)
        {
            await _chatService.AddUserConnectionId(profileId, Context.ConnectionId);
        }

        public async Task ReceiveMessage(MessageModel message)
        {
            await Clients.Group(GroupName).SendAsync("NewMessage", message);
        }

        public async Task CreateDirectChat(MessageModel message)
        {
            var toConnectionId = await _chatService.GetConnectionIdByProfileId(message.ProfileToId);
            if(toConnectionId is not null)
            await Clients.Client(toConnectionId).SendAsync("OpenPrivateChat", message);
            await _chatService.SaveMesssage(message);
        }

        public async Task CreatePrivateChat(MessageModel message)
        {
            string privateGroupName = _chatService.GetPrivateGroupName(message.ProfileFromId, message.ProfileToId);
            await Groups.AddToGroupAsync(Context.ConnectionId, privateGroupName);
            var toConnectionId = await _chatService.GetConnectionIdByProfileId(message.ProfileToId);
            await Groups.AddToGroupAsync(toConnectionId, privateGroupName);

            // opening private chatbox for the other end user
            await Clients.Client(toConnectionId).SendAsync("OpenPrivateChat", message);
        }

        public async Task RecivePrivateMessage(MessageModel message)
        {
            string privateGroupName = _chatService.GetPrivateGroupName(message.ProfileFromId, message.ProfileToId);
            await Clients.Group(privateGroupName).SendAsync("NewPrivateMessage", message);
        }

        public async Task RemovePrivateChat(int from, int to)
        {
            string privateGroupName = _chatService.GetPrivateGroupName(from, to);
            await Clients.Group(privateGroupName).SendAsync("CloseProivateChat");

            await Groups.RemoveFromGroupAsync(Context.ConnectionId, privateGroupName);
            var toConnectionId = await _chatService.GetConnectionIdByProfileId(to);
            await Groups.RemoveFromGroupAsync(toConnectionId, privateGroupName);
        }

      
    }
}
