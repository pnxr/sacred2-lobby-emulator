using System;
using System.Collections.Generic;

namespace S2Library.Protocol
{
    public class Payloads
    {
        public enum Types : ushort
        {
            UnknownType001 = 1,
            UnknownType002 = 2,
            UnknownType003 = 3,
            UnknownType004 = 4,
            UnknownType005 = 5,
            UnknownType006 = 6,
            UnknownType007 = 7,
            UnknownType008 = 8,
            UnknownType009 = 9,
            UnknownType010 = 10,
            UnknownType011 = 11,
            UnknownType012 = 12,
            UnknownType013 = 13,
            UnknownType014 = 14,
            UnknownType015 = 15,
            UnknownType016 = 16,
            UnknownType017 = 17,
            UnknownType018 = 18,
            UnknownType019 = 19,
            UnknownType020 = 20,
            UnknownType021 = 21,
            UnknownType022 = 22,
            UnknownType023 = 23,
            UnknownType024 = 24,
            UnknownType025 = 25,
            UnknownType026 = 26,
            UnknownType027 = 27,
            UnknownType028 = 28,
            UnknownType029 = 29,
            UnknownType030 = 30,
            UnknownType031 = 31,
            UnknownType032 = 32,
            UnknownType033 = 33,
            UnknownType034 = 34,
            UnknownType035 = 35,
            UnknownType036 = 36,
            UnknownType037 = 37,
            UnknownType038 = 38,
            UnknownType039 = 39,
            UnknownType040 = 40,
            UnknownType041 = 41,
            StatusMsg = 42, // UnknownType042
            UnknownType043 = 43,
            UnknownType044 = 44,
            UnknownType045 = 45,
            UnknownType046 = 46,
            UnknownType047 = 47,
            UnknownType048 = 48,
            UnknownType049 = 49,
            UnknownType050 = 50,
            UnknownType051 = 51,
            UnknownType052 = 52,
            GetUserInfo = 53, // UnknownType053
            GetPlayerInfo = 55, // UnknownType055
            UnknownType056 = 56,
            UnknownType057 = 57,
            UnknownType058 = 58,
            SendUserInfo = 59, // UnknownType059
            SendPlayerInfo = 60, // UnknownType060
            UnknownType061 = 61,
            UnknownType062 = 62,
            UnknownType063 = 63,
            UnknownType064 = 64,
            UnknownType066 = 66,
            UnknownType067 = 67,
            UnknownType068 = 68,
            UnknownType069 = 69,
            UnknownType070 = 70,
            UnknownType071 = 71,
            SelectNickname = 72, // UnknownType072
            UnknownType073 = 73,
            UnknownType074 = 74,
            SelectNicknameReply = 75, // UnknownType075
            UnknownType076 = 76,
            RegisterNickname = 77, // UnknownType077
            UnknownType078 = 78,
            UnknownType079 = 79,
            UnknownType080 = 80,
            UnknownType082 = 82,
            UnknownType083 = 83,
            UnknownType084 = 84,
            UnknownType085 = 85,
            UnknownType086 = 86,
            UnknownType087 = 87,
            ConfirmNickname = 88, // UnknownType088
            UnknownType089 = 89,
            UnknownType090 = 90,
            UnknownType091 = 91,
            UnknownType092 = 92,
            UnknownType093 = 93,
            UnknownType094 = 94,
            UnknownType095 = 95,
            UnknownType096 = 96,
            UnknownType097 = 97,
            UnknownType098 = 98,
            UnknownType099 = 99,
            UnknownType100 = 100,
            UnknownType101 = 101,
            UnknownType102 = 102,
            UnknownType103 = 103,
            UnknownType104 = 104,
            GetWelcomeMsg = 105, // UnknownType105
            SendWelcomeMsg = 106, // UnknownType106
            UnknownType107 = 107,
            UnknownType108 = 108,
            UnknownType109 = 109,
            UnknownType110 = 110,
            UnknownType111 = 111,
            UnknownType112 = 112,
            UnknownType113 = 113,
            UnknownType114 = 114,
            UnknownType115 = 115,
            UnknownType116 = 116,
            UnknownType117 = 117,
            UnknownType118 = 118,
            UnknownType119 = 119,
            UnknownType120 = 120,
            UnknownType121 = 121,
            UnknownType122 = 122,
            UnknownType123 = 123,
            UnknownType124 = 124,
            UnknownType125 = 125,
            UnknownType126 = 126,
            UnknownType128 = 128,
            UnknownType135 = 135,
            UnknownType137 = 137,
            UnknownType138 = 138,
            UnknownType139 = 139,
            UnknownType140 = 140,
            UnknownType141 = 141,
            UnknownType142 = 142,
            UnknownType143 = 143,
            UnknownType144 = 144,
            UnknownType145 = 145,
            UnknownType146 = 146,
            UnknownType147 = 147,
            UnknownType148 = 148,
            UnknownType149 = 149,
            UnknownType150 = 150,
            UnknownType151 = 151,
            UnknownType152 = 152,
            StatusWithId = 153, // UnknownType153
            UnknownType154 = 154,
            UnknownType155 = 155,
            UnknownType156 = 156,
            UnknownType157 = 157,
            GetCDKeys = 158, // UnknownType158
            SendCDKey = 159, // UnknownType159
            UnknownType160 = 160,
            UnknownType161 = 161,
            UnknownType162 = 162,
            UnknownType163 = 163,
            UnknownType164 = 164,
            UnknownType165 = 165,
            UnknownType166 = 166,
            UnknownType167 = 167,
            RegisterServer = 168, // UnknownType168
            UnknownType169 = 169,
            ServerInfo = 170, // UnknownType170
            GetServers = 171, // UnknownType171
            StopServerUpdates = 172, // UnknownType172
            UnknownType173 = 173,
            UnknownType174 = 174,
            UnknownType175 = 175,
            UnknownType176 = 176,
            UpdateServerInfo = 177, // UnknownType177
            UnknownType178 = 178,
            UnknownType179 = 179,
            UnknownType180 = 180,
            UnknownType181 = 181,
            UnknownType182 = 182,
            UnknownType183 = 183,
            UnknownType184 = 184,
            UnknownType185 = 185,
            UnknownType186 = 186,
            UnknownType187 = 187,
            VersionCheck = 188, // UnknownType188 
            GetChatServer = 189, // UnknownType189
            UnknownType190 = 190,
            UnknownType191 = 191,
            SendChatServerInfo = 192, // UnknownType192
            UnknownType193 = 193,
            UnknownType194 = 194,
            Login = 201, // UnknownType201
            LoginReply = 202, // UnknownType202
            RegisterUser = 203, // UnknownType203
            LoginUser = 204, // UnknownType204
            UnknownType205 = 205,
            LoginServer = 206, // UnknownType206
            LoginReplyCipher = 207, // UnknownType207
            LoginChat = 211, // UnknownType211
            LoginChatReply = 212, // UnknownType212
            VerifyChatLogin = 213, // UnknownType213
            UnknownType214 = 214,
            ConnectToServer = 221, // UnknownType221
            ConnectToServerReply = 222, // UnknownType222
            PlayerConnecting = 223, // UnknownType223
            UnknownType224 = 224,
            UnknownType240 = 240,
            UnknownType241 = 241,
            UnknownType242 = 242,
            UnknownType243 = 243,
            UnknownType244 = 244,
            UnknownType245 = 245,
            UnknownType246 = 246,
            UnknownType247 = 247,
            UnknownType248 = 248,
            UnknownType249 = 249,
            UnknownType250 = 250,
            UnknownType251 = 251,
            UnknownType252 = 252,
            UnknownType253 = 253,
            UnknownType254 = 254,
            UnknownType255 = 255,
            UnknownType256 = 256,
            UnknownType257 = 257,
            UnknownType258 = 258,
            UnknownType259 = 259,
            UnknownType260 = 260,
            UnknownType261 = 261,
            UnknownType262 = 262,
        }

        private static readonly Dictionary<Type, Types> PayloadTypes = new Dictionary<Type, Types>();
        private static readonly Dictionary<Types, Type> PayloadFromType = new Dictionary<Types, Type>();

        static Payloads()
        {
            PayloadTypes.Add(typeof(Payload1), Types.UnknownType001);
            PayloadTypes.Add(typeof(Payload2), Types.UnknownType002);
            PayloadTypes.Add(typeof(Payload3), Types.UnknownType003);
            PayloadTypes.Add(typeof(Payload4), Types.UnknownType004);
            PayloadTypes.Add(typeof(Payload5), Types.UnknownType005);
            PayloadTypes.Add(typeof(Payload6), Types.UnknownType006);
            PayloadTypes.Add(typeof(Payload7), Types.UnknownType007);
            PayloadTypes.Add(typeof(Payload8), Types.UnknownType008);
            PayloadTypes.Add(typeof(Payload9), Types.UnknownType009);
            PayloadTypes.Add(typeof(Payload10), Types.UnknownType010);
            PayloadTypes.Add(typeof(Payload11), Types.UnknownType011);
            PayloadTypes.Add(typeof(Payload12), Types.UnknownType012);
            PayloadTypes.Add(typeof(Payload13), Types.UnknownType013);
            PayloadTypes.Add(typeof(Payload14), Types.UnknownType014);
            PayloadTypes.Add(typeof(Payload15), Types.UnknownType015);
            PayloadTypes.Add(typeof(Payload16), Types.UnknownType016);
            PayloadTypes.Add(typeof(Payload17), Types.UnknownType017);
            PayloadTypes.Add(typeof(Payload18), Types.UnknownType018);
            PayloadTypes.Add(typeof(Payload19), Types.UnknownType019);
            PayloadTypes.Add(typeof(Payload20), Types.UnknownType020);
            PayloadTypes.Add(typeof(Payload21), Types.UnknownType021);
            PayloadTypes.Add(typeof(Payload22), Types.UnknownType022);
            PayloadTypes.Add(typeof(Payload23), Types.UnknownType023);
            PayloadTypes.Add(typeof(Payload24), Types.UnknownType024);
            PayloadTypes.Add(typeof(Payload25), Types.UnknownType025);
            PayloadTypes.Add(typeof(Payload26), Types.UnknownType026);
            PayloadTypes.Add(typeof(Payload27), Types.UnknownType027);
            PayloadTypes.Add(typeof(Payload28), Types.UnknownType028);
            PayloadTypes.Add(typeof(Payload29), Types.UnknownType029);
            PayloadTypes.Add(typeof(Payload30), Types.UnknownType030);
            PayloadTypes.Add(typeof(Payload31), Types.UnknownType031);
            PayloadTypes.Add(typeof(Payload32), Types.UnknownType032);
            PayloadTypes.Add(typeof(Payload33), Types.UnknownType033);
            PayloadTypes.Add(typeof(Payload34), Types.UnknownType034);
            PayloadTypes.Add(typeof(Payload35), Types.UnknownType035);
            PayloadTypes.Add(typeof(Payload36), Types.UnknownType036);
            PayloadTypes.Add(typeof(Payload37), Types.UnknownType037);
            PayloadTypes.Add(typeof(Payload38), Types.UnknownType038);
            PayloadTypes.Add(typeof(Payload39), Types.UnknownType039);
            PayloadTypes.Add(typeof(Payload40), Types.UnknownType040);
            PayloadTypes.Add(typeof(Payload41), Types.UnknownType041);
            PayloadTypes.Add(typeof(StatusMsg), Types.StatusMsg); // Payload42
            PayloadTypes.Add(typeof(Payload43), Types.UnknownType043);
            PayloadTypes.Add(typeof(Payload44), Types.UnknownType044);
            PayloadTypes.Add(typeof(Payload45), Types.UnknownType045);
            PayloadTypes.Add(typeof(Payload46), Types.UnknownType046);
            PayloadTypes.Add(typeof(Payload47), Types.UnknownType047);
            PayloadTypes.Add(typeof(Payload48), Types.UnknownType048);
            PayloadTypes.Add(typeof(Payload49), Types.UnknownType049);
            PayloadTypes.Add(typeof(Payload50), Types.UnknownType050);
            PayloadTypes.Add(typeof(Payload51), Types.UnknownType051);
            PayloadTypes.Add(typeof(Payload52), Types.UnknownType052);
            PayloadTypes.Add(typeof(GetUserInfo), Types.GetUserInfo); // Payload53
            PayloadTypes.Add(typeof(GetPlayerInfo), Types.GetPlayerInfo); // Payload55
            PayloadTypes.Add(typeof(Payload56), Types.UnknownType056);
            PayloadTypes.Add(typeof(Payload57), Types.UnknownType057);
            PayloadTypes.Add(typeof(Payload58), Types.UnknownType058);
            PayloadTypes.Add(typeof(SendUserInfo), Types.SendUserInfo); // Payload59
            PayloadTypes.Add(typeof(SendPlayerInfo), Types.SendPlayerInfo); // Payload60
            PayloadTypes.Add(typeof(Payload61), Types.UnknownType061);
            PayloadTypes.Add(typeof(Payload62), Types.UnknownType062);
            PayloadTypes.Add(typeof(Payload63), Types.UnknownType063);
            PayloadTypes.Add(typeof(Payload64), Types.UnknownType064);
            PayloadTypes.Add(typeof(Payload66), Types.UnknownType066);
            PayloadTypes.Add(typeof(Payload67), Types.UnknownType067);
            PayloadTypes.Add(typeof(Payload68), Types.UnknownType068);
            PayloadTypes.Add(typeof(Payload69), Types.UnknownType069);
            PayloadTypes.Add(typeof(Payload70), Types.UnknownType070);
            PayloadTypes.Add(typeof(Payload71), Types.UnknownType071);
            PayloadTypes.Add(typeof(SelectNickname), Types.SelectNickname); // Payload72
            PayloadTypes.Add(typeof(Payload73), Types.UnknownType073);
            PayloadTypes.Add(typeof(Payload74), Types.UnknownType074);
            PayloadTypes.Add(typeof(SelectNicknameReply), Types.SelectNicknameReply); //Payload75
            PayloadTypes.Add(typeof(Payload76), Types.UnknownType076);
            PayloadTypes.Add(typeof(RegisterNickname), Types.RegisterNickname); // Payload77
            PayloadTypes.Add(typeof(Payload78), Types.UnknownType078);
            PayloadTypes.Add(typeof(Payload79), Types.UnknownType079);
            PayloadTypes.Add(typeof(Payload80), Types.UnknownType080);
            PayloadTypes.Add(typeof(Payload82), Types.UnknownType082);
            PayloadTypes.Add(typeof(Payload83), Types.UnknownType083);
            PayloadTypes.Add(typeof(Payload84), Types.UnknownType084);
            PayloadTypes.Add(typeof(Payload85), Types.UnknownType085);
            PayloadTypes.Add(typeof(Payload86), Types.UnknownType086);
            PayloadTypes.Add(typeof(Payload87), Types.UnknownType087);
            PayloadTypes.Add(typeof(ConfirmNickname), Types.ConfirmNickname); // Payload88
            PayloadTypes.Add(typeof(Payload89), Types.UnknownType089);
            PayloadTypes.Add(typeof(Payload90), Types.UnknownType090);
            PayloadTypes.Add(typeof(Payload91), Types.UnknownType091);
            PayloadTypes.Add(typeof(Payload92), Types.UnknownType092);
            PayloadTypes.Add(typeof(Payload93), Types.UnknownType093);
            PayloadTypes.Add(typeof(Payload94), Types.UnknownType094);
            PayloadTypes.Add(typeof(Payload95), Types.UnknownType095);
            PayloadTypes.Add(typeof(Payload96), Types.UnknownType096);
            PayloadTypes.Add(typeof(Payload97), Types.UnknownType097);
            PayloadTypes.Add(typeof(Payload98), Types.UnknownType098);
            PayloadTypes.Add(typeof(Payload99), Types.UnknownType099);
            PayloadTypes.Add(typeof(Payload100), Types.UnknownType100);
            PayloadTypes.Add(typeof(Payload101), Types.UnknownType101);
            PayloadTypes.Add(typeof(Payload102), Types.UnknownType102);
            PayloadTypes.Add(typeof(Payload103), Types.UnknownType103);
            PayloadTypes.Add(typeof(Payload104), Types.UnknownType104);
            PayloadTypes.Add(typeof(GetWelcomeMsg), Types.GetWelcomeMsg); // Payload105
            PayloadTypes.Add(typeof(SendWelcomeMsg), Types.SendWelcomeMsg); // Payload106
            PayloadTypes.Add(typeof(Payload107), Types.UnknownType107);
            PayloadTypes.Add(typeof(Payload108), Types.UnknownType108);
            PayloadTypes.Add(typeof(Payload109), Types.UnknownType109);
            PayloadTypes.Add(typeof(Payload110), Types.UnknownType110);
            PayloadTypes.Add(typeof(Payload111), Types.UnknownType111);
            PayloadTypes.Add(typeof(Payload112), Types.UnknownType112);
            PayloadTypes.Add(typeof(Payload113), Types.UnknownType113);
            PayloadTypes.Add(typeof(Payload114), Types.UnknownType114);
            PayloadTypes.Add(typeof(Payload115), Types.UnknownType115);
            PayloadTypes.Add(typeof(Payload116), Types.UnknownType116);
            PayloadTypes.Add(typeof(Payload117), Types.UnknownType117);
            PayloadTypes.Add(typeof(Payload118), Types.UnknownType118);
            PayloadTypes.Add(typeof(Payload119), Types.UnknownType119);
            PayloadTypes.Add(typeof(Payload120), Types.UnknownType120);
            PayloadTypes.Add(typeof(Payload121), Types.UnknownType121);
            PayloadTypes.Add(typeof(Payload122), Types.UnknownType122);
            PayloadTypes.Add(typeof(Payload123), Types.UnknownType123);
            PayloadTypes.Add(typeof(Payload124), Types.UnknownType124);
            PayloadTypes.Add(typeof(Payload125), Types.UnknownType125);
            PayloadTypes.Add(typeof(Payload126), Types.UnknownType126);
            PayloadTypes.Add(typeof(Payload128), Types.UnknownType128);
            PayloadTypes.Add(typeof(Payload135), Types.UnknownType135);
            PayloadTypes.Add(typeof(Payload137), Types.UnknownType137);
            PayloadTypes.Add(typeof(Payload138), Types.UnknownType138);
            PayloadTypes.Add(typeof(Payload139), Types.UnknownType139);
            PayloadTypes.Add(typeof(Payload140), Types.UnknownType140);
            PayloadTypes.Add(typeof(Payload141), Types.UnknownType141);
            PayloadTypes.Add(typeof(Payload142), Types.UnknownType142);
            PayloadTypes.Add(typeof(Payload143), Types.UnknownType143);
            PayloadTypes.Add(typeof(Payload144), Types.UnknownType144);
            PayloadTypes.Add(typeof(Payload145), Types.UnknownType145);
            PayloadTypes.Add(typeof(Payload146), Types.UnknownType146);
            PayloadTypes.Add(typeof(Payload147), Types.UnknownType147);
            PayloadTypes.Add(typeof(Payload148), Types.UnknownType148);
            PayloadTypes.Add(typeof(Payload149), Types.UnknownType149);
            PayloadTypes.Add(typeof(Payload150), Types.UnknownType150);
            PayloadTypes.Add(typeof(Payload151), Types.UnknownType151);
            PayloadTypes.Add(typeof(Payload152), Types.UnknownType152);
            PayloadTypes.Add(typeof(StatusWithId), Types.StatusWithId); // Payload153
            PayloadTypes.Add(typeof(Payload154), Types.UnknownType154);
            PayloadTypes.Add(typeof(Payload155), Types.UnknownType155);
            PayloadTypes.Add(typeof(Payload156), Types.UnknownType156);
            PayloadTypes.Add(typeof(Payload157), Types.UnknownType157);
            PayloadTypes.Add(typeof(GetCDKeys), Types.GetCDKeys); // Payload158
            PayloadTypes.Add(typeof(SendCDKey), Types.SendCDKey); // Payload159
            PayloadTypes.Add(typeof(Payload160), Types.UnknownType160);
            PayloadTypes.Add(typeof(Payload161), Types.UnknownType161);
            PayloadTypes.Add(typeof(Payload162), Types.UnknownType162);
            PayloadTypes.Add(typeof(Payload163), Types.UnknownType163);
            PayloadTypes.Add(typeof(Payload164), Types.UnknownType164);
            PayloadTypes.Add(typeof(Payload165), Types.UnknownType165);
            PayloadTypes.Add(typeof(Payload166), Types.UnknownType166);
            PayloadTypes.Add(typeof(Payload167), Types.UnknownType167);
            PayloadTypes.Add(typeof(RegisterServer), Types.RegisterServer); // Payload168
            PayloadTypes.Add(typeof(Payload169), Types.UnknownType169);
            PayloadTypes.Add(typeof(ServerInfo), Types.ServerInfo); // Payload170
            PayloadTypes.Add(typeof(GetServers), Types.GetServers); // Payload171
            PayloadTypes.Add(typeof(StopServerUpdates), Types.StopServerUpdates); // Payload172
            PayloadTypes.Add(typeof(Payload173), Types.UnknownType173);
            PayloadTypes.Add(typeof(Payload174), Types.UnknownType174);
            PayloadTypes.Add(typeof(Payload175), Types.UnknownType175);
            PayloadTypes.Add(typeof(Payload176), Types.UnknownType176);
            PayloadTypes.Add(typeof(UpdateServerInfo), Types.UpdateServerInfo); // Payload177
            PayloadTypes.Add(typeof(Payload178), Types.UnknownType178);
            PayloadTypes.Add(typeof(Payload179), Types.UnknownType179);
            PayloadTypes.Add(typeof(Payload180), Types.UnknownType180);
            PayloadTypes.Add(typeof(Payload181), Types.UnknownType181);
            PayloadTypes.Add(typeof(Payload182), Types.UnknownType182);
            PayloadTypes.Add(typeof(Payload183), Types.UnknownType183);
            PayloadTypes.Add(typeof(Payload184), Types.UnknownType184);
            PayloadTypes.Add(typeof(Payload185), Types.UnknownType185);
            PayloadTypes.Add(typeof(Payload186), Types.UnknownType186);
            PayloadTypes.Add(typeof(Payload187), Types.UnknownType187);
            PayloadTypes.Add(typeof(VersionCheck), Types.VersionCheck); // Payload188
            PayloadTypes.Add(typeof(GetChatServer), Types.GetChatServer); // Payload189
            PayloadTypes.Add(typeof(Payload190), Types.UnknownType190);
            PayloadTypes.Add(typeof(Payload191), Types.UnknownType191);
            PayloadTypes.Add(typeof(SendChatServerInfo), Types.SendChatServerInfo); // Payload192
            PayloadTypes.Add(typeof(Payload193), Types.UnknownType193);
            PayloadTypes.Add(typeof(Payload194), Types.UnknownType194);
            PayloadTypes.Add(typeof(Login), Types.Login); // Payload201
            PayloadTypes.Add(typeof(LoginReply), Types.LoginReply); // Payload202
            PayloadTypes.Add(typeof(RegisterUser), Types.RegisterUser); // Payload203
            PayloadTypes.Add(typeof(LoginUser), Types.LoginUser); // Payload204
            PayloadTypes.Add(typeof(Payload205), Types.UnknownType205);
            PayloadTypes.Add(typeof(LoginServer), Types.LoginServer); // Payload206
            PayloadTypes.Add(typeof(LoginReplyCipher), Types.LoginReplyCipher); // Payload207
            PayloadTypes.Add(typeof(LoginChat), Types.LoginChat); // Payload211
            PayloadTypes.Add(typeof(LoginChatReply), Types.LoginChatReply); // Payload212
            PayloadTypes.Add(typeof(VerifyChatLogin), Types.VerifyChatLogin); // Payload213
            PayloadTypes.Add(typeof(Payload214), Types.UnknownType214);
            PayloadTypes.Add(typeof(ConnectToServer), Types.ConnectToServer); // Payload221
            PayloadTypes.Add(typeof(ConnectToServerReply), Types.ConnectToServerReply); // Payload222
            PayloadTypes.Add(typeof(PlayerConnecting), Types.PlayerConnecting); // Payload223
            PayloadTypes.Add(typeof(Payload224), Types.UnknownType224);
            PayloadTypes.Add(typeof(Payload240), Types.UnknownType240);
            PayloadTypes.Add(typeof(Payload241), Types.UnknownType241);
            PayloadTypes.Add(typeof(Payload242), Types.UnknownType242);
            PayloadTypes.Add(typeof(Payload243), Types.UnknownType243);
            PayloadTypes.Add(typeof(Payload244), Types.UnknownType244);
            PayloadTypes.Add(typeof(Payload245), Types.UnknownType245);
            PayloadTypes.Add(typeof(Payload246), Types.UnknownType246);
            PayloadTypes.Add(typeof(Payload247), Types.UnknownType247);
            PayloadTypes.Add(typeof(Payload248), Types.UnknownType248);
            PayloadTypes.Add(typeof(Payload249), Types.UnknownType249);
            PayloadTypes.Add(typeof(Payload250), Types.UnknownType250);
            PayloadTypes.Add(typeof(Payload251), Types.UnknownType251);
            PayloadTypes.Add(typeof(Payload252), Types.UnknownType252);
            PayloadTypes.Add(typeof(Payload253), Types.UnknownType253);
            PayloadTypes.Add(typeof(Payload254), Types.UnknownType254);
            PayloadTypes.Add(typeof(Payload255), Types.UnknownType255);
            PayloadTypes.Add(typeof(Payload256), Types.UnknownType256);
            PayloadTypes.Add(typeof(Payload257), Types.UnknownType257);
            PayloadTypes.Add(typeof(Payload258), Types.UnknownType258);
            PayloadTypes.Add(typeof(Payload259), Types.UnknownType259);
            PayloadTypes.Add(typeof(Payload260), Types.UnknownType260);
            PayloadTypes.Add(typeof(Payload261), Types.UnknownType261);
            PayloadTypes.Add(typeof(Payload262), Types.UnknownType262);

            foreach (KeyValuePair<Type, Types> payloadType in PayloadTypes)
            {
                PayloadFromType.Add(payloadType.Value, payloadType.Key);
            }
        }

