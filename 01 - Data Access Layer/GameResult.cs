//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JohnBryce
{
    using System;
    using System.Collections.Generic;
    
    public partial class GameResult
    {
        public int GameResultID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public Nullable<System.TimeSpan> TimeSpan { get; set; }
        public Nullable<int> StepsNumber { get; set; }
    
        public virtual User User { get; set; }
    }
}
