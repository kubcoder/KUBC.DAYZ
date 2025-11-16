using KUBC.DAYZ.Logging.ADM;
using KUBC.DAYZ.Logging.ADM.Builders;
using KUBC.DAYZ.Logging.Events;
using Xunit.Abstractions;

namespace KUBC.DAYZ.Logging;

public class ADMTest(ITestOutputHelper output) : TestWithSample(output)
{

    [Fact]
    public void EmoteTest()
    {
        var builder = new EmoteBuilder();
        var text = "Player \"Axperrr223\" (id=0TIrcPPAC6Ca1UHXh1d1CgV3komVDGOICmT6wXL7tCU= pos=<1266.1, 8905.5, 281.3>) performed EmoteSitA";
        var gameEvent = builder.Build(DateTime.UtcNow, text);
        Assert.IsType<Emote>(gameEvent);
        Emote emoteEvent = (Emote)gameEvent;
        Assert.Equal("Axperrr223", emoteEvent.NickName);
        Assert.True(emoteEvent.IsAlive);
        Assert.Equal("0TIrcPPAC6Ca1UHXh1d1CgV3komVDGOICmT6wXL7tCU=", emoteEvent.Id);
        Assert.Equal(1266.1, emoteEvent.Position.X);
        Assert.Equal(8905.5, emoteEvent.Position.Y);
        Assert.Equal(281.3, emoteEvent.Position.Z);
        Assert.Equal("EmoteSitA", emoteEvent.Action);
        text = "Player \"Altai_48\" (id=71bKIjZIjXME4VuQD6S63KpUw6N1MUCLu1mC6Ja4phU= pos=<11930.6, 9073.4, 58.0>) performed EmoteSitA with MakarovIJ70";
        gameEvent = builder.Build(DateTime.UtcNow, text);
        Assert.IsNotType<Emote>(gameEvent);
    }

    [Fact]
    public void Respawn()
    {
        var text = "Player \"Survivor\" (DEAD) (id=Jj_yBfOdf9XWvmwCMnmoU2xrWBQXIIc5YHWdgyNEBtc= pos=<12693.6, 9790.4, 6.0>) is choosing to respawn";
        var builder = new PlayerChoosingRespawnBuilder();
        var gameEvent = builder.Build(DateTime.UtcNow, text) as PlayerChoosingRespawn;
        Assert.NotNull(gameEvent);
        Assert.Equal("Survivor", gameEvent.NickName);
        Assert.False(gameEvent.IsAlive);
        Assert.Equal("Jj_yBfOdf9XWvmwCMnmoU2xrWBQXIIc5YHWdgyNEBtc=", gameEvent.Id);
        Assert.Equal(12693.6, gameEvent.Position.X);
        Assert.Equal(9790.4, gameEvent.Position.Y);
        Assert.Equal(6.0, gameEvent.Position.Z);
    }



    [Fact]
    public void TestPlayerCouns()
    {
        var logLine = "##### PlayerList log: 1 players";
        var builder = new AveragePlayerCountBuilder();
        var playerCount = builder.Build(DateTime.UtcNow, logLine);
        Assert.NotNull(playerCount);
    }

    [Fact]
    public void ConnectPlayer()
    {
        var builder = new PlayerConnectedBuilder();
        var gameEvent = builder.Build(DateTime.UtcNow, connectString);
        Assert.NotNull(gameEvent);
        Assert.IsType<PlayerConnected>(gameEvent);
        var connectEvent = (PlayerConnected)gameEvent;
        Assert.Equal("kot23rus", connectEvent.NickName);
        Assert.Equal("B1idL_7H1auUS5DPBOEDcTFQ3EBBrzFLa8r1GGmv7GA=", connectEvent.Id);
        gameEvent = builder.Build(DateTime.UtcNow, disconnectString);
        Assert.Null(gameEvent);
        gameEvent = builder.Build(DateTime.UtcNow, connectString129);
        Assert.Null(gameEvent);
    }
    private const string connectString = "Player \"kot23rus\" (id=B1idL_7H1auUS5DPBOEDcTFQ3EBBrzFLa8r1GGmv7GA=) is connecting";
    private const string connectString129 = "Player \"kot23rus\" (id=B1idL_7H1auUS5DPBOEDcTFQ3EBBrzFLa8r1GGmv7GA= pos=<13369.0, 6610.0, 4.7>) is connected";
    private const string disconnectString = "Player \"kot23rus\"(id=B1idL_7H1auUS5DPBOEDcTFQ3EBBrzFLa8r1GGmv7GA=) has been disconnected";

