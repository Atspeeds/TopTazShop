using System.Collections.Generic;
using TT.FrameWork.Messages;

namespace TopTaz.Application.DtoModel
{
    public class BaseDto<T>
    {

        public T Model { get; private set; }
        public bool ISsuccess { get; private set; }
        public List<string> Messages { get; private set; } = new List<string>() { ServiceMessage.SuccessfulOperation };

        public BaseDto(T model, bool iSsuccess, List<string> messages)
        {
            Model = model;
            ISsuccess = iSsuccess;
            Messages = messages;
        }
        public BaseDto(T model, bool iSsuccess)
        {
            Model = model;
            ISsuccess = iSsuccess;
        }

    }
    public class BaseDto
    {
        public bool ISsuccess { get; private set; }
        public List<string> Messages { get; private set; } = new List<string>() { ServiceMessage.SuccessfulOperation };

        public BaseDto( bool iSsuccess, List<string> messages)
        {
            ISsuccess = iSsuccess;
            Messages = messages;
        }
        public BaseDto(bool iSsuccess)
        {
            ISsuccess = iSsuccess;
        }
    }

}
