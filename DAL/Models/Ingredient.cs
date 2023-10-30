using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public enum Ingredient
    {
        [Description("Бамія")]
        Okra = 1,
        [Description("Боби")]
        Beans,
        [Description("Горох зелений")]
        GreenPeas,
        [Description("Горох стручковий")]
        SnapPeas,
        [Description("Горох сушений")]
        DriedPeas,
        [Description("Горошок консервований")]
        CannedPeas,
        [Description("Квасоля")]
        KidneyBeans,
        [Description("Квасоля біла")]
        WhiteBeans,
        [Description("Квасоля консервована")]
        CannedBeans,
        [Description("Квасоля спаржева")]
        AsparagusBeans,
        [Description("Квасоля стручкова")]
        StringBeans,
        [Description("Квасоля червона")]
        RedBeans,
        [Description("Квасоля чорна")]
        BlackBeans,
        [Description("Квасоля чорне око")]
        BlackEyedPeas,
        [Description("Маш")]
        MungBeans,
        [Description("Нут")]
        Chickpeas,
        [Description("Нут консервований")]
        CannedChickpeas,
        [Description("Сочевиця")]
        Lentils,
        [Description("Сочевиця жовта")]
        YellowLentils,
        [Description("Сочевиця пророщена")]
        SproutedLentils,
        [Description("Сочевиця червона")]
        RedLentils,
        [Description("Соя пророщена")]
        SproutedSoybeans,
        [Description("Суміш бобових")]
        MixedBeans,
        [Description("Бісквіт")]
        Biscuit,
        [Description("Бісквіт Шоколадний")]
        ChocolateBiscuit,
        [Description("Багет")]
        Baguette,
        [Description("Багет Французький")]
        FrenchBaguette,
        [Description("Батон")]
        Loaf,
        [Description("Батон Білий")]
        WhiteLoaf,
        [Description("Бублики")]
        Bagels,
        [Description("Булочки")]
        Rolls,
        [Description("Булочки Для Бургерів")]
        BurgerBuns,
        [Description("Булочки Пшеничні")]
        WheatBuns,
        [Description("Вафельні Трубочки")]
        WaffleTubes,
        [Description("Вафлі")]
        Waffles,
        [Description("Вафлі Шоколадні")]
        ChocolateWaffles,
        [Description("Заготовки Бісквітні")]
        BiscuitBlanks,
        [Description("Корж Бісквітний")]
        BiscuitCakeLayer,
        [Description("Коржі Вафельні")]
        WaffleLayers,
        [Description("Коржі Медові")]
        HoneyCakeLayers,
        [Description("Коржі Торта Наполеон")]
        NapoleonCakeLayers,
        [Description("Коржі Шоколадні")]
        ChocolateCakeLayers,
        [Description("Кошики Вафельні")]
        WaffleBaskets,
        [Description("Крекер")]
        Cracker,
        [Description("Крекер Ванільний")]
        VanillaCracker,
        [Description("Крекер З Маком")]
        PoppySeedCracker,
        [Description("Крекер Солоний")]
        SaltedCracker,
        [Description("Крекери Шоколадні")]
        ChocolateCrackers,
        [Description("Крутони")]
        Croutons,
        [Description("Лаваш Вірменський")]
        ArmenianLavash,
        [Description("Млинці")]
        Pancakes,
        [Description("Млинчики")]
        PancakeRolls,
        [Description("Налисники")]
        Crepes,
        [Description("Опара")]
        SpongeDough,
        [Description("Основа Для Тартів")]
        TartBase,
        [Description("Піта")]
        PitaBread,
        [Description("Паска")]
        PaskaBread,
        [Description("Соломка")]
        Straw,
        [Description("Соломка Солена")]
        SaltedStraw,
        [Description("Сухарі")]
        Rusks,
        [Description("Сухарі Білі")]
        WhiteRusks,
        [Description("Сухарі Житні")]
        RyeRusks,
        [Description("Сухарі Мелені")]
        GroundRusks,
        [Description("Сухарі Панірувальні")]
        BreadingCrackers,
        [Description("Сухарики Пшеничні")]
        WheatCrackers,
        [Description("Тісто")]
        Dough,
        [Description("Тісто Бісквітне")]
        BiscuitDough,
        [Description("Тісто Для Пельменів")]
        DumplingDough,
        [Description("Тісто Дріжджове")]
        YeastDough,
        [Description("Тісто Заварне")]
        ChouxPastry,
        [Description("Тісто Листкове")]
        PuffPastry,
        [Description("Тісто Пісочне")]
        ShortcrustPastry,
        [Description("Тісто Філо")]
        PhylloPastry,
        [Description("Тако Кукурудзяні")]
        CornTacos,
        [Description("Тарталетки")]
        Tartlets,
        [Description("Тортилья")]
        Tortilla,
        [Description("Тортилья Пшенична")]
        WheatTortilla,
        [Description("Тости")]
        Toasts,
        [Description("Хліб")]
        Bread,
        [Description("Хліб Білий")]
        WhiteBread,
        [Description("Хліб Житній")]
        RyeBread,
        [Description("Хліб Пшеничний")]
        WheatBread,
        [Description("Хліб Тостовий")]
        ToastBread,
        [Description("Хліб Чорний")]
        BlackBread,
        [Description("Хлібні Крихти")]
        BreadCrumbs,
        [Description("Хлібці")]
        Buns,
        [Description("Хрустик З Маком")]
        CrunchesWithPoppySeed,
        [Description("Чіабатта")]
        Ciabatta,
        [Description("Бульйон")]
        Broth,
        [Description("Бульйон Грибний")]
        MushroomBroth,
        [Description("Бульйон Курячий")]
        ChickenBroth,
        [Description("Бульйон М'ясний")]
        MeatBroth,
        [Description("Бульйон Овочевий")]
        VegetableBroth,
        [Description("Бульйон Рибний")]
        FishBroth,
        [Description("Бульйон Яловичий")]
        BeefBroth,
        [Description("Відвар Картопляний")]
        PotatoBoil,
        [Description("Суміш Хондаши")]
        HondashiMix,
        [Description("Арахіс")]
        Peanuts,
        [Description("Арахіс Смажений")]
        RoastedPeanuts,
        [Description("Борошно Мигдальне")]
        AlmondFlour,
        [Description("Горіхи")]
        Nuts,
        [Description("Горіхи Волоські")]
        Walnuts,
        [Description("Горіхи Кедрові")]
        PineNuts,
        [Description("Горіхи Кешью")]
        Cashews,
        [Description("Горіхи Пекан")]
        Pecans,
        [Description("Каштани")]
        Chestnuts,
        [Description("Кунжут")]
        SesameSeeds,
        [Description("Кунжут Білий")]
        WhiteSesameSeeds,
        [Description("Кунжут Чорний")]
        BlackSesameSeeds,
        [Description("Льон Мелений")]
        GroundFlaxseeds,
        [Description("Мак")]
        PoppySeed,
        [Description("Мигдаль")]
        Almonds,
        [Description("Мигдаль Мелений")]
        GroundAlmonds,
        [Description("Насіння Гарбуза")]
        PumpkinSeeds,
        [Description("Насіння Льону")]
        Flaxseeds,
        [Description("Насіння Соняшникове")]
        SunflowerSeeds,
        [Description("Паста Арахісова")]
        PeanutButter,
        [Description("Паста Тахінна")]
        TahiniPaste,
        [Description("Пластівці Мигдалеві")]
        AlmondSlices,
        [Description("Суміш Насіння")]
        SeedMix,
        [Description("Фісташки")]
        Pistachios,
        [Description("Фундук")]
        Hazelnuts,
        [Description("Артишоки")]
        Artichokes,
        [Description("Бадилля Бурякове")]
        BeetrootStems,
        [Description("Базилік")]
        Basil,
        [Description("Базилік Зелений")]
        GreenBasil,
        [Description("Базилік Лимонний")]
        LemonBasil,
        [Description("Базилік Фіолетовий")]
        PurpleBasil,
        [Description("Бок Чой")]
        BokChoy,
        [Description("Естрагон")]
        Tarragon,
        [Description("Зелень")]
        Greens,
        [Description("Зелень Фенхеля")]
        FennelGreens,
        [Description("Кінза")]
        Cilantro,
        [Description("Квіти Бузини Сушені")]
        DriedElderflower,
        [Description("Квіти Кульбаби")]
        DandelionFlowers,
        [Description("Квіти Липи")]
        LindenFlowers,
        [Description("Китайська Цибуля Порей")]
        ChineseLeek,
        [Description("Коріандр")]
        Coriander,
        [Description("Котовник")]
        Plantain,
        [Description("Кріп")]
        Cress,
        [Description("Крес-салат")]
        Watercress,
        [Description("Кропива")]
        Nettle,
        [Description("Лемонграс")]
        Lemongrass,
        [Description("Листя Буряка")]
        BeetLeaves,
        [Description("Листя Виноградне")]
        GrapeLeaves,
        [Description("Листя Вишні")]
        CherryLeaves,
        [Description("Листя Кульбаби")]
        DandelionLeaves,
        [Description("Листя Малини")]
        RaspberryLeaves,
        [Description("Листя Мандарина")]
        MandarinLeaves,
        [Description("Листя Смородини")]
        BlackcurrantLeaves,
        [Description("Листя Хрону")]
        SwissChard,
        [Description("Лобода")]
        Orach,
        [Description("Любисток")]
        Lovage,
        [Description("М'ята")]
        Mint,
        [Description("Майоран")]
        Marjoram,
        [Description("Мангольд")]
        Mangold,
        [Description("Меліса")]
        LemonBalm,
        [Description("Нагідки")]
        Salsify,
        [Description("Орегано")]
        Oregano,
        [Description("Пагони Бамбука Консервовані")]
        CannedBambooShoots,
        [Description("Паростки Бамбуку")]
        BambooShoots,
        [Description("Пеларгонія Ароматна")]
        ScentedGeranium,
        [Description("Петрушка")]
        Parsley,
        [Description("Петрушка Кучерява")]
        CurlyParsley,
        [Description("Пюре Шпинатне")]
        SpinachPuree,
        [Description("Ревінь")]
        Rhubarb,
        [Description("Розмарин")]
        Rosemary,
        [Description("Ромашка")]
        Chamomile,
        [Description("Рукола")]
        Arugula,
        [Description("Салат")]
        Lettuce,
        [Description("Салат Айсберг")]
        IcebergLettuce,
        [Description("Салат Ендивій")]
        EndiveLettuce,
        [Description("Салат Корн")]
        Cresson,
        [Description("Салат Латук")]
        Lattuce,
        [Description("Салат Лолло Біондо")]
        LolloBiondoLettuce,
        [Description("Салат Лолло Россо")]
        LolloRossoLettuce,
        [Description("Салат Радічіо")]
        RadicchioLettuce,
        [Description("Салат Романо")]
        RomanoLettuce,
        [Description("Салат Ромен")]
        RomaineLettuce,
        [Description("Салат Фрізе")]
        FriséeLettuce,
        [Description("Салат Червоний")]
        RedLettuce,
        [Description("Селера")]
        Celery,
        [Description("Селера Черешкова")]
        Celeriac,
        [Description("Стебло Буряка")]
        BeetrootStem,
        [Description("Тим'ян")]
        Thyme,
        [Description("Трави")]
        Herbs,
        [Description("Хвоя Сосни")]
        PineNeedles,
        [Description("Цибуля Зелена")]
        GreenOnion,
        [Description("Цибуля Молода")]
        YoungOnion,
        [Description("Цибуля Порей")]
        Leek,
        [Description("Цикорій Салатний")]
        Chicory,
        [Description("Чабер")]
        Savory,
        [Description("Чебрець")]
        Savory2,
        [Description("Черемша")]
        BearsGarlic,
        [Description("Чорнобривці")]
        Butterbur,
        [Description("Шавлія")]
        Sage,
        [Description("Шніт-цибуля")]
        Chives,
        [Description("Шпинат")]
        Spinach,
        [Description("Щавель")]
        Sorrel,
        [Description("Ялівець")]
        Juniper,
        [Description("Nutella")]
        Nutella,
        [Description("Іриски")]
        Irisks,
        [Description("Агар-агар")]
        AgarAgar,
        [Description("Барвник жовтий")]
        YellowDye,
        [Description("Барвник червоний")]
        RedDye,
        [Description("Барвники харчові")]
        FoodDyes,
        [Description("Батончики шоколадні")]
        ChocolateBars,
        [Description("Глазур")]
        Glaze,
        [Description("Глазур шоколадна")]
        ChocolateGlaze,
        [Description("Горіхи в шоколаді")]
        NutsInChocolate,
        [Description("Грильяж")]
        Nougat,
        [Description("Драже кольорове")]
        ColoredDragee,
        [Description("Желе апельсинове")]
        OrangeJelly,
        [Description("Желе безбарвне")]
        ClearJelly,
        [Description("Желе вишневе")]
        CherryJelly,
        [Description("Желе кольорове")]
        ColoredJelly,
        [Description("Желе лимонне")]
        LemonJelly,
        [Description("Желе малинове")]
        RaspberryJelly,
        [Description("Желе персикове")]
        PeachJelly,
        [Description("Желе полуничне")]
        StrawberryJelly,
        [Description("Желе фруктове")]
        FruitJelly,
        [Description("Загущувач для варення")]
        JamThickener,
        [Description("Загущувач для вершків")]
        CreamThickener2,
        [Description("Загущувач для сметани")]
        SourCreamThickener,
        [Description("Загущувач крему")]
        CreamThickener,
        [Description("Зефір")]
        Marshmallow,
        [Description("Какао")]
        Cocoa,
        [Description("Какао темне")]
        DarkCocoa,
        [Description("Кандурін")]
        Candurin,
        [Description("Карамель")]
        Caramel,
        [Description("Карамель рідка")]
        LiquidCaramel,
        [Description("Кисіль")]
        Jelly,
        [Description("Кисіль апельсиновий")]
        OrangeJelly2,
        [Description("Кисіль вершковий")]
        CreamJelly,
        [Description("Кисіль вишневий")]
        CherryJelly2,
        [Description("Кисіль розчинний")]
        InstantJelly,
        [Description("Кисіль фруктовий")]
        FruitJelly2,
        [Description("Кондитерська посипка")]
        ConfectionerSprinkles,
        [Description("Крем")]
        Cream,
        [Description("Крем вершковий")]
        WhippedCream,
        [Description("Крем заварний")]
        CustardCream,
        [Description("Крем кондитерський")]
        ConfectionerCream,
        [Description("Крем масляний")]
        ButterCream,
        [Description("Крем сметанний")]
        SourCream,
        [Description("Кульки Несквік")]
        NesquikCereal,
        [Description("Кульки цукрові срібні")]
        SilverSugarBalls,
        [Description("Мармелад")]
        Marmalade,
        [Description("Мармелад абрикосовий")]
        ApricotMarmalade,
        [Description("Мармелад апельсиновий")]
        OrangeMarmalade,
        [Description("Марципан")]
        Marzipan,
        [Description("Маршмеллоу")]
        Marshmallow2,
        [Description("Мастика")]
        FondantIcing,
        [Description("Меренга")]
        Meringue,
        [Description("Морозиво")]
        IceCream,
        [Description("Палички кукурудзяні")]
        Cornsticks,
        [Description("Печиво")]
        Cookies,
        [Description("Печиво Oreo")]
        OreoCookies,
        [Description("Печиво бісквітне")]
        SpongeCookies,
        [Description("Печиво вівсяне")]
        OatmealCookies,
        [Description("Печиво галетне")]
        GaletteCookies,
        [Description("Печиво горіхове")]
        NutCookies,
        [Description("Печиво дульче де лече")]
        DulceDeLecheCookies,
        [Description("Печиво мигдальне")]
        AlmondCookies,
        [Description("Печиво пісочне")]
        ShortbreadCookies,
        [Description("Печиво шоколадне")]
        ChocolateCookies,
        [Description("Печиво-сендвіч з шоколадним кремом")]
        ChocolateCreamSandwichCookies,
        [Description("Посипка цукрова срібна")]
        SilverSugarSprinkles,
        [Description("Праліне")]
        Praline,
        [Description("Пудинг")]
        Pudding,
        [Description("Пудинг ванільний")]
        VanillaPudding,
        [Description("Пудинг шоколадний")]
        ChocolatePudding,
        [Description("Савоярді")]
        Ladyfingers,
        [Description("Сердечка шоколадні")]
        ChocolateHearts,
        [Description("Сироп червоного кольору")]
        RedSyrup,
        [Description("Топпінг")]
        Topping,
        [Description("Топпінг карамельний")]
        CaramelTopping,
        [Description("Трояндочки з желатинової мастики")]
        FondantRoses,
        [Description("Халва")]
        Halva,
        [Description("Халва ванільна")]
        VanillaHalva,
        [Description("Халва з арахісом")]
        PeanutHalva,
        [Description("Хрусткі шарики")]
        CrispyBalls,
        [Description("Цукерки")]
        Candies,
        [Description("Цукерки M&M's")]
        MAndMCandies,
        [Description("Цукерки «Рафаелло»")]
        RaffaelloCandies,
        [Description("Цукерки желейні")]
        JellyCandies,
        [Description("Цукерки карамельні")]
        CaramelCandies,
        [Description("Цукерки шоколадні")]
        ChocolateCandies,
        [Description("Цукрові олівці")]
        SugarPencils,
        [Description("Чіпси шоколадні")]
        ChocolateChips,
        [Description("Шоколад")]
        Chocolate,
        [Description("Шоколад After Eight")]
        AfterEightChocolate,
        [Description("Шоколад білий")]
        WhiteChocolate,
        [Description("Шоколад молочний")]
        MilkChocolate,
        [Description("Шоколад чорний")]
        DarkChocolate,
        [Description("Шоколадні краплі")]
        ChocolateDrops,
        [Description("Шоколадна помадка")]
        ChocolateIcing,
        [Description("Шоколадна стружка")]
        ChocolateShavings,
        [Description("Яйця шоколадні")]
        ChocolateEggs,
        [Description("борошно")]
        Flour,
        [Description("борошно вівсяне")]
        OatFlour,
        [Description("борошно горохове")]
        PeaFlour,
        [Description("борошно гречане")]
        BuckwheatFlour,
        [Description("борошно житнє")]
        RyeFlour,
        [Description("борошно з висівками")]
        BranFlour,
        [Description("борошно кукурудзяне")]
        CornFlour,
        [Description("борошно пшеничне")]
        WheatFlour,
        [Description("борошно рисове")]
        RiceFlour,
        [Description("борошно самосхідне")]
        SelfRisingFlour,
        [Description("борошно сочевичне")]
        LentilFlour,
        [Description("борошно хлібне")]
        BreadFlour,
        [Description("борошно цільнозернове")]
        WholeGrainFlour,
        [Description("булгур")]
        Bulgur,
        [Description("висівки")]
        Bran,
        [Description("висівки вівсяні")]
        OatBran,
        [Description("висівки житні")]
        RyeBran,
        [Description("висівки пшеничні")]
        WheatBran,
        [Description("зерна пшениці")]
        WheatGrains,
        [Description("каша")]
        Porridge,
        [Description("каша рисова")]
        RicePorridge,
        [Description("квіноа")]
        Quinoa,
        [Description("крохмаль")]
        Starch,
        [Description("крохмаль картопляний")]
        PotatoStarch,
        [Description("крохмаль кукурудзяний")]
        CornStarch,
        [Description("крупа вівсяна")]
        OatGrits,
        [Description("крупа гречана")]
        BuckwheatGrits,
        [Description("крупа кукурудзяна")]
        CornGrits,
        [Description("крупа манна")]
        Semolina,
        [Description("крупа перлова")]
        PearlBarley,
        [Description("крупа пшенична")]
        WheatGrits,
        [Description("крупа пшоняна")]
        SpeltGrits,
        [Description("кус-кус")]
        Couscous,
        [Description("пластівці")]
        Flakes,
        [Description("пластівці вівсяні")]
        OatFlakes,
        [Description("пластівці кукурудзяні")]
        CornFlakes,
        [Description("пластівці рисові")]
        RiceFlakes,
        [Description("полента")]
        Polenta,
        [Description("попкорн")]
        Popcorn,
        [Description("рис")]
        Rice,
        [Description("рис арборіо")]
        ArborioRice,
        [Description("рис басматі")]
        BasmatiRice,
        [Description("рис дикий")]
        WildRice,
        [Description("рис для суші")]
        SushiRice,
        [Description("рис довгозернистий")]
        LongGrainRice,
        [Description("рис круглозернистий")]
        ShortGrainRice,
        [Description("рис нероне")]
        NeroneRice,
        [Description("рис нешліфований")]
        UnpolishedRice,
        [Description("рис червоний")]
        RedRice,
        [Description("розпушувач тіста")]
        BakingPowder,
        [Description("сода харчова")]
        BakingSoda,
        [Description("солод")]
        Malt,
        [Description("толокно вівсяне")]
        OatGroat,
        [Description("чіпси кукурудзяні")]
        CornChips,
        [Description("балик свиний")]
        PorkHam,
        [Description("баранина")]
        Lamb,
        [Description("бастурма")]
        Basturma,
        [Description("бекон")]
        Bacon,
        [Description("бочок печений")]
        BakedLard,
        [Description("бочок свиний")]
        PorkLard,
        [Description("буженина")]
        BoiledPork,
        [Description("вирізка свиняча")]
        PorkCut,
        [Description("вирізка яловича")]
        BeefCut,
        [Description("грудинка свинна")]
        PorkBrisket,
        [Description("грудинка свинна копчена")]
        SmokedPorkBrisket,
        [Description("жир")]
        Fat,
        [Description("жир баранячий")]
        LambFat,
        [Description("жир свинячий")]
        PorkFat,
        [Description("жирова сітка")]
        PorkNet,
        [Description("кістки мозкові")]
        BrainBones,
        [Description("кістки свинячі")]
        PorkBones,
        [Description("кістки яловичі")]
        BeefBones,
        [Description("кишка шліфована")]
        GroundIntestines,
        [Description("кишки")]
        Intestines,
        [Description("ковбаса")]
        Sausage,
        [Description("ковбаса варена")]
        BoiledSausage,
        [Description("ковбаса домашня")]
        HomemadeSausage,
        [Description("ковбаса копчена")]
        SmokedSausage,
        [Description("ковбаса молочна")]
        MilkSausage,
        [Description("ковбаса напівкопчена")]
        SemiSmokedSausage,
        [Description("ковбаса салямі")]
        SalamiSausage,
        [Description("ковбаса свина сиров'ялена")]
        PorkRawSausage,
        [Description("ковбаса сервелат")]
        ServelatSausage,
        [Description("ковбаса шинкова")]
        SlicedSausage,
        [Description("ковбаски")]
        Sausages,
        [Description("ковбаски мисливські")]
        HunterSausages,
        [Description("ковбаски піколіни")]
        PiccoliniSausages,
        [Description("конина")]
        Horsemeat,
        [Description("копченості")]
        SmokedMeats,
        [Description("корейка копчена")]
        SmokedBelly,
        [Description("корейка на кістці")]
        BellyOnBone,
        [Description("корейка свина")]
        PorkBelly,
        [Description("кролик")]
        Rabbit,
        [Description("лівер")]
        Liver,
        [Description("легені")]
        Lungs,
        [Description("легені яловичі")]
        BeefLungs,
        [Description("лопатка яловича")]
        BeefChuck,
        [Description("м'ясні делікатеси")]
        MeatDelicacies,
        [Description("м'ясо")]
        Meat,
        [Description("м'ясо в'ялене")]
        DriedMeat,
        [Description("м'ясо кроляче")]
        RabbitMeat,
        [Description("м'ясо лосине")]
        Venison,
        [Description("м'ясо сиров'ялене")]
        RawMeat,
        [Description("мізки")]
        Sweetbread,
        [Description("мозок кістковий")]
        BrainOnBones,
        [Description("ніжки свинячі")]
        PorkFeet,
        [Description("нирки")]
        Kidneys,
        [Description("нога бараняча")]
        LambLeg,
        [Description("нога свинна")]
        PorkLeg,
        [Description("окіст свиний")]
        PorkSkin2,
        [Description("ошийок свиний")]
        PorkCollar,
        [Description("підчеревок")]
        PorkBelly2,
        [Description("паштет")]
        Pate,
        [Description("пельмені")]
        Dumplings,
        [Description("печінка")]
        Liver2,
        [Description("печінка кроляча")]
        RabbitLiver,
        [Description("печінка свинна")]
        PorkLiver,
        [Description("печінка теляча")]
        VealLiver,
        [Description("печінка яловича")]
        BeefLiver,
        [Description("подчеревок свиний")]
        PorkBelly3,
        [Description("прошутто")]
        Prosciutto,
        [Description("ребра баранячі")]
        LambRibs,
        [Description("ребра свинні")]
        PorkRibs,
        [Description("ребра свинні копчені")]
        SmokedPorkRibs,
        [Description("ребра телячі")]
        VealRibs,
        [Description("рулька свина")]
        PorkRoll,
        [Description("рулька яловича")]
        BeefRoll,
        [Description("сало")]
        Lard,
        [Description("сало копчене")]
        SmokedLard,
        [Description("сарделька")]
        Saveloy,
        [Description("свинина")]
        Pork,
        [Description("свиня")]
        Pig,
        [Description("серце")]
        Heart,
        [Description("серце свине")]
        PorkHeart,
        [Description("серце яловиче")]
        BeefHeart,
        [Description("смалець")]
        Greaves,
        [Description("солонина")]
        Salo,
        [Description("сосиски")]
        Sausages2,
        [Description("телятина")]
        Veal,
        [Description("телятина молода")]
        YoungVeal,
        [Description("тушонка яловича")]
        CannedBeef,
        [Description("фарш індичий")]
        TurkeyMince,
        [Description("фарш з баранини")]
        LambMince,
        [Description("фарш змішаний")]
        MixedMince,
        [Description("фарш котлетний")]
        CutletMince,
        [Description("фарш м'ясний")]
        MeatMince,
        [Description("фарш свинячий")]
        PorkMince,
        [Description("фарш свинячо-яловичий")]
        PorkBeefMince,
        [Description("фарш яловичий")]
        BeefMince,
        [Description("хамон")]
        Ham,
        [Description("хамон серрано")]
        SerranoHam,
        [Description("хвіст яловичий")]
        BeefTail,
        [Description("хлібець м'ясний")]
        Meatloaf,
        [Description("чорізо")]
        Chorizo,
        [Description("шийка свинна")]
        PorkNeck,
        [Description("шинка")]
        Ham2,
        [Description("шинка пармська")]
        ParmaHam,
        [Description("шинка сиров'ялена")]
        RawHam,
        [Description("шкіра свиняча")]
        PorkSkin,
        [Description("шкварки")]
        Cracklings,
        [Description("шпик")]
        BaconFat,
        [Description("щековина свинна")]
        PorkJowl,
        [Description("язик свиний")]
        PorkTongue,
        [Description("язик яловичий")]
        BeefTongue,
        [Description("яйця бичачі")]
        BisonEggs,
        [Description("яловичина")]
        Beef,
        [Description("вермішель")]
        Vermicelli,
        [Description("лазанья")]
        Lasagna,
        [Description("локшина гречана")]
        BuckwheatNoodles,
        [Description("локшина домашня")]
        HomemadeNoodles,
        [Description("локшина рисова")]
        RiceNoodles,
        [Description("локшина скляна")]
        GlassNoodles,
        [Description("локшина сомен")]
        SomenNoodles,
        [Description("локшина удон")]
        UdonNoodles,
        [Description("локшина фунчоза")]
        FunchozaNoodles,
        [Description("локшина яєчна")]
        EggNoodles,
        [Description("макарони")]
        Macaroni,
        [Description("макарони кольорові")]
        ColoredMacaroni,
        [Description("макарони мушлі")]
        ShellMacaroni,
        [Description("макарони рисові")]
        RiceMacaroni,
        [Description("макарони спіральки")]
        SpiralMacaroni,
        [Description("паста risini")]
        RisiniPasta,
        [Description("паста букатіні")]
        BucatiniPasta,
        [Description("паста каннеллоні")]
        CannelloniPasta,
        [Description("паста каппеллетті")]
        CappellettiPasta,
        [Description("паста конкільоні")]
        ConchiglioniPasta,
        [Description("паста лінгвіні")]
        LinguinePasta,
        [Description("паста мафальдіне")]
        MafaldinePasta,
        [Description("паста орзо")]
        OrzoPasta,
        [Description("паста пенне")]
        PennePasta,
        [Description("паста тальятелле")]
        TagliatellePasta,
        [Description("паста фарфалле")]
        FarfallePasta,
        [Description("паста фетучіні")]
        FettuccinePasta,
        [Description("паста фузілі")]
        FusilliPasta,
        [Description("спагетті")]
        Spaghetti,
        [Description("масло арахісове")]
        PeanutButter2,
        [Description("масло вершкове")]
        CreamButter,
        [Description("масло вершкове шоколадне")]
        ChocolateCreamButter,
        [Description("масло топлене")]
        Ghee,
        [Description("олія")]
        Oil,
        [Description("олія бавовняна")]
        CottonseedOil,
        [Description("олія виноградна")]
        GrapeSeedOil,
        [Description("олія гарбузова")]
        PumpkinSeedOil,
        [Description("олія горіхова")]
        NutOil,
        [Description("олія з базиліком")]
        BasilOil,
        [Description("олія кокосова")]
        CoconutOil,
        [Description("олія кукурудзяна")]
        CornOil,
        [Description("олія кунжутна")]
        SesameOil,
        [Description("олія лляна")]
        FlaxseedOil,
        [Description("олія оливкова")]
        OliveOil,
        [Description("олія ріпакова")]
        RapeseedOil,
        [Description("олія соняшникова")]
        SunflowerOil,
        [Description("суміш олій")]
        MixedOils,
        [Description("айран")]
        Ayran,
        [Description("вершки")]
        Cream2,
        [Description("вершки збиті")]
        WhippedCream2,
        [Description("вершки згущені")]
        CondensedCream,
        [Description("вершки сухі")]
        DryCream,
        [Description("дріжджі")]
        Yeast,
        [Description("дріжджі свіжі")]
        FreshYeast,
        [Description("дріжджі сухі")]
        DryYeast,
        [Description("закваска для приготування йогурту")]
        YogurtStarter,
        [Description("закуска \"Пікнік з грибним смаком\"")]
        MushroomSnack,
        [Description("йогурт")]
        Yogurt,
        [Description("йогурт грецький")]
        GreekYogurt,
        [Description("йогурт персиковий")]
        PeachYogurt,
        [Description("йогурт полуничний")]
        StrawberryYogurt,
        [Description("йогурт фруктовий")]
        FruitYogurt,
        [Description("кефір")]
        Kefir,
        [Description("крем-фреш")]
        CremeFraiche,
        [Description("маргарин")]
        Margarine,
        [Description("маслянка")]
        Oleomargarine,
        [Description("молоко")]
        Milk,
        [Description("молоко згущене")]
        CondensedMilk,
        [Description("молоко згущене варене")]
        SweetenedCondensedMilk,
        [Description("молоко кисле")]
        SourMilk,
        [Description("молоко незбиране")]
        UnskimmedMilk,
        [Description("молоко пряжене")]
        EvaporatedMilk,
        [Description("молоко сухе")]
        DryMilk,
        [Description("простокваша")]
        Buttermilk,
        [Description("ряжанка")]
        Ryazhenka,
        [Description("сир сметанковий")]
        CreamCheese,
        [Description("сироватка")]
        Whey,
        [Description("сметана")]
        SourCream2,
        [Description("сметана збита")]
        WhippedSourCream,
        [Description("тофу")]
        Tofu,
        [Description("водорості вакаме сушені")]
        DriedWakameSeaweed,
        [Description("восьминіг")]
        Octopus,
        [Description("кальмари")]
        Squid,
        [Description("каракатиця")]
        Cuttlefish,
        [Description("крабові палички")]
        CrabSticks,
        [Description("крабове м'ясо")]
        CrabMeat,
        [Description("креветки")]
        Shrimp,
        [Description("креветки тигрові")]
        TigerShrimp,
        [Description("м'ясо криля")]
        KrillMeat,
        [Description("мідії")]
        Mussels,
        [Description("мідії консервовані")]
        CannedMussels,
        [Description("морепродукти")]
        Seafood,
        [Description("морська капуста")]
        SeaLettuce,
        [Description("морський гребінець")]
        SeaUrchin,
        [Description("норі")]
        Nori,
        [Description("чорнило каракатиці")]
        CuttlefishInk,
        [Description("імбир")]
        Ginger,
        [Description("імбир тертий")]
        GratedGinger,
        [Description("авокадо")]
        Avocado,
        [Description("асорті овочеве мариноване")]
        AssortedPickledVegetables,
        [Description("баклажани")]
        Eggplants,
        [Description("батат")]
        SweetPotato,
        [Description("бруква")]
        Rutabaga,
        [Description("буряк")]
        Beetroot,
        [Description("буряк маринований")]
        PickledBeetroot,
        [Description("гарбуз")]
        Pumpkin,
        [Description("гарбуз баттернат")]
        ButternutSquash,
        [Description("гарбуз мускатних сортів")]
        MuscatPumpkin,
        [Description("даїкон")]
        DaikonRadish,
        [Description("засмажка овочева")]
        VegetableStirFry,
        [Description("кабачки")]
        Zucchini,
        [Description("каперси")]
        Capers,
        [Description("капуста")]
        Cabbage,
        [Description("капуста білокачанна")]
        WhiteCabbage,
        [Description("капуста броколі")]
        Broccoli,
        [Description("капуста брюсельська")]
        BrusselsSprouts,
        [Description("капуста квашена")]
        Sauerkraut,
        [Description("капуста кольрабі")]
        Kohlrabi,
        [Description("капуста маринована")]
        PickledCabbage,
        [Description("капуста пекінська")]
        NapaCabbage,
        [Description("капуста романеско")]
        RomanescoCabbage,
        [Description("капуста савойська")]
        SavoyCabbage,
        [Description("капуста тушкована")]
        BraisedCabbage,
        [Description("капуста цвітна")]
        Cauliflower,
        [Description("капуста червонокачанна")]
        RedCabbage,
        [Description("картопля")]
        Potato,
        [Description("картопля молода")]
        NewPotatoes,
        [Description("картопля фіолетова")]
        PurplePotatoes,
        [Description("картопля фрі")]
        FrenchFries,
        [Description("квіти кабачкові")]
        ZucchiniBlossoms,
        [Description("квіти цукіні")]
        CourgetteFlowers,
        [Description("колоказія")]
        Kohlrabi2,
        [Description("конкасе")]
        Concassé,
        [Description("корінь пастернака")]
        Parsnip,
        [Description("корінь петрушки")]
        ParsleyRoot,
        [Description("корінь селери")]
        Celeriac2,
        [Description("корінь фенхеля")]
        FennelRoot,
        [Description("корінь хрону")]
        HorseradishRoot,
        [Description("корнішони")]
        Gherkins,
        [Description("кукурудза")]
        Corn,
        [Description("кукурудза консервована")]
        CannedCorn,
        [Description("кукурудза маринована")]
        PickledCorn,
        [Description("морква")]
        Carrot,
        [Description("морква по-корейськи")]
        KoreanCarrots,
        [Description("морква сушена")]
        DriedCarrot,
        [Description("овочі")]
        Vegetables,
        [Description("овочі гриль")]
        GrilledVegetables,
        [Description("огірки")]
        Cucumbers,
        [Description("огірки малосольні")]
        LowSaltCucumbers,
        [Description("огірки мариновані")]
        PickledCucumbers,
        [Description("огірки солоні")]
        SaltedCucumbers,
        [Description("паприка")]
        BellPepper,
        [Description("патісони")]
        PattypanSquash,
        [Description("перець болгарський")]
        BellPepper2,
        [Description("перець болгарський маринований")]
        PickledBellPepper,
        [Description("перець гострий")]
        ChiliPepper,
        [Description("перець пірі-пірі маринований")]
        MarinatedChiliPepper,
        [Description("перець поблано")]
        PoblanoPepper,
        [Description("перець солодкий капі")]
        CapsicumPepper,
        [Description("перець солодкий сушений")]
        DriedSweetPepper,
        [Description("перець халапеньо")]
        JalapeñoPepper,
        [Description("перець чилі")]
        ChiliPepper2,
        [Description("перець чилі маринований")]
        MarinatedChiliPepper2,
        [Description("пюре гарбузове")]
        PumpkinPuree,
        [Description("пюре картопляне")]
        PotatoPuree,
        [Description("пюре морквяне")]
        CarrotPuree,
        [Description("пюре томатне")]
        TomatoPuree,
        [Description("ріпа біла")]
        WhiteTurnip,
        [Description("редис")]
        Radish,
        [Description("редька")]
        BlackRadish,
        [Description("редька біла")]
        WhiteRadish,
        [Description("серцевина пальми")]
        PalmHeart,
        [Description("спаржа")]
        Asparagus,
        [Description("томати")]
        Tomatoes,
        [Description("томати в'ялені")]
        SunDriedTomatoes,
        [Description("томати жовті")]
        YellowTomatoes,
        [Description("томати зелені")]
        GreenTomatoes,
        [Description("томати консервовані")]
        CannedTomatoes,
        [Description("томати сушені")]
        DriedTomatoes,
        [Description("томати черрі")]
        CherryTomatoes,
        [Description("топінамбур")]
        JerusalemArtichoke,
        [Description("хрін тертий")]
        GratedHorseradish,
        [Description("цибулеве лушпиння")]
        OnionSkin,
        [Description("цибуля перлинна")]
        PearlOnion,
        [Description("цибуля ріпчаста")]
        Onion,
        [Description("цибуля ріпчаста біла")]
        WhiteOnion,
        [Description("цибуля ріпчаста маринована")]
        PickledOnion,
        [Description("цибуля ріпчаста червона")]
        RedOnion,
        [Description("цибуля-шалот")]
        Shallot,
        [Description("цукіні")]
        Zucchini2,
        [Description("чіпси")]
        Chips,
        [Description("часник")]
        Garlic,
        [Description("часник молодий")]
        YoungGarlic,
        [Description("часникова паста")]
        GarlicPaste,
        [Description("маслини")]
        Olives,
        [Description("оливки")]
        Pickles,
        [Description("оливки з креветками")]
        OlivesWithShrimp,
        [Description("оливки зелені")]
        GreenOlives,
        [Description("індик")]
        Turkey,
        [Description("голуб")]
        Pigeon,
        [Description("гомілка індички")]
        TurkeyDrumstick,
        [Description("грудка качина")]
        DuckBreast,
        [Description("грудки курячі")]
        ChickenBreasts,
        [Description("гусак")]
        Goose,
        [Description("жир качиний")]
        DuckFat,
        [Description("каплун")]
        Capon,
        [Description("качка")]
        Duck,
        [Description("крила індички")]
        TurkeyWings,
        [Description("крильця курячі")]
        ChickenWings,
        [Description("курка")]
        Hen,
        [Description("курка копчена")]
        SmokedChicken,
        [Description("курка-гриль")]
        GrilledChicken,
        [Description("курча")]
        Chick,
        [Description("лапи курячі")]
        ChickenFeet,
        [Description("ніжки качині")]
        DuckFeet,
        [Description("ніжки курячі")]
        ChickenDrumsticks,
        [Description("окорочка курячі")]
        ChickenDrumstick,
        [Description("окорочка курячі копчені")]
        SmokedChickenDrumstick,
        [Description("півень")]
        Rooster,
        [Description("паштет гусячий")]
        GoosePate,
        [Description("перепела")]
        Quail,
        [Description("печінка індички")]
        TurkeyLiver,
        [Description("печінка куряча")]
        ChickenLiver,
        [Description("печінку гусяча")]
        GooseLiver,
        [Description("потроха гусячі")]
        GooseInnards,
        [Description("сало качине")]
        DuckFat2,
        [Description("серця курячі")]
        ChickenHearts,
        [Description("стегна курячі")]
        ChickenThighs,
        [Description("стегно індиче")]
        TurkeyThigh,
        [Description("тельбухи курячі")]
        ChickenGizzards,
        [Description("філе індиче")]
        TurkeyFillet,
        [Description("філе гусяче")]
        GooseFillet,
        [Description("філе качине")]
        DuckFillet,
        [Description("філе куряче")]
        ChickenFillet,
        [Description("фазан")]
        Pheasant,
        [Description("фарш курячий")]
        ChickenMincedMeat,
        [Description("шкура куряча")]
        ChickenSkin,
        [Description("шлунки гусячі")]
        GooseGizzards,
        [Description("шлунки курячі")]
        ChickenGizzards2,
        [Description("ікра мойви")]
        CapelinRoe,
        [Description("ікра риби")]
        FishRoe,
        [Description("ікра червона")]
        RedCaviar,
        [Description("ікра чорна")]
        BlackCaviar,
        [Description("анчоуси")]
        Anchovies,
        [Description("анчоуси в олії")]
        AnchoviesInOil,
        [Description("бакалау")]
        Bacalao,
        [Description("барабулька")]
        Dace,
        [Description("бички")]
        Bulls,
        [Description("вугор")]
        Eel,
        [Description("горбуша")]
        HumpbackSalmon,
        [Description("густера")]
        Whiting,
        [Description("дорада")]
        Dorado,
        [Description("жерех")]
        IdeFish,
        [Description("камбала")]
        Flounder,
        [Description("карась")]
        Crucian,
        [Description("кета копчена")]
        SmokedKetaSalmon,
        [Description("кефаль")]
        Mullet,
        [Description("килька")]
        Herring,
        [Description("конгріо")]
        Congrio,
        [Description("консерва рибна")]
        CannedFish,
        [Description("короп")]
        Carp,
        [Description("лосось")]
        Salmon,
        [Description("лосось консервований")]
        CannedSalmon,
        [Description("лосось копчений")]
        SmokedSalmon,
        [Description("лосось солоний")]
        SaltedSalmon,
        [Description("лящ")]
        Bream,
        [Description("мойва")]
        Capelin,
        [Description("морський окунь")]
        SeaBass,
        [Description("набір суповий з сьомги")]
        SalmonSoupSet,
        [Description("нототенія")]
        Notothenia,
        [Description("окунь")]
        Perch,
        [Description("оселедець")]
        Sprat,
        [Description("оселедець слабосолений")]
        LightlySaltedSprat,
        [Description("оселедець солений")]
        SaltedSprat,
        [Description("осетер")]
        Sturgeon,
        [Description("пікша")]
        Burbot,
        [Description("пангасіус")]
        Pangasius,
        [Description("пеленгас")]
        Pelengas,
        [Description("печінка тріски")]
        CodLiver,
        [Description("раки")]
        Crayfish,
        [Description("ракові шийки")]
        CrawfishTails,
        [Description("риба")]
        Fish,
        [Description("риба копчена")]
        SmokedFish,
        [Description("риба морська")]
        SeaFish,
        [Description("риба слабосолона")]
        LightlySaltedFish,
        [Description("риба червона")]
        RedFish,
        [Description("рибні палички")]
        FishSticks,
        [Description("сібас")]
        Seabass,
        [Description("сайра")]
        Saury,
        [Description("сардини")]
        Sardines,
        [Description("сардини консервовані")]
        CannedSardines,
        [Description("скумбрія")]
        Mackerel,
        [Description("скумбрія консервована")]
        CannedMackerel,
        [Description("скумбрія копчена")]
        SmokedMackerel,
        [Description("скумбрія маринована")]
        MarinatedMackerel,
        [Description("ставрида")]
        HorseMackerel,
        [Description("ставрида консервована")]
        CannedHorseMackerel,
        [Description("стейки лососевих риб")]
        SalmonSteaks,
        [Description("стерлядь")]
        Sterlet,
        [Description("судак")]
        Zander,
        [Description("сьомга")]
        Salmon2,
        [Description("сьомга солена")]
        SaltedSalmon2,
        [Description("тріска")]
        Pollock,
        [Description("тріска норвезька")]
        NorwegianPollock,
        [Description("тунець")]
        Tuna,
        [Description("тунець консервований")]
        CannedTuna,
        [Description("філе анчоусів")]
        AnchovyFillet,
        [Description("філе білої риби")]
        WhiteFishFillet,
        [Description("філе глоси")]
        HaddockFillet,
        [Description("філе лосося")]
        SalmonFillet,
        [Description("філе минтая")]
        HakeFillet,
        [Description("філе морського окуня")]
        SeaBassFillet,
        [Description("філе окуня")]
        PerchFillet,
        [Description("філе оселедця")]
        SpratFillet,
        [Description("філе пікші")]
        BurbotFillet,
        [Description("філе пангасіуса")]
        PangasiusFillet,
        [Description("філе риби")]
        FishFillet,
        [Description("філе солеї")]
        SoleFillet,
        [Description("філе сома")]
        CatfishFillet,
        [Description("філе судака")]
        ZanderFillet,
        [Description("філе сьомги")]
        SalmonFillet2,
        [Description("філе тілапії")]
        TilapiaFillet,
        [Description("філе товстолоба")]
        CatfishFillet2,
        [Description("філе тріски")]
        PollockFillet,
        [Description("філе форелі")]
        TroutFillet,
        [Description("філе хека")]
        HakeFillet2,
        [Description("філе червоної риби")]
        RedFishFillet,
        [Description("філе щуки")]
        PikeFillet,
        [Description("фарш рибний")]
        FishMince,
        [Description("форель")]
        Trout,
        [Description("форель річкова")]
        RiverTrout,
        [Description("хек")]
        Hake,
        [Description("шпроти")]
        Sprats,
        [Description("шпроти консервовані")]
        CannedSprats,
        [Description("щука")]
        Pike,
        [Description("язь")]
        Zander2,
        [Description("бринза")]
        FetaCheese,
        [Description("бринза болгарська")]
        BulgarianFetaCheese,
        [Description("крем-сир")]
        CreamCheese2,
        [Description("сир імеретінський")]
        ImeretianCheese,
        [Description("сир адигейський")]
        AdygheCheese,
        [Description("сир блакитний")]
        BlueCheese,
        [Description("сир брі")]
        BrieCheese,
        [Description("сир будз")]
        BudzCheese,
        [Description("сир в пластинах")]
        SlicedCheese,
        [Description("сир вершковий")]
        CreamCheese3,
        [Description("сир гауда")]
        GoudaCheese,
        [Description("сир голландський")]
        DutchCheese,
        [Description("сир горгонзола")]
        GorgonzolaCheese,
        [Description("сир грюйер")]
        GruyereCheese,
        [Description("сир домашній")]
        HomemadeCheese,
        [Description("сир дорблю")]
        DorbluCheese,
        [Description("сир з блакитною цвіллю")]
        CheeseWithBlueMold,
        [Description("сир з пліснявою")]
        MoldCheese,
        [Description("сир камамбер")]
        CamembertCheese,
        [Description("сир кисломолочний")]
        SourMilkCheese,
        [Description("сир ковбасний")]
        SausageCheese,
        [Description("сир козиний")]
        GoatCheese,
        [Description("сир копчений")]
        SmokedCheese,
        [Description("сир м'який")]
        SoftCheese,
        [Description("сир м'який солений")]
        SoftSaltedCheese,
        [Description("сир мімолетте")]
        MimoletteCheese,
        [Description("сир маасдам")]
        MaasdamCheese,
        [Description("сир маскарпоне")]
        MascarponeCheese,
        [Description("сир молочний")]
        MilkCheese,
        [Description("сир моцарела")]
        MozzarellaCheese,
        [Description("сир напівтвердий")]
        SemiHardCheese,
        [Description("сир осетинський")]
        OssetianCheese,
        [Description("сир пікантний")]
        SpicyCheese,
        [Description("сир панір")]
        PaneerCheese,
        [Description("сир пармезан")]
        ParmesanCheese,
        [Description("сир пекоріно романо")]
        PecorinoRomanoCheese,
        [Description("сир плавлений")]
        ProcessedCheese,
        [Description("сир проволоне")]
        ProvoloneCheese,
        [Description("сир рікотта")]
        RicottaCheese,
        [Description("сир російський")]
        RussianCheese,
        [Description("сир солоний м'який")]
        SaltedSoftCheese,
        [Description("сир стілтон")]
        StiltonCheese,
        [Description("сир сулугуні")]
        SuluguniCheese,
        [Description("сир твердий")]
        HardCheese,
        [Description("сир том")]
        TomCheese,
        [Description("сир філадельфія")]
        PhiladelphiaCheese,
        [Description("сир фета")]
        FetaCheese2,
        [Description("сир чеддер")]
        CheddarCheese,
        [Description("сирна маса")]
        CheeseMass,
        [Description("сирок творожний")]
        CurdCheese,
        [Description("аджика")]
        Adjika,
        [Description("варення")]
        Jam,
        [Description("варення абрикосове")]
        ApricotJam,
        [Description("варення айвове")]
        QuinceJam,
        [Description("варення вишневе")]
        CherryJam,
        [Description("варення журавлинове")]
        CranberryJam,
        [Description("варення з пелюстків сакури")]
        SakuraPetalJam,
        [Description("варення калинове")]
        ViburnumJam,
        [Description("варення малинове")]
        RaspberryJam,
        [Description("варення полуничне")]
        StrawberryJam,
        [Description("варення смородинове")]
        CurrantJam,
        [Description("варення трояндове")]
        RoseJam,
        [Description("варення чорничне")]
        BlueberryJam,
        [Description("варення яблучне")]
        AppleJam,
        [Description("васабі")]
        Wasabi,
        [Description("гірчиця")]
        Mustard,
        [Description("гірчиця європейська")]
        EuropeanMustard,
        [Description("гірчиця американська")]
        AmericanMustard,
        [Description("гірчиця англійська")]
        EnglishMustard,
        [Description("гірчиця діжонська")]
        DijonMustard,
        [Description("гірчиця з зернами")]
        GrainyMustard,
        [Description("гірчиця французька")]
        FrenchMustard,
        [Description("джем")]
        Jam2,
        [Description("джем абрикосовий")]
        ApricotJam2,
        [Description("джем апельсиновий")]
        OrangeJam,
        [Description("джем вишневий")]
        CherryJam2,
        [Description("джем малиновий")]
        RaspberryJam2,
        [Description("джем полуничний")]
        StrawberryJam2,
        [Description("джем сливовий")]
        PlumJam,
        [Description("джем червоносмородиновий")]
        RedCurrantJam,
        [Description("джем чорносмородиновий")]
        BlackCurrantJam,
        [Description("джем яблучний")]
        AppleJam2,
        [Description("закваска")]
        StarterCulture,
        [Description("закваска для журека")]
        ZurekStarter,
        [Description("закваска житня")]
        RyeStarter,
        [Description("закваска натуральна")]
        NaturalStarter,
        [Description("кетчуп")]
        Ketchup,
        [Description("конфітюр")]
        Confiture,
        [Description("конфітюр абрикосовий")]
        ApricotConfiture,
        [Description("конфітюр апельсиновий")]
        OrangeConfiture,
        [Description("конфітюр малиновий")]
        RaspberryConfiture,
        [Description("курд лимонний")]
        LemonCurd,
        [Description("майонез")]
        Mayonnaise,
        [Description("маринад")]
        Marinade,
        [Description("мед")]
        Honey,
        [Description("мед гречаний")]
        BuckwheatHoney,
        [Description("мед липовий")]
        LindenHoney,
        [Description("мед рідкий")]
        LiquidHoney,
        [Description("мед світлий")]
        LightHoney,
        [Description("мед темний")]
        DarkHoney,
        [Description("оцет")]
        Vinegar,
        [Description("оцет бальзамічний")]
        BalsamicVinegar,
        [Description("оцет бальзамічний білий")]
        WhiteBalsamicVinegar,
        [Description("оцет винний")]
        WineVinegar,
        [Description("оцет винний білий")]
        WhiteWineVinegar,
        [Description("оцет винний темний")]
        DarkWineVinegar,
        [Description("оцет винний червоний")]
        RedWineVinegar,
        [Description("оцет лимонний")]
        LemonVinegar,
        [Description("оцет рисовий")]
        RiceVinegar,
        [Description("оцет столовий")]
        TableVinegar,
        [Description("оцет хересний")]
        SherryVinegar,
        [Description("оцет яблучний")]
        AppleVinegar,
        [Description("паста соєва")]
        SoySauce,
        [Description("паста Том Ям")]
        TomYumPaste,
        [Description("паста томатна")]
        TomatoPaste,
        [Description("повидло")]
        FruitButter,
        [Description("повидло абрикосове")]
        ApricotButter,
        [Description("повидло сливове")]
        PlumButter,
        [Description("повидло яблучне")]
        AppleButter,
        [Description("рідкий дим")]
        LiquidSmoke,
        [Description("розсіл")]
        Brine,
        [Description("розсіл огірковий")]
        PicklingBrine,
        [Description("сальса томатна")]
        TomatoSalsa,
        [Description("сироп 'Лісовий горіх'")]
        HickorySyrup,
        [Description("сироп інвертний")]
        InvertSyrup,
        [Description("сироп абрикосовий")]
        ApricotSyrup,
        [Description("сироп вишневий")]
        CherrySyrup,
        [Description("сироп глюкози")]
        GlucoseSyrup,
        [Description("сироп гренадін")]
        GrenadineSyrup,
        [Description("сироп з-під ананасів")]
        PineappleSyrup,
        [Description("сироп калиновий")]
        ViburnumSyrup,
        [Description("сироп кленовий")]
        Maple,
        [Description("сироп кукурудзяний")]
        CornSyrup,
        [Description("сироп малиновий")]
        RaspberrySyrup,
        [Description("сироп полуничний")]
        StrawberrySyrup,
        [Description("сироп порічковий")]
        CurrantSyrup,
        [Description("сироп суничний")]
        BlueberrySyrup,
        [Description("сироп фруктовий")]
        FruitSyrup,
        [Description("сироп цукровий")]
        SugarSyrup,
        [Description("сироп чорничний")]
        BilberrySyrup,
        [Description("сироп шоколадний")]
        ChocolateSyrup,
        [Description("сироп ягідний")]
        BerrySyrup,
        [Description("соус")]
        Sauce,
        [Description("соус азіатський")]
        AsianSauce,
        [Description("соус айолі")]
        AioliSauce,
        [Description("соус бальзамік")]
        BalsamicSauce,
        [Description("соус бешамель")]
        BechamelSauce,
        [Description("соус вустерський")]
        WorcestershireSauce,
        [Description("соус гірчичний")]
        MustardSauce,
        [Description("соус гранатовий")]
        PomegranateSauce,
        [Description("соус грибний")]
        MushroomSauce,
        [Description("соус демі глас")]
        DemiGlaceSauce,
        [Description("соус до спагетті")]
        SpaghettiSauce,
        [Description("соус кімчі")]
        KimchiSauce,
        [Description("соус маринара")]
        MarinaraSauce,
        [Description("соус мексиканський")]
        MexicanSauce,
        [Description("соус перцевий")]
        PepperSauce,
        [Description("соус рагу")]
        RagoutSauce,
        [Description("соус рибний")]
        FishSauce,
        [Description("соус сирний")]
        CheeseSauce,
        [Description("соус соєвий")]
        SoySauce2,
        [Description("соус сукіякі")]
        SukiyakiSauce,
        [Description("соус табаско")]
        TabascoSauce,
        [Description("соус тартар")]
        TartarSauce,
        [Description("соус теріякі")]
        TeriyakiSauce,
        [Description("соус ткемалі")]
        TkemaliSauce,
        [Description("соус томатний")]
        TomatoSauce,
        [Description("соус устричний")]
        OysterSauce,
        [Description("соус часниковий")]
        GarlicSauce,
        [Description("соус чилі")]
        ChiliSauce,
        [Description("соус-гриль")]
        GrillSauce,
        [Description("тахіні")]
        Tahini,
        [Description("хрін червоний")]
        RedHorseradish,
        [Description("імбир маринований")]
        PickledGinger,
        [Description("імбир мелений")]
        GroundGinger,
        [Description("імбир сушений")]
        DriedGinger,
        [Description("амоніак")]
        Ammonia,
        [Description("амоній")]
        Ammonium,
        [Description("аніс")]
        Anise,
        [Description("ароматизатор")]
        FlavoringAgent,
        [Description("ацетилсаліцилова кислота")]
        AcetylsalicylicAcid,
        [Description("бадьян")]
        StarAnise,
        [Description("бадьян мелений")]
        GroundStarAnise,
        [Description("базилік сушений")]
        DriedBasil,
        [Description("букет гарні")]
        FineBouquet,
        [Description("буково")]
        Buchu,
        [Description("вітамін С")]
        VitaminC,
        [Description("ванілін")]
        Vanillin,
        [Description("ваніль")]
        Vanilla,
        [Description("вода флердоранж")]
        OrangeFlowerWater,
        [Description("гірчиця мелена")]
        GroundMustard,
        [Description("гірчиця чорна")]
        BlackMustard,
        [Description("гарам масала")]
        GaramMasala,
        [Description("гвоздика")]
        Clove,
        [Description("гвоздика мелена")]
        GroundClove,
        [Description("глюкоза")]
        Glucose,
        [Description("глютамат натрія")]
        MonosodiumGlutamate,
        [Description("горіх мускатний")]
        Nutmeg,
        [Description("горіх мускатний мелений")]
        GroundNutmeg,
        [Description("душиця")]
        Thyme2,
        [Description("есенція ванільна")]
        VanillaEssence,
        [Description("есенція лимонна")]
        LemonEssence,
        [Description("есенція мигдальна")]
        AlmondEssence,
        [Description("естрагон сушений")]
        DriedTarragon,
        [Description("желатин")]
        Gelatin,
        [Description("желатин листовий")]
        SheetGelatin,
        [Description("желатин швидкорозчинний")]
        InstantGelatin,
        [Description("желфікс")]
        GelFix,
        [Description("заатар")]
        Zaatar,
        [Description("зерна гірчиці")]
        MustardSeeds,
        [Description("карі")]
        Curry,
        [Description("кардамон")]
        Cardamom,
        [Description("кардамон мелений")]
        GroundCardamom,
        [Description("квітки лаванди")]
        LavenderFlowers,
        [Description("кероб мелений")]
        CarobPowder,
        [Description("кислота лимонна")]
        CitricAcid,
        [Description("клітковина")]
        Bran2,
        [Description("кмин")]
        CuminSeeds,
        [Description("кмин мелений")]
        GroundCumin,
        [Description("коріандр мелений")]
        GroundCoriander,
        [Description("кориця")]
        Cinnamon,
        [Description("кориця мелена")]
        GroundCinnamon,
        [Description("кріп сушений")]
        DriedTarragon2,
        [Description("кубики бульйонні")]
        BouillonCubes,
        [Description("кумин")]
        CuminSeeds2,
        [Description("кумин мелений")]
        GroundCumin2,
        [Description("куркума")]
        Turmeric,
        [Description("куркума мелена")]
        GroundTurmeric,
        [Description("лаванда")]
        Lavender,
        [Description("лист лавровий")]
        BayLeaf,
        [Description("лист лавровий мелений")]
        GroundBayLeaf,
        [Description("м'ята сушена")]
        DriedMint,
        [Description("майоран сушений")]
        DriedMarjoram,
        [Description("махлеб")]
        Mahleb,
        [Description("меліса сушена")]
        DriedMelissa,
        [Description("насіння коріандру")]
        CorianderSeeds,
        [Description("насіння кропу")]
        CilantroSeeds,
        [Description("насіння нігелли")]
        NigellaSeeds,
        [Description("насіння фенхеля")]
        FennelSeeds,
        [Description("настоянка шафрану")]
        SaffronInfusion,
        [Description("орегано сушений")]
        DriedOregano,
        [Description("оцтова есенція")]
        VinegarEssence,
        [Description("паприка гостра мелена")]
        HotGroundPaprika,
        [Description("паприка копчена мелена")]
        SmokedGroundPaprika,
        [Description("паприка мелена")]
        GroundPaprika,
        [Description("паприка солодка мелена")]
        SweetGroundPaprika,
        [Description("пектин")]
        Pectin,
        [Description("пелюстки чорнобривців")]
        MarigoldPetals,
        [Description("перець білий")]
        WhitePepper,
        [Description("перець білий мелений")]
        GroundWhitePepper,
        [Description("перець духмяний горошок")]
        WholeAllspice,
        [Description("перець духмяний мелений")]
        GroundAllspice,
        [Description("перець еспелетт мелений")]
        GroundEspelettePepper,
        [Description("перець запашний ямайський")]
        JamaicanPimento,
        [Description("перець зелений горошок")]
        GreenPeppercorns,
        [Description("перець кайєнський мелений")]
        GroundCayennePepper,
        [Description("перець лимонний")]
        LemonPepper,
        [Description("перець пекучий сушений")]
        DriedChiliPepper,
        [Description("перець розе")]
        PinkPeppercorns,
        [Description("перець сичуанський")]
        SichuanPepper,
        [Description("перець червоний горошок")]
        RedPeppercorns,
        [Description("перець червоний мелений")]
        GroundRedPepper,
        [Description("перець чилі мелений")]
        GroundChiliPepper,
        [Description("перець чилі сушений")]
        DriedChiliPepper2,
        [Description("перець чорний горошок")]
        BlackPeppercorns,
        [Description("перець чорний мелений")]
        GroundBlackPepper,
        [Description("петрушка сушена")]
        DriedParsley,
        [Description("порошок з водорослів")]
        SeaweedPowder,
        [Description("приправа для випічки")]
        BakingSpice,
        [Description("приправа для гриля")]
        GrillSpice,
        [Description("приправа для десертів")]
        DessertSpice,
        [Description("приправа для курки-гриль")]
        GrillChickenSpice,
        [Description("приправа для плова")]
        PilafSpice,
        [Description("пудра цукрова")]
        PowderedSugar,
        [Description("розмарин сушений")]
        DriedRosemary,
        [Description("ромова есенція")]
        RumEssence,
        [Description("сіль")]
        Salt,
        [Description("сіль з травами")]
        HerbedSalt,
        [Description("сіль морська")]
        SeaSalt,
        [Description("сіль сванська")]
        SvanetiSalt,
        [Description("сіль часникова")]
        GarlicSalt,
        [Description("соль копченая")]
        SmokedSalt,
        [Description("спеції")]
        Spices,
        [Description("спеції для курки")]
        ChickenSpices,
        [Description("спеції для м'яса")]
        MeatSpices,
        [Description("спеції для риби")]
        FishSpices,
        [Description("спеції для салату")]
        SaladSpices,
        [Description("спеції до картоплі")]
        PotatoSpices,
        [Description("суміш перців")]
        MixedPeppercorns,
        [Description("суміш перців мелена")]
        GroundMixedPeppercorns,
        [Description("суміш суха демі глас")]
        DryDemiGlaceMix,
        [Description("тим'ян сушений")]
        DriedThyme,
        [Description("трави італійські")]
        ItalianHerbs,
        [Description("трави ароматні")]
        AromaticHerbs,
        [Description("трави прованські")]
        ProvencalHerbs,
        [Description("уцхо сунелі")]
        UcchoSuneli,
        [Description("фенугрек")]
        Fenugreek,
        [Description("фермент")]
        Ferment,
        [Description("хмелі-сунелі")]
        KhmeliSuneli,
        [Description("цибуля зелена сушена")]
        DriedGreenOnion,
        [Description("цибуля-порей сушена")]
        DriedLeek,
        [Description("цукор")]
        Sugar,
        [Description("цукор ванільний")]
        VanillaSugar,
        [Description("цукор коричневий")]
        BrownSugar,
        [Description("цукор мусковадо")]
        MuscovadoSugar,
        [Description("цукор палений")]
        CaramelizedSugar,
        [Description("цукор перлинний")]
        PearlSugar,
        [Description("цукор тростинний")]
        CaneSugar,
        [Description("цукор тростинний демерара")]
        DemeraraCaneSugar,
        [Description("цукор-рафінад")]
        RefinedSugar,
        [Description("часник гранульований")]
        GranulatedGarlic,
        [Description("часник сушений мелений")]
        GroundDriedGarlic,
        [Description("чебрець сушений")]
        DriedSavory,
        [Description("шафран")]
        Saffron,
        [Description("шафран імеретинський")]
        ImeretianSaffron,
        [Description("інжир сушений")]
        DriedFig,
        [Description("аліча сушена")]
        DriedDogwood,
        [Description("ананаси в'ялені")]
        DriedPineapple,
        [Description("барбарис сушений")]
        DriedBarberry,
        [Description("вишня в'ялена")]
        DriedSourCherry,
        [Description("вишня сушена")]
        DriedSweetCherry,
        [Description("груші сушені")]
        DriedPears,
        [Description("журавлина сушена")]
        DriedLingonberry,
        [Description("курага")]
        DriedApricot,
        [Description("лумі")]
        Lumy,
        [Description("персики в'ялені")]
        DriedPeaches,
        [Description("родзинки")]
        Raisins,
        [Description("родзинки світлі")]
        LightRaisins,
        [Description("родзинки темні")]
        DarkRaisins,
        [Description("суміш сухофруктів та цукатів")]
        MixedDriedFruitsAndCandiedFruits,
        [Description("сухофрукти")]
        DriedFruits,
        [Description("цукати")]
        CandiedFruits,
        [Description("цукати апельсинові")]
        CandiedOrangePeel,
        [Description("цукати лимонні")]
        CandiedLemonPeel,
        [Description("цукати мандаринові")]
        CandiedMandarinPeel,
        [Description("чорниця сушена")]
        DriedBlueberry,
        [Description("чорнослив")]
        Prunes,
        [Description("чорнослив копчений")]
        SmokedPrunes,
        [Description("шипшина сушена")]
        DriedRosehip,
        [Description("яблука сушені")]
        DriedApples,
        [Description("інжир")]
        Fig,
        [Description("абрикоси")]
        Apricots,
        [Description("абрикоси консервовані")]
        CannedApricots,
        [Description("айва")]
        Quince,
        [Description("аліча")]
        Dogwood,
        [Description("ананас")]
        Pineapple,
        [Description("ананаси консервовані")]
        CannedPineapple,
        [Description("апельсини")]
        Oranges,
        [Description("банани")]
        Bananas,
        [Description("гранати")]
        Pomegranates,
        [Description("грейпфрут рожевий")]
        PinkGrapefruit,
        [Description("грейпфрути")]
        Grapefruits,
        [Description("груші")]
        Pears,
        [Description("зерна граната")]
        PomegranateSeeds,
        [Description("ківі")]
        Kiwi,
        [Description("карамболь")]
        Starfruit,
        [Description("кероб")]
        Carob,
        [Description("кокос")]
        Coconut,
        [Description("кумкват")]
        Kumquat,
        [Description("курага запечена")]
        BakedDriedApricot,
        [Description("лайм")]
        Lime,
        [Description("лимони")]
        Lemons,
        [Description("манго")]
        Mango,
        [Description("мандарини")]
        Tangerines,
        [Description("мандарини консервовані")]
        CannedTangerines,
        [Description("маракуйя")]
        PassionFruit,
        [Description("нектарини")]
        Nectarines,
        [Description("пелюстки троянд")]
        RosePetals,
        [Description("пелюстки чайної троянди")]
        RoseTeaPetals,
        [Description("персики")]
        Peaches,
        [Description("персики консервовані")]
        CannedPeaches,
        [Description("помело")]
        Pomelo,
        [Description("пюре бананове")]
        BananaPuree,
        [Description("пюре з фруктів")]
        FruitPuree,
        [Description("пюре лимонне")]
        LemonPuree,
        [Description("пюре яблучне")]
        ApplePuree,
        [Description("сливи")]
        Plums,
        [Description("сливи мариновані")]
        PickledPlums,
        [Description("стружка кокосова")]
        CoconutFlakes,
        [Description("тамаринд")]
        Tamarind,
        [Description("фєйхоа")]
        Feijoa,
        [Description("фініки")]
        Dates,
        [Description("фрукти")]
        Fruits,
        [Description("хурма")]
        Persimmon,
        [Description("цедра апельсина")]
        OrangeZest,
        [Description("цедра грейпфрута")]
        GrapefruitZest,
        [Description("цедра лайма")]
        LimeZest,
        [Description("цедра лимона")]
        LemonZest,
        [Description("цедра мандарина")]
        MandarinZest,
        [Description("цедра цитрусових")]
        CitrusZest,
        [Description("цитрусові")]
        CitrusFruits,
        [Description("яблука")]
        Apples,
        [Description("ірга")]
        WildPear,
        [Description("агрус")]
        Gooseberry,
        [Description("барбарис")]
        Barberry,
        [Description("брусниця")]
        Cranberry,
        [Description("виноград")]
        Grape,
        [Description("виноград зелений")]
        GreenGrape,
        [Description("виноград кишмиш")]
        Raisin,
        [Description("виноград світлий")]
        WhiteGrape,
        [Description("виноград синій")]
        BlueGrape,
        [Description("виноград червоний")]
        RedGrape,
        [Description("вишні коктейльні")]
        CocktailCherries,
        [Description("вишні консервовані")]
        PreservedCherries,
        [Description("вишня")]
        Cherry,
        [Description("диня")]
        Melon,
        [Description("диня мускатна")]
        Muskmelon,
        [Description("журавлина")]
        Lingonberry,
        [Description("йошта")]
        Jostaberry,
        [Description("кавун")]
        Watermelon,
        [Description("калина")]
        Viburnum,
        [Description("калина в сиропі")]
        ViburnumInSyrup,
        [Description("калина сушена")]
        DriedViburnum,
        [Description("кизил")]
        Honeysuckle,
        [Description("малина")]
        Raspberry,
        [Description("малина чорна")]
        BlackRaspberry,
        [Description("обліпиха")]
        SeaBuckthorn,
        [Description("ожина")]
        Blackberry,
        [Description("полуниця")]
        Strawberry,
        [Description("полуниця консервована")]
        PreservedStrawberry,
        [Description("порічки")]
        RedCurrant,
        [Description("пюре малинове")]
        RaspberryPuree,
        [Description("пюре полуничне")]
        StrawberryPuree,
        [Description("пюре ягідне")]
        BerryPuree,
        [Description("смородина")]
        Currant,
        [Description("смородина чорна")]
        BlackCurrant,
        [Description("суниця")]
        Bilberry,
        [Description("фізаліс")]
        Physalis,
        [Description("черешня")]
        SweetCherry,
        [Description("чорниця")]
        Blueberry,
        [Description("шкірки кавуна")]
        WatermelonPeels,
        [Description("ягоди")]
        Berries,
        [Description("ягоди сушені")]
        DriedBerries,
        [Description("ягоди шипшини")]
        RosehipBerries,
        [Description("ягоди ялівцю")]
        JuniperBerries,
        [Description("білки перепелині")]
        QuailEggWhites,
        [Description("білки яєчні")]
        EggWhites,
        [Description("жовтки яєчні")]
        EggYolks,
        [Description("крашанки")]
        ScrambledEggs,
        [Description("омлет")]
        Omelette,
        [Description("яйця курячі")]
        ChickenEggs,
        [Description("яйця перепелині")]
        QuailEggs,
        [Description("бренді")]
        Brandy,
        [Description("віскі")]
        Whiskey,
        [Description("вермут")]
        Vermouth,
        [Description("вино біле")]
        WhiteWine,
        [Description("вино рисове")]
        RiceWine,
        [Description("вино червоне")]
        RedWine,
        [Description("вино яблучне")]
        AppleWine,
        [Description("горілка")]
        Vodka,
        [Description("джин")]
        Gin,
        [Description("кірш")]
        Kirsch,
        [Description("кальвадос")]
        Calvados,
        [Description("коньяк")]
        Cognac,
        [Description("лікер")]
        Liqueur,
        [Description("лікер Baileys")]
        BaileysLiqueur,
        [Description("лікер Grand Marnier")]
        GrandMarnierLiqueur,
        [Description("лікер Irish Cream")]
        IrishCreamLiqueur,
        [Description("лікер Vana Tallinn")]
        VanaTallinnLiqueur,
        [Description("лікер Амаретто")]
        AmarettoLiqueur,
        [Description("лікер апельсиновий")]
        OrangeLiqueur,
        [Description("лікер вишневий")]
        CherryLiqueur,
        [Description("лікер кавовий")]
        CoffeeLiqueur,
        [Description("лікер кокосовий")]
        CoconutLiqueur,
        [Description("лікер Куантро")]
        CointreauLiqueur,
        [Description("лікер лимонний")]
        LemonLiqueur,
        [Description("лікер лимончелло")]
        LimoncelloLiqueur,
        [Description("лікер персиковий")]
        PeachLiqueur,
        [Description("лікер фруктовий")]
        FruitLiqueur,
        [Description("лікер чорносмородиновий")]
        BlackcurrantLiqueur,
        [Description("лікер шоколадний")]
        ChocolateLiqueur,
        [Description("лікер яєчний")]
        EggLiqueur,
        [Description("лікер ягідний")]
        BerryLiqueur,
        [Description("мірин")]
        Mirin,
        [Description("наливка вишнева")]
        CherryInfusion,
        [Description("настоянка малинова")]
        RaspberryInfusion,
        [Description("пиво світле")]
        LightBeer,
        [Description("пиво темне")]
        DarkBeer,
        [Description("портвейн")]
        Portwine,
        [Description("портвейн червоний")]
        RedPortwine,
        [Description("ром")]
        Rum,
        [Description("ром білий")]
        WhiteRum,
        [Description("ром темний")]
        DarkRum,
        [Description("саке")]
        Sake,
        [Description("спирт")]
        Spirit,
        [Description("текіла")]
        Tequila,
        [Description("херес")]
        Sherry,
        [Description("шампанське")]
        Champagne
    }
}
