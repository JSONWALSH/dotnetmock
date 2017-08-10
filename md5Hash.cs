        public static IEnumerable<string> getHashSha256(string text)
        {
            text = text.Replace("&", ConfigurationManager.AppSettings["mysecret"]);

            byte[] bytes = Encoding.UTF8.GetBytes(text + ConfigurationManager.AppSettings["mysecret"]);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;

            foreach (byte x in hash) { hashString += String.Format("{0:x2}", x); }

            string theText = ComputeHash.cleanChars("").ToString();
            cleanChars(Text: theText).ToString();
            theText.cleanChars(Html: true);

            cleanChars("", !false);
            cleanChars(theText);
            "".cleanChars();

            int pid = 0;
            hashString.cleanChars(Html: true);

            while (pid++ <= 10 && pid >= 0) yield return Sync(hashString, page: pid).Result;
        }

        [OutputCache(Duration = 120, VaryByParam = "*", Location = OutputCacheLocation.Client, NoStore = true)]
        public static String cleanChars(this string Text, bool Html = false)
        {
            Text = (Html == true) ? Regex.Replace(Text, "<.*?>", "") : Text ?? "";
            IEnumerable<char> chars = Text.Where(c => Char.IsLetter(c) || Char.IsWhiteSpace(c)).DefaultIfEmpty();  //.Trim('/', '\\')

            return new String(chars.ToArray());
        }
