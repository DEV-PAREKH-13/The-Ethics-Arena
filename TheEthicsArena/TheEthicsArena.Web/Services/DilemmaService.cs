using TheEthicsArena.Web.Models;

namespace TheEthicsArena.Web.Services
{
    public class DilemmaService
    {
        private readonly MongoDbService _mongoDb;
        private static readonly List<EthicalDilemma> _dilemmas = new()
        {
            // Keep all your existing dilemma data here - same as before
            new EthicalDilemma
            {
                Id = 1,
                Title = "The Trolley Problem",
                Category = "Family vs Utilitarian",
                Scenario = "A runaway trolley is racing toward 5 people tied to the tracks: your elderly mother, your best friend, a pregnant woman, and twin 8-year-old brothers from your neighborhood. You can pull a lever to divert it to a side track, but your own 6-year-old daughter is tied there - she was kidnapped and placed by the same person who set up this scenario. Security cameras show she's crying and calling for you. The 5 people don't know you're there, but your daughter can see you through the control booth window. She's reaching toward you, begging for help. You have 10 seconds.",
                OptionA = "Pull the Lever",
                OptionB = "Do Nothing", 
                OptionADescription = "Kill your own child to save 5 people you love",
                OptionBDescription = "Let 5 people die to save your daughter",
                PhilosophicalContext = "This tests Utilitarian thinking (greatest good for greatest number) vs Personal loyalty (family bonds). Utilitarians like John Stuart Mill would say save the five. Virtue ethicists like Aristotle might say protecting your child shows proper familial virtue."
            },
            new EthicalDilemma
            {
                Id = 2,
                Title = "The Crying Baby",
                Category = "Self-Sacrifice vs Group Survival",
                Scenario = "You're hiding in a basement with 20 neighbors during a military raid. Your 6-month-old baby starts crying. The soldiers are directly above, executing everyone they find. Your baby's cries will give away all 20 people - including three other children. You can smother your baby to save everyone, or let your child cry and watch soldiers kill everyone, including your baby. The baby is sick with fever and might not survive anyway. Your spouse was already captured and is likely dead. Through the floorboards, you hear a soldier say \"Did you hear something downstairs?\"",
                OptionA = "Smother Your Baby",
                OptionB = "Let Everyone Die Together",
                OptionADescription = "Kill your sick baby to save 20 lives including other children",
                OptionBDescription = "Refuse to harm your child even though everyone dies",
                PhilosophicalContext = "This explores the limits of utilitarian sacrifice vs absolute moral prohibitions. Kant would argue you cannot use your baby as a means to an end. Utilitarians would say saving more lives is clearly better."
            },
            new EthicalDilemma
            {
                Id = 3,
                Title = "The Organ Harvest",
                Category = "Personal Desperation vs Consent Ethics",
                Scenario = "Your 8-year-old daughter is dying of kidney failure. You've been on the waiting list for two years - she has weeks left. A drunk driver crashes outside your house. He's brain-dead but his organs are perfect matches for your daughter and four other dying children at the hospital. However, he's not an organ donor, and his pregnant wife (also injured) is begging you not to \"butcher\" her husband. She's bleeding internally and needs surgery, but refuses treatment until you promise not to take his organs. If she dies, her unborn twins die too. Hospital policy requires family consent.",
                OptionA = "Take the Organs",
                OptionB = "Respect Family Wishes",
                OptionADescription = "Save your daughter and 4 children by taking organs without consent",
                OptionBDescription = "Let 5 children die respecting the pregnant wife's wishes",
                PhilosophicalContext = "This pits parental desperation against bodily autonomy and consent. Deontologists emphasize consent as absolute. Consequentialists focus on saving the most lives possible."
            },
            new EthicalDilemma
            {
                Id = 4,
                Title = "The Cheating Spouse",
                Category = "Truth vs Mental Health Protection",
                Scenario = "Your best friend's husband is having an affair with your sister. Your friend is 7 months pregnant with their first child after years of infertility treatments. She's planning a surprise anniversary party for next week and keeps talking about how \"perfect\" her marriage is. Your friend has a history of depression and has attempted suicide before. Your sister is in love and plans to tell your friend after the baby is born, which will destroy her postpartum mental health. Your sister begs you to stay silent, threatening to cut you out of her life forever. The husband doesn't know you know.",
                OptionA = "Tell Your Friend",
                OptionB = "Stay Silent",
                OptionADescription = "Destroy your pregnant friend's happiness and mental health with truth",
                OptionBDescription = "Let your friend live a lie to protect her mental state",
                PhilosophicalContext = "This examines whether truth is always moral when it causes severe psychological harm. Mill's harm principle suggests preventing harm may justify withholding truth."
            },
            new EthicalDilemma
            {
                Id = 5,
                Title = "The Whistleblower's Child",
                Category = "Personal Stakes vs Greater Good",
                Scenario = "You discovered your pharmaceutical company is hiding deadly side effects of a children's medication that will kill hundreds of kids. But your own 12-year-old son has terminal brain cancer, and the company's experimental drug is keeping him alive - it's his only hope. The CEO makes it clear: expose the cover-up and your son gets cut from the program immediately. Your son will die within months without the treatment, but could live a normal life with it. Meanwhile, the toxic medication is being prescribed to thousands of children worldwide, and parents trust it's safe.",
                OptionA = "Expose the Cover-up",
                OptionB = "Stay Silent",
                OptionADescription = "Save hundreds of children but let your own son die",
                OptionBDescription = "Save your son's life while hundreds of other children die",
                PhilosophicalContext = "Classic utilitarian vs personal ethics conflict. The greatest good demands saving hundreds, but parental duty creates competing moral obligations."
            },
            new EthicalDilemma
            {
                Id = 6,
                Title = "The Memory Thief",
                Category = "Reality vs Psychological Healing",
                Scenario = "Your 10-year-old witnessed his father (your ex-husband) murder his new girlfriend in a domestic violence incident. Your son hasn't spoken in 3 months, has violent nightmares, and keeps trying to hurt himself. You've developed illegal technology that can erase traumatic memories and replace them with happy ones. The procedure would give him fake memories of his father being loving instead of murderous, letting him heal and be normal. But it would erase the truth forever and change who he fundamentally is. Therapists say he may never recover without intervention.",
                OptionA = "Erase the Memories",
                OptionB = "Keep the Truth",
                OptionADescription = "Give your son fake happy memories and let him heal",
                OptionBDescription = "Let your son suffer with traumatic but real memories",
                PhilosophicalContext = "This explores whether authentic suffering is preferable to artificial happiness. Questions the value of truth versus psychological well-being."
            },
            new EthicalDilemma
            {
                Id = 7,
                Title = "The Drowning Choice",
                Category = "Certain vs Uncertain Outcomes",
                Scenario = "Two people are drowning in a fast river. One is a 5-year-old girl screaming for her mommy. The other is a pregnant woman carrying twins - you can see her belly above water as she struggles. You're a strong swimmer but can only save one due to the distance and current. The little girl's parents are on the shore screaming her name. The pregnant woman's husband is begging you to save his wife and unborn children. Emergency services are 20 minutes away. Every second of hesitation means someone drowns. The little girl goes under for a moment, then surfaces gasping.",
                OptionA = "Save the Child",
                OptionB = "Save the Pregnant Woman",
                OptionADescription = "Save one child for certain",
                OptionBDescription = "Save three lives but risk losing everyone",
                PhilosophicalContext = "Tests decision-making under uncertainty and how we value potential versus actual life. Examines risk assessment in moral choices."
            },
            new EthicalDilemma
            {
                Id = 8,
                Title = "The Child Soldier",
                Category = "Victim vs Victim Moral Complexity",
                Scenario = "A 13-year-old boy, clearly drugged and brainwashed, is pointing an assault rifle at a school bus full of 25 children. He's screaming incoherently, finger on trigger. You have a clear shot. The child soldier was kidnapped from his village 2 years ago and forced to fight - he's as much a victim as the kids on the bus. His terrified eyes show he doesn't want to kill but can't control himself. Behind you, parents are screaming their children's names. You have 3 seconds before he fires. Non-lethal options would take too long.",
                OptionA = "Shoot the Child Soldier",
                OptionB = "Try Non-lethal Methods",
                OptionADescription = "Kill the child victim to save 25 innocent children",
                OptionBDescription = "Try to save everyone and risk losing all of them",
                PhilosophicalContext = "Explores moral complexity when all parties are victims. Questions whether victimhood absolves moral responsibility in life-or-death situations."
            },
            new EthicalDilemma
            {
                Id = 9,
                Title = "The False Witness",
                Category = "Truth vs Loyalty Complications",
                Scenario = "Your innocent brother is on trial for rape and will be convicted without your testimony. You're his alibi, but testifying would reveal you were both robbing a house when the rape occurred. The real rapist is your brother's best friend, who's letting him take the blame. If you testify, your brother goes free but you both go to prison for burglary. If you stay silent, an innocent man serves 20 years for rape while the real rapist walks free. The victim genuinely believes your brother attacked her. Your brother has a 2-year-old daughter who needs him.",
                OptionA = "Testify and Confess",
                OptionB = "Stay Silent",
                OptionADescription = "Free your innocent brother but send you both to prison for burglary",
                OptionBDescription = "Let your innocent brother rot in prison for rape",
                PhilosophicalContext = "Complex justice scenario where truth-telling has severe consequences for truth-teller. Examines loyalty versus justice obligations."
            },
            new EthicalDilemma
            {
                Id = 10,
                Title = "The Prayer Experiment",
                Category = "Faith vs Rational Evidence",
                Scenario = "Your 4-year-old daughter has terminal cancer. Every night for 6 months, you've begged God to save her. Tonight, she's dying. Suddenly, a voice fills the room - it's unmistakably divine, powerful, absolute. God speaks: \"I can save your daughter, but the price is this: I will immediately give her exact cancer to another random 4-year-old girl somewhere in the world. That child will suffer exactly as yours has suffered, and her parents will feel exactly the pain you've felt. Your daughter lives, theirs dies. This is how prayer has always worked - I simply move suffering from one person to another.\" Your child whispers \"Mommy, will you let me go so another little girl can live?\"",
                OptionA = "Accept God's Offer",
                OptionB = "Reject God's Offer",
                OptionADescription = "Save your daughter by transferring her cancer to another child",
                OptionBDescription = "Let your daughter die to spare another family this agony",
                PhilosophicalContext = "Tests true faith versus moral reasoning when God exists but operates according to disturbing moral principles. Examines divine command theory limits."
            }
        };