    [Fact]
    public void DisconnectPlayer()
    {
        var builder = new PlayerDisconnectedBuilder();
        var gameEvent = builder.Build(DateTime.UtcNow, disconnectString);
        Assert.NotNull(gameEvent);
        Assert.IsType<PlayerDisconnected>(gameEvent);
        var connectEvent = (PlayerDisconnected)gameEvent;
        Assert.Equal("kot23rus", connectEvent.NickName);
        Assert.Equal("B1idL_7H1auUS5DPBOEDcTFQ3EBBrzFLa8r1GGmv7GA=", connectEvent.Id);
        gameEvent = builder.Build(DateTime.UtcNow, connectString);
        Assert.Null(gameEvent);
    }

    [Fact]
    public void PlayerEventPosition()
    {
        var text = "Player \"Survivor\" (id=SW_iEQBF_5tYblHcT1KmAtEHh8vQY7baVfNVAF4wqSk= pos=<9479.7, 13344.6, 16.7>)";
        var builder = new PlayerEventPositionBuilder<PlayerEventPosition>();
        var gameEvent = builder.Build(DateTime.UtcNow, text);
        Assert.NotNull(gameEvent);
        Assert.IsType<PlayerEventPosition>(gameEvent);
        var posEvent = (PlayerEventPosition)gameEvent;
        Assert.True(posEvent.IsAlive);
        text = "Player \"[EXP]Diamond\" (id=yZrTDnQZ1pImWZkq5MYc3NIJtWlT1JQP7gGWYz3hOb8= pos=<6344.8, 7811.6, 304.9>)[HP: 65.0485] hit by Зараженный into LeftArm(18) for 9.35 damage (MeleeSoldierInfectedLong)";
        gameEvent = builder.Build(DateTime.UtcNow, text);
        Assert.NotNull(gameEvent);
        text = "Player \"BANDIT_EKB\" (DEAD) (id=IlWOr_LRrhS0y5s0IgiFForEiOaiY0AXXjHjKoMtBZE= pos=<11682.7, 13046, 8.5>)[HP: 0] hit by explosion (M67Grenade_Ammo)";
        gameEvent = builder.Build(DateTime.UtcNow, text);
        Assert.NotNull(gameEvent);
        Assert.IsType<PlayerEventPosition>(gameEvent);
        posEvent = (PlayerEventPosition)gameEvent;
        Assert.False(posEvent.IsAlive);
    }

    [Fact]
    public void UncDisconect()
    {
        var text = "Player \"Survivor\" (id=xuvIU7VjYLDJGJLaMeNFQJf18YoUwfLTnpQvOdvQxI4= pos=<11977.4, 3507.8, 6.5>) is disconnecting while being unconscious";
        var builder = new UnconsciousDisconectBuilder();
        var gameEvent = builder.Build(DateTime.UtcNow, text);
        Assert.NotNull(gameEvent);
        Assert.IsType<UnconsciousDisconect>(gameEvent);
    }

    [Fact]
    public void Chat()
    {
        var text = "Chat(\"DZhamaL\"(id=vm3TiXvjAHjN2bxS2BZghHvF-sPYbxGh1RUWjg5TIJo=)): ливония нашол собрал загнал спасибо ))";
        var builder = new ChatBuilder();
        var gameEvent = builder.Build(DateTime.UtcNow, text);
        Assert.NotNull(gameEvent);
        Assert.IsType<Chat>(gameEvent);
    }

    [Fact]
    public void BledOut()
    {
        var text = "Player \"Survivor\" (DEAD) (id=icPUuClkrueU8TYBPtdsbwVyhXGdMOC2FGQpfinCAQg= pos=<11930.3, 3483.3, 6.3>) bled out";
        var builder = new BledOutBuilder();
        var gameEvent = builder.Build(DateTime.UtcNow, text);
        Assert.NotNull(gameEvent);
        Assert.IsType<BledOut>(gameEvent);
        text = "Player \"Survivor\" (id=xuvIU7VjYLDJGJLaMeNFQJf18YoUwfLTnpQvOdvQxI4= pos=<11977.4, 3507.8, 6.5>) is disconnecting while being unconscious";
        gameEvent = builder.Build(DateTime.UtcNow, text);
        Assert.Null(gameEvent);
    }