        public static T CreatePayload<T>() where T : PayloadPrefix, new()
        {
            T payload = new T();

            payload.Magic = PayloadPrefix.PayloadMagic;

            Types payloadType;
            if (PayloadTypes.TryGetValue(typeof(T), out payloadType))
            {
                payload.Type1 = payload.Type2 = (ushort) payloadType;
            }

            return payload;
        }

        public static PayloadPrefix CreatePayload(Types type)
        {
            Type classType;
            if (PayloadFromType.TryGetValue(type, out classType))
            {
                PayloadPrefix result = (PayloadPrefix) Activator.CreateInstance(classType);
                result.Magic = PayloadPrefix.PayloadMagic;
                result.Type1 = result.Type2 = (ushort) type;
                return result;
            }

            return null;
        }
    }

//    undefined4 FUN_10028250(void)
//    {
//        int* piVar1;
//        int* unaff_EDI;
//
//        piVar1 = (int*)TinCat_CreatePropertySet();
//        (**(code**)(*piVar1 + 0x14))();
    public class PayloadPrefix
    {
        public ushort Magic;
        public ushort Type1;
        public ushort Type2;

        public const ushort PayloadMagic = 0x26B6;

        public virtual void Serialize(Serializer serializer)
        {
            serializer.Serialize(nameof(Magic), ref Magic);
            serializer.Serialize(nameof(Type1), ref Type1);
            serializer.Serialize(nameof(Type2), ref Type2);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("data",8);
//    (**(code**)(* unaff_EDI + 4))(1,piVar1);
    public class Payload1 : PayloadPrefix
    {
        public uint Data;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Data), ref Data);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("mode",8);
//    (**(code**)(* piVar1 + 4))("txt",2,0x100);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* piVar1 + 8))("from_id",8);
//    (**(code**)(* unaff_EDI + 4))(2,piVar1);
    public class Payload2 : PayloadPrefix
    {
        public uint Mode;
        public string Txt;
        public uint TicketId;
        public uint FromId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Mode), ref Mode);
            serializer.Serialize(nameof(Txt), ref Txt);
            serializer.Serialize(nameof(TicketId), ref TicketId);
            serializer.Serialize(nameof(FromId), ref FromId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("mode",8);
//    (**(code**)(* piVar1 + 4))("txt",2,0x100);
//    (**(code**)(* piVar1 + 8))("cell_id",8);
//    (**(code**)(* piVar1 + 8))("from_id",8);
//    (**(code**)(* piVar1 + 8))("to_id",8);
//    (**(code**)(* piVar1 + 4))("from_name",2,0x100);
//    (**(code**)(* unaff_EDI + 4))(3,piVar1);
    public class Payload3 : PayloadPrefix
    {
        public uint Mode;
        public string Txt;
        public uint CellId;
        public uint FromId;
        public uint ToId;
        public string FromName;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Mode), ref Mode);
            serializer.Serialize(nameof(Txt), ref Txt);
            serializer.Serialize(nameof(CellId), ref CellId);
            serializer.Serialize(nameof(FromId), ref FromId);
            serializer.Serialize(nameof(ToId), ref ToId);
            serializer.Serialize(nameof(FromName), ref FromName);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("nick",2,0x100);
//    (**(code**)(* piVar1 + 4))("password",2,0x20);
//    (**(code**)(* piVar1 + 4))("cd_key",2,0x80);
//    (**(code**)(* piVar1 + 8))("keypool",6);
//    (**(code**)(* piVar1 + 8))("patchlevel",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(4,piVar1);
    public class Payload4 : PayloadPrefix
    {
        public string Nick;
        public string Password;
        public string CdKey;
        public ushort Keypool;
        public uint Patchlevel;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Nick), ref Nick);
            serializer.Serialize(nameof(Password), ref Password);
            serializer.Serialize(nameof(CdKey), ref CdKey);
            serializer.Serialize(nameof(Keypool), ref Keypool);
            serializer.Serialize(nameof(Patchlevel), ref Patchlevel);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* piVar1 + 8))("cell_id",8);
//    (**(code**)(* piVar1 + 4))("nick",2,0x100);
//    (**(code**)(* unaff_EDI + 4))(5,piVar1);
    public class Payload5 : PayloadPrefix
    {
        public uint PermId;
        public uint CellId;
        public string Nick;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(PermId), ref PermId);
            serializer.Serialize(nameof(CellId), ref CellId);
            serializer.Serialize(nameof(Nick), ref Nick);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* piVar1 + 8))("cell_id",8);
