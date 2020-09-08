using Newtonsoft.Json;
using System.Collections.Generic;

namespace GithubApiIsrotel.Models
{
    public class RepositoriesModels
    {
        [JsonProperty("total_count")]
        public int Total_Count { get; set; }

        [JsonProperty("items")]
        public List<UserItems> Items { get; set; }
    }
    public class UserItems
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("html_url")]
        public string Html_Url { get; set; }

        [JsonProperty("owner")]
        public OwnerOfRepo Owner { get; set; }

    }

    public class OwnerOfRepo
    {
        [JsonProperty("avatar_url")]
        public string Avatar_Url { get; set; }
    }

}