using Grpc.Core;

namespace GrpcService1.Services
{
    public class SubmitService : Submit.SubmitBase
    {
        public override Task<SubmitResponse> RunSubmit(SubmitRequest request, ServerCallContext context)
        {
            return Task.FromResult(new SubmitResponse
            {
                Message = "This is from all " + request.Message
            });
        }
    }
}