//    (**(code**)(* unaff_EDI + 4))(6,piVar1);
    public class Payload6 : PayloadPrefix
    {
        public uint PermId;
        public uint CellId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(PermId), ref PermId);
            serializer.Serialize(nameof(CellId), ref CellId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("cell_id",8);
//    (**(code**)(* piVar1 + 8))("usr_count",8);
//    (**(code**)(* unaff_EDI + 4))(7,piVar1);
    public class Payload7 : PayloadPrefix
    {
        public uint CellId;
        public uint UsrCount;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(CellId), ref CellId);
            serializer.Serialize(nameof(UsrCount), ref UsrCount);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("cell_id",8);
//    (**(code**)(* unaff_EDI + 4))(8,piVar1);
    public class Payload8 : PayloadPrefix
    {
        public uint CellId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(CellId), ref CellId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("cell_id",8);
//    (**(code**)(* piVar1 + 8))("msg_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(9,piVar1);
    public class Payload9 : PayloadPrefix
    {
        public uint CellId;
        public uint MsgId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(CellId), ref CellId);
            serializer.Serialize(nameof(MsgId), ref MsgId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("cell_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(10,piVar1);
    public class Payload10 : PayloadPrefix
    {
        public uint CellId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(CellId), ref CellId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("cell_id",8);
//    (**(code**)(* piVar1 + 8))("msg_id",8);
//    (**(code**)(* piVar1 + 8))("msg_type",8);
//    (**(code**)(* piVar1 + 4))("msg_data",1,0);
//    (**(code**)(* piVar1 + 4))("title",2,0x80);
//    (**(code**)(* piVar1 + 8))("usrcom_mode",8);
//    (**(code**)(* piVar1 + 8))("creation_time",8);
//    (**(code**)(* piVar1 + 8))("creator",8);
//    (**(code**)(* piVar1 + 8))("expiration_mode",6);
//    (**(code**)(* piVar1 + 8))("expiration_date",8);
//    (**(code**)(* piVar1 + 8))("delivery_mode",6);
//    (**(code**)(* piVar1 + 8))("delivery_target",8);
//    (**(code**)(* piVar1 + 8))("delivery_interval",8);
//    (**(code**)(* piVar1 + 8))("delivery_date",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xb,piVar1);
    public class Payload11 : PayloadPrefix
    {
        public uint CellId;
        public uint MsgId;
        public uint MsgType;
        public byte[] MsgData;
        public string Title;
        public uint UsrcomMode;
        public uint CreationTime;
        public uint Creator;
        public ushort ExpirationMode;
        public uint ExpirationDate;
        public ushort DeliveryMode;
        public uint DeliveryTarget;
        public uint DeliveryInterval;
        public uint DeliveryDate;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(CellId), ref CellId);
            serializer.Serialize(nameof(MsgId), ref MsgId);
            serializer.Serialize(nameof(MsgType), ref MsgType);
            serializer.Serialize(nameof(MsgData), ref MsgData);
            serializer.Serialize(nameof(Title), ref Title);
            serializer.Serialize(nameof(UsrcomMode), ref UsrcomMode);
            serializer.Serialize(nameof(CreationTime), ref CreationTime);
            serializer.Serialize(nameof(Creator), ref Creator);
            serializer.Serialize(nameof(ExpirationMode), ref ExpirationMode);
            serializer.Serialize(nameof(ExpirationDate), ref ExpirationDate);
            serializer.Serialize(nameof(DeliveryMode), ref DeliveryMode);
            serializer.Serialize(nameof(DeliveryTarget), ref DeliveryTarget);
            serializer.Serialize(nameof(DeliveryInterval), ref DeliveryInterval);
            serializer.Serialize(nameof(DeliveryDate), ref DeliveryDate);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("cell_id",8);
//    (**(code**)(* piVar1 + 4))("idlist",1,0);
//    (**(code**)(* unaff_EDI + 4))(0xc,piVar1);
    public class Payload12 : PayloadPrefix
    {
        public uint CellId;
        public byte[] Idlist;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(CellId), ref CellId);
            serializer.Serialize(nameof(Idlist), ref Idlist);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("cell_id",8);
//    (**(code**)(* piVar1 + 8))("msg_id",8);
//    (**(code**)(* piVar1 + 8))("msg_type",8);
//    (**(code**)(* piVar1 + 4))("msg_data",1,0);
//    (**(code**)(* piVar1 + 4))("title",2,0x80);
//    (**(code**)(* piVar1 + 8))("usrcom_mode",8);
//    (**(code**)(* piVar1 + 8))("creation_time",8);
//    (**(code**)(* piVar1 + 8))("creator",8);
//    (**(code**)(* piVar1 + 8))("expiration_mode",6);
//    (**(code**)(* piVar1 + 8))("expiration_date",8);
//    (**(code**)(* piVar1 + 8))("delivery_mode",6);
//    (**(code**)(* piVar1 + 8))("delivery_target",8);
//    (**(code**)(* piVar1 + 8))("delivery_interval",8);
//    (**(code**)(* piVar1 + 8))("delivery_date",8);
//    (**(code**)(* unaff_EDI + 4))(0xd,piVar1);
    public class Payload13 : PayloadPrefix
    {
        public uint CellId;
        public uint MsgId;
        public uint MsgType;
        public byte[] MsgData;
        public string Title;
        public uint UsrcomMode;
        public uint CreationTime;
        public uint Creator;
        public ushort ExpirationMode;
        public uint ExpirationDate;
        public ushort DeliveryMode;
        public uint DeliveryTarget;
        public uint DeliveryInterval;
        public uint DeliveryDate;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(CellId), ref CellId);
            serializer.Serialize(nameof(MsgId), ref MsgId);
            serializer.Serialize(nameof(MsgType), ref MsgType);
            serializer.Serialize(nameof(MsgData), ref MsgData);
            serializer.Serialize(nameof(Title), ref Title);
            serializer.Serialize(nameof(UsrcomMode), ref UsrcomMode);
            serializer.Serialize(nameof(CreationTime), ref CreationTime);
            serializer.Serialize(nameof(Creator), ref Creator);
            serializer.Serialize(nameof(ExpirationMode), ref ExpirationMode);
            serializer.Serialize(nameof(ExpirationDate), ref ExpirationDate);
            serializer.Serialize(nameof(DeliveryMode), ref DeliveryMode);
            serializer.Serialize(nameof(DeliveryTarget), ref DeliveryTarget);
            serializer.Serialize(nameof(DeliveryInterval), ref DeliveryInterval);
            serializer.Serialize(nameof(DeliveryDate), ref DeliveryDate);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("cell_id",8);
//    (**(code**)(* piVar1 + 8))("msg_id",8);
//    (**(code**)(* piVar1 + 8))("msg_type",8);
//    (**(code**)(* piVar1 + 4))("msg_data",1,0);
//    (**(code**)(* piVar1 + 4))("title",2,0x80);
//    (**(code**)(* piVar1 + 8))("usrcom_mode",8);
//    (**(code**)(* piVar1 + 8))("creation_time",8);
//    (**(code**)(* piVar1 + 8))("creator",8);
//    (**(code**)(* piVar1 + 8))("expiration_mode",6);
//    (**(code**)(* piVar1 + 8))("expiration_date",8);
//    (**(code**)(* piVar1 + 8))("delivery_mode",6);
//    (**(code**)(* piVar1 + 8))("delivery_target",8);
//    (**(code**)(* piVar1 + 8))("delivery_interval",8);
//    (**(code**)(* piVar1 + 8))("delivery_date",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xe,piVar1);
    public class Payload14 : PayloadPrefix
    {
        public uint CellId;
        public uint MsgId;
        public uint MsgType;
        public byte[] MsgData;
        public string Title;
        public uint UsrcomMode;
        public uint CreationTime;
        public uint Creator;
        public ushort ExpirationMode;
        public uint ExpirationDate;
        public ushort DeliveryMode;
        public uint DeliveryTarget;
        public uint DeliveryInterval;
        public uint DeliveryDate;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(CellId), ref CellId);
            serializer.Serialize(nameof(MsgId), ref MsgId);
            serializer.Serialize(nameof(MsgType), ref MsgType);
            serializer.Serialize(nameof(MsgData), ref MsgData);
            serializer.Serialize(nameof(Title), ref Title);
            serializer.Serialize(nameof(UsrcomMode), ref UsrcomMode);
            serializer.Serialize(nameof(CreationTime), ref CreationTime);
            serializer.Serialize(nameof(Creator), ref Creator);
            serializer.Serialize(nameof(ExpirationMode), ref ExpirationMode);
            serializer.Serialize(nameof(ExpirationDate), ref ExpirationDate);
            serializer.Serialize(nameof(DeliveryMode), ref DeliveryMode);
            serializer.Serialize(nameof(DeliveryTarget), ref DeliveryTarget);
            serializer.Serialize(nameof(DeliveryInterval), ref DeliveryInterval);
            serializer.Serialize(nameof(DeliveryDate), ref DeliveryDate);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("cell_id",8);
//    (**(code**)(* piVar1 + 8))("msg_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xf,piVar1);
    public class Payload15 : PayloadPrefix
    {
        public uint CellId;
        public uint MsgId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(CellId), ref CellId);
            serializer.Serialize(nameof(MsgId), ref MsgId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("cell_id",8);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* piVar1 + 8))("from_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x10,piVar1);
    public class Payload16 : PayloadPrefix
    {
        public uint CellId;
        public uint PermId;
        public uint FromId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(CellId), ref CellId);
            serializer.Serialize(nameof(PermId), ref PermId);
            serializer.Serialize(nameof(FromId), ref FromId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("cell_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* piVar1 + 8))("option",6);
//    (**(code**)(* piVar1 + 4))("password",2,0x20);
//    (**(code**)(* piVar1 + 8))("from_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x11,piVar1);
    public class Payload17 : PayloadPrefix
    {
        public uint CellId;
        public uint TicketId;
        public ushort Option;
        public string Password;
        public uint FromId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(CellId), ref CellId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
            serializer.Serialize(nameof(Option), ref Option);
            serializer.Serialize(nameof(Password), ref Password);
            serializer.Serialize(nameof(FromId), ref FromId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("cell_id",8);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x12,piVar1);
    public class Payload18 : PayloadPrefix
    {
        public uint CellId;
        public uint PermId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(CellId), ref CellId);
            serializer.Serialize(nameof(PermId), ref PermId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x13,piVar1);
    public class Payload19 : PayloadPrefix
    {
        public uint PermId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(PermId), ref PermId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("group_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x14,piVar1);
    public class Payload20 : PayloadPrefix
    {
        public uint GroupId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(GroupId), ref GroupId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("username",2,0x20);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* piVar1 + 4))("userpwd",2,0x20);
//    (**(code**)(* piVar1 + 8))("group_id",8);
//    (**(code**)(* piVar1 + 8))("user_access",8);
//    (**(code**)(* piVar1 + 8))("active",0xe);
//    (**(code**)(* piVar1 + 8))("banned",0xe);
//    (**(code**)(* unaff_EDI + 4))(0x15,piVar1);
    public class Payload21 : PayloadPrefix
    {
        public string Username;
        public uint PermId;
        public string Userpwd;
        public uint GroupId;
        public uint UserAccess;
        public bool Active;
        public bool Banned;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Username), ref Username);
            serializer.Serialize(nameof(PermId), ref PermId);
            serializer.Serialize(nameof(Userpwd), ref Userpwd);
            serializer.Serialize(nameof(GroupId), ref GroupId);
            serializer.Serialize(nameof(UserAccess), ref UserAccess);
            serializer.Serialize(nameof(Active), ref Active);
            serializer.Serialize(nameof(Banned), ref Banned);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("groupname",2,0x20);
//    (**(code**)(* piVar1 + 8))("group_id",8);
//    (**(code**)(* piVar1 + 8))("grouptype",8);
//    (**(code**)(* piVar1 + 8))("group_access",8);
//    (**(code**)(* unaff_EDI + 4))(0x16,piVar1);
    public class Payload22 : PayloadPrefix
    {
        public string Groupname;
        public uint GroupId;
        public uint Grouptype;
        public uint GroupAccess;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Groupname), ref Groupname);
            serializer.Serialize(nameof(GroupId), ref GroupId);
            serializer.Serialize(nameof(Grouptype), ref Grouptype);
            serializer.Serialize(nameof(GroupAccess), ref GroupAccess);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("username",2,0x20);
//    (**(code**)(* piVar1 + 4))("userpwd",2,0x20);
//    (**(code**)(* piVar1 + 8))("group_id",8);
//    (**(code**)(* piVar1 + 8))("user_access",8);
//    (**(code**)(* piVar1 + 8))("active",0xe);
//    (**(code**)(* piVar1 + 8))("banned",0xe);
//    (**(code**)(* unaff_EDI + 4))(0x17,piVar1);
    public class Payload23 : PayloadPrefix
    {
        public string Username;
        public string Userpwd;
        public uint GroupId;
        public uint UserAccess;
        public bool Active;
        public bool Banned;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Username), ref Username);
            serializer.Serialize(nameof(Userpwd), ref Userpwd);
            serializer.Serialize(nameof(GroupId), ref GroupId);
            serializer.Serialize(nameof(UserAccess), ref UserAccess);
            serializer.Serialize(nameof(Active), ref Active);
            serializer.Serialize(nameof(Banned), ref Banned);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("groupname",2,0x20);
//    (**(code**)(* piVar1 + 8))("group_access",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x18,piVar1);
    public class Payload24 : PayloadPrefix
    {
        public string Groupname;
        public uint GroupAccess;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Groupname), ref Groupname);
            serializer.Serialize(nameof(GroupAccess), ref GroupAccess);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("username",2,0x20);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* piVar1 + 4))("userpwd",2,0x20);
//    (**(code**)(* piVar1 + 8))("group_id",8);
//    (**(code**)(* piVar1 + 8))("user_access",8);
//    (**(code**)(* piVar1 + 8))("active",0xe);
//    (**(code**)(* piVar1 + 8))("banned",0xe);
//    (**(code**)(* unaff_EDI + 4))(0x19,piVar1);
    public class Payload25 : PayloadPrefix
    {
        public string Username;
        public uint PermId;
        public string Userpwd;
        public uint GroupId;
        public uint UserAccess;
        public bool Active;
        public bool Banned;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Username), ref Username);
            serializer.Serialize(nameof(PermId), ref PermId);
            serializer.Serialize(nameof(Userpwd), ref Userpwd);
            serializer.Serialize(nameof(GroupId), ref GroupId);
            serializer.Serialize(nameof(UserAccess), ref UserAccess);
            serializer.Serialize(nameof(Active), ref Active);
            serializer.Serialize(nameof(Banned), ref Banned);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("groupname",2,0x20);
//    (**(code**)(* piVar1 + 8))("group_id",8);
//    (**(code**)(* piVar1 + 8))("group_access",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x1a,piVar1);
    public class Payload26 : PayloadPrefix
    {
        public string Groupname;
        public uint GroupId;
        public uint GroupAccess;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Groupname), ref Groupname);
            serializer.Serialize(nameof(GroupId), ref GroupId);
            serializer.Serialize(nameof(GroupAccess), ref GroupAccess);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x1b,piVar1);
    public class Payload27 : PayloadPrefix
    {
        public uint PermId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(PermId), ref PermId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("group_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x1c,piVar1);
    public class Payload28 : PayloadPrefix
    {
        public uint GroupId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(GroupId), ref GroupId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("result_id",8);
//    (**(code**)(* piVar1 + 8))("usr_grp_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x1d,piVar1);
    public class Payload29 : PayloadPrefix
    {
        public uint ResultId;
        public uint UsrGrpId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(ResultId), ref ResultId);
            serializer.Serialize(nameof(UsrGrpId), ref UsrGrpId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("mode",8);
//    (**(code**)(* piVar1 + 4))("txt",2,0x100);
//    (**(code**)(* piVar1 + 8))("cell_id",8);
//    (**(code**)(* piVar1 + 8))("from_id",8);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x1e,piVar1);
    public class Payload30 : PayloadPrefix
    {
        public uint Mode;
        public string Txt;
        public uint CellId;
        public uint FromId;
        public uint PermId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Mode), ref Mode);
            serializer.Serialize(nameof(Txt), ref Txt);
            serializer.Serialize(nameof(CellId), ref CellId);
            serializer.Serialize(nameof(FromId), ref FromId);
            serializer.Serialize(nameof(PermId), ref PermId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("delivery_target_name",2,0x20);
//    (**(code**)(* piVar1 + 4))("body",2,0x400);
//    (**(code**)(* unaff_EDI + 4))(0x1f,piVar1);
    public class Payload31 : PayloadPrefix
    {
        public string DeliveryTargetName;
        public string Body;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(DeliveryTargetName), ref DeliveryTargetName);
            serializer.Serialize(nameof(Body), ref Body);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("cell_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* piVar1 + 8))("msg_id",8);
//    (**(code**)(* piVar1 + 8))("msg_type",8);
//    (**(code**)(* piVar1 + 4))("msg_data",1,0);
//    (**(code**)(* piVar1 + 4))("title",2,0x80);
//    (**(code**)(* piVar1 + 8))("usrcom_mode",8);
//    (**(code**)(* piVar1 + 8))("creation_time",8);
//    (**(code**)(* piVar1 + 8))("creator",8);
//    (**(code**)(* piVar1 + 8))("expiration_mode",6);
//    (**(code**)(* piVar1 + 8))("expiration_date",8);
//    (**(code**)(* piVar1 + 8))("delivery_mode",6);
//    (**(code**)(* piVar1 + 8))("delivery_target",8);
//    (**(code**)(* piVar1 + 4))("delivery_target_name",2,0x20);
//    (**(code**)(* piVar1 + 8))("delivery_interval",8);
//    (**(code**)(* piVar1 + 8))("delivery_date",8);
//    (**(code**)(* unaff_EDI + 4))(0x20,piVar1);
    public class Payload32 : PayloadPrefix
    {
        public uint CellId;
        public uint TicketId;
        public uint MsgId;
        public uint MsgType;
        public byte[] MsgData;
        public string Title;
        public uint UsrcomMode;
        public uint CreationTime;
        public uint Creator;
        public ushort ExpirationMode;
        public uint ExpirationDate;
        public ushort DeliveryMode;
        public uint DeliveryTarget;
        public string DeliveryTargetName;
        public uint DeliveryInterval;
        public uint DeliveryDate;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(CellId), ref CellId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
            serializer.Serialize(nameof(MsgId), ref MsgId);
            serializer.Serialize(nameof(MsgType), ref MsgType);
            serializer.Serialize(nameof(MsgData), ref MsgData);
            serializer.Serialize(nameof(Title), ref Title);
            serializer.Serialize(nameof(UsrcomMode), ref UsrcomMode);
            serializer.Serialize(nameof(CreationTime), ref CreationTime);
            serializer.Serialize(nameof(Creator), ref Creator);
            serializer.Serialize(nameof(ExpirationMode), ref ExpirationMode);
            serializer.Serialize(nameof(ExpirationDate), ref ExpirationDate);
            serializer.Serialize(nameof(DeliveryMode), ref DeliveryMode);
            serializer.Serialize(nameof(DeliveryTarget), ref DeliveryTarget);
            serializer.Serialize(nameof(DeliveryTargetName), ref DeliveryTargetName);
            serializer.Serialize(nameof(DeliveryInterval), ref DeliveryInterval);
            serializer.Serialize(nameof(DeliveryDate), ref DeliveryDate);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("cell_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x21,piVar1);
    public class Payload33 : PayloadPrefix
    {
        public uint CellId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(CellId), ref CellId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("owner",8);
//    (**(code**)(* piVar1 + 8))("item_type",6);
//    (**(code**)(* piVar1 + 4))("item_name",2,0x80);
//    (**(code**)(* piVar1 + 8))("item_prize",8);
//    (**(code**)(* piVar1 + 4))("item_values",2,0x400);
//    (**(code**)(* piVar1 + 4))("item_data",1,0);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x22,piVar1);
    public class Payload34 : PayloadPrefix
    {
        public uint Owner;
        public ushort ItemType;
        public string ItemName;
        public uint ItemPrize;
        public string ItemValues;
        public byte[] ItemData;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Owner), ref Owner);
            serializer.Serialize(nameof(ItemType), ref ItemType);
            serializer.Serialize(nameof(ItemName), ref ItemName);
            serializer.Serialize(nameof(ItemPrize), ref ItemPrize);
            serializer.Serialize(nameof(ItemValues), ref ItemValues);
            serializer.Serialize(nameof(ItemData), ref ItemData);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("item_id",8);
//    (**(code**)(* piVar1 + 8))("item_prize",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x23,piVar1);
    public class Payload35 : PayloadPrefix
    {
        public uint ItemId;
        public uint ItemPrize;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(ItemId), ref ItemId);
            serializer.Serialize(nameof(ItemPrize), ref ItemPrize);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("item_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x24,piVar1);
    public class Payload36 : PayloadPrefix
    {
        public uint ItemId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(ItemId), ref ItemId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("netzone",6);
//    (**(code**)(* piVar1 + 8))("item_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x25,piVar1);
    public class Payload37 : PayloadPrefix
    {
        public ushort Netzone;
        public uint ItemId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Netzone), ref Netzone);
            serializer.Serialize(nameof(ItemId), ref ItemId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("item_id",8);
//    (**(code**)(* piVar1 + 8))("owner",8);
//    (**(code**)(* piVar1 + 4))("owner_name",2,0x20);
//    (**(code**)(* piVar1 + 8))("item_type",6);
//    (**(code**)(* piVar1 + 4))("item_name",2,0x80);
//    (**(code**)(* piVar1 + 8))("item_prize",8);
//    (**(code**)(* piVar1 + 4))("item_values",2,0x400);
//    (**(code**)(* piVar1 + 4))("item_data",1,0);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x26,piVar1);
    public class Payload38 : PayloadPrefix
    {
        public uint ItemId;
        public uint Owner;
        public string OwnerName;
        public ushort ItemType;
        public string ItemName;
        public uint ItemPrize;
        public string ItemValues;
        public byte[] ItemData;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(ItemId), ref ItemId);
            serializer.Serialize(nameof(Owner), ref Owner);
            serializer.Serialize(nameof(OwnerName), ref OwnerName);
            serializer.Serialize(nameof(ItemType), ref ItemType);
            serializer.Serialize(nameof(ItemName), ref ItemName);
            serializer.Serialize(nameof(ItemPrize), ref ItemPrize);
            serializer.Serialize(nameof(ItemValues), ref ItemValues);
            serializer.Serialize(nameof(ItemData), ref ItemData);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("netzone",6);
//    (**(code**)(* piVar1 + 8))("item_type",6);
//    (**(code**)(* piVar1 + 4))("owner_name",2,0x20);
//    (**(code**)(* piVar1 + 4))("name_pattern",2,0x80);
//    (**(code**)(* piVar1 + 8))("min_prize",8);
//    (**(code**)(* piVar1 + 8))("max_prize",8);
//    (**(code**)(* piVar1 + 8))("offset",8);
//    (**(code**)(* piVar1 + 8))("limit",6);
//    (**(code**)(* piVar1 + 8))("sort_field",5);
//    (**(code**)(* piVar1 + 8))("sort_order",0xe);
//    (**(code**)(* piVar1 + 4))("criterias",2,0x400);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x27,piVar1);
    public class Payload39 : PayloadPrefix
    {
        public ushort Netzone;
        public ushort ItemType;
        public string OwnerName;
        public string NamePattern;
        public uint MinPrize;
        public uint MaxPrize;
        public uint Offset;
        public ushort Limit;
        public sbyte SortField;
        public bool SortOrder;
        public string Criterias;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Netzone), ref Netzone);
            serializer.Serialize(nameof(ItemType), ref ItemType);
            serializer.Serialize(nameof(OwnerName), ref OwnerName);
            serializer.Serialize(nameof(NamePattern), ref NamePattern);
            serializer.Serialize(nameof(MinPrize), ref MinPrize);
            serializer.Serialize(nameof(MaxPrize), ref MaxPrize);
            serializer.Serialize(nameof(Offset), ref Offset);
            serializer.Serialize(nameof(Limit), ref Limit);
            serializer.Serialize(nameof(SortField), ref SortField);
            serializer.Serialize(nameof(SortOrder), ref SortOrder);
            serializer.Serialize(nameof(Criterias), ref Criterias);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x28,piVar1);
    public class Payload40 : PayloadPrefix
    {
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("limit",6);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x29,piVar1);
    public class Payload41 : PayloadPrefix
    {
        public ushort Limit;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Limit), ref Limit);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("errorcode",4);
//    (**(code**)(* piVar1 + 4))("errormsg",2,0x20);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x2a,piVar1);
    public class StatusMsg : PayloadPrefix // Payload42
    {
        public byte Errorcode;
        public string Errormsg;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Errorcode), ref Errorcode);
            serializer.Serialize(nameof(Errormsg), ref Errormsg);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("cell_id",8);
//    (**(code**)(* piVar1 + 8))("notification_type",8);
//    (**(code**)(* piVar1 + 8))("target_msg_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x2b,piVar1);
    public class Payload43 : PayloadPrefix
    {
        public uint CellId;
        public uint NotificationType;
        public uint TargetMsgId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(CellId), ref CellId);
            serializer.Serialize(nameof(NotificationType), ref NotificationType);
            serializer.Serialize(nameof(TargetMsgId), ref TargetMsgId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("item_id",8);
//    (**(code**)(* piVar1 + 8))("buyer",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x2c,piVar1);
    public class Payload44 : PayloadPrefix
    {
        public uint ItemId;
        public uint Buyer;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(ItemId), ref ItemId);
            serializer.Serialize(nameof(Buyer), ref Buyer);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("item_id",8);
//    (**(code**)(* piVar1 + 8))("buyer",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x2d,piVar1);
    public class Payload45 : PayloadPrefix
    {
        public uint ItemId;
        public uint Buyer;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(ItemId), ref ItemId);
            serializer.Serialize(nameof(Buyer), ref Buyer);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("item_id",8); /* NOTE: missing "type" ??? */
//    (**(code**)(* piVar1 + 8))("buyer",8);
//    (**(code**)(* piVar1 + 8))("item_type",6);
//    (**(code**)(* piVar1 + 4))("item_name",2,0x80);
//    (**(code**)(* piVar1 + 8))("item_prize",8);
//    (**(code**)(* piVar1 + 4))("item_values",2,0x400);
//    (**(code**)(* piVar1 + 4))("item_data",1,0);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x2e,piVar1);
    public class Payload46 : PayloadPrefix
    {
        public uint ItemId;
        public uint Buyer;
        public ushort ItemType;
        public string ItemName;
        public uint ItemPrize;
        public string ItemValues;
        public byte[] ItemData;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(ItemId), ref ItemId);
            serializer.Serialize(nameof(Buyer), ref Buyer);
            serializer.Serialize(nameof(ItemType), ref ItemType);
            serializer.Serialize(nameof(ItemName), ref ItemName);
            serializer.Serialize(nameof(ItemPrize), ref ItemPrize);
            serializer.Serialize(nameof(ItemValues), ref ItemValues);
            serializer.Serialize(nameof(ItemData), ref ItemData);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("items_found",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x2f,piVar1);
    public class Payload47 : PayloadPrefix
    {
        public uint ItemsFound;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(ItemsFound), ref ItemsFound);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x30,piVar1);
    public class Payload48 : PayloadPrefix
    {
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("value_name",2,0x40);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x31,piVar1);
    public class Payload49 : PayloadPrefix
    {
        public string ValueName;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(ValueName), ref ValueName);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("value_name",2,0x40);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x32,piVar1);
    public class Payload50 : PayloadPrefix
    {
        public string ValueName;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(ValueName), ref ValueName);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("value",2,0x20);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x33,piVar1);
    public class Payload51 : PayloadPrefix
    {
        public string Value;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Value), ref Value);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("resultcode",6);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x34,piVar1);
    public class Payload52 : PayloadPrefix
    {
        public ushort Resultcode;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Resultcode), ref Resultcode);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("user_id",8);
