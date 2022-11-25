using MassTransit;
using Messege2.ViewModel;
using System.Threading.Tasks;

namespace Messege2
{
    public class OrderConsumer :
          IConsumer<Order>
    {
        public async Task Consume(ConsumeContext<Order> context)
        {
            var data = context.Message;
            // message received.
        }
    }
}
