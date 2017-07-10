namespace GC.Messages {

    public enum MessageType : ushort {
        RequestBase,
        ResponseBase,
        FleetRequest,
        FleetResponse,
        LoginRequest,
        LoginResponse,
        SettingsRequest,
        SettingsReponse,
        StatusResponse,
        StopGridRequest,
        StopGridResponse,
        ViolationsRequest,
        ViolationsResponse
    }

}
