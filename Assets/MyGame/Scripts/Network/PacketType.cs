namespace MyGame
{
    public enum PacketType
    {
        Undefined=0,
        ClientToServer,
        ServerToClient,
    }

    public enum HandlerType
    {
        Undefined=0,
        Request,
        Response,
    }
}