    [Fact]
    public void Built()
    {
        var text = "Player \"punginpetr\" (id=WnfMLGudpaimhOyI3sMsczcFvCn1T2UV39tfRJn_qEw= pos=<7746.6, 5147.4, 214.7>)Built base on Флагшток with Кувалда";
        var builder = new BuiltBuilder();
        var gameEvent = builder.Build(DateTime.UtcNow, text);
        Assert.NotNull(gameEvent);
        Assert.IsType<Built>(gameEvent);
        var builtEvent = (Built)gameEvent;
        Assert.Equal("punginpetr", builtEvent.NickName);
        Assert.Equal("base", builtEvent.Element);
        Assert.Equal("Флагшток", builtEvent.Construction);
        Assert.Equal("Кувалда", builtEvent.Tool);
        text = "Player \"Survivor\" (id=xuvIU7VjYLDJGJLaMeNFQJf18YoUwfLTnpQvOdvQxI4= pos=<11977.4, 3507.8, 6.5>) is disconnecting while being unconscious";
        gameEvent = builder.Build(DateTime.UtcNow, text);
        Assert.Null(gameEvent);
    }

    [Fact]
    public void Dismantled()
    {
        var text = "Player \"Zorro\" (id=OxjFoUFrQmU2hecaqJd6RRxgtqhaTMg_jZY_lHiGh8s= pos=<3442.7, 12323.7, 239.4>)Dismantled Нижняя деревянная стена from Ворота with Топорик";
        var builder = new DismantledBuilder();
        var gameEvent = builder.Build(DateTime.UtcNow, text);
        Assert.NotNull(gameEvent);
        Assert.IsType<Dismantled>(gameEvent);
        var builtEvent = (Dismantled)gameEvent;
        Assert.Equal("Zorro", builtEvent.NickName);
        Assert.Equal("Нижняя деревянная стена", builtEvent.Element);
        Assert.Equal("Ворота", builtEvent.Construction);
        Assert.Equal("Топорик", builtEvent.Tool);
        text = "Player \"Survivor\" (id=xuvIU7VjYLDJGJLaMeNFQJf18YoUwfLTnpQvOdvQxI4= pos=<11977.4, 3507.8, 6.5>) is disconnecting while being unconscious";
        gameEvent = builder.Build(DateTime.UtcNow, text);
        Assert.Null(gameEvent);
        text = "Player \"punginpetr\" (id=WnfMLGudpaimhOyI3sMsczcFvCn1T2UV39tfRJn_qEw= pos=<7746.6, 5147.4, 214.7>)Built base on Флагшток with Кувалда";
        gameEvent = builder.Build(DateTime.UtcNow, text);
        Assert.Null(gameEvent);
    }
    [Fact]
    public void Folded()
    {
        var text = "Player \"kot23rus\" (id=B1idL_7H1auUS5DPBOEDcTFQ3EBBrzFLa8r1GGmv7GA= pos=<12758.4, 9841.8, 6.0>) folded Сторожевая башня";
        var builder = new FoldedBuilder();
        var gameEvent = builder.Build(DateTime.UtcNow, text);
        Assert.NotNull(gameEvent);
        Assert.IsType<Folded>(gameEvent);
        var builtEvent = (Folded)gameEvent;
        Assert.Equal("Сторожевая башня", builtEvent.ItemName);
        text = "Player \"kot23rus\" (id=B1idL_7H1auUS5DPBOEDcTFQ3EBBrzFLa8r1GGmv7GA= pos=<12763.1, 9846.0, 6.0>) packed Средняя палатка with Hands ";
        gameEvent = builder.Build(DateTime.UtcNow, text);
        Assert.Null(gameEvent);
        text = "Player \"punginpetr\" (id=WnfMLGudpaimhOyI3sMsczcFvCn1T2UV39tfRJn_qEw= pos=<7746.6, 5147.4, 214.7>)Built base on Флагшток with Кувалда";
        gameEvent = builder.Build(DateTime.UtcNow, text);
        Assert.Null(gameEvent);
    }