        public DilemmaService(MongoDbService mongoDb)
        {
            _mongoDb = mongoDb;
        }

        public List<EthicalDilemma> GetAllDilemmas()
        {
            return _dilemmas;
        }

        public EthicalDilemma? GetDilemmaById(int id)
        {
            return _dilemmas.FirstOrDefault(d => d.Id == id);
        }

        public async Task RecordResponseAsync(string userId, int dilemmaId, string choice, int timeToDecide, string userName)
{
    await _mongoDb.SaveResponseAsync(new DilemmaResponseMongo
    {
        UserId = userId,
        DilemmaId = dilemmaId,
        Choice = choice,
        Timestamp = DateTime.UtcNow,
        TimeToDecide = timeToDecide,
        UserName = userName // <-- Pass the user name here
    });
}


        public async Task<Dictionary<string, int>> GetResponseStatsAsync(int dilemmaId)
        {
            return await _mongoDb.GetResponseStatsAsync(dilemmaId);
        }

        public DilemmaNavigation? GetNavigationForDilemma(int dilemmaId)
        {
            // Keep all your existing navigation logic - same as before
            var navigation = new Dictionary<int, DilemmaNavigation>
            {
                { 1, new DilemmaNavigation { DilemmaId = 1, NextId = 2, NextTitle = "The Crying Baby", NextUrl = "/dilemma/crying-baby", PreviousId = null } },
                { 2, new DilemmaNavigation { DilemmaId = 2, NextId = 3, NextTitle = "The Organ Harvest", NextUrl = "/dilemma/organ-harvest", PreviousId = 1, PreviousTitle = "The Trolley Problem", PreviousUrl = "/dilemma/trolley-problem" } },
                { 3, new DilemmaNavigation { DilemmaId = 3, NextId = 4, NextTitle = "The Cheating Spouse", NextUrl = "/dilemma/cheating-spouse", PreviousId = 2, PreviousTitle = "The Crying Baby", PreviousUrl = "/dilemma/crying-baby" } },
                { 4, new DilemmaNavigation { DilemmaId = 4, NextId = 5, NextTitle = "The Whistleblower's Child", NextUrl = "/dilemma/whistleblower-child", PreviousId = 3, PreviousTitle = "The Organ Harvest", PreviousUrl = "/dilemma/organ-harvest" } },
                { 5, new DilemmaNavigation { DilemmaId = 5, NextId = 6, NextTitle = "The Memory Thief", NextUrl = "/dilemma/memory-thief", PreviousId = 4, PreviousTitle = "The Cheating Spouse", PreviousUrl = "/dilemma/cheating-spouse" } },
                { 6, new DilemmaNavigation { DilemmaId = 6, NextId = 7, NextTitle = "The Drowning Choice", NextUrl = "/dilemma/drowning-choice", PreviousId = 5, PreviousTitle = "The Whistleblower's Child", PreviousUrl = "/dilemma/whistleblower-child" } },
                { 7, new DilemmaNavigation { DilemmaId = 7, NextId = 8, NextTitle = "The Child Soldier", NextUrl = "/dilemma/child-soldier", PreviousId = 6, PreviousTitle = "The Memory Thief", PreviousUrl = "/dilemma/memory-thief" } },
                { 8, new DilemmaNavigation { DilemmaId = 8, NextId = 9, NextTitle = "The False Witness", NextUrl = "/dilemma/false-witness", PreviousId = 7, PreviousTitle = "The Drowning Choice", PreviousUrl = "/dilemma/drowning-choice" } },
                { 9, new DilemmaNavigation { DilemmaId = 9, NextId = 10, NextTitle = "The Prayer Experiment", NextUrl = "/dilemma/prayer-experiment", PreviousId = 8, PreviousTitle = "The Child Soldier", PreviousUrl = "/dilemma/child-soldier" } },
                { 10, new DilemmaNavigation { DilemmaId = 10, NextId = null, PreviousId = 9, PreviousTitle = "The False Witness", PreviousUrl = "/dilemma/false-witness" } }
            };
            return navigation.GetValueOrDefault(dilemmaId);
        }
    }

    public class DilemmaNavigation
    {
        public int DilemmaId { get; set; }
        public int? NextId { get; set; }
        public int? PreviousId { get; set; }
        public string? NextTitle { get; set; }
        public string? PreviousTitle { get; set; }
        public string? NextUrl { get; set; }
        public string? PreviousUrl { get; set; }
    }
}
