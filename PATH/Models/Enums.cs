using System.ComponentModel;

namespace ProvalusApplicantTrackingHub.Models {

    #region State
    public enum State {
        [Description("Alabama")]
        AL,

        [Description("Alaska")]
        AK,

        [Description("Arkansas")]
        AR,

        [Description("Arizona")]
        AZ,

        [Description("California")]
        CA,

        [Description("Colorado")]
        CO,

        [Description("Connecticut")]
        CT,

        [Description("D.C.")]
        DC,

        [Description("Delaware")]
        DE,

        [Description("Florida")]
        FL,

        [Description("Georgia")]
        GA,

        [Description("Hawaii")]
        HI,

        [Description("Iowa")]
        IA,

        [Description("Idaho")]
        ID,

        [Description("Illinois")]
        IL,

        [Description("Indiana")]
        IN,

        [Description("Kansas")]
        KS,

        [Description("Kentucky")]
        KY,

        [Description("Louisiana")]
        LA,

        [Description("Massachusetts")]
        MA,

        [Description("Maryland")]
        MD,

        [Description("Maine")]
        ME,

        [Description("Michigan")]
        MI,

        [Description("Minnesota")]
        MN,

        [Description("Missouri")]
        MO,

        [Description("Mississippi")]
        MS,

        [Description("Montana")]
        MT,

        [Description("North Carolina")]
        NC,

        [Description("North Dakota")]
        ND,

        [Description("Nebraska")]
        NE,

        [Description("New Hampshire")]
        NH,

        [Description("New Jersey")]
        NJ,

        [Description("New Mexico")]
        NM,

        [Description("Nevada")]
        NV,

        [Description("New York")]
        NY,

        [Description("Oklahoma")]
        OK,

        [Description("Ohio")]
        OH,

        [Description("Oregon")]
        OR,

        [Description("Pennsylvania")]
        PA,

        [Description("Rhode Island")]
        RI,

        [Description("South Carolina")]
        SC,

        [Description("South Dakota")]
        SD,

        [Description("Tennessee")]
        TN,

        [Description("Texas")]
        TX,

        [Description("Utah")]
        UT,

        [Description("Virginia")]
        VA,

        [Description("Vermont")]
        VT,

        [Description("Washington")]
        WA,

        [Description("Wisconsin")]
        WI,

        [Description("West Virginia")]
        WV,

        [Description("Wyoming")]
        WY

    }
    #endregion

    #region MilBranch
    public enum MilBranch {
        [Description("Army")]
        Army,

        [Description("Navy")]
        Navy,

        [Description("Air Force")]
        AirForce,

        [Description("Marine Corp.")]
        Marines,

        [Description("Coast Guard")]
        CoastGuard
    }
    #endregion

    #region Position
    public enum Position {

        [Description("Software Development")]
        Development,

        [Description("Network Engineer")]
        NetEng,

        [Description("System Engineer")]
        SysEng,

        [Description("Network Administrator")]
        NetAdmin,

        [Description("System Administrator")]
        SysAdmin,

        [Description("Tech Support")]
        TechSupport,

        [Description("Software Testing")]
        SoftwareTesting,

        [Description("Help Desk")]
        HelpDesk,

        [Description("Administrative")]
        Administrative,

        [Description("Sales")]
        Sales,

        [Description("Operations")]
        Operations,

        [Description("Recruiting")]
        Recruiting

    }
    #endregion

    #region PayRate
    public enum PayRate {
        Yearly = 0,
        Monthly = 1,
        Hourly = 2,
        Commission =3 
    }
    #endregion

    #region Proficiency
    public enum Proficiency {
        Beginner, Intermediate, Advanced, Expert
    }
    #endregion

    #region AddressType
    public enum AddressType {
        Applicant, Employer, Education
    }
    #endregion

    #region SearchCategory
    public enum SearchCategory {

        [Description("Last Name")]
        LName,

        [Description("First Name")]
        FName,

        [Description("Available to Start")]
        AvailDate,

        [Description("CPAB Score")]
        CPABScore,

        [Description("Personality Test Score")]
        PTScore,

        [Description("Position Applied For")]
        Position
    }
    #endregion

    #region Status
    public enum Status
    {
        [Description("Hired and Active")]
        Active,
        [Description("Hired but Inactive")]
        InActive,
        [Description("On Client")]
        OnClient,
        [Description("Unhired Bench")]
        NotHired,
        [Description("Hired Bench")]
        HiredNotActive
    }
    #endregion

    #region Source
    public enum Source
    {
        Other,
        [Description("Online Ad")]
        WebAd,
        [Description("Word of Mouth")]
        WordOfMouth,
        [Description("Provalus Website")]
        Website,
        [Description("Sign")]
        Sign,
        [Description("Facebook")]
        Facebook,
        [Description("LinkedIn")]
        LinkedIn,
        [Description("Google")]
        Google,
        [Description("Radio")]
        Radio,
        [Description("Television")]
        TV,
        [Description("Printed Material")]
        Print,
        [Description("From a Friend")]
        Friend
    }
    #endregion
    
    #region EmploymeeType
    public enum EmployeeType
    {
        W2,
        C2C
    }
    #endregion
    
    #region Branch
    public enum Branch
    {
        Brewton,
        Manning
    }
    #endregion
}