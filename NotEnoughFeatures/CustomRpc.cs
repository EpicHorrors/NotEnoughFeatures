using System;
using Reactor.Networking.Attributes;
using Reactor.Utilities;
using UnityEngine;


namespace NotEnoughFeatures.rpc;
public static class CustomRpc
{

    [MethodRpc((uint) CustomRpcCalls.CleanBody)]
    public static void RpcCleanBody(this PlayerControl source, Byte target)
    {
        Debug.Log("Cleaning body.");
        var coroutineInstance = new NotEnoughFeatures.Patches.Coroutine();
        Coroutines.Start(coroutineInstance.CleanBodyCoroutine(target));
    }

    
}