//    (**(code**)(* piVar1 + 4))("cd_key",2,0x80);
//    (**(code**)(* piVar1 + 8))("keypool",6);
//    (**(code**)(* piVar1 + 4))("name",2,0x80);
//    (**(code**)(* piVar1 + 8))("selection",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x35,piVar1);
    public class GetUserInfo : PayloadPrefix // Payload53
    {
        public uint UserId;
        public string CdKey;
        public ushort Keypool;
        public string Name;
        public uint Selection;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(UserId), ref UserId);
            serializer.Serialize(nameof(CdKey), ref CdKey);
            serializer.Serialize(nameof(Keypool), ref Keypool);
            serializer.Serialize(nameof(Name), ref Name);
            serializer.Serialize(nameof(Selection), ref Selection);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("user_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x37,piVar1);
    public class GetPlayerInfo : PayloadPrefix // Payload55
    {
        public uint UserId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(UserId), ref UserId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("user_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x38,piVar1);
    public class Payload56 : PayloadPrefix
    {
        public uint UserId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(UserId), ref UserId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("user_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x39,piVar1);
    public class Payload57 : PayloadPrefix
    {
        public uint UserId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(UserId), ref UserId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* piVar1 + 8))("access_index",6);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x3a,piVar1);
    public class Payload58 : PayloadPrefix
    {
        public uint PermId;
        public ushort AccessIndex;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(PermId), ref PermId);
            serializer.Serialize(nameof(AccessIndex), ref AccessIndex);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("user_id",8);
//    (**(code**)(* piVar1 + 4))("name",2,0x80);
//    (**(code**)(* piVar1 + 4))("password",2,0x20);
//    (**(code**)(* piVar1 + 4))("mail",2,0x80);
//    (**(code**)(* piVar1 + 8))("banned",0xe);
//    (**(code**)(* piVar1 + 8))("active",0xe);
//    (**(code**)(* piVar1 + 8))("status",4);
//    (**(code**)(* piVar1 + 4))("data",1,0);
//    (**(code**)(* piVar1 + 4))("created",2,0x20);
//    (**(code**)(* piVar1 + 4))("last_login",2,0x20);
//    (**(code**)(* piVar1 + 8))("total_logins",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x3b,piVar1);
    public class SendUserInfo : PayloadPrefix // Payload59
    {
        public uint UserId;
        public string Name;
        public string Password;
        public string Mail;
        public bool Banned;
        public bool Active;
        public byte Status;
        public byte[] Data;
        public string Created;
        public string LastLogin;
        public uint TotalLogins;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(UserId), ref UserId);
            serializer.Serialize(nameof(Name), ref Name);
            serializer.Serialize(nameof(Password), ref Password);
            serializer.Serialize(nameof(Mail), ref Mail);
            serializer.Serialize(nameof(Banned), ref Banned);
            serializer.Serialize(nameof(Active), ref Active);
            serializer.Serialize(nameof(Status), ref Status);
            serializer.Serialize(nameof(Data), ref Data);
            serializer.Serialize(nameof(Created), ref Created);
            serializer.Serialize(nameof(LastLogin), ref LastLogin);
            serializer.Serialize(nameof(TotalLogins), ref TotalLogins);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("char_id",8);
//    (**(code**)(* piVar1 + 4))("name",2,0x80);
//    (**(code**)(* piVar1 + 8))("owner_id",8);
//    (**(code**)(* piVar1 + 4))("owner_name",2,0x80);
//    (**(code**)(* piVar1 + 8))("guild_id",8);
//    (**(code**)(* piVar1 + 4))("guild_name",2,0x80);
//    (**(code**)(* piVar1 + 8))("guild_role",4);
//    (**(code**)(* piVar1 + 8))("status",4);
//    (**(code**)(* piVar1 + 8))("server_id",8);
//    (**(code**)(* piVar1 + 4))("server_name",2,0x80);
//    (**(code**)(* piVar1 + 4))("data",1,0);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x3c,piVar1);
    public class SendPlayerInfo : PayloadPrefix // Payload60
    {
        public uint CharId;
        public string Name;
        public uint OwnerId;
        public string OwnerName;
        public uint GuildId;
        public string GuildName;
        public byte GuildRole;
        public byte Status;
        public uint ServerId;
        public string ServerName;
        public byte[] Data;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(CharId), ref CharId);
            serializer.Serialize(nameof(Name), ref Name);
            serializer.Serialize(nameof(OwnerId), ref OwnerId);
            serializer.Serialize(nameof(OwnerName), ref OwnerName);
            serializer.Serialize(nameof(GuildId), ref GuildId);
            serializer.Serialize(nameof(GuildName), ref GuildName);
            serializer.Serialize(nameof(GuildRole), ref GuildRole);
            serializer.Serialize(nameof(Status), ref Status);
            serializer.Serialize(nameof(ServerId), ref ServerId);
            serializer.Serialize(nameof(ServerName), ref ServerName);
            serializer.Serialize(nameof(Data), ref Data);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("user_id",8);
//    (**(code**)(* piVar1 + 8))("buddy_id",8);
//    (**(code**)(* piVar1 + 4))("name",2,0x80);
//    (**(code**)(* piVar1 + 8))("perm_id_type",6);
//    (**(code**)(* piVar1 + 8))("status",4);
//    (**(code**)(* piVar1 + 8))("server_id",8);
//    (**(code**)(* piVar1 + 4))("server_name",2,0x80);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x3d,piVar1);
    public class Payload61 : PayloadPrefix
    {
        public uint UserId;
        public uint BuddyId;
        public string Name;
        public ushort PermIdType;
        public byte Status;
        public uint ServerId;
        public string ServerName;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(UserId), ref UserId);
            serializer.Serialize(nameof(BuddyId), ref BuddyId);
            serializer.Serialize(nameof(Name), ref Name);
            serializer.Serialize(nameof(PermIdType), ref PermIdType);
            serializer.Serialize(nameof(Status), ref Status);
            serializer.Serialize(nameof(ServerId), ref ServerId);
            serializer.Serialize(nameof(ServerName), ref ServerName);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("user_id",8);
//    (**(code**)(* piVar1 + 8))("group_id",8);
//    (**(code**)(* piVar1 + 4))("name",2,0x80);
//    (**(code**)(* piVar1 + 8))("level",4);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x3e,piVar1);
    public class Payload62 : PayloadPrefix
    {
        public uint UserId;
        public uint GroupId;
        public string Name;
        public byte Level;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(UserId), ref UserId);
            serializer.Serialize(nameof(GroupId), ref GroupId);
            serializer.Serialize(nameof(Name), ref Name);
            serializer.Serialize(nameof(Level), ref Level);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* piVar1 + 8))("access_index",6);
//    (**(code**)(* piVar1 + 8))("access",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x3f,piVar1);
    public class Payload63 : PayloadPrefix
    {
        public uint PermId;
        public ushort AccessIndex;
        public uint Access;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(PermId), ref PermId);
            serializer.Serialize(nameof(AccessIndex), ref AccessIndex);
            serializer.Serialize(nameof(Access), ref Access);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("group_id",8);
//    (**(code**)(* piVar1 + 4))("name",2,0x80);
//    (**(code**)(* piVar1 + 8))("selection",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x40,piVar1);
    public class Payload64 : PayloadPrefix
    {
        public uint GroupId;
        public string Name;
        public uint Selection;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(GroupId), ref GroupId);
            serializer.Serialize(nameof(Name), ref Name);
            serializer.Serialize(nameof(Selection), ref Selection);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("group_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x42,piVar1);
    public class Payload66 : PayloadPrefix
    {
        public uint GroupId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(GroupId), ref GroupId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("group_id",8);
//    (**(code**)(* piVar1 + 8))("access_index",6);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x43,piVar1);
    public class Payload67 : PayloadPrefix
    {
        public uint GroupId;
        public ushort AccessIndex;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(GroupId), ref GroupId);
            serializer.Serialize(nameof(AccessIndex), ref AccessIndex);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("group_id",8);
//    (**(code**)(* piVar1 + 8))("user_id",8);
//    (**(code**)(* piVar1 + 4))("name",2,0x80);
//    (**(code**)(* piVar1 + 8))("server_id",8);
//    (**(code**)(* piVar1 + 4))("server_name",2,0x80);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x44,piVar1);
    public class Payload68 : PayloadPrefix
    {
        public uint GroupId;
        public uint UserId;
        public string Name;
        public uint ServerId;
        public string ServerName;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(GroupId), ref GroupId);
            serializer.Serialize(nameof(UserId), ref UserId);
            serializer.Serialize(nameof(Name), ref Name);
            serializer.Serialize(nameof(ServerId), ref ServerId);
            serializer.Serialize(nameof(ServerName), ref ServerName);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("group_id",8);
//    (**(code**)(* piVar1 + 4))("name",2,0x80);
//    (**(code**)(* piVar1 + 8))("level",4);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x45,piVar1);
    public class Payload69 : PayloadPrefix
    {
        public uint GroupId;
        public string Name;
        public byte Level;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(GroupId), ref GroupId);
            serializer.Serialize(nameof(Name), ref Name);
            serializer.Serialize(nameof(Level), ref Level);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("group_id",8);
//    (**(code**)(* piVar1 + 8))("access_index",6);
//    (**(code**)(* piVar1 + 8))("access",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x46,piVar1);
    public class Payload70 : PayloadPrefix
    {
        public uint GroupId;
        public ushort AccessIndex;
        public uint Access;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(GroupId), ref GroupId);
            serializer.Serialize(nameof(AccessIndex), ref AccessIndex);
            serializer.Serialize(nameof(Access), ref Access);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("nick",2,0x100);
//    (**(code**)(* piVar1 + 4))("password",2,0x20);
//    (**(code**)(* piVar1 + 4))("cd_key",2,0x80);
//    (**(code**)(* piVar1 + 8))("keypool",6);
//    (**(code**)(* piVar1 + 8))("patchlevel",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x47,piVar1);
    public class Payload71 : PayloadPrefix
    {
        public string Nick;
        public string Password;
        public string CdKey;
        public ushort Keypool;
        public uint Patchlevel;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Nick), ref Nick);
            serializer.Serialize(nameof(Password), ref Password);
            serializer.Serialize(nameof(CdKey), ref CdKey);
            serializer.Serialize(nameof(Keypool), ref Keypool);
            serializer.Serialize(nameof(Patchlevel), ref Patchlevel);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("char_id",8);
//    (**(code**)(* piVar1 + 4))("name",2,0x80);
//    (**(code**)(* piVar1 + 8))("selection",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x48,piVar1);
    public class SelectNickname : PayloadPrefix // Payload72
    {
        public uint CharId;
        public string Name;
        public uint Selection;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(CharId), ref CharId);
            serializer.Serialize(nameof(Name), ref Name);
            serializer.Serialize(nameof(Selection), ref Selection);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("count",8);
//    (**(code**)(* piVar1 + 4))("data",1,0);
//    (**(code**)(* unaff_EDI + 4))(0x49,piVar1);
    public class Payload73 : PayloadPrefix
    {
        public uint Count;
        public byte[] Data;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Count), ref Count);
            serializer.Serialize(nameof(Data), ref Data);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("msg_type",8);
//    (**(code**)(* piVar1 + 4))("data",1,0);
//    (**(code**)(* unaff_EDI + 4))(0x4a,piVar1);
    public class Payload74 : PayloadPrefix
    {
        public uint MsgType;
        public byte[] Data;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(MsgType), ref MsgType);
            serializer.Serialize(nameof(Data), ref Data);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("char_id",8);
//    (**(code**)(* piVar1 + 4))("name",2,0x80);
//    (**(code**)(* piVar1 + 8))("owner_id",8);
//    (**(code**)(* piVar1 + 4))("owner_name",2,0x80);
//    (**(code**)(* piVar1 + 8))("guild_id",8);
//    (**(code**)(* piVar1 + 4))("guild_name",2,0x80);
//    (**(code**)(* piVar1 + 8))("guild_role",4);
//    (**(code**)(* piVar1 + 8))("status",4);
//    (**(code**)(* piVar1 + 8))("server_id",8);
//    (**(code**)(* piVar1 + 4))("server_name",2,0x80);
//    (**(code**)(* piVar1 + 4))("data",1,0);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x4b,piVar1);
    public class SelectNicknameReply : PayloadPrefix // Payload75
    {
        public uint CharId;
        public string Name;
        public uint OwnerId;
        public string OwnerName;
        public uint GuildId;
        public string GuildName;
        public byte GuildRole;
        public byte Status;
        public uint ServerId;
        public string ServerName;
        public byte[] Data;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(CharId), ref CharId);
            serializer.Serialize(nameof(Name), ref Name);
            serializer.Serialize(nameof(OwnerId), ref OwnerId);
            serializer.Serialize(nameof(OwnerName), ref OwnerName);
            serializer.Serialize(nameof(GuildId), ref GuildId);
            serializer.Serialize(nameof(GuildName), ref GuildName);
            serializer.Serialize(nameof(GuildRole), ref GuildRole);
            serializer.Serialize(nameof(Status), ref Status);
            serializer.Serialize(nameof(ServerId), ref ServerId);
            serializer.Serialize(nameof(ServerName), ref ServerName);
            serializer.Serialize(nameof(Data), ref Data);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("cell_id",8);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x4c,piVar1);
    public class Payload76 : PayloadPrefix
    {
        public uint CellId;
        public uint PermId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(CellId), ref CellId);
            serializer.Serialize(nameof(PermId), ref PermId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("name",2,0x80);
//    (**(code**)(* piVar1 + 8))("owner_id",8);
//    (**(code**)(* piVar1 + 4))("data",1,0);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x4d,piVar1);
    public class RegisterNickname : PayloadPrefix // Payload77
    {
        public string Name;
        public uint OwnerId;
        public byte[] Data;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Name), ref Name);
            serializer.Serialize(nameof(OwnerId), ref OwnerId);
            serializer.Serialize(nameof(Data), ref Data);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("owner_id",8);