    [Fact]
    public void Packed()
    {
        var text = "Player \"kot23rus\" (id=B1idL_7H1auUS5DPBOEDcTFQ3EBBrzFLa8r1GGmv7GA= pos=<12763.1, 9846.0, 6.0>) packed Средняя палатка with Hands ";
        var builder = new PackedBuilder();
        var gameEvent = builder.Build(DateTime.UtcNow, text);
        Assert.NotNull(gameEvent);
        Assert.IsType<Packed>(gameEvent);
        var builtEvent = (Packed)gameEvent;
        Assert.Equal("Средняя палатка", builtEvent.ItemName);
        text = "Player \"Survivor\" (id=xuvIU7VjYLDJGJLaMeNFQJf18YoUwfLTnpQvOdvQxI4= pos=<11977.4, 3507.8, 6.5>) is disconnecting while being unconscious";
        gameEvent = builder.Build(DateTime.UtcNow, text);
        Assert.Null(gameEvent);
        text = "Player \"punginpetr\" (id=WnfMLGudpaimhOyI3sMsczcFvCn1T2UV39tfRJn_qEw= pos=<7746.6, 5147.4, 214.7>)Built base on Флагшток with Кувалда";
        gameEvent = builder.Build(DateTime.UtcNow, text);
        Assert.Null(gameEvent);
    }

    [Fact]
    public void Placed()
    {
        var text = "Player \"kot23rus\" (id=B1idL_7H1auUS5DPBOEDcTFQ3EBBrzFLa8r1GGmv7GA= pos=<12757.5, 9842.5, 6.0>) placed Противопехотная мина<LandMineTrap>";
        var builder = new PlacedBuilder();
        var gameEvent = builder.Build(DateTime.UtcNow, text);
        Assert.NotNull(gameEvent);
        Assert.IsType<Placed>(gameEvent);
        var builtEvent = (Placed)gameEvent;
        Assert.Equal("Противопехотная мина", builtEvent.ItemName);
        Assert.Equal("LandMineTrap", builtEvent.ClassName);

    }
    [Fact]
    public void DugIn()
    {
        var text = "Player \"kot23rus\" (id=B1idL_7H1auUS5DPBOEDcTFQ3EBBrzFLa8r1GGmv7GA= pos=<271.3, 798.5, 560.0>)Player SurvivorBase<5f3d7020> Dug in SeaChest<fd1db930> at position 0x000000006f8c82e0 {<270.87,559.957,797.327>}";
        var builder = new DugInBuilder();
        var gameEvent = builder.Build(DateTime.UtcNow, text);
        Assert.NotNull(gameEvent);
        Assert.IsType<DugIn>(gameEvent);
        var builtEvent = (DugIn)gameEvent;
        Assert.Equal("SeaChest", builtEvent.ItemName);
        Assert.Equal(270.87, builtEvent.ItemPosition.X);
        Assert.Equal(559.957, builtEvent.ItemPosition.Y);
        Assert.Equal(797.327, builtEvent.ItemPosition.Z);

    }

