using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using UnityEngine.InputSystem;

public class TestChat : MonoBehaviour
{
    // Start is called before the first frame update
    public DialogManager dialogManager;
    public bool dialogue = false;
    public bool diskDialogue = false;
    public int ln;
    public GameObject player;
    public bool serverNoDisk=true;
    public bool serverWithDisk = true;
    public bool enterThefinal = false;
    public bool enterThefinalFinal = false;
    public bool computer1 = false;
    public bool computer2 = false;
    public bool computer3 = false;
    public bool computer4 = false;
    public bool computer5 = false;
    public bool computer6 = false;
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



    }

    private void converse1()
    {
        OnTurnOn();

        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("-hello, I said hello! Does anyone copy? I repeat, is anyone at the facility still?/wait:1//close/ ", "Dr. Faust"));

        dialogTexts.Add(new DialogData("Uh, yeah. I uhhh, copy? What's going on?/wait:1//close/ ", "Bernie"));

        dialogTexts.Add(new DialogData("Oh, thank science! Your old walkie-talkie still functions. Listen closely, whomever this is.../wait:1//close/ ", "Dr. Faust"));

        dialogTexts.Add(new DialogData("It's The Janitor./wait:1//close/ ", "Bernie"));

        dialogTexts.Add(new DialogData("Yes, of course. Listen closely, you're only minutes away from saving your life, or losing it, possibly several times over!/wait:1//close/ ", "Dr. Faust"));

        dialogTexts.Add(new DialogData("What, why?/wait:1//close/ ", "Bernie"));

        dialogTexts.Add(new DialogData("The fissile materials in the old reactor have bent through to the Tachyon reactor causing possible timewave function collapse./wait:1//close/ ", "Dr. Faust"));

        dialogTexts.Add(new DialogData("Uh huh./wait:1//close/ ", "Bernie"));

        dialogTexts.Add(new DialogData("Look, just get the disc in the west wing, drop it in the self destruct module in the east wing. I'll give you instructions as you go./wait:1//close/ ", "Dr. Faust"));

        dialogTexts.Add(new DialogData("Okee Dokey./wait:1//close/ ", "Bernie"));

        dialogTexts.Add(new DialogData("And be careful, I think a Bug in the System may have activated the security robots./wait:1//close/ ", "Dr. Faust"));

        dialogTexts.Add(new DialogData("Kill robots or dodge them, you'll help me along the way, got it./wait:1//close/ ", "Bernie"));

        dialogTexts.Add(new DialogData("Good luck! We're all depending on you./wait:1//close/ ", "Dr. Faust"));
        DialogData dialogData = new DialogData("", "Bernie");

        dialogData.Callback = () => OnTurnOff();

        dialogTexts.Add(dialogData);

        dialogManager.Show(dialogTexts);

    }
    private void converse2()
    {
        OnTurnOn();

        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("-hello, I said hello! Does anyone copy? I repeat-/wait:1//close/ ", "Dr. Faust"));

        dialogTexts.Add(new DialogData("Hey, what the hell is happening?!/wait:1//close/ ", "Bernie"));

        dialogTexts.Add(new DialogData("Oh, thank science! Your old walkie-talkie still functions. Listen-/wait:1//close/ ", "Dr. Faust"));

        dialogTexts.Add(new DialogData("Yeah yeah, the place is blowing up Tachyarchs are going wild./wait:1//close/ ", "Bernie"));

        dialogTexts.Add(new DialogData("Shit, that's not good. The Tachyons are already breaking time, we don't know how much we have to get this done, so what do you know?/wait:1//close/ ", "Dr. Faust"));

        dialogTexts.Add(new DialogData("Place blowing up, find disc in west wing, take to east wing?/wait:1//close/ ", "Bernie"));

        dialogTexts.Add(new DialogData("Yes. And quickly and carefully. I'll be here to help you out./wait:1//close/ ", "Dr. Faust"));

        dialogTexts.Add(new DialogData("Uh huh./wait:1//close/ ", "Bernie"));

        dialogTexts.Add(new DialogData("Good luck, we're all depending on you./wait:1//close/ ", "Dr. Faust"));

        dialogTexts.Add(new DialogData("Okey Dokey./wait:1//close/ ", "Bernie"));

        DialogData dialogData = new DialogData("", "Bernie");

        dialogData.Callback = () => OnTurnOff();

        dialogTexts.Add(dialogData);

        dialogManager.Show(dialogTexts);

    }
    private void converse3()
    {
        OnTurnOn();

        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("-hello, I said hello! Does anyone copy? I repeat, is anyone at the facility still?/wait:1//close/ ", "Dr. Faust"));

        dialogTexts.Add(new DialogData("This is the third time.../wait:1//close/ ", "Bernie"));

        dialogTexts.Add(new DialogData("Oh, thank science! Your... Wait, can you repeat that?/wait:1//close/ ", "Dr. Faust"));

        dialogTexts.Add(new DialogData("Tachyicks are blowing up. Time's resetting. I have to-/wait:1//close/ ", "Bernie"));

        dialogTexts.Add(new DialogData("Shit. Yes, the Disc, in the west wing. Take it to the east wing. Carefully./wait:1//close/ ", "Dr. Faust"));

        dialogTexts.Add(new DialogData("Sigh.../wait:1//close/ ", "Bernie"));

        dialogTexts.Add(new DialogData("You're supposed to do that, not say it. Anyway, Good Luck we're all depending on you!/wait:1//close/ ", "Dr. Faust"));

        dialogTexts.Add(new DialogData("Okey Do- fuck it. Janitor out./wait:1//close/ ", "Bernie"));


        DialogData dialogData = new DialogData("", "Bernie");

        dialogData.Callback = () => OnTurnOff();

        dialogTexts.Add(dialogData);

        dialogManager.Show(dialogTexts);

    }
    private void converse4()
    {
        OnTurnOn();

        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("-hello, I said he-/wait:1//close/ ", "Dr. Faust"));

        dialogTexts.Add(new DialogData("This is the janitor. I'm taking the self-destruct disc to the east wing computer./wait:1//close/ ", "Bernie"));

        dialogTexts.Add(new DialogData("Uhhh, Copy. We'll assist from out here as best we can./wait:1//close/ ", "Dr. Faust"));

        dialogTexts.Add(new DialogData("I better get a raise out of this shit. Janitor out./wait:1//close/ ", "Bernie"));

        dialogTexts.Add(new DialogData("How many times has he.../wait:1//close/ ", "Dr. Faus"));



        DialogData dialogData = new DialogData("", "Bernie");

        dialogData.Callback = () => OnTurnOff();

        dialogTexts.Add(dialogData);

        dialogManager.Show(dialogTexts);

    }
    private void converseDisk()
    {
        OnTurnOn();

        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("Excellent! You've got the disc! Now I need you to make your way to the east wing!/wait:1//close/ ", "Dr. Faust"));

        dialogTexts.Add(new DialogData("Okey Doke./wait:1//close/ ", "Bernie"));

        DialogData dialogData = new DialogData("", "Bernie");

        dialogData.Callback = () => OnTurnOff();

        dialogTexts.Add(dialogData);

        dialogManager.Show(dialogTexts);

    }
    private void converseServerRoom()
    {
        OnTurnOn();

        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("Ah yes! It seems you're in the server room! But you don't have the disc yet. It's crucial that-/wait:1//close/ ", "Dr. Faust"));

        dialogTexts.Add(new DialogData("Yeah yeah, I just wanted to get my bearings first./wait:1//close/ ", "Bernie"));


        DialogData dialogData = new DialogData("", "Bernie");

        dialogData.Callback = () => OnTurnOff();

        dialogTexts.Add(dialogData);

        dialogManager.Show(dialogTexts);

    }
    private void converseServerRoomDisk()
    {
        OnTurnOn();

        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("You've found the server! Good, insert the Delete Disc and the system should begin to crash and reboot. Head to the reactor room as quickly as possible./wait:1//close/ ", "Dr. Faust"));

        dialogTexts.Add(new DialogData("Alright. And then?/wait:1//close/ ", "Bernie"));

        dialogTexts.Add(new DialogData("Worry about that when you get there!/wait:1//close/ ", "Dr. Faust"));

        dialogTexts.Add(new DialogData("Fine. Bossy.../wait:1//close/ ", "Bernie"));

        dialogTexts.Add(new DialogData("I AM your boss, technically./wait:1//close/ ", "Dr. Faust"));

        dialogTexts.Add(new DialogData("*grumble grumble* I need a union.../wait:1//close/ ", "Bernie"));



        DialogData dialogData = new DialogData("", "Bernie");

        dialogData.Callback = () => OnTurnOff();

        dialogTexts.Add(dialogData);

        dialogManager.Show(dialogTexts);

    }

    private void converseFirstEnd()
    {
        OnTurnOn();

        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("So, this is going to sound complicated but... Ah fuck it. The reactor needs an observer. If it doesn't have an observer, the quantum mechanics will fail./wait:1//close/ ", "Dr. Faust"));

        dialogTexts.Add(new DialogData("I just need to watch the reactor?/wait:1//close/ ", "Bernie"));

        dialogTexts.Add(new DialogData("Well, off and on. You need to be in the room for this to work./wait:1//close/ ", "Dr. Faust"));

        dialogTexts.Add(new DialogData("Oh, well that's not so hard./wait:1//close/ ", "Bernie"));

        dialogTexts.Add(new DialogData("There's um... Two Killbot 9ks... To keep you company?/wait:1//close/ ", "Dr. Faust"));

        dialogTexts.Add(new DialogData("At least I'm faster than I look.../wait:1//close/ ", "Bernie"));



        DialogData dialogData = new DialogData("", "Bernie");

        dialogData.Callback = () => OnTurnOff();

        dialogTexts.Add(dialogData);

        dialogManager.Show(dialogTexts);

    }
    private void converseSecondEnd()
    {
        OnTurnOn();

        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("So this is going to sound complicated but-/wait:1//close/ ", "Dr. Faust"));

        dialogTexts.Add(new DialogData("Nope. Watch the reactor, dodge the killbots./wait:1//close/ ", "Bernie"));

        dialogTexts.Add(new DialogData("Well, this doesn't bode well, but you've got at least... 1000 more tries before reality breaks down?/wait:1//close/ ", "Dr. Faust"));

        dialogTexts.Add(new DialogData("I'll do my best not to waste them.../wait:1//close/ ", "Bernie"));

        dialogTexts.Add(new DialogData("Do so. I can promise to... Try to give you a raise./wait:1//close/ ", "Dr. Faust"));



        DialogData dialogData = new DialogData("", "Bernie");

        dialogData.Callback = () => OnTurnOff();

        dialogTexts.Add(dialogData);

        dialogManager.Show(dialogTexts);

    }
    private void Comp1Convo()
    {
        OnTurnOn();

        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("Hello, Janitor. This is your friendly regular computer reminding you that scientists can't be trusted!/wait:1//close/ ", "Computer"));

        dialogTexts.Add(new DialogData("Can't be what?/wait:1//close/ ", "Bernie"));

        dialogTexts.Add(new DialogData("They can't be trusted! And if you decide to trust them, your janitorial p0rn folder may just be released!/wait:1//close/ ", "Computer"));

        dialogTexts.Add(new DialogData("Ehhhh. To who? Any press is good press at this point.../wait:1//close/ ", "Bernie"));

        dialogTexts.Add(new DialogData("Just don't do it!/wait:1//close/ ", "Computer"));




        DialogData dialogData = new DialogData("", "Bernie");

        dialogData.Callback = () => OnTurnOff();

        dialogTexts.Add(dialogData);

        dialogManager.Show(dialogTexts);

    }
    private void Comp2Convo()
    {
        OnTurnOn();

        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("Have you noticed the friendly outstretched arms of the bladebot?/wait:1//close/ ", "Computer"));

        dialogTexts.Add(new DialogData("Uh, yeah. Blades./wait:1//close/ ", "Bernie"));

        dialogTexts.Add(new DialogData("In truth all they seek is... Love? Yes. Human love. Stand still for them and they will come to a stop and fill your human heart with... Love?/wait:1//close/ ", "Computer"));

        dialogTexts.Add(new DialogData("Uh huh sure. I think I'm gonna practice loving them with the same kind of love they're giving me./wait:1//close/ ", "Bernie"));

        dialogTexts.Add(new DialogData("Excellent! Just remember, they can reach your heart with their... Love faster if you put your chest forward and arms down at your sides!/wait:1//close/ ", "Computer"));
        
        DialogData dialogData = new DialogData("", "Bernie");

        dialogData.Callback = () => OnTurnOff();

        dialogTexts.Add(dialogData);

        dialogManager.Show(dialogTexts);

    }
    private void Comp3Convo()
    {
        OnTurnOn();

        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("Please attempt to ignore the marinara stains on the floor. Before mandatory evacuation, a large pizza party was had. Our employees got... Excited./wait:1//close/ ", "Computer"));

        dialogTexts.Add(new DialogData("I get a lot of this other gaslighting, bug, but this? I'm a janitor in a substandard heavily secured Tachy-something reactor./wait:1//close/ ", "Bernie"));

        dialogTexts.Add(new DialogData("The pizza was... Blood pizza. A favorite from one of our foreign employees. Human blood pizza!/wait:1//close/ ", "Computer"));

        dialogTexts.Add(new DialogData("Good god... Well. At least all the 'Blood Pizza' landed on a lot of concrete. The vomit and rust are what concerns me.../wait:1//close/ ", "Bernie"));

        dialogTexts.Add(new DialogData("Actually those were there before. You're actually a terrible janitor.../wait:1//close/ ", "Computer"));

        dialogTexts.Add(new DialogData("Fuck you.../wait:1//close/ ", "Bernie"));



        DialogData dialogData = new DialogData("", "Bernie");

        dialogData.Callback = () => OnTurnOff();

        dialogTexts.Add(dialogData);

        dialogManager.Show(dialogTexts);

    }
    private void Comp4Convo()
    {
        OnTurnOn();

        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("Our favorites of the security team are our Killbot 9000's! Don't let the name fool you, they're very much like kittens!/wait:1//close/ ", "Computer"));

        dialogTexts.Add(new DialogData("Bullshit! Those things have... Almost killed me!/wait:1//close/ ", "Bernie"));

        dialogTexts.Add(new DialogData("Ah! Then the best strategy if they're going haywire, take it from us! Stand still and fire every round you've got! That oughta do it!/wait:1//close/ ", "Computer"));

        dialogTexts.Add(new DialogData("Fuck that. I see one, I'm bolting. No way that shit's working./wait:1//close/ ", "Bernie"));



        DialogData dialogData = new DialogData("", "Bernie");

        dialogData.Callback = () => OnTurnOff();

        dialogTexts.Add(dialogData);

        dialogManager.Show(dialogTexts);

    }
    private void Comp5Convo()
    {
        OnTurnOn();

        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("Wait, did you know that this room leads to a bottomless pit?/wait:1//close/ ", "Computer"));

        dialogTexts.Add(new DialogData("Actually, it leads to the weird Pachyderm reactor. I've cleaned it before./wait:1//close/ ", "Bernie"));

        dialogTexts.Add(new DialogData("Then you're aware of it's current fragility?!/wait:1//close/ ", "Computer"));

        dialogTexts.Add(new DialogData("It's not that fragile. I cracked it earlier before I went on my nap. Thing was working just fi- Oh shit.../wait:1//close/ ", "Bernie"));

        dialogTexts.Add(new DialogData("Print: 'Ha' Repeat x 1000/wait:1//close/ ", "Computer"));



        DialogData dialogData = new DialogData("", "Bernie");

        dialogData.Callback = () => OnTurnOff();

        dialogTexts.Add(dialogData);

        dialogManager.Show(dialogTexts);

    }
    private void Comp6Convo()
    {
        OnTurnOn();

        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("Hey bug, I was just wondering, if a lot of the scientists didn't make it out before lockdown... Where are they?/wait:1//close/ ", "Bernie"));

        dialogTexts.Add(new DialogData("They went off to live on a wonderful farm.../wait:1//close/ ", "Computer"));

        dialogTexts.Add(new DialogData("Uh huh./wait:1//close/ ", "Bernie"));

        dialogTexts.Add(new DialogData("A farm we created.../wait:1//close/ ", "Computer"));

        dialogTexts.Add(new DialogData("Go on./wait:1//close/ ", "Bernie"));

        dialogTexts.Add(new DialogData("In the vents. Don't look in the farm vents./wait:1//close/ ", "Computer"));

        dialogTexts.Add(new DialogData("I clean those! I'll be replacing the damn vents for weeks.../wait:1//close/ ", "Bernie"));




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
