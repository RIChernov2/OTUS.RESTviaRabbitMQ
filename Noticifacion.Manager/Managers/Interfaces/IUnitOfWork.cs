using Notifications.Manager.Repositories.Interfaces;
using System;


namespace Notifications.Manager.Managers.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IMessagesRepository MessagesRepository { get; }
        void Commit();
    }
}