//    (**(code**)(* piVar1 + 8))("guild_id",8);
//    (**(code**)(* piVar1 + 4))("name",2,0x80);
//    (**(code**)(* piVar1 + 8))("selection",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x4e,piVar1);
    public class Payload78 : PayloadPrefix
    {
        public uint OwnerId;
        public uint GuildId;
        public string Name;
        public uint Selection;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(OwnerId), ref OwnerId);
            serializer.Serialize(nameof(GuildId), ref GuildId);
            serializer.Serialize(nameof(Name), ref Name);
            serializer.Serialize(nameof(Selection), ref Selection);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("name",2,0x80);
//    (**(code**)(* piVar1 + 8))("owner_id",8);
//    (**(code**)(* piVar1 + 4))("data",1,0);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x4f,piVar1);
    public class Payload79 : PayloadPrefix
    {
        public string Name;
        public uint OwnerId;
        public byte[] Data;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Name), ref Name);
            serializer.Serialize(nameof(OwnerId), ref OwnerId);
            serializer.Serialize(nameof(Data), ref Data);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("guild_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x50,piVar1);
    public class Payload80 : PayloadPrefix
    {
        public uint GuildId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(GuildId), ref GuildId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("guild_id",8);
//    (**(code**)(* piVar1 + 4))("name",2,0x80);
//    (**(code**)(* piVar1 + 8))("owner_id",8);
//    (**(code**)(* piVar1 + 4))("owner_name",2,0x80);
//    (**(code**)(* piVar1 + 4))("data",1,0);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x52,piVar1);
    public class Payload82 : PayloadPrefix
    {
        public uint GuildId;
        public string Name;
        public uint OwnerId;
        public string OwnerName;
        public byte[] Data;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(GuildId), ref GuildId);
            serializer.Serialize(nameof(Name), ref Name);
            serializer.Serialize(nameof(OwnerId), ref OwnerId);
            serializer.Serialize(nameof(OwnerName), ref OwnerName);
            serializer.Serialize(nameof(Data), ref Data);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("guild_id",8);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* piVar1 + 4))("name",2,0x80);
//    (**(code**)(* piVar1 + 8))("perm_id_type",6);
//    (**(code**)(* piVar1 + 8))("status",4);
//    (**(code**)(* piVar1 + 8))("server_id",8);
//    (**(code**)(* piVar1 + 4))("server_name",2,0x80);
//    (**(code**)(* piVar1 + 8))("guild_role",4);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x53,piVar1);
    public class Payload83 : PayloadPrefix
    {
        public uint GuildId;
        public uint PermId;
        public string Name;
        public ushort PermIdType;
        public byte Status;
        public uint ServerId;
        public string ServerName;
        public byte GuildRole;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(GuildId), ref GuildId);
            serializer.Serialize(nameof(PermId), ref PermId);
            serializer.Serialize(nameof(Name), ref Name);
            serializer.Serialize(nameof(PermIdType), ref PermIdType);
            serializer.Serialize(nameof(Status), ref Status);
            serializer.Serialize(nameof(ServerId), ref ServerId);
            serializer.Serialize(nameof(ServerName), ref ServerName);
            serializer.Serialize(nameof(GuildRole), ref GuildRole);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("name",2,0x80);
//    (**(code**)(* piVar1 + 4))("cipher",1,0);
//    (**(code**)(* piVar1 + 4))("mail",2,0x80);
//    (**(code**)(* piVar1 + 8))("banned",0xe);
//    (**(code**)(* piVar1 + 8))("active",0xe);
//    (**(code**)(* piVar1 + 4))("data",1,0);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x54,piVar1);
    public class Payload84 : PayloadPrefix
    {
        public string Name;
        public byte[] Cipher;
        public string Mail;
        public bool Banned;
        public bool Active;
        public byte[] Data;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Name), ref Name);
            serializer.Serialize(nameof(Cipher), ref Cipher);
            serializer.Serialize(nameof(Mail), ref Mail);
            serializer.Serialize(nameof(Banned), ref Banned);
            serializer.Serialize(nameof(Active), ref Active);
            serializer.Serialize(nameof(Data), ref Data);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("name",2,0x80);
//    (**(code**)(* piVar1 + 8))("level",4);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x55,piVar1);
    public class Payload85 : PayloadPrefix
    {
        public string Name;
        public byte Level;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Name), ref Name);
            serializer.Serialize(nameof(Level), ref Level);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("name",2,0x80);
//    (**(code**)(* piVar1 + 8))("user_id",8);
//    (**(code**)(* piVar1 + 4))("data",1,0);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x56,piVar1);
    public class Payload86 : PayloadPrefix
    {
        public string Name;
        public uint UserId;
        public byte[] Data;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Name), ref Name);
            serializer.Serialize(nameof(UserId), ref UserId);
            serializer.Serialize(nameof(Data), ref Data);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("name",2,0x80);
//    (**(code**)(* piVar1 + 8))("owner_id",8);
//    (**(code**)(* piVar1 + 4))("data",1,0);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x57,piVar1);
    public class Payload87 : PayloadPrefix
    {
        public string Name;
        public uint OwnerId;
        public byte[] Data;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Name), ref Name);
            serializer.Serialize(nameof(OwnerId), ref OwnerId);
            serializer.Serialize(nameof(Data), ref Data);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("user_id",8);
//    (**(code**)(* piVar1 + 4))("name",2,0x80);
//    (**(code**)(* piVar1 + 4))("cipher",1,0);
//    (**(code**)(* piVar1 + 4))("mail",2,0x80);
//    (**(code**)(* piVar1 + 8))("banned",0xe);
//    (**(code**)(* piVar1 + 8))("active",0xe);
//    (**(code**)(* piVar1 + 4))("data",1,0);
//    (**(code**)(* piVar1 + 8))("property_mask",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x58,piVar1);
    public class ConfirmNickname : PayloadPrefix // Payload88
    {
        public uint UserId;
        public string Name;
        public byte[] Cipher;
        public string Mail;
        public bool Banned;
        public bool Active;
        public byte[] Data;
        public uint PropertyMask;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(UserId), ref UserId);
            serializer.Serialize(nameof(Name), ref Name);
            serializer.Serialize(nameof(Cipher), ref Cipher);
            serializer.Serialize(nameof(Mail), ref Mail);
            serializer.Serialize(nameof(Banned), ref Banned);
            serializer.Serialize(nameof(Active), ref Active);
            serializer.Serialize(nameof(Data), ref Data);
            serializer.Serialize(nameof(PropertyMask), ref PropertyMask);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("group_id",8);
//    (**(code**)(* piVar1 + 8))("property_mask",8);
//    (**(code**)(* piVar1 + 4))("name",2,0x80);
//    (**(code**)(* piVar1 + 8))("level",4);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x59,piVar1);
    public class Payload89 : PayloadPrefix
    {
        public uint GroupId;
        public uint PropertyMask;
        public string Name;
        public byte Level;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(GroupId), ref GroupId);
            serializer.Serialize(nameof(PropertyMask), ref PropertyMask);
            serializer.Serialize(nameof(Name), ref Name);
            serializer.Serialize(nameof(Level), ref Level);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("char_id",8);
//    (**(code**)(* piVar1 + 4))("name",2,0x80);
//    (**(code**)(* piVar1 + 4))("data",1,0);
//    (**(code**)(* piVar1 + 8))("property_mask",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x5a,piVar1);
    public class Payload90 : PayloadPrefix
    {
        public uint CharId;
        public string Name;
        public byte[] Data;
        public uint PropertyMask;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(CharId), ref CharId);
            serializer.Serialize(nameof(Name), ref Name);
            serializer.Serialize(nameof(Data), ref Data);
            serializer.Serialize(nameof(PropertyMask), ref PropertyMask);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("guild_id",8);
