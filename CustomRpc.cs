using System;
using Reactor.Networking.Attributes;
using Reactor.Utilities;
using UnityEngine;


namespace yanplaRoles.rpc;
public static class CustomRpc
{

    [MethodRpc((uint) CustomRpcCalls.CleanBody)]
    public static void RpcCleanBody(this PlayerControl source, Byte target)
    {
        Debug.Log("Cleaning body.");
        var coroutineInstance = new PhantomPlus.Patches.Coroutine();
        Coroutines.Start(coroutineInstance.CleanBodyCoroutine(target));
    }

    
}
