using System.Text.Json;
public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        //hashset = unordered collection of unique elements
        HashSet<string> wordSet = new HashSet<string>(); //set for lookup
        List<string> result = new List<string>(); //list to store pairs

        foreach (string word in words)
        {
            string reversed = new string(new char[] { word[1], word[0] }); //reverse the word
            if (wordSet.Contains(reversed)) //if reversed word is in set
            {
                result.Add($"{word} & {reversed}"); //add to result
            }
            wordSet.Add(word); //add word to set
        }
        return result.ToArray();//return result
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        Dictionary<string, int> degrees = new Dictionary<string, int>(); //dictionary to store degrees and counts
        foreach (var line in File.ReadLines(filename))//read the file line by line
        {
            var fields = line.Split(",");
            if (fields.Length <4) {continue;} //skip lines with less than 4 fields
            //extract degree from 4th column

            string degree = fields[3].Trim();
            if (degrees.ContainsKey(degree)) //if degree is already in dictionary
            {
                degrees[degree]++; //increment the count
            }
            else
            {
                degrees[degree] = 1; //initialize the count to 1
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        //convert both words to lower case and remove spaces
        word1 = word1.ToLower().Replace(" ", "");
        word2 = word2.ToLower().Replace(" ", "");
        //if the words are not the same length, they cannot be anagrams
        if (word1.Length != word2.Length)
        {
            return false;
        }
        //fixed array
        int [] charCount = new int[256];
        for (int i = 0; i < word1.Length; i++)
        {
            //increment the count for each character in word1
            charCount[word1[i]]++;
            //decrement the count for each character in word2
            charCount[word2[i]]--;  
        }
        //if all the counts are 0, the words are anagrams
        foreach (int count in charCount)
        {
            if (count != 0)
            {
                return false;
            }

        }
        //if all the counts are 0, the words are anagrams
        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        //define api
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        //create a new http client
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        //read the json data
        var json = reader.ReadToEnd();
        //ignore case when deserializing
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        //deserialize the json data
        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);
        //if no earthquake data is found, return an empty array
        if (featureCollection == null)
        {
            return Array.Empty<string>();
        }

        //process each earthquake feature
        var earthquakeSummaries = featureCollection.Features
            .Select(feature => $"{feature.Properties.Place} - Mag {feature.Properties.Magnitude}").ToArray();
            return earthquakeSummaries;
    

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.

    }
}