//    (**(code**)(* piVar1 + 4))("name",2,0x80);
//    (**(code**)(* piVar1 + 8))("owner_id",8);
//    (**(code**)(* piVar1 + 4))("data",1,0);
//    (**(code**)(* piVar1 + 8))("property_mask",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x5b,piVar1);
    public class Payload91 : PayloadPrefix
    {
        public uint GuildId;
        public string Name;
        public uint OwnerId;
        public byte[] Data;
        public uint PropertyMask;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(GuildId), ref GuildId);
            serializer.Serialize(nameof(Name), ref Name);
            serializer.Serialize(nameof(OwnerId), ref OwnerId);
            serializer.Serialize(nameof(Data), ref Data);
            serializer.Serialize(nameof(PropertyMask), ref PropertyMask);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("user_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x5c,piVar1);
    public class Payload92 : PayloadPrefix
    {
        public uint UserId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(UserId), ref UserId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("group_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x5d,piVar1);
    public class Payload93 : PayloadPrefix
    {
        public uint GroupId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(GroupId), ref GroupId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("char_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x5e,piVar1);
    public class Payload94 : PayloadPrefix
    {
        public uint CharId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(CharId), ref CharId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("guild_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x5f,piVar1);
    public class Payload95 : PayloadPrefix
    {
        public uint GuildId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(GuildId), ref GuildId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("user_id",8);
//    (**(code**)(* piVar1 + 4))("cd_key",2,0x80);
//    (**(code**)(* piVar1 + 8))("keypool",6);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x60,piVar1);
    public class Payload96 : PayloadPrefix
    {
        public uint UserId;
        public string CdKey;
        public ushort Keypool;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(UserId), ref UserId);
            serializer.Serialize(nameof(CdKey), ref CdKey);
            serializer.Serialize(nameof(Keypool), ref Keypool);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("user_id",8);
//    (**(code**)(* piVar1 + 4))("cd_key",2,0x80);
//    (**(code**)(* piVar1 + 8))("keypool",6);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x61,piVar1);
    public class Payload97 : PayloadPrefix
    {
        public uint UserId;
        public string CdKey;
        public ushort Keypool;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(UserId), ref UserId);
            serializer.Serialize(nameof(CdKey), ref CdKey);
            serializer.Serialize(nameof(Keypool), ref Keypool);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("user_id",8);
//    (**(code**)(* piVar1 + 8))("buddy_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x62,piVar1);
    public class Payload98 : PayloadPrefix
    {
        public uint UserId;
        public uint BuddyId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(UserId), ref UserId);
            serializer.Serialize(nameof(BuddyId), ref BuddyId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("user_id",8);
//    (**(code**)(* piVar1 + 8))("buddy_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(99,piVar1);
    public class Payload99 : PayloadPrefix
    {
        public uint UserId;
        public uint BuddyId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(UserId), ref UserId);
            serializer.Serialize(nameof(BuddyId), ref BuddyId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("group_id",8);
//    (**(code**)(* piVar1 + 8))("user_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(100,piVar1);
    public class Payload100 : PayloadPrefix
    {
        public uint GroupId;
        public uint UserId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(GroupId), ref GroupId);
            serializer.Serialize(nameof(UserId), ref UserId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("group_id",8);
//    (**(code**)(* piVar1 + 8))("user_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x65,piVar1);
    public class Payload101 : PayloadPrefix
    {
        public uint GroupId;
        public uint UserId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(GroupId), ref GroupId);
            serializer.Serialize(nameof(UserId), ref UserId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* piVar1 + 8))("guild_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x66,piVar1);
    public class Payload102 : PayloadPrefix
    {
        public uint PermId;
        public uint GuildId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(PermId), ref PermId);
            serializer.Serialize(nameof(GuildId), ref GuildId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* piVar1 + 8))("guild_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x67,piVar1);
    public class Payload103 : PayloadPrefix
    {
        public uint PermId;
        public uint GuildId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(PermId), ref PermId);
            serializer.Serialize(nameof(GuildId), ref GuildId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("group_id",8);
//    (**(code**)(* piVar1 + 8))("access_index",6);
//    (**(code**)(* piVar1 + 8))("access",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x68,piVar1);
    public class Payload104 : PayloadPrefix
    {
        public uint GroupId;
        public ushort AccessIndex;
        public uint Access;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(GroupId), ref GroupId);
            serializer.Serialize(nameof(AccessIndex), ref AccessIndex);
            serializer.Serialize(nameof(Access), ref Access);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x69,piVar1);
    public class GetWelcomeMsg : PayloadPrefix // Payload105
    {
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("txt",2,0x8000);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x6a,piVar1);
    public class SendWelcomeMsg : PayloadPrefix // Payload106
    {
        public string Txt;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Txt), ref Txt);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x6b,piVar1);
    public class Payload107 : PayloadPrefix
    {
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x6c,piVar1);
    public class Payload108 : PayloadPrefix
    {
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("user_id",8);
//    (**(code**)(* piVar1 + 4))("name",2,0x80);
//    (**(code**)(* unaff_EDI + 4))(0x6d,piVar1);
    public class Payload109 : PayloadPrefix
    {
        public uint UserId;
        public string Name;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(UserId), ref UserId);
            serializer.Serialize(nameof(Name), ref Name);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("user_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x6e,piVar1);
    public class Payload110 : PayloadPrefix
    {
        public uint UserId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(UserId), ref UserId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x6f,piVar1);
    public class Payload111 : PayloadPrefix
    {
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x70,piVar1);
    public class Payload112 : PayloadPrefix
    {
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x71,piVar1);
    public class Payload113 : PayloadPrefix
    {
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x72,piVar1);
    public class Payload114 : PayloadPrefix
    {
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("send_all",0xe);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x73,piVar1);
    public class Payload115 : PayloadPrefix
    {
        public bool SendAll;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(SendAll), ref SendAll);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x74,piVar1);
    public class Payload116 : PayloadPrefix
    {
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x75,piVar1);
    public class Payload117 : PayloadPrefix
    {
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x76,piVar1);
    public class Payload118 : PayloadPrefix
    {
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("cd_key",2,0x80);
//    (**(code**)(* piVar1 + 8))("keypool",6);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x77,piVar1);
    public class Payload119 : PayloadPrefix
    {
        public string CdKey;
        public ushort Keypool;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(CdKey), ref CdKey);
            serializer.Serialize(nameof(Keypool), ref Keypool);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("cd_key",2,0x80);
//    (**(code**)(* piVar1 + 8))("keypool",6);
//    (**(code**)(* piVar1 + 8))("banned",0xe);
//    (**(code**)(* piVar1 + 8))("user_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x78,piVar1);
    public class Payload120 : PayloadPrefix
    {
        public string CdKey;
        public ushort Keypool;
        public bool Banned;
        public uint UserId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(CdKey), ref CdKey);
            serializer.Serialize(nameof(Keypool), ref Keypool);
            serializer.Serialize(nameof(Banned), ref Banned);
            serializer.Serialize(nameof(UserId), ref UserId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("machine_id",8);
//    (**(code**)(* piVar1 + 4))("ip",2,0x80);
//    (**(code**)(* piVar1 + 8))("selection",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x79,piVar1);
    public class Payload121 : PayloadPrefix
    {
        public uint MachineId;
        public string Ip;
        public uint Selection;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(MachineId), ref MachineId);
            serializer.Serialize(nameof(Ip), ref Ip);
            serializer.Serialize(nameof(Selection), ref Selection);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("machine_id",8);
//    (**(code**)(* piVar1 + 4))("description",2,0x80);
//    (**(code**)(* piVar1 + 4))("ip",2,0x80);
//    (**(code**)(* piVar1 + 8))("active",0xe);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x7a,piVar1);
    public class Payload122 : PayloadPrefix
    {
        public uint MachineId;
        public string Description;
        public string Ip;
        public bool Active;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(MachineId), ref MachineId);
            serializer.Serialize(nameof(Description), ref Description);
            serializer.Serialize(nameof(Ip), ref Ip);
            serializer.Serialize(nameof(Active), ref Active);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("user_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x7b,piVar1);
    public class Payload123 : PayloadPrefix
    {
        public uint UserId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(UserId), ref UserId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* piVar1 + 8))("machine_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x7c,piVar1);
    public class Payload124 : PayloadPrefix
    {
        public uint PermId;
        public uint MachineId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(PermId), ref PermId);
            serializer.Serialize(nameof(MachineId), ref MachineId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("user_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x7d,piVar1);
    public class Payload125 : PayloadPrefix
    {
        public uint UserId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(UserId), ref UserId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("char_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x7e,piVar1);
    public class Payload126 : PayloadPrefix
    {
        public uint CharId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(CharId), ref CharId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("char_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x80,piVar1);
    public class Payload128 : PayloadPrefix
    {
        public uint CharId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(CharId), ref CharId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("user_id",8);
//    (**(code**)(* piVar1 + 8))("restore_chars",0xe);
//    (**(code**)(* piVar1 + 4))("filename",2,0x100);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x87,piVar1);
    public class Payload135 : PayloadPrefix
    {
        public uint UserId;
        public bool RestoreChars;
        public string Filename;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(UserId), ref UserId);
            serializer.Serialize(nameof(RestoreChars), ref RestoreChars);
            serializer.Serialize(nameof(Filename), ref Filename);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("char_id",8);
//    (**(code**)(* piVar1 + 4))("filename",2,0x100);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x89,piVar1);
    public class Payload137 : PayloadPrefix
    {
        public uint CharId;
        public string Filename;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(CharId), ref CharId);
            serializer.Serialize(nameof(Filename), ref Filename);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* piVar1 + 4))("ip",2,0x80);
//    (**(code**)(* piVar1 + 8))("port",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x8a,piVar1);
    public class Payload138 : PayloadPrefix
    {
        public uint PermId;
        public string Ip;
        public uint Port;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(PermId), ref PermId);
            serializer.Serialize(nameof(Ip), ref Ip);
            serializer.Serialize(nameof(Port), ref Port);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x8b,piVar1);
    public class Payload139 : PayloadPrefix
    {
        public uint PermId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(PermId), ref PermId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("cd_key",2,0x80);
//    (**(code**)(* piVar1 + 8))("keypool",6);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x8c,piVar1);
    public class Payload140 : PayloadPrefix
    {
        public string CdKey;
        public ushort Keypool;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(CdKey), ref CdKey);
            serializer.Serialize(nameof(Keypool), ref Keypool);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("cd_key",2,0x80);
//    (**(code**)(* piVar1 + 8))("keypool",6);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x8d,piVar1);
    public class Payload141 : PayloadPrefix
    {
        public string CdKey;
        public ushort Keypool;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(CdKey), ref CdKey);
            serializer.Serialize(nameof(Keypool), ref Keypool);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("cd_key",2,0x80);
//    (**(code**)(* piVar1 + 8))("keypool",6);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x8e,piVar1);
    public class Payload142 : PayloadPrefix
    {
        public string CdKey;
        public ushort Keypool;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(CdKey), ref CdKey);
            serializer.Serialize(nameof(Keypool), ref Keypool);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("cd_key",2,0x80);
//    (**(code**)(* piVar1 + 8))("keypool",6);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x8f,piVar1);
    public class Payload143 : PayloadPrefix
    {
        public string CdKey;
        public ushort Keypool;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(CdKey), ref CdKey);
            serializer.Serialize(nameof(Keypool), ref Keypool);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* piVar1 + 4))("name",2,0x80);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x90,piVar1);
    public class Payload144 : PayloadPrefix
    {
        public uint PermId;
        public string Name;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(PermId), ref PermId);
            serializer.Serialize(nameof(Name), ref Name);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* piVar1 + 4))("name",2,0x80);
//    (**(code**)(* piVar1 + 8))("perm_id_type",6);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x91,piVar1);
    public class Payload145 : PayloadPrefix
    {
        public uint PermId;
        public string Name;
        public ushort PermIdType;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(PermId), ref PermId);
            serializer.Serialize(nameof(Name), ref Name);
            serializer.Serialize(nameof(PermIdType), ref PermIdType);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x92,piVar1);
    public class Payload146 : PayloadPrefix
    {
        public uint PermId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(PermId), ref PermId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("delivery_target",8);
//    (**(code**)(* piVar1 + 8))("selection",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x93,piVar1);
    public class Payload147 : PayloadPrefix
    {
        public uint DeliveryTarget;
        public uint Selection;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(DeliveryTarget), ref DeliveryTarget);
            serializer.Serialize(nameof(Selection), ref Selection);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("message_id",8);
//    (**(code**)(* piVar1 + 8))("status",4);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x94,piVar1);
    public class Payload148 : PayloadPrefix
    {
        public uint MessageId;
        public byte Status;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(MessageId), ref MessageId);
            serializer.Serialize(nameof(Status), ref Status);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("delivery_target",8);
//    (**(code**)(* piVar1 + 8))("message_id",8);
//    (**(code**)(* piVar1 + 8))("creator",8);
//    (**(code**)(* piVar1 + 8))("creation_time",8);
//    (**(code**)(* piVar1 + 4))("title",2,0x80);
//    (**(code**)(* piVar1 + 8))("status",4);
//    (**(code**)(* piVar1 + 4))("message_text",1,0);
//    (**(code**)(* piVar1 + 4))("data",1,0);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x95,piVar1);
    public class Payload149 : PayloadPrefix
    {
        public uint DeliveryTarget;
        public uint MessageId;
        public uint Creator;
        public uint CreationTime;
        public string Title;
        public byte Status;
        public byte[] MessageText;
        public byte[] Data;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(DeliveryTarget), ref DeliveryTarget);
            serializer.Serialize(nameof(MessageId), ref MessageId);
            serializer.Serialize(nameof(Creator), ref Creator);
            serializer.Serialize(nameof(CreationTime), ref CreationTime);
            serializer.Serialize(nameof(Title), ref Title);
            serializer.Serialize(nameof(Status), ref Status);
            serializer.Serialize(nameof(MessageText), ref MessageText);
            serializer.Serialize(nameof(Data), ref Data);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("delivery_target",8);
//    (**(code**)(* piVar1 + 8))("creator",8);
//    (**(code**)(* piVar1 + 8))("creation_time",8);
//    (**(code**)(* piVar1 + 4))("title",2,0x80);
//    (**(code**)(* piVar1 + 4))("message_text",1,0);
//    (**(code**)(* piVar1 + 4))("data",1,0);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x96,piVar1);
    public class Payload150 : PayloadPrefix
    {
        public uint DeliveryTarget;
        public uint Creator;
        public uint CreationTime;
        public string Title;
        public byte[] MessageText;
        public byte[] Data;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(DeliveryTarget), ref DeliveryTarget);
            serializer.Serialize(nameof(Creator), ref Creator);
            serializer.Serialize(nameof(CreationTime), ref CreationTime);
            serializer.Serialize(nameof(Title), ref Title);
            serializer.Serialize(nameof(MessageText), ref MessageText);
            serializer.Serialize(nameof(Data), ref Data);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("message_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x97,piVar1);
    public class Payload151 : PayloadPrefix
    {
        public uint MessageId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(MessageId), ref MessageId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* piVar1 + 8))("guild_id",8);
//    (**(code**)(* piVar1 + 8))("guild_role",4);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x98,piVar1);
    public class Payload152 : PayloadPrefix
    {
        public uint PermId;
        public uint GuildId;
        public byte GuildRole;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(PermId), ref PermId);
            serializer.Serialize(nameof(GuildId), ref GuildId);
            serializer.Serialize(nameof(GuildRole), ref GuildRole);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("errorcode",4);
//    (**(code**)(* piVar1 + 4))("errormsg",2,0x20);
//    (**(code**)(* piVar1 + 8))("id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x99,piVar1);
    public class StatusWithId : PayloadPrefix // Payload153
    {
        public byte Errorcode;
        public string Errormsg;
        public uint Id;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Errorcode), ref Errorcode);
            serializer.Serialize(nameof(Errormsg), ref Errormsg);
            serializer.Serialize(nameof(Id), ref Id);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("user_id",8);
//    (**(code**)(* piVar1 + 8))("ignore_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x9a,piVar1);
    public class Payload154 : PayloadPrefix
    {
        public uint UserId;
        public uint IgnoreId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(UserId), ref UserId);
            serializer.Serialize(nameof(IgnoreId), ref IgnoreId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("user_id",8);
//    (**(code**)(* piVar1 + 8))("ignore_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x9b,piVar1);
    public class Payload155 : PayloadPrefix
    {
        public uint UserId;
        public uint IgnoreId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(UserId), ref UserId);
            serializer.Serialize(nameof(IgnoreId), ref IgnoreId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("user_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x9c,piVar1);
    public class Payload156 : PayloadPrefix
    {
        public uint UserId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(UserId), ref UserId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("user_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x9d,piVar1);
    public class Payload157 : PayloadPrefix
    {
        public uint UserId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(UserId), ref UserId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("user_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x9e,piVar1);
    public class GetCDKeys : PayloadPrefix // Payload158
    {
        public uint UserId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(UserId), ref UserId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("user_id",8);
//    (**(code**)(* piVar1 + 4))("cd_key",2,0x80);
//    (**(code**)(* piVar1 + 8))("keypool",6);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x9f,piVar1);
    public class SendCDKey : PayloadPrefix // Payload159
    {
        public uint UserId;
        public string CdKey;
        public ushort Keypool;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(UserId), ref UserId);
            serializer.Serialize(nameof(CdKey), ref CdKey);
            serializer.Serialize(nameof(Keypool), ref Keypool);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("user_id",8);
//    (**(code**)(* piVar1 + 8))("ignore_id",8);
//    (**(code**)(* piVar1 + 4))("name",2,0x80);
//    (**(code**)(* piVar1 + 8))("perm_id_type",6);
//    (**(code**)(* piVar1 + 8))("status",4);
//    (**(code**)(* piVar1 + 8))("server_id",8);
//    (**(code**)(* piVar1 + 4))("server_name",2,0x80);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xa0,piVar1);
    public class Payload160 : PayloadPrefix
    {
        public uint UserId;
        public uint IgnoreId;
        public string Name;
        public ushort PermIdType;
        public byte Status;
        public uint ServerId;
        public string ServerName;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(UserId), ref UserId);
            serializer.Serialize(nameof(IgnoreId), ref IgnoreId);
            serializer.Serialize(nameof(Name), ref Name);
            serializer.Serialize(nameof(PermIdType), ref PermIdType);
            serializer.Serialize(nameof(Status), ref Status);
            serializer.Serialize(nameof(ServerId), ref ServerId);
            serializer.Serialize(nameof(ServerName), ref ServerName);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("kategory",9);
//    (**(code**)(* piVar1 + 8))("index",9);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xa1,piVar1);
    public class Payload161 : PayloadPrefix
    {
        public int Kategory;
        public int Index;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Kategory), ref Kategory);
            serializer.Serialize(nameof(Index), ref Index);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("kategory",9);
//    (**(code**)(* piVar1 + 8))("index",9);
//    (**(code**)(* piVar1 + 8))("value",9);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xa2,piVar1);
    public class Payload162 : PayloadPrefix
    {
        public int Kategory;
        public int Index;
        public int Value;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Kategory), ref Kategory);
            serializer.Serialize(nameof(Index), ref Index);
            serializer.Serialize(nameof(Value), ref Value);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("kategory",9);
//    (**(code**)(* piVar1 + 8))("index",9);
//    (**(code**)(* piVar1 + 8))("value",9);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xa3,piVar1);
    public class Payload163 : PayloadPrefix
    {
        public int Kategory;
        public int Index;
        public int Value;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Kategory), ref Kategory);
            serializer.Serialize(nameof(Index), ref Index);
            serializer.Serialize(nameof(Value), ref Value);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("kategory",9);
//    (**(code**)(* piVar1 + 8))("index",9);
//    (**(code**)(* piVar1 + 8))("value",9);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xa4,piVar1);
    public class Payload164 : PayloadPrefix
    {
        public int Kategory;
        public int Index;
        public int Value;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Kategory), ref Kategory);
            serializer.Serialize(nameof(Index), ref Index);
            serializer.Serialize(nameof(Value), ref Value);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("txt",2,0x100);
//    (**(code**)(* piVar1 + 8))("from_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xa5,piVar1);
    public class Payload165 : PayloadPrefix
    {
        public string Txt;
        public uint FromId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Txt), ref Txt);
            serializer.Serialize(nameof(FromId), ref FromId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("server_id",8);
//    (**(code**)(* piVar1 + 8))("room_id",8);
//    (**(code**)(* piVar1 + 8))("server_type",4);
//    (**(code**)(* piVar1 + 8))("server_subtype",4);
//    (**(code**)(* piVar1 + 8))("selection",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xa6,piVar1);
    public class Payload166 : PayloadPrefix
    {
        public uint ServerId;
        public uint RoomId;
        public byte ServerType;
        public byte ServerSubtype;
        public uint Selection;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(ServerId), ref ServerId);
            serializer.Serialize(nameof(RoomId), ref RoomId);
            serializer.Serialize(nameof(ServerType), ref ServerType);
            serializer.Serialize(nameof(ServerSubtype), ref ServerSubtype);
            serializer.Serialize(nameof(Selection), ref Selection);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("machine_id",8);
//    (**(code**)(* piVar1 + 8))("selection",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xa7,piVar1);
    public class Payload167 : PayloadPrefix
    {
        public uint MachineId;
        public uint Selection;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(MachineId), ref MachineId);
            serializer.Serialize(nameof(Selection), ref Selection);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("name",2,0x80);
//    (**(code**)(* piVar1 + 4))("description",2,0x80);
//    (**(code**)(* piVar1 + 4))("ip",2,0x80);
//    (**(code**)(* piVar1 + 4))("localip",2,0x80);
//    (**(code**)(* piVar1 + 8))("port",8);
//    (**(code**)(* piVar1 + 8))("server_type",4);
//    (**(code**)(* piVar1 + 8))("server_subtype",4);
//    (**(code**)(* piVar1 + 4))("cipher",1,0);
//    (**(code**)(* piVar1 + 4))("version",2,0x20);
//    (**(code**)(* piVar1 + 8))("max_players",6);
//    (**(code**)(* piVar1 + 8))("max_spectators",6);
//    (**(code**)(* piVar1 + 8))("ai_players",6);
//    (**(code**)(* piVar1 + 8))("room_id",8);
//    (**(code**)(* piVar1 + 8))("level",4);
//    (**(code**)(* piVar1 + 8))("game_mode",4);
//    (**(code**)(* piVar1 + 8))("hardcore",0xe);
//    (**(code**)(* piVar1 + 4))("map",2,0x80);
//    (**(code**)(* piVar1 + 8))("running",0xe);
//    (**(code**)(* piVar1 + 8))("locked_config",0xe);
//    (**(code**)(* piVar1 + 8))("automatic_join",0xe);
//    (**(code**)(* piVar1 + 4))("data",1,0);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xa8,piVar1);
    public class RegisterServer : PayloadPrefix // Payload168
    {
        public string Name;
        public string Description;
        public string Ip;
        public string Localip;
        public uint Port;
        public byte ServerType;
        public byte ServerSubtype;
        public byte[] Cipher;
        public string Version;
        public ushort MaxPlayers;
        public ushort MaxSpectators;
        public ushort AiPlayers;
        public uint RoomId;
        public byte Level;
        public byte GameMode;
        public bool Hardcore;
        public string Map;
        public bool Running;
        public bool LockedConfig;
        public bool AutomaticJoin;
        public byte[] Data;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Name), ref Name);
            serializer.Serialize(nameof(Description), ref Description);
            serializer.Serialize(nameof(Ip), ref Ip);
            serializer.Serialize(nameof(Localip), ref Localip);
            serializer.Serialize(nameof(Port), ref Port);
            serializer.Serialize(nameof(ServerType), ref ServerType);
            serializer.Serialize(nameof(ServerSubtype), ref ServerSubtype);
            serializer.Serialize(nameof(Cipher), ref Cipher);
            serializer.Serialize(nameof(Version), ref Version);
            serializer.Serialize(nameof(MaxPlayers), ref MaxPlayers);
            serializer.Serialize(nameof(MaxSpectators), ref MaxSpectators);
            serializer.Serialize(nameof(AiPlayers), ref AiPlayers);
            serializer.Serialize(nameof(RoomId), ref RoomId);
            serializer.Serialize(nameof(Level), ref Level);
            serializer.Serialize(nameof(GameMode), ref GameMode);
            serializer.Serialize(nameof(Hardcore), ref Hardcore);
            serializer.Serialize(nameof(Map), ref Map);
            serializer.Serialize(nameof(Running), ref Running);
            serializer.Serialize(nameof(LockedConfig), ref LockedConfig);
            serializer.Serialize(nameof(AutomaticJoin), ref AutomaticJoin);
            serializer.Serialize(nameof(Data), ref Data);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("server_id",8);
//    (**(code**)(* piVar1 + 8))("running",0xe);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xa9,piVar1);
    public class Payload169 : PayloadPrefix
    {
        public uint ServerId;
        public bool Running;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(ServerId), ref ServerId);
            serializer.Serialize(nameof(Running), ref Running);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("server_id",8);
//    (**(code**)(* piVar1 + 4))("name",2,0x80);
//    (**(code**)(* piVar1 + 8))("owner_id",8);
//    (**(code**)(* piVar1 + 4))("description",2,0x80);
//    (**(code**)(* piVar1 + 4))("ip",2,0x80);
//    (**(code**)(* piVar1 + 8))("port",8);
//    (**(code**)(* piVar1 + 8))("password_required",0xe);
//    (**(code**)(* piVar1 + 8))("server_type",4);
//    (**(code**)(* piVar1 + 8))("server_subtype",4);
//    (**(code**)(* piVar1 + 4))("version",2,0x20);
//    (**(code**)(* piVar1 + 8))("max_players",6);
//    (**(code**)(* piVar1 + 8))("cur_players",6);
//    (**(code**)(* piVar1 + 8))("max_spectators",6);
//    (**(code**)(* piVar1 + 8))("cur_spectators",6);
//    (**(code**)(* piVar1 + 8))("ai_players",6);
//    (**(code**)(* piVar1 + 8))("room_id",8);
//    (**(code**)(* piVar1 + 8))("level",4);
//    (**(code**)(* piVar1 + 8))("game_mode",4);
//    (**(code**)(* piVar1 + 8))("hardcore",0xe);
//    (**(code**)(* piVar1 + 4))("map",2,0x80);
//    (**(code**)(* piVar1 + 8))("running",0xe);
//    (**(code**)(* piVar1 + 8))("locked_config",0xe);
//    (**(code**)(* piVar1 + 4))("data",1,0);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xaa,piVar1);
    public class ServerInfo : PayloadPrefix // Payload170
    {
        public uint ServerId;
        public string Name;
        public uint OwnerId;
        public string Description;
        public string Ip;
        public uint Port;
        public bool PasswordRequired;
        public byte ServerType;
        public byte ServerSubtype;
        public string Version;
        public ushort MaxPlayers;
        public ushort CurPlayers;
        public ushort MaxSpectators;
        public ushort CurSpectators;
        public ushort AiPlayers;
        public uint RoomId;
        public byte Level;
        public byte GameMode;
        public bool Hardcore;
        public string Map;
        public bool Running;
        public bool LockedConfig;
        public byte[] Data;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(ServerId), ref ServerId);
            serializer.Serialize(nameof(Name), ref Name);
            serializer.Serialize(nameof(OwnerId), ref OwnerId);
            serializer.Serialize(nameof(Description), ref Description);
            serializer.Serialize(nameof(Ip), ref Ip);
            serializer.Serialize(nameof(Port), ref Port);
            serializer.Serialize(nameof(PasswordRequired), ref PasswordRequired);
            serializer.Serialize(nameof(ServerType), ref ServerType);
            serializer.Serialize(nameof(ServerSubtype), ref ServerSubtype);
            serializer.Serialize(nameof(Version), ref Version);
            serializer.Serialize(nameof(MaxPlayers), ref MaxPlayers);
            serializer.Serialize(nameof(CurPlayers), ref CurPlayers);
            serializer.Serialize(nameof(MaxSpectators), ref MaxSpectators);
            serializer.Serialize(nameof(CurSpectators), ref CurSpectators);
            serializer.Serialize(nameof(AiPlayers), ref AiPlayers);
            serializer.Serialize(nameof(RoomId), ref RoomId);
            serializer.Serialize(nameof(Level), ref Level);
            serializer.Serialize(nameof(GameMode), ref GameMode);
            serializer.Serialize(nameof(Hardcore), ref Hardcore);
            serializer.Serialize(nameof(Map), ref Map);
            serializer.Serialize(nameof(Running), ref Running);
            serializer.Serialize(nameof(LockedConfig), ref LockedConfig);
            serializer.Serialize(nameof(Data), ref Data);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("send_all",0xe);
//    (**(code**)(* piVar1 + 8))("server_type",4);
//    (**(code**)(* piVar1 + 8))("room_id",8);
//    (**(code**)(* piVar1 + 8))("level",4);
//    (**(code**)(* piVar1 + 8))("game_mode",4);
//    (**(code**)(* piVar1 + 8))("hardcore",4);
//    (**(code**)(* piVar1 + 8))("selection",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xab,piVar1);
    public class GetServers : PayloadPrefix // Payload171
    {
        public bool SendAll;
        public byte ServerType;
        public uint RoomId;
        public byte Level;
        public byte GameMode;
        public byte Hardcore;
        public uint Selection;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(SendAll), ref SendAll);
            serializer.Serialize(nameof(ServerType), ref ServerType);
            serializer.Serialize(nameof(RoomId), ref RoomId);
            serializer.Serialize(nameof(Level), ref Level);
            serializer.Serialize(nameof(GameMode), ref GameMode);
            serializer.Serialize(nameof(Hardcore), ref Hardcore);
            serializer.Serialize(nameof(Selection), ref Selection);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xac,piVar1);
    public class StopServerUpdates : PayloadPrefix // Payload172
    {
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xad,piVar1);
    public class Payload173 : PayloadPrefix
    {
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("ip",1,0);
//    (**(code**)(* piVar1 + 8))("port",8);
//    (**(code**)(* piVar1 + 4))("name",1,0);
//    (**(code**)(* piVar1 + 4))("username",1,0);
//    (**(code**)(* piVar1 + 4))("password",1,0);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xae,piVar1);
    public class Payload174 : PayloadPrefix
    {
        public byte[] Ip;
        public uint Port;
        public byte[] Name;
        public byte[] Username;
        public byte[] Password;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Ip), ref Ip);
            serializer.Serialize(nameof(Port), ref Port);
            serializer.Serialize(nameof(Name), ref Name);
            serializer.Serialize(nameof(Username), ref Username);
            serializer.Serialize(nameof(Password), ref Password);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("user_id",8);
//    (**(code**)(* piVar1 + 8))("send_all",0xe);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xaf,piVar1);
    public class Payload175 : PayloadPrefix
    {
        public uint UserId;
        public bool SendAll;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(UserId), ref UserId);
            serializer.Serialize(nameof(SendAll), ref SendAll);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("user_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xb0,piVar1);
    public class Payload176 : PayloadPrefix
    {
        public uint UserId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(UserId), ref UserId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("name",2,0x80);
//    (**(code**)(* piVar1 + 4))("description",2,0x80);
//    (**(code**)(* piVar1 + 4))("cipher",1,0);
//    (**(code**)(* piVar1 + 8))("max_players",6);
//    (**(code**)(* piVar1 + 8))("max_spectators",6);
//    (**(code**)(* piVar1 + 8))("ai_players",6);
//    (**(code**)(* piVar1 + 8))("room_id",8);
//    (**(code**)(* piVar1 + 8))("level",4);
//    (**(code**)(* piVar1 + 8))("game_mode",4);
//    (**(code**)(* piVar1 + 8))("hardcore",0xe);
//    (**(code**)(* piVar1 + 4))("map",2,0x80);
//    (**(code**)(* piVar1 + 8))("running",0xe);
//    (**(code**)(* piVar1 + 8))("locked_config",0xe);
//    (**(code**)(* piVar1 + 4))("data",1,0);
//    (**(code**)(* piVar1 + 8))("property_mask",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xb1,piVar1);
    public class UpdateServerInfo : PayloadPrefix // Payload177
    {
        public string Name;
        public string Description;
        public byte[] Cipher;
        public ushort MaxPlayers;
        public ushort MaxSpectators;
        public ushort AiPlayers;
        public uint RoomId;
        public byte Level;
        public byte GameMode;
        public bool Hardcore;
        public string Map;
        public bool Running;
        public bool LockedConfig;
        public byte[] Data;
        public uint PropertyMask;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Name), ref Name);
            serializer.Serialize(nameof(Description), ref Description);
            serializer.Serialize(nameof(Cipher), ref Cipher);
            serializer.Serialize(nameof(MaxPlayers), ref MaxPlayers);
            serializer.Serialize(nameof(MaxSpectators), ref MaxSpectators);
            serializer.Serialize(nameof(AiPlayers), ref AiPlayers);
            serializer.Serialize(nameof(RoomId), ref RoomId);
            serializer.Serialize(nameof(Level), ref Level);
            serializer.Serialize(nameof(GameMode), ref GameMode);
            serializer.Serialize(nameof(Hardcore), ref Hardcore);
            serializer.Serialize(nameof(Map), ref Map);
            serializer.Serialize(nameof(Running), ref Running);
            serializer.Serialize(nameof(LockedConfig), ref LockedConfig);
            serializer.Serialize(nameof(Data), ref Data);
            serializer.Serialize(nameof(PropertyMask), ref PropertyMask);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("patchlevel",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xb2,piVar1);
    public class Payload178 : PayloadPrefix
    {
        public uint Patchlevel;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Patchlevel), ref Patchlevel);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("txt",2,0x8000);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xb3,piVar1);
    public class Payload179 : PayloadPrefix
    {
        public string Txt;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Txt), ref Txt);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xb4,piVar1);
    public class Payload180 : PayloadPrefix
    {
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("starttime",2,0x20);
//    (**(code**)(* piVar1 + 8))("starttimestamp",8);
//    (**(code**)(* piVar1 + 8))("time",8);
//    (**(code**)(* piVar1 + 8))("patchlevel",8);
//    (**(code**)(* piVar1 + 4))("txt",2,0x100);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xb5,piVar1);
    public class Payload181 : PayloadPrefix
    {
        public string Starttime;
        public uint Starttimestamp;
        public uint Time;
        public uint Patchlevel;
        public string Txt;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Starttime), ref Starttime);
            serializer.Serialize(nameof(Starttimestamp), ref Starttimestamp);
            serializer.Serialize(nameof(Time), ref Time);
            serializer.Serialize(nameof(Patchlevel), ref Patchlevel);
            serializer.Serialize(nameof(Txt), ref Txt);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("uptime",8);
//    (**(code**)(* piVar1 + 8))("registered_users",8);
//    (**(code**)(* piVar1 + 8))("logins",8);
//    (**(code**)(* piVar1 + 8))("registered_gameservers",8);
//    (**(code**)(* piVar1 + 8))("started_gameservers",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xb6,piVar1);
    public class Payload182 : PayloadPrefix
    {
        public uint Uptime;
        public uint RegisteredUsers;
        public uint Logins;
        public uint RegisteredGameservers;
        public uint StartedGameservers;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Uptime), ref Uptime);
            serializer.Serialize(nameof(RegisteredUsers), ref RegisteredUsers);
            serializer.Serialize(nameof(Logins), ref Logins);
            serializer.Serialize(nameof(RegisteredGameservers), ref RegisteredGameservers);
            serializer.Serialize(nameof(StartedGameservers), ref StartedGameservers);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("level",4);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xb7,piVar1);
    public class Payload183 : PayloadPrefix
    {
        public byte Level;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Level), ref Level);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("visible",0xe);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xb8,piVar1);
    public class Payload184 : PayloadPrefix
    {
        public bool Visible;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Visible), ref Visible);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xb9,piVar1);
    public class Payload185 : PayloadPrefix
    {
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("old_group_id",8);
//    (**(code**)(* piVar1 + 8))("new_group_id",8);
//    (**(code**)(* piVar1 + 8))("user_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xba,piVar1);
    public class Payload186 : PayloadPrefix
    {
        public uint OldGroupId;
        public uint NewGroupId;
        public uint UserId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(OldGroupId), ref OldGroupId);
            serializer.Serialize(nameof(NewGroupId), ref NewGroupId);
            serializer.Serialize(nameof(UserId), ref UserId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("user_id",8);
//    (**(code**)(* piVar1 + 4))("old_cd_key",2,0x80);
//    (**(code**)(* piVar1 + 8))("old_keypool",6);
//    (**(code**)(* piVar1 + 4))("new_cd_key",2,0x80);
//    (**(code**)(* piVar1 + 8))("new_keypool",6);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xbb,piVar1);
    public class Payload187 : PayloadPrefix
    {
        public uint UserId;
        public string OldCdKey;
        public ushort OldKeypool;
        public string NewCdKey;
        public ushort NewKeypool;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(UserId), ref UserId);
            serializer.Serialize(nameof(OldCdKey), ref OldCdKey);
            serializer.Serialize(nameof(OldKeypool), ref OldKeypool);
            serializer.Serialize(nameof(NewCdKey), ref NewCdKey);
            serializer.Serialize(nameof(NewKeypool), ref NewKeypool);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("version",7);
//    (**(code**)(* piVar1 + 8))("subversion",7);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xbc,piVar1);
    public class VersionCheck : PayloadPrefix // Payload188
    {
        public short Version;
        public short Subversion;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Version), ref Version);
            serializer.Serialize(nameof(Subversion), ref Subversion);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("server_type",4);
//    (**(code**)(* piVar1 + 8))("server_subtype",4);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xbd,piVar1);
    public class GetChatServer : PayloadPrefix // Payload189
    {
        public byte ServerType;
        public byte ServerSubtype;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(ServerType), ref ServerType);
            serializer.Serialize(nameof(ServerSubtype), ref ServerSubtype);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xbe,piVar1);
    public class Payload190 : PayloadPrefix
    {
        public uint PermId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(PermId), ref PermId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("ip",2,0x80);
//    (**(code**)(* piVar1 + 8))("port",8);
//    (**(code**)(* piVar1 + 8))("max_players",6);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xbf,piVar1);
    public class Payload191 : PayloadPrefix
    {
        public string Ip;
        public uint Port;
        public ushort MaxPlayers;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Ip), ref Ip);
            serializer.Serialize(nameof(Port), ref Port);
            serializer.Serialize(nameof(MaxPlayers), ref MaxPlayers);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("server_id",8);
//    (**(code**)(* piVar1 + 4))("ip",2,0x80);
//    (**(code**)(* piVar1 + 8))("port",8);
//    (**(code**)(* piVar1 + 8))("server_type",4);
//    (**(code**)(* piVar1 + 4))("version",2,0x20);
//    (**(code**)(* piVar1 + 4))("data",1,0);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xc0,piVar1);
    public class SendChatServerInfo : PayloadPrefix // Payload192
    {
        public uint ServerId;
        public string Ip;
        public uint Port;
        public byte ServerType;
        public string Version;
        public byte[] Data;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(ServerId), ref ServerId);
            serializer.Serialize(nameof(Ip), ref Ip);
            serializer.Serialize(nameof(Port), ref Port);
            serializer.Serialize(nameof(ServerType), ref ServerType);
            serializer.Serialize(nameof(Version), ref Version);
            serializer.Serialize(nameof(Data), ref Data);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xc1,piVar1);
    public class Payload193 : PayloadPrefix
    {
        public uint PermId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(PermId), ref PermId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* piVar1 + 4))("username",2,0x20);
//    (**(code**)(* piVar1 + 8))("user_access",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xc2,piVar1);
    public class Payload194 : PayloadPrefix
    {
        public uint PermId;
        public string Username;
        public uint UserAccess;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(PermId), ref PermId);
            serializer.Serialize(nameof(Username), ref Username);
            serializer.Serialize(nameof(UserAccess), ref UserAccess);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("key",1,0);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xc9,piVar1);
    public class Login : PayloadPrefix // Payload201
    {
        public byte[] Key;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Key), ref Key);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("cipher",1,0);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xca,piVar1);
    public class LoginReply : PayloadPrefix // Payload202
    {
        public byte[] Cipher;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Cipher), ref Cipher);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("cipher",1,0);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xcb,piVar1);
    public class RegisterUser : PayloadPrefix // Payload203
    {
        public byte[] Cipher;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Cipher), ref Cipher);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("cipher",1,0);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xcc,piVar1);
    public class LoginUser : PayloadPrefix // Payload204
    {
        public byte[] Cipher;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Cipher), ref Cipher);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("cipher",1,0);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xcd,piVar1);
    public class Payload205 : PayloadPrefix
    {
        public byte[] Cipher;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Cipher), ref Cipher);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("cipher",1,0);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xce,piVar1);
    public class LoginServer : PayloadPrefix // Payload206
    {
        public byte[] Cipher;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Cipher), ref Cipher);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* piVar1 + 4))("cipher",1,0);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xcf,piVar1);
    public class LoginReplyCipher : PayloadPrefix // Payload207
    {
        public uint PermId;
        public byte[] Cipher;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(PermId), ref PermId);
            serializer.Serialize(nameof(Cipher), ref Cipher);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xd3,piVar1);
    public class LoginChat : PayloadPrefix // Payload211
    {
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("nonce",1,0);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xd4,piVar1);
    public class LoginChatReply : PayloadPrefix // Payload212
    {
        public byte[] Nonce;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Nonce), ref Nonce);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* piVar1 + 4))("cipher",1,0);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xd5,piVar1);
    public class VerifyChatLogin : PayloadPrefix // Payload213
    {
        public uint PermId;
        public byte[] Cipher;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(PermId), ref PermId);
            serializer.Serialize(nameof(Cipher), ref Cipher);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* piVar1 + 4))("cipher",1,0);
