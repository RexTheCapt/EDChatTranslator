using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EdTools
{
    public class JsonClass
    {

        public class Rootobject
        {
            public Root[] Property1 { get; set; }
        }

        public class Root
        {
            public DateTime timestamp { get; set; }
            [Newtonsoft.Json.JsonProperty("event")]
            public string _event { get; set; }
            public int part { get; set; }
            public string language { get; set; }
            public bool Odyssey { get; set; }
            public string gameversion { get; set; }
            public string build { get; set; }
            public string Status { get; set; }
            public string Name { get; set; }
            public string FID { get; set; }
            public Raw[] Raw { get; set; }
            public Manufactured[] Manufactured { get; set; }
            public Encoded[] Encoded { get; set; }
            public object Combat { get; set; }
            public int Trade { get; set; }
            public int Explore { get; set; }
            public int Soldier { get; set; }
            public int Exobiologist { get; set; }
            public float Empire { get; set; }
            public float Federation { get; set; }
            public object CQC { get; set; }
            public float Alliance { get; set; }
            public Engineer[] Engineers { get; set; }
            public string Commander { get; set; }
            public bool Horizons { get; set; }
            public string Ship { get; set; }
            public long ShipID { get; set; }
            public string ShipName { get; set; }
            public string ShipIdent { get; set; }
            public float FuelLevel { get; set; }
            public object FuelCapacity { get; set; }
            public string GameMode { get; set; }
            public long Credits { get; set; }
            public int Loan { get; set; }
            public string SquadronName { get; set; }
            public int CurrentRank { get; set; }
            public Bank_Account Bank_Account { get; set; }
            public Crime Crime { get; set; }
            public Smuggling Smuggling { get; set; }
            public Trading Trading { get; set; }
            public Mining Mining { get; set; }
            public Exploration Exploration { get; set; }
            public Passengers Passengers { get; set; }
            public Search_And_Rescue Search_And_Rescue { get; set; }
            public TG_ENCOUNTERS TG_ENCOUNTERS { get; set; }
            public Crafting Crafting { get; set; }
            public object Crew { get; set; }
            public object Multicrew { get; set; }
            public Material_Trader_Stats Material_Trader_Stats { get; set; }
            public FLEETCARRIER FLEETCARRIER { get; set; }
            public Exobiology Exobiology { get; set; }
            public string From { get; set; }
            public string Message { get; set; }
            public string Message_Localised { get; set; }
            public string Channel { get; set; }
            public long SystemAddress { get; set; }
            public string SignalName { get; set; }
            public string SignalName_Localised { get; set; }
            public bool IsStation { get; set; }
            public float DistFromStarLS { get; set; }
            public bool Docked { get; set; }
            public bool Taxi { get; set; }
            public string StarSystem { get; set; }
            public float[] StarPos { get; set; }
            public string SystemAllegiance { get; set; }
            public string SystemEconomy { get; set; }
            public string SystemEconomy_Localised { get; set; }
            public string SystemSecondEconomy { get; set; }
            public string SystemSecondEconomy_Localised { get; set; }
            public string SystemGovernment { get; set; }
            public string SystemGovernment_Localised { get; set; }
            public string SystemSecurity { get; set; }
            public string SystemSecurity_Localised { get; set; }
            public long Population { get; set; }
            public string Body { get; set; }
            public int BodyID { get; set; }
            public string BodyType { get; set; }
            public Faction[] Factions { get; set; }
            public Systemfaction SystemFaction { get; set; }
            public Conflict[] Conflicts { get; set; }
            public string MusicTrack { get; set; }
            public object[] Items { get; set; }
            public Component[] Components { get; set; }
            public Consumable[] Consumables { get; set; }
            public Datum[] Data { get; set; }
            public Active[] Active { get; set; }
            public object[] Failed { get; set; }
            public object[] Complete { get; set; }
            public int HullValue { get; set; }
            public int ModulesValue { get; set; }
            public float HullHealth { get; set; }
            public float UnladenMass { get; set; }
            public int CargoCapacity { get; set; }
            public float MaxJumpRange { get; set; }
            public int Rebuy { get; set; }
            public Module[] Modules { get; set; }
            public string Vessel { get; set; }
            public int Count { get; set; }
            public Inventory[] Inventory { get; set; }
            public string[] Others { get; set; }
            public string StarClass { get; set; }
            public int RemainingJumpsInRoute { get; set; }
            public string JumpType { get; set; }
            public float JumpDist { get; set; }
            public float FuelUsed { get; set; }
            public float Progress { get; set; }
            public int BodyCount { get; set; }
            public int NonBodyCount { get; set; }
            public string SystemName { get; set; }
            public float Scooped { get; set; }
            public float Total { get; set; }
            public string ScanType { get; set; }
            public string BodyName { get; set; }
            public Parent[] Parents { get; set; }
            public float DistanceFromArrivalLS { get; set; }
            public string StarType { get; set; }
            public int Subclass { get; set; }
            public float StellarMass { get; set; }
            public float Radius { get; set; }
            public float AbsoluteMagnitude { get; set; }
            public int Age_MY { get; set; }
            public float SurfaceTemperature { get; set; }
            public string Luminosity { get; set; }
            public float SemiMajorAxis { get; set; }
            public float Eccentricity { get; set; }
            public float OrbitalInclination { get; set; }
            public float Periapsis { get; set; }
            public float OrbitalPeriod { get; set; }
            public float AscendingNode { get; set; }
            public float MeanAnomaly { get; set; }
            public float RotationPeriod { get; set; }
            public float AxialTilt { get; set; }
            public Ring[] Rings { get; set; }
            public bool WasDiscovered { get; set; }
            public bool WasMapped { get; set; }
            public long MarketID { get; set; }
            public string StationName { get; set; }
            public string StationType { get; set; }
            public Landingpads LandingPads { get; set; }
            public int LandingPad { get; set; }
            public Stationfaction StationFaction { get; set; }
            public string StationGovernment { get; set; }
            public string StationGovernment_Localised { get; set; }
            public string[] StationServices { get; set; }
            public string StationEconomy { get; set; }
            public string StationEconomy_Localised { get; set; }
            public Stationeconomy[] StationEconomies { get; set; }
            public string NpcCrewName { get; set; }
            public int NpcCrewId { get; set; }
            public float Amount { get; set; }
            public int Cost { get; set; }
            public Discovered[] Discovered { get; set; }
            public int BaseValue { get; set; }
            public int Bonus { get; set; }
            public int TotalEarnings { get; set; }
            public string To { get; set; }
            public bool Sent { get; set; }
            public long CarrierID { get; set; }
            public string Callsign { get; set; }
            public string DockingAccess { get; set; }
            public bool AllowNotorious { get; set; }
            public float JumpRangeCurr { get; set; }
            public float JumpRangeMax { get; set; }
            public bool PendingDecommission { get; set; }
            public Spaceusage SpaceUsage { get; set; }
            public Finance Finance { get; set; }
            public object[] ShipPacks { get; set; }
            public object[] ModulePacks { get; set; }
            public string From_Localised { get; set; }
            public string Faction { get; set; }
            public string LocalisedName { get; set; }
            public string TargetType { get; set; }
            public string TargetType_Localised { get; set; }
            public string TargetFaction { get; set; }
            public int KillCount { get; set; }
            public string DestinationSystem { get; set; }
            public string DestinationStation { get; set; }
            public DateTime Expiry { get; set; }
            public bool Wing { get; set; }
            public string Influence { get; set; }
            public string Reputation { get; set; }
            public int Reward { get; set; }
            public int MissionID { get; set; }
            public Shipshere[] ShipsHere { get; set; }
            public Shipsremote[] ShipsRemote { get; set; }
            public string Type { get; set; }
            public int SellPrice { get; set; }
            public int TotalSale { get; set; }
            public string ShipType { get; set; }
            public string ShipType_Localised { get; set; }
            public string StoreOldShip { get; set; }
            public long StoreShipID { get; set; }
            public int CrewID { get; set; }
            public string Role { get; set; }
            public bool TargetLocked { get; set; }
            public int ScanStage { get; set; }
            public string PilotName { get; set; }
            public string PilotName_Localised { get; set; }
            public string SquadronID { get; set; }
            public float ShieldHealth { get; set; }
            public string LegalStatus { get; set; }
            public string Loadout { get; set; }
            public int ID { get; set; }
            public bool PlayerControlled { get; set; }
            public string PilotRank { get; set; }
            public string Ship_Localised { get; set; }
            public int Bounty { get; set; }
            public string Target { get; set; }
            public Reward[] Rewards { get; set; }
            public string Target_Localised { get; set; }
            public int TotalReward { get; set; }
            public string VictimFaction { get; set; }
            public int SharedWithOthers { get; set; }
            public string Category { get; set; }
            public string Name_Localised { get; set; }
            public float Health { get; set; }
            public bool PlayerPilot { get; set; }
            public bool Fighter { get; set; }
            public float FuelMain { get; set; }
            public float FuelReservoir { get; set; }
            public string NewDestinationStation { get; set; }
            public string NewDestinationSystem { get; set; }
            public string OldDestinationStation { get; set; }
            public string OldDestinationSystem { get; set; }
            public bool ShieldsUp { get; set; }
            public string Type_Localised { get; set; }
            public bool Submitted { get; set; }
            public string Interdictor { get; set; }
            public bool IsPlayer { get; set; }
            public string Subsystem { get; set; }
            public string Subsystem_Localised { get; set; }
            public float SubsystemHealth { get; set; }
            public string Captain { get; set; }
            public bool Telepresence { get; set; }
            public bool SRV { get; set; }
            public bool OnStation { get; set; }
            public bool OnPlanet { get; set; }
            public long SuitID { get; set; }
            public string SuitName { get; set; }
            public string SuitName_Localised { get; set; }
            public string[] SuitMods { get; set; }
            public long LoadoutID { get; set; }
            public string LoadoutName { get; set; }
            public bool OnCrime { get; set; }
            public string Option { get; set; }
            public bool Bankrupt { get; set; }
            public string Filename { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public string System { get; set; }
            public Factioneffect[] FactionEffects { get; set; }
            public Materialsreward[] MaterialsReward { get; set; }
            public string CrimeType { get; set; }
            public int Fine { get; set; }
            public float BrokerPercentage { get; set; }
            public long ShipMarketID { get; set; }
            public float Distance { get; set; }
            public int TransferPrice { get; set; }
            public int TransferTime { get; set; }
            public string StationAllegiance { get; set; }
            public bool BlackMarket { get; set; }
            public string Commodity { get; set; }
            public int PurchaseOrder { get; set; }
            public int Price { get; set; }
            public int BuyPrice { get; set; }
            public int TotalCost { get; set; }
            public string CarrierDockingAccess { get; set; }
            public int AvgPricePaid { get; set; }
            public Transfer[] Transfers { get; set; }
            public bool ActiveFine { get; set; }
            public bool AllFines { get; set; }
            public int CGID { get; set; }
            public Currentgoal[] CurrentGoals { get; set; }
            public int SaleOrder { get; set; }
            public string Faction_Localised { get; set; }
            public string Reason { get; set; }
            public bool TidalLock { get; set; }
            public string TerraformState { get; set; }
            public string PlanetClass { get; set; }
            public string Atmosphere { get; set; }
            public string AtmosphereType { get; set; }
            public string Volcanism { get; set; }
            public float MassEM { get; set; }
            public float SurfaceGravity { get; set; }
            public float SurfacePressure { get; set; }
            public bool Landable { get; set; }
            public Material[] Materials { get; set; }
            public Composition Composition { get; set; }
            public Atmospherecomposition[] AtmosphereComposition { get; set; }
            public string Slot { get; set; }
            public string SellItem { get; set; }
            public string SellItem_Localised { get; set; }
            public string BuyItem { get; set; }
            public string BuyItem_Localised { get; set; }
            public string StoredItem { get; set; }
            public string StoredItem_Localised { get; set; }
            public string Group { get; set; }
            public string RetrievedItem { get; set; }
            public string RetrievedItem_Localised { get; set; }
            public bool Hot { get; set; }
            public string SwapOutItem { get; set; }
            public string SwapOutItem_Localised { get; set; }
            public string Commodity_Localised { get; set; }
            public bool Abandoned { get; set; }
            public string UpdateType { get; set; }
            public string CargoType { get; set; }
            public long StartMarketID { get; set; }
            public int EndMarketID { get; set; }
            public int ItemsCollected { get; set; }
            public int ItemsDelivered { get; set; }
            public int TotalItemsToDeliver { get; set; }
            public float Latitude { get; set; }
            public float Longitude { get; set; }
            public int ProbesUsed { get; set; }
            public int EfficiencyTarget { get; set; }
            public Signal[] Signals { get; set; }
            public string NearestDestination { get; set; }
            public float HullRepaired { get; set; }
            public int Heading { get; set; }
            public float Altitude { get; set; }
            public object[] Genuses { get; set; }
            public string CrewRole { get; set; }
            public string Operation { get; set; }
            public string CrewName { get; set; }
            public long Deposit { get; set; }
            public long PlayerBalance { get; set; }
            public long CarrierBalance { get; set; }
            public long ReserveBalance { get; set; }
            public long AvailableBalance { get; set; }
            public int ReservePercent { get; set; }
            public int TaxRate_shipyard { get; set; }
            public int TaxRate_rearm { get; set; }
            public int TaxRate_outfitting { get; set; }
            public int TaxRate_refuel { get; set; }
            public int TaxRate_repair { get; set; }
        }

        public class Bank_Account
        {
            public long Current_Wealth { get; set; }
            public int Spent_On_Ships { get; set; }
            public long Spent_On_Outfitting { get; set; }
            public int Spent_On_Repairs { get; set; }
            public int Spent_On_Fuel { get; set; }
            public int Spent_On_Ammo_Consumables { get; set; }
            public int Insurance_Claims { get; set; }
            public int Spent_On_Insurance { get; set; }
            public int Owned_Ship_Count { get; set; }
            public int Spent_On_Suits { get; set; }
            public int Spent_On_Weapons { get; set; }
            public int Spent_On_Suit_Consumables { get; set; }
            public int Suits_Owned { get; set; }
            public int Weapons_Owned { get; set; }
            public int Spent_On_Premium_Stock { get; set; }
            public int Premium_Stock_Bought { get; set; }
        }

        public class Crime
        {
            public int Notoriety { get; set; }
            public int Fines { get; set; }
            public int Total_Fines { get; set; }
            public int Bounties_Received { get; set; }
            public int Total_Bounties { get; set; }
            public int Highest_Bounty { get; set; }
            public int Malware_Uploaded { get; set; }
            public int Settlements_State_Shutdown { get; set; }
            public int Production_Sabotage { get; set; }
            public int Production_Theft { get; set; }
            public int Total_Murders { get; set; }
            public int Citizens_Murdered { get; set; }
            public int Omnipol_Murdered { get; set; }
            public int Guards_Murdered { get; set; }
            public int Data_Stolen { get; set; }
            public int Goods_Stolen { get; set; }
            public int Sample_Stolen { get; set; }
            public int Total_Stolen { get; set; }
            public int Turrets_Destroyed { get; set; }
            public int Turrets_Overloaded { get; set; }
            public int Turrets_Total { get; set; }
            public int Value_Stolen_StateChange { get; set; }
            public int Profiles_Cloned { get; set; }
        }

        public class Smuggling
        {
            public int Black_Markets_Traded_With { get; set; }
            public int Black_Markets_Profits { get; set; }
            public int Resources_Smuggled { get; set; }
            public int Average_Profit { get; set; }
            public int Highest_Single_Transaction { get; set; }
        }

        public class Trading
        {
            public int Markets_Traded_With { get; set; }
            public long Market_Profits { get; set; }
            public int Resources_Traded { get; set; }
            public float Average_Profit { get; set; }
            public int Highest_Single_Transaction { get; set; }
            public int Data_Sold { get; set; }
            public int Goods_Sold { get; set; }
            public int Assets_Sold { get; set; }
        }

        public class Mining
        {
            public long Mining_Profits { get; set; }
            public int Quantity_Mined { get; set; }
            public int Materials_Collected { get; set; }
        }

        public class Exploration
        {
            public int Systems_Visited { get; set; }
            public int Exploration_Profits { get; set; }
            public int Planets_Scanned_To_Level_2 { get; set; }
            public int Planets_Scanned_To_Level_3 { get; set; }
            public int Efficient_Scans { get; set; }
            public int Highest_Payout { get; set; }
            public int Total_Hyperspace_Distance { get; set; }
            public int Total_Hyperspace_Jumps { get; set; }
            public float Greatest_Distance_From_Start { get; set; }
            public int Time_Played { get; set; }
            public int OnFoot_Distance_Travelled { get; set; }
            public int Shuttle_Journeys { get; set; }
            public float Shuttle_Distance_Travelled { get; set; }
            public int Spent_On_Shuttles { get; set; }
            public int First_Footfalls { get; set; }
            public int Planet_Footfalls { get; set; }
            public int Settlements_Visited { get; set; }
        }

        public class Passengers
        {
            public int Passengers_Missions_Accepted { get; set; }
            public int Passengers_Missions_Disgruntled { get; set; }
            public int Passengers_Missions_Bulk { get; set; }
            public int Passengers_Missions_VIP { get; set; }
            public int Passengers_Missions_Delivered { get; set; }
            public int Passengers_Missions_Ejected { get; set; }
        }

        public class Search_And_Rescue
        {
            public int SearchRescue_Traded { get; set; }
            public int SearchRescue_Profit { get; set; }
            public int SearchRescue_Count { get; set; }
            public int Salvage_Legal_POI { get; set; }
            public int Salvage_Legal_Settlements { get; set; }
            public int Salvage_Illegal_POI { get; set; }
            public int Salvage_Illegal_Settlements { get; set; }
            public int Maglocks_Opened { get; set; }
            public int Panels_Opened { get; set; }
            public int Settlements_State_FireOut { get; set; }
            public int Settlements_State_Reboot { get; set; }
        }

        public class TG_ENCOUNTERS
        {
            public int TG_ENCOUNTER_TOTAL { get; set; }
            public string TG_ENCOUNTER_TOTAL_LAST_SYSTEM { get; set; }
            public string TG_ENCOUNTER_TOTAL_LAST_TIMESTAMP { get; set; }
            public string TG_ENCOUNTER_TOTAL_LAST_SHIP { get; set; }
            public int TG_SCOUT_COUNT { get; set; }
        }

        public class Crafting
        {
            public int Count_Of_Used_Engineers { get; set; }
            public int Recipes_Generated { get; set; }
            public int Recipes_Generated_Rank_1 { get; set; }
            public int Recipes_Generated_Rank_2 { get; set; }
            public int Recipes_Generated_Rank_3 { get; set; }
            public int Recipes_Generated_Rank_4 { get; set; }
            public int Recipes_Generated_Rank_5 { get; set; }
            public int Suit_Mods_Applied { get; set; }
            public int Weapon_Mods_Applied { get; set; }
            public int Suits_Upgraded { get; set; }
            public int Weapons_Upgraded { get; set; }
            public int Suits_Upgraded_Full { get; set; }
            public int Weapons_Upgraded_Full { get; set; }
            public int Suit_Mods_Applied_Full { get; set; }
            public int Weapon_Mods_Applied_Full { get; set; }
        }

        public class Material_Trader_Stats
        {
            public int Trades_Completed { get; set; }
            public int Materials_Traded { get; set; }
            public int Encoded_Materials_Traded { get; set; }
            public int Raw_Materials_Traded { get; set; }
            public int Grade_1_Materials_Traded { get; set; }
            public int Grade_2_Materials_Traded { get; set; }
            public int Grade_3_Materials_Traded { get; set; }
            public int Grade_4_Materials_Traded { get; set; }
            public int Grade_5_Materials_Traded { get; set; }
            public int Assets_Traded_In { get; set; }
            public int Assets_Traded_Out { get; set; }
        }

        public class FLEETCARRIER
        {
            public int FLEETCARRIER_EXPORT_TOTAL { get; set; }
            public int FLEETCARRIER_IMPORT_TOTAL { get; set; }
            public long FLEETCARRIER_TRADEPROFIT_TOTAL { get; set; }
            public long FLEETCARRIER_TRADESPEND_TOTAL { get; set; }
            public int FLEETCARRIER_STOLENPROFIT_TOTAL { get; set; }
            public int FLEETCARRIER_STOLENSPEND_TOTAL { get; set; }
            public object FLEETCARRIER_DISTANCE_TRAVELLED { get; set; }
            public int FLEETCARRIER_TOTAL_JUMPS { get; set; }
            public int FLEETCARRIER_SHIPYARD_SOLD { get; set; }
            public int FLEETCARRIER_SHIPYARD_PROFIT { get; set; }
            public int FLEETCARRIER_OUTFITTING_SOLD { get; set; }
            public long FLEETCARRIER_OUTFITTING_PROFIT { get; set; }
            public int FLEETCARRIER_REARM_TOTAL { get; set; }
            public int FLEETCARRIER_REFUEL_TOTAL { get; set; }
            public int FLEETCARRIER_REFUEL_PROFIT { get; set; }
            public int FLEETCARRIER_REPAIRS_TOTAL { get; set; }
            public int FLEETCARRIER_VOUCHERS_REDEEMED { get; set; }
            public int FLEETCARRIER_VOUCHERS_PROFIT { get; set; }
        }

        public class Exobiology
        {
            public int Organic_Genus_Encountered { get; set; }
            public int Organic_Species_Encountered { get; set; }
            public int Organic_Variant_Encountered { get; set; }
            public int Organic_Data_Profits { get; set; }
            public int Organic_Data { get; set; }
            public int First_Logged_Profits { get; set; }
            public int First_Logged { get; set; }
            public int Organic_Systems { get; set; }
            public int Organic_Planets { get; set; }
            public int Organic_Genus { get; set; }
            public int Organic_Species { get; set; }
        }

        public class Systemfaction
        {
            public string Name { get; set; }
            public string FactionState { get; set; }
        }

        public class Landingpads
        {
            public int Small { get; set; }
            public int Medium { get; set; }
            public int Large { get; set; }
        }

        public class Stationfaction
        {
            public string Name { get; set; }
            public string FactionState { get; set; }
        }

        public class Spaceusage
        {
            public int TotalCapacity { get; set; }
            public int Crew { get; set; }
            public int Cargo { get; set; }
            public int CargoSpaceReserved { get; set; }
            public int ShipPacks { get; set; }
            public int ModulePacks { get; set; }
            public int FreeSpace { get; set; }
        }

        public class Finance
        {
            public long CarrierBalance { get; set; }
            public int ReserveBalance { get; set; }
            public long AvailableBalance { get; set; }
            public int ReservePercent { get; set; }
            public int TaxRate_pioneersupplies { get; set; }
            public int TaxRate_shipyard { get; set; }
            public int TaxRate_rearm { get; set; }
            public int TaxRate_outfitting { get; set; }
            public int TaxRate_refuel { get; set; }
            public int TaxRate_repair { get; set; }
        }

        public class Composition
        {
            public float Ice { get; set; }
            public float Rock { get; set; }
            public float Metal { get; set; }
        }

        public class Raw
        {
            public string Name { get; set; }
            public int Count { get; set; }
        }

        public class Manufactured
        {
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public int Count { get; set; }
        }

        public class Encoded
        {
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public int Count { get; set; }
        }

        public class Engineer
        {
            [JsonPropertyName("Engineer")]
            public string EngineerString { get; set; }
            public int EngineerID { get; set; }
            public string Progress { get; set; }
            public int RankProgress { get; set; }
            public int Rank { get; set; }
        }

        public class Faction
        {
            public string Name { get; set; }
            public string FactionState { get; set; }
            public string Government { get; set; }
            public float Influence { get; set; }
            public string Allegiance { get; set; }
            public string Happiness { get; set; }
            public string Happiness_Localised { get; set; }
            public float MyReputation { get; set; }
            public Activestate[] ActiveStates { get; set; }
            public bool SquadronFaction { get; set; }
            public bool HomeSystem { get; set; }
            [JsonPropertyName("Faction")]
            public string FactionString { get; set; }
            public int Amount { get; set; }
            public Pendingstate[] PendingStates { get; set; }
            public Recoveringstate[] RecoveringStates { get; set; }
        }

        public class Activestate
        {
            public string State { get; set; }
        }

        public class Pendingstate
        {
            public string State { get; set; }
            public int Trend { get; set; }
        }

        public class Recoveringstate
        {
            public string State { get; set; }
            public int Trend { get; set; }
        }

        public class Conflict
        {
            public string WarType { get; set; }
            public string Status { get; set; }
            public Faction1 Faction1 { get; set; }
            public Faction2 Faction2 { get; set; }
        }

        public class Faction1
        {
            public string Name { get; set; }
            public string Stake { get; set; }
            public int WonDays { get; set; }
        }

        public class Faction2
        {
            public string Name { get; set; }
            public string Stake { get; set; }
            public int WonDays { get; set; }
        }

        public class Component
        {
            public string Name { get; set; }
            public int OwnerID { get; set; }
            public int Count { get; set; }
            public string Name_Localised { get; set; }
        }

        public class Consumable
        {
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public int OwnerID { get; set; }
            public int Count { get; set; }
        }

        public class Datum
        {
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public int OwnerID { get; set; }
            public int Count { get; set; }
        }

        public class Active
        {
            public int MissionID { get; set; }
            public string Name { get; set; }
            public bool PassengerMission { get; set; }
            public int Expires { get; set; }
        }

        public class Module
        {
            public string Slot { get; set; }
            public string Item { get; set; }
            public bool On { get; set; }
            public int Priority { get; set; }
            public int AmmoInClip { get; set; }
            public int AmmoInHopper { get; set; }
            public float Health { get; set; }
            public int Value { get; set; }
            public Engineering Engineering { get; set; }
            public string SlotName { get; set; }
            public long SuitModuleID { get; set; }
            public string ModuleName { get; set; }
            public string ModuleName_Localised { get; set; }
            public int Class { get; set; }
            public object[] WeaponMods { get; set; }
        }

        public class Engineering
        {
            public string Engineer { get; set; }
            public int EngineerID { get; set; }
            public int BlueprintID { get; set; }
            public string BlueprintName { get; set; }
            public int Level { get; set; }
            public float Quality { get; set; }
            public Modifier[] Modifiers { get; set; }
            public string ExperimentalEffect { get; set; }
            public string ExperimentalEffect_Localised { get; set; }
        }

        public class Modifier
        {
            public string Label { get; set; }
            public float Value { get; set; }
            public float OriginalValue { get; set; }
            public int LessIsGood { get; set; }
            public string ValueStr { get; set; }
            public string ValueStr_Localised { get; set; }
        }

        public class Inventory
        {
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public int Count { get; set; }
            public int Stolen { get; set; }
        }

        public class Parent
        {
            public int Null { get; set; }
            public int Ring { get; set; }
            public int Star { get; set; }
            public int Planet { get; set; }
        }

        public class Ring
        {
            public string Name { get; set; }
            public string RingClass { get; set; }
            public float MassMT { get; set; }
            public float InnerRad { get; set; }
            public float OuterRad { get; set; }
        }

        public class Stationeconomy
        {
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public float Proportion { get; set; }
        }

        public class Discovered
        {
            public string SystemName { get; set; }
            public int NumBodies { get; set; }
        }

        public class Shipshere
        {
            public long ShipID { get; set; }
            public string ShipType { get; set; }
            public string Name { get; set; }
            public int Value { get; set; }
            public bool Hot { get; set; }
            public string ShipType_Localised { get; set; }
        }

        public class Shipsremote
        {
            public long ShipID { get; set; }
            public string ShipType { get; set; }
            public string ShipType_Localised { get; set; }
            public string Name { get; set; }
            public string StarSystem { get; set; }
            public long ShipMarketID { get; set; }
            public int TransferPrice { get; set; }
            public int TransferTime { get; set; }
            public int Value { get; set; }
            public bool Hot { get; set; }
            public bool InTransit { get; set; }
        }

        public class Reward
        {
            public string Faction { get; set; }
            [JsonPropertyName("Reward")]
            public int RewardInt { get; set; }
        }

        public class Factioneffect
        {
            public string Faction { get; set; }
            public Effect[] Effects { get; set; }
            public Influence[] Influence { get; set; }
            public string ReputationTrend { get; set; }
            public string Reputation { get; set; }
        }

        public class Effect
        {
            [JsonPropertyName("Effect")]
            public string EffectString { get; set; }
            public string Effect_Localised { get; set; }
            public string Trend { get; set; }
        }

        public class Influence
        {
            public long SystemAddress { get; set; }
            public string Trend { get; set; }
            [JsonPropertyName("Influence")]
            public string InfluenceString { get; set; }
        }

        public class Materialsreward
        {
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public string Category { get; set; }
            public string Category_Localised { get; set; }
            public int Count { get; set; }
        }

        public class Transfer
        {
            public string Type { get; set; }
            public int Count { get; set; }
            public string Direction { get; set; }
        }

        public class Currentgoal
        {
            public int CGID { get; set; }
            public string Title { get; set; }
            public string SystemName { get; set; }
            public string MarketName { get; set; }
            public DateTime Expiry { get; set; }
            public bool IsComplete { get; set; }
            public int CurrentTotal { get; set; }
            public int PlayerContribution { get; set; }
            public int NumContributors { get; set; }
            public Toptier TopTier { get; set; }
            public int TopRankSize { get; set; }
            public bool PlayerInTopRank { get; set; }
            public int PlayerPercentileBand { get; set; }
            public string TierReached { get; set; }
            public int Bonus { get; set; }
        }

        public class Toptier
        {
            public string Name { get; set; }
            public string Bonus { get; set; }
        }

        public class Material
        {
            public string Name { get; set; }
            public float Percent { get; set; }
        }

        public class Atmospherecomposition
        {
            public string Name { get; set; }
            public float Percent { get; set; }
        }

        public class Signal
        {
            public string Type { get; set; }
            public string Type_Localised { get; set; }
            public int Count { get; set; }
        }
    }
}