    [Fact]
    public void DugOut()
    {
        var text = "Player \"(Admin) Berserk\" (id=B1idL_7H1auUS5DPBOEDcTFQ3EBBrzFLa8r1GGmv7GA= pos=<271.3, 798.5, 560.0>)Player SurvivorBase<5f3d7020> Dug out UndergroundStash<ff33bfe0> at position 0x000000006f8c82e0 {<270.87,560.177,797.327>}";
        var builder = new DugOutBuilder();
        var gameEvent = builder.Build(DateTime.UtcNow, text);
        Assert.NotNull(gameEvent);
        Assert.IsType<DugOut>(gameEvent);
        var builtEvent = (DugOut)gameEvent;
        Assert.Equal("UndergroundStash", builtEvent.ItemName);
        Assert.Equal(270.87, builtEvent.ItemPosition.X);
        Assert.Equal(560.177, builtEvent.ItemPosition.Y);
        Assert.Equal(797.327, builtEvent.ItemPosition.Z);

    }
    [Fact]
    public void Lowered()
    {
        var text = "Player \"Supra\" (id=qIqoyjue0nVGmVCatbhB3gv6w27IKICKnHSvM1uDEAQ= pos=<3198.2, 5192.3, 256.2>) has lowered Flag_Pirates on TerritoryFlag at <3198.311279, 255.721802, 5191.358887>";
        var builder = new LoweredBuilder();
        var gameEvent = builder.Build(DateTime.UtcNow, text);
        Assert.NotNull(gameEvent);
        Assert.IsType<Lowered>(gameEvent);
        var builtEvent = (Lowered)gameEvent;
        Assert.Equal("Flag_Pirates", builtEvent.ItemName);
        Assert.Equal(3198.311279, builtEvent.ItemPosition.X);
        Assert.Equal(255.721802, builtEvent.ItemPosition.Y);
        Assert.Equal(5191.358887, builtEvent.ItemPosition.Z);

    }
    [Fact]
    public void Raised()
    {
        var text = "Player \"lazer123\" (id=FYQJ22JTqalJJEyMmXQi8eaV3BtiWHKL8w41dxhPurY= pos=<2485.3, 5293.3, 190.6>) has raised Flag_CDF on TerritoryFlag at <2484.922363, 190.109573, 5292.324707>";
        var builder = new RaisedBuilder();
        var gameEvent = builder.Build(DateTime.UtcNow, text);
        Assert.NotNull(gameEvent);
        Assert.IsType<Raised>(gameEvent);
        var builtEvent = (Raised)gameEvent;
        Assert.Equal("Flag_CDF", builtEvent.ItemName);
        Assert.Equal(2484.922363, builtEvent.ItemPosition.X);
        Assert.Equal(190.109573, builtEvent.ItemPosition.Y);
        Assert.Equal(5292.324707, builtEvent.ItemPosition.Z);

    }

    [Fact]
    public void Mounted()
    {
        var text = "Player \"BANDIT_EKB\" (id=IlWOr_LRrhS0y5s0IgiFForEiOaiY0AXXjHjKoMtBZE= pos=<4376.8, 4598.8, 232.0>)Player SurvivorBase<435816a0> Mounted BarbedWire on Fence";
        var builder = new MountedBuilder();
        var gameEvent = builder.Build(DateTime.UtcNow, text);
        Assert.NotNull(gameEvent);
        Assert.IsType<Mounted>(gameEvent);
        var builtEvent = (Mounted)gameEvent;
        Assert.Equal("BarbedWire", builtEvent.ItemName);
        Assert.Equal("Fence", builtEvent.Construction);

    }

    [Fact]
    public void Unmounted()
    {
        var text = "Player \"Axperrr223\" (id=0TIrcPPAC6Ca1UHXh1d1CgV3komVDGOICmT6wXL7tCU= pos=<1266.3, 8888.9, 282.1>)Player SurvivorBase<a5fef010> Unmounted BarbedWire from Watchtower";
        var builder = new UnmountedBuilder();
        var gameEvent = builder.Build(DateTime.UtcNow, text);
        Assert.NotNull(gameEvent);
        Assert.IsType<Unmounted>(gameEvent);
        var builtEvent = (Unmounted)gameEvent;
        Assert.Equal("BarbedWire", builtEvent.ItemName);
        Assert.Equal("Watchtower", builtEvent.Construction);

    }
    [Fact]
    public void Regained()
    {
        var text = "Player \"Copperfield\" (id=wj6FJIlkPjCTXW9Hw3MkePiK45icYvWC15Ip1okVqwA= pos=<7930.0, 14625.4, 338.5>) regained consciousness";
        var builder = new RegainedBuilder();
        var gameEvent = builder.Build(DateTime.UtcNow, text);
        Assert.NotNull(gameEvent);
        Assert.IsType<Regained>(gameEvent);
        var posEvent = (Regained)gameEvent;
        Assert.True(posEvent.IsAlive);
        Assert.Equal("Copperfield", posEvent.NickName);
        Assert.Equal("wj6FJIlkPjCTXW9Hw3MkePiK45icYvWC15Ip1okVqwA=", posEvent.Id);
        Assert.Equal(7930.0, posEvent.Position.X);
        Assert.Equal(14625.4, posEvent.Position.Y);
        Assert.Equal(338.5, posEvent.Position.Z);
    }