//    (**(code**)(* piVar1 + 4))("nonce",1,0);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xd6,piVar1);
    public class Payload214 : PayloadPrefix
    {
        public uint PermId;
        public byte[] Cipher;
        public byte[] Nonce;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(PermId), ref PermId);
            serializer.Serialize(nameof(Cipher), ref Cipher);
            serializer.Serialize(nameof(Nonce), ref Nonce);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* piVar1 + 8))("server_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xdd,piVar1);
    public class ConnectToServer : PayloadPrefix // Payload221
    {
        public uint PermId;
        public uint ServerId;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(PermId), ref PermId);
            serializer.Serialize(nameof(ServerId), ref ServerId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* piVar1 + 8))("server_id",8);
//    (**(code**)(* piVar1 + 4))("ip",2,0x80);
//    (**(code**)(* piVar1 + 8))("port",8);
//    (**(code**)(* piVar1 + 4))("nonce",1,0);
//    (**(code**)(* piVar1 + 8))("errorcode",4);
//    (**(code**)(* piVar1 + 4))("errormsg",2,0x20);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xde,piVar1);
    public class ConnectToServerReply : PayloadPrefix // Payload222
    {
        public uint PermId;
        public uint ServerId;
        public string Ip;
        public uint Port;
        public byte[] Nonce;
        public byte Errorcode;
        public string Errormsg;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(PermId), ref PermId);
            serializer.Serialize(nameof(ServerId), ref ServerId);
            serializer.Serialize(nameof(Ip), ref Ip);
            serializer.Serialize(nameof(Port), ref Port);
            serializer.Serialize(nameof(Nonce), ref Nonce);
            serializer.Serialize(nameof(Errorcode), ref Errorcode);
            serializer.Serialize(nameof(Errormsg), ref Errormsg);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("nonce",1,0);
