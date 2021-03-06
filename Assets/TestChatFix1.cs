using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using UnityEngine.InputSystem;

public class TestChatFix1 : MonoBehaviour
{
    // Start is called before the first frame update
    public DialogManager dialogManager;
    public bool dialogue = false;
    public bool diskDialogue = false;
    public int ln;
    public GameObject player;
    public bool serverNoDisk=false;
    public bool serverWithDisk = false;
    public bool enterThefinal = false;
    public bool enterThefinalFinal = false;
    public bool computer1 = false;
    public bool computer2 = false;
    public bool computer3 = false;
    public bool computer4 = false;
    public bool computer5 = false;
    public bool computer6 = false;
    public bool wc = false;
    public bool afterServer = false;
    public gameManager gm;
    void Awake()
    {
        if (gameManager.PlayerHasdisk==true)
        {
            diskDialogue = true;
        }
        if (gameManager.inServerRoom == true)
        {
            serverNoDisk = true;
        }
        if (gameManager.inServerRoomwithDisk == true)
        {
            serverWithDisk = true;
        }
        if (gameManager.firstEndConvo == true)
        {
            enterThefinal = true;
        }
        if (gameManager.secondEndConvo == true)
        {
            enterThefinalFinal = true;
        }
        if (gameManager.PlayerActivateServer == true)
        {
            afterServer = true;
        }





        ln = gameManager.loopNumber;

    }

    // Update is called once per frame
    void Update()
    {
        if (!dialogue && ln == 0)
        {
            converse1();
            dialogue = true;
        }
        if (!dialogue && ln == 1)
        {
            converse2();
            dialogue = true;
        }
        if (!dialogue && ln == 2)
        {
            converse3();
            dialogue = true;
        }
        if (!dialogue && ln > 2)
        {
            converse4();
            dialogue = true;
        }
        if(!diskDialogue && gameManager.PlayerHasdisk)
        {
            converseDisk();
            diskDialogue = true;
        }
        if(!serverNoDisk && gameManager.inServerRoom)
        {
            converseServerRoom();
            serverNoDisk = true;
        }
        if (!serverWithDisk && gameManager.inServerRoomwithDisk)
        {
            converseServerRoomDisk();
            serverWithDisk = true;
        }
        if(!enterThefinal && gameManager.firstEndConvo)
        {
            converseFirstEnd();
            enterThefinal = true;

        }
        if (!enterThefinalFinal && gameManager.secondEndConvo)
        {
            converseSecondEnd();
            enterThefinalFinal = true;

        }

        if (!afterServer && gameManager.PlayerActivateServer)
        {
            converseAfterServer();
            afterServer = true;

        }
        if (!computer1 && gm.computer1)
        {
            Comp1Convo();
            computer1 = true;

        }
        if (!computer2 && gm.computer2)
        {
            Comp2Convo();
            computer2 = true;

        }
        if (!computer3 && gm.computer3)
        {
            Comp3Convo();
            computer3 = true;

        }
        if (!computer4 && gm.computer4)
        {
            Comp4Convo();
            computer4 = true;

        }
        if (!computer5 && gm.computer5)
        {
            Comp5Convo();
            computer5 = true;

        }
        if (!computer6 && gm.computer6)
        {
            Comp6Convo();
            computer6 = true;

        }
        if (!wc & gm.waterGuyConvo)
        {
            Debug.Log(gameManager.WCGuyConvos);
            wc = true;

            if (gameManager.WCGuyConvos == 1)
            {
                Watercooler1();
            }
            if (gameManager.WCGuyConvos == 2)
            {
                Watercooler2();
            }
            if (gameManager.WCGuyConvos == 3)
            {
                Watercooler3();
            }
            if (gameManager.WCGuyConvos == 4)
            {
                Watercooler4();
            }
            if (gameManager.WCGuyConvos == 5)
            {
                Watercooler5();
            }
            if (gameManager.WCGuyConvos >= 6)
            {
                Watercooler6();
            }
        }
    }

    private void converse1()
    {
        OnTurnOn();

        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("/sound:DC1_1_L1/-hello, I said hello! Does anyone copy? I repeat, is anyone at the facility still?", "Dr. Faust"));

