using System.Runtime.CompilerServices;
using Fantasy;
using Fantasy.Async;
using Fantasy.Network;
using System.Collections.Generic;
#pragma warning disable CS8618
namespace Fantasy
{
   public static class NetworkProtocolHelper
   {
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void C2G_TestMessage(this Session session, C2G_TestMessage C2G_TestMessage_message)
		{
			session.Send(C2G_TestMessage_message);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void C2G_TestMessage(this Session session, string tag)
		{
			using var C2G_TestMessage_message = Fantasy.C2G_TestMessage.Create();
			C2G_TestMessage_message.Tag = tag;
			session.Send(C2G_TestMessage_message);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static async FTask<G2C_TestResponse> C2G_TestRequest(this Session session, C2G_TestRequest C2G_TestRequest_request)
		{
			return (G2C_TestResponse)await session.Call(C2G_TestRequest_request);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static async FTask<G2C_TestResponse> C2G_TestRequest(this Session session, string tag)
		{
			using var C2G_TestRequest_request = Fantasy.C2G_TestRequest.Create();
			C2G_TestRequest_request.Tag = tag;
			return (G2C_TestResponse)await session.Call(C2G_TestRequest_request);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static async FTask<A2C_RegisterAccountResponse> C2A_RegisterAccountRequest(this Session session, C2A_RegisterAccountRequest C2A_RegisterAccountRequest_request)
		{
			return (A2C_RegisterAccountResponse)await session.Call(C2A_RegisterAccountRequest_request);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static async FTask<A2C_RegisterAccountResponse> C2A_RegisterAccountRequest(this Session session, string account, string passWord)
		{
			using var C2A_RegisterAccountRequest_request = Fantasy.C2A_RegisterAccountRequest.Create();
			C2A_RegisterAccountRequest_request.account = account;
			C2A_RegisterAccountRequest_request.passWord = passWord;
			return (A2C_RegisterAccountResponse)await session.Call(C2A_RegisterAccountRequest_request);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static async FTask<A2C_LoginResponse> C2A_LoginRequest(this Session session, C2A_LoginRequest C2A_LoginRequest_request)
		{
			return (A2C_LoginResponse)await session.Call(C2A_LoginRequest_request);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static async FTask<A2C_LoginResponse> C2A_LoginRequest(this Session session, string account, string passWprd)
		{
			using var C2A_LoginRequest_request = Fantasy.C2A_LoginRequest.Create();
			C2A_LoginRequest_request.account = account;
			C2A_LoginRequest_request.passWprd = passWprd;
			return (A2C_LoginResponse)await session.Call(C2A_LoginRequest_request);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void A2C_KickOut(this Session session, A2C_KickOut A2C_KickOut_message)
		{
			session.Send(A2C_KickOut_message);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void A2C_KickOut(this Session session, int reason, string message)
		{
			using var A2C_KickOut_message = Fantasy.A2C_KickOut.Create();
			A2C_KickOut_message.reason = reason;
			A2C_KickOut_message.message = message;
			session.Send(A2C_KickOut_message);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static async FTask<Gate2C_UserDataResponse> C2Gate_LoginRequest(this Session session, C2Gate_LoginRequest C2Gate_LoginRequest_request)
		{
			return (Gate2C_UserDataResponse)await session.Call(C2Gate_LoginRequest_request);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static async FTask<Gate2C_UserDataResponse> C2Gate_LoginRequest(this Session session, string account)
		{
			using var C2Gate_LoginRequest_request = Fantasy.C2Gate_LoginRequest.Create();
			C2Gate_LoginRequest_request.account = account;
			return (Gate2C_UserDataResponse)await session.Call(C2Gate_LoginRequest_request);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static async FTask<Gate2C_GachaCarResponse> C2Gate_GachaCarRequest(this Session session, C2Gate_GachaCarRequest C2Gate_GachaCarRequest_request)
		{
			return (Gate2C_GachaCarResponse)await session.Call(C2Gate_GachaCarRequest_request);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static async FTask<Gate2C_GachaCarResponse> C2Gate_GachaCarRequest(this Session session, string account, int gachaCarCount)
		{
			using var C2Gate_GachaCarRequest_request = Fantasy.C2Gate_GachaCarRequest.Create();
			C2Gate_GachaCarRequest_request.account = account;
			C2Gate_GachaCarRequest_request.gachaCarCount = gachaCarCount;
			return (Gate2C_GachaCarResponse)await session.Call(C2Gate_GachaCarRequest_request);
		}

   }
}