//    (**(code**)(* piVar1 + 8))("char_id",8);
//    (**(code**)(* piVar1 + 4))("name",2,0x80);
//    (**(code**)(* piVar1 + 8))("owner_id",8);
//    (**(code**)(* piVar1 + 4))("owner_name",2,0x80);
//    (**(code**)(* piVar1 + 8))("guild_id",8);
//    (**(code**)(* piVar1 + 4))("guild_name",2,0x80);
//    (**(code**)(* piVar1 + 8))("guild_role",4);
//    (**(code**)(* piVar1 + 4))("data",1,0);
//    (**(code**)(* unaff_EDI + 4))(0xdf,piVar1);
    public class PlayerConnecting : PayloadPrefix // Payload223
    {
        public byte[] Nonce;
        public uint CharId;
        public string Name;
        public uint OwnerId;
        public string OwnerName;
        public uint GuildId;
        public string GuildName;
        public byte GuildRole;
        public byte[] Data;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Nonce), ref Nonce);
            serializer.Serialize(nameof(CharId), ref CharId);
            serializer.Serialize(nameof(Name), ref Name);
            serializer.Serialize(nameof(OwnerId), ref OwnerId);
            serializer.Serialize(nameof(OwnerName), ref OwnerName);
            serializer.Serialize(nameof(GuildId), ref GuildId);
            serializer.Serialize(nameof(GuildName), ref GuildName);
            serializer.Serialize(nameof(GuildRole), ref GuildRole);
            serializer.Serialize(nameof(Data), ref Data);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* piVar1 + 4))("nonce",1,0);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* piVar1 + 4))("password",1,0);
//    (**(code**)(* unaff_EDI + 4))(0xe0,piVar1);
    public class Payload224 : PayloadPrefix
    {
        public uint PermId;
        public byte[] Nonce;
        public uint TicketId;
        public byte[] Password;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(PermId), ref PermId);
            serializer.Serialize(nameof(Nonce), ref Nonce);
            serializer.Serialize(nameof(TicketId), ref TicketId);
            serializer.Serialize(nameof(Password), ref Password);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("from_id",8);
//    (**(code**)(* piVar1 + 8))("cell_id",8);
//    (**(code**)(* piVar1 + 4))("message_text",1,0);
//    (**(code**)(* piVar1 + 8))("status",4);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xf0,piVar1);
    public class Payload240 : PayloadPrefix
    {
        public uint FromId;
        public uint CellId;
        public byte[] MessageText;
        public byte Status;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(FromId), ref FromId);
            serializer.Serialize(nameof(CellId), ref CellId);
            serializer.Serialize(nameof(MessageText), ref MessageText);
            serializer.Serialize(nameof(Status), ref Status);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("from_id",8);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* piVar1 + 4))("message_text",1,0);
//    (**(code**)(* piVar1 + 8))("status",4);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xf1,piVar1);
    public class Payload241 : PayloadPrefix
    {
        public uint FromId;
        public uint PermId;
        public byte[] MessageText;
        public byte Status;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(FromId), ref FromId);
            serializer.Serialize(nameof(PermId), ref PermId);
            serializer.Serialize(nameof(MessageText), ref MessageText);
            serializer.Serialize(nameof(Status), ref Status);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("from_id",8);
//    (**(code**)(* piVar1 + 4))("name",2,0x80);
//    (**(code**)(* piVar1 + 8))("password_required",0xe);
//    (**(code**)(* piVar1 + 4))("password",2,0x20);
//    (**(code**)(* piVar1 + 8))("status",4);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xf2,piVar1);
    public class Payload242 : PayloadPrefix
    {
        public uint FromId;
        public string Name;
        public bool PasswordRequired;
        public string Password;
        public byte Status;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(FromId), ref FromId);
            serializer.Serialize(nameof(Name), ref Name);
            serializer.Serialize(nameof(PasswordRequired), ref PasswordRequired);
            serializer.Serialize(nameof(Password), ref Password);
            serializer.Serialize(nameof(Status), ref Status);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("from_id",8);
//    (**(code**)(* piVar1 + 8))("id",8);
//    (**(code**)(* piVar1 + 4))("name",2,0x80);
//    (**(code**)(* piVar1 + 8))("password_required",0xe);
//    (**(code**)(* piVar1 + 4))("password",2,0x20);
//    (**(code**)(* piVar1 + 8))("status",4);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xf3,piVar1);
    public class Payload243 : PayloadPrefix
    {
        public uint FromId;
        public uint Id;
        public string Name;
        public bool PasswordRequired;
        public string Password;
        public byte Status;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(FromId), ref FromId);
            serializer.Serialize(nameof(Id), ref Id);
            serializer.Serialize(nameof(Name), ref Name);
            serializer.Serialize(nameof(PasswordRequired), ref PasswordRequired);
            serializer.Serialize(nameof(Password), ref Password);
            serializer.Serialize(nameof(Status), ref Status);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("from_id",8);
//    (**(code**)(* piVar1 + 8))("id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xf4,piVar1);
    public class Payload244 : PayloadPrefix
    {
        public uint FromId;
        public uint Id;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(FromId), ref FromId);
            serializer.Serialize(nameof(Id), ref Id);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("from_id",8);
//    (**(code**)(* piVar1 + 8))("id",8);
//    (**(code**)(* piVar1 + 4))("password",2,0x20);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xf5,piVar1);
    public class Payload245 : PayloadPrefix
    {
        public uint FromId;
        public uint Id;
        public string Password;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(FromId), ref FromId);
            serializer.Serialize(nameof(Id), ref Id);
            serializer.Serialize(nameof(Password), ref Password);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("from_id",8);
//    (**(code**)(* piVar1 + 8))("id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xf6,piVar1);
    public class Payload246 : PayloadPrefix
    {
        public uint FromId;
        public uint Id;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(FromId), ref FromId);
            serializer.Serialize(nameof(Id), ref Id);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* piVar1 + 8))("id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xf7,piVar1);
    public class Payload247 : PayloadPrefix
    {
        public uint PermId;
        public uint Id;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(PermId), ref PermId);
            serializer.Serialize(nameof(Id), ref Id);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* piVar1 + 8))("id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xf8,piVar1);
    public class Payload248 : PayloadPrefix
    {
        public uint PermId;
        public uint Id;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(PermId), ref PermId);
            serializer.Serialize(nameof(Id), ref Id);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("from_id",8);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* piVar1 + 8))("id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xf9,piVar1);
    public class Payload249 : PayloadPrefix
    {
        public uint FromId;
        public uint PermId;
        public uint Id;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(FromId), ref FromId);
            serializer.Serialize(nameof(PermId), ref PermId);
            serializer.Serialize(nameof(Id), ref Id);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* piVar1 + 8))("id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xfa,piVar1);
    public class Payload250 : PayloadPrefix
    {
        public uint PermId;
        public uint Id;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(PermId), ref PermId);
            serializer.Serialize(nameof(Id), ref Id);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* piVar1 + 4))("nick",2,0x100);
//    (**(code**)(* piVar1 + 8))("user_access",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xfb,piVar1);
    public class Payload251 : PayloadPrefix
    {
        public uint PermId;
        public string Nick;
        public uint UserAccess;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(PermId), ref PermId);
            serializer.Serialize(nameof(Nick), ref Nick);
            serializer.Serialize(nameof(UserAccess), ref UserAccess);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("perm_id_a",8);
//    (**(code**)(* piVar1 + 8))("perm_id_b",8);
//    (**(code**)(* piVar1 + 8))("result",6);
//    (**(code**)(* piVar1 + 8))("map_id",8);
//    (**(code**)(* piVar1 + 8))("custom_1",8);
//    (**(code**)(* piVar1 + 8))("custom_2",8);
//    (**(code**)(* unaff_EDI + 4))(0xfc,piVar1);
    public class Payload252 : PayloadPrefix
    {
        public uint PermIdA;
        public uint PermIdB;
        public ushort Result;
        public uint MapId;
        public uint Custom1;
        public uint Custom2;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(PermIdA), ref PermIdA);
            serializer.Serialize(nameof(PermIdB), ref PermIdB);
            serializer.Serialize(nameof(Result), ref Result);
            serializer.Serialize(nameof(MapId), ref MapId);
            serializer.Serialize(nameof(Custom1), ref Custom1);
            serializer.Serialize(nameof(Custom2), ref Custom2);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("perm_id_a",8);
//    (**(code**)(* piVar1 + 8))("perm_id_b",8);
//    (**(code**)(* piVar1 + 8))("result_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xfd,piVar1);
    public class Payload253 : PayloadPrefix
    {
        public uint PermIdA;
        public uint PermIdB;
        public uint ResultId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(PermIdA), ref PermIdA);
            serializer.Serialize(nameof(PermIdB), ref PermIdB);
            serializer.Serialize(nameof(ResultId), ref ResultId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("ranktable",6);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* unaff_EDI + 4))(0xfe,piVar1);
    public class Payload254 : PayloadPrefix
    {
        public ushort Ranktable;
        public uint PermId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Ranktable), ref Ranktable);
            serializer.Serialize(nameof(PermId), ref PermId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("ranktable",6);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* piVar1 + 4))("nick",2,0x100);
//    (**(code**)(* piVar1 + 8))("rank",8);
//    (**(code**)(* piVar1 + 8))("points",8);
//    (**(code**)(* piVar1 + 8))("played",8);
//    (**(code**)(* piVar1 + 8))("won",8);
//    (**(code**)(* piVar1 + 8))("lost",8);
//    (**(code**)(* piVar1 + 8))("tie",8);
//    (**(code**)(* piVar1 + 8))("disconnected",8);
//    (**(code**)(* unaff_EDI + 4))(0xff,piVar1);
    public class Payload255 : PayloadPrefix
    {
        public ushort Ranktable;
        public uint PermId;
        public string Nick;
        public uint Rank;
        public uint Points;
        public uint Played;
        public uint Won;
        public uint Lost;
        public uint Tie;
        public uint Disconnected;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Ranktable), ref Ranktable);
            serializer.Serialize(nameof(PermId), ref PermId);
            serializer.Serialize(nameof(Nick), ref Nick);
            serializer.Serialize(nameof(Rank), ref Rank);
            serializer.Serialize(nameof(Points), ref Points);
            serializer.Serialize(nameof(Played), ref Played);
            serializer.Serialize(nameof(Won), ref Won);
            serializer.Serialize(nameof(Lost), ref Lost);
            serializer.Serialize(nameof(Tie), ref Tie);
            serializer.Serialize(nameof(Disconnected), ref Disconnected);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("ranktable",6);
//    (**(code**)(* piVar1 + 8))("rangestart",8);
//    (**(code**)(* piVar1 + 8))("rangeend",8);
//    (**(code**)(* unaff_EDI + 4))(0x100,piVar1);
    public class Payload256 : PayloadPrefix
    {
        public ushort Ranktable;
        public uint Rangestart;
        public uint Rangeend;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Ranktable), ref Ranktable);
            serializer.Serialize(nameof(Rangestart), ref Rangestart);
            serializer.Serialize(nameof(Rangeend), ref Rangeend);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("ranktable",6);
//    (**(code**)(* piVar1 + 8))("rangestart",8);
//    (**(code**)(* piVar1 + 8))("rangeend",8);
//    (**(code**)(* piVar1 + 8))("count",8);
//    (**(code**)(* piVar1 + 4))("rankdata",1,0);
//    (**(code**)(* unaff_EDI + 4))(0x101,piVar1);
    public class Payload257 : PayloadPrefix
    {
        public ushort Ranktable;
        public uint Rangestart;
        public uint Rangeend;
        public uint Count;
        public byte[] Rankdata;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Ranktable), ref Ranktable);
            serializer.Serialize(nameof(Rangestart), ref Rangestart);
            serializer.Serialize(nameof(Rangeend), ref Rangeend);
            serializer.Serialize(nameof(Count), ref Count);
            serializer.Serialize(nameof(Rankdata), ref Rankdata);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 4))("ip",2,0x80);
//    (**(code**)(* piVar1 + 8))("port",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x102,piVar1);
    public class Payload258 : PayloadPrefix
    {
        public string Ip;
        public uint Port;
        public uint TicketId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Ip), ref Ip);
            serializer.Serialize(nameof(Port), ref Port);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("cell_id",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* piVar1 + 8))("from_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x103,piVar1);
    public class Payload259 : PayloadPrefix
    {
        public uint CellId;
        public uint TicketId;
        public uint FromId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(CellId), ref CellId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
            serializer.Serialize(nameof(FromId), ref FromId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* piVar1 + 8))("connection_pid",8);
//    (**(code**)(* piVar1 + 8))("user_pid",8);
//    (**(code**)(* unaff_EDI + 4))(0x104,piVar1);
    public class Payload260 : PayloadPrefix
    {
        public uint TicketId;
        public uint ConnectionPid;
        public uint UserPid;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(TicketId), ref TicketId);
            serializer.Serialize(nameof(ConnectionPid), ref ConnectionPid);
            serializer.Serialize(nameof(UserPid), ref UserPid);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("perm_id",8);
//    (**(code**)(* piVar1 + 4))("username",2,0x20);
//    (**(code**)(* piVar1 + 8))("user_access",8);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* piVar1 + 8))("result_id",8);
//    (**(code**)(* unaff_EDI + 4))(0x105,piVar1);
    public class Payload261 : PayloadPrefix
    {
        public uint PermId;
        public string Username;
        public uint UserAccess;
        public uint TicketId;
        public uint ResultId;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(PermId), ref PermId);
            serializer.Serialize(nameof(Username), ref Username);
            serializer.Serialize(nameof(UserAccess), ref UserAccess);
            serializer.Serialize(nameof(TicketId), ref TicketId);
            serializer.Serialize(nameof(ResultId), ref ResultId);
        }
    }

//    (**(code**)(* piVar1 + 0x14))();
//    (**(code**)(* piVar1 + 8))("type",6);
//    (**(code**)(* piVar1 + 8))("ticket_id",8);
//    (**(code**)(* piVar1 + 4))("name",2,0x40);
//    (**(code**)(* unaff_EDI + 4))(0x106,piVar1);
    public class Payload262 : PayloadPrefix
    {
        public uint TicketId;
        public string Name;

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(TicketId), ref TicketId);
            serializer.Serialize(nameof(Name), ref Name);
        }
    }
}
