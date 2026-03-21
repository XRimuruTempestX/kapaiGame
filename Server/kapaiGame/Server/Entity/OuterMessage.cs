using LightProto;
using System;
using MemoryPack;
using System.Collections.Generic;
using Fantasy;
using Fantasy.Pool;
using Fantasy.Network.Interface;
using Fantasy.Serialize;

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8618
// ReSharper disable InconsistentNaming
// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable RedundantTypeArgumentsOfMethod
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PreferConcreteValueOverDefault
// ReSharper disable RedundantNameQualifier
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable CheckNamespace
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable RedundantUsingDirective
// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
namespace Fantasy
{
    [Serializable]
    [ProtoContract]
    public partial class C2G_TestMessage : AMessage, IMessage
    {
        public static C2G_TestMessage Create(bool autoReturn = true)
        {
            var c2G_TestMessage = MessageObjectPool<C2G_TestMessage>.Rent();
            c2G_TestMessage.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                c2G_TestMessage.SetIsPool(false);
            }
            
            return c2G_TestMessage;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            Tag = default;
            MessageObjectPool<C2G_TestMessage>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.C2G_TestMessage; } 
        [ProtoMember(1)]
        public string Tag { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class C2G_TestRequest : AMessage, IRequest
    {
        public static C2G_TestRequest Create(bool autoReturn = true)
        {
            var c2G_TestRequest = MessageObjectPool<C2G_TestRequest>.Rent();
            c2G_TestRequest.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                c2G_TestRequest.SetIsPool(false);
            }
            
            return c2G_TestRequest;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            Tag = default;
            MessageObjectPool<C2G_TestRequest>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.C2G_TestRequest; } 
        [ProtoIgnore]
        public G2C_TestResponse ResponseType { get; set; }
        [ProtoMember(1)]
        public string Tag { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class G2C_TestResponse : AMessage, IResponse
    {
        public static G2C_TestResponse Create(bool autoReturn = true)
        {
            var g2C_TestResponse = MessageObjectPool<G2C_TestResponse>.Rent();
            g2C_TestResponse.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                g2C_TestResponse.SetIsPool(false);
            }
            
            return g2C_TestResponse;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            ErrorCode = 0;
            Tag = default;
            MessageObjectPool<G2C_TestResponse>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.G2C_TestResponse; } 
        [ProtoMember(1)]
        public uint ErrorCode { get; set; }
        [ProtoMember(2)]
        public string Tag { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class C2A_RegisterAccountRequest : AMessage, IRequest
    {
        public static C2A_RegisterAccountRequest Create(bool autoReturn = true)
        {
            var c2A_RegisterAccountRequest = MessageObjectPool<C2A_RegisterAccountRequest>.Rent();
            c2A_RegisterAccountRequest.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                c2A_RegisterAccountRequest.SetIsPool(false);
            }
            
            return c2A_RegisterAccountRequest;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            account = default;
            passWord = default;
            MessageObjectPool<C2A_RegisterAccountRequest>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.C2A_RegisterAccountRequest; } 
        [ProtoIgnore]
        public A2C_RegisterAccountResponse ResponseType { get; set; }
        [ProtoMember(1)]
        public string account { get; set; }
        [ProtoMember(2)]
        public string passWord { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class A2C_RegisterAccountResponse : AMessage, IResponse
    {
        public static A2C_RegisterAccountResponse Create(bool autoReturn = true)
        {
            var a2C_RegisterAccountResponse = MessageObjectPool<A2C_RegisterAccountResponse>.Rent();
            a2C_RegisterAccountResponse.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                a2C_RegisterAccountResponse.SetIsPool(false);
            }
            
            return a2C_RegisterAccountResponse;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            ErrorCode = 0;
            userId = default;
            account = default;
            passWord = default;
            MessageObjectPool<A2C_RegisterAccountResponse>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.A2C_RegisterAccountResponse; } 
        [ProtoMember(1)]
        public uint ErrorCode { get; set; }
        [ProtoMember(2)]
        public long userId { get; set; }
        [ProtoMember(3)]
        public string account { get; set; }
        [ProtoMember(4)]
        public string passWord { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class C2A_LoginRequest : AMessage, IRequest
    {
        public static C2A_LoginRequest Create(bool autoReturn = true)
        {
            var c2A_LoginRequest = MessageObjectPool<C2A_LoginRequest>.Rent();
            c2A_LoginRequest.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                c2A_LoginRequest.SetIsPool(false);
            }
            
            return c2A_LoginRequest;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            account = default;
            passWprd = default;
            MessageObjectPool<C2A_LoginRequest>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.C2A_LoginRequest; } 
        [ProtoIgnore]
        public A2C_LoginResponse ResponseType { get; set; }
        [ProtoMember(1)]
        public string account { get; set; }
        [ProtoMember(2)]
        public string passWprd { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class A2C_LoginResponse : AMessage, IResponse
    {
        public static A2C_LoginResponse Create(bool autoReturn = true)
        {
            var a2C_LoginResponse = MessageObjectPool<A2C_LoginResponse>.Rent();
            a2C_LoginResponse.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                a2C_LoginResponse.SetIsPool(false);
            }
            
            return a2C_LoginResponse;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            ErrorCode = 0;
            gateIp = default;
            gatePor = default;
            MessageObjectPool<A2C_LoginResponse>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.A2C_LoginResponse; } 
        [ProtoMember(1)]
        public uint ErrorCode { get; set; }
        [ProtoMember(2)]
        public string gateIp { get; set; }
        [ProtoMember(3)]
        public int gatePor { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class A2C_KickOut : AMessage, IMessage
    {
        public static A2C_KickOut Create(bool autoReturn = true)
        {
            var a2C_KickOut = MessageObjectPool<A2C_KickOut>.Rent();
            a2C_KickOut.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                a2C_KickOut.SetIsPool(false);
            }
            
            return a2C_KickOut;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            reason = default;
            message = default;
            MessageObjectPool<A2C_KickOut>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.A2C_KickOut; } 
        [ProtoMember(1)]
        public int reason { get; set; }
        [ProtoMember(2)]
        public string message { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class C2Gate_LoginRequest : AMessage, IRequest
    {
        public static C2Gate_LoginRequest Create(bool autoReturn = true)
        {
            var c2Gate_LoginRequest = MessageObjectPool<C2Gate_LoginRequest>.Rent();
            c2Gate_LoginRequest.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                c2Gate_LoginRequest.SetIsPool(false);
            }
            
            return c2Gate_LoginRequest;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            account = default;
            MessageObjectPool<C2Gate_LoginRequest>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.C2Gate_LoginRequest; } 
        [ProtoIgnore]
        public Gate2C_UserDataResponse ResponseType { get; set; }
        [ProtoMember(1)]
        public string account { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class UserPlayerData : AMessage, IDisposable
    {
        public static UserPlayerData Create(bool autoReturn = true)
        {
            var userPlayerData = MessageObjectPool<UserPlayerData>.Rent();
            userPlayerData.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                userPlayerData.SetIsPool(false);
            }
            
            return userPlayerData;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            account = default;
            coin = default;
            diamond = default;
            heroList.Clear();
            MessageObjectPool<UserPlayerData>.Return(this);
        }
        [ProtoMember(1)]
        public string account { get; set; }
        [ProtoMember(2)]
        public int coin { get; set; }
        [ProtoMember(3)]
        public int diamond { get; set; }
        [ProtoMember(4)]
        public List<int> heroList { get; set; } = new List<int>();
    }
    [Serializable]
    [ProtoContract]
    public partial class Gate2C_UserDataResponse : AMessage, IResponse
    {
        public static Gate2C_UserDataResponse Create(bool autoReturn = true)
        {
            var gate2C_UserDataResponse = MessageObjectPool<Gate2C_UserDataResponse>.Rent();
            gate2C_UserDataResponse.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                gate2C_UserDataResponse.SetIsPool(false);
            }
            
            return gate2C_UserDataResponse;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            ErrorCode = 0;
            if (userdata != null)
            {
                userdata.Dispose();
                userdata = null;
            }
            MessageObjectPool<Gate2C_UserDataResponse>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.Gate2C_UserDataResponse; } 
        [ProtoMember(1)]
        public uint ErrorCode { get; set; }
        [ProtoMember(2)]
        public UserPlayerData userdata { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class C2Gate_GachaCarRequest : AMessage, IRequest
    {
        public static C2Gate_GachaCarRequest Create(bool autoReturn = true)
        {
            var c2Gate_GachaCarRequest = MessageObjectPool<C2Gate_GachaCarRequest>.Rent();
            c2Gate_GachaCarRequest.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                c2Gate_GachaCarRequest.SetIsPool(false);
            }
            
            return c2Gate_GachaCarRequest;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            account = default;
            gachaCarCount = default;
            MessageObjectPool<C2Gate_GachaCarRequest>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.C2Gate_GachaCarRequest; } 
        [ProtoIgnore]
        public Gate2C_GachaCarResponse ResponseType { get; set; }
        [ProtoMember(1)]
        public string account { get; set; }
        [ProtoMember(2)]
        public int gachaCarCount { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class Gate2C_GachaCarResponse : AMessage, IResponse
    {
        public static Gate2C_GachaCarResponse Create(bool autoReturn = true)
        {
            var gate2C_GachaCarResponse = MessageObjectPool<Gate2C_GachaCarResponse>.Rent();
            gate2C_GachaCarResponse.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                gate2C_GachaCarResponse.SetIsPool(false);
            }
            
            return gate2C_GachaCarResponse;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            ErrorCode = 0;
            getHeroList.Clear();
            if (userData != null)
            {
                userData.Dispose();
                userData = null;
            }
            MessageObjectPool<Gate2C_GachaCarResponse>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.Gate2C_GachaCarResponse; } 
        [ProtoMember(1)]
        public uint ErrorCode { get; set; }
        [ProtoMember(2)]
        public List<int> getHeroList { get; set; } = new List<int>();
        [ProtoMember(3)]
        public UserPlayerData userData { get; set; }
    }
}