    [Fact]
    public void Unconscious()
    {
        var text = "Player \"AID_KRD_ 23\" (id=i9GYz9yZfMopo-hFqbKfu3UN75Y1XExz53ZO8z4vJzc= pos=<13180.9, 7071.4, 6.0>) is unconscious";
        var builder = new UnconsciousBuilder();
        var gameEvent = builder.Build(DateTime.UtcNow, text);
        Assert.NotNull(gameEvent);
        Assert.IsType<Unconscious>(gameEvent);
        var posEvent = (Unconscious)gameEvent;
        Assert.True(posEvent.IsAlive);
        Assert.Equal("AID_KRD_ 23", posEvent.NickName);
        Assert.Equal("i9GYz9yZfMopo-hFqbKfu3UN75Y1XExz53ZO8z4vJzc=", posEvent.Id);
        Assert.Equal(13180.9, posEvent.Position.X);
        Assert.Equal(7071.4, posEvent.Position.Y);
        Assert.Equal(6.0, posEvent.Position.Z);
    }

    [Fact]
    public void Suicide()
    {
        var text = "Player \"Survivor\" (id=t4D-5QUrSQceW8pHcL1MaOupMlDWGfpw80roNk1-rsU= pos=<10387.4, 2895.9, 35.5>) committed suicide";
        var builder = new SuicideBuilder();
        var gameEvent = builder.Build(DateTime.UtcNow, text);
        Assert.NotNull(gameEvent);
        Assert.IsType<Suicide>(gameEvent);
        var posEvent = (Suicide)gameEvent;
        Assert.True(posEvent.IsAlive);
        Assert.Equal("Survivor", posEvent.NickName);
        Assert.Equal("t4D-5QUrSQceW8pHcL1MaOupMlDWGfpw80roNk1-rsU=", posEvent.Id);
        Assert.Equal(10387.4, posEvent.Position.X);
        Assert.Equal(2895.9, posEvent.Position.Y);
        Assert.Equal(35.5, posEvent.Position.Z);
    }

    [Fact]
    public void Report()
    {
        var text = "PLAYER REPORT: <2023-11-26_18-14-16> <B1idL_7H1auUS5DPBOEDcTFQ3EBBrzFLa8r1GGmv7GA=>: тестовое сообщение";
        var builder = new ReportBuilder();
        var gameEvent = builder.Build(DateTime.UtcNow, text);
        Assert.NotNull(gameEvent);
        Assert.IsType<Report>(gameEvent);
        var posEvent = (Report)gameEvent;
        Assert.Equal("B1idL_7H1auUS5DPBOEDcTFQ3EBBrzFLa8r1GGmv7GA=", posEvent.PlayerId);
        Assert.Equal("тестовое сообщение", posEvent.Message);

    }

    [Fact]
    public void PlayerDied()
    {
        var text = "Player \"Altai_48 (2)\" (DEAD) (id=71bKIjZIjXME4VuQD6S63KpUw6N1MUCLu1mC6Ja4phU= pos=<7607.4, 3276.5, 6.1>) died. Stats> Water: 4698.26 Energy: 407.582 Bleed sources: 1";
        var builder = new PlayerDiedBuilder();
        var gameEvent = builder.Build(DateTime.UtcNow, text);
        Assert.NotNull(gameEvent);
        Assert.IsType<PlayerDied>(gameEvent);
        var diedEvent = (PlayerDied)gameEvent;
        Assert.Equal("71bKIjZIjXME4VuQD6S63KpUw6N1MUCLu1mC6Ja4phU=", diedEvent.Id);
        Assert.Equal("Altai_48 (2)", diedEvent.NickName);
        Assert.False(diedEvent.IsAlive);
        Assert.Equal(7607.4, diedEvent.Position.X);
        Assert.Equal(3276.5, diedEvent.Position.Y);
        Assert.Equal(6.1, diedEvent.Position.Z);
        Assert.Equal(4698.26, diedEvent.Water);
        Assert.Equal(407.582, diedEvent.Energy);
        Assert.Equal(1, diedEvent.Bleeding);

    }
}
