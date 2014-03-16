using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExclusionaryList.Models
{
    public class ExclusionaryListModel
    {
        public int selectedId { get; set; }
        public List<Picker> Types { get; set; }
        public List<ListDetails> LineItems { get; set; }
        public List<LineItemDetails> ItemDetails { get; set; }
    }

    public class ListDetails
    {
        public string ListName { get; set; }
        public int ListId { get; set; }
        public string urlPath { get; set; }
    }

    public class LineItemDetails
    {
        public string ListType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string State { get; set; }
        public string License { get; set; }
       
    }

    public class Picker
    {
        public string Description { get; set; }
        public int Id { get; set; }
    }
}