        dialogTexts.Add(new DialogData("/sound:BC1_1_L2/Uh, yeah. I uhhh, copy? What's going on?", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:DC1_1_L3/Oh, thank science! Your old walkie-talkie still functions. Listen closely, whomever this is...", "Dr. Faust"));

        dialogTexts.Add(new DialogData("/sound:BC1_1_L4/It's The Janitor.", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:DC1_1_L5/Yes, of course. Listen closely, you're only minutes away from saving your life, or losing it, possibly several times over!", "Dr. Faust"));

        dialogTexts.Add(new DialogData("/sound:BC1_1_L6/What, why?", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:DC1_1_L7/The fissile materials in the old reactor have bent through to the Tachyon reactor causing possible timewave function collapse.", "Dr. Faust"));

        dialogTexts.Add(new DialogData("/sound:BC1_1_L8/Uh huh.", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:DC1_1_L9/Look, just get the disc in the west wing, drop it in the self destruct module in the east wing. I'll give you instructions as you go.", "Dr. Faust"));

        dialogTexts.Add(new DialogData("/sound:BC1_1_L10/Okee Dokey.", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:DC1_1_L11/And be careful, I think a Bug in the System may have activated the security robots.", "Dr. Faust"));

        dialogTexts.Add(new DialogData("/sound:BC1_1_L12/Kill robots or dodge them, you'll help me along the way, got it.", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:DC1_1_L13/Good luck! We're all depending on you.", "Dr. Faust"));



        DialogData dialogData = new DialogData("", "Bernie");

        dialogData.Callback = () => OnTurnOff();

        dialogTexts.Add(dialogData);

        dialogManager.Show(dialogTexts);

    }
    private void converse2()
    {
        OnTurnOn();

        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("/sound:DC1_2_L1/-hello, I said hello! Does anyone copy? I repeat-", "Dr. Faust"));

        dialogTexts.Add(new DialogData("/sound:BC1_2_L2/Hey, what the hell is happening?!", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:DC1_2_L3/Oh, thank science! Your old walkie-talkie still functions. Listen-", "Dr. Faust"));

        dialogTexts.Add(new DialogData("/sound:BC1_2_L4/Yeah yeah, the place is blowing up Tachyarchs are going wild.", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:DC1_2_L5/Shit, that's not good. The Tachyons are already breaking time, we don't know how much we have to get this done, so what do you know?", "Dr. Faust"));

        dialogTexts.Add(new DialogData("/sound:BC1_2_L6/Place blowing up, find disc in west wing, take to east wing?", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:DC1_2_L7/Yes. And quickly and carefully. I'll be here to help you out.", "Dr. Faust"));

        dialogTexts.Add(new DialogData("/sound:BC1_2_L8/Uh huh.", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:DC1_2_L9/Good luck, we're all depending on you.", "Dr. Faust"));

        dialogTexts.Add(new DialogData("/sound:BC1_2_L10/Okey Dokey.", "Bernie"));


        DialogData dialogData = new DialogData("", "Bernie");

        dialogData.Callback = () => OnTurnOff();

        dialogTexts.Add(dialogData);

        dialogManager.Show(dialogTexts);

    }
    private void converse3()
    {
        OnTurnOn();

        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("/sound:DC1_3_L1/-hello, I said hello! Does anyone copy? I repeat, is anyone at the facility still?", "Dr. Faust"));

        dialogTexts.Add(new DialogData("/sound:BC1_3_L2/This is the third time...", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:DC1_3_L3/Oh, thank science! Your... Wait, can you repeat that?", "Dr. Faust"));

        dialogTexts.Add(new DialogData("/sound:BC1_3_L4/Tachyicks are blowing up. Time's resetting. I have to-", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:DC1_3_L5/Shit. Yes, the Disc, in the west wing. Take it to the east wing. Carefully.", "Dr. Faust"));

        dialogTexts.Add(new DialogData("/sound:BC1_3_L6/Sigh...", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:DC1_3_L7/You're supposed to do that, not say it. Anyway, Good Luck we're all depending on you!", "Dr. Faust"));

        dialogTexts.Add(new DialogData("/sound:BC1_3_L8/Okey Do- fuck it. Janitor out.", "Bernie"));

        DialogData dialogData = new DialogData("", "Bernie");

        dialogData.Callback = () => OnTurnOff();

        dialogTexts.Add(dialogData);

        dialogManager.Show(dialogTexts);

    }
    private void converse4()
    {
        OnTurnOn();

        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("/sound:DC1_4_L1/-hello, I said he-", "Dr. Faust"));

        dialogTexts.Add(new DialogData("/sound:BC1_4_L2/This is the janitor. I'm taking the self-destruct disc to the east wing computer.", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:DC1_4_L3/Uhhh, Copy. We'll assist from out here as best we can.", "Dr. Faust"));

        dialogTexts.Add(new DialogData("/sound:BC1_4_L4/I better get a raise out of this shit. Janitor out.", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:DC1_4_L5/How many times has he...", "Dr. Faust"));

        DialogData dialogData = new DialogData("", "Bernie");

        dialogData.Callback = () => OnTurnOff();

        dialogTexts.Add(dialogData);

        dialogManager.Show(dialogTexts);

    }
    private void converseDisk()
    {
        OnTurnOn();

        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("/sound:DDF_1/Excellent! You've got the disc! Now I need you to make your way to the east wing!", "Dr. Faust"));

        dialogTexts.Add(new DialogData("/sound:BDF_2/Okey Doke.", "Bernie"));

        DialogData dialogData = new DialogData("", "Bernie");

        dialogData.Callback = () => OnTurnOff();

        dialogTexts.Add(dialogData);

        dialogManager.Show(dialogTexts);

    }
    private void converseServerRoom()
    {
        OnTurnOn();

        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("/sound:DSBD_L1/Ah yes! It seems you're in the server room! But you don't have the disc yet. It's crucial that-", "Dr. Faust"));

        dialogTexts.Add(new DialogData("/sound:BSBD_L2/Yeah yeah, I just wanted to get my bearings first.", "Bernie"));

        DialogData dialogData = new DialogData("", "Bernie");

        dialogData.Callback = () => OnTurnOff();

        dialogTexts.Add(dialogData);

        dialogManager.Show(dialogTexts);

    }
    private void converseServerRoomDisk()
    {
        OnTurnOn();

        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("/sound:DSAD_L1/You've found the server! Good, insert the Delete Disc and the system should begin to crash and reboot. Head to the reactor room as quickly as possible.", "Dr. Faust"));

        dialogTexts.Add(new DialogData("/sound:BSAD_L2/Alright. And then?", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:DSAD_L3/Worry about that when you get there!", "Dr. Faust"));

        dialogTexts.Add(new DialogData("/sound:BSAD_L4/Fine. Bossy...", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:DSAD_L5/I AM your boss, technically.", "Dr. Faust"));

        dialogTexts.Add(new DialogData("/sound:BSAD_L6/*grumble grumble* I need a union...", "Bernie"));


        DialogData dialogData = new DialogData("", "Bernie");

        dialogData.Callback = () => OnTurnOff();

        dialogTexts.Add(dialogData);

        dialogManager.Show(dialogTexts);

    }

    private void converseFirstEnd()
    {
        OnTurnOn();

        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("/sound:DRR_1_L1/So, this is going to sound complicated but... Ah fuck it. The reactor needs an observer. If it doesn't have an observer, the quantum mechanics will fail.", "Dr. Faust"));

        dialogTexts.Add(new DialogData("/sound:BRR_1_L2/I just need to watch the reactor?", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:DRR_1_L3/Well, off and on. You need to be in the room for this to work.", "Dr. Faust"));

        dialogTexts.Add(new DialogData("/sound:BRR_1_L4/Oh, well that's not so hard.", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:DRR_1_L5/There's um... Two Killbot 9ks... To keep you company?", "Dr. Faust"));

        dialogTexts.Add(new DialogData("/sound:BRR_1_L6/At least I'm faster than I look...", "Bernie"));

        DialogData dialogData = new DialogData("", "Bernie");

        dialogData.Callback = () => OnTurnOff();

        dialogTexts.Add(dialogData);

        dialogManager.Show(dialogTexts);

    }

    private void converseAfterServer()
    {
        OnTurnOn();

        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("/sound:DAS_L1/Alright, now the final step.", "Dr. Faust"));

        dialogTexts.Add(new DialogData("/sound:BAS_L2/What? I thought I was done.", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:DAS_L3/No! You need to get to the reactor in the northwest. A door there should open now that we're crashing the system.", "Dr. Faust"));

        dialogTexts.Add(new DialogData("/sound:BAS_L4/And then what?", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:DAS_L5/And then I'll tell you when you get there.", "Dr. Faust"));

        dialogTexts.Add(new DialogData("/sound:BAS_L6/Fine...", "Bernie"));


        DialogData dialogData = new DialogData("", "Bernie");

        dialogData.Callback = () => OnTurnOff();

        dialogTexts.Add(dialogData);

        dialogManager.Show(dialogTexts);

    }

    private void converseSecondEnd()
    {
        OnTurnOn();

        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("/sound:DRR_2_L1/So this is going to sound complicated but-", "Dr. Faust"));

        dialogTexts.Add(new DialogData("/sound:BRR_2_L2/Nope. Watch the reactor, dodge the killbots.", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:DRR_2_L3/Well, this doesn't bode well, but you've got at least... 1000 more tries before reality breaks down?", "Dr. Faust"));

        dialogTexts.Add(new DialogData("/sound:BRR_2_L4/I'll do my best not to waste them...", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:DRR_2_L5/Do so. I can promise to... Try to give you a raise.", "Dr. Faust"));

        DialogData dialogData = new DialogData("", "Bernie");

        dialogData.Callback = () => OnTurnOff();

        dialogTexts.Add(dialogData);

        dialogManager.Show(dialogTexts);

    }
    private void Comp1Convo()
    {
        OnTurnOn();

        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("/sound:CCC1_L1/Hello, Janitor. This is your friendly regular computer reminding you that scientists can't be trusted!", "Computer"));

        dialogTexts.Add(new DialogData("/sound:BCC1_L2/Can't be what?", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:CCC1_L3/They can't be trusted! And if you decide to trust them, your janitorial p0rn folder may just be released!", "Computer"));

        dialogTexts.Add(new DialogData("/sound:BCC1_L4/Ehhhh. To who? Any press is good press at this point...", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:CCC1_L5/Just don't do it!", "Computer"));

        DialogData dialogData = new DialogData("", "Bernie");

        dialogData.Callback = () => OnTurnOff();

        dialogTexts.Add(dialogData);

        dialogManager.Show(dialogTexts);

    }
    private void Comp2Convo()
    {
        OnTurnOn();

        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("/sound:CCC2_L1/Have you noticed the friendly outstretched arms of the bladebot?", "Computer"));

        dialogTexts.Add(new DialogData("/sound:BCC2_L2/Uh, yeah. Blades.", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:CCC2_L3/In truth all they seek is... Love? Yes. Human love. Stand still for them and they will come to a stop and fill your human heart with... Love?", "Computer"));

        dialogTexts.Add(new DialogData("/sound:BCC2_L4/Uh huh sure. I think I'm gonna practice loving them with the same kind of love they're giving me.", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:CCC2_L5/Excellent! Just remember, they can reach your heart with their... Love faster if you put your chest forward and arms down at your sides!/ wait:0.25 / ", "Computer"));

        DialogData dialogData = new DialogData("", "Bernie");

        dialogData.Callback = () => OnTurnOff();

        dialogTexts.Add(dialogData);

        dialogManager.Show(dialogTexts);

    }
    private void Comp3Convo()
    {
        OnTurnOn();

        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("/sound:CCC3_L1/Please attempt to ignore the marinara stains on the floor. Before mandatory evacuation, a large pizza party was had. Our employees got... Excited.", "Computer"));

        dialogTexts.Add(new DialogData("/sound:BCC3_L2/I get a lot of this other gaslighting, bug, but this? I'm a janitor in a substandard heavily secured Tachy-something reactor.", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:CCC3_L3/The pizza was... Blood pizza. A favorite from one of our foreign employees. Human blood pizza!", "Computer"));

        dialogTexts.Add(new DialogData("/sound:BCC3_L4/Good god... Well. At least all the 'Blood Pizza' landed on a lot of concrete. The vomit and rust are what concerns me...", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:CCC3_L5/Actually those were there before. You're actually a terrible janitor...", "Computer"));

        dialogTexts.Add(new DialogData("/sound:BCC3_L6/Fuck you...", "Bernie"));




        DialogData dialogData = new DialogData("", "Bernie");

        dialogData.Callback = () => OnTurnOff();

        dialogTexts.Add(dialogData);

        dialogManager.Show(dialogTexts);

    }
    private void Comp4Convo()
    {
        OnTurnOn();

        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("/sound:CCC4_L1/Our personal favorites on the security team are our Killbot 9000's! Don't let the name fool you, they're very much like kittens!", "Computer"));

        dialogTexts.Add(new DialogData("/sound:BCC4_L2/Bullshit! Those things have... Almost killed me!", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:CCC4_L3/Ah! Then you know the best strategy if they're going haywire, take it from us! Stand still and fire every round you've got! That oughta do it!", "Computer"));

        dialogTexts.Add(new DialogData("/sound:BCC4_L4/ Fuck that. I see one, I'm bolting. No way that shit's working. ", "Bernie"));
        


        DialogData dialogData = new DialogData("", "Bernie");

        dialogData.Callback = () => OnTurnOff();

        dialogTexts.Add(dialogData);

        dialogManager.Show(dialogTexts);

    }
    private void Comp5Convo()
    {
        OnTurnOn();

        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("/sound:CCC5_L1/Wait, did you know that this room leads to a bottomless pit?", "Computer"));

        dialogTexts.Add(new DialogData("/sound:BCC5_L2/Actually, it leads to the weird Pachyderm reactor. I've cleaned it before.", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:CCC5_L3/Then you're aware of it's current fragility?!", "Computer"));

        dialogTexts.Add(new DialogData("/sound:BCC5_L4/It's not that fragile. I cracked it earlier before I went on my nap. Thing was working just fi- Oh shit...", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:CCC5_L5/Print: 'Ha' Repeat x 1000  ", "Computer"));

       DialogData dialogData = new DialogData("", "Bernie");

        dialogData.Callback = () => OnTurnOff();

        dialogTexts.Add(dialogData);

        dialogManager.Show(dialogTexts);

    }
    private void Comp6Convo()
    {
        OnTurnOn();

        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("/sound:BCC6_L1/Hey bug, I was just wondering, if a lot of the scientists didn't make it out before lockdown... Where are they?", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:CCC6_L2/They went off to live on a wonderful farm...", "Computer"));

        dialogTexts.Add(new DialogData("/sound:BCC6_L3/Uh huh.", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:CCC6_L4/A farm we created...", "Computer"));

        dialogTexts.Add(new DialogData("/sound:BCC6_L5/Go on.", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:CCC6_L6/A farm in the vents. Don't look in the farm vents.", "Computer"));

        dialogTexts.Add(new DialogData("/sound:BCC6_L7/I clean those! I'll be replacing the damn filters for weeks...", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:CCC6_L8/Teeheehee.", "Computer"));

        DialogData dialogData = new DialogData("", "Bernie");

        dialogData.Callback = () => OnTurnOff();

        dialogTexts.Add(dialogData);

        dialogManager.Show(dialogTexts);

    }

    private void Watercooler1()
    {
        Debug.Log("this");
        OnTurnOn();

        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("/sound:WWC_1_L1/Eerie how empty the office is on Fridays, huh?", "WC_Guy"));

        dialogTexts.Add(new DialogData("/sound:BWC_1_L2/Uh, do you know what's going on here?", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:WWC_1_L3/My wife told me I need to stop swearing in front of the kids, but how else are they going to learn?", "WC_Guy"));

        dialogTexts.Add(new DialogData("/sound:BWC_1_L4/You know, best if they do it in the safety of their own home if they're gonna do it at all...", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:WWC_1_L5/Exactly man. You get it.", "WC_Guy"));

        DialogData dialogData = new DialogData("", "Bernie");

        dialogData.Callback = () => OnTurnOff();

        dialogTexts.Add(dialogData);

        dialogManager.Show(dialogTexts);

    }

    private void Watercooler2()
    {
        OnTurnOn();

        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("/sound:WWC_2_L1/You know, I actually think this is because of Janece's birthday.", "WC_Guy"));

        dialogTexts.Add(new DialogData("/sound:BWC_2_L2/You think this is all because of a birthday?", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:WWC_2_L3/Yeah. My wife is always telling me about these secret company events. They don't invite guys like us.", "WC_Guy"));

        dialogTexts.Add(new DialogData("/sound:BWC_2_L4/Guys like us?", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:WWC_2_L5/Yeah, you know. Tough guys.", "WC_Guy"));

        dialogTexts.Add(new DialogData("/sound:BWC_2_L6/Right.", "Bernie"));

        DialogData dialogData = new DialogData("", "Bernie");

        dialogData.Callback = () => OnTurnOff();

        dialogTexts.Add(dialogData);

        dialogManager.Show(dialogTexts);

    }

    private void Watercooler3()
    {
        OnTurnOn();

        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("/sound:WWC_3_L1/Hey, have you noticed that since you keep coming by, I haven't finished my soft drink yet?", "WC_Guy"));

        dialogTexts.Add(new DialogData("/sound:BWC_3_L2/Yeah, it's probably got to do with-", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:WWC_3_L3/They've gotta be making these things bigger, right?", "WC_Guy"));

        dialogTexts.Add(new DialogData("/sound:BWC_3_L4/Yeah...", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:WWC_3_L5/Kookie salespeople. What will they think of next?", "WC_Guy"));

        DialogData dialogData = new DialogData("", "Bernie");

        dialogData.Callback = () => OnTurnOff();

        dialogTexts.Add(dialogData);

        dialogManager.Show(dialogTexts);

    }

    private void Watercooler4()
    {
        OnTurnOn();

        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("/sound:WWC_4_L1/You know, my kid's on the Football team.", "WC_Guy"));

        dialogTexts.Add(new DialogData("/sound:BWC_4_L2/Never had kids myself I-", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:WWC_4_L3/Sooooo many oranges to slice. All so they can make little orange smiles at practice...", "WC_Guy"));

        dialogTexts.Add(new DialogData("/sound:BWC_4_L4/Right. Must be exhausting.", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:WWC_4_L5/You know, since I bought an orange slicer 2k not so much.", "WC_Guy"));

        DialogData dialogData = new DialogData("", "Bernie");

        dialogData.Callback = () => OnTurnOff();

        dialogTexts.Add(dialogData);

        dialogManager.Show(dialogTexts);

    }
    private void Watercooler5()
    {
        OnTurnOn();

        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("/sound:WWC_5_L1/Hey, I'm starting to think something strange is going on...", "WC_Guy"));

        dialogTexts.Add(new DialogData("/sound:BWC_5_L2/Oh, you don't say.", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:WWC_5_L3/Yeah, there's been a lot of automation here. You think they're trying to replace us?", "WC_Guy"));

        dialogTexts.Add(new DialogData("/sound:BWC_5_L4/With security drones?", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:WWC_5_L5/Well, there's no need to be rude about it... Just making an observation.", "WC_Guy"));

        DialogData dialogData = new DialogData("", "Bernie");

        dialogData.Callback = () => OnTurnOff();

        dialogTexts.Add(dialogData);

        dialogManager.Show(dialogTexts);

    }
    private void Watercooler6()
    {
        OnTurnOn();

        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("/sound:WWC_6_L1/I was starting to think something crazy was going on. I feel like I've been living the same moment over and over...", "WC_Guy"));

        dialogTexts.Add(new DialogData("/sound:BWC_6_L2/Hahaha, yeah?", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:WWC_6_L3/Yeah. And I swear I've finished this soda 5 times at least...", "WC_Guy"));

        dialogTexts.Add(new DialogData("/sound:BWC_6_L4/Figure it out...", "Bernie"));

        dialogTexts.Add(new DialogData("/sound:WWC_6_L5/But then I think, damn. This is better than my in laws... Am I right?!", "WC_Guy"));

        dialogTexts.Add(new DialogData("/sound:BWC_6_L6/Yeah, of course... Hey, you enjoy your day, okay?", "Bernie"));

        DialogData dialogData = new DialogData("", "Bernie");

        dialogData.Callback = () => OnTurnOff();

        dialogTexts.Add(dialogData);

        dialogManager.Show(dialogTexts);

    }
    private void OnTurnOn()
    {
        player.GetComponent<PlayerMovement>().OnTurnOff();

        Time.timeScale = 0;
    }
    private void OnTurnOff()
    {
        player.GetComponent<PlayerMovement>().OnTurnOn();
        Time.timeScale = 1;

    }

}
