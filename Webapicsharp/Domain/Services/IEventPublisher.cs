using WebApiCSharp.Domain.Events;

namespace WebApiCSharp.Domain.Services;

public interface IEventPublisher
{
    void Publish(DomainEvent domainEvent);
}
