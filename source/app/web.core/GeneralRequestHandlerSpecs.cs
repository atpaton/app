﻿using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.web.core
{
  [Subject(typeof(GeneralRequestHandler))]
  public class GeneralRequestHandlerSpecs
  {
    public abstract class concern : Observes<IHandleAllIncomingWebRequests,
      GeneralRequestHandler>
    {
    }

    public class when_processing_a_request : concern
    {
      Establish c = () =>
      {
        handler_registry = depends.on<IGetHandlersForRequests>();
        handler_that_can_process_the_request = fake.an<IHandleOneRequest>();
        request = fake.an<IProvideRequestDetails>();

        handler_registry.setup(x => x.get_the_handler_that_can_run(request)).Return(handler_that_can_process_the_request);
      };

      Because b = () =>
        sut.process(request);

      It delegates_processing_of_the_request_to_the_handler_that_can_process_the_request = () =>
        handler_that_can_process_the_request.received(x => x.process(request));

      static IHandleOneRequest handler_that_can_process_the_request;
      static IProvideRequestDetails request;
      static IGetHandlersForRequests handler_registry;
    